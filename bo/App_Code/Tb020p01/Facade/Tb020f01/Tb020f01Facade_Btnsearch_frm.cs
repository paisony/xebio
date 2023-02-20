using com.xebio.bo.Tb020p01.Constant;
using com.xebio.bo.Tb020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V03000.V03001;
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

namespace com.xebio.bo.Tb020p01.Facade
{
  /// <summary>
  /// Tb020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb020f01Facade : StandardBaseFacade
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
				Tb020f01Form f01VO = (Tb020f01Form) facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				//入荷予定小口数の初期化
				f01VO.Nyukayotei_koguti_su = string.Empty;	

				#endregion

                #region 業務チェック
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

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                #endregion

                #region 関連項目チェック

                // 2-1 入荷予定日日FROM、入荷予定日TO
                //       入荷予定日ＦＲＯＭ > 入荷予定日ＴＯの場合エラー
                if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
                {
                    V03001Check.DateFromToChk(
                                    f01VO.Nyukayotei_ymd_from,
                                    f01VO.Nyukayotei_ymd_to,
                                    facadeContext,
                                    "入荷予定日",
                                    new[] { "Nyukayotei_ymd_from", "Nyukayotei_ymd_to" }
                                    );
                }

                // 2-2 仕入確定日FROM、仕入確定日TO
                //       仕入確定日ＦＲＯＭ > 仕入確定日ＴＯの場合エラー
                if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
                {
                    V03001Check.DateFromToChk(
                                    f01VO.Siire_kakutei_ymd_from,
                                    f01VO.Siire_kakutei_ymd_to,
                                    facadeContext,
                                    "仕入確定日",
                                    new[] { "Siire_kakutei_ymd_from", "Siire_kakutei_ymd_to" }
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
                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tb020p01Constant.SQL_ID_01, facadeContext.DBContext);
 
                #region テーブルID設定

                ArrayList bindList = new ArrayList();
                BindInfoVO bindVO = new BindInfoVO();
                StringBuilder sRepSql = new StringBuilder();
                Decimal dCnt = 0;

                // [SCM状態]が"未処理"の場合、SCM予定テーブルから検索
				if (f01VO.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI1))
                {
					// SCM予定TBL(H)
					sRepSql.Append("MDPT0030 T1 ");
					sRepSql.Append("LEFT JOIN ( ");
					sRepSql.Append("	SELECT ");
					sRepSql.Append("		TENPO_CD,SCM_CD,NONYUTYAKUYOTEI_YMD ");
					sRepSql.Append("		,SIIRESAKI_CD,KYAKUTYU_FLG,NEGAKIHIN_FLG ");
					sRepSql.Append("	FROM ");
					sRepSql.Append("		MDPT0031 ");
					sRepSql.Append("	GROUP BY");
					sRepSql.Append("		TENPO_CD,SCM_CD,NONYUTYAKUYOTEI_YMD ");
					sRepSql.Append("		,SIIRESAKI_CD,KYAKUTYU_FLG,NEGAKIHIN_FLG ");
					sRepSql.Append(") T2 ");

                }
                // [SCM状態]が"確定"の場合、SCM確定テーブルから検索
                else
				{
					// SCM確定TBL(H)
					sRepSql.Append("MDPT0040 T1 ");
					sRepSql.Append("LEFT JOIN ( ");
					sRepSql.Append("	SELECT ");
					sRepSql.Append("		TENPO_CD,SCM_CD,NONYUTYAKUYOTEI_YMD ");
					sRepSql.Append("		,SIIRESAKI_CD,KYAKUTYU_FLG,NEGAKIHIN_FLG ");
					sRepSql.Append("	FROM ");
					sRepSql.Append("		MDPT0041");
					sRepSql.Append("	GROUP BY");
					sRepSql.Append("		TENPO_CD,SCM_CD,NONYUTYAKUYOTEI_YMD ");
					sRepSql.Append("		,SIIRESAKI_CD,KYAKUTYU_FLG,NEGAKIHIN_FLG ");
					sRepSql.Append(") T2 ");
                }

                BoSystemSql.AddSql(rtChk, Tb020p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);

                #endregion

                // 検索条件設定
                AddWhere(f01VO, rtChk);

                //検索結果を取得します
                rtChk.CreateDbCommand();
                IList<Hashtable> tableListcnt = rtChk.Execute();

				//ログ出力
                logger.Debug("SQL: " + rtChk.LogSql);

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

				//入荷予定小口数の設定
				f01VO.Nyukayotei_koguti_su = dCnt.ToString();	

                #endregion

                #region 検索処理
				string sSqlId = "";
				// [SCM状態]が"未処理"の場合、SCM予定テーブルから検索
				if (f01VO.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI1))
				{
					sSqlId = Tb020p01Constant.SQL_ID_02;
				}
				// [SCM状態]が"確定"の場合、SCM確定テーブルから検索
				else
				{
					sSqlId = Tb020p01Constant.SQL_ID_03;
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
                    Tb020f01M1Form f01m1VO = new Tb020f01M1Form();

                    f01m1VO.M1rowno                 = iCnt.ToString();	        	            // M1ROWNO(No.)
                    f01m1VO.M1siiresaki_cd          = rec["SIIRESAKI_CD"].ToString();	        // M1SIIRESAKI_CD(仕入先)
                    f01m1VO.M1siiresaki_ryaku_nm    = rec["SIIRESAKI_RYAKU_NM"].ToString();		// M1SIIRESAKI_RYAKU_NM()
                    f01m1VO.M1nyukayotei_ymd        = rec["NONYUTYAKUYOTEI_YMD"].ToString();    // M1NYUKAYOTEI_YMD(入荷予定日)

					// [SCM状態]が"確定"の場合のみ表示
					if (f01VO.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI2))
					{
						f01m1VO.M1siire_kakutei_ymd = rec["ADD_YMD"].ToString();		        // M1SIIRE_KAKUTEI_YMD(仕入確定日)
					}
					else
					{
						f01m1VO.M1siire_kakutei_ymd = string.Empty;
					}
                    
                    f01m1VO.M1gokei_suryo           = rec["SYUKKA_SU"].ToString();		        // M1GOKEI_SURYO(数量)
                    f01m1VO.M1genka_kin             = rec["GENKA_KIN"].ToString();	            // M1GENKA_KIN(原価金額)
                    f01m1VO.M1selectorcheckbox      = BoSystemConstant.CHECKBOX_OFF;		    // Ｍ１選択フラグ(隠し)
                    f01m1VO.M1entersyoriflg         = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１確定処理フラグ(隠し)
					if (f01VO.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI2)
						&& rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;			// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)
					}

                    // Dictionary
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1ROWNUM, iCnt.ToString());								// No.
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1SIIRESAKI_CD, rec["SIIRESAKI_CD"].ToString());				// 仕入先コード
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1SIIRESAKI_RYAKU_NM, rec["SIIRESAKI_RYAKU_NM"].ToString());	// 仕入先名
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1NONYUTYAKUYOTEI_YMD, rec["NONYUTYAKUYOTEI_YMD"].ToString());	// 入荷予定日
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1ADD_YMD, rec["ADD_YMD"].ToString());					// 仕入確定日
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1SCM_CD, rec["SCM_CD"].ToString());					// SCMコード
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1SYUKKA_SU, rec["SYUKKA_SU"].ToString());				// 数量
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1GENKA_KIN, rec["GENKA_KIN"].ToString());				// 原価金額

					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				// 店舗コード
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1KYAKUTYU_FLG, rec["KYAKUTYU_FLG"].ToString());		// Ｍ１客注
					f01m1VO.Dictionary.Add(Tb020p01Constant.DIC_M1NEGAKIHIN_FLG, rec["NEGAKIHIN_FLG"].ToString());		// Ｍ１値書き

                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(f01m1VO, true);
                }

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				//検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

                #endregion
				
				//トランザクションをコミットする。
				// CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				// RollbackTransaction(facadeContext);
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
        private void AddWhere(Tb020f01Form f01VO, FindSqlResultTable reader)
        {
            ArrayList bindList = new ArrayList();
            BindInfoVO bindVO = new BindInfoVO();
            StringBuilder sRepSql = new StringBuilder();

            #region 検索条件設定

            sRepSql = new StringBuilder();


            // 店舗コードを設定
            sRepSql.Append(" AND T2.TENPO_CD = :BIND_TENPO_CD");

            bindVO = new BindInfoVO();
            bindVO.BindId = "BIND_TENPO_CD";
            bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
            bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
            bindList.Add(bindVO);


            // 仕入先コードを設定
            if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
            {
                sRepSql.Append(" AND T2.SIIRESAKI_CD = :BIND_SIIRESAKI_CD");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SIIRESAKI_CD";
                bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }


            // 入荷予定日FROMを設定
            if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from))
            {
				sRepSql.Append(" AND T1.NONYUTYAKUYOTEI_YMD >= :BIND_NYUKA_YMD_FROM");

                bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_NYUKA_YMD_FROM";
                bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }


            // 入荷予定日TOを設定
            if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
            {
				sRepSql.Append(" AND T1.NONYUTYAKUYOTEI_YMD <= :BIND_NYUKA_YMD_TO");

                bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_NYUKA_YMD_TO";
                bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }


            // 仕入確定日FROMを設定
            if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from))
            {
                sRepSql.Append(" AND T1.ADD_YMD >= :BIND_SIIRE_YMD_FROM");

                bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_YMD_FROM";
                bindVO.Value = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }


            // 仕入確定日TOを設定
            if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
            {
				sRepSql.Append(" AND T1.ADD_YMD <= :BIND_SIIRE_YMD_TO");

                bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_YMD_TO";
                bindVO.Value = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }


			// 予定テーブル参照時、確定フラグの条件を設定
			if (f01VO.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI1))
			{
				sRepSql.Append(" AND T1.KAKUTEI_FLG = :BIND_KAKUTEI_FLG");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAKUTEI_FLG";
				bindVO.Value = "0";
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

            BoSystemSql.AddSql(reader, Tb020p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
            #endregion

        }

        #endregion
	}
}
