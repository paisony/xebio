using com.xebio.bo.Ta040p01.Constant;
using com.xebio.bo.Ta040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
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

namespace com.xebio.bo.Ta040p01.Facade
{
  /// <summary>
  /// Ta040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta040f01Facade : StandardBaseFacade
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
                ////コネクションを取得して、トランザクションを開始する。
                //BeginTransactionWithConnect(facadeContext);
                //コネクションを取得する。
                OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。

                #region 初期化

                // ログイン情報取得

                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Ta040f01Form f04VO = (Ta040f01Form)facadeContext.FormVO;
                IDataList m1List = f04VO.GetList("M1");

                // 一覧の初期化
                m1List.ClearCacheData();
                m1List.Clear();
                
                #endregion

                #region 業務チェック

                #region 単項目チェック
                // 1-1 ヘッダ店舗コード
                //       店舗マスタを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(f04VO.Head_tenpo_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01001Check.CheckTenpo(f04VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
                    if (resultHash != null)
                    {
                        f04VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 関連項目チェック
                
                // 部門コードFrom(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f04VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f04VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f04VO.Bumon_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f04VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門コードTo(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f04VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f04VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f04VO.Bumon_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f04VO.Bumon_nm_to = (string)resultHash["BUMON_NM"];
					}
				}
                //2-1 部門コードFROM、部門TO
                //      部門コードFROM > 部門コードＴＯの場合エラー
                if (!string.IsNullOrEmpty(f04VO.Bumon_cd_from) && !string.IsNullOrEmpty(f04VO.Bumon_cd_to))
                {
                    V03002Check.CodeFromToChk(
                        f04VO.Bumon_cd_from,
                        f04VO.Bumon_cd_to,
                        facadeContext,
                        "部門",
                        new[] { "Bumon_cd_from", "Bumon_cd_to" }
                 );
                }
                

                //2-2 決裁日FROM、決裁日TO
                //      決裁日FROM >決裁日の場合エラー
                if (!string.IsNullOrEmpty(f04VO.Kessai_ymd_from) && !string.IsNullOrEmpty(f04VO.Kessai_ymd_to))
                {
                    V03001Check.DateFromToChk(
                        f04VO.Kessai_ymd_from,
                        f04VO.Kessai_ymd_to,
                        facadeContext,
                        "決裁日",
                        new[] { "Kessai_ymd_from", "Kessai_ymd_to" }
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

                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Ta040p01Constant.SQL_ID_01, facadeContext.DBContext);

                #region SQL設定

                StringBuilder sRepSql = new StringBuilder();
                Decimal dCnt = 0;

                #endregion

                BoSystemLog.logOut("[補充依頼結果TBL(H)]件数を検索 START");

                // 検索条件設定
                AddWhere(f04VO, rtChk);

                BoSystemLog.logOut("[補充依頼結果TBL(H)件数]を検索 END");

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

                // 検索件数の設定
                f04VO.Searchcnt = dCnt.ToString();

                #endregion

                #region 検索処理

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Ta040p01Constant.SQL_ID_02, facadeContext.DBContext);

                BoSystemLog.logOut("[補充依頼結果TBL(H)]を検索 START");
                // 検索条件設定
                AddWhere(f04VO, rtSeach);
                BoSystemLog.logOut("[補充依頼結果TBL(H)]を検索 END");

                //検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

                int iCnt = 0;
                foreach (Hashtable rec in tableList)
                {
                    iCnt++;
                    Ta040f01M1Form f04m1VO = new Ta040f01M1Form();

                    f04m1VO.M1rowno = iCnt.ToString();                          // Ｍ１行NO
                    f04m1VO.M1henko_kbn_nm = rec["MEISYO_NM"].ToString();	    // Ｍ１変更区分
                    f04m1VO.M1hattyu_su = rec["IRAI_SU"].ToString();	        // Ｍ１発注数
                    f04m1VO.M1haibun_su　= rec["HAIBUN_SU"].ToString();       	// Ｍ１配分数
                    f04m1VO.M1genkakin = rec["HAIBUN_KIN"].ToString();	        // Ｍ１原価金
                    f04m1VO.M1kessai_ymd = rec["KESSAI_YMD"].ToString();	    // Ｍ１決裁日
                    f04m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;	
                                                                                // Ｍ１選択フラグ(隠し)
                    f04m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	
                                                                                // Ｍ１確定処理フラグ(隠し)
                    f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
                                                                                // Ｍ１明細色区分(隠し)
                    
                    // Dictionary
                    f04m1VO.Dictionary.Add(Ta040p01Constant.DIC_M1HENKO_KBN, rec["HENKO_KBN"].ToString());		    // 変更区分
                    f04m1VO.Dictionary.Add(Ta040p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());            // 部門コード
                    f04m1VO.Dictionary.Add(Ta040p01Constant.DIC_M1BUMONKANA_NM, rec["BUMONKANA_NM"].ToString());    // 部門カナ名                    
                    f04m1VO.Dictionary.Add(Ta040p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());            // 部門名                    

                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(f04m1VO, true);
                }
				// 検索件数の設定
                f04VO.Searchcnt = m1List.Count.ToString();

                // 検索条件を退避
                SearchConditionSaveCls.SearchConditionSave(f04VO);

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
        /// <param name="f04VO">Ta040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
        private void AddWhere(Ta040f01Form f04VO, FindSqlResultTable reader)
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
            bindVO.Value = BoSystemFormat.formatTenpoCd(f04VO.Head_tenpo_cd);
            bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
            bindList.Add(bindVO);

            // 決裁日FROMを設定
            if (!string.IsNullOrEmpty(f04VO.Kessai_ymd_from))
            {
                sRepSql.Append(" AND T1.KESSAI_YMD >= :BIND_KESSAI_YMD_FROM");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_KESSAI_YMD_FROM";
                bindVO.Value = BoSystemFormat.formatDate(f04VO.Kessai_ymd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }
            // 決裁日TOを設定

            if (!string.IsNullOrEmpty(f04VO.Kessai_ymd_to))
            {
                sRepSql.Append(" AND T1.KESSAI_YMD <= :BIND_KESSAI_YMD_TO");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_KESSAI_YMD_TO";
                bindVO.Value = BoSystemFormat.formatDate(f04VO.Kessai_ymd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }
            
            // 変更区分を設定
            if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f04VO.Henko_kbn))
            {
                sRepSql.Append(" AND T1.HENKO_KBN = :BIND_HENKO_KBN");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_HENKO_KBN";
                bindVO.Value = f04VO.Henko_kbn;
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }

            // 部門FROMを設定
            if (!string.IsNullOrEmpty(f04VO.Bumon_cd_from))
            {
                sRepSql.Append(" AND T1.BUMON_CD >= :BIND_BUMON_CD_FROM");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_BUMON_CD_FROM";
                bindVO.Value = BoSystemFormat.formatBumonCd(f04VO.Bumon_cd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }

            // 部門TOを設定
            if (!string.IsNullOrEmpty(f04VO.Bumon_cd_to))
            {
                sRepSql.Append(" AND T1.BUMON_CD <= :BIND_BUMON_CD_TO");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_BUMON_CD_TO";
                bindVO.Value = BoSystemFormat.formatBumonCd(f04VO.Bumon_cd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);
            }

            BoSystemSql.AddSql(reader, Ta040p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
            #endregion
        }

        #endregion
    }
}
