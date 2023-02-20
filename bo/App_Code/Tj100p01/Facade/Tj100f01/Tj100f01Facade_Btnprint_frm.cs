//---------------------------------------------------------
// 標準
//---------------------------------------------------------
//---------------------------------------------------------
// com.xebio.bo.Common
//---------------------------------------------------------
using com.xebio.bo.Tj100p01.Constant;
using com.xebio.bo.Tj100p01.Formvo;
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

namespace com.xebio.bo.Tj100p01.Facade
{
  ///----------------------------------------------------------------------------------
  /// <summary>
  /// Facade：Tj100f01
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  ///----------------------------------------------------------------------------------
  public partial class Tj100f01Facade : StandardBaseFacade
	{
		#region フォームを呼び出します。(ボタンID : Btnprint)
		///------------------------------------------------------------------------------
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		///------------------------------------------------------------------------------
		///【 出力帳票について 】
		///
		///   この画面からは２種類の帳票が出力される。
		///   画面のコンボボックスで指定した内容で出力されるものが変わる。
		///    - 取漏れ：棚卸取漏リスト(V)
		///    - 欠番  ：棚卸欠番報告書(V)
		///    - 空白  ：棚卸取漏リスト(V)、棚卸欠番報告書(V) の両方
		///  
		///------------------------------------------------------------------------------
		///【 帳票ごとの画面入力～PDF出力までの流れ 】
		///
		/// ※CSVファイルの列名やデータ設定内容が大きく異る。
		/// 
		/// 棚卸取漏リスト(V)
		/// ：検索ボタン押下時
		///     1.画面入力値によるデータテーブルのデータ存在判定。
		///     2.画面にデータテーブルからの取得内容の表示。
		/// ：印刷ボタン押下時
		///     3.CSVファイルへ記入する列名設定。
		///     4.画面表示内容の取得。
		///     5.CSVファイルへ記入するデータ設定。
		///     6.CSVファイル出力。
		///     7.PDFファイル出力。
		/// 
		/// 棚卸欠番報告書(V)
		/// ：検索ボタン押下時
		///     1.画面入力値によるデータテーブルのデータ存在判定。
		///     2.画面にデータテーブルからの取得内容の表示。
		/// ：印刷ボタン押下時
		///     3.画面表示内容の取得。
		///     4.クエリープラグインによる画面取得内容を使ったSQL実行。
		///     5.クエリープラグインによるCSVファイルへ書き込む内容のまとめ。
		///     6.CSVファイル出力。
		///     7.PDFファイル出力。
		///     
		///------------------------------------------------------------------------------
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//=========================================================
				// DBコネクション
				//=========================================================

				#region DBコネクション

				// DBコンテキストを設定する。
				SetDBContext(facadeContext);

				// コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				#endregion

				//=========================================================
				// DBコネクション
				//=========================================================

				#region DBコネクション

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj100f01Form f01VO = (Tj100f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				//=========================================================
				// 印刷先の用意
				//=========================================================

				#region 印刷先の用意

				// 変数宣言
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

			    // 取り漏れ欠番を取得
				// ①フォームVOに退避した取り漏れ欠番のキーを取得。
				// ②フォームVOからキーを使って退避した取り漏れ欠番を取得。
				string torimoreKetsuban = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Torimore_ketsuban)].ToString();

				#endregion

				//=========================================================
				// ★棚卸取漏れリスト
				//=========================================================

				#region ★棚卸取漏れリスト

				// 取漏れ／欠番が「取漏れ」か「空白」の場合、[棚卸取漏れリスト]を出力する
				if (ConditionTorimore_ketsuban_kbn.VALUE_TORIMORE.Equals(torimoreKetsuban)
					|| BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
				{
					//=========================================================
					// CSV出力
					//=========================================================

					#region 印刷用CSV作成

					//------------------------------------
					//
					// 主となるCSVデータ格納Listの宣言
					//
					//------------------------------------

					// 例）
					// 1行目：列名
					// 2行目：データ１
					// 3行目：データ２

					// CSV出力用リスト
					IList<IList<string>> csvList = new List<IList<string>>();

					//------------------------------------
					//
					// 列名となる一行を設定
					//
					//------------------------------------

					// CSVファイルの先頭一行となる列名を設定
					IList<string> csvColumnListData = new List<string>();
					csvColumnListData.Add("H店舗コード");
					csvColumnListData.Add("H店舗名");
					csvColumnListData.Add("HフェイスNoラベル");
					csvColumnListData.Add("HフェイスNo1");
					csvColumnListData.Add("HフェイスNo2");
					csvColumnListData.Add("HフェイスNo3");
					csvColumnListData.Add("HフェイスNo4");
					csvColumnListData.Add("HフェイスNo5");
					csvColumnListData.Add("HフェイスNo6");
					csvColumnListData.Add("HフェイスNo7");
					csvColumnListData.Add("HフェイスNo8");
					csvColumnListData.Add("HフェイスNo9");
					csvColumnListData.Add("HフェイスNo10");
					csvColumnListData.Add("MフェイスNo");
					csvColumnListData.Add("M棚段");

					// リストに列名の行を追加
					csvList.Add(csvColumnListData);

					//------------------------------------
					//
					// データとなる行を順に設定
					//
					//------------------------------------

					// フォームVOの明細を編集
					//  - 返り値：明細配列(NO,フェイスNO,棚段,チェック状態,検索時欠番フラグ)
					ArrayList al = this.MeisaiEdit(f01VO);

					// 比較用：前回のフェイスNo
					string preFaceNo = string.Empty;

					// 明細の数だけ繰り返す
					for (int i = 0; i < al.Count; i++)
					{
						Hashtable ht = (Hashtable)al[i];
						IList<string> csvListData = new List<string>();

						// 検索時未選択状態（= 取漏）の行を対象
						if (BoSystemConstant.CHECKBOX_OFF.Equals(ht["FLG"].ToString()))
						{
							// 店舗コード
							csvListData.Add(BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));

							// 店舗名
							csvListData.Add(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)].ToString());

							// フェイスNoラベル
							csvListData.Add("フェイスNo.");

							// フェイスNoFROMTO1～10
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from1)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to1)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from2)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to2)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from3)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to3)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from4)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to4)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from5)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to5)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from6)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to6)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from7)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to7)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from8)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to8)].ToString()));
							csvListData.Add(setFaceNo(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from9)].ToString(), f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to9)].ToString()));

							// フェイスNo
							if (preFaceNo.Equals(ht["FACE_NO"].ToString()))
							{
								csvListData.Add("|");
							}
							else
							{
								csvListData.Add(BoSystemFormat.formatFaceNo(ht["FACE_NO"].ToString()));
							}
							
							// 前回との比較用フェイスNoを更新
							preFaceNo = ht["FACE_NO"].ToString();

							// 棚段
							csvListData.Add(BoSystemString.ZeroToEmpty(ht["TANA_DAN"].ToString()));

							// 一行分のCSVデータをListに格納
							csvList.Add(csvListData);
						}
					}

					//------------------------------------
					//
					// CSV出力処理
					//
					//------------------------------------

					// 帳票印刷用CSV作成
					string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_V);
					
					// CSV出力
					string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.COMMA);

					#endregion

					//=========================================================
					// PDF出力
					//=========================================================

					#region PDF出力

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_V),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					outputTorimore = reportClsTorimore.MdGenerateCsvToPDF(inputDataTorimore,
															BoSystemConstant.REPORTID_TANAOROSITORIMORELIST_V,
															Tj100p01Constant.FORMID_01,
															Tj100p01Constant.PGID,
															pdfFileNmNaibu,
															csvFilePath
															);
					#endregion

					//=========================================================
					// 件数チェック
					//=========================================================

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

				//=========================================================
				// ★棚卸欠番報告書
				//=========================================================

				#region ★棚卸欠番報告書

				// 取漏れ／欠番が「欠番」か「空白」の場合、[棚卸欠番報告書]を出力する
				if (ConditionTorimore_ketsuban_kbn.VALUE_KETSUBAN.Equals(torimoreKetsuban)
					|| BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(torimoreKetsuban))
				{
					#region 印刷用CSV作成
					
					// ※ここで『棚卸取漏れリスト』のようにCSVファイルの列名は設定しない。
					//   列名はクエリープラグインクラスのEntityで設定されたものが適応される。

					//------------------------------------
					//
					// データとなる行を順に設定
					//
					//------------------------------------

					// ※以下で設定する内容はクエリープラグインに画面内容として渡される。

					// 店舗コード Dictionaryより取得
					string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());
					
					// 条件を設定
					// 店舗コード
					inputDataKetsuban.AddScreenParameter(1, keyHeadTenpoCd);
					// 棚卸日
					inputDataKetsuban.AddScreenParameter(2, BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj100p01Constant.DIC_TANAOROSIKIJUN_YMD]));
					// フェイス№FROM
					inputDataKetsuban.AddScreenParameter(3, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)].ToString(), string.Empty));
					// フェイス№TO
					inputDataKetsuban.AddScreenParameter(4, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)].ToString(), string.Empty));
					// フェイス№FROM1
					inputDataKetsuban.AddScreenParameter(5, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from1)].ToString(), string.Empty));
					// フェイス№TO1
					inputDataKetsuban.AddScreenParameter(6, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to1)].ToString(), string.Empty));
					// フェイス№FROM2
					inputDataKetsuban.AddScreenParameter(7, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from2)].ToString(), string.Empty));
					// フェイス№TO2
					inputDataKetsuban.AddScreenParameter(8, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to2)].ToString(), string.Empty));
					// フェイス№FROM3
					inputDataKetsuban.AddScreenParameter(9, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from3)].ToString(), string.Empty));
					// フェイス№TO3
					inputDataKetsuban.AddScreenParameter(10, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to3)].ToString(), string.Empty));
					// フェイス№FROM4
					inputDataKetsuban.AddScreenParameter(11, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from4)].ToString(), string.Empty));
					// フェイス№TO4
					inputDataKetsuban.AddScreenParameter(12, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to4)].ToString(), string.Empty));
					// フェイス№FROM5
					inputDataKetsuban.AddScreenParameter(13, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from5)].ToString(), string.Empty));
					// フェイス№TO5
					inputDataKetsuban.AddScreenParameter(14, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to5)].ToString(), string.Empty));
					// フェイス№FROM6
					inputDataKetsuban.AddScreenParameter(15, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from6)].ToString(), string.Empty));
					// フェイス№TO6
					inputDataKetsuban.AddScreenParameter(16, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to6)].ToString(), string.Empty));
					// フェイス№FROM7
					inputDataKetsuban.AddScreenParameter(17, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from7)].ToString(), string.Empty));
					// フェイス№TO7
					inputDataKetsuban.AddScreenParameter(18, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to7)].ToString(), string.Empty));
					// フェイス№FROM8
					inputDataKetsuban.AddScreenParameter(19, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from8)].ToString(), string.Empty));
					// フェイス№TO8
					inputDataKetsuban.AddScreenParameter(20, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to8)].ToString(), string.Empty));
					// フェイス№FROM9
					inputDataKetsuban.AddScreenParameter(21, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from9)].ToString(), string.Empty));
					// フェイス№TO9
					inputDataKetsuban.AddScreenParameter(22, BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to9)].ToString(), string.Empty));
					
					#endregion

					//------------------------------------
					//
					// PDF出力処理
					//
					//------------------------------------

					#region PDF出力処理

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_V),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					outputKetsuban = reportClsKetsuban.MdGeneratePDF(inputDataKetsuban,
													BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_V,
													Tj100p01Constant.FORMID_01,
													Tj100p01Constant.PGID,
													pdfFileNmNaibu
													);

					#endregion

					//=========================================================
					// 件数チェック
					//=========================================================

					#region 件数チェック

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

				//=========================================================
				// エラーチェック
				//=========================================================

				#region エラーチェック

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

				#endregion

				//=========================================================
				// ユーザマップ設定
				//=========================================================

				#region ユーザーマップに登録

				// 常に複数帳票のパターンで出力する
				// 複数帳票の場合
				if (errFlg != 2)
				{
					// PDFファイル名（ダウンロード用）取漏れ
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSITORIMORELIST_V),
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
					facadeContext.UserMap.Add(Tj100p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
				}

				#endregion
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

		///------------------------------------------------------------------------------
		/// <summary>
		/// フェイスNO印字
		/// </summary>
		/// <param name="String">faceNoFrom</param>
		/// <param name="String">faceNoTo</param>
		///------------------------------------------------------------------------------
		private string setFaceNo(string faceNoFrom, string faceNoTo)
		{
			// 未設定の場合、空白を返す
			if (string.IsNullOrEmpty(faceNoFrom) || string.IsNullOrEmpty(faceNoTo))
			{
				return string.Empty;
			}

			// フェイスNOフォーマット編集
			faceNoFrom = BoSystemFormat.formatFaceNo(faceNoFrom);
			faceNoTo = BoSystemFormat.formatFaceNo(faceNoTo);

			// フェイスNOFROM、TOを結合し返却
			return faceNoFrom + Tj100p01Constant.FACE_NO_DELIMITER + faceNoTo;
		}
		#endregion
	}
}
