using com.xebio.bo.Tj110p01.Constant;
using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Csv;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace com.xebio.bo.Tj110p01.Facade
{
  /// <summary>
  /// Tj110f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj110f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj110f01Form f01VO = (Tj110f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 印刷処理
				string pdfFileNmNaibu = String.Empty;
				InputData inputDataTorimore = new InputData();
				InputData inputDataKetsuban = new InputData();
				OutputInfo outputTorimore = new OutputInfo();
				OutputInfo outputKetsuban = new OutputInfo();
				BoSystemReport reportClsTorimore = new BoSystemReport();
				BoSystemReport reportClsKetsuban = new BoSystemReport();
				int errFlg = 0;

				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();
				// 出力PDFファイル名
				string pdfFileNm = string.Empty;
				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);
				string torimoreKetsuban = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Torimore_ketsuban)].ToString();
				
				#region 取漏れリスト

				// 取漏れ／欠番が「取漏れ」か「空白」の場合、[棚卸取漏れリスト]を出力する
				if (ConditionTorimore_ketsuban_kbn.VALUE_TORIMORE.Equals(torimoreKetsuban)
					|| BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
				{
					#region 印刷用CSV作成

					// CSV出力用リスト
					IList<IList<string>> csvList = new List<IList<string>>();

					ArrayList al = this.MeisaiEdit(f01VO);
					string preFaceNo = string.Empty;
					for (int i = 0; i < al.Count; i++)
					{
						Hashtable ht = (Hashtable)al[i];
						IList<string> csvListData = new List<string>();
						// 検索時未選択状態（= 取漏）の行を対象
						if ( BoSystemConstant.CHECKBOX_OFF.Equals(ht["FLG"].ToString()))
						{
							csvListData.Add(BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));	// 店舗コード
							csvListData.Add(BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)].ToString()));	// 店舗名
							if (preFaceNo.Equals(ht["FACE_NO"].ToString()))
							{
								csvListData.Add("|");
							}
							else
							{
								csvListData.Add(BoSystemFormat.formatFaceNo(ht["FACE_NO"].ToString()));	// フェイスNo
							}
							preFaceNo = ht["FACE_NO"].ToString();
							csvListData.Add(BoSystemString.ZeroToEmpty(ht["TANA_DAN"].ToString()));	// 棚段
							csvList.Add(csvListData);
						}
						
					}
					// 帳票印刷用CSV作成
					string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_X);
					// CSV出力
					string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.TAB);

					#endregion

					#region 印刷処理
					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					outputTorimore = reportClsTorimore.MdGenerateCsvToPDF(inputDataTorimore,
															BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_X,
															Tj110p01Constant.FORMID_01,
															Tj110p01Constant.PGID,
															pdfFileNmNaibu,
															csvFilePath
															);
					#endregion

					#region 件数チェック
					// 出力件数
					if (outputTorimore.ReportState == ReportState.FatalError || outputTorimore.ReportState == ReportState.DataNotFound || outputTorimore.ReportState == ReportState.MaxRecord)
					{
						if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
						{
							errFlg++;
						}
						else
						{
							// 抽出件数は0件です。
							ErrMsgCls.AddErrMsg("E174", "", facadeContext);
						}
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion 
				}
				#endregion

				#region 欠番報告書
				// 取漏れ／欠番が「欠番」か「空白」の場合、[棚卸欠番報告書]を出力する
				if (ConditionTorimore_ketsuban_kbn.VALUE_KETSUBAN.Equals(torimoreKetsuban)
					|| BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
				{

					#region パラメータ設定
					// 店舗コード Dictionaryより取得
					string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());
					
					// 条件を設定
					// 店舗コード
					inputDataKetsuban.AddScreenParameter(1, keyHeadTenpoCd);
					// フェイス№FROM
					inputDataKetsuban.AddScreenParameter(2, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)].ToString(), "-1"));
					// フェイス№TO
					inputDataKetsuban.AddScreenParameter(3, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)].ToString(), "-1"));
					// 棚卸日
					inputDataKetsuban.AddScreenParameter(4, BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD]));
					#endregion

					#region 印刷処理
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					outputKetsuban = reportClsKetsuban.MdGeneratePDF(inputDataKetsuban,
													BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X,
													Tj110p01Constant.FORMID_01,
													Tj110p01Constant.PGID,
													pdfFileNmNaibu
													);
					#endregion

					#region 件数チェック
					// 出力件数
					// 出力件数
					if (outputKetsuban.ReportState == ReportState.FatalError || outputKetsuban.ReportState == ReportState.DataNotFound || outputKetsuban.ReportState == ReportState.MaxRecord)
					{
						if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
						{
							errFlg++;
						}
						else
						{
							// 抽出件数は0件です。
							ErrMsgCls.AddErrMsg("E174", "", facadeContext);
						}
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion
				}
				#endregion

				// エラーチェック（複数帳票）
				if (errFlg == 2)
				{
					ErrMsgCls.AddErrMsg("E174", "", facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region ユーザーマップに登録
				// 複数帳票の場合

				if (errFlg != 2)
				{

					// PDFファイル名（ダウンロード用）取漏れ
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSITORIMORELIST_X),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(outputTorimore.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(outputTorimore.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}
					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);

					// PDFファイル名（ダウンロード用）欠番
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSIKETUBANHOKOKUSYO_V),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(outputKetsuban.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(outputKetsuban.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);

					// 出力PDFファイル名のリストをユーザマップに設定
					facadeContext.UserMap.Add(Tj110p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
				}

				#endregion

				#endregion

				//トランザクションをコミットする。
//				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
//				RollbackTransaction(facadeContext);
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
