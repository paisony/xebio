using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Formvo;
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

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f01Facade : StandardBaseFacade
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
				Tf010f01Form f01VO = (Tf010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				// 確定モードの場合、
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEI))
				{
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

				// 申請店舗コードFrom
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Shinsei_tenpo_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Shinsei_tenpo_cd_from
														, facadeContext
														, string.Empty
														, null
														, "申請店舗ＦＲＯＭ"
														, new[] { "Shinsei_tenpo_cd_from" }
														, null
														, null
														, null
														, 0
														, 0);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Shinsei_tenpo_nm_from = (string)resultHash["TENPO_NM"];
					}
				}

				// 申請店舗コードTo
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Shinsei_tenpo_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Shinsei_tenpo_cd_to
														, facadeContext
														, string.Empty
														, null
														, "申請店舗ＴＯ"
														, new[] { "Shinsei_tenpo_cd_to" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Shinsei_tenpo_nm_to = (string)resultHash["TENPO_NM"];
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

				// 2-1 申請日FROM、申請日TO
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

				// 2-2 確定日FROM、確定日TO
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

				// 2-3 申請店舗コードFROM、申請店舗コードTO
				//       申請店舗コードＦＲＯＭ > 申請店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Shinsei_tenpo_cd_from,
									f01VO.Shinsei_tenpo_cd_to,
									facadeContext,
									"申請店舗コード",
									new[] { "Shinsei_tenpo_cd_from", "Shinsei_tenpo_cd_to" }
									);
				}

				// 2-4 業務稟議No、業務稟議No
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

				// 2-6 受理番号FROM、受理番号TO
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

				// 2-7 科目コードFROM、科目コードTO
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
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				String sSqlId_chk = null;
				String sSqlId_src = null;
				String sTblId1 = null;
				String sTblId2 = null;

				// [選択モードNO]が「確定」の場合、または[選択モードNO]が「照会」かつ[承認状態]が「未決裁」の場合
				// 経費振替申請テーブルから検索する。
				if (    BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno)
					|| (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
						&& ConditionSyonin_jotai.VALUE_SYONIN_JOTAI3.Equals(f01VO.Syonin_flg))
					)
				{
					sSqlId_chk = Tf010p01Constant.SQL_ID_01;
					sSqlId_src = Tf010p01Constant.SQL_ID_03;
					sTblId1 = Tf010p01Constant.TABLE_ID_MDAT0020;	// 経費振替申請テーブル(H)
				}
				// [選択モードNO]が「修正」「取消」の場合、または[選択モードNO]が「照会」かつ[承認状態]が「承認」「却下」の場合
				// 経費振替確定テーブルから検索する。
				else if (   BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
						||  BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
						|| (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& (   ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1.Equals(f01VO.Syonin_flg)
								|| ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2.Equals(f01VO.Syonin_flg))
						)
					)
				{
					sSqlId_chk = Tf010p01Constant.SQL_ID_01;
					sSqlId_src = Tf010p01Constant.SQL_ID_04;
					sTblId1 = Tf010p01Constant.TABLE_ID_MDAT0030;	// 経費振替確定テーブル(H)
				}
				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				// 経費振替申請テーブル、経費振替確定テーブルから検索する。
				else
				{
					sSqlId_chk = Tf010p01Constant.SQL_ID_02;
					sSqlId_src = Tf010p01Constant.SQL_ID_05;
					sTblId1 = Tf010p01Constant.TABLE_ID_MDAT0020;	// 経費振替申請テーブル(H)
					sTblId2 = Tf010p01Constant.TABLE_ID_MDAT0030;	// 経費振替確定テーブル(H)
				}

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(sSqlId_chk, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				BoSystemSql.AddSql(rtChk, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					BoSystemSql.AddSql(rtChk, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtChk, sTblId1, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					this.AddWhere(f01VO, rtChk, sTblId2, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE2);
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
				BoSystemSql.AddSql(rtSeach, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					BoSystemSql.AddSql(rtSeach, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach, sTblId1, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// [選択モードNo]が「照会」、かつ[承認状態]が空白の場合
				if (!string.IsNullOrEmpty(sTblId2))
				{
					this.AddWhere(f01VO, rtSeach, sTblId2, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE2);
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
					Tf010f01M1Form f01m1VO = new Tf010f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１ＮＯ
					f01m1VO.M1apply_ymd = BoSystemFormat.formatDate(rec["APPLY_YMD"].ToString());						// Ｍ１申請日
					f01m1VO.M1shinsei_tenpo_cd = BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString());				// Ｍ１申請店舗コード
					f01m1VO.M1shinsei_tenpo_nm = rec["TENPO_NM"].ToString();											// Ｍ１申請店舗名
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
																														// Ｍ１伝票番号リンク
					f01m1VO.M1gyomuringi_no = string.Empty;
					if (!"0".Equals(rec["GYOMURINGI_NO"].ToString()))
					{
						f01m1VO.M1gyomuringi_no = rec["GYOMURINGI_NO"].ToString();										// Ｍ１業務稟議No
					}
					f01m1VO.M1jyuri_no = rec["JYURI_NO"].ToString();													// Ｍ１受理番号
					f01m1VO.M1suryo = rec["SUURYO"].ToString();															// Ｍ１数量
					f01m1VO.M1genka_kin = rec["MONEY"].ToString();														// Ｍ１原価金額
					f01m1VO.M1sinseitan_nm = rec["HANBAIIN_NM"].ToString();												// Ｍ１申請担当者名称

					f01m1VO.M1sinseiriyu = rec["MEISYO_NM"].ToString() + rec["SINSEIRIYU"].ToString();
					if (System.Text.Encoding.GetEncoding(932).GetByteCount(f01m1VO.M1sinseiriyu) > 30)
					{
						f01m1VO.M1sinseiriyu = BoSystemString.LeftB(f01m1VO.M1sinseiriyu, 30);
					}																									// Ｍ１申請理由

					f01m1VO.M1kyakkariyu = rec["KYAKKARIYU"].ToString();												// Ｍ１却下理由

					switch (rec["SYONINSTATUSKBN"].ToString())
					{
						// 「承認」の場合
						case ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1:
							f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;										// Ｍ１承認フラグ
							f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;										// Ｍ１却下フラグ
							break;

						// 「却下」の場合
						case ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2:
							f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;										// Ｍ１承認フラグ
							f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;										// Ｍ１却下フラグ
							break;
					}

					f01m1VO.M1kakutei_ymd = string.Empty;
					if (!"0".Equals(rec["KAKUTEI_YMD"].ToString()))
					{
						f01m1VO.M1kakutei_ymd = BoSystemFormat.formatDate(rec["KAKUTEI_YMD"].ToString());
					}																									// Ｍ１確定日

					f01m1VO.M1kamoku_cd = rec["KAMOKU_CD"].ToString();													// Ｍ１科目コード
					f01m1VO.M1kamoku_nm = rec["KAMOKU_NM"].ToString();													// Ｍ１科目名
					f01m1VO.M1baika_kin = rec["BAIKAMONEY"].ToString();													// Ｍ１売価金額
					f01m1VO.M1kakuteitan_nm = rec["KAKUTEITANTONM"].ToString();											// Ｍ１確定担当者名称

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}

					// Dictionary
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1TBLFLG, rec["TBLFLG"].ToString());													// Ｍ１テーブル区分
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SINSEITAN_CD, BoSystemFormat.formatTantoCd(rec["SINSEITAN_CD"].ToString()));			// Ｍ１申請担当者コード
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1KAKUTEITANTOCD, BoSystemFormat.formatTantoCd(rec["KAKUTEITANTOCD"].ToString()));		// Ｍ１確定担当者コード
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SYORI_YMD, BoSystemFormat.formatDate(rec["SYORI_YMD"].ToString()));					// Ｍ１処理日付
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());												// Ｍ１処理時間
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1TONANHINKANRI_NO, rec["TONANHINKANRI_NO"].ToString());								// Ｍ１盗難品管理番号
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1TONANHINSYORI_YMD, BoSystemFormat.formatDate(rec["TONANHINSYORI_YMD"].ToString()));	// Ｍ１盗難品処理日付
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1TONANHINTENPO_CD, BoSystemFormat.formatTenpoCd(rec["TONANHINTENPO_CD"].ToString()));	// Ｍ１盗難品店舗コード
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SYONINSTATUSKBN, rec["SYONINSTATUSKBN"].ToString());									// Ｍ１承認状態名称
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SYONINSTATUS, rec["SYONINSTATUS"].ToString());										// Ｍ１承認状態名称
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SINSEIRIYU_KB, rec["SINSEIRIYU_KB"].ToString());										// Ｍ１申請理由区分
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SINSEIRIYU, rec["SINSEIRIYU"].ToString());											// Ｍ１申請理由
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());													// Ｍ１更新日
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());													// Ｍ１更新時間
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());										// Ｍ１送信済フラグ
					f01m1VO.Dictionary.Add(Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG, BoSystemConstant.CHECKBOX_OFF);									// Ｍ１明細画面確定フラグ

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
		private void AddWhere(Tf010f01Form f01VO, FindSqlResultTable reader, String table_id, String add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

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

			// 申請店舗コードFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_from))
			{
				sRepSql.Append("	AND T1.TENPO_CD >= :BIND_TEN_FROM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TEN_FROM_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Shinsei_tenpo_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 申請店舗コードTOを設定
			if (!string.IsNullOrEmpty(f01VO.Shinsei_tenpo_cd_to))
			{
				sRepSql.Append("	AND T1.TENPO_CD <= :BIND_TEN_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TEN_TO_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Shinsei_tenpo_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 業務稟議NoFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Gyomuringi_no_from))
			{
				sRepSql.Append("	AND T1.GYOMURINGI_NO >= :BIND_RINGI_FROM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_RINGI_FROM_" + add_where_id;
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

			// 伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			{
				sRepSql.Append("	AND T1.DENPYO_BANGO >= :BIND_DEN_FROM_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DEN_FROM_" + add_where_id;
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

			// 申請理由区分が45(盗難・事故）の場合
			if ("45".Equals(f01VO.Sinseiriyu_kb))
			{
				sRepSql.Append("	AND T1.TONANHINKANRI_NO <> 0");

			}
			// 申請理由区分が未選択以外の場合
			else if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Sinseiriyu_kb))
			{
				sRepSql.Append("	AND T1.TONANHINKANRI_NO = 0");
				sRepSql.Append("	AND T1.SINSEIRIYU_KB = :BIND_RIYU" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_RIYU" + add_where_id;
				bindVO.Value = Math.Floor(Convert.ToDecimal(f01VO.Sinseiriyu_kb) / 10).ToString();
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 経費振替申請テーブルの場合
			if (Tf010p01Constant.TABLE_ID_MDAT0020.Equals(table_id))
			{
				sRepSql.Append("	AND T1.KESSAI_FLG <> 1 ");
			}

			// 経費振替確定テーブルの場合
			if (Tf010p01Constant.TABLE_ID_MDAT0030.Equals(table_id))
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

				// 送信済フラグ
				// [選択モードNO]が「修正」「取消」の場合
				if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno))
				{
					sRepSql.Append("	AND T1.SOSINZUMI_FLG <> 1 ");
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
		private void addOrderBy(Tf010f01Form f01VO, FindSqlResultTable reader)
		{

			StringBuilder sRepSql = new StringBuilder();

			sRepSql.Append("				ORDER BY ");
	
			switch (f01VO.Meisai_sort)
			{
				// 「申請日順」の場合
				case ConditionMeisai_sort_tf010f01.VALUE_MEISAI_SORT_TF010F011:
					sRepSql.Append("					  APPLY_YMD ");
					sRepSql.Append("					, TENPO_CD ");
					sRepSql.Append("					, DENPYO_BANGO ");
					break;

				// 「店舗順」の場合
				case ConditionMeisai_sort_tf010f01.VALUE_MEISAI_SORT_TF010F012:
					sRepSql.Append("					  TENPO_CD ");
					sRepSql.Append("					, APPLY_YMD ");
					sRepSql.Append("					, DENPYO_BANGO ");
					break;

				// 「申請理由順」の場合
				case ConditionMeisai_sort_tf010f01.VALUE_MEISAI_SORT_TF010F013:
					sRepSql.Append("					  SINSEIRIYU_KB ");
					sRepSql.Append("					, TENPO_CD ");
					sRepSql.Append("					, APPLY_YMD ");
					sRepSql.Append("					, DENPYO_BANGO ");
					break;
			}

			BoSystemSql.AddSql(reader, Tf010p01Constant.SQL_ID_01_REP_ADD_ORDER1, sRepSql.ToString());

		}
		#endregion

	}
}
