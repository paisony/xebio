using com.xebio.bo.Ti040p01.Constant;
using com.xebio.bo.Ti040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Advanced.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.V01000.V01001;
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

namespace com.xebio.bo.Ti040p01.Facade
{
  /// <summary>
  /// Ti040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ti040f01Facade : StandardBaseFacade
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

                // ログイン情報取得
                LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Ti040f01Form formVO = (Ti040f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 初期化

                // ディクショナリのクリア
                formVO.Dictionary.Clear();

                // 一覧の初期化
                m1List.ClearCacheData();
                m1List.Clear();

                #endregion

                #region 業務チェック

                #region 1. 単項目チェック

                // 1-1 ヘッダ店舗コード
                //       店舗MSTを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(formVO.Head_tenpo_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01001Check.CheckTenpo(formVO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
                    // 名称をラベルに設定
                    if (resultHash != null)
                    {
                        formVO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
                    }
                }


                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 2. 単項目チェック

                // 2-1 ラベル発行機ＩＤＦＲＯＭ、ラベル発行機ＩＤＦＲＯＭ2 
                //       結合した桁数が7桁以外の場合エラー
                if (!string.IsNullOrEmpty(formVO.Label_cd_from) ||
                    !string.IsNullOrEmpty(formVO.Label_cd_from2))
                {
                    if ((formVO.Label_cd_from.Length + formVO.Label_cd_from2.Length) != Ti040p01Constant.LEN_LABEL_CD)
                    {
                        ErrMsgCls.AddErrMsg("E107", new[] { "ラベル発行機ID（FROM）", "7" }, facadeContext, new[] { "Label_cd_from", "Label_cd_from2" });
                    }
                }

                // 2-2 ラベル発行機ＩＤＴＯ、ラベル発行機ＩＤＴＯ2 
                //       結合した桁数が7桁以外の場合エラー
                if (!string.IsNullOrEmpty(formVO.Label_cd_to) ||
                    !string.IsNullOrEmpty(formVO.Label_cd_to2))
                {
                    if ((formVO.Label_cd_to.Length + formVO.Label_cd_to2.Length) != Ti040p01Constant.LEN_LABEL_CD)
                    {
                        ErrMsgCls.AddErrMsg("E107", new[] { "ラベル発行機ID（TO）", "7" }, facadeContext, new[] { "Label_cd_to", "Label_cd_to2" });
                    }
                }

                // 2-3 ラベル発行機IPFROM～4 
                //       入力項目、未入力項目が混在する場合、エラー
                if (!string.IsNullOrEmpty(formVO.Label_ip_from)  &&
                    !string.IsNullOrEmpty(formVO.Label_ip_from2) &&
                    !string.IsNullOrEmpty(formVO.Label_ip_from3) &&
                    !string.IsNullOrEmpty(formVO.Label_ip_from4))
                {
                    //正常
                }
                else if (string.IsNullOrEmpty(formVO.Label_ip_from)  &&
                         string.IsNullOrEmpty(formVO.Label_ip_from2) &&
                         string.IsNullOrEmpty(formVO.Label_ip_from3) &&
                         string.IsNullOrEmpty(formVO.Label_ip_from4))
                {
                    //正常
                }
                else
                {
                    ErrMsgCls.AddErrMsg("E121", "ラベル発行機IP（FROM）", facadeContext, new[] { "Label_ip_from", "Label_ip_from2", "Label_ip_from3", "Label_ip_from4" });
                }

                // 2-4 ラベル発行機IPTO～4 
                //       入力項目、未入力項目が混在する場合、エラー
                if (!string.IsNullOrEmpty(formVO.Label_ip_to)  &&
                    !string.IsNullOrEmpty(formVO.Label_ip_to2) &&
                    !string.IsNullOrEmpty(formVO.Label_ip_to3) &&
                    !string.IsNullOrEmpty(formVO.Label_ip_to4))
                {
                    //正常
                }
                else if (string.IsNullOrEmpty(formVO.Label_ip_to)  &&
                         string.IsNullOrEmpty(formVO.Label_ip_to2) &&
                         string.IsNullOrEmpty(formVO.Label_ip_to3) &&
                         string.IsNullOrEmpty(formVO.Label_ip_to4))
                {
                    //正常
                }
                else
                {
                    ErrMsgCls.AddErrMsg("E121", "ラベル発行機IP（TO）", facadeContext, new[] { "Label_ip_to", "Label_ip_to2", "Label_ip_to3", "Label_ip_to4" });
                }


                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 3. 関連チェック

                // 3-1 ラベル発行機ＩＤＦＲＯＭ、ラベル発行機ＩＤＦＲＯＭ2、ラベル発行機ＩＤTO、ラベル発行機ＩＤTO2
                //       ラベル発行機IDFROM　|| ラベル発行機IDFROM2 > ラベル発行機IDTO || ラベル発行機IDTO2の場合エラー
                if (!string.IsNullOrEmpty(formVO.Label_cd_from)  ||
                    !string.IsNullOrEmpty(formVO.Label_cd_from2) ||
                    !string.IsNullOrEmpty(formVO.Label_cd_to)    ||
                    !string.IsNullOrEmpty(formVO.Label_cd_to2))
                {
                    string strLabelcdfrom = string.Empty;
                    string strLabelcdto   = string.Empty;

                    if (!string.IsNullOrEmpty(formVO.Label_cd_from) ||
                        !string.IsNullOrEmpty(formVO.Label_cd_from2))
                    {
                        strLabelcdfrom = formVO.Label_cd_from.PadLeft(4, '0') + formVO.Label_cd_from2.PadLeft(3, '0');
                    }

                    if (!string.IsNullOrEmpty(formVO.Label_cd_to) ||
                        !string.IsNullOrEmpty(formVO.Label_cd_to2))
                    {
                        strLabelcdto = formVO.Label_cd_to.PadLeft(4, '0') + formVO.Label_cd_to2.PadLeft(3, '0');
                    }

                    if (!string.IsNullOrEmpty(strLabelcdfrom) &&
                        !string.IsNullOrEmpty(strLabelcdto))
                    {
                        V03002Check.CodeFromToChk(strLabelcdfrom,
                                                  strLabelcdto,
                                                  facadeContext,
                                                  "ラベル発行機ID",
                                                  new[] { "Label_cd_from", "Label_cd_from2", "Label_cd_to", "Label_cd_to2" }
                                                 );
                    }
                }

                // 3-2 ラベル発行機IPFROM～4、ラベル発行機IPTO～4
                //       ラベル発行機IPFROM～4 > ラベル発行機IPTO～4の場合エラー
                if (!string.IsNullOrEmpty(formVO.Label_ip_from)  ||
                    !string.IsNullOrEmpty(formVO.Label_ip_from2) ||
                    !string.IsNullOrEmpty(formVO.Label_ip_from3) ||
                    !string.IsNullOrEmpty(formVO.Label_ip_from4) ||
                    !string.IsNullOrEmpty(formVO.Label_ip_to)    ||
                    !string.IsNullOrEmpty(formVO.Label_ip_to2)   ||
                    !string.IsNullOrEmpty(formVO.Label_ip_to3)   ||
                    !string.IsNullOrEmpty(formVO.Label_ip_to4))
                {
                    string strLabelipfrom = string.Empty;
                    string strLabelipto   = string.Empty;

                    if (!string.IsNullOrEmpty(formVO.Label_ip_from)  ||
                        !string.IsNullOrEmpty(formVO.Label_ip_from2) ||
                        !string.IsNullOrEmpty(formVO.Label_ip_from3) ||
                        !string.IsNullOrEmpty(formVO.Label_ip_from4))
                    {
                        strLabelipfrom = formVO.Label_ip_from.PadLeft(3, '0') + formVO.Label_ip_from2.PadLeft(3, '0') + formVO.Label_ip_from3.PadLeft(3, '0') + formVO.Label_ip_from4.PadLeft(3, '0');
                    }

                    if (!string.IsNullOrEmpty(formVO.Label_ip_to)  ||
                        !string.IsNullOrEmpty(formVO.Label_ip_to2) ||
                        !string.IsNullOrEmpty(formVO.Label_ip_to3) ||
                        !string.IsNullOrEmpty(formVO.Label_ip_to4))
                    {
                        strLabelipto = formVO.Label_ip_to.PadLeft(3, '0') + formVO.Label_ip_to2.PadLeft(3, '0') + formVO.Label_ip_to3.PadLeft(3, '0') + formVO.Label_ip_to4.PadLeft(3, '0');
                    }

                    if (!string.IsNullOrEmpty(strLabelipfrom) &&
                        !string.IsNullOrEmpty(strLabelipto))
                    {
                        V03002Check.CodeFromToChk(strLabelipfrom,
                                                  strLabelipto,
                                                  facadeContext,
                                                  "ラベル発行機IP",
                                                  new[] { "Label_ip_from", "Label_ip_from2", "Label_ip_from3", "Label_ip_from4", "Label_ip_to", "Label_ip_to2", "Label_ip_to3", "Label_ip_to4" }
                                                 );
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

                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_01, facadeContext.DBContext);
                // 検索条件設定
                ReplaceWherePart(formVO, rtChk);
                
                #region SQL実行

                Decimal dCnt = 0;

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

                    // 権限取得部品の戻り値が"TRUE"の場合
                    if (CheckKengenCls.CheckKengen(loginInfVO))
                    {
                        // 最大件数チェック
                        V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
                    }
                    // 権限取得部品の戻り値が"FALSE"の場合
                    else
                    {
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
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #endregion

                #region 検索処理

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_02, facadeContext.DBContext);
                // 検索条件設定
                ReplaceWherePart(formVO, rtSeach);

                #region SQL実行

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
                    iCnt++;
                    Ti040f01M1Form m1formVO = new Ti040f01M1Form();

                    m1formVO.Commode = DbuModeCode.UPDATE;

                    // Ｍ１行NO
                    m1formVO.M1rowno = iCnt.ToString();
                    // Ｍ１ラベル発行機ＩＤ
                    m1formVO.M1label_cd = rec["LABEL_CD"].ToString();
                    // Ｍ１ラベル発行機ＩＤ2
                    m1formVO.M1label_cd2 = rec["LABEL_CD2"].ToString();
                    // Ｍ１ラベル発行機ＩＰ
                    m1formVO.M1label_ip = rec["LABEL_IP"].ToString();
                    // Ｍ１ラベル発行機ＩＰ2
                    m1formVO.M1label_ip2 = rec["LABEL_IP2"].ToString();
                    // Ｍ１ラベル発行機ＩＰ3
                    m1formVO.M1label_ip3 = rec["LABEL_IP3"].ToString();
                    // Ｍ１ラベル発行機ＩＰ4
                    m1formVO.M1label_ip4 = rec["LABEL_IP4"].ToString();
                    // Ｍ１ラベル発行機名
                    m1formVO.M1label_nm = rec["LABEL_NM"].ToString();
                    // Ｍ１ラベル備考
                    m1formVO.M1label_biko = rec["LABEL_BIKO"].ToString();

                    // Ｍ１選択フラグ(隠し)
                    m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                    // Ｍ１確定処理フラグ(隠し)
                    m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
                    // Ｍ１明細色区分(隠し)
                    m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

                    // Dictionary保存
                    // M1ラベル発行機ID
                    m1formVO.Dictionary.Add(Ti040p01Constant.DIC_M1LABEL_CD, rec["LABEL_CD"].ToString());
                    // M1ラベル発行機ID2
                    m1formVO.Dictionary.Add(Ti040p01Constant.DIC_M1LABEL_CD2, rec["LABEL_CD2"].ToString());
                    // 更新日
                    m1formVO.Dictionary.Add(Ti040p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());
                    // 更新時間
                    m1formVO.Dictionary.Add(Ti040p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());

                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(m1formVO, true);
                }

                // 検索結果が0件の場合、空白行を1行追加する
                if (iCnt == 0)
                {
                    iCnt++;
                    Ti040f01M1Form f01m1VO = new Ti040f01M1Form();

                    // Ｍ１行NO
                    f01m1VO.M1rowno = iCnt.ToString();
					f01m1VO.Commode = DbuModeCode.INSERT;

                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(f01m1VO, true);
                }

                // 検索件数の設定
                formVO.Searchcnt = m1List.Count.ToString();

                #endregion

                #endregion

                #region Dictionary保存（カード部）

                // 検索条件を退避
                SearchConditionSaveCls.SearchConditionSave(formVO);

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
        /// ReplaceWherePart 検索条件設定
		/// </summary>
        /// <param name="formVO">Ti040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
        private void ReplaceWherePart(Ti040f01Form formVO, FindSqlResultTable reader)
		{

            // 店舗コードを設定
            reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND T1.TENPO_CD = ");
            reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
            reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
            
            // ラベル発行機ＩＤFROMを設定
            if (!string.IsNullOrEmpty(formVO.Label_cd_from) &&
                !string.IsNullOrEmpty(formVO.Label_cd_from2))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_CD_FROM", " AND T1.LABEL_CD >= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_CD_FROM", "BIND02");
                reader.BindValue("BIND02", formVO.Label_cd_from.PadLeft(4, '0') + 
                                           formVO.Label_cd_from2.PadLeft(3, '0'));
            }

            // ラベル発行機ＩＤTOを設定
            if (!string.IsNullOrEmpty(formVO.Label_cd_to) &&
                !string.IsNullOrEmpty(formVO.Label_cd_to2))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_CD_TO", " AND T1.LABEL_CD <= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_CD_TO", "BIND03");
                reader.BindValue("BIND03", formVO.Label_cd_to.PadLeft(4, '0') +
                                           formVO.Label_cd_to2.PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰFROMを設定
            if (!string.IsNullOrEmpty(formVO.Label_ip_from)  &&
                !string.IsNullOrEmpty(formVO.Label_ip_from2) &&
                !string.IsNullOrEmpty(formVO.Label_ip_from3) &&
                !string.IsNullOrEmpty(formVO.Label_ip_from4))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_IP_FROM", " AND T1.LABEL_IP >= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_IP_FROM", "BIND04");
                reader.BindValue("BIND04", formVO.Label_ip_from.PadLeft(3, '0')  +
                                           formVO.Label_ip_from2.PadLeft(3, '0') +
                                           formVO.Label_ip_from3.PadLeft(3, '0') +
                                           formVO.Label_ip_from4.PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰTOを設定
            if (!string.IsNullOrEmpty(formVO.Label_ip_to)  &&
                !string.IsNullOrEmpty(formVO.Label_ip_to2) &&
                !string.IsNullOrEmpty(formVO.Label_ip_to3) &&
                !string.IsNullOrEmpty(formVO.Label_ip_to4))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_IP_TO", " AND T1.LABEL_IP <= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_IP_TO", "BIND05");
                reader.BindValue("BIND05", formVO.Label_ip_to.PadLeft(3, '0') +
                                           formVO.Label_ip_to2.PadLeft(3, '0') +
                                           formVO.Label_ip_to3.PadLeft(3, '0') +
                                           formVO.Label_ip_to4.PadLeft(3, '0'));
            }

            // ラベル発行機名を設定
            if (!string.IsNullOrEmpty(formVO.Label_nm))
            {
                string strLabelnm = "AND T1.LABEL_NM LIKE '%" + formVO.Label_nm + "%'";
                reader.ReplaceAdd("REPLACE_ID_LABEL_NM", strLabelnm);
            }

            // 備考を設定
            if (!string.IsNullOrEmpty(formVO.Label_biko))
            {
                string strLabelbiko = "AND T1.LABEL_BIKO LIKE '%" + formVO.Label_biko + "%'";
                reader.ReplaceAdd("REPLACE_ID_LABEL_BIKO", strLabelbiko);
            }

        }
        #endregion
    }
}
