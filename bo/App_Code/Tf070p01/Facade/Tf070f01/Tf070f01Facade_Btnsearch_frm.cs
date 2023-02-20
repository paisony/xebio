using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
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

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f01Facade : StandardBaseFacade
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

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// 画面情報取得
				Tf070f01Form f01VO = (Tf070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 保持していた検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				#endregion

				#region 業務チェック

				#region 単項目チェック
				// 1-1 ヘッダ店舗コード
				// 店舗MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = resultHash["TENPO_NM"].ToString();
					}
				}

				// 1-2 報告担当者コード
				// 担当者MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hokokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Hokokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "報告者"
														, new[] { "Hokokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hokokutan_nm = resultHash["HANBAIIN_NM"].ToString();
					}
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック
				// 2-1 盗難品管理番号ＦＲＯＭ、盗難品管理番号ＴＯ 
				// 盗難品管理番号ＦＲＯＭ > 盗難品管理番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tonanhinkanri_no_from)
					&& !string.IsNullOrEmpty(f01VO.Tonanhinkanri_no_to))
				{
					V03002Check.CodeFromToChk(
						f01VO.Tonanhinkanri_no_from,
						f01VO.Tonanhinkanri_no_to,
						facadeContext,
						"管理番号",
						new[] { "Tonanhinkanri_no_from", "Tonanhinkanri_no_to" }
						);
				}

				// 2-2 事故発生日ＦＲＯＭ、事故発生日ＴＯ 
				// 事故発生日ＦＲＯＭ > 事故発生日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Jikohassei_ymd_from)
					&& !string.IsNullOrEmpty(f01VO.Jikohassei_ymd_to))
				{
					V03001Check.DateFromToChk(
						f01VO.Jikohassei_ymd_from,
						f01VO.Jikohassei_ymd_to,
						facadeContext,
						"事故発生日",
						new[] { "Jikohassei_ymd_from", "Jikohassei_ymd_to" }
						);
				}

				// 2-3 報告日ＦＲＯＭ、報告日ＴＯ 
				// 報告日ＦＲＯＭ > 報告日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hokoku_ymd_from)
					&& !string.IsNullOrEmpty(f01VO.Hokoku_ymd_to))
				{
					V03001Check.DateFromToChk(
						f01VO.Hokoku_ymd_from,
						f01VO.Hokoku_ymd_to,
						facadeContext,
						"報告日",
						new[] { "Hokoku_ymd_from", "Hokoku_ymd_to" }
						);
				}

				// 2-4 警察届出日ＦＲＯＭ、警察届出日ＴＯ 
				// 警察届出日ＦＲＯＭ > 警察届出日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Keisatsutodoke_ymd_from)
					&& !string.IsNullOrEmpty(f01VO.Keisatsutodoke_ymd_to))
				{
					V03001Check.DateFromToChk(
						f01VO.Keisatsutodoke_ymd_from,
						f01VO.Keisatsutodoke_ymd_to,
						facadeContext,
						"警察届出日",
						new[] { "Keisatsutodoke_ymd_from", "Keisatsutodoke_ymd_to" }
						);
				}

				// 2-5 受理番号ＦＲＯＭ、受理番号ＴＯ 
				// 受理番号ＦＲＯＭ > 受理番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Jyuri_no_from)
					&& !string.IsNullOrEmpty(f01VO.Jyuri_no_to))
				{
					V03002Check.CodeFromToChk(
						f01VO.Jyuri_no_from.PadLeft(10, '0'),	// ０埋めして比較
						f01VO.Jyuri_no_to.PadLeft(10, '0'),		// ０埋めして比較
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
				// SQL実行部品生成
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtChk);

				// 検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					decimal dCnt = (Decimal)resultTbl["CNT"];

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
				// SQL実行部品生成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_02, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtSeach);

				// 検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tf070f01M1Form f01m1VO = new Tf070f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行No
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1KANRI_NO, BoSystemString.AllZeroToEmpty(BoSystemFormat.formatDenpyoNo(rec["KANRI_NO"].ToString())));	// Ｍ１管理番号
					f01m1VO.M1jikohassei_ymd = BoSystemString.ZeroToEmpty(rec["JIKOHASSEI_YMD"].ToString());			// Ｍ１事故発生日
					f01m1VO.M1hokoku_ymd = BoSystemString.ZeroToEmpty(rec["HOKOKU_YMD"].ToString());					// Ｍ１報告日
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1HOKOKUTAN_CD, rec["HOKOKUTAN_CD"].ToString());		// Ｍ１報告担当者コード
					f01m1VO.M1hokokutan_nm = rec["HOKOKUTAN_NM"].ToString();											// Ｍ１報告担当者名称
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1TENTYOTAN_CD, rec["TENTYOTAN_CD"].ToString());		// Ｍ１店長担当者コード
					f01m1VO.M1tentyotan_nm = rec["TENTYOTAN_NM"].ToString();											// Ｍ１店長担当者名称
					f01m1VO.M1keisatsutodoke_ymd = BoSystemString.ZeroToEmpty(rec["KEISATSUTODOKE_YMD"].ToString());	// Ｍ１警察届出日
					f01m1VO.M1todokedesakikeisatsu_nm = rec["TODOKEDESAKIKEISATSU_NM"].ToString();						// Ｍ１届先警察署名
					f01m1VO.M1jyuri_no = rec["JYURI_NO"].ToString();													// Ｍ１受理番号

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)

					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());							// 更新日付
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());							// 更新時間
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());						// 処理日付
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());						// 処理時間
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1KEIHISINSEI_FLG, rec["KEIHISINSEI_FLG"].ToString());			// 経費申請フラグ
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1KEIHISINSEI_YMD, rec["KEIHISINSEI_YMD"].ToString());			// 経費申請日
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1KEIHISINSEI_UPD_YMD, rec["KEIHISINSEI_UPD_YMD"].ToString());	// 経費申請更新日
					f01m1VO.Dictionary.Add(Tf070p01Constant.DIC_M1KEIHISINSEI_UPD_TM, rec["KEIHISINSEI_UPD_TM"].ToString());	// 経費申請更新時間

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
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				//トランザクションをコミットする。
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
		/// <param name="f01VO">Tf070f01Form</param>
		/// <param name="stmt">SQL実行部品</param>
		private void AddWhere(Tf070f01Form f01VO, FindSqlResultTable stmt)
		{
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();
			BindInfoVO bindVO = null;

			#region 検索条件設定

			// 検索条件を設定 -----------

			// バインド変数
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

			// リプレイス変数
			sRepSql = new StringBuilder();

			#region 盗難品管理番号ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Tonanhinkanri_no_from))
			{
				sRepSql.Append(" AND T1.KANRI_NO >= :KANRI_NO_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "KANRI_NO_FROM";
				bindVO.Value = f01VO.Tonanhinkanri_no_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 盗難品管理番号ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Tonanhinkanri_no_to))
			{
				sRepSql.Append(" AND T1.KANRI_NO <= :KANRI_NO_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "KANRI_NO_TO";
				bindVO.Value = f01VO.Tonanhinkanri_no_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 事故発生日ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Jikohassei_ymd_from))
			{
				sRepSql.Append(" AND T1.JIKOHASSEI_YMD >= :JIKOHASSEI_YMD_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "JIKOHASSEI_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Jikohassei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 事故発生日ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Jikohassei_ymd_to))
			{
				sRepSql.Append(" AND T1.JIKOHASSEI_YMD <= :JIKOHASSEI_YMD_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "JIKOHASSEI_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Jikohassei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 報告日ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Hokoku_ymd_from))
			{
				sRepSql.Append(" AND T1.HOKOKU_YMD >= :HOKOKU_YMD_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "HOKOKU_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hokoku_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 報告日ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Hokoku_ymd_to))
			{
				sRepSql.Append(" AND T1.HOKOKU_YMD <= :HOKOKU_YMD_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "HOKOKU_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hokoku_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 報告担当者コード
			if (!string.IsNullOrEmpty(f01VO.Hokokutan_cd))
			{
				sRepSql.Append(" AND T1.HOKOKUTAN_CD = :HOKOKUTAN_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "HOKOKUTAN_CD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Hokokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;
				bindList.Add(bindVO);
			}
			#endregion

			#region 警察届出日ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Keisatsutodoke_ymd_from))
			{
				sRepSql.Append(" AND T1.KEISATSUTODOKE_YMD >= :KEISATSUTODOKE_YMD_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "KEISATSUTODOKE_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Keisatsutodoke_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 警察届出日ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Keisatsutodoke_ymd_to))
			{
				sRepSql.Append(" AND T1.KEISATSUTODOKE_YMD <= :KEISATSUTODOKE_YMD_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "KEISATSUTODOKE_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Keisatsutodoke_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 受理番号ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Jyuri_no_from))
			{
				sRepSql.Append(" AND T1.JYURI_NO >= :JYURI_NO_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "JYURI_NO_FROM";
				bindVO.Value = f01VO.Jyuri_no_from;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;
				bindList.Add(bindVO);
			}
			#endregion

			#region 受理番号ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Jyuri_no_to))
			{
				sRepSql.Append(" AND T1.JYURI_NO <= :JYURI_NO_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "JYURI_NO_TO";
				bindVO.Value = f01VO.Jyuri_no_to;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;
				bindList.Add(bindVO);
			}
			#endregion

			#region 受理番号が登録されるまで
			if	(
					(
						f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD)			// 修正モード
					||	f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL)			// 取消モード
					)
				&&	!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo())	// 店舗
				)
			{
				// （[モードNO]が「修正」、または「取消」）、かつ本部以外の場合
				sRepSql.Append(" AND T1.JYURI_NO IS NULL ");
			}
			#endregion

			#region 経費申請、修正、取消
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)	// 経費申請モード
				||f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD)		// 修正モード
				|| f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL)		// 取消モード
				)
			{
				// [モードNO]が「経費申請」、「修正」、「取消」の場合
				sRepSql.Append(" AND T1.KEIHISINSEI_FLG = 0 ");

				sRepSql.Append(" AND NOT EXISTS ( ");
				sRepSql.Append("         SELECT  1 ");
				sRepSql.Append("         FROM    MDAT0020 ST1 ");	// 経費振替申請TBL(H)
				sRepSql.Append("         WHERE   ST1.TONANHINKANRI_NO    = T1.KANRI_NO ");
				sRepSql.Append("         AND     ST1.TONANHINSYORI_YMD   = T1.SYORI_YMD ");
				sRepSql.Append("         AND     ST1.TONANHINTENPO_CD    = T1.TENPO_CD ");
				sRepSql.Append("         AND     ST1.KESSAI_FLG          = 0 ");
				sRepSql.Append("     ) ");
			}
			#endregion

			#region 申請済取消
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEITORIKESI)	// 申請済取消モード
				)
			{
				// [モードNO]が「申請済取消」の場合
				sRepSql.Append(" AND T1.KEIHISINSEI_FLG = 1 ");

				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append("         SELECT  1 ");
				sRepSql.Append("         FROM    MDAT0020 ST1 ");	// 経費振替申請TBL(H)
				sRepSql.Append("         WHERE   ST1.TONANHINKANRI_NO    = T1.KANRI_NO ");
				sRepSql.Append("         AND     ST1.TONANHINSYORI_YMD   = T1.SYORI_YMD ");
				sRepSql.Append("         AND     ST1.TONANHINTENPO_CD    = T1.TENPO_CD ");
				sRepSql.Append("         AND     ST1.KESSAI_FLG          = 0 ");
				sRepSql.Append("     ) ");
			}
			#endregion

			BoSystemSql.AddSql(stmt, Tf070p01Constant.SQL_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion
		}
		#endregion
	}
}
