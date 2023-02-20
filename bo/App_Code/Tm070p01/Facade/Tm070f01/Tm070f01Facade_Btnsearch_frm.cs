using com.xebio.bo.Tm070p01.Constant;
using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
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

namespace com.xebio.bo.Tm070p01.Facade
{
  /// <summary>
  /// Tm070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm070f01Facade : StandardBaseFacade
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
				Tm070f01Form f01VO = (Tm070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				// 選択モードNoを初期化
				f01VO.Stkmodeno = string.Empty;

				#endregion

				#region 業務チェック

				#region マスタ存在チェック
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

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック
				// 2-1 変更日FROM、変更日TO
				//       変更日ＦＲＯＭ > 変更日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Henko_ymd_from) && !string.IsNullOrEmpty(f01VO.Henko_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Henko_ymd_from,
									f01VO.Henko_ymd_to,
									facadeContext,
									"変更日",
									new[] { "Henko_ymd_from", "Henko_ymd_to" }
									);
				}

				// 2-2 元店舗コードFROM、元店舗コードTO
				//       元店舗コードＦＲＯＭ > 元店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Moto_tenpo_cd_from,
									f01VO.Moto_tenpo_cd_to,
									facadeContext,
									"元店舗コード",
									new[] { "Moto_tenpo_cd_from", "Moto_tenpo_cd_to" }
									);
				}

				// 2-3 担当者コードFROM、担当者コードTO
				//       担当者コードＦＲＯＭ > 担当者コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tan_cd_from) && !string.IsNullOrEmpty(f01VO.Tan_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tan_cd_from,
									f01VO.Tan_cd_to,
									facadeContext,
									"担当者コード",
									new[] { "Tan_cd_from", "Tan_cd_to" }
									);
				}

				// 元店舗コードFrom(名称取得、チェックは行わない)
				//       店舗マスタを検索し、名前を設定する。
				f01VO.Moto_tenpo_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Moto_tenpo_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Moto_tenpo_nm_from = (string)resultHash["TENPO_NM"];
					}
				}

				// 元店舗コードTo(名称取得、チェックは行わない)
				//       店舗マスタを検索し、名前を設定する。
				f01VO.Moto_tenpo_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Moto_tenpo_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Moto_tenpo_nm_to = (string)resultHash["TENPO_NM"];
					}
				}

				// 担当者コードFrom(名称取得、チェックは行わない)
				//       担当者マスタを検索し、名前を設定する。
				f01VO.Tan_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tan_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Tan_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tan_nm_from = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 担当者コードFrom(名称取得、チェックは行わない)
				//       担当者マスタを検索し、名前を設定する。
				f01VO.Tan_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tan_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Tan_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tan_nm_to = (string)resultHash["HANBAIIN_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtChk, Tm070p01Constant.REP_ADD_WHERE1);

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

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_02, facadeContext.DBContext);

				// システム日付のバインド
				rtSeach.BindValue("BIND_SYSDATE", sysDateVO.Sysdate);

				// 検索条件設定
				AddWhere(f01VO, rtSeach, Tm070p01Constant.REP_ADD_WHERE1);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				int iCnt = 0;

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tm070f01M1Form f01m1VO = new Tm070f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();															// Ｍ１行NO
					f01m1VO.M1tan_cd = rec["HANBAIIN_CD"].ToString();											// Ｍ１担当者コード
					f01m1VO.M1tan_nm = rec["HANBAIIN_NM"].ToString();											// Ｍ１担当者名
					f01m1VO.M1moto_tenpo_cd = rec["MOTO_TENPO_CD"].ToString();									// Ｍ１元店舗コード
					f01m1VO.M1moto_tenpo_nm = rec["MOTO_TENPO_NM"].ToString();									// Ｍ１元店舗名
					f01m1VO.M1henko_tenpo_cd = rec["HENKO_TENPO_CD"].ToString();								// Ｍ１変更店舗コード
					f01m1VO.M1henko_tenpo_nm = rec["HENKO_TENPO_NM"].ToString();								// Ｍ１変更店舗名
					f01m1VO.M1henko_ymd = rec["HENKO_YMD"].ToString();											// Ｍ１変更日
					f01m1VO.M1henko_tm = rec["HENKO_TM"].ToString();											// Ｍ１変更時間
					f01m1VO.M1henko_tm = BoSystemFormat.formatTime(Convert.ToDecimal(f01m1VO.M1henko_tm), 1);

					f01m1VO.M1upd_ymd = rec["UPD_YMD"].ToString();												// Ｍ１更新日
					f01m1VO.M1upd_tm = rec["UPD_TM"].ToString();												// Ｍ１更新時間
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;									// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;								// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;									// Ｍ１明細色区分(隠し)

					// Dictionary
					// 初期化フラグ
					// 初期化可能にする条件
					// ・変更日が当日
					// ・最新のデータ
					// ・担当者マスタのSAKUJYO_FLGが0
					// ・変更店舗と販売員店舗が違う
					if (rec["HENKO_YMD"].ToString().Equals(sysDateVO.Sysdate.ToString())
						&& rec["HENKO_TM"].ToString().Equals(rec["MAX_HENKO_TM"].ToString())
						&& rec["SAKUJYO_FLG"].ToString().Equals("0")
						&& !rec["HENKO_TENPO_CD"].ToString().Equals(rec["HANBAIINTENPO_CD"].ToString()))
					{
						f01m1VO.Dictionary.Add(Tm070p01Constant.DIC_M1SHOKIKA_FLG, Tm070p01Constant.VALUE_SHOKIKA_ON);		
					}
					else
					{
						f01m1VO.Dictionary.Add(Tm070p01Constant.DIC_M1SHOKIKA_FLG, Tm070p01Constant.VALUE_SHOKIKA_OFF);
					}

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 選択モードNoを「照会」に設定
				f01VO.Stkmodeno = BoSystemConstant.MODE_REF;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
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
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tm070f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="string">add_where_id</param>
		/// <returns></returns>
		private void AddWhere(Tm070f01Form f01VO, FindSqlResultTable reader, string add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 店舗コードを設定
			sRepSql.Append(" AND T1.HENKO_TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 変更日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Henko_ymd_from))
			{
				sRepSql.Append(" AND T1.HENKO_YMD >= :BIND_HENKO_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENKO_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henko_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 変更日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Henko_ymd_to))
			{
				sRepSql.Append(" AND T1.HENKO_YMD <= :BIND_HENKO_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENKO_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henko_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 元店舗FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_from))
			{
				sRepSql.Append(" AND T1.MOTO_TENPO_CD >= :BIND_MOTO_TENPO_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_MOTO_TENPO_CD_FROM";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Moto_tenpo_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 元店舗TOを設定
			if (!string.IsNullOrEmpty(f01VO.Moto_tenpo_cd_to))
			{
				sRepSql.Append(" AND T1.MOTO_TENPO_CD <= :BIND_MOTO_TENPO_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_MOTO_TENPO_CD_TO";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Moto_tenpo_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 担当者FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Tan_cd_from))
			{
				sRepSql.Append(" AND T1.HANBAIIN_CD >= :BIND_HANBAIIN_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HANBAIIN_CD_FROM";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tan_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 担当者TOを設定
			if (!string.IsNullOrEmpty(f01VO.Tan_cd_to))
			{
				sRepSql.Append(" AND T1.HANBAIIN_CD <= :BIND_HANBAIIN_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HANBAIIN_CD_TO";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tan_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);
			#endregion

		}
		#endregion
	}
}
