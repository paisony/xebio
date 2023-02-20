using com.xebio.bo.Te070p01.Constant;
using com.xebio.bo.Te070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01027;
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

namespace com.xebio.bo.Te070p01.Facade
{
  /// <summary>
  /// Te070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te070f01Facade : StandardBaseFacade
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
			
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Te070f01Form f07VO = (Te070f01Form)facadeContext.FormVO;
				IDataList m1List = f07VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion
				
				#region 入力値チェック
				// 1-1 伝票状態、出荷店コード
				// 伝票状態と出荷店コードのどちらかが入力されていない場合、エラーとする。
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai) && string.IsNullOrEmpty(f07VO.Syukkaten_cd))
				{
					ErrMsgCls.AddErrMsg("E176", string.Empty, facadeContext, new[] { "Denpyo_jyotai", "Syukkaten_cd" });
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
				f07VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f07VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f07VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f07VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}
				// 2-2 会社コード
				// 名称MST(KASY)に存在しない場合エラー
				if (!string.IsNullOrEmpty(BoSystemString.AllZeroToEmpty(f07VO.Kaisya_cd)))
				{
					// 入荷会社コードの前0除去
					string unformatJyuryokaisyaCd = Convert.ToInt32(f07VO.Kaisya_cd).ToString();

					Hashtable resultHash = new Hashtable();
					resultHash = V01006Check.CheckKaisya(f07VO.Kaisya_cd
														, facadeContext
														, string.Empty
														, null
														, "会社"
														, new[] { "Kaisya_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);

					if (resultHash != null)
					{
						f07VO.Kaisya_nm = (string)resultHash["MEISYO_NM"];
					}
            
				}

				// 2-3 出荷店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f07VO.Syukkaten_nm = string.Empty;
				if (!string.IsNullOrEmpty(f07VO.Syukkaten_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01026Check.CheckTenpoAll(f07VO.Kaisya_cd
														, f07VO.Syukkaten_cd
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
						f07VO.Syukkaten_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 2-4、2-5 SCMコード
				//		入力桁数が14桁でない、かつ20桁でない場合、エラー
				//		先頭2バイトが[00][01][02][03][04]以外はエラー
				if (!string.IsNullOrEmpty(f07VO.Scm_cd))
				{
					// SCMコードフォーマット
					f07VO.Scm_cd = BoSystemFormat.formatScmCd(f07VO.Scm_cd);

					if (!ScmCodeCls.CheckLength(f07VO.Scm_cd))
					{
						// 入力桁数が14桁でない、かつ20桁でない場合、エラー
						ErrMsgCls.AddErrMsg("E223", string.Empty, facadeContext, new[] { "Scm_cd" });
					}
					else if (!ScmCodeCls.CheckFormat(f07VO.Scm_cd))
					{
						// 先頭2バイトが[00][01][02][03][04]以外はエラー
						ErrMsgCls.AddErrMsg("E209", string.Empty, facadeContext, new[] { "Scm_cd" });
					}
				}

				// 2-6 旧自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f07VO.Maker_hbn = string.Empty;
				f07VO.Dictionary[Te070p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(f07VO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f07VO.Old_jisya_hbn,	// 自社品番
						f07VO.Head_tenpo_cd,	// 店舗コード
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
						f07VO.Maker_hbn = (string)resultHash["HIN_NBR"];
						// 自社品番をディクショナリに退避
						f07VO.Dictionary[Te070p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
					}
				}


				// 2-7 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f07VO.Scan_cd))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f07VO.Scan_cd,			// スキャンコード
						f07VO.Head_tenpo_cd,	// 店舗コード
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
						f07VO.Dictionary[Te070p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}



				}

				// 2-8 ｵﾌﾗｲﾝ伝票No（Xのみ）
				//       20桁以外の場合、エラー
				if (!string.IsNullOrEmpty(f07VO.Offline_no))
				{
					if (f07VO.Offline_no.Length != 20)
					{
						ErrMsgCls.AddErrMsg("E107", new[] { "ｵﾌﾗｲﾝ伝票", "20" }, facadeContext, new[] { "Offline_no" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion
 
				#region 関連チェック

				// 3-1 出荷日FROM、出荷日TO
				//      出荷日ＦＲＯＭ >出荷日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f07VO.Syukka_ymd_from) && !string.IsNullOrEmpty(f07VO.Syukka_ymd_to))
				{
					V03001Check.DateFromToChk(
									f07VO.Syukka_ymd_from,
									f07VO.Syukka_ymd_to,
									facadeContext,
									"出荷日",
									new[] { "Syukka_ymd_from", "Syukka_ymd_to" }
									);
				}

				// 3-2 入荷日FROM、入荷日TO
				//     入荷日ＦＲＯＭ  >入荷日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f07VO.Jyuryo_ymd_from) && !string.IsNullOrEmpty(f07VO.Jyuryo_ymd_to))
				{
					V03001Check.DateFromToChk(
									f07VO.Jyuryo_ymd_from,
									f07VO.Jyuryo_ymd_to,
									facadeContext,
									"入荷日",
									new[] { "Jyuryo_ymd_from", "Jyuryo_ymd_to" }
									);
				}

				// 3-3 出荷店コード、会社コード
				//      出荷店コード入力時は会社コードが未入力の場合エラー
				if (!string.IsNullOrEmpty(f07VO.Syukkaten_cd))
				{
					if (string.IsNullOrEmpty(f07VO.Kaisya_cd))
					{
						ErrMsgCls.AddErrMsg("E159", string.Empty, facadeContext, new[] {"Syukkaten_cd", "Kaisya_cd" });
					}
				}

				// 3-4 伝票番号FROM、伝票番号TO
				//       伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f07VO.Denpyo_bango_from) && !string.IsNullOrEmpty(f07VO.Denpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f07VO.Denpyo_bango_from,
									f07VO.Denpyo_bango_to,
									facadeContext,
									"伝票番号",
									new[] { "Denpyo_bango_from", "Denpyo_bango_to" }
									);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 件数チェック

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				Decimal dCnt = 0;
				String sSqlId_chk = null;
				String sSqlId_src = null;
				String sTblId1 = null;
				String sTblId2 = null;

				// 伝票状態によってSQL、テーブルを変更する
				switch (f07VO.Denpyo_jyotai)
				{
					// 「未処理」の場合
					case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI2:
						sSqlId_chk = Te070p01Constant.SQL_ID_02;
						sSqlId_src = Te070p01Constant.SQL_ID_04;
						sTblId1 = Te070p01Constant.TABLE_ID_MDNT0010;	// 移動入荷予定テーブル(H)
						break;

					// 「確定」「差異あり」の場合
					case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI1:
					case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI3:
						sSqlId_chk = Te070p01Constant.SQL_ID_02;
						sSqlId_src = Te070p01Constant.SQL_ID_05;
						sTblId1 = Te070p01Constant.TABLE_ID_MDNT0020;	// 移動入荷確定テーブル(H)
						break;

					// 「登録履歴」「取消履歴」の場合
					case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI4:
					case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI5:
						sSqlId_chk = Te070p01Constant.SQL_ID_02;
						sSqlId_src = Te070p01Constant.SQL_ID_06;
						sTblId1 = Te070p01Constant.TABLE_ID_MDNT0040;	// 移動入荷履歴テーブル(H)
						break;

					// 空白の場合
					default:
						sSqlId_chk = Te070p01Constant.SQL_ID_01;
						sSqlId_src = Te070p01Constant.SQL_ID_03;
						sTblId1 = Te070p01Constant.TABLE_ID_MDNT0010;	// 仕入入荷予定テーブル(H)
						sTblId2 = Te070p01Constant.TABLE_ID_MDNT0020;	// 仕入入荷確定テーブル(H)
						break;
				}

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(sSqlId_chk, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------
				BoSystemSql.AddSql(rtChk, Te070p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					BoSystemSql.AddSql(rtChk, Te070p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f07VO, rtChk, sTblId1, Te070p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					this.AddWhere(f07VO, rtChk, sTblId2, Te070p01Constant.SQL_ID_01_REP_ADD_WHERE2);
				}

				BoSystemLog.logOut("移動入荷件数を検索 START");
				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();
				BoSystemLog.logOut("[移動入荷件数を検索 END");

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

				// 移動入荷予定テーブルテーブルから検索する。

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId_src, facadeContext.DBContext);

				#region テーブルID設定

				// テーブルIDを設定 -----------
				BoSystemSql.AddSql(rtSeach, Te070p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);
				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					BoSystemSql.AddSql(rtSeach, Te070p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f07VO, rtSeach, sTblId1, Te070p01Constant.SQL_ID_01_REP_ADD_WHERE1);
				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					this.AddWhere(f07VO, rtSeach, sTblId2, Te070p01Constant.SQL_ID_01_REP_ADD_WHERE2);
				}
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				//伝票状態が空白の時に使用する変数の設定
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_ORD_LOGINTENPO_CD, Convert.ToDecimal(loginInfVo.CopCd));
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_ORD_LOGIN_TENPOCD, Convert.ToDecimal(loginInfVo.CopCd));
				}
				else
				{
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_ORD_LOGINTENPO_CD, Convert.ToDecimal(loginInfVo.CopCd));
				}
				//ログイン会社コードと出荷会社コード比較用変数の設定
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f07VO.Denpyo_jyotai))
				{
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_SEL_LOGINTENPO_RE, Convert.ToDecimal(loginInfVo.CopCd));
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_SEL_LOGIN_TENPOCD_RE, Convert.ToDecimal(loginInfVo.CopCd));
				}
				else
				{
					rtSeach.BindValue(Te070p01Constant.SQL_ID_04_SEL_LOGINTENPO_RE, Convert.ToDecimal(loginInfVo.CopCd));
				}

				BoSystemLog.logOut("移動入荷結果を検索 START");
				////検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				BoSystemLog.logOut("移動入荷結果を取得　END");

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Te070f01M1Form f07m1VO = new Te070f01M1Form();

					f07m1VO.M1rowno = iCnt.ToString();																	// Ｍ１ＮＯ
					//ログイン中の会社コードと出荷会社コードが同じ場合、会社コードを非表示とする。

					decimal loginkaisyacd = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatKaisyaCd(loginInfVo.CopCd), "0"));
					decimal syukkakaisyacd = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatKaisyaCd(rec["SYUKKAKAISYA_CD"].ToString()), "0"));

					if (loginkaisyacd == syukkakaisyacd)
					{
						f07m1VO.M1kaisya_cd = "";                
					}
					else
					{
						f07m1VO.M1kaisya_cd = rec["SYUKKAKAISYA_NM_KANA"].ToString();									// 会社カナ名
					}
                
					f07m1VO.M1syukkaten_cd = BoSystemFormat.formatTenpoCd(rec["SYUKKATEN_CD"].ToString());				// 出荷店コード
					f07m1VO.M1syukkaten_nm = rec["TENPO_NM"].ToString();												// 出荷店舗
					f07m1VO.M1scm_cd = BoSystemFormat.formatViewScmCd(rec["SCM_CD"].ToString());						// SCMコード
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
																														// Ｍ１伝票番号リンク
					f07m1VO.M1syukka_ymd = BoSystemFormat.formatDate(rec["SYUKKA_YMD"].ToString());						// 出荷日
					f07m1VO.M1jyuryo_ymd = BoSystemFormat.formatDate(rec["JYURYO_YMD"].ToString());						// 入荷日
					f07m1VO.M1yotei_su = rec["NYUKAYOTEIGOUKEI_SU"].ToString();											// 入荷予定合計数量

					f07m1VO.M1kyakucyu = rec["KYAKUTYU_FLG"].ToString();                                                // 客注
					f07m1VO.M1negaki = rec["NEGAKIHIN_FLG"].ToString();                                                 // 値書
					f07m1VO.M1denpyo_jyotainm = rec["DENPYO_NM"].ToString();                                            // 伝票状態名称

					//確定数の設定
					//検索条件の伝票状態が未処理のとき、確定数量を空白にする
					if (ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI2.Equals(f07VO.Denpyo_jyotai))
					{
						f07m1VO.M1kakutei_su = "";
					}
					else
					{
						f07m1VO.M1kakutei_su = rec["NYUKAJISSEKIGOUKEI_SU"].ToString();
					}

					f07m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
																														// Ｍ１選択フラグ(隠し)
					f07m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
																														// Ｍ１確定処理フラグ(隠し)
					if (rec.ContainsKey("SOSINZUMI_FLG")
						&& rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						// 送信済フラグＯＮの場合
						f07m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						// それ以外の場合
						f07m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}
                                
					//伝票状態が「登録履歴」「取消履歴」の場合
					if (ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI4.Equals(f07VO.Denpyo_jyotai) || (ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI5.Equals(f07VO.Denpyo_jyotai)))
					{
						f07m1VO.M1syorinm = rec["SYORI_NM"].ToString();                                         //処理名称
						f07m1VO.M1syoriymd = BoSystemFormat.formatDate(rec["RIREKI_SYORI_YMD"].ToString());     //処理日
						f07m1VO.M1syori_tm = BoSystemFormat.formatTime(rec["RIREKI_SYORI_TM"].ToString());      //処理時間
					}


					// Dictionary
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1SYUKKAKAISYA_CD, rec["SYUKKAKAISYA_CD"].ToString());
																												// 出荷会社コード
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1SYUKKAKAISYA_NM, rec["SYUKKAKAISYA_NM"].ToString());
																												// 出荷会社名                    
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1SYUKKATEN_CD, rec["SYUKKATEN_CD"].ToString());
																												// 出荷店コード
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1TENPO_NM, rec["TENPO_NM"].ToString());	    // 出荷会社名称
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1TENPOLC_KBN, rec["TENPOLC_KBN"].ToString());
																												// 店舗ＬＣ区分
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1RIREKI_SYORIYMD, rec["RIREKI_SYORI_YMD"].ToString());
																												// 履歴処理日付
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1RIREKI_SYORITM, rec["RIREKI_SYORI_TM"].ToString());
																												// 履歴処理時間
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1ADDHANBAIIN_CD, rec["ADDHANBAIIN_CD"].ToString());
																												// 入荷担当者コード
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1HANBAIIN_NM, rec["HANBAIIN_NM"].ToString());
																												// 入荷担当者名    
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1SYUKKATAN_CD, rec["SYUKKATAN_CD"].ToString());
																												// 出荷担当者コード
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1SYUKKATAN_HANBAIIN_NM, rec["SYUKKATAN_HANBAIIN_NM"].ToString());
																												// 出荷担当者名
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1DENPYO_JYOTAI, rec["DENPYO_JYOTAI"].ToString());
																												 //伝票状態
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1KAKUTEI_FLG, rec["KAKUTEI_FLG"].ToString());  // 確定フラグ
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1RIREKI_NO, rec["RIREKI_NO"].ToString());      // 履歴No
					f07m1VO.Dictionary.Add(Te070p01Constant.DIC_M1AKAKURO_KBN, rec["AKAKURO_KBN"].ToString());  // 赤黒区分

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f07m1VO, true);
				}

				// 検索件数の設定
				f07VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f07VO);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

        #region 検索条件設定
        /// <summary>
        /// AddWhere 検索条件設定
        /// </summary>
        /// <param name="f01VO">Tb010f01Form</param>
        /// <param name="FindSqlResultTable">rtChk</param>
        /// <param name="String">table_id</param>
        /// <param name="String">add_where_id</param>
        /// <returns></returns>
        private void AddWhere(Te070f01Form f01VO, FindSqlResultTable reader, String table_id, String add_where_id)
        {
            ArrayList bindList = new ArrayList();
            BindInfoVO bindVO = new BindInfoVO();
            StringBuilder sRepSql = new StringBuilder();

            #region 検索条件設定

            // 検索条件を設定 -----------

            sRepSql = new StringBuilder();

            // 店舗コードを設定
            sRepSql.Append("	AND T1.JYURYOTEN_CD = :BIND_TENPO_CD_" + add_where_id);

            bindVO = new BindInfoVO();
            bindVO.BindId = "BIND_TENPO_CD_" + add_where_id;
            bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
            bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
            bindList.Add(bindVO);

            //// 出荷日FROM-TOを設定

            if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from) || !string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
            {
                String syukka_ymd_from = f01VO.Syukka_ymd_from;
                String syukka_ymd_to = f01VO.Syukka_ymd_to;

                // 出荷日FROM
                if (string.IsNullOrEmpty(f01VO.Syukka_ymd_from))
                {
                    syukka_ymd_from = "0";
                }

                // 出荷日TO
                if (string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
                {
                    syukka_ymd_to = "99999999";
                }

                sRepSql.Append("	AND T1.SYUKKA_YMD BETWEEN :BIND_SYUKKA_FROM_" + add_where_id + " AND :BIND_SYUKKA_TO_" + add_where_id);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SYUKKA_FROM_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatDate(syukka_ymd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SYUKKA_TO_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatDate(syukka_ymd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }

            //伝票状態が「未処理」以外の場合、入荷日FROM-TOを設定を設定
    
            if (!Te070p01Constant.TABLE_ID_MDNT0010.Equals(table_id))
            {         
                if (!string.IsNullOrEmpty(f01VO.Jyuryo_ymd_from) || !string.IsNullOrEmpty(f01VO.Jyuryo_ymd_to))        
                {
                            
                    String jyuryo_ymd_from = f01VO.Jyuryo_ymd_from;      
                    String jyuryo_ymd_to = f01VO.Jyuryo_ymd_to;

                    // 入荷日FROM
                    if (string.IsNullOrEmpty(f01VO.Jyuryo_ymd_from))
                    {
                        jyuryo_ymd_from = "0";
                    }

                    // 入荷日TO
                    if (string.IsNullOrEmpty(f01VO.Jyuryo_ymd_to))
                    {
                        jyuryo_ymd_to = "99999999";
                    }
                     sRepSql.Append("	AND T1.JYURYO_YMD BETWEEN :BIND_JYURYO_FROM_" + add_where_id + " AND :BIND_JYURYO_TO_" + add_where_id);
    
                    bindVO = new BindInfoVO();
                    bindVO.BindId = "BIND_JYURYO_FROM_" + add_where_id;
                    bindVO.Value = BoSystemFormat.formatDate(jyuryo_ymd_from);
                    bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                    bindList.Add(bindVO);

                    bindVO = new BindInfoVO();
                    bindVO.BindId = "BIND_JYURYO_TO_" + add_where_id;
                    bindVO.Value = BoSystemFormat.formatDate(jyuryo_ymd_to);
                    bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                    bindList.Add(bindVO);
                }

            }
            //会社コードを設定
            if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
            {
                sRepSql.Append("	AND T1.SYUKKAKAISYA_CD = :BIND_KAISYA_CD_" + add_where_id);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_KAISYA_CD_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatKaisyaCd(f01VO.Kaisya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }

            //出荷店コードを設定
            if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
            {
                sRepSql.Append("	AND T1.SYUKKATEN_CD = :BIND_SYUKKATEN_CD_" + add_where_id);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SYUKKATEN_CD_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Syukkaten_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }
               
            // 伝票番号FROM-TOを設定

            if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) || !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
            {
                String denpyo_bango_from = f01VO.Denpyo_bango_from;
                String denpyo_bango_to = f01VO.Denpyo_bango_to;

                // 伝票番号FROM
                if (string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
                {
                    denpyo_bango_from = "0";
                }

                // 伝票番号TO
                if (string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
                {
                    denpyo_bango_to = "999999";
                }

                sRepSql.Append(" AND T1.DENPYO_BANGO BETWEEN :BIND_DEN_FROM_" + add_where_id + " AND :BIND_DEN_TO_" + add_where_id);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_DEN_FROM_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatDenpyoNo(denpyo_bango_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_DEN_TO_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatDenpyoNo(denpyo_bango_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }

            //SCMコードを設定
            if (!string.IsNullOrEmpty(f01VO.Scm_cd))
            {
                sRepSql.Append("	AND T1.SCM_CD = :BIND_SCM_CD_" + add_where_id);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SCM_CD_" + add_where_id;
                bindVO.Value = BoSystemFormat.formatScmCd(f01VO.Scm_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }

            // 自社品番を設定

            if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
            {
                // 移動入荷予定テーブルの場合
                if (Te070p01Constant.TABLE_ID_MDNT0010.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0011 T2");
                    sRepSql.Append("		WHERE  T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND  T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND  T2.DENPYO_BANGO = T1.DENPYO_BANGO");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//	sRepSql.Append("				MDMT0130.JAN_CD");
					//	sRepSql.Append("			FROM MDMT0130");
					//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//	sRepSql.Append("		)");
					//}
					//// 自社品番が10桁以外の場合
					//else
                    //{
                        sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
                    //}
                    sRepSql.Append("	 )");

                    // 移動入荷確定テーブルの場合
                }
                else if (Te070p01Constant.TABLE_ID_MDNT0020.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0021 T2");
                    sRepSql.Append("		WHERE T2.TENPOLC_KBN = T1.TENPOLC_KBN");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND   T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//	sRepSql.Append("				MDMT0130.JAN_CD");
					//	sRepSql.Append("			FROM MDMT0130");
					//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//	sRepSql.Append("		)");
					//}
					//// 自社品番が10桁以外の場合
					//else
					//{
                        sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
                    //}
                    sRepSql.Append("	 )");

                    // 移動入荷履歴テーブルの場合
                }
                else if (Te070p01Constant.TABLE_ID_MDNT0040.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0041 T2");
                    sRepSql.Append("		WHERE T2.TENPOLC_KBN = T1.TENPOLC_KBN");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD"); 
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");
                    sRepSql.Append("		AND   T2.RIREKI_NO = T1.RIREKI_NO");
                    sRepSql.Append("		AND   T2.AKAKURO_KBN = T1.AKAKURO_KBN");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND   T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//		sRepSql.Append("		    MDMT0130.JAN_CD");
					//		sRepSql.Append("			FROM MDMT0130");
					//		sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//		sRepSql.Append("		)");
					//}
					//else
					//{
                        sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
                    //}
                    sRepSql.Append("	 )");

                }

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_JISYA_HBN_" + add_where_id;
				bindVO.Value = (string)f01VO.Dictionary[Te070p01Constant.DIC_SEARCH_XEBIOCD];
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }

            // スキャンコードを設定

            if (!string.IsNullOrEmpty(f01VO.Scan_cd))
            {
                // 移動入荷予定テーブルの場合
                if (Te070p01Constant.TABLE_ID_MDNT0010.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0011 T2");
                    sRepSql.Append("		WHERE T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
                    sRepSql.Append("	 )");

                //移動入荷確定テーブルの場合
                }
                else if(Te070p01Constant.TABLE_ID_MDNT0020.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0021 T2");
                    sRepSql.Append("		WHERE T2.TENPOLC_KBN = T1.TENPOLC_KBN");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");
                    sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
                    sRepSql.Append("	 )");

                    // 移動入荷履歴テーブルの場合
                }
                if (Te070p01Constant.TABLE_ID_MDNT0040.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0041 T2");
                    sRepSql.Append("		WHERE T2.TENPOLC_KBN = T1.TENPOLC_KBN");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");
                    sRepSql.Append("		AND   T2.RIREKI_NO = T1.RIREKI_NO");
                    sRepSql.Append("		AND   T2.AKAKURO_KBN = T1.AKAKURO_KBN");
                    sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
                    sRepSql.Append("	 )");
                }

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_JAN_CD_" + add_where_id;
				bindVO.Value = (string)f01VO.Dictionary[Te070p01Constant.DIC_SEARCH_JANCD];
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

            }

            // オフライン伝票コードを設定

            if (!string.IsNullOrEmpty(f01VO.Offline_no))
            {
                // 移動入荷予定テーブルの場合
                if (Te070p01Constant.TABLE_ID_MDNT0010.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDUT0040 T2");
                    sRepSql.Append("		WHERE T1.TENPOLC_KBN = 0 ");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.OFFLINE_NO = :BIND_OFFLINE_NO_" + add_where_id);
                    sRepSql.Append("	 )");
                //     移動入荷確定テーブルの場合
                }
                else if(Te070p01Constant.TABLE_ID_MDNT0020.Equals(table_id))
                {
                        sRepSql.Append("	AND EXISTS (");
                        sRepSql.Append("		SELECT 1");
                        sRepSql.Append("		FROM MDUT0040 T2");
                        sRepSql.Append("		WHERE  T1.TENPOLC_KBN = 0");
                        sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                        sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                        sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                        sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");
                        sRepSql.Append("		AND   T2.OFFLINE_NO = :BIND_OFFLINE_NO_" + add_where_id);
                        sRepSql.Append("	 )");

                    // 移動入荷履歴テーブルの場合
                    }
                else if (Te070p01Constant.TABLE_ID_MDNT0040.Equals(table_id))
                {
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDUT0040 T2");
                    sRepSql.Append("		WHERE T1.TENPOLC_KBN = 0");
                    sRepSql.Append("		AND   T2.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T2.SYUKKATEN_CD = T1.SYUKKATEN_CD");
                    sRepSql.Append("	    AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
                    sRepSql.Append("		AND   T2.SYUKKA_YMD = T1.SYUKKA_YMD");
                    sRepSql.Append("		AND   T2.OFFLINE_NO = :BIND_OFFLINE_NO_" + add_where_id);
                    sRepSql.Append("	 )");
                }

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_OFFLINE_NO_" + add_where_id;
                bindVO.Value = f01VO.Offline_no;
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }

            // 伝票状態によってSQL、テーブルを変更する
            switch (f01VO.Denpyo_jyotai)
            {
                // 「未処理」の場合:
                case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI2:
                    sRepSql.Append("	AND T1.KAKUTEI_FLG = 0");
                    break;

                // 「「差異あり」の場合
                case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI3:
                    sRepSql.Append("	AND T1.SAI_FLG = 1");
                    break;

                //「取消履歴」の場合
                case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI5:
                    sRepSql.Append("	AND EXISTS (");
                    sRepSql.Append("		SELECT 1");
                    sRepSql.Append("		FROM MDNT0040 T2");
                    sRepSql.Append("		WHERE T1.TENPOLC_KBN = T2.TENPOLC_KBN");
                    sRepSql.Append("		AND   T1.SYUKKAKAISYA_CD = T2.SYUKKAKAISYA_CD");
                    sRepSql.Append("		AND   T1.SYUKKATEN_CD = T2.SYUKKATEN_CD");
                    sRepSql.Append("	    AND   T1.DENPYO_BANGO = T2.DENPYO_BANGO");
                    sRepSql.Append("		AND   T1.SYUKKA_YMD = T2.SYUKKA_YMD");
                    sRepSql.Append("		AND   T2.SYORI_SB = 3");
                    sRepSql.Append("	 )");
                    break;

                // 空白の場合
                case BoSystemConstant.DROPDOWNLIST_MISENTAKU:
                    // 移動入荷予定テーブルテーブルの場合
                    if (Te070p01Constant.TABLE_ID_MDNT0010.Equals(table_id))
                    {
                        sRepSql.Append("	AND T1.KAKUTEI_FLG = 0");
                    }
                    break;

                default:
                    break;
            }

            //ソート条件設定
            // ログイン情報取得
            //LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

            //bindVO = new BindInfoVO();
            //bindVO.BindId = "BIND_LOGINTENPO_CD_" + add_where_id;
            //bindVO.Value = BoSystemFormat.formatKaisyaCd(loginInfVo.CopCd);
            //bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
            //bindList.Add(bindVO);

            BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);

            #endregion
        }

        #endregion
	}
}