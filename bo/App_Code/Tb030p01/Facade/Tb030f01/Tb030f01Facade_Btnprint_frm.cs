using com.xebio.bo.Tb030p01.Constant;
using com.xebio.bo.Tb030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01018;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.xebio.bo.Tb030p01.Facade
{
  /// <summary>
  /// Tb030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb030f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnprint)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb030f01Form f01VO = (Tb030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);

				#endregion

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb030f01M1Form f01m1VO = (Tb030f01M1Form)m1List[i];

						// 選択行の場合
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// 選択行の伝票状態がﾏﾆｭｱﾙ仕入、訂正伝票
							// かつ、送信済フラグが未送信または、本部ユーザーの場合は印刷対象
							if ((BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB])
									|| BoSystemConstant.KAKUTEI_SB_SHIIRE_TSUJO_TEISEI.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB])
									|| BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL_TEISEI.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]))
								&& (CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo())
									|| BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals(f01m1VO.Dictionary[Tb030p01Constant.DIC_M1SOSINZUMI_FLG].ToString()))
								)
							{
								inputflg = 1;
							}
						}
					}

					if (inputflg == 0)
					{
						// 印刷する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 印刷処理

				// 帳票ツールに渡すパラメータを格納
				InputData inputDataManual = new InputData();
				InputData inputDataTeisei = new InputData();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb030f01M1Form f01m1VO = (Tb030f01M1Form)m1List[i];
					// 選択明細のみ対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 確定種別がﾏﾆｭｱﾙ仕入の場合
						if (BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]))
						{
							// 会社コード
							inputDataManual.AddScreenParameter(1, logininfo.CopCd);
							// 仕入先コード
							inputDataManual.AddScreenParameter(2, BoSystemFormat.formatSiiresakiCd(f01m1VO.M1siiresaki_cd));
							// 伝票番号
							inputDataManual.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							// 指定納品日
							inputDataManual.AddScreenParameter(4, BoSystemFormat.formatDate(f01m1VO.M1nyukayotei_ymd));
							// 店舗コード
							inputDataManual.AddScreenParameter(5, tenpoCd);
							// 店舗控え出力フラグ
							inputDataManual.AddScreenParameter(6, "1");

						}
						// 確定種別が通常訂正、ﾏﾆｭｱﾙ訂正の場合
						else if (BoSystemConstant.KAKUTEI_SB_SHIIRE_TSUJO_TEISEI.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB])
								|| BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL_TEISEI.Equals((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]))
						{
							// 伝票種別(1:伝票番号、2:元伝票番号)
							inputDataTeisei.AddScreenParameter(1, "1");
							// 会社コード
							inputDataTeisei.AddScreenParameter(2, logininfo.CopCd);
							// 確定種別
							inputDataTeisei.AddScreenParameter(3, f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB].ToString());
							// 仕入先コード
							inputDataTeisei.AddScreenParameter(4, BoSystemFormat.formatSiiresakiCd(f01m1VO.M1siiresaki_cd));
							// 伝票番号
							inputDataTeisei.AddScreenParameter(5, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							// 指定納品日
							inputDataTeisei.AddScreenParameter(6, BoSystemFormat.formatDate(f01m1VO.M1nyukayotei_ymd));
							// 店舗コード
							inputDataTeisei.AddScreenParameter(7, tenpoCd);
							// 店舗控え出力フラグ
							inputDataTeisei.AddScreenParameter(8, "1");
						}
					}
				}

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();
				// 出力PDFファイル名
				string pdfFileNm = string.Empty;
				// 出力PDFファイル名（内部用）
				string pdfFileNmNaibu = string.Empty;
				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

				// ﾏﾆｭｱﾙ仕入伝票の出力
				if (inputDataManual.GetScreenParameterCount() > 0)
				{
					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_MANUALSIIREDENPYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataManual,
													BoSystemConstant.REPORTID_MANUALSIIREDENPYO,
													Tb030p01Constant.FORMID_01,
													Tb030p01Constant.PGID,
													pdfFileNmNaibu
													);

					#region 件数チェック

					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_MANUALSIIREDENPYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);
				}

				// 仕入訂正伝票の出力
				if (inputDataTeisei.GetScreenParameterCount() > 0)
				{
					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SIIRETEISEIDENPYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataTeisei,
													BoSystemConstant.REPORTID_SIIRETEISEIDENPYO,
													Tb030p01Constant.FORMID_01,
													Tb030p01Constant.PGID,
													pdfFileNmNaibu
													);

					#region 件数チェック

					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SIIRETEISEIDENPYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);

				}
				// 出力PDFファイル名のリストをユーザマップに設定
				facadeContext.UserMap.Add(Tb030p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);

				#endregion

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

		}
		#endregion
	}
}
