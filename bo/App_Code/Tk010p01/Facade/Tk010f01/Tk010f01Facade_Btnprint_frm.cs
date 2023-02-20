using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tk010f01Form f01VO = (Tk010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧表出力フラグ
				Boolean PrintFlg = true;

				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();
				// 出力PDFファイル名
				string pdfFileNm = string.Empty;

				// X
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// V
				OutputInfo output2 = new OutputInfo();
				BoSystemReport reportCls2 = new BoSystemReport();

				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E174", "", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// [承認状態]が却下の場合で、選択行が存在しない場合はエラー
						if (ConditionSyonin_jotai2.VALUE_SYONIN_JOTAI22.Equals(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syonin_flg)].ToString()))
						{
							ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
						}
						else
						// それ以外の場合、一覧表出力フラグをfalseにする
						{
							PrintFlg = false;
						}
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

				//印刷エラーフラグ
				bool printErrorFlg = false;
				// ----------------------
				// 評価損確定一覧表
				// ----------------------
				#region 評価損確定一覧表

				if (PrintFlg)
				{
					//string pdfFileNm = string.Empty;

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					// 評価損確定一覧表
					// パラメータ
					//  画面ID
					//  店舗コード				
					//  処理月
					//  承認状態
					//  評価損種別区分
					//  申請日			
					//  再申請フラグ

					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];
						// Ｍ１選択フラグ(隠し)が"1"の場合、以下の処理を実施する。
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// パラメタを配列形式で格納します
							// 画面ID
							inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(Tk010p01Constant.PGID));
							// 店舗コード
							inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()));
							// 処理月
							inputData.AddScreenParameter(3, BoSystemString.LeftB(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syori_ym)].ToString(), 6));
							// 承認状態
							inputData.AddScreenParameter(4, f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString());
							// 評価損種別区分
							inputData.AddScreenParameter(5, f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString());
							// 申請日
							inputData.AddScreenParameter(6, BoSystemFormat.formatDate(BoSystemString.Nvl(f01m1VO.M1apply_ymd,"0")));
							// 再申請フラグ
							inputData.AddScreenParameter(7, f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString());		
					
						}
					}

					//OutputInfo output = new OutputInfo();
					//BoSystemReport reportCls = new BoSystemReport();

					// Xの場合
					if (CheckCompanyCls.IsXebio())
					{


						// PDFファイル名
						pdfFileNm = string.Format("{0}.{1}",
													BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_X, 1),
													BoSystemConstant.RPT_PDF_EXTENSION
													);

						// 帳票を出力
						output = reportCls.MdGeneratePDF(inputData,
														BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_X,
														Tk010p01Constant.FORMID_01,
														Tk010p01Constant.PGID,
														pdfFileNm
														);

					}
					// X以外の場合
					else
					{
						// PDFファイル名
						pdfFileNm = string.Format("{0}.{1}",
													BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_V, 1),
													BoSystemConstant.RPT_PDF_EXTENSION
													);

						// 帳票を出力
						output = reportCls.MdGeneratePDF(inputData,
														BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_V,
														Tk010p01Constant.FORMID_01,
														Tk010p01Constant.PGID,
														pdfFileNm
														);
					}

					// 出力件数
					if (output.ReportState == ReportState.FatalError || output.ReportState == ReportState.DataNotFound || output.ReportState == ReportState.MaxRecord)
					{
						//ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
						printErrorFlg = true;
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					//if (MessageDisplayUtil.HasError(facadeContext))
					//{
					//	return;
					//}

					// PDFをファイルをユーザマップに設定
					//facadeContext.UserMap.Add(Tk010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				}
				#endregion

				// ----------------------
				// 評価損確定集計表
				// ----------------------
				#region 評価損確定集計表

				//string pdfFileNm2 = string.Empty;

				// 帳票ツールに渡すパラメータを格納
				InputData inputData2 = new InputData();

				// 評価損確定集計表
				// パラメータ
				//  店舗コード				
				//  更新日
				//  処理日付
				//  承認状態
				//  決済状態
				//  評価損種別区分		
				//  再申請フラグ
				//OutputInfo output2 = new OutputInfo();
				//BoSystemReport reportCls2 = new BoSystemReport();

				// パラメタを配列形式で格納します
				// 店舗コードFrom
				inputData2.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Tenpo_cd_from)].ToString()));
				// 店舗コードTo
				inputData2.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Tenpo_cd_to)].ToString()));
				// 処理月
				inputData2.AddScreenParameter(3, BoSystemString.LeftB(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syori_ym)].ToString(), 6));
				// 決裁状態
				inputData2.AddScreenParameter(4, GetdrpCtlSelect(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Kessai_flg)].ToString()));
				// 承認状態
				inputData2.AddScreenParameter(5, GetdrpCtlSelect(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syonin_flg)].ToString()));
				// 評価損種別
				inputData2.AddScreenParameter(6, GetdrpCtlSelect(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString()));
				// 再申請フラグ
				inputData2.AddScreenParameter(7, GetdrpCtlSelect(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Sinsei_kb)].ToString()));	

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONKAKUTEISYUKEIHYO, 1),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票を出力
				output2 = reportCls2.MdGeneratePDF(inputData2,
												BoSystemConstant.REPORTID_HYOKASONKAKUTEISYUKEIHYO,
												Tk010p01Constant.FORMID_01,
												Tk010p01Constant.PGID,
												pdfFileNm
												);

				// 出力件数
				if (output2.ReportState == ReportState.FatalError || output2.ReportState == ReportState.DataNotFound || output2.ReportState == ReportState.MaxRecord)
				{
					// ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					printErrorFlg = true;

				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}

				// PDFをファイルをユーザマップに設定
				//facadeContext.UserMap.Add(Tk010p01Constant.FCDUO_RRT_FLNM_2, pdfFileNm2);

				#endregion

				#endregion

				// 印刷エラー
				if (printErrorFlg)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region ユーザーマップに登録
				// 複数帳票
				// Xの場合
				if (CheckCompanyCls.IsXebio())
				{
					// PDFファイル名（ダウンロード用）評価損確定一覧表(X)
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HYOKASONKAKUTEIITIRANHYO_X),
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
				else
				{
					// PDFファイル名（ダウンロード用）評価損確定一覧表(V)
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HYOKASONKAKUTEIITIRANHYO_V),
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

				// PDFファイル名（ダウンロード用）評価損確定集計表
				pdfFileNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HYOKASONKAKUTEISYUKEIHYO),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				if (!string.IsNullOrEmpty(output2.TransferFile))
				{
					// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
					File.Copy(output2.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
				}

				// ファイル名をリストに追加
				pdfFileNmList.Add(pdfFileNm);

				// 出力PDFファイル名のリストをユーザマップに設定
				facadeContext.UserMap.Add(Tk010p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
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

		#region ドロップダウン値取得
		/// <summary>
		/// ドロップダウン値取得
		/// </summary>
		/// <param name="String">drpCtl</param>
		public string GetdrpCtlSelect(String drpCtl)
		{
			String rt = string.Empty;

			if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(drpCtl))
			{
				rt = drpCtl;
			}

			return rt;
		}
		#endregion

	}
}
