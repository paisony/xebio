using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01028;
using Common.Business.C02000.C02002;
using Common.Business.C99999.ApiUtil;
using Common.Business.C99999.ApiUtil.Ncr050a01;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01024;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Csv;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
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

				// FormVO取得
				// 画面より情報を取得する。
				Tl030f01Form f01VO = (Tl030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 店舗コード
				String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

				// 明細確定フラグ
				bool bMeisaiFlg = false;

				#endregion

				#region 業務チェック

				#region 入力値チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー

				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					int ikakutei = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
						}

						// 明細での確定行がある場合はエラーとしない
						if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							ikakutei = 1;
						}
					}

					if (inputflg == 0 && ikakutei == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}

					// 明細で確定された行のみの場合、更新処理をスキップする
					if (inputflg == 0 && ikakutei == 1)
					{
						bMeisaiFlg = true;
					}
				}

				// 1-2 選択状態
				// 選択された明細の品番数が、ファイルに設定された件数より大きくなった場合、エラー
				// 選択行の合計を取得
				decimal iHinban_su = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						iHinban_su += Convert.ToDecimal(f01m1VO.M1hinban_su);
					}
				}

				if (iHinban_su  > Convert.ToDecimal(Tl030p01Constant.GOKEI_HINBAN_SU)) 
				{
					ErrMsgCls.AddErrMsg("E204", Tl030p01Constant.GOKEI_HINBAN_SU, facadeContext);
				}

				// 申請元 = 本部の行が選択されている場合に、現売価 = 支持売価のチェックボックスがついてないとエラー
				bool bhonbuF = true; 
				for (int i = 0; i < m1List.Count; i++)
				{
					Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
						&& ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString())
						&& BoSystemConstant.CHECKBOX_OFF.Equals(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Genbaika_shijibaika_flg)].ToString()))
					{
						bhonbuF = false;
					}
				}

				if (!bhonbuF)
				{
					ErrMsgCls.AddErrMsg("E228", Tl030p01Constant.GOKEI_HINBAN_SU, facadeContext);
				}

				// 1-4 ラベル発行機名
				// ラベル発行機名が空白（未選択）の場合、エラー

				if (string.IsNullOrEmpty(f01VO.Label_nm))
				{
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext);
				}
				else
				{
					// 1-4 ラベル発行機名
					// ラベル発行機がマスタに存在しない場合エラー

					Hashtable resultHash = new Hashtable();
					resultHash = V01024Check.CheckLabel(BoSystemFormat.formatTenpoCd(logininfo.TnpCd),
														f01VO.Label_cd, 
														facadeContext, 
														"ラベル発行機", 
														new[] { "" });

					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Label_ip = (string)resultHash["LABEL_IP"];
						f01VO.Label_nm = (string)resultHash["LABEL_NM"];
					}

				}

				// 売変期間チェック
				if (PricechangeRangeChk(facadeContext, f01VO, sysDateVO) == -1)
				{
					ErrMsgCls.AddErrMsg("W108", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 警告

				// 1-5 選択状態
				// 店舗判断の場合、警告メッセージを表示する

				// 警告メッセージの応答結果を取得
				string waningFlg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as String, "0");

				if (!waningFlg.Equals("1"))
				{
					for (int i = 0; i < m1List.Count; i++)
					{

						Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];

						// 選択されている行に申請元区分 = ２(店舗)が存在するか確認
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
							&& ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
						{
							// 警告メッセージを表示する
							InfoMsgCls.AddWarnMsg("W109", String.Empty, facadeContext);
							break;
						}
					}

					// 警告メッセージ表示
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
				}

				// ToDoラベル発行機疎通チェックが入る予定


				#endregion

				#region 排他チェック

				// 2-1 更新日時
				// 検索時に取得した更新日、更新時間と[売価変更指示TBL]から取得した更新日、更新時間を比較する。

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");				// 店舗コード
				sRepSql.Append(" AND BAIHENKAISI_YMD = :BIND_BAIHENKAISI_YMD");	// 売変開始日
				sRepSql.Append(" AND BAIHEN_NO = :BIND_BAIHEN_NO");				// 売変№
				sRepSql.Append(" AND KAKUTEI_FLG = 0");							// 確定フラグ

				for (int i = 0; i < m1List.Count; i++)
				{

					Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{

						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();
						String tableId = String.Empty;

						// 選択行(Dictionary)[Ｍ１申請元区分] が「本部」の場合
						if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
						{
							// SQL設定
							tableId = Tl030p01Constant.TABLE_MDCT0010;
						}
						// 選択行(Dictionary)[Ｍ１申請元区分] が「店舗」の場合

						else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
						{
							tableId = Tl030p01Constant.TABLE_MDCT0020;
						}

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 売変開始日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_BAIHENKAISI_YMD";
						bindVO.Value = BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 売変№
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_BAIHEN_NO";
						bindVO.Value = BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								100
						);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}


				#endregion


				#endregion

				#region 更新処理

				// 明細で確定された行のみの場合、更新処理は実施しない
				if (!bMeisaiFlg)
				{
					// 1.明細単位に下記処理を実行
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{

							// ① 申請元区分 = 本部の場合
							if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
							{
								// [自動売変延長データTBL]を削除する。
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 START");
								int iDeleteAutoPriceChangeRt = DeleteAutoPriceChange(facadeContext, f01VO, f01m1VO);
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 END");

								// [売変確定一時TBL]を登録する。
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 START");
								int iInsertBaihenKakuteiTempRt = InsertBaihenKakuteiTemp(facadeContext, f01VO, f01m1VO, sysDateVO);
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 END");

								// [事前売変データTBL]を登録する。
								BoSystemLog.logOut("[事前売変データTBL]を登録する。 START");
								int iInsertJizenBaihenRt = InsertJizenBaihen(facadeContext, f01VO, f01m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[事前売変データTBL]を登録する。 END");

								// [売価変更指示TBL]を更新する。
								BoSystemLog.logOut("[売価変更指示TBL]を更新する。 START");
								int iUpdateBaikaHenkoSijiRt = UpdateBaikaHenkoSiji(facadeContext, f01VO, f01m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[売価変更指示TBL]を更新する。 END");
							}

							// ② 申請元区分 = 店舗の場合
							else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
							{
								// [店舗売変確定TBL]を登録する。
								BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 START");
								int iInsertTenpoBaikaKakuteiRet = InsertTenpoBaikaKakutei(facadeContext, f01VO, f01m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 END");

								// [店舗売変確定TBL]を登録する。(カラー管理商品用）
								BoSystemLog.logOut("[店舗売変確定TBL]を登録する。(カラー管理商品用） START");
								int iInsertTenpoBaikaKakuteiColorSyohinRet = InsertTenpoBaikaKakuteiColorSyohin(facadeContext, f01VO, f01m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[店舗売変確定TBL]を登録する。(カラー管理商品用） END");

								// [売変確定一時TBL]を登録する。
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 START");
								int iInsertTenpoBaihenKakuteiTempRet = InsertTenpoBaihenKakuteiTemp(facadeContext, f01VO, f01m1VO, sysDateVO);
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 END");

								// [店舗売変予定TBL]を更新する。
								BoSystemLog.logOut("[店舗売変予定TBL]を更新する。 START");
								int iUpdateTenpoBaiYoteiRet = UpdateTenpoBaiYotei(facadeContext, f01VO, f01m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[店舗売変予定TBL]を更新する。 END");
							}
						}
					}

					// 2.API(売価変更)を起動する。
					BoSystemLog.logOut("API(売価変更)を起動する。 START");

					int ApiRet = ApiConnectPriceChage(facadeContext, f01VO, sysDateVO, logininfo);
					// エラー判定
					//  0:正常終了
					// -1:異常終了(APIエラー)
					// -2:自社品番エラー(インフォメーション)
					if (ApiRet == 0)
					{
						// 正常終了

					}
					else if (ApiRet == -1)
					{
						// 異常終了。ロールバックし処理を終了する
						RollbackTransaction(facadeContext);
						return;
					}
					else if (ApiRet == -2)
					{
						// 自社品番エラー、インフォメーションを表示する
						// 部品内でメッセージ情報は作成済み
					}
					else if (ApiRet == -3)
					{
						// DBエラーの場合、システムエラー画面を表示
						// 部品内でスロー済み
					}

					BoSystemLog.logOut("API(売価変更)を起動する。 END");

					// 3.[店別単価MST]を更新する。
					BoSystemLog.logOut("[店別単価MST]を更新する。 START");
					int iUpdatePLUPosRt = UpdatePLUPos(facadeContext);
					BoSystemLog.logOut("[店別単価MST]を更新する。 END");

					// [売変確定ワークTBL]を登録する。
					BoSystemLog.logOut("[売変確定ワークTBL]を登録する。 START");
					int iInsertBaihenKakuteiWorkRet = InsertBaihenKakuteiWork(facadeContext, f01VO, sysDateVO, logininfo);
					BoSystemLog.logOut("[売変確定ワークTBL]を登録する。 END");

				}

				#endregion

				// 帳票、売変シール用税率計算
				// 税率計算クラス
				CalcTaxCls calcTax = new CalcTaxCls(facadeContext);
				TaxVO taxvo = new TaxVO();

				#region 印刷用CSV作成

				bool bPrintFlg = true;

				// 印刷用CSV出力用データ取得
				FindSqlResultTable rtCsvSeach = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_32, facadeContext.DBContext);

				// 店舗コード
				rtCsvSeach.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
				rtCsvSeach.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
				rtCsvSeach.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
				rtCsvSeach.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
				rtCsvSeach.BindValue("BIND_TENPO_CD_05", sTenpo_cd);
				rtCsvSeach.BindValue("BIND_TENPO_CD_06", sTenpo_cd);

				// シーケンス
				rtCsvSeach.BindValue("BIND_SEQ_01", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtCsvSeach.BindValue("BIND_SEQ_02", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtCsvSeach.BindValue("BIND_SEQ_03", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtCsvSeach.BindValue("BIND_SEQ_04", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));

				//検索結果を取得します
				rtCsvSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtCsvSeach.Execute();

				// BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// 0件の場合、出力しない
					bPrintFlg = false;
				}

				if (bPrintFlg)
				{

					// 帳票用CSV作成

					// 印刷用CSV出力用リスト
					IList<IList<string>> csvList = BaihenSijiListcls.outBaihenSijiCsvList(tableList, facadeContext);

					// 帳票印刷用CSV作成
					string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X);
					// CSV出力
					string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.PIPE);

					string pdfFileNm = string.Empty;

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X, 1),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					output = reportCls.MdGenerateCsvToPDF(inputData,
															BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X,
															Tl030p01Constant.FORMID_01,
															Tl030p01Constant.PGID,
															pdfFileNm,
															csvFilePath
															);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tl030p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

					// 出力件数
					if (output.ReportState == ReportState.FatalError || output.ReportState == ReportState.DataNotFound || output.ReportState == ReportState.MaxRecord)
					{
						// 抽出件数は0件です。
						ErrMsgCls.AddErrMsg("E174", "", facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

				}

				#endregion

				#region 売変シール発行処理

				bool bSealFlg = true;

				// 印刷用CSV出力用データ取得
				FindSqlResultTable rtSealSeach = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_33, facadeContext.DBContext);

				// シーケンス
				rtSealSeach.BindValue("BIND_SEQ_01", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtSealSeach.BindValue("BIND_SEQ_02", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtSealSeach.BindValue("BIND_SEQ_03", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
				rtSealSeach.BindValue("BIND_SEQ_04", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));

				//検索結果を取得します
				rtSealSeach.CreateDbCommand();

				IList<Hashtable> sealTable = rtSealSeach.Execute();

				// BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (sealTable == null || sealTable.Count <= 0)
				{
					// 0件の場合、出力しない
					bSealFlg = false;
				}

				if (bSealFlg)
				{
					String sPrvBaika = string.Empty;		// 1行前の売価
					String sPrvBumonCd = string.Empty;		// 1行前の部門

					// 売変シールのレイアウト
					string printID = string.Empty;
					// 売変シールのCSVデータ
					string tmpFileName = string.Empty;

					// 売変シールデータを設定
					List<PriceChangeSealVO> sealList = new List<PriceChangeSealVO>();

					// 前行の部門コード
					string prevBumoncd = string.Empty;
					// 前行のハンドラベル
					string prevHandLbl = string.Empty;

					// シール用の税計算クラス
					var sealIds = new List<string>();

					// 売変用CSV作成
					foreach (Hashtable rec in sealTable)
					{
						// 在庫数が1以上の行を対象とする
						if (Convert.ToInt16(rec["FREEZAIKO_SU"].ToString()) > 0)
						{
							// 現在行の部門コード、ハンドラベルを取得
							string nowBumonCd = rec["BUMON_CD"].ToString();
							string nowHandLbl = rec["HANDLBL_KB"].ToString();

							// 部門コードとハンドラベルがブレークしたらメッセージを差し込む
							if (!prevBumoncd.Equals(nowBumonCd) || !prevHandLbl.Equals(nowHandLbl))
							{
								PriceChangeSealVO sealVo_msg = new PriceChangeSealVO();
								sealVo_msg.Baika = BoSystemLabelData.PriceChangeSealConfirmMsgStr(rec["BUMON_NM"].ToString(), rec["MEISYO_NM"].ToString());	// 売価
								sealVo_msg.Labelnm = string.Empty;			// ラベル名
								sealVo_msg.Zeikomikakaku = string.Empty;	// 税込価格
								sealVo_msg.Hakosu = "1";					// 発行枚数
								sealVo_msg.KoteiMongon = string.Empty;		// 固定文言
								sealVo_msg.Layoutnm = string.Empty;			// シールレイアウト情報を取得
								sealList.Add(sealVo_msg);
							}

							string sealtype = "4";	// シールタイプ(Def:10%)
							// 自動判別
							sealtype = rec["TAX_CD"].ToString();
							CalcTaxCls calcTaxSeal = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));

							// 税込金額計算
							taxvo = calcTaxSeal.calcTax(Convert.ToDecimal(rec["KAKUTEIBAIKA_TNK2"].ToString()), Convert.ToDecimal(rec["ZEI_KB"].ToString()));

							PriceChangeSealVO sealVo = new PriceChangeSealVO();
							sealVo.Baika = rec["KAKUTEIBAIKA_TNK"].ToString();				// 売価
							sealVo.Labelnm = rec["MEISYO_NM"].ToString();					// ラベル名
							sealVo.Zeikomikakaku = taxvo.Zeikomi.ToString();				// 税込価格
							sealVo.Hakosu = rec["FREEZAIKO_SU"].ToString();					// 発行枚数
							// 固定文言を設定
							sealVo.KoteiMongon = sealtype.Equals(BoSystemConstant.PRICECHANGESEAL_HYOJUNCD) ? BoSystemConstant.PRICECHANGESEAL_KOTEISTRING : string.Empty;
							// シールレイアウト情報を取得
							printID = BoSystemLabelData.GetPriceChangeSealLayout(Convert.ToInt16(sealtype)) + BoSystemConstant.LABEL_NM_EXTENTS;
							sealVo.Layoutnm = printID;
							if (!sealIds.Contains(printID))
								sealIds.Add(printID);
							sealList.Add(sealVo);

							// 前行の値を設定
							prevBumoncd = rec["BUMON_CD"].ToString();
							prevHandLbl = rec["HANDLBL_KB"].ToString();
						}
					}

					// 売変シールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvPriceChangeSeal(PGID, sealList, printID);

					// CSVファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tl030p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
					// レイアウトファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tl030p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);
				}

				#endregion

				#region 売変確定ワークTBL削除

				// 売変確定ワークTBLを削除する
				BoSystemLog.logOut("売変確定ワークTBLを削除する。 START");
				int iDeleteBaihenKakuteiWorkRet = DeleteBaihenKakuteiWork(facadeContext, f01VO, logininfo);
				BoSystemLog.logOut("売変確定ワークTBLを削除する。 END");

				#endregion

				// トランザクションをコミットする。
				CommitTransaction(facadeContext);

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

		#region [自動売変延長データTBL]を削除する。

		/// <summary>
		/// DeleteAutoPriceChange [自動売変延長データTBL]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <returns>件数</returns>
		private int DeleteAutoPriceChange(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));
			// 売変理由
			reader.BindValue("BIND_BAIHEN_RIYTU", Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU]));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Genbaika_shijibaika_flg)].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定一時TBL]を登録する。(本部指示)

		/// <summary>
		/// InsertBaihenKakuteiTemp [売変確定一時TBL]を登録する。(本部指示)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiTemp(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd= BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1UPD_YMD].ToString())));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1UPD_TM].ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 店舗コード5
			reader.BindValue("BIND_TENPO_CD_05", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));
			// 売変作業開始日
			reader.BindValue("BIND_BAIHENSAGYOKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihensagyokaisi_ymd)));
			// 売変理由
			reader.BindValue("BIND_BAIHEN_RIYTU", Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU]));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Genbaika_shijibaika_flg)].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [事前売変データTBL]を登録する。

		/// <summary>
		/// InsertJizenBaihen [事前売変データTBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertJizenBaihen(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 店舗コード5
			reader.BindValue("BIND_TENPO_CD_05", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));
			// 売変作業開始日
			reader.BindValue("BIND_BAIHENSAGYOKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihensagyokaisi_ymd)));
			// 売変理由
			reader.BindValue("BIND_BAIHEN_RIYTU", Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU]));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Genbaika_shijibaika_flg)].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売価変更指示TBL]を更新する。

		/// <summary>
		/// UpdateBaikaHenkoSiji [売価変更指示TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int UpdateBaikaHenkoSiji(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 店舗コード5
			reader.BindValue("BIND_TENPO_CD_05", sTenpo_cd);
			// 店舗コード6
			reader.BindValue("BIND_TENPO_CD_06", sTenpo_cd);
			// 店舗コード7
			reader.BindValue("BIND_TENPO_CD_07", sTenpo_cd);
			// 店舗コード8
			reader.BindValue("BIND_TENPO_CD_08", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));
			// 売変作業開始日
			reader.BindValue("BIND_BAIHENSAGYOKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihensagyokaisi_ymd)));
			// 売変理由
			reader.BindValue("BIND_BAIHEN_RIYTU", Convert.ToDecimal((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU]));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Genbaika_shijibaika_flg)].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変確定TBL]を登録する。

		/// <summary>
		/// InsertTenpoBaikaKakutei [店舗売変確定TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertTenpoBaikaKakutei(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 確定担当者コード
			reader.BindValue("BIND_KAKUTEI_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 店舗コード5
			reader.BindValue("BIND_TENPO_CD_05", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変確定TBL]を登録する。(カラー管理商品用）

		/// <summary>
		/// InsertTenpoBaikaKakuteiColorSyohin [店舗売変確定TBL]を登録する。(カラー管理商品用）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertTenpoBaikaKakuteiColorSyohin(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 確定担当者コード
			reader.BindValue("BIND_KAKUTEI_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定一時TBL]を登録する。(店舗指示)

		/// <summary>
		/// InsertTenpoBaihenKakuteiTemp [売変確定一時TBL]を登録する。(店舗指示)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <returns>件数</returns>
		private int InsertTenpoBaihenKakuteiTemp(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変予定TBL]を更新する。

		/// <summary>
		/// UpdateTenpoBaiYotei [店舗売変予定TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="Tl030f01M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int UpdateTenpoBaiYotei(IFacadeContext facadeContext, Tl030f01Form f01VO, Tl030f01M1Form f01m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 更新日1
			reader.BindValue("BIND_UPD_YMD_01", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間1
			reader.BindValue("BIND_UPD_TM_01", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新日2
			reader.BindValue("BIND_UPD_YMD_02", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間2
			reader.BindValue("BIND_UPD_TM_02", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd)));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region API(売価変更)を起動する。

		/// <summary>
		/// ApiConnectPriceChage API(売価変更)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>0:正常終了 -1:異常終了(エラー) -2:自社品番エラー(インフォメーション)</returns>
		private int ApiConnectPriceChage(IFacadeContext facadeContext, Tl030f01Form f01VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{

			// 店舗コード
			String stenpo_Cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// エラー判定フラグ
			//  0:正常終了
			// -1:異常終了(エラー)
			// -2:自社品番エラー(インフォメーション)
			int Errkbn = 0;

			// API起動
			ApiResponseVO<Ncr050a01ResponseVO> resVo = Ncr050a01Api.ApiConnectPriceChage(facadeContext, stenpo_Cd, Tl030p01Constant.FORMID_01.ToUpper(), sysDateVO, logininfo);

			#region ■■応答データ取得

			// APIステータスの取得
			string errcd = resVo.ERROR.ERRORCD.ToString();

			if (resVo != null && errcd.Equals(BoSystemApi.APISTATUS_NOMAL))
			{
				// 正常終了の場合
				Errkbn = 0;
			}
			// 業務エラー
			else if (errcd.Equals(BoSystemApi.APISTATUS_GYOMUERR) || errcd.Equals(BoSystemApi.APISTATUS_WARNING))
			{
				// 異常終了の場合
				List<ErrorDetailVO> ErrList = resVo.ERROR.ERRORS;
				string sErrCd = string.Empty;
				if (ErrList.Count == 0)
				{
					Errkbn = -1;
				}
				else
				{
					for (int i = 0; i < ErrList.Count; i++)
					{
						if (i == 0)
						{
							sErrCd = ErrList[i].ERRORID;

							// 明細行ごとにエラーを判定
							if (!string.IsNullOrEmpty(sErrCd))
							{
								if (sErrCd.Equals("E830")
									|| sErrCd.Equals("E831")
									)
								{	
									/*
									 E830:会社コードエラー
									 E831:店舗コードエラー
									 */
									// 異常（API連携エラー）
									Errkbn = -1;
									break;
								}
								else
								{
									/*
									 E834:自社品番エラー
									 E835:カラーエラー
									 */
									Errkbn = -2;
									break;
								}
							}
							else
							{
								// 異常（API連携エラー）
								Errkbn = -1;
								break;
							}
						}
					}
				}
			}
			// 異常エラー
			else
			{
				Errkbn = -1;
			}
			#endregion

			#region ■■応答結果によりエラー、インフォメーションを表示する

			// E834:自社品番エラー、E835:カラーエラーの行が存在した場合、インフォメーションダイアログを表示
			if (Errkbn == -2)
			{
				// インフォメーション情報一行目は固定「以下の商品がPOSに正しく登録されませんでした。」
				InfoMsgCls.AddInfoMsg("I115", string.Empty, facadeContext);

				List<ErrorDetailVO> ErrorMessegeList = resVo.ERROR.ERRORS;

				// 2行目以降はエラー行の情報を元にメッセージ作成
				if (ErrorMessegeList.Count > 0)
				{
					for(int i = 0; i < ErrorMessegeList.Count; i++)
					{
						if (ErrorMessegeList[i].ERRORID.Equals("E834")
							|| ErrorMessegeList[i].ERRORID.Equals("E835"))
						{
							InfoMsgCls.AddInfoMsg("I116",
												BoSystemApi.messageSplit(ErrorMessegeList[i].ERRORMESSAGE),
												facadeContext);
						}
					}
				}
			}
			// 異常終了、E830:会社コードエラー、E831:店舗コードエラーの場合
			else if (Errkbn == -1)
			{
				// POS連携に失敗しました
				ErrMsgCls.AddErrMsg("E226", string.Empty, facadeContext);
			}

			#endregion

			return Errkbn;
		}
		#endregion

		#region [店別単価MST]を更新する。

		/// <summary>
		/// UpdatePLUPos [店別単価MST]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>件数</returns>
		private int UpdatePLUPos(IFacadeContext facadeContext)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 条件なしで更新する

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定ワークTBL]を登録する

		/// <summary>
		/// InsertBaihenKakuteiWork [売変確定ワークTBL]を登録する
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiWork(IFacadeContext facadeContext, Tl030f01Form f01VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_31, facadeContext.DBContext);

			// SEQ
			reader.BindValue("BIND_SEQ", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 担当者コード
			reader.BindValue("BIND_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定ワークTBL]を削除する

		/// <summary>
		/// DeleteBaihenKakuteiWork [売変確定ワークTBL]を削除する
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int DeleteBaihenKakuteiWork(IFacadeContext facadeContext, Tl030f01Form f01VO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_15, facadeContext.DBContext);

			// SEQ
			reader.BindValue("BIND_SEQ", Convert.ToDecimal(f01VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
			// 担当者コード
			reader.BindValue("BIND_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion


		#region 売変期間チェック
		/// <summary>
		/// PricechangeRangeChk 売変期間チェック
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f01Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <returns>0:正常 -1:異常</returns>
		private int PricechangeRangeChk(IFacadeContext facadeContext, Tl030f01Form f01VO, SysDateVO sysDateVO)
		{

			int iRt = -1;
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sBindId = new StringBuilder();

			// 店舗申請行対象フラグ
			bool bFlg = false;

			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 検索時の店舗コード取得
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			// 明細情報取得
			IDataList m1List = f01VO.GetList("M1");

			#region 店舗コード

			// 	店舗コード
			sRepSql.Append(" AND MDCT0010.TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = sTenpo_cd;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region システム日付

			sRepSql.Append(" AND MDCT0010.BAIHENSAGYOKAISI_YMD <=  :BIND_SYS_YMD_01");
			sRepSql.Append(" AND MDCT0010.BAIHENKAISI_YMD >=  :BIND_SYS_YMD_02");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYS_YMD_01";
			bindVO.Value = sysDateVO.Sysdate.ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYS_YMD_02";
			bindVO.Value = sysDateVO.Sysdate.ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region 明細条件

			// 明細条件ヘッダー条件
			sRepSql.Append(" AND (MDCT0010.BUMON_CD,MDCT0010.JISYA_HBN,MDCT0010.IRO_CD) IN ( ");
			sRepSql.Append("     SELECT MDCT0020.BUMON_CD,MDCT0020.JISYA_HBN,MDCT0020.IRO_CD ");
			sRepSql.Append("     FROM   MDCT0020 ");
			sRepSql.Append("     WHERE  MDCT0020.TENPO_CD = :BIND2_TENPO_CD");
			sRepSql.Append("     AND    MDCT0020.KAKUTEI_FLG = 0");

			// 店舗コード(明細共通条件)
			bindList.Add(new BindInfoVO("BIND2_TENPO_CD", sTenpo_cd, BoSystemSql.BINDTYPE_STRING));

			// 部門、売変開始日、売変No
			sRepSql.Append("      AND (MDCT0020.BAIHENKAISI_YMD,MDCT0020.BAIHEN_NO,MDCT0020.BUMON_CD) IN (");

			String First_flg = "S";

			// 条件設定
			for (int i = 0; i < m1List.Count; i++)
			{
				Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1List[i];

				// 店舗申請行が対象
				if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString())
					&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					bFlg = true;

					//1件目はカンマをつけない。
					if (First_flg == "S")
					{
						//初回フラグを終了させる
						First_flg = "E";
					}
					else
					{
						sRepSql.Append(",");
					}

					sRepSql.Append(" ( ");
					sRepSql.Append(" :BIND_KAISI_YMD").Append(i.ToString("0000"));

					// 開始日
					bindList.Add(new BindInfoVO("BIND_KAISI_YMD" + i.ToString("0000"), BoSystemFormat.formatDate(f01m1VO.M1baihenkaisi_ymd), BoSystemSql.BINDTYPE_NUMBER));

					sRepSql.Append(" ,:BIND_BAIHEN_NO").Append(i.ToString("0000"));

					// 売変No
					bindList.Add(new BindInfoVO("BIND_BAIHEN_NO" + i.ToString("0000"),
												BoSystemFormat.formatBaihen_shiji_no(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()),
												BoSystemSql.BINDTYPE_STRING));

					sRepSql.Append(" ,:BIND_BUMON_CD").Append(i.ToString("0000"));

					// 部門コード
					bindList.Add(new BindInfoVO("BIND_BUMON_CD" + i.ToString("0000"),
												BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD]),
												BoSystemSql.BINDTYPE_STRING));

					sRepSql.Append(" ) ");

				}
			}


			sRepSql.Append("            ) ");
			sRepSql.Append("     )");

			#endregion

			// 店舗申請行が存在する場合のみ検索する
			if (bFlg)
			{
				BoSystemSql.AddSql(rtSeach, Tl030p01Constant.SQL_ID_16_REP_WHERE, sRepSql.ToString(), bindList);

				//検索結果を取得します
				rtSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				decimal dCnt = 0;

				// 存在しない場合、正常
				if (tableList == null || tableList.Count <= 0)
				{
					// 正常
					iRt = 0;
				}
				else
				{
					Hashtable resultTbl = tableList[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						// エラー
						iRt = 0;
					}
				}
			}
			// 店舗申請行が存在しない場合は正常終了
			else
			{
				iRt = 0;
			}
			return iRt;

		}
		#endregion


		#endregion

	}
}
