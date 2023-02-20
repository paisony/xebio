using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01021;
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

namespace com.xebio.bo.Tf021p01.Facade
{
  /// <summary>
  /// Tf021f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf021f01Facade : StandardBaseFacade
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
				Tf021f01Form f01VO = (Tf021f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEIMAEUPD)
					|| f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEIMAEDEL))
				{
					// 申請、申請前修正、申請前取消モードの場合
					// 承認状態、申請日、確定日、伝票番号、申請者の条件を初期化
					f01VO.Syonin_flg = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
					f01VO.Apply_ymd_from = String.Empty;
					f01VO.Apply_ymd_to = String.Empty;
					f01VO.Kakutei_ymd_from = String.Empty;
					f01VO.Kakutei_ymd_to = String.Empty;
					f01VO.Denpyo_bango_from = String.Empty;
					f01VO.Denpyo_bango_to = String.Empty;
					f01VO.Sinseitan_cd = String.Empty;
					f01VO.Sinseitan_nm = String.Empty;
				}
				else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEIGODEL))
				{
					// 申請後取消モードの場合、
					// 承認状態、確定日の条件を初期化
					f01VO.Syonin_flg = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
					f01VO.Kakutei_ymd_from = String.Empty;
					f01VO.Kakutei_ymd_to = String.Empty;
				}

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

				// 1-2 申請担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				f01VO.Sinseitan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Sinseitan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Sinseitan_cd
														, facadeContext
														, string.Empty
														, null
														, "申請者"
														, new[] { "Sinseitan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Sinseitan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 科目コードFrom(名称取得、チェックは行わない)
				//       科目マスタを検索し、名前を設定する。
				f01VO.Kamoku_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Kamoku_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01021Check.CheckKamoku(f01VO.Kamoku_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);

					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Kamoku_nm_from = (string)resultHash["KAMOKU_NM"];
					}
				}

				// 科目コードTo(名称取得、チェックは行わない)
				//       科目マスタを検索し、名前を設定する。
				f01VO.Kamoku_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Kamoku_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01021Check.CheckKamoku(f01VO.Kamoku_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);

					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Kamoku_nm_to = (string)resultHash["KAMOKU_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連項目チェック

				// 2-1 登録日FROM、登録日TO
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

				// 2-2 申請日FROM、申請日TO
				//       申請日ＦＲＯＭ > 申請日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Apply_ymd_from) && !string.IsNullOrEmpty(f01VO.Apply_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Apply_ymd_from,
									f01VO.Apply_ymd_to,
									facadeContext,
									"申請日",
									new[] { "Apply_ymd_from", "Apply_ymd_to" }
									);
				}

				// 2-3 確定日FROM、確定日TO
				//       確定日ＦＲＯＭ > 確定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Kakutei_ymd_from,
									f01VO.Kakutei_ymd_to,
									facadeContext,
									"確定日",
									new[] { "Kakutei_ymd_from", "Kakutei_ymd_to" }
									);
				}

				// 2-4 科目コードFROM、科目コードTO
				//       科目コードＦＲＯＭ > 科目コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Kamoku_cd_from) && !string.IsNullOrEmpty(f01VO.Kamoku_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Kamoku_cd_from,
									f01VO.Kamoku_cd_to,
									facadeContext,
									"科目コード",
									new[] { "Kamoku_cd_from", "Kamoku_cd_to" }
									);
				}

				// 2-5 伝票番号FROM、伝票番号TO
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

				// 2-6 管理NoFROM、管理NoTO
				//       管理NoＦＲＯＭ > 管理NoＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Kanri_no_from) && !string.IsNullOrEmpty(f01VO.Kanri_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Kanri_no_from,
									f01VO.Kanri_no_to,
									facadeContext,
									"管理No",
									new[] { "Kanri_no_from", "Kanri_no_to" }
									);
				}

				// 2-7 業務稟議No、業務稟議No
				//       業務稟議No > 業務稟議Noの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Gyomuringi_no_from) && !string.IsNullOrEmpty(f01VO.Gyomuringi_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Gyomuringi_no_from,
									f01VO.Gyomuringi_no_to,
									facadeContext,
									"業務稟議No",
									new[] { "Gyomuringi_no_from", "Gyomuringi_no_to" }
									);
				}

				// 2-8 受理番号FROM、受理番号TO
				//       受理番号ＦＲＯＭ > 受理番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Jyuri_no_from) && !string.IsNullOrEmpty(f01VO.Jyuri_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Jyuri_no_from,
									f01VO.Jyuri_no_to,
									facadeContext,
									"受理番号",
									new[] { "Jyuri_no_from", "Jyuri_no_to" }
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

				// テーブルIDを設定 -----------

				ArrayList bindList = new ArrayList();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				String sSqlId_chk = null;
				String sSqlId_src = null;
				String sTblId1 = null;
				String sTblId2 = null;
				String sTblId3 = null;

				// [選択モードNo]が「申請」、「申請前修正」、「申請前取消」の場合
				// 経費振替予定テーブルから検索する。
				if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_SINSEIMAEDEL.Equals(f01VO.Modeno))
				{
					sSqlId_chk = Tf021p01Constant.SQL_ID_01;
					sSqlId_src = Tf021p01Constant.SQL_ID_03;
					sTblId1 = Tf021p01Constant.TABLE_ID_MDAT0100;	// 経費振替予定テーブル(H)
				}
				// [選択モードNo]が「申請後取消」、または[選択モードNo]が「照会」、かつ[承認状態]が"未決裁"の場合
				// 経費振替申請テーブルから検索する。
				else if (BoSystemConstant.MODE_SINSEIGODEL.Equals(f01VO.Modeno)
						|| (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& ConditionSyonin_jotai.VALUE_SYONIN_JOTAI3.Equals(f01VO.Syonin_flg))
					)
				{
					sSqlId_chk = Tf021p01Constant.SQL_ID_01;
					sSqlId_src = Tf021p01Constant.SQL_ID_04;
					sTblId1 = Tf021p01Constant.TABLE_ID_MDAT0020;	// 経費振替申請テーブル(H)
				}
				// [選択モードNo]が「照会」、かつ[承認状態]が"承認"、"却下"の場合
				// 経費振替確定テーブルから検索する。
				else if (   BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& (   ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1.Equals(f01VO.Syonin_flg)
								|| ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2.Equals(f01VO.Syonin_flg)))
				{
					sSqlId_chk = Tf021p01Constant.SQL_ID_01;
					sSqlId_src = Tf021p01Constant.SQL_ID_05;
					sTblId1 = Tf021p01Constant.TABLE_ID_MDAT0030;	// 経費振替確定テーブル(H)
				}
				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				// 経費振替申請テーブル、経費振替確定テーブルから検索する。
				else
				{
					sSqlId_chk = Tf021p01Constant.SQL_ID_02;
					sSqlId_src = Tf021p01Constant.SQL_ID_06;
					sTblId1 = Tf021p01Constant.TABLE_ID_MDAT0100;	// 経費振替予定テーブル(H)
					sTblId2 = Tf021p01Constant.TABLE_ID_MDAT0020;	// 経費振替申請テーブル(H)
					sTblId3 = Tf021p01Constant.TABLE_ID_MDAT0030;	// 経費振替確定テーブル(H)
				}

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(sSqlId_chk, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				BoSystemSql.AddSql(rtChk, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					BoSystemSql.AddSql(rtChk, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
					BoSystemSql.AddSql(rtChk, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID3, sTblId3 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtChk, sTblId1, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					this.AddWhere(f01VO, rtChk, sTblId2, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE2);
					this.AddWhere(f01VO, rtChk, sTblId3, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE3);
				}

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

				#endregion

				#region 検索処理

				// 経費振替テーブルから検索する。

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId_src, facadeContext.DBContext);

				#region テーブルID設定

				// テーブルIDを設定 -----------
				BoSystemSql.AddSql(rtSeach, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					BoSystemSql.AddSql(rtSeach, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
					BoSystemSql.AddSql(rtSeach, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID3, sTblId3 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach, sTblId1, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					this.AddWhere(f01VO, rtSeach, sTblId2, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE2);
					this.AddWhere(f01VO, rtSeach, sTblId3, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE3);
				}

				// 検索順序設定
				this.addOrderBy(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tf021f01M1Form f01m1VO = new Tf021f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１ＮＯ
					f01m1VO.M1add_ymd = string.Empty;
					if (!"0".Equals(rec["ADD_YMD"].ToString()))
					{
						f01m1VO.M1add_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());				// Ｍ１登録日
					}
					f01m1VO.M1apply_ymd = string.Empty;
					if (!"0".Equals(rec["APPLY_YMD"].ToString()))
					{
						f01m1VO.M1apply_ymd = BoSystemFormat.formatDate_yyMMdd(rec["APPLY_YMD"].ToString());			// Ｍ１申請日
					}
					f01m1VO.M1kakutei_ymd = string.Empty;
					if (!"0".Equals(rec["KAKUTEI_YMD"].ToString()))
					{
						f01m1VO.M1kakutei_ymd = BoSystemFormat.formatDate_yyMMdd(rec["KAKUTEI_YMD"].ToString());
					}																									// Ｍ１確定日

					f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO] = string.Empty;
					if (!"0".Equals(rec["DENPYO_BANGO"].ToString()))
					{
						f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO] = BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString());
					}																									// Ｍ１伝票番号リンク

					f01m1VO.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO] = string.Empty;
					if (!"0".Equals(rec["KANRI_NO"].ToString()))
					{
						f01m1VO.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO] = rec["KANRI_NO"].ToString().PadLeft(6, '0');
					}																									// Ｍ１管理Noリンク
					f01m1VO.M1kamoku_cd = rec["KAMOKU_CD"].ToString();													// Ｍ１科目コード
					f01m1VO.M1kamoku_nm = rec["KAMOKU_NM"].ToString();													// Ｍ１科目名
					f01m1VO.M1itemsu = rec["SUURYO"].ToString();														// Ｍ１数量
					f01m1VO.M1genkakin = rec["MONEY"].ToString();														// Ｍ１原価金額
					f01m1VO.M1baika_tnk = rec["BAIKAKINGAKU"].ToString();												// Ｍ１売価金額
					f01m1VO.M1sinseitan_nm = rec["SINSEITAN_NM"].ToString();											// Ｍ１申請担当者名称

					f01m1VO.M1gyomuringi_no = string.Empty;
					if (!"0".Equals(rec["GYOMURINGI_NO"].ToString()))
					{
						f01m1VO.M1gyomuringi_no = rec["GYOMURINGI_NO"].ToString();
					}																									// Ｍ１業務稟議No

					f01m1VO.M1jyuri_no = rec["JYURI_NO"].ToString();													// Ｍ１受理番号
					f01m1VO.M1syonin_flg_nm = rec["SYONINSTATUS"].ToString();											// Ｍ１承認状態名称

					f01m1VO.M1sinseiriyu = rec["MEISYO_NM"].ToString() + rec["SINSEIRIYU"].ToString();
					if (System.Text.Encoding.GetEncoding(932).GetByteCount(f01m1VO.M1sinseiriyu) > 30)
					{
						f01m1VO.M1sinseiriyu = BoSystemString.LeftB(f01m1VO.M1sinseiriyu, 30);
					}																									// Ｍ１申請理由

					f01m1VO.M1kyakkariyu = rec["KYAKKARIYU"].ToString();												// Ｍ１却下理由

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)

					// 送信済み行は色変更
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}

					// Dictionary
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1TBLFLG, rec["TBLFLG"].ToString());					// Ｍ１テーブル区分
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1SYORI_YMD,rec["SYORI_YMD"].ToString());				// Ｍ１処理日付
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());				// Ｍ１処理時間
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1SINSEIRIYU_KB, rec["SINSEIRIYU_KB"].ToString());		// Ｍ１申請理由区分
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1SINSEIRIYU, rec["SINSEIRIYU"].ToString());			// Ｍ１申請理由
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// Ｍ１更新日
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// Ｍ１更新時間
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1SYONINSTATUS, rec["SYONINSTATUS"].ToString());		// Ｍ１承認状態名称
					f01m1VO.Dictionary.Add(Tf021p01Constant.DIC_M1MAX_BAIKA_TNK, rec["BAIKA_TNK"].ToString());			// Ｍ１売価単価

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tf010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="String">table_id</param>
		/// <param name="String">add_where_id</param>
		/// <returns></returns>
		private void AddWhere(Tf021f01Form f01VO, FindSqlResultTable reader, String table_id, String add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 店舗コードを設定
			if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
			{
				sRepSql.Append("	AND T1.TENPO_CD = :BIND_TENPO_CD_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 科目コードFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Kamoku_cd_from))
			{
				sRepSql.Append("	AND T1.KAMOKU_CD >= :BIND_KMK_FROM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KMK_FROM_" + add_where_id;
				bindVO.Value = f01VO.Kamoku_cd_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 科目コードTOを設定
			if (!string.IsNullOrEmpty(f01VO.Kamoku_cd_to))
			{
				sRepSql.Append("	AND T1.KAMOKU_CD <= :BIND_KMK_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KMK_TO_" + add_where_id;
				bindVO.Value = f01VO.Kamoku_cd_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 経費振替申請テーブル、もしくは経費振替確定テーブルの場合
			if (Tf021p01Constant.TABLE_ID_MDAT0020.Equals(table_id)
				|| Tf021p01Constant.TABLE_ID_MDAT0030.Equals(table_id))
			{
				// 申請担当者コードを設定
				if (!string.IsNullOrEmpty(f01VO.Sinseitan_cd))
				{
					sRepSql.Append("	AND T1.SINSEITAN_CD = :BIND_SINTAN_CD_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SINTAN_CD_" + add_where_id;
					bindVO.Value = f01VO.Sinseitan_cd;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 受理番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuri_no_from))
			{
				sRepSql.Append("	AND TRIM(T1.JYURI_NO) >= :BIND_JYURI_FROM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURI_FROM_" + add_where_id;
				bindVO.Value = f01VO.Jyuri_no_from;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 受理番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuri_no_to))
			{
				sRepSql.Append("	AND TRIM(T1.JYURI_NO) <= :BIND_JYURI_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURI_TO_" + add_where_id;
				bindVO.Value = f01VO.Jyuri_no_to;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				sRepSql.Append("	AND T1.ADD_YMD >= :BIND_ADD_FRM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_FRM_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 登録日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				sRepSql.Append("	AND T1.ADD_YMD <= :BIND_ADD_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_TO_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 業務稟議NoFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Gyomuringi_no_from))
			{
				sRepSql.Append("	AND T1.GYOMURINGI_NO >= :BIND_RINGI_FRM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_RINGI_FRM_" + add_where_id;
				bindVO.Value = f01VO.Gyomuringi_no_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 業務稟議NoTOを設定
			if (!string.IsNullOrEmpty(f01VO.Gyomuringi_no_to))
			{
				sRepSql.Append("	AND T1.GYOMURINGI_NO <= :BIND_RINGI_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_RINGI_TO_" + add_where_id;
				bindVO.Value = f01VO.Gyomuringi_no_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 経費振替予定テーブル、もしくは経費振替申請テーブルの場合
			if (   Tf021p01Constant.TABLE_ID_MDAT0100.Equals(table_id)
				|| Tf021p01Constant.TABLE_ID_MDAT0020.Equals(table_id))
			{
				// 管理NoFROMを設定
				if (!string.IsNullOrEmpty(f01VO.Kanri_no_from))
				{
					sRepSql.Append("	AND T1.KANRI_NO >= :BIND_KANRI_FRM_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KANRI_FRM_" + add_where_id;
					bindVO.Value = f01VO.Kanri_no_from;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 管理NoTOを設定
				if (!string.IsNullOrEmpty(f01VO.Kanri_no_to))
				{
					sRepSql.Append("	AND T1.KANRI_NO <= :BIND_KANRI_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KANRI_TO_" + add_where_id;
					bindVO.Value = f01VO.Kanri_no_to;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

			}

			// 経費振替申請テーブル、もしくは経費振替確定テーブルの場合
			if (   Tf021p01Constant.TABLE_ID_MDAT0020.Equals(table_id)
				|| Tf021p01Constant.TABLE_ID_MDAT0030.Equals(table_id))
			{
				// 伝票番号FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
				{
					sRepSql.Append("	AND T1.DENPYO_BANGO >= :BIND_DEN_FRM_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DEN_FRM_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 伝票番号TOを設定
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					sRepSql.Append("	AND T1.DENPYO_BANGO <= :BIND_DEN_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DEN_TO_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 申請日FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Apply_ymd_from))
				{
					sRepSql.Append("	AND T1.APPLY_YMD >= :BIND_APPLY_FRM_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_APPLY_FRM_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Apply_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}

				// 申請日TOを設定
				if (!string.IsNullOrEmpty(f01VO.Apply_ymd_to))
				{
					sRepSql.Append("	AND T1.APPLY_YMD <= :BIND_APPLY_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_APPLY_TO_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Apply_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

			}

			// 経費振替予定テーブルの場合
			if (Tf021p01Constant.TABLE_ID_MDAT0100.Equals(table_id))
			{
				sRepSql.Append("	AND T1.SINSEI_FLG <> 1 ");

			}

			// 経費振替申請テーブルの場合
			if (Tf021p01Constant.TABLE_ID_MDAT0020.Equals(table_id))
			{
				sRepSql.Append("	AND T1.KESSAI_FLG <> 1 ");

				// [選択モードNo]が「申請後取消」の場合
				if (BoSystemConstant.MODE_SINSEIGODEL.Equals(f01VO.Modeno))
				{
					sRepSql.Append("	AND T1.TONANHINKANRI_NO = 0 ");
					sRepSql.Append("	AND T1.TONANHINSYORI_YMD = 0 ");
					sRepSql.Append("	AND T1.TONANHINTENPO_CD IS NULL ");
					sRepSql.Append("	AND T1.JYURI_NO IS NULL ");

				}
			}

			// 経費振替確定テーブルの場合
			if (Tf021p01Constant.TABLE_ID_MDAT0030.Equals(table_id))
			{
				// 確定日FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Kakutei_ymd_from))
				{
					sRepSql.Append("	AND T1.UPD_YMD >= :BIND_UPD_FRM_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_UPD_FRM_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Kakutei_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 確定日TOを設定
				if (!string.IsNullOrEmpty(f01VO.Kakutei_ymd_to))
				{
					sRepSql.Append("	AND T1.UPD_YMD <= :BIND_UPD_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_UPD_TO_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Kakutei_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 承認状態
				if (ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1.Equals(f01VO.Syonin_flg))
				{
					sRepSql.Append("	AND T1.SYONIN_FLG = 1 ");
				}
				else if (ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2.Equals(f01VO.Syonin_flg))
				{
					sRepSql.Append("	AND T1.SYONIN_FLG = 2 ");
				}

			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);

			#endregion

		}

		#endregion

		#region 検索順序設定
		/// <summary>
		/// AddWhere 検索順序設定
		/// </summary>
		/// <param name="f01VO">Tf010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void addOrderBy(Tf021f01Form f01VO, FindSqlResultTable reader)
		{

			StringBuilder sRepSql = new StringBuilder();

			sRepSql.Append("				ORDER BY ");
			sRepSql.Append("					  APPLY_YMD ");
			sRepSql.Append("					, UPD_YMD ");
			sRepSql.Append("					, DENPYO_BANGO ");
			sRepSql.Append("					, KANRI_NO ");

			BoSystemSql.AddSql(reader, Tf021p01Constant.SQL_ID_01_REP_ADD_ORDER1, sRepSql.ToString());

		}
		#endregion


	}
}
