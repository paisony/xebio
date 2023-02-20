using com.xebio.bo.Tj090p01.Constant;
using com.xebio.bo.Tj090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
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

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f01Facade : StandardBaseFacade
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
                Tj090f01Form formVO = (Tj090f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 初期化

                // ディクショナリのクリア
                formVO.Dictionary.Clear();

                // 選択モードの初期化
                formVO.Stkmodeno = string.Empty;

                // 一覧の初期化
                m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(formVO);
				formVO.Dictionary.Clear();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸基準日
				String tanaorosikijun_Ymd = "-1";

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

						// 1-2 ヘッダ店舗コード
						// 棚卸期間外の場合、エラー
						Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(
												formVO.Head_tenpo_cd,
												sysDateVO.Sysdate.ToString(),     //エラーが発生した場合、その時点でチェックを中止しクライアント側
												facadeContext,
												1);

						if (TanaoroshiYmdList != null)
						{
							tanaorosikijun_Ymd = TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString();
						}
                    }
                }

                // 1-3 棚段FROM
                //       1～16の範囲内でない場合、エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_from))
                {
                    if (!(int.Parse(formVO.Tana_dan_from) >= 1 &&
						  int.Parse(formVO.Tana_dan_from) <= BoSystemConstant.TANA_DAN_MAX_X))
                    {
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段FROM", "1", BoSystemConstant.TANA_DAN_MAX_X.ToString() }, facadeContext, new[] { "Tana_dan_from" });
                    }
                }

                // 1-4 棚段TO
                //       1～16の範囲内でない場合、エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_to))
                {
                    if (!(int.Parse(formVO.Tana_dan_to) >= 1 &&
						  int.Parse(formVO.Tana_dan_to) <= BoSystemConstant.TANA_DAN_MAX_X))
                    {
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段TO", "1", BoSystemConstant.TANA_DAN_MAX_X.ToString() }, facadeContext, new[] { "Tana_dan_to" });
                    }
                }

                // 1-5 入力担当者コード
                //       担当者MSTを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(formVO.Nyuryokutan_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01005Check.CheckTanto(formVO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
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
						formVO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion


                #region 2. 関連チェック

                // 2-1 フェイス№FROM、フェイス№TO
                //       フェイス№FROM > フェイス№TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Face_no_from) &&
                    !string.IsNullOrEmpty(formVO.Face_no_to))
                {
                    V03002Check.CodeFromToChk(formVO.Face_no_from,
                                              formVO.Face_no_to,
                                              facadeContext,
                                              "フェイスNo",
                                              new[] { "Face_no_from", "Face_no_to" }
                                             );
                }

                // 2-2 棚段FROM、棚段TO
                //       棚段FROM > 棚段TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_from) &&
                    !string.IsNullOrEmpty(formVO.Tana_dan_to))
                {
                    V03002Check.CodeFromToChk(formVO.Tana_dan_from,
                                              formVO.Tana_dan_to,
                                              facadeContext,
                                              "棚段",
                                              new[] { "Tana_dan_from", "Tana_dan_to" }
                                             );
                }

                // 2-3 入力日FROM、入力日TO
                //       入力日FROM > 入力日TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_from) &&
                    !string.IsNullOrEmpty(formVO.Nyuryoku_ymd_to))
                {
                    V03001Check.DateFromToChk(formVO.Nyuryoku_ymd_from,
                                              formVO.Nyuryoku_ymd_to,
                                              facadeContext,
                                              "入力日",
                                              new[] { "Nyuryoku_ymd_from", "Nyuryoku_ymd_to" }
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

				//// 営業日の取得
				//SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				//#region 棚卸基準日の取得

				//string strTanaorosikijun_ymd = string.Empty;

				//// 棚卸実施日TBLの検索
				//Hashtable hsMdit0030 = new Hashtable();
				//hsMdit0030 = SearchInventory.SearchMdit0030(BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd),
				//											sysDateVO.Sysdate.ToString(),
				//											facadeContext,
				//											0);
				//// 棚卸基準日の設定
				//if (hsMdit0030 != null)
				//{
				//	strTanaorosikijun_ymd = Convert.ToString(hsMdit0030["TANAOROSIKIJUN_YMD"]);
				//}

				//#endregion

                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_01, facadeContext.DBContext);
                // 検索条件設定
				ReplaceWherePart(formVO, rtChk, tanaorosikijun_Ymd);

                #region SQL実行

                Decimal dCnt = 0;

                //検索結果を取得します
                rtChk.CreateDbCommand();
                IList<Hashtable> tableListcnt = rtChk.Execute();

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

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_02, facadeContext.DBContext);
                // 検索条件設定
				ReplaceWherePart(formVO, rtSeach, tanaorosikijun_Ymd);

                #region SQL実行

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                int iCnt = 0;
                foreach (Hashtable rec in tableList)
                {
                    iCnt++;
                    Tj090f01M1Form m1formVO = new Tj090f01M1Form();

                    // Ｍ１フェイスＮｏ
                    m1formVO.M1face_no = rec["FACE_NO"].ToString();
                    // Ｍ１棚段
                    m1formVO.M1tana_dan = rec["TANA_DAN"].ToString();
                    // Ｍ１回数
                    m1formVO.M1kai_su = rec["KAI_SU"].ToString();
                    // Ｍ１点数棚卸入力数
                    m1formVO.M1tensutanaorosinyuryoku_su = rec["TENSUTANAOROSINYURYOKU_SU"].ToString();
                    // Ｍ１点数棚卸訂正数
                    m1formVO.M1tensutanaorositeisei_su = rec["TENSUTANAOROSITEISEI_SU"].ToString();
                    // Ｍ１点数棚卸訂正数(隠し)
                    m1formVO.M1tensutanaorositeisei_su_hdn = rec["TENSUTANAOROSITEISEI_SU"].ToString();
                    // Ｍ１点数棚卸合計数
                    m1formVO.M1tensutanaorosigokei_su = rec["TENSUTANAOROSIGOKEI_SU"].ToString();
                    // Ｍ１スキャン数量
                    m1formVO.M1scan_su = rec["TANAOROSISCAN_SU"].ToString();
                    // Ｍ１訂正数量
                    m1formVO.M1teisei_suryo = rec["TANAOROSITEISEI_SU"].ToString();
                    // Ｍ１合計数量
                    m1formVO.M1gokei_suryo = rec["TANAOROSIGOKEI_SU"].ToString();
                    // Ｍ１入力担当者名称
                    m1formVO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();
                    // Ｍ１理由コメント情報
                    if (rec["TANAOROSIRIYU_NM"].ToString().Length > 8)
                    {
                        m1formVO.M1riyucomment_nm = rec["TANAOROSIRIYU_NM"].ToString().Substring(8);
                    }
                    else
                    {
                        m1formVO.M1riyucomment_nm = rec["TANAOROSIRIYU_NM"].ToString();
                    }
                    // Ｍ１入力日
                    m1formVO.M1nyuryoku_ymd = rec["ADD_YMD"].ToString();

                    // Ｍ１選択フラグ(隠し)
                    m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                    // Ｍ１確定処理フラグ(隠し)
                    m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
                    // Ｍ１明細色区分(隠し)
                    m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

                    // Dictionary保存
                    // 更新日
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());
                    // 更新時間
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());
                    // 棚卸日
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1TANAOROSI_YMD, rec["TANAOROSI_YMD"].ToString());
                    // 送信回数
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1SOSINKAI_SU, rec["SOSINKAI_SU"].ToString());
                    // 入力担当者コード
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1NYURYOKUTAN_CD, rec["ADDTAN_CD"].ToString());
                    // 理由コード
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1RIYUCOMMENT_CD, rec["TANAOROSIRIYU_CD"].ToString());

                    // Ｍ１行NO
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1ROWNO, iCnt.ToString());

                    // Ｍ１フェイスＮｏ
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1FACE_NO, rec["FACE_NO"].ToString());
                    // Ｍ１棚段
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1TANA_DAN, rec["TANA_DAN"].ToString());
                    // Ｍ１回数
                    m1formVO.Dictionary.Add(Tj090p01Constant.DIC_M1KAI_SU, rec["KAI_SU"].ToString());


                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(m1formVO, true);
                }

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

                #endregion

                #endregion

                #region 選択モードNOの設定

                // 選択モードNOの設定
                formVO.Stkmodeno = formVO.Modeno;

                #endregion

                #region Dictionary保存（カード部）

                // 検索条件を退避
                SearchConditionSaveCls.SearchConditionSave(formVO);

                // 棚卸基準日
				formVO.Dictionary.Add(Tj090p01Constant.DIC_TANAOROSIKIJUN_YMD, tanaorosikijun_Ymd);

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
        /// <param name="formVO">Tj040f01Form</param>
        /// <param name="FindSqlResultTable">rtChk</param>
        /// <returns></returns>
        private void ReplaceWherePart(Tj090f01Form formVO, FindSqlResultTable reader, string prmTanaorosikijun_ymd)
        {

            // 店舗コードを設定
            reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND T1.TENPO_CD = ");
            reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
            reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

            // フェイスＮｏFROMを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_from))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_FROM", " AND T1.FACE_NO >= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_FROM", "BIND02");
                reader.BindValue("BIND02", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_from, "0")));
            }

            // フェイスＮｏTOを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_to))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_TO", " AND T1.FACE_NO <= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_TO", "BIND03");
                reader.BindValue("BIND03", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_to, "0")));
            }

            // 棚段FROMを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_from))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_FROM", " AND T1.TANA_DAN >= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_FROM", "BIND04");
                reader.BindValue("BIND04", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_from, "0")));
            }

            // 棚段TOを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_to))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_TO", " AND T1.TANA_DAN <= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_TO", "BIND05");
                reader.BindValue("BIND05", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_to, "0")));
            }

            // 入力担当者コードを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryokutan_cd))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKUTAN_CD", " AND T1.ADDTAN_CD = ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKUTAN_CD", "BIND06");
                reader.BindValue("BIND06", BoSystemFormat.formatTantoCd(formVO.Nyuryokutan_cd));
            }

            // 入力日FROMを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_from))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_FROM", " AND T1.ADD_YMD >= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_FROM", "BIND07");
				reader.BindValue("BIND07", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_from)));
            }

            // 入力日TOを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_to))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_TO", " AND T1.ADD_YMD <= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_TO", "BIND08");
                reader.BindValue("BIND08", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_to)));
            }

            // 棚卸日を設定
            if (!string.IsNullOrEmpty(prmTanaorosikijun_ymd))
            {
                reader.ReplaceAdd("REPLACE_ID_TANAOROSI_YMD", " AND T1.TANAOROSI_YMD = ");
                reader.ReplaceAddBind("REPLACE_ID_TANAOROSI_YMD", "BIND09");
                reader.BindValue("BIND09", Convert.ToDecimal(BoSystemString.Nvl(prmTanaorosikijun_ymd, "0")));
            }

        }
        #endregion
    }
}
