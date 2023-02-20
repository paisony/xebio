using com.xebio.bo.Tj150p01.Constant;
using com.xebio.bo.Tj150p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace com.xebio.bo.Tj150p01.Facade
{
  /// <summary>
  /// Tj150f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj150f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

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

				//カード部を取得します。
				Tj150f01Form f01VO = (Tj150f01Form)facadeContext.FormVO;

				// 営業日取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック

				#region ① ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region ② 棚卸データ 期間
			//棚卸期間外の場合、エラー
			//共通部品化
			Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(
									f01VO.Head_tenpo_cd,
									sysDateVO.Sysdate.ToString(),
									facadeContext,
									1);
			#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#region ③ [棚卸終了区分]が「棚卸終了確定」の場合、入力値をチェックする。
				if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1)
				{
					#region ③-1 棚卸データ 終了処理済チェック

					//棚卸終了処理が行われている場合、エラー
					SearchInventory.CheckInventoryEnd(
					f01VO.Head_tenpo_cd,
					TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString(),
					facadeContext,
					1
					);
					#endregion

					#region ③-2 棚卸データ 未送信存在チェック
					// 未送信のデータがある場合、エラー E136			
					decimal miSosinKensu = 0;
					// XMLからSQLを取得する。
					FindSqlResultTable rtCheck = FindSqlUtil.CreateFindSqlResultTable("TJ150P01-01", facadeContext.DBContext);
					// 送信依頼フラグ
					rtCheck.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸日
					rtCheck.BindValue("BIND_TANAOROSI_YMD", (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);

					//検索結果を取得します
					rtCheck.CreateDbCommand();
					IList<Hashtable> tableList = rtCheck.Execute();
					miSosinKensu = (decimal)tableList[0]["CNT"];

					if (miSosinKensu > 0)
					{
						// 未送信のデータがあります。
						ErrMsgCls.AddErrMsg("E136", string.Empty, facadeContext);
					}
					#endregion

					#region ③-3 棚卸データ 送信データ存在チェック
					// 送信データが1件もない場合、エラー 
					decimal sosinKensu = 0;
					// XMLからSQLを取得する。
					FindSqlResultTable rtCheck2 = FindSqlUtil.CreateFindSqlResultTable("TJ150P01-02", facadeContext.DBContext);
					// 送信依頼フラグ
					rtCheck2.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸日
					rtCheck2.BindValue("BIND_TANAOROSI_YMD", (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);

					//検索結果を取得します
					rtCheck2.CreateDbCommand();
					IList<Hashtable> tableList2 = rtCheck2.Execute();
					sosinKensu = (decimal)tableList2[0]["CNT"];

					if (sosinKensu == 0)
					{
						// 送信データが1件もありません。
						ErrMsgCls.AddErrMsg("E131", string.Empty, facadeContext);
					}
					#endregion
				}
				#endregion
				#region ④ [棚卸終了区分]が「棚卸終了解除」の場合、入力値をチェックする。
				else if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN2)
				{
					#region ④-1 棚卸データ 未終了処理チェック
					// 棚卸終了処理が行われていない場合、エラー E211			

					// 棚卸終了フラグ取得
					// XMLからSQLを取得する。
					FindSqlResultTable rtCheck = FindSqlUtil.CreateFindSqlResultTable("TJ150P01-04", facadeContext.DBContext);
					// 店舗コードを設定
					rtCheck.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd(BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd)));
					// 棚卸基準日を設定
					rtCheck.BindValue("BIND_TANAOROSIKIJUN_YMD", (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);
					//検索結果を取得します
					rtCheck.CreateDbCommand();
					IList<Hashtable> tableList = rtCheck.Execute();
					string tanaorosiSyuryoFlg = tableList[0]["TANAOROSISYURYO_FLG"].ToString();
					if (tanaorosiSyuryoFlg != "1")
					{
						// 棚卸終了処理が済んでいません。
						ErrMsgCls.AddErrMsg("E211", string.Empty, facadeContext);
					}
					#endregion
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion 業務チェック

				#region 更新処理
				// [棚卸実施日TBL]を更新する。
				BoSystemLog.logOut("[棚卸実施日TBL]を更新 START");
				int TanaoroshiKakuteih = Upd_TanaorosiJissiYmdTbl(facadeContext, f01VO, logininfo, sysDateVO, (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);
				BoSystemLog.logOut("[棚卸実施日TBL]を更新 END");
				#endregion

				#region 印刷処理
				// [棚卸終了区分]が「棚卸終了確定」の場合、[棚卸集計表]、[棚卸欠番報告書]、[棚卸訂正報告書]、[棚卸修正報告書]の出力を行う。
				if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1)
				{
					InputData inputDataSyukei = new InputData();
					InputData inputDataKetuban = new InputData();
					InputData inputDataTeisei = new InputData();
					InputData inputDataSyusei = new InputData();

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

					#region 棚卸集計表

					///棚卸集計表(X)クエリプラグインです。
					/// ■パラメータ
					/// ① 店舗コード
					/// ② 棚卸日
					/// ③ 棚卸期間FROM
					/// ④ 棚卸期間TO
					/// ⑤ 送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 ""：両方とも出力)

					//[ヘッダ店舗コード]																								
					inputDataSyukei.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					//[棚卸基準日]																								
					inputDataSyukei.AddScreenParameter(2, TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString());
					//[棚卸期間From]
					inputDataSyukei.AddScreenParameter(3, TanaoroshiYmdList["TANAOROSIKIKAN_FROM"].ToString());
					//[棚卸期間To]
					inputDataSyukei.AddScreenParameter(4, TanaoroshiYmdList["TANAOROSIKIKAN_TO"].ToString());
					//送信済みフラグ
					inputDataSyukei.AddScreenParameter(5, "");

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSISYUKEIHYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力 棚卸集計表
					output = reportCls.MdGeneratePDF(inputDataSyukei,
													BoSystemConstant.REPORTID_TANAOROSISYUKEIHYO_X,
													Tj150p01Constant.FORMID_01,
													Tj150p01Constant.PGID,
													pdfFileNmNaibu
													);
					// 件数チェック
					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
//						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSISYUKEIHYO_X),
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
					#region 棚卸欠番報告書
					///棚卸欠番報告書(X)クエリプラグインです。
					/// ■パラメータ
					/// ① 店舗コード
					/// ② フェイスNoFrom
					/// ③ フェイスNoTo
					/// ④ 棚卸基準日

					//[ヘッダ店舗コード]																	
					inputDataKetuban.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					//[フェイスNoFrom]
					inputDataKetuban.AddScreenParameter(2, "-1");
					//[フェイスNoTo]
					inputDataKetuban.AddScreenParameter(3, "-1");
					//[棚卸基準日]																			
					inputDataKetuban.AddScreenParameter(4, TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString());

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力 棚卸欠番報告書
					output = reportCls.MdGeneratePDF(inputDataKetuban,
													BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X,
													Tj150p01Constant.FORMID_01,
													Tj150p01Constant.PGID,
													pdfFileNmNaibu
													);
					// 件数チェック
					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
//						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSIKETUBANHOKOKUSYO_X),
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
					#region 棚卸訂正報告書
					///棚卸訂正報告書(X)クエリプラグインです。
					/// ■パラメータ
					/// ① 店舗コード
					/// ② 棚卸日
					/// ③ 送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 ""：両方とも出力)
					//[ヘッダ店舗コード]																								
					inputDataTeisei.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					//[棚卸基準日]																								
					inputDataTeisei.AddScreenParameter(2, TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString());
					//送信済みフラグ
					inputDataTeisei.AddScreenParameter(3, "");

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITEISEIHOKOKUSYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力 棚卸訂正報告書
					output = reportCls.MdGeneratePDF(inputDataTeisei,
													BoSystemConstant.REPORTID_TANAOROSITEISEIHOKOKUSYO_X,
													Tj150p01Constant.FORMID_01,
													Tj150p01Constant.PGID,
													pdfFileNmNaibu
													);
					// 件数チェック
					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
//						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSITEISEIHOKOKUSYO_X),
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
					#region 棚卸修正報告書
					///棚卸修正報告書(X)のクエリプラグインです。
					/// ■パラメータ
					/// ①店舗コード
					/// ②棚卸日
					/// ③送信日
					/// ④送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 ""：両方とも出力)

					//[ヘッダ店舗コード]																	
					inputDataSyusei.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					//[棚卸基準日]																			
					inputDataSyusei.AddScreenParameter(2, TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString());
					//[棚卸実施日]
					inputDataSyusei.AddScreenParameter(3, TanaoroshiYmdList["TANAOROSIJISSI_YMD"].ToString());
					//送信済みフラグ
					inputDataSyusei.AddScreenParameter(4, "");

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力 棚卸修正報告書
					output = reportCls.MdGeneratePDF(inputDataSyusei,
													BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_X,
													Tj150p01Constant.FORMID_01,
													Tj150p01Constant.PGID,
													pdfFileNmNaibu
													);
					// 件数チェック
					if (output.ReportState == ReportState.DataNotFound)
					{
						// 抽出件数は0件です。
//						ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSISYUSEIHOKOKUSYO_X),
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

					// 出力PDFファイル名のリストをユーザマップに設定
					facadeContext.UserMap.Add(Tj150p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
				}
				#endregion
							
				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				
				#region メッセージダイアログ表示
				//	[棚卸終了区分]が「棚卸終了確定」の場合
				if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1)
				{
					// ダイアログを表示する。I111
	//				InfoMsgCls.AddInfoMsg("I111", string.Empty, facadeContext);
				}
				//	[棚卸終了区分]が「棚卸終了解除」の場合		
				else if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN2)
				{
					// ダイアログを表示する。I112
					InfoMsgCls.AddInfoMsg("I112", string.Empty, facadeContext);
				}
				#endregion

				#region ラジオチェック初期化
				f01VO.Tanaorosisyuryo_kb = ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1;
				#endregion 

			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region ユーザー定義関数
		#region 棚卸実施日TBL 更新
		/// <summary>
		/// [棚卸実施日TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj150f01Form">カード部のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="tanaoroshiKijunYmd">棚卸基準日</param>
		/// <returns>更新件数</returns>
		private int Upd_TanaorosiJissiYmdTbl(IFacadeContext facadeContext,
											Tj150f01Form f01VO,
											LoginInfoVO logininfo,
											SysDateVO sysDateVO,
											decimal tanaoroshiKijunYmd)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TJ150P01-03", facadeContext.DBContext);

			//BIND_UPD_YMD
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			//BIND_UPD_TM
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			//BIND_UPD_TANCD
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// BIND_TANAOROSISYURYO_FLG
			// [棚卸終了区分]が「棚卸終了確定」の場合、1を設定する。
			if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1)
			{
				reader.BindValue("BIND_TANAOROSISYURYO_FLG", 1);
			}
			// [棚卸終了区分]が「棚卸終了解除」の場合、9を設定する																									
			else if (f01VO.Tanaorosisyuryo_kb == ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN2)
			{
				// 送信依頼フラグ
				reader.BindValue("BIND_TANAOROSISYURYO_FLG", 9);
			}
			//BIND_TENPO_CD
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01VO.Head_tenpo_cd));
			//BIND_TANAOROSI_YMD
			reader.BindValue("BIND_TANAOROSI_YMD", tanaoroshiKijunYmd);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#endregion

	}
}
