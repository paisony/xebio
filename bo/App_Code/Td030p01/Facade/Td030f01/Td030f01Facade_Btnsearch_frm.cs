using com.xebio.bo.Td030p01.Constant;
using com.xebio.bo.Td030p01.Formvo;
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
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01010;
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

namespace com.xebio.bo.Td030p01.Facade
{
  /// <summary>
  /// Td030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td030f01Facade : StandardBaseFacade
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
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td030f01Form f01VO = (Td030f01Form) facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 入力値チェック
				// 1-1 伝票状態、仕入先コード
				//       伝票状態と仕入先コードの両方が入力されていない場合、エラーとする。
				if (f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU) && string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					ErrMsgCls.AddErrMsg("E175", string.Empty, facadeContext, new[] { "Denpyo_jyotai", "Siiresaki_cd" });
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック
				// 2-1 ヘッダ店舗コード
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

				// 2-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				f01VO.Siiresaki_ryaku_nm = string.Empty;
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

				// 2-3 入力担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				f01VO.Nyuryokutan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入荷担当者"
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

				// 2-4 確定担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				f01VO.Kakuteitan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Kakuteitan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Kakuteitan_cd
														, facadeContext
														, string.Empty
														, null
														, "確定担当者"
														, new[] { "Kakuteitan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Kakuteitan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 2-5 旧自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					Hashtable resultHash = new Hashtable();
					SearchHachuVO searchConditionVO = new SearchHachuVO();
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn;
					searchConditionVO.Tencd = f01VO.Head_tenpo_cd;
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}

				// 2-6 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_JANCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					Hashtable resultHash = new Hashtable();
					SearchHachuVO searchConditionVO = new SearchHachuVO();
					searchConditionVO.Scancd = f01VO.Scan_cd;
					searchConditionVO.Tencd = f01VO.Head_tenpo_cd;

					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ", new[] { "Scan_cd" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック

				// 2-1 伝票番号FROM、伝票番号TO
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

				// 2-2 元伝票番号FROM、元伝票番号TO
				//       元伝票番号ＦＲＯＭ > 元伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Motodenpyo_bango_from,
									f01VO.Motodenpyo_bango_to,
									facadeContext,
									"元伝票番号",
									new[] { "Motodenpyo_bango_from", "Motodenpyo_bango_to" }
									);
				}

				// 2-4 指示番号FROM、指示番号TO 
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

				// 2-3 指示番号FROM、指示番号TO 
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

				// 2-5 部門コードFROM、部門コードTO
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

				// 2-6 返品確定日FROM、返品確定日TO
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

				// 2-7 登録日FROM、登録日TO
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

				// 部門コードFrom(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門コードTo(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_to = (string)resultHash["BUMON_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 件数チェック

				#region テーブルID設定
				// テーブルIDを設定 -----------

				FindSqlResultTable rtChk = new FindSqlResultTable();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				// [伝票状態]が空白の場合
				if (f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 返品予定TBLと返品確定TBLから検索する。
					rtChk = FindSqlUtil.CreateFindSqlResultTable(Td030p01Constant.SQL_ID_02, facadeContext.DBContext);
				}
				else
				{
					rtChk = FindSqlUtil.CreateFindSqlResultTable(Td030p01Constant.SQL_ID_01, facadeContext.DBContext);

					// [伝票状態]が「未処理」の場合、返品予定TBLから検索する。
					if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
					{
						sRepSql.Append("MDRT0010");	// 返品予定TBL
					}
					// [伝票状態]が「確定」「ﾏﾆｭｱﾙ返品」の場合、返品確定TBLから検索する。
					else if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1)
							|| f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI3))
					{
						sRepSql.Append("MDRT0020");	// 返品確定TBL
					}
					// [伝票状態]が「登録履歴」「取消履歴」の場合、返品確定履歴TBLから検索する。
					else if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI4)
							|| f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
					{
						sRepSql.Append("MDRT0030");	// 返品確定履歴TBL
					}

					BoSystemSql.AddSql(rtChk, Td030p01Constant.REP_TABLE_ID, sRepSql.ToString(), bindList);
				}

				#endregion

				// 検索条件設定
				// [伝票状態]が空白の場合
				if (f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					AddWhere(f01VO, rtChk, ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2, Td030p01Constant.REP_ADD_WHERE1);
					AddWhere(f01VO, rtChk, ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1, Td030p01Constant.REP_ADD_WHERE2);
				}
				else
				{
					AddWhere(f01VO, rtChk, f01VO.Denpyo_jyotai, Td030p01Constant.REP_ADD_WHERE1);
				}

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();
				Decimal dCnt = 0;

				if (logger.IsDebugEnabled)
				{
					BoSystemLog.logOut("SQL: " + rtChk.LogSql);
				}

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

				string sSqlId = "";
				// [伝票状態]が「未処理」の場合、返品予定TBLから検索する。
				if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sSqlId = Td030p01Constant.SQL_ID_03;
				}
				// [伝票状態]が「確定」「ﾏﾆｭｱﾙ返品」の場合、返品確定TBLから検索する。
				else if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1)
						|| f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI3))
				{
					sSqlId = Td030p01Constant.SQL_ID_04;
				}
				// [伝票状態]が「登録履歴」「取消履歴」の場合、返品確定履歴TBLから検索する。
				else if (f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI4)
						|| f01VO.Denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
				{
					sSqlId = Td030p01Constant.SQL_ID_05;
				}
				// [伝票状態]が空白の場合、返品予定TBLと返品確定TBLから検索する。
				else
				{
					sSqlId = Td030p01Constant.SQL_ID_06;
				}
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);
				
				// 検索条件設定
				// [伝票状態]が空白の場合
				if (f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					AddWhere(f01VO, rtSeach, ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2, Td030p01Constant.REP_ADD_WHERE1);
					AddWhere(f01VO, rtSeach, ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1, Td030p01Constant.REP_ADD_WHERE2);
				}
				else
				{
					AddWhere(f01VO, rtSeach, f01VO.Denpyo_jyotai, Td030p01Constant.REP_ADD_WHERE1);
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				int iCnt = 0;

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Td030f01M1Form f01m1VO = new Td030f01M1Form();

                    f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
                    f01m1VO.M1bumon_cd_bo1 = rec["BUMON_CD"].ToString();												// Ｍ１部門コード
                    f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
                    f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
                    f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先略式名称
                    f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
                    f01m1VO.M1henpin_kakutei_ymd = rec["HENPIN_YMD"].ToString();										// Ｍ１返品確定日
                    f01m1VO.M1add_ymd = rec["ADD_YMD"].ToString();														// Ｍ１登録日

                    f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDenpyoNo(BoSystemString.ZeroToEmpty(rec["DENPYO_BANGO"].ToString()))); // Ｍ１伝票番号リンク
                    f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1KANRI_NO, BoSystemFormat.formatDenpyoNo(BoSystemString.ZeroToEmpty(rec["KANRI_NO"].ToString()))); // Ｍ１管理Noリンク
                    f01m1VO.M1siji_bango = BoSystemString.ZeroToEmpty(rec["SIJI_BANGO"].ToString());					// Ｍ１指示番号
                    f01m1VO.M1motodenpyo_bango = BoSystemFormat.formatDenpyoNo(BoSystemString.ZeroToEmpty(rec["MOTODENPYO_BANGO"].ToString()));	// Ｍ１元伝票番号

                    f01m1VO.M1itemsu = rec["GOKEI_SU"].ToString();														// Ｍ１数量
                    f01m1VO.M1genkakin = rec["GOUKEI_KIN"].ToString();													// Ｍ１原価金額
                    f01m1VO.M1nyuryokutan_nm = rec["NYURYOKUTAN_NM"].ToString();										// Ｍ１入力担当者名称
                    f01m1VO.M1kakuteitan_nm = rec["KAKUTEITAN_NM"].ToString();											// Ｍ１確定担当者名称
                    f01m1VO.M1henpin_riyu_nm = rec["HENPIN_RIYU_NM"].ToString();										// Ｍ１返品理由名称
                    f01m1VO.M1denpyo_jyotainm = rec["DENPYO_JYOTAINM"].ToString();										// Ｍ１伝票状態名称
                    f01m1VO.M1syorinm = rec["SYORINM"].ToString();										                // Ｍ１処理名称
                    f01m1VO.M1syoriymd = rec["RIREKI_SYORI_YMD"].ToString();										    // Ｍ１処理日
					f01m1VO.M1syori_tm = rec["RIREKI_SYORI_TM"].ToString();												// Ｍ１処理時間
					if (!string.IsNullOrEmpty(f01m1VO.M1syori_tm))
					{
						f01m1VO.M1syori_tm = BoSystemFormat.formatTime(Convert.ToDecimal(f01m1VO.M1syori_tm), 1);
					}
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						// 送信済みの場合、背景色変更
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}

                    // Dictionary
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1NYURYOKUTAN_CD, rec["NYURYOKUTAN_CD"].ToString());	// 入力担当者コード
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1KAKUTEITAN_CD, rec["KAKUTEITAN_CD"].ToString());		// 確認担当者コード
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());			// ブランドコード
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());				// 部門名
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());				// 処理日付
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				// 店舗コード
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1RIREKI_NO, rec["RIREKI_NO"].ToString());				// 履歴No
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1AKAKURO_KBN, rec["AKAKURO_KBN"].ToString());			// 赤黒区分
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());		// 送信済フラグ
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1TBL_KBN, rec["TBL_KBN"].ToString());					// 参照テーブル
					f01m1VO.Dictionary.Add(Td030p01Constant.DIC_M1KAKUTEI_SB, rec["KAKUTEI_SB"].ToString());			// 確定種別

					// フォーカス項目
					if (iCnt == 1)
					{
						if (!string.IsNullOrEmpty(rec["DENPYO_BANGO"].ToString()))
						{
							f01VO.Dictionary[Td030p01Constant.DIC_FOCUS_ITEM] = "M1denpyo_bango";
						}
						else if (!string.IsNullOrEmpty(rec["KANRI_NO"].ToString()))
						{
							f01VO.Dictionary[Td030p01Constant.DIC_FOCUS_ITEM] = "M1kanri_no";
						}
						else
						{
							f01VO.Dictionary[Td030p01Constant.DIC_FOCUS_ITEM] = "";
						}
					}

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
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
		/// <param name="f01VO">Td030f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="string">denpyo_jyotai</param>
		/// <param name="string">add_where_id</param>
		/// <returns></returns>
		private void AddWhere(Td030f01Form f01VO, FindSqlResultTable reader, string denpyo_jyotai, string add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// バインド変数
			string add_bind = "";
			if (add_where_id.Equals(Td030p01Constant.REP_ADD_WHERE1))
			{
				add_bind = Td030p01Constant.REP_ADD_BIND1;
			}
			else if (add_where_id.Equals(Td030p01Constant.REP_ADD_WHERE2))
			{
				add_bind = Td030p01Constant.REP_ADD_BIND2;
			}

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD_" + add_bind);

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD_" + add_bind;
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// [伝票状態]が「未処理」以外の場合
			if (!denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
			{
				// 伝票番号FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
				{
					sRepSql.Append(" AND T1.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO_FROM_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 伝票番号TOを設定
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					sRepSql.Append(" AND T1.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO_TO_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 元伝票番号FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from))
				{
					sRepSql.Append(" AND T1.MOTODENPYO_BANGO >= :BIND_MOTODENPYO_FROM_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_MOTODENPYO_FROM_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Motodenpyo_bango_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 元伝票番号TOを設定
				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					sRepSql.Append(" AND T1.MOTODENPYO_BANGO <= :BIND_MOTODENPYO_TO_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_MOTODENPYO_TO_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Motodenpyo_bango_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 指示番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from))
			{
				//後10桁を条件とする
				string siji_bango_from = f01VO.Siji_bango_from;
				if (siji_bango_from.Length > 10)
				{
					siji_bango_from = siji_bango_from.Substring(siji_bango_from.Length - 10, 10);
				}

				sRepSql.Append(" AND T1.SIJI_BANGO >= :BIND_SIJI_BANGO_FROM_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_FROM_" + add_bind;
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(siji_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 指示番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				//後10桁を条件とする
				string siji_bango_to = f01VO.Siji_bango_to;
				if (siji_bango_to.Length > 10)
				{
					siji_bango_to = siji_bango_to.Substring(siji_bango_to.Length - 10, 10);
				}

				sRepSql.Append(" AND T1.SIJI_BANGO <= :BIND_SIJI_BANGO_TO_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_TO_" + add_bind;
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(siji_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 仕入先コードを設定
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
			{
				sRepSql.Append(" AND T1.BUMON_CD >= :BIND_BUMON_CD_FROM_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_FROM_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門TOを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND T1.BUMON_CD <= :BIND_BUMON_CD_TO_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_TO_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// [伝票状態]が「未処理」以外の場合
			if (!denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
			{
				// 返品確定日FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from))
				{
					sRepSql.Append(" AND T1.HENPIN_YMD >= :BIND_HENPIN_YMD_FROM_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HENPIN_YMD_FROM_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 返品確定日TOを設定
				if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
				{
					sRepSql.Append(" AND T1.HENPIN_YMD <= :BIND_HENPIN_YMD_TO_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HENPIN_YMD_TO_" + add_bind;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 登録日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				// [伝票状態]が「未処理」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sRepSql.Append(" AND T1.UPD_YMD >= :BIND_ADD_YMD_FROM_" + add_bind);
				}
				else
				{
					sRepSql.Append(" AND T1.HHTADD_YMD >= :BIND_ADD_YMD_FROM_" + add_bind);

				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_FROM_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				// [伝票状態]が「未処理」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sRepSql.Append(" AND T1.UPD_YMD <= :BIND_ADD_YMD_TO_" + add_bind);
				}
				else
				{
					sRepSql.Append(" AND T1.HHTADD_YMD <= :BIND_ADD_YMD_TO_" + add_bind);

				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_TO_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 入力担当者コードを設定
			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				// [伝票状態]が「未処理」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sRepSql.Append(" AND T1.UPD_TANCD = :BIND_NYURYOKU_TANCD_" + add_bind);
				}
				else
				{
					sRepSql.Append(" AND T1.HHTADDTAN_CD = :BIND_NYURYOKU_TANCD_" + add_bind);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_NYURYOKU_TANCD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// [伝票状態]が「未処理」以外の場合
			if (!denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
			{
				// 確定担当者コードを設定
				if (!string.IsNullOrEmpty(f01VO.Kakuteitan_cd))
				{
					sRepSql.Append(" AND T1.UPD_TANCD = :BIND_KAKUTEI_TANCD_" + add_bind);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KAKUTEI_TANCD_" + add_bind;
					bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Kakuteitan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			// 返品理由を設定
			if (!string.IsNullOrEmpty(f01VO.Henpin_riyu) && !f01VO.Henpin_riyu.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND T1.HENPIN_RIYU = :BIND_HENPIN_RIYU_" + add_bind);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_RIYU_" + add_bind;
				bindVO.Value = f01VO.Henpin_riyu;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 自社品番を設定
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND EXISTS(");

				// [伝票状態]が「未処理」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0011 T2");	// 返品予定TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T2.KANRI_NO  = T1.KANRI_NO");
					sRepSql.Append(" 		AND		T2.SYORI_YMD = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T2.TENPO_CD  = T1.TENPO_CD");
				}
				// [伝票状態]が「確定」「ﾏﾆｭｱﾙ返品」の場合
				else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1)
						|| denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI3))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0021 T2");	// 返品確定TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T2.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND		T2.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T2.TENPO_CD      = T1.TENPO_CD");
				}
				// [伝票状態]が「登録履歴」「取消履歴」の場合
				else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI4)
						|| denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0031 T2");	// 返品確定履歴TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T2.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND		T2.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T2.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T2.RIREKI_NO     = T1.RIREKI_NO");
					sRepSql.Append(" 		AND		T2.AKAKURO_KBN   = T1.AKAKURO_KBN");
				}

				//// [自社品番]が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	sRepSql.Append(" 		AND		T2.JAN_CD IN (");
				//	sRepSql.Append(" 					SELECT JAN_CD");
				//	sRepSql.Append(" 					FROM MDMT0130");
				//	sRepSql.Append(" 					WHERE OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_bind);
				//	sRepSql.Append(" 		        )");
				//}
				//else
				//{
					sRepSql.Append(" 		AND		T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_bind);
				//}

				sRepSql.Append(" )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN_" + add_bind;
				bindVO.Value = (string)f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコードを設定
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND EXISTS(");

				// [伝票状態]が「未処理」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0011 T3");	// 返品予定TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T3.KANRI_NO  = T1.KANRI_NO");
					sRepSql.Append(" 		AND		T3.SYORI_YMD = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T3.TENPO_CD  = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T3.JAN_CD    = :BIND_JAN_CD_" + add_bind);
				}
				// [伝票状態]が「確定」「ﾏﾆｭｱﾙ返品」の場合
				else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1)
						|| denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI3))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0021 T3");	// 返品確定TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T3.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND		T3.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T3.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T3.JAN_CD        = :BIND_JAN_CD_" + add_bind);
				}
				// [伝票状態]が「登録履歴」「取消履歴」の場合
				else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI4)
						|| denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
				{
					sRepSql.Append(" 		SELECT 1 FROM MDRT0031 T3");	// 返品確定履歴TBL
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T3.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND		T3.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T3.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND		T3.RIREKI_NO     = T1.RIREKI_NO");
					sRepSql.Append(" 		AND		T3.AKAKURO_KBN   = T1.AKAKURO_KBN");
					sRepSql.Append(" 		AND		T3.JAN_CD        = :BIND_JAN_CD_" + add_bind);
				}
				sRepSql.Append(" )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD_" + add_bind;
				bindVO.Value = (string)f01VO.Dictionary[Td030p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// その他の条件を設定
			// [伝票状態]が「未処理」の場合
			if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI2))
			{
				// 確定フラグ
				sRepSql.Append(" AND T1.KAKUTEI_FLG = 0");
			}
			// [伝票状態]が「確定」の場合
			else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1))
			{
				if (!f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 確定種別
					sRepSql.Append(" AND T1.KAKUTEI_SB IN (0,2)");
				}
			}
			// [伝票状態]が「ﾏﾆｭｱﾙ返品」の場合
			else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI3))
			{
				// 確定種別
				sRepSql.Append(" AND T1.KAKUTEI_SB IN (1,3)");
			}
			// [伝票状態]が「登録履歴」「取消履歴」の場合
			else if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI4)
					|| denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
			{
				// 履歴画面表示区分
				sRepSql.Append(" AND T1.RIREKI_DISP_KB = 1");

				// [伝票状態]が「取消履歴」の場合
				if (denpyo_jyotai.Equals(ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI5))
				{
					// 返品確定履歴TBLの取消データあり
					sRepSql.Append(" AND (");
					sRepSql.Append("	EXISTS(");
					sRepSql.Append("		SELECT 1 FROM MDRT0030 T4");
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T4.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND 	T4.KANRI_NO      = T1.KANRI_NO");
					sRepSql.Append(" 		AND 	T4.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T4.SYORI_SB      = 2");
					sRepSql.Append(" 		AND		T4.KANRI_NO      <> 0");
					sRepSql.Append("	)");
					sRepSql.Append("	OR");
					sRepSql.Append("	EXISTS(");
					sRepSql.Append(" 		SELECT 1 FROM MDRT0030 T5");
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T5.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND 	T5.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND 	T5.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T5.SYORI_SB      IN (2, 5)");
					sRepSql.Append(" 		AND		T5.KANRI_NO      = 0");
					sRepSql.Append("	)");
					sRepSql.Append("	OR");
					sRepSql.Append("	EXISTS(");
					sRepSql.Append(" 		SELECT 1 FROM MDRT0030 T6");
					sRepSql.Append(" 		WHERE");
					sRepSql.Append(" 				T6.TENPO_CD      = T1.TENPO_CD");
					sRepSql.Append(" 		AND 	T6.KANRI_NO      = T1.KANRI_NO");
					sRepSql.Append(" 		AND 	T6.DENPYO_BANGO  = T1.DENPYO_BANGO");
					sRepSql.Append(" 		AND 	T6.SYORI_YMD     = T1.SYORI_YMD");
					sRepSql.Append(" 		AND		T6.SYORI_SB      = 5");
					sRepSql.Append(" 		AND		T6.KANRI_NO      <> 0");
					sRepSql.Append("	)");
					sRepSql.Append(" )");
				}
			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);
			#endregion

		}

		#endregion
	}
}
