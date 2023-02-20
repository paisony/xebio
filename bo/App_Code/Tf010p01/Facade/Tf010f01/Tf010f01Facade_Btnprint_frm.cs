using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Formvo;
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

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf010f01Form f01VO = (Tf010f01Form)facadeContext.FormVO;
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
					foreach (Tf010f01M1Form f01m1VO in m1List.ListData)
					{
						
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
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
				InputData inputDataProof = new InputData();
				InputData inputDataFurikae = new InputData();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// 店舗コード
					inputDataProof.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01m1VO.M1shinsei_tenpo_cd));
					// 処理日付
					inputDataProof.AddScreenParameter(2, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD].ToString()));
					// 伝票番号
					inputDataProof.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO].ToString()));
					// テーブル区分
					inputDataProof.AddScreenParameter(4, f01m1VO.Dictionary[Tf010p01Constant.DIC_M1TBLFLG].ToString());
					// 明細ソート
					inputDataProof.AddScreenParameter(5, f01VO.Meisai_sort);

					// 選択明細かつ、権限ありまたは未送信のみ対象
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox)
						&&  (  CheckKengenCls.CheckKengen(logininfo)
							|| BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SOSINZUMI_FLG].ToString())))
					{

						// 店舗コード
						inputDataFurikae.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01m1VO.M1shinsei_tenpo_cd));
						// 処理日付
						inputDataFurikae.AddScreenParameter(2, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD].ToString()));
						// 伝票番号
						inputDataFurikae.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO].ToString()));
						// テーブル区分
						inputDataFurikae.AddScreenParameter(4, f01m1VO.Dictionary[Tf010p01Constant.DIC_M1TBLFLG].ToString());
						// 会社コード
						inputDataFurikae.AddScreenParameter(5, logininfo.CopCd);
						// 店舗控え出力フラグ
						inputDataFurikae.AddScreenParameter(6, "1");
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

				// 帳票区分
//				string reportKbn = string.Empty;
//				if (inputDataProof.GetScreenParameterCount() > 0
//					&& inputDataFurikae.GetScreenParameterCount() > 0)
//				{
//					// 複数帳票(ﾏﾆｭｱﾙ仕入伝票＆仕入訂正伝票)
//					reportKbn = Tf010p01Constant.REPORT_KBN_ALL;
//				}
//				else if (inputDataProof.GetScreenParameterCount() > 0)
//				{
//					// 商品経費振替プルーフリスト
//					reportKbn = Tf010p01Constant.REPORT_KBN_PROOF;
//	
//				}
//				else if (inputDataFurikae.GetScreenParameterCount() > 0)
//				{
//					// 商品経費振替伝票
//					reportKbn = Tf010p01Constant.REPORT_KBN_FURIKAE;
//	
//				}
//				f01VO.Dictionary[Tf010p01Constant.DIC_REPORT_KBN] = reportKbn;

				// 商品経費振替プルーフリスト
				if (inputDataProof.GetScreenParameterCount() > 0)
				{
					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEPROOFLIST),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataProof,
													BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEPROOFLIST,
													Tf010p01Constant.FORMID_01,
													Tf010p01Constant.PGID,
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

//					// 複数帳票の場合
//					if (reportKbn.Equals(Tf010p01Constant.REPORT_KBN_ALL))
//					{
						// PDFファイル名（ダウンロード用）
						pdfFileNm = string.Format(
							"{0}.{1}",
							BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEPROOFLIST),
							BoSystemConstant.RPT_PDF_EXTENSION
							);

						if (!string.IsNullOrEmpty(output.TransferFile))
						{
							// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
							File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
						}

						// ファイル名をリストに追加
						pdfFileNmList.Add(pdfFileNm);
//					}
//					// 単一帳票の場合
//					else
//					{
//						// PDFをファイルをユーザマップに設定
//						facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNmNaibu);
//					}
				}

				// 商品経費振替伝票
				if (inputDataFurikae.GetScreenParameterCount() > 0)
				{
					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataFurikae,
													BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X,
													Tf010p01Constant.FORMID_01,
													Tf010p01Constant.PGID,
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

//					// 複数帳票の場合
//					if (reportKbn.Equals(Tf010p01Constant.REPORT_KBN_ALL))
//					{
						// PDFファイル名（ダウンロード用）
						pdfFileNm = string.Format(
							"{0}.{1}",
							BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_X),
							BoSystemConstant.RPT_PDF_EXTENSION
							);

						if (!string.IsNullOrEmpty(output.TransferFile))
						{
							// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
							File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
						}

						// ファイル名をリストに追加
						pdfFileNmList.Add(pdfFileNm);

//						// 出力PDFファイル名のリストをユーザマップに設定
//						facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
//					}
//					// 単一帳票の場合
//					else
//					{
//						// PDFをファイルをユーザマップに設定
//						facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNmNaibu);
//					}
				}
				// 出力PDFファイル名のリストをユーザマップに設定
				facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);

				#endregion
				
			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
