using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
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
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01012;
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

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td010f01Form f01VO = (Td010f01Form) facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				
				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;
				
				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」の場合、
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) ||
					f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) ||
					f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					// 伝票番号FROM-TOに空白設定
					f01VO.Denpyo_bango_from = String.Empty;
					f01VO.Denpyo_bango_to = String.Empty;
					// 返品確定日FROM-TOに空白設定
					f01VO.Henpin_kakutei_ymd_from = String.Empty;
					f01VO.Henpin_kakutei_ymd_to = String.Empty;
				}

				#region 単項目チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				// 1-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
														, facadeContext
														, string.Empty
														, null
														, "仕入先"
														, new[] { "Siiresaki_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}

				// 1-3 ブランドコード
				//       ブランドマスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd
														, facadeContext
														, string.Empty
														, null
														, "ブランド"
														, new[] { "Burando_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}

				// 1-4 入力担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
														, new[] { "Nyuryokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 1-5 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Td010p01Constant.DIC_SEARCH_JANCD] = string.Empty;
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
					Hashtable hachuMst = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });
					if (hachuMst != null)
					{
						f01VO.Dictionary[Td010p01Constant.DIC_SEARCH_JANCD] = (string)hachuMst["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック

				// 2-1 指示番号FROM、指示番号TO 
				//       指示番号ＦＲＯＭ と 指示番号ＴＯの桁数が違う場合エラー
				int iErrF = 0;
				if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
				{
					if (f01VO.Siji_bango_from.Length != f01VO.Siji_bango_to.Length)
					{
						ErrMsgCls.AddErrMsg("E194", string.Empty, facadeContext, new[] { "Siji_bango_from", "Siji_bango_to" });
						iErrF = 1;
					}
						
				}


				// 2-2 指示番号FROM、指示番号TO 
				//       指示番号ＦＲＯＭ > 指示番号ＴＯの場合エラー
				if (iErrF == 0)
				{
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
				}


				// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」以外の場合、
				if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) &&
					!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) &&
					!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					// 2-3 伝票番号FROM、伝票番号TO
					//       伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
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
				}

				// 2-4 部門コードFROM、部門コードTO
				//       部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Bumon_cd_from,
									f01VO.Bumon_cd_to,
									facadeContext,
									"部門コード",
									new[] { "Bumon_cd_from", "Bumon_cd_to" }
									);
				}


				
				// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」以外の場合、
				if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) &&
					!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) &&
					!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					// 2-5 返品確定日FROM、返品確定日TO
					//       返品確定日ＦＲＯＭ > 返品確定日ＴＯの場合エラー
					if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
					{
						V03001Check.DateFromToChk(
										f01VO.Henpin_kakutei_ymd_from,
										f01VO.Henpin_kakutei_ymd_to,
										facadeContext,
										"返品確定日",
										new[] { "Henpin_kakutei_ymd_from", "Henpin_kakutei_ymd_to" }
										);
					}
				}


				// 2-6 登録日FROM、登録日TO
				//       登録日ＦＲＯＭ > 登録日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Add_ymd_from) && !string.IsNullOrEmpty(f01VO.Add_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Add_ymd_from,
									f01VO.Add_ymd_to,
									facadeContext,
									"登録日",
									new[] { "Add_ymd_from", "Add_ymd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Td010p01Constant.SQL_ID_01, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、返品予定テーブルから検索する。
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sRepSql.Append("MDRT0010");	// 返品予定テーブル
				}
				// [選択モードNO]が「確定後取消」「照会」の場合、返品確定テーブルから検索する。
				else
				{
					sRepSql.Append("MDRT0020");	// 返品確定テーブル
				}

				BoSystemSql.AddSql(rtChk, Td010p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);
				#endregion

				// 検索条件設定
				AddWhere(f01VO, rtChk);

				//検索結果を取得します
				rtChk.CreateDbCommand();
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

				//// 検索件数の設定
				//f01VO.Searchcnt = dCnt.ToString();

				#endregion

				#region 検索処理

				
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、返品予定テーブルから検索する。
				string sSqlId = "";
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sSqlId = Td010p01Constant.SQL_ID_02;
				}
				else
				{
					sSqlId = Td010p01Constant.SQL_ID_03;
				}
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Td010f01M1Form f01m1VO = new Td010f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
					f01m1VO.M1siji_bango = BoSystemString.ZeroToEmpty(rec["SIJI_BANGO"].ToString());					// Ｍ１指示番号
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();													// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
					f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
					f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先略式名称
					// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」の場合、
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) ||
						f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) ||
						f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
					{
						f01m1VO.M1henpin_kakutei_ymd = string.Empty;													// Ｍ１返品確定日
					}
					else
					{
						f01m1VO.M1henpin_kakutei_ymd = rec["HENPIN_YMD"].ToString();									// Ｍ１返品確定日
					}

					f01m1VO.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO] = string.Empty;
					if (!"0".Equals(rec["DENPYO_BANGO"].ToString()))
					{
						f01m1VO.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO] = BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString());
					}																									// Ｍ１伝票番号リンク

					f01m1VO.M1add_ymd = rec["ADD_YMD"].ToString();														// Ｍ１登録日
					f01m1VO.Dictionary[Td010p01Constant.DIC_M1KANRI_NO] = string.Empty;
					if (!"0".Equals(rec["KANRI_NO"].ToString()))
					{
						f01m1VO.Dictionary[Td010p01Constant.DIC_M1KANRI_NO] = BoSystemFormat.formatDenpyoNo(rec["KANRI_NO"].ToString());
					}																									// Ｍ１管理Noリンク
					f01m1VO.M1suryo = rec["GOKEI_SU"].ToString();														// Ｍ１数量
					f01m1VO.M1genkakin = rec["GOUKEI_KIN"].ToString();													// Ｍ１原価金額
					f01m1VO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();											// Ｍ１入力担当者名称
					f01m1VO.M1henpin_riyu_nm = rec["HENPIN_RIYU_NM"].ToString();										// Ｍ１返品理由名称
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}
					// Dictionary
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());				// 部門名
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());				// 処理日付
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());				// 処理時間
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				// 店舗コード
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());			// ブランドコード
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1SUBSIIRESAKI_CD, rec["SUBSIIRESAKI_CD"].ToString());	// サブ仕入先
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1HENPIN_RIYU, rec["HENPIN_RIYU"].ToString());			// 返品理由
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1TANTOSYA_CD, rec["TANTOSYA_CD"].ToString());			// 担当者コード
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// 更新日付
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// 更新時間
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1UPD_TANCD, rec["UPD_TANCD"].ToString());				// 更新担当者コード
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1HHTSERIAL_NO, rec["HHTSERIAL_NO"].ToString());		// HHTシリアル番号
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1HHTSEQUENCE_NO, rec["HHTSEQUENCE_NO"].ToString());	// HHTシーケンスNo
					f01m1VO.Dictionary.Add(Td010p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());		// 送信済フラグ

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				
				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
				#endregion

				#region ダミー行追加
				//Td010f01M1Form f01m1VO2 = new Td010f01M1Form();
				//f01m1VO2.M1rowno = "999";											// Ｍ１行NO
				//f01m1VO2.M1siji_bango = "1234567890";								// Ｍ１指示番号
				//f01m1VO2.M1bumon_cd = "999";										// Ｍ１部門コード
				//f01m1VO2.M1bumonkana_nm = "WWWWWWWWWWWW";							// Ｍ１部門カナ名
				//f01m1VO2.M1burando_nm = "WWWWWWWWWWWW";								// Ｍ１ブランド名
				//f01m1VO2.M1siiresaki_cd = "9999";									// Ｍ１仕入先コード
				//f01m1VO2.M1siiresaki_ryaku_nm = "ＮＮＮＮＮＮＮＮＮＮ";				// Ｍ１仕入先略式名称
				//f01m1VO2.M1henpin_kakutei_ymd = "9999/99/99";						// Ｍ１返品確定日
				//f01m1VO2.M1denpyo_bango = "999999";									// Ｍ１伝票番号
				//f01m1VO2.M1add_ymd = "9999/99/99";									// Ｍ１登録日
				//f01m1VO2.Dictionary.Add(Td010p01Constant.DIC_M1KANRI_NO, "999999");	// Ｍ１管理Noリンク
				//f01m1VO2.M1suryo = "999,999,999";									// Ｍ１数量
				//f01m1VO2.M1genkakin = "999,999,999";								// Ｍ１原価金額
				//f01m1VO2.M1nyuryokutan_nm = "ＮＮＮＮＮＮＮＮＮＮ";					// Ｍ１入力担当者名称
				//f01m1VO2.M1henpin_riyu_nm = "本部指示";								// Ｍ１返品理由名称

				////リストオブジェクトにM1Formを追加します。
				//m1List.Add(f01m1VO2, true);

				//// 選択モードNO設定
				//f01VO.Stkmodeno = f01VO.Modeno;
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Td010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void AddWhere(Td010f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();


			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);


			// 指示番号FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from))
			{
				sRepSql.Append(" AND T1.SIJI_BANGO >= :BIND_SIJI_BANGO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_FROM";
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 指示番号TOを設定

			if (!string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				sRepSql.Append(" AND T1.SIJI_BANGO <= :BIND_SIJI_BANGO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_TO";
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」以外の場合、
			if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
			{
				// 伝票番号FROMを設定

				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
				{
					sRepSql.Append(" AND T1.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO_FROM";
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 伝票番号TOを設定

				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					sRepSql.Append(" AND T1.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO_TO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 仕入先コードを設定

			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 部門FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
			{
				sRepSql.Append(" AND T1.BUMON_CD >= :BIND_BUMON_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_FROM";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門TOを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND T1.BUMON_CD <= :BIND_BUMON_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_TO";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// ブランドコードを設定

			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql.Append(" AND T1.BURANDO_CD = :BIND_BURANDO_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」以外の場合、
			if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
			{
				// 返品確定日FROMを設定

				if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from))
				{
					sRepSql.Append(" AND T1.HENPIN_YMD >= :BIND_HENPIN_YMD_FROM");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HENPIN_YMD_FROM";
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 返品確定日TOを設定

				if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
				{
					sRepSql.Append(" AND T1.HENPIN_YMD <= :BIND_HENPIN_YMD_TO");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HENPIN_YMD_TO";
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 入力担当者コードを設定

			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、更新担当者から検索する。
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sRepSql.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD");
				}
				else
				// [選択モードNO]が「確定後取消」「照会」の場合、HHT登録担当者から検索する。
				{
					sRepSql.Append(" AND T1.HHTADDTAN_CD = :BIND_UPD_TANCD");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、更新担当者から検索する。
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sRepSql.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM");
				}
				else
				// [選択モードNO]が「確定後取消」「照会」の場合、HHT登録担当者から検索する。
				{
					sRepSql.Append(" AND T1.HHTADD_YMD >= :BIND_UPD_YMD_FROM");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日TOを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、更新担当者から検索する。
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sRepSql.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO");
				}
				else
				{
					sRepSql.Append(" AND T1.HHTADD_YMD <= :BIND_UPD_YMD_TO");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 返品理由を設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_riyu) && !f01VO.Henpin_riyu.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND T1.HENPIN_RIYU = :BIND_HENPIN_RIYU");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_RIYU";
				bindVO.Value = f01VO.Henpin_riyu;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコードを設定
			string jancd = (string)f01VO.Dictionary[Td010p01Constant.DIC_SEARCH_JANCD];
			if (!string.IsNullOrEmpty(jancd))
			{
				sRepSql.Append(" AND EXISTS(");
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、返品予定テーブルから検索する。
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0011 T2");	// 返品予定テーブル
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T2.KANRI_NO  = T1.KANRI_NO");
					sRepSql.Append(" 		AND		T2.SYORI_YMD = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T2.TENPO_CD  = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T2.JAN_CD    = :BIND_JAN_CD");
					sRepSql.Append(" )");
				}
				// [選択モードNO]が「確定後取消」「照会」の場合、返品確定テーブルから検索する。
				else
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0021 T2");	// 返品確定テーブル
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND		T2.SYORI_YMD    = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T2.TENPO_CD     = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T2.JAN_CD       = :BIND_JAN_CD");
					sRepSql.Append(" )");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD";
				//bindVO.Value = f01VO.Scan_cd;
				bindVO.Value = jancd;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}


			// 予定テーブル参照時、確定フラグの条件を設定
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
				|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
				|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
			{
				sRepSql.Append(" AND T1.KAKUTEI_FLG = :BIND_KAKUTEI_FLG");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAKUTEI_FLG";
				bindVO.Value = "0";
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// :[選択モードNO]が「確定後取消」の場合、「送信済みフラグ＝0」を条件とする。
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL))
			{
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = 0");
			}
			
			// [選択モードNo]が「返品確定」「確定前修正」「確定前取消」以外の場合、
			if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD) &&
				!f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
			{
				sRepSql.Append(" AND T1.KAKUTEI_SB IN (0, 1)");
			}

			BoSystemSql.AddSql(reader, Td010p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion

		}

		#endregion
	}
}
