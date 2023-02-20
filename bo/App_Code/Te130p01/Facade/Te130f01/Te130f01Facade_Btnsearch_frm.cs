using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01006;
using Common.Business.V01000.V01026;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Te130p01.Facade
{
  /// <summary>
  /// Te130f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te130f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				//以下に業務ロジックを記述する。

				//トランザクションをコミットする。
				//	CommitTransaction(facadeContext);

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Te130f01Form f01VO = (Te130f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 単項目チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
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
				// 1-2 入荷店コード
				// 店舗マスタを検索し、存在しない場合エラー
				f01VO.Juryoten_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01026Check.CheckTenpoAll(f01VO.Jyuryokaisya_cd
														, f01VO.Jyuryoten_cd
														, facadeContext
														, string.Empty
														, null
														, "入荷店"
														, new[] { "Jyuryoten_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Juryoten_nm = (string)resultHash["TENPO_NM"];
					}
				}

				//1-3出荷会社コード
				// 会社コード

				// 名称MST(KASY)に存在しない場合エラー
				if (!string.IsNullOrEmpty(BoSystemString.AllZeroToEmpty(f01VO.Syukkakaisya_cd)))
				{
					// 出荷会社コードの前0除去
					string unformatJyuryokaisyaCd = Convert.ToInt32(f01VO.Syukkakaisya_cd).ToString();

					Hashtable kaisyaInfo = V01006Check.CheckKaisya(f01VO.Syukkakaisya_cd
																, facadeContext
																, string.Empty
																, null
																, "出荷会社コード"
																, new[] { "Syukkakaisya_cd" }
																, null
																, null
																, null
																, 0
																, 0
																);

				}

				// 1-3 出荷店コード
				//       店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01026Check.CheckTenpoAll(f01VO.Syukkakaisya_cd
														, f01VO.Syukkaten_cd
														, facadeContext
														, string.Empty
														, null
														, "出荷店"
														, new[] { "Syukkaten_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Syukkatenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}
				//1-5旧自社品番 存在
				//発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Old_jisya_hbn,	// 自社品番
						f01VO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });

					// 名称をラベルに設定
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}
				//1-6旧自社品番 0以外

				//1-7スキャンコード 存在
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_JANCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Scan_cd,			// スキャンコード
						f01VO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}
				}
				//1-8スキャンコード 0以外

				//2-1伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Denpyo_bango_from,
									f01VO.Denpyo_bango_to,
									facadeContext,
									"伝票番号",
									new[] { "Denpyo_bango_from", "Denpyo_bango_to" }
									);
				}
				//2-2移動伝票番号ＦＲＯＭ >移動伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Idodenpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Idodenpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Idodenpyo_bango_from,
									f01VO.Idodenpyo_bango_to,
									facadeContext,
									"移動伝票",
									new[] { "Idodenpyo_bango_from", "Idodenpyo_bango_to" }
									);
				}
				//2-3指示番号ＦＲＯＭ >指示番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Siji_bango_from,
									f01VO.Siji_bango_to,
									facadeContext,
									"指示番号",
									new[] { "Siji_bango_from", "Siji_bango_to" }
									);
				}
				//2-4入荷日ＦＲＯＭ > 入荷日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Jyuryo_ymd_from) && !string.IsNullOrEmpty(f01VO.Jyuryo_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Jyuryo_ymd_from,
									f01VO.Jyuryo_ymd_to,
									facadeContext,
									"入荷日",
									new[] { "Jyuryo_ymd_from", "Jyuryo_ymd_to" }
									);
				}
				//2-5出荷日ＦＲＯＭ > 出荷日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from) && !string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Syukka_ymd_from,
									f01VO.Syukka_ymd_to,
									facadeContext,
									"出荷日",
									new[] { "Syukka_ymd_from", "Syukka_ymd_to" }
									);
				}
				// 2-6 出荷店コード、会社コード
				//      出荷店コード入力時は会社コードが未入力の場合エラー
				if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
				{
					if (string.IsNullOrEmpty(f01VO.Syukkakaisya_cd))
					{
						ErrMsgCls.AddErrMsg("E160", string.Empty, facadeContext, new[] { "Syukkaten_cd", "Syukkakaisya_cd" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 件数チェック

				//3-1検索件数が0件の場合エラー
				//3-2検索件数が最大件数を超える場合エラー
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Te130p01Constant.SQL_ID_01, facadeContext.DBContext);

				#region SQL設定

				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				#endregion

				BoSystemLog.logOut("[企業間仕入TBL(H)]件数を検索 START");
				//「空白」「確定」「差異あり」の場合
				if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI1)
						|| f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI3)
						|| f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 検索条件設定
					AddWhere(f01VO, rtChk, 2);
				}
				else
				{
					// 検索条件設定
					AddWhere(f01VO, rtChk, 1);
				}


				//検索結果を取得します
				//	rtChk.CreateDbCommand();

				IList<Hashtable> tableListcnt = rtChk.Execute();

				BoSystemLog.logOut("SQL: " + rtChk.LogSql);

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 検索件数の設定
				f01VO.Searchcnt = dCnt.ToString();
				BoSystemLog.logOut("[企業間仕入TBL(H)件数]を検索 END");

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Te130p01Constant.SQL_ID_02, facadeContext.DBContext);

				BoSystemLog.logOut("[企業間仕入TBL(H)]を検索 START");

				//「空白」「確定」「差異あり」の場合
				if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI1)
						|| f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI3)
							|| f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 検索条件設定
					AddWhere(f01VO, rtSeach, 2);
				}
				else
				{
					// 検索条件設定
					AddWhere(f01VO, rtSeach, 1);
				}

				rtSeach.BindValue(Te130p01Constant.REP_ORDER_JISYAKAIASYA1, Convert.ToDecimal(f01VO.Jyuryokaisya_cd));
				rtSeach.BindValue(Te130p01Constant.REP_ORDER_JISYAKAIASYA2, Convert.ToDecimal(f01VO.Jyuryokaisya_cd));
				BoSystemLog.logOut("[企業間仕入TBL(H)]を検索 END");

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				// 会社コードを取得
				decimal loginkaisyacd = Convert.ToDecimal(logininfo.CopCd);
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Te130f01M1Form f01m1VO = new Te130f01M1Form();


					f01m1VO.M1rowno = iCnt.ToString();										// Ｍ１行NO
					// 出荷会社コードを取得
					decimal syukkakaisyacd = Convert.ToDecimal(rec["SYUKKAKAISYA_CD"].ToString());
					if (loginkaisyacd == syukkakaisyacd)
					{
						// 自社の場合は空白
						f01m1VO.M1syukkakaisya_cd = string.Empty;							// Ｍ１出荷会社
					}
					else
					{
						f01m1VO.M1syukkakaisya_cd = rec["SYUKKAKANA_NM"].ToString();		// Ｍ１出荷会社
					}
					f01m1VO.M1syukkaten_cd = rec["SYUKKATEN_CD"].ToString();				// Ｍ１出荷店コード
					f01m1VO.M1syukkatenpo_nm = rec["SYUKKATEN_NM"].ToString();				// Ｍ１出荷店名

					// 入荷会社コードを取得
					decimal nyukakaisyacd = Convert.ToDecimal(rec["JYURYOKAISYA_CD"].ToString());
					if (loginkaisyacd == nyukakaisyacd)
					{
						f01m1VO.M1jyuryokaisya_cd = string.Empty;							// Ｍ１入荷会社
					}
					else
					{
						f01m1VO.M1jyuryokaisya_cd = rec["NYUKAKANA_NM"].ToString();			// Ｍ１入荷会社
					}

					f01m1VO.M1jyuryoten_cd = rec["JYURYOTEN_CD"].ToString();			    // Ｍ１入荷店コード
					f01m1VO.M1juryoten_nm = rec["NYUKATEN_NM"].ToString();					// Ｍ１入荷店名
					//f01m1VO. = rec["DENPYO_BANGO"].ToString();		// Ｍ１伝票番号
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1DENPYOBANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
					f01m1VO.M1idodenpyo_bango = rec["IDODENPYO_BANGO"].ToString();			// Ｍ１移動伝票番号
					f01m1VO.M1siji_bango = BoSystemString.AllZeroToEmpty(rec["SYUKKA_SIJI_NO"].ToString());	// Ｍ１指示番号
					f01m1VO.M1syukka_ymd = rec["SYUKKA_YMD"].ToString();					// Ｍ１出荷日
					f01m1VO.M1jyuryo_ymd = rec["JYURYO_YMD"].ToString();					// Ｍ１入荷日
					f01m1VO.M1nyukayotei_su = rec["NYUKAYOTEIGOUKEI_SU"].ToString();		// Ｍ１予定数量
					f01m1VO.M1nyukajisseki_su = rec["NYUKAJISSEKIGOUKEI_SU"].ToString();	// Ｍ１確定数量
					f01m1VO.M1kyakucyu = rec["KYAKUTYU"].ToString();						//** ○Ｍ１客注
					if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI1)
						|| f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI3)
						|| f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						f01m1VO.M1syorinm = string.Empty;
						f01m1VO.M1syori_ymd = string.Empty;
						f01m1VO.M1syori_tm = string.Empty;
					}
					else
					{
						f01m1VO.M1syorinm = rec["SYORI_SB"].ToString();					//** Ｍ１処理名
						f01m1VO.M1syori_ymd = rec["RIREKI_SYORI_YMD"].ToString();		// Ｍ１処理日
						f01m1VO.M1syori_tm = BoSystemFormat.formatTime((decimal)rec["RIREKI_SYORI_TM"], 1);		// Ｍ１処理時間
					}

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)

					// Dictionary
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1RIREKI_NO, rec["RIREKI_NO"].ToString());				// 履歴No
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1AKAKURO_KBN, rec["AKAKURO_KBN"].ToString());			// 赤黒区分
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());		// 送信済みフラグ                    
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SCM_CD, rec["SCM_CD"].ToString());					// SCMコード
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1NYUKAKAI_CD, rec["JYURYOKAISYA_CD"].ToString());		// 入荷会社コード
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1NYUKAKAI_NM, rec["NYUKAKAI_NM"].ToString());			// 入荷会社名
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1ADDTAN_CD, rec["ADDTAN_CD"].ToString());				// 入荷担当者コード
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1NYUKAHANBAI_NM, rec["NYUKAHANBAI_NM"].ToString());	// 入荷担当者名
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SYUKKAKAI_CD, rec["SYUKKAKAISYA_CD"].ToString());		// 出荷会社コード
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SYUKKAKAI_NM, rec["SYUKKAKAI_NM"].ToString());		// 出荷会社名
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SYUKKATAN_CD, rec["SYUKKATAN_CD"].ToString());		// 出荷担当者コード
					f01m1VO.Dictionary.Add(Te130p01Constant.DIC_M1SYUKKAHANBAI_NM, rec["SYUKKAHANBAI_NM"].ToString());	// 出荷担当者名

					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;	// Ｍ１明細色区分(隠し)
					}

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");
		}
		#endregion//フォームボタン

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Ta040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="int">selKbn</param>
		/// <returns></returns>
		private void AddWhere(Te130f01Form f01VO, FindSqlResultTable reader, int selKbn)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 検索条件を設定 -----------
			sRepSql = new StringBuilder();

			// 伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			{


				sRepSql.Append(" AND MDNT0060.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 伝票番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			{
				sRepSql.Append(" AND MDNT0060.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 移動伝票FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Idodenpyo_bango_from))
			{
				sRepSql.Append(" AND MDNT0060.IDODENPYO_BANGO >= :BIND_IDODENPYO_BANGO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_IDODENPYO_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Idodenpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 移動伝票TOを設定
			if (!string.IsNullOrEmpty(f01VO.Idodenpyo_bango_to))
			{
				sRepSql.Append(" AND MDNT0060.IDODENPYO_BANGO <= :BIND_IDODENPYO_BANGO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_IDODENPYO_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Idodenpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 指示番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKA_SIJI_NO >= :BIND_SYUKKA_SIJI_NO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_SIJI_NO_FROM";
				bindVO.Value = BoSystemFormat.formatIdoSijiNo(f01VO.Siji_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 指示番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKA_SIJI_NO <= :BIND_SYUKKA_SIJI_NO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_SIJI_NO_TO";
				bindVO.Value = BoSystemFormat.formatIdoSijiNo(f01VO.Siji_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 入荷会社コードを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuryokaisya_cd))
			{
				sRepSql.Append(" AND MDNT0060.JYURYOKAISYA_CD = :BIND_JYURYOKAISYA_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYOKAISYA_CD";
				bindVO.Value = BoSystemFormat.formatKaisyaCd(f01VO.Jyuryokaisya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 入荷店コードを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
			{
				sRepSql.Append(" AND MDNT0060.JYURYOTEN_CD = :BIND_JYURYOTEN_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYOTEN_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Jyuryoten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 入荷日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuryo_ymd_from))
			{
				sRepSql.Append(" AND MDNT0060.JYURYO_YMD >= :BIND_JYURYO_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYO_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Jyuryo_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 入荷日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuryo_ymd_to))
			{
				sRepSql.Append(" AND MDNT0060.JYURYO_YMD <= :BIND_JYURYO_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYO_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Jyuryo_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 出荷会社を設定
			if (!string.IsNullOrEmpty(f01VO.Syukkakaisya_cd))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
				bindVO.Value = BoSystemFormat.formatKaisyaCd(f01VO.Syukkakaisya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 出荷店を設定
			if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKATEN_CD = :BIND_SYUKKATEN_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKATEN_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Syukkaten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 出荷日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKA_YMD >= :BIND_SYUKKA_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			// 出荷日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
			{
				sRepSql.Append(" AND MDNT0060.SYUKKA_YMD <= :BIND_SYUKKA_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			//自社品番
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				//sRepSql.Append(" /*1*/ ");

				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append("	SELECT 1  ");
				sRepSql.Append("	FROM	MDNT0061 ");
				sRepSql.Append("	WHERE");
				sRepSql.Append("			MDNT0060.JYURYOKAISYA_CD = MDNT0061.JYURYOKAISYA_CD ");
				sRepSql.Append("	AND		MDNT0060.JYURYOTEN_CD    = MDNT0061.JYURYOTEN_CD ");
				sRepSql.Append("	AND		MDNT0060.DENPYO_BANGO    = MDNT0061.DENPYO_BANGO ");
				sRepSql.Append("	AND		MDNT0060.JYURYO_YMD      = MDNT0061.JYURYO_YMD ");
				sRepSql.Append("	AND		MDNT0060.RIREKI_NO       = MDNT0061.RIREKI_NO ");
				sRepSql.Append("	AND		MDNT0060.AKAKURO_KBN     = MDNT0061.AKAKURO_KBN ");
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	sRepSql.Append(" AND MDNT0061.JAN_CD IN ( ");
				//	sRepSql.Append("	SELECT MDMT0130.JAN_CD");
				//	sRepSql.Append("	FROM MDMT0130");
				//	sRepSql.Append("	WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN ");
				//	sRepSql.Append("	)");
				//	sRepSql.Append(")");

				//}
				//else
				//{
					sRepSql.Append(" AND MDNT0061.JISYA_HBN = :BIND_JISYA_HBN");
					sRepSql.Append(")");
				//}

				//sRepSql.Append(" /*1end*/ ");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN";
				bindVO.Value = (string)f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			//スキャンコード
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{

				//sRepSql.Append(" /*2*/ ");
				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append("	SELECT 1 ");
				sRepSql.Append("	FROM	MDNT0061");
				sRepSql.Append("	WHERE ");
				sRepSql.Append("			MDNT0060.JYURYOKAISYA_CD = MDNT0061.JYURYOKAISYA_CD");
				sRepSql.Append("	AND		MDNT0060.JYURYOTEN_CD    = MDNT0061.JYURYOTEN_CD");
				sRepSql.Append("	AND		MDNT0060.DENPYO_BANGO    = MDNT0061.DENPYO_BANGO");
				sRepSql.Append("	AND		MDNT0060.JYURYO_YMD      = MDNT0061.JYURYO_YMD");
				sRepSql.Append("	AND		MDNT0060.RIREKI_NO       = MDNT0061.RIREKI_NO");
				sRepSql.Append("	AND		MDNT0060.AKAKURO_KBN     = MDNT0060.AKAKURO_KBN");
				sRepSql.Append("	AND		MDNT0061.JAN_CD          = :BIND_SCAN_CD");
				sRepSql.Append(" )");

				//sRepSql.Append(" /*2end*/ ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Te130p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			//伝票状態
			// [伝票状態]が「差異あり」の場合、返品予定TBLから検索する。
			if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI3))
			{
				sRepSql.Append(" AND MDNT0060.NYUKAYOTEIGOUKEI_SU <> MDNT0060.NYUKAJISSEKIGOUKEI_SU ");
			}
			// [伝票状態]が「取り消し履歴」の場合
			else if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI5))
			{
				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append(" 	SELECT	1 ");
				sRepSql.Append(" 	FROM	MDNT0060 T1");
				sRepSql.Append(" 	WHERE	T1.SYUKKAKAISYA_CD = MDNT0060.SYUKKAKAISYA_CD");
				sRepSql.Append("	AND		T1.SYUKKATEN_CD    = MDNT0060.SYUKKATEN_CD ");
				sRepSql.Append("	AND		T1.IDODENPYO_BANGO = MDNT0060.IDODENPYO_BANGO ");
				sRepSql.Append("	AND		T1.SYORI_SB = 3 ");
				sRepSql.Append(" ) ");

			}
			//[伝票状態]が「空白」「確定」「差異あり」の場合
			if (selKbn == 2)
			{
				//sRepSql.Append(" /*3*/ ");
				sRepSql.Append("AND (TENPOLC_KBN,SYUKKAKAISYA_CD,SYUKKATEN_CD,IDODENPYO_BANGO,SYUKKA_YMD,RIREKI_NO) ");
				sRepSql.Append("	IN	(");
				sRepSql.Append("	SELECT TENPOLC_KBN ");
				sRepSql.Append("	,SYUKKAKAISYA_CD ");
				sRepSql.Append("	,SYUKKATEN_CD ");
				sRepSql.Append("	,IDODENPYO_BANGO ");
				sRepSql.Append("	,SYUKKA_YMD ");
				sRepSql.Append("	,MAX(RIREKI_NO) ");
				sRepSql.Append(" FROM MDNT0060 ");
				sRepSql.Append(" WHERE AKAKURO_KBN	=	0 ");
				sRepSql.Append(" GROUP BY TENPOLC_KBN ");
				sRepSql.Append(" 	,SYUKKAKAISYA_CD ");
				sRepSql.Append(" 	,SYUKKATEN_CD ");
				sRepSql.Append(" 	,IDODENPYO_BANGO ");
				sRepSql.Append(" 	,SYUKKA_YMD) ");
				//sRepSql.Append(" /*3end*/ ");
			}
			//履歴画面表示区分
			sRepSql.Append(" AND MDNT0060.RIREKI_DISP_KB = 1 ");

			BoSystemSql.AddSql(reader, Te130p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
		}
		#endregion 検索条件設定
	}
}
