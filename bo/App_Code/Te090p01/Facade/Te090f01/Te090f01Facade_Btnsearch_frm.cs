using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01027;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
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

namespace com.xebio.bo.Te090p01.Facade
{
  /// <summary>
  /// Te090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te090f01Facade : StandardBaseFacade
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
				Te090f01Form f01VO = (Te090f01Form)facadeContext.FormVO;
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

				// 1-2 会社コード
				// 名称MST（KASY）を検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd
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
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Kaisya_nm = resultHash["MEISYO_NM"].ToString();
					}
				}

				// 1-3 出荷店コード
				// 店舗MST（全企業）を検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01026Check.CheckTenpoAll(f01VO.Kaisya_cd
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
						f01VO.Syukkaten_nm = resultHash["TENPO_NM"].ToString();
					}
				}

				// SCMコード
				if (!string.IsNullOrEmpty(f01VO.Scm_cd))
				{
					// SCMコードフォーマット
					f01VO.Scm_cd = BoSystemFormat.formatScmCd(f01VO.Scm_cd);

					if (!ScmCodeCls.CheckLength(f01VO.Scm_cd))
					{
						// 1-4 SCMコード
						// 入力桁数が14桁でない、かつ20桁でない場合、エラー
						ErrMsgCls.AddErrMsg("E223", string.Empty, facadeContext, new[] { "Scm_cd" });
					}
					else if (!ScmCodeCls.CheckFormat(f01VO.Scm_cd))
					{
						// 1-5 SCMコード
						// 先頭2バイトが[00][01][02][03][04]以外はエラー
						ErrMsgCls.AddErrMsg("E209", string.Empty, facadeContext, new[] { "Scm_cd" });
					}
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック
				// 2-1 伝票番号ＦＲＯＭ、伝票番号ＴＯ 
				// 伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from)
					&& !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
						f01VO.Denpyo_bango_from,
						f01VO.Denpyo_bango_to,
						facadeContext,
						"伝票番号",
						new[] { "Denpyo_bango_from", "Denpyo_bango_to" }
						);
				}

				// 2-2 出荷日号ＦＲＯＭ、出荷日ＴＯ 
				// 出荷日ＦＲＯＭ > 出荷日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from)
					&& !string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
				{
					V03001Check.DateFromToChk(
						f01VO.Syukka_ymd_from,
						f01VO.Syukka_ymd_to,
						facadeContext,
						"出荷日",
						new[] { "Syukka_ymd_from", "Syukka_ymd_to" }
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
				string cntSqlId = string.Empty;
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
				{
					// 入荷確定モードの場合
					cntSqlId = Te090p01Constant.SQL_ID_01;
				}
				else
				{
					// 入荷確定モード以外の場合
					cntSqlId = Te090p01Constant.SQL_ID_03;
				}

				// SQL実行部品生成
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(cntSqlId, facadeContext.DBContext);

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
				string selSqlId = string.Empty;
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
				{
					// 入荷確定モードの場合
					selSqlId = Te090p01Constant.SQL_ID_02;
				}
				else
				{
					// 入荷確定モード以外の場合
					selSqlId = Te090p01Constant.SQL_ID_04;
				}

				// SQL実行部品生成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(selSqlId, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtSeach);

				// 検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Te090f01M1Form f01m1VO = new Te090f01M1Form();

					// Ｍ１行Ｎｏ
					f01m1VO.M1rowno = iCnt.ToString();
					// Ｍ１会社カナ名
					if (BoSystemFormat.formatKaisyaCd(rec["SYUKKAKAISYA_CD"].ToString()).Equals(BoSystemFormat.formatKaisyaCd(logininfo.CopCd)))
					{
						// 取得した出荷会社コード＝ログイン情報.会社コードの場合
						f01m1VO.M1kaisyakana_nm = string.Empty;
					}
					else
					{
						f01m1VO.M1kaisyakana_nm = rec["SYUKKAKAISYA_KANA_NM"].ToString();
					}
					// Ｍ１出荷店コード
					f01m1VO.M1syukkaten_cd = BoSystemFormat.formatTenpoCd(rec["SYUKKATEN_CD"].ToString());
					// Ｍ１出荷店名称
					f01m1VO.M1syukkaten_nm = rec["TENPO_NM"].ToString();
					// Ｍ１SCMコード
					f01m1VO.M1scm_cd = BoSystemFormat.formatViewScmCd(rec["SCM_CD"].ToString());
					// Ｍ１伝票番号リンク
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO] = BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString());
					// Ｍ１出荷日
					f01m1VO.M1syukka_ymd = rec["SYUKKA_YMD"].ToString();
					// Ｍ１入荷日
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
					{
						// 入荷確定モードの場合
						f01m1VO.M1jyuryo_ymd = string.Empty;
					}
					else
					{
						// 入荷確定モード以外の場合
						f01m1VO.M1jyuryo_ymd = rec["JYURYO_YMD"].ToString();
					}
					// Ｍ１予定数量
					f01m1VO.M1yotei_su = rec["NYUKAYOTEIGOUKEI_SU"].ToString();
					// Ｍ１確定数量
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
					{
						// 入荷確定モードの場合
						f01m1VO.M1kakutei_su = string.Empty;
					}
					else
					{
						// 入荷確定モード以外の場合
						f01m1VO.M1kakutei_su = rec["NYUKAJISSEKIGOUKEI_SU"].ToString();
					}
					// Ｍ１客注
					f01m1VO.M1kyakucyu = rec["KYAKUCHU"].ToString();
					// Ｍ１値書
					f01m1VO.M1negaki = rec["NEGAKI"].ToString();
					// Ｍ１伝票状態名称
					f01m1VO.M1denpyo_jyotainm = rec["IDST_NM"].ToString();
					// Ｍ１選択フラグ(隠し)
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI)
						&& rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						// 入荷確定モード以外、かつ送信済の場合
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;
					}
					else
					{
						// それ以外の場合
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}

					// Ｍ１店舗ＬＣ区分
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN] = rec["TENPOLC_KBN"].ToString();
					// Ｍ１会社コード
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD] = BoSystemFormat.formatKaisyaCd(rec["SYUKKAKAISYA_CD"].ToString());
					// Ｍ１会社名称
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_NM] = rec["SYUKKAKAISYA_NM"].ToString();
					// Ｍ１出荷担当者コード
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1SYUKKATAN_CD] = BoSystemFormat.formatTantoCd(rec["SYUKKATAN_CD"].ToString());
					// Ｍ１出荷担当者名称
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1SYUKKATAN_NM] = rec["SYUKKATAN_NM"].ToString();
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
					{
						// 入荷確定モードの場合
						// Ｍ１入荷担当者コード
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_CD] = string.Empty;
						// Ｍ１入荷担当者名称
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_NM] = string.Empty;
					}
					else
					{
						// 入荷確定モード以外の場合
						// Ｍ１入荷担当者コード
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_CD] = BoSystemFormat.formatTantoCd(rec["NYUKATAN_CD"].ToString());
						// Ｍ１入荷担当者名称
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_NM] = rec["NYUKATAN_NM"].ToString();
					}
					// Ｍ１更新日（予定）
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_YOTEI] = rec["UPD_YMD_YOTEI"].ToString();
					// Ｍ１更新時間（予定）
					f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_YOTEI] = rec["UPD_TM_YOTEI"].ToString();
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
					{
						// 入荷確定モードの場合
						// Ｍ１更新日（確定）
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_KAKUTEI] = string.Empty;
						// Ｍ１更新時間（確定）
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_KAKUTEI] = string.Empty;
					}
					else
					{
						// 入荷確定モード以外の場合
						// Ｍ１更新日（確定）
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_KAKUTEI] = rec["UPD_YMD_KAKUTEI"].ToString();
						// Ｍ１更新時間（確定）
						f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_KAKUTEI] = rec["UPD_TM_KAKUTEI"].ToString();
					}

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
		/// <param name="f01VO">Te090f01Form</param>
		/// <param name="stmt">SQL実行部品</param>
		private void AddWhere(Te090f01Form f01VO, FindSqlResultTable stmt)
		{
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();
			BindInfoVO bindVO = null;

			#region 検索条件設定

			// 検索条件を設定 -----------

			// バインド変数
			// 入荷店コード
			stmt.BindValue("BIND_JYURYOTEN_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

			// リプレイス変数
			sRepSql = new StringBuilder();

			#region 出荷会社コード
			if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
			{
				sRepSql.Append(" AND T1.SYUKKAKAISYA_CD = :SYUKKAKAISYA_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "SYUKKAKAISYA_CD";
				bindVO.Value = Convert.ToDecimal(f01VO.Kaisya_cd).ToString();
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 出荷店コード
			if (!string.IsNullOrEmpty(f01VO.Syukkaten_cd))
			{
				sRepSql.Append(" AND T1.SYUKKATEN_CD = :SYUKKATEN_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "SYUKKATEN_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Syukkaten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;
				bindList.Add(bindVO);
			}
			#endregion

			#region 伝票番号ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO >= :DENPYO_BANGO_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "DENPYO_BANGO_FROM";
				bindVO.Value = f01VO.Denpyo_bango_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 伝票番号ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO <= :DENPYO_BANGO_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "DENPYO_BANGO_TO";
				bindVO.Value = f01VO.Denpyo_bango_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region SCMコード
			if (!string.IsNullOrEmpty(f01VO.Scm_cd))
			{
				sRepSql.Append(" AND T1.SCM_CD = :SCM_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "SCM_CD";
				bindVO.Value = BoSystemFormat.formatScmCd(f01VO.Scm_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;
				bindList.Add(bindVO);
			}
			#endregion

			#region 出荷日ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from))
			{
				sRepSql.Append(" AND T1.SYUKKA_YMD >= :SYUKKA_YMD_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "SYUKKA_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 出荷日ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
			{
				sRepSql.Append(" AND T1.SYUKKA_YMD <= :SYUKKA_YMD_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "SYUKKA_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}
			#endregion

			#region 確定後修正、確定後取消
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD)		// 確定後修正モード
				|| f01VO.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL)	// 確定後取消モード
				)
			{
				// [モードNO]が「確定後修正」、「確定後取消」の場合
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = 0 ");
			}
			#endregion

			BoSystemSql.AddSql(stmt, Te090p01Constant.SQL_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion
		}
		#endregion
	}
}
