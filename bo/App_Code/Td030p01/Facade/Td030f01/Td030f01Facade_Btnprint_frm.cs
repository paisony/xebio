using com.xebio.bo.Td030p01.Constant;
using com.xebio.bo.Td030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections.Generic;
using System.IO;

namespace com.xebio.bo.Td030p01.Facade
{
  /// <summary>
  /// Td030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td030f01Facade : StandardBaseFacade
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
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td030f01Form f01VO = (Td030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 選択行チェック

				// 権限取得部品
				bool bKengen = CheckKengenCls.CheckKengen(logininfo);

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
						Td030f01M1Form f01m1VO = (Td030f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// 参照テーブルが「返品確定テーブル」の場合（伝票状態が確定/ﾏﾆｭｱﾙ返品の場合）
							if (((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1TBL_KBN]).Equals(Td030p01Constant.TBL_KAKUTEI))
							{
								// 権限が「本部」の場合、または送信済フラグが「未送信」の場合
								if (bKengen || ((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1SOSINZUMI_FLG]).Equals(ConditionSosinzumi_flg.VALUE_MISOSIN))
								{
									// 印刷対象行あり
									inputflg = 1;
									break;
								}
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

				#endregion

				#region 印刷処理

				string pdfFileNm = "";
				string pdfFileNmNaibu = string.Empty;
				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();
				InputData inputDataTeise = new InputData();
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				for (int i = 0; i < m1List.Count; i++)
				{
					Td030f01M1Form f01m1VO = (Td030f01M1Form)m1List[i];

					// 選択明細のみ対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 参照テーブルが「返品確定テーブル」の場合（伝票状態が確定/ﾏﾆｭｱﾙ返品の場合）
						if (((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1TBL_KBN]).Equals(Td030p01Constant.TBL_KAKUTEI))
						{
							// 権限が「本部」の場合、または送信済フラグが「未送信」の場合
							if (bKengen || ((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1SOSINZUMI_FLG]).Equals(ConditionSosinzumi_flg.VALUE_MISOSIN))
							{
								if (((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO) ||
									((string)f01m1VO.Dictionary[Td030p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL))
								{
									// 店舗コード
									inputData.AddScreenParameter(1, f01m1VO.Dictionary[Td030p01Constant.DIC_M1TENPO_CD].ToString());
									// 伝票番号
									inputData.AddScreenParameter(2, f01m1VO.Dictionary[Td030p01Constant.DIC_M1DENPYO_BANGO].ToString());
									// 処理日付
									inputData.AddScreenParameter(3, f01m1VO.Dictionary[Td030p01Constant.DIC_M1SYORI_YMD].ToString());
									// 店舗控え出力フラグ
									inputData.AddScreenParameter(4, "1");
								}
								else
								{
									// 検索区分(1:伝票番号で検索、2:元伝票番号で検索)
									inputDataTeise.AddScreenParameter(1, "1");
									// 店舗コード
									inputDataTeise.AddScreenParameter(2, f01m1VO.Dictionary[Td030p01Constant.DIC_M1TENPO_CD].ToString());
									// 元伝票番号
									inputDataTeise.AddScreenParameter(3, f01m1VO.Dictionary[Td030p01Constant.DIC_M1DENPYO_BANGO].ToString());
									// 処理日
									inputDataTeise.AddScreenParameter(4, f01m1VO.Dictionary[Td030p01Constant.DIC_M1SYORI_YMD].ToString());
									// 店舗控え印刷フラグ
									inputDataTeise.AddScreenParameter(5, "1");
								}
							}
						}
					}
				}

				// 返品伝票の出力
				if (inputData.GetScreenParameterCount() > 0)
				{
					// PDFファイル名（内部用）
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINDENPYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_HENPINDENPYO,
													Td030p01Constant.FORMID_01,
													Td030p01Constant.PGID,
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

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HENPINDENPYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);
					#endregion
				}


				// 返品訂正伝票の出力
				if (inputDataTeise.GetScreenParameterCount() > 0)
				{
					// PDFファイル名（内部用）
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINTEISEIDENPYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataTeise,
													BoSystemConstant.REPORTID_HENPINTEISEIDENPYO,
													Td030p01Constant.FORMID_01,
													Td030p01Constant.PGID,
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

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HENPINTEISEIDENPYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}
					#endregion

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);
				}

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Td030p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);

			}
			catch (System.Exception ex)
			{
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
