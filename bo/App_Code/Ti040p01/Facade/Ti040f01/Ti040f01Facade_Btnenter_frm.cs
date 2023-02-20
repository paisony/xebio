using com.xebio.bo.Ti040p01.Constant;
using com.xebio.bo.Ti040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Advanced.Util;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Ti040p01.Facade
{
  /// <summary>
  /// Ti040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ti040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

            try
            {
                //DBコンテキストを設定する。
                SetDBContext(facadeContext);
                //コネクションを取得して、トランザクションを開始する。
                BeginTransactionWithConnect(facadeContext);

                //以下に業務ロジックを記述する。

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // 画面より情報を取得する。
                Ti040f01Form formVO = (Ti040f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warninngFlg != 1)
				{

					#region 業務チェック

					#region 行数チェック

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 入力値チェック

					for (int i = 0; i < m1List.Count; i++)
					{
						Ti040f01M1Form m1formVO = (Ti040f01M1Form)m1List[i];

						// ラベル発行機IDが入力されている行のチェックを行う。
						if (!string.IsNullOrEmpty(m1formVO.M1label_cd) ||
							!string.IsNullOrEmpty(m1formVO.M1label_cd2))
						{
							// 1-1 M1ラベル発行機ID、M1ラベル発行機ID2 
							//       結合した桁数が7桁以外の場合エラー
							if (!string.IsNullOrEmpty(m1formVO.M1label_cd) ||
								!string.IsNullOrEmpty(m1formVO.M1label_cd2))
							{
								if ((m1formVO.M1label_cd.Length + m1formVO.M1label_cd2.Length) != Ti040p01Constant.LEN_LABEL_CD)
								{
									ErrMsgCls.AddErrMsg("E107",
														new[] { "ラベル発行機ID", "7" },
														facadeContext,
														new[] { "M1label_cd", "M1label_cd2" },
														m1formVO.M1rowno,
														i.ToString(),
														"M1");
								}
							}

							// 1-2 M1ラベル発行機名 
							//       ラベル発行機名が入力されていない場合、エラー
							if (string.IsNullOrEmpty(m1formVO.M1label_nm))
							{
								ErrMsgCls.AddErrMsg("E121",
													"ラベル発行機名",
													facadeContext,
													new[] { "M1label_nm" },
													m1formVO.M1rowno,
													i.ToString(),
													"M1");
							}

							// 1-3 M1ラベル発行機ID、M1ラベル発行機ID2 
							//       同一のラベル発行機IDが複数存在した場合、エラー
							if (!string.IsNullOrEmpty(m1formVO.M1label_cd) &&
								!string.IsNullOrEmpty(m1formVO.M1label_cd2))
							{
								for (int j = 0; j < m1List.Count; j++)
								{
									if (i == j)
									{
										continue;
									}

									Ti040f01M1Form m1form2VO = (Ti040f01M1Form)m1List[j];

									if (!string.IsNullOrEmpty(m1form2VO.M1label_cd) &&
										!string.IsNullOrEmpty(m1form2VO.M1label_cd2))
									{
										if ((m1formVO.M1label_cd + m1formVO.M1label_cd2).Equals(m1form2VO.M1label_cd + m1form2VO.M1label_cd2))
										{
											ErrMsgCls.AddErrMsg("E193",
																String.Empty,
																facadeContext,
																new[] { "M1label_cd", "M1label_cd2" },
																m1formVO.M1rowno,
																i.ToString(),
																"M1");
											break;
										}
									}
								}
							}

							// 1-4 M1ラベル発行機IP～4 
							//       同一のラベル発行機IP～4が複数存在する場合、エラー
							if (!string.IsNullOrEmpty(m1formVO.M1label_ip) &&
								!string.IsNullOrEmpty(m1formVO.M1label_ip2) &&
								!string.IsNullOrEmpty(m1formVO.M1label_ip3) &&
								!string.IsNullOrEmpty(m1formVO.M1label_ip4))
							{
								for (int j = 0; j < m1List.Count; j++)
								{
									if (i == j)
									{
										continue;
									}

									Ti040f01M1Form m1form2VO = (Ti040f01M1Form)m1List[j];

									if (!string.IsNullOrEmpty(m1form2VO.M1label_ip) &&
										!string.IsNullOrEmpty(m1form2VO.M1label_ip2) &&
										!string.IsNullOrEmpty(m1form2VO.M1label_ip3) &&
										!string.IsNullOrEmpty(m1form2VO.M1label_ip4))
									{
										if ((m1formVO.M1label_ip + m1formVO.M1label_ip2 +
											 m1formVO.M1label_ip3 + m1formVO.M1label_ip4).Equals(
														m1form2VO.M1label_ip + m1form2VO.M1label_ip2 +
														m1form2VO.M1label_ip3 + m1form2VO.M1label_ip4))
										{
											ErrMsgCls.AddErrMsg("E138",
																String.Empty,
																facadeContext,
																new[] { "M1label_ip", "M1label_ip2", "M1label_ip3", "M1label_ip4" },
																m1formVO.M1rowno,
																i.ToString(),
																"M1");
											break;
										}
									}
								}
							}
						}
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 排他チェック

					StringBuilder sRepSql = new StringBuilder();

					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND LABEL_CD = :BIND_LABEL_CD");

					ArrayList bindList = null;
					BindInfoVO bindVO = null;

					for (int i = 0; i < m1List.Count; i++)
					{
						Ti040f01M1Form m1formVO = (Ti040f01M1Form)m1List[i];

						string strGyonm = "(" + m1formVO.M1rowno + "行目" + ")";

						if (DbuModeCode.UPDATE.Equals(m1formVO.Commode))
						{
							// ----------------------------------------------
							// 検索した明細行の場合、排他チェックを行う。
							// ----------------------------------------------
							bindList = new ArrayList();
							bindVO = new BindInfoVO();

							// 店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// ラベル発行機ＩＤ
							string strLabelcd = ((String)m1formVO.Dictionary[Ti040p01Constant.DIC_M1LABEL_CD]).PadLeft(4, '0') +
												((String)m1formVO.Dictionary[Ti040p01Constant.DIC_M1LABEL_CD2]).PadLeft(3, '0');

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_LABEL_CD";
							bindVO.Value = strLabelcd;
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)m1formVO.Dictionary[Ti040p01Constant.DIC_M1UPD_YMD]),
									Convert.ToDecimal((string)m1formVO.Dictionary[Ti040p01Constant.DIC_M1UPD_TM]),
									facadeContext,
									"MDMT0220",
									sRepSql.ToString(),
									bindList,
									1,
									null,
									m1formVO.M1rowno,
									i.ToString(),
									"M1",
									100
							);


							// ----------------------------------------------
							// 検索条件外に同一データが存在する場合、エラー
							// ----------------------------------------------
							if (Chk_Labelcd(facadeContext, m1formVO, formVO))
							{
								ErrMsgCls.AddErrMsg("E219",
													String.Empty,
													facadeContext,
													new[] { "M1label_cd", "M1label_cd2" },
													m1formVO.M1rowno,
													i.ToString(),
													"M1");
							}

						}
						// 追加した明細行の場合、存在チェックを行う。
						else if (DbuModeCode.INSERT.Equals(m1formVO.Commode))
						{
							// ----------------------------------------------
							// 検索条件外に同一データが存在する場合、エラー
							// ----------------------------------------------
							if (Chk_Labelcd(facadeContext, m1formVO, formVO))
							{
								ErrMsgCls.AddErrMsg("E219",
													String.Empty,
													facadeContext,
													new[] { "M1label_cd", "M1label_cd2" },
													m1formVO.M1rowno,
													i.ToString(),
													"M1");
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

					#region 警告チェック
					for (int i = 0; i < m1List.Count; i++)
					{
						Ti040f01M1Form m1formVO = (Ti040f01M1Form)m1List[i];

						// 1-5 M1ラベル発行機IP～4 
						//       ラベルプリンタ管理MSTの他店舗情報で同一IPが存在する場合、エラー
						if (!string.IsNullOrEmpty(m1formVO.M1label_ip) &&
							!string.IsNullOrEmpty(m1formVO.M1label_ip2) &&
							!string.IsNullOrEmpty(m1formVO.M1label_ip3) &&
							!string.IsNullOrEmpty(m1formVO.M1label_ip4))
						{
							FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_06, facadeContext.DBContext);

							#region 検索条件設定

							//// 店舗コードを設定
							//rtChk.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));

							// ラベル発行機ＩＰを設定
							string strLabel_ip = m1formVO.M1label_ip.PadLeft(3, '0') +
												 m1formVO.M1label_ip2.PadLeft(3, '0') +
												 m1formVO.M1label_ip3.PadLeft(3, '0') +
												 m1formVO.M1label_ip4.PadLeft(3, '0');
							rtChk.BindValue("BIND_LABEL_IP", strLabel_ip);

							// 店舗コードを設定
							rtChk.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND TENPO_CD = ");
							rtChk.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
							rtChk.BindValue("BIND01", BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));

							// ラベル発行機ＩＤFROMを設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)]))
							{
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_CD_FROM", " AND LABEL_CD >= ");
								rtChk.ReplaceAddBind("REPLACE_ID_LABEL_CD_FROM", "BIND02");
								rtChk.BindValue("BIND02", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)].ToString().PadLeft(4, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)].ToString().PadLeft(3, '0'));
							}

							// ラベル発行機ＩＤTOを設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)]))
							{
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_CD_TO", " AND LABEL_CD <= ");
								rtChk.ReplaceAddBind("REPLACE_ID_LABEL_CD_TO", "BIND03");
								rtChk.BindValue("BIND03", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)].ToString().PadLeft(4, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)].ToString().PadLeft(3, '0'));
							}

							// ラベル発行機ＩＰFROMを設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)]))
							{
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_IP_FROM", " AND LABEL_IP >= ");
								rtChk.ReplaceAddBind("REPLACE_ID_LABEL_IP_FROM", "BIND04");
								rtChk.BindValue("BIND04", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)].ToString().PadLeft(3, '0'));
							}

							// ラベル発行機ＩＰTOを設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)]) &&
								!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)]))
							{
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_IP_TO", " AND LABEL_IP <= ");
								rtChk.ReplaceAddBind("REPLACE_ID_LABEL_IP_TO", "BIND05");
								rtChk.BindValue("BIND05", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)].ToString().PadLeft(3, '0') +
														  formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)].ToString().PadLeft(3, '0'));
							}

							// ラベル発行機名を設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)]))
							{
								string strLabelnm = "AND LABEL_NM LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)] + "%'";
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_NM", strLabelnm);
							}

							// 備考を設定
							if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)]))
							{
								string strLabelbiko = "AND LABEL_BIKO LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)] + "%'";
								rtChk.ReplaceAdd("REPLACE_ID_LABEL_BIKO", strLabelbiko);
							}

							#endregion

							#region SQL実行

							//検索結果を取得します
							rtChk.CreateDbCommand();
							IList<Hashtable> tableListcnt = rtChk.Execute();

							BoSystemLog.logOut("SQL: " + rtChk.LogSql);

							if (tableListcnt != null && tableListcnt.Count > 0)
							{
								Hashtable resultTbl = tableListcnt[0];
								Decimal dCnt = (Decimal)resultTbl["CNT"];

								if (dCnt > 0)
								{
									InfoMsgCls.AddWarnMsg("W124",
														new[] { m1formVO.M1label_ip + "." + m1formVO.M1label_ip2 + "." + m1formVO.M1label_ip3 + "." + m1formVO.M1label_ip4 },
														facadeContext,
														new[] { "M1label_ip", "M1label_ip2", "M1label_ip3", "M1label_ip4" },
														m1formVO.M1rowno,
														i.ToString(),
														"M1");
								}
							}

							#endregion
						}
					}

					// ------------------------------------------------------------------------------------
					// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
					// ------------------------------------------------------------------------------------
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}

					#endregion
				}

                #region 更新処理

                // システム日付取得
                SysDateVO sysDateVO = new SysDateVO();
                sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                // 権限取得部品の戻り値が"TRUE"の場合
                if (CheckKengenCls.CheckKengen(logininfo))
                {
                    // [ラベルプリンタ管理MST]を削除する。
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を削除 START");
                    int Delcnt = Del_Mdmt0220(facadeContext, formVO, logininfo);
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を削除 END");

                    // [ラベルプリンタ管理MST]を登録する。
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を登録 START");
                    int Intcnt = Ins_Mdmt0220(facadeContext, formVO, logininfo, sysDateVO);
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を登録 END");
                }
                // 権限取得部品の戻り値が"FALSE"の場合
                else
                {
                    // [ラベルプリンタ管理MST]を更新する。
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を更新 START");
                    int Updcnt = Upd_Mdmt0220(facadeContext, formVO, logininfo, sysDateVO);
					BoSystemLog.logOut("[ラベルプリンタ管理MST]を更新 END");
                }

                #endregion

                //トランザクションをコミットする。
                CommitTransaction(facadeContext);
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
            EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

        #region [ラベルプリンタ管理MST]を削除する。
        /// <summary>
        /// [ラベルプリンタ管理MST]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">画面VO</param>
        /// <param name="loginInfoVO">ログイン情報</param>
        /// <returns>更新件数</returns>
        private int Del_Mdmt0220(IFacadeContext facadeContext, Ti040f01Form formVO, LoginInfoVO loginInfoVO)
        {

            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_03, facadeContext.DBContext);

            // 検索条件設定
            ReplaceDeleteWherePart(formVO, reader);

            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region [ラベルプリンタ管理MST]を登録する。
        /// <summary>
        /// [ラベルプリンタ管理MST]を登録する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">画面VO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <returns>更新件数</returns>
        private int Ins_Mdmt0220(IFacadeContext facadeContext, Ti040f01Form formVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
        {
            int iRownum = 0;

            // Dictionary取得（カード部）
            // ヘッダ店舗コード
            string dHeadTenpoCd = BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);

            IDataList m1List = formVO.GetList("M1");

            // Oracleコマンドの生成
            OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
            // トランザクションの設定
            command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
            // SQLの実行タイプ
            command.CommandType = CommandType.Text;


            IList<Mdmt0220VO> insertBodyList = new List<Mdmt0220VO>();	// 更新データリスト

            // パラメータバインド処理
            IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
            int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

            for (int i = 0; i < m1List.Count; i++)
            {
                Ti040f01M1Form m1formVO = (Ti040f01M1Form)m1List[i];

                // ラベル発行機ＩＤが入力されている行が対象
                if (!string.IsNullOrEmpty(m1formVO.M1label_cd.Trim()) &&
                    !string.IsNullOrEmpty(m1formVO.M1label_cd2.Trim()))
                {
                    counter++;
                    iRownum++;

                    Dictionary<string, string> bindDic = new Dictionary<string, string>();

                    #region 登録内容設定

                    // 店舗コード
                    BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), dHeadTenpoCd, ref bindDic, ref command);
                    // ラベル発行機ＩＤ
                    string strLabelcd = m1formVO.M1label_cd.PadLeft(4, '0') +
                                        m1formVO.M1label_cd2.PadLeft(3, '0');
                    BoSystemDb.setInsertVal("LABEL_CD", iRownum.ToString(), strLabelcd, ref bindDic, ref command);
                    // ラベル発行機ＩＰ
                    string strLabelip = m1formVO.M1label_ip.PadLeft(3, '0')  +
                                        m1formVO.M1label_ip2.PadLeft(3, '0') +
                                        m1formVO.M1label_ip3.PadLeft(3, '0') +
                                        m1formVO.M1label_ip4.PadLeft(3, '0');
                    BoSystemDb.setInsertVal("LABEL_IP", iRownum.ToString(), strLabelip, ref bindDic, ref command);
                    // ラベル発行機名
                    string strLabelnm = m1formVO.M1label_nm.Trim();
                    BoSystemDb.setInsertVal("LABEL_NM", iRownum.ToString(), strLabelnm, ref bindDic, ref command);
                    // ラベル備考
                    string strLabelbiko = m1formVO.M1label_biko.Trim();
                    BoSystemDb.setInsertVal("LABEL_BIKO", iRownum.ToString(), strLabelbiko, ref bindDic, ref command);

                    // 登録日
                    BoSystemDb.setInsertVal("ADD_YMD", iRownum.ToString(), sysDateVO.Sysdate.ToString(), ref bindDic, ref command);
                    // 登録時間
                    BoSystemDb.setInsertVal("ADD_TM", iRownum.ToString(), sysDateVO.Systime.ToString(), ref bindDic, ref command);
                    // 登録担当者コード
					BoSystemDb.setInsertVal("ADDTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.LoginId), ref bindDic, ref command);
                    // 更新日
                    BoSystemDb.setInsertVal("UPD_YMD", iRownum.ToString(), sysDateVO.Sysdate.ToString(), ref bindDic, ref command);
                    // 更新時間
                    BoSystemDb.setInsertVal("UPD_TM", iRownum.ToString(), sysDateVO.Systime.ToString(), ref bindDic, ref command);
                    // 更新担当者コード
                    BoSystemDb.setInsertVal("UPD_TANCD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.LoginId), ref bindDic, ref command);
                    // 削除日
                    BoSystemDb.setInsertVal("SAKUJYO_YMD", iRownum.ToString(), sysDateVO.Sysdate.ToString(), ref bindDic, ref command);
                    // 削除フラグ
                    BoSystemDb.setInsertVal("SAKUJYO_FLG", iRownum.ToString(), "0", ref bindDic, ref command);
                    // 受信日
                    BoSystemDb.setInsertVal("JYUSIN_YMD", iRownum.ToString(), "0", ref bindDic, ref command);
                    // 受信時間
                    BoSystemDb.setInsertVal("JYUSIN_TM", iRownum.ToString(), "0", ref bindDic, ref command);

                    insertBindList.Add(bindDic);

                    #endregion

                    // 一括処理単位に達した場合は、マルチインサートを実行
                    if (counter == 20)
                    {
                        // カウンタのリセット
                        counter = 0;

                        // マルチインサートの実行
                        command.CommandText = GetSqlMultiInsT_Mdmt0220(insertBindList);
                        //OutPutLog(command.CommandText);
                        command.ExecuteNonQuery();

                        // 配列、バインドパラメータのクリア
                        insertBindList.Clear();
                        command.Parameters.Clear();
                    }
                }

            }// for

            // 未登録レコードの登録
            if (counter > 0)
            {
                // マルチインサートの実行
                command.CommandText = GetSqlMultiInsT_Mdmt0220(insertBindList);
                command.ExecuteNonQuery();
            }

            return iRownum;
        }
        #endregion

        #region [ラベルプリンタ管理MST]を更新する。
        /// <summary>
        /// [ラベルプリンタ管理MST]を更新する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">画面VO</param>
        /// <param name="loginInfoVO">ログイン情報</param>
        /// <returns>更新件数</returns>
        private int Upd_Mdmt0220(IFacadeContext facadeContext, Ti040f01Form formVO, LoginInfoVO loginInfoVO, SysDateVO sysDateVO)
        {
            int retCount = 0;

            // Dictionary取得（カード部）
            // ヘッダ店舗コード
            string dHeadTenpoCd = BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);

            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_05, facadeContext.DBContext);

            IDataList m1List = formVO.GetList("M1");

            for (int i = 0; i < m1List.Count; i++)
            {
                Ti040f01M1Form m1formVO = (Ti040f01M1Form)m1List[i];

                // バインドパラメータのクリア
                reader.ClearValue();

                // 更新内容の設定
                ReplaceUpdateWherePart(dHeadTenpoCd, m1formVO, loginInfoVO, sysDateVO, reader);

                //クエリを実行する。
                IDbCommand cmd = reader.CreateDbCommand();

                retCount = cmd.ExecuteNonQuery();
            }

            return retCount;
        }
        #endregion

        #region [ラベルプリンタ管理MST]へのマルチインサート文作成。
        /// <summary>
        /// ラベルプリンタ管理MSTへのマルチインサートを行うSQL文を取得する。
        /// </summary>
        /// <param name="insertBindList">バインドテキスト</param>
        private string GetSqlMultiInsT_Mdmt0220(IList<Dictionary<string, string>> insertBindList)
        {
            IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

            // バインドテキストのデータ分INSERT文を作成
            foreach (Dictionary<string, string> bindDic in insertBindList)
            {
                StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文

                insertSql.Append("    INTO MDMT0220 VALUES ( ");
                insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");
                insertSql.Append(bindDic["LABEL_CD"]).Append(" , ");
                insertSql.Append(bindDic["LABEL_IP"]).Append(" , ");
                insertSql.Append(bindDic["LABEL_NM"]).Append(" , ");
                insertSql.Append(bindDic["LABEL_BIKO"]).Append(" , ");

                insertSql.Append(bindDic["ADD_YMD"]).Append(" , ");
                insertSql.Append(bindDic["ADD_TM"]).Append(" , ");
                insertSql.Append(bindDic["ADDTAN_CD"]).Append(" , ");
                insertSql.Append(bindDic["UPD_YMD"]).Append(" , ");
                insertSql.Append(bindDic["UPD_TM"]).Append(" , ");
                insertSql.Append(bindDic["UPD_TANCD"]).Append(" , ");
                insertSql.Append(bindDic["SAKUJYO_YMD"]).Append(" , ");
                insertSql.Append(bindDic["SAKUJYO_FLG"]).Append(" , ");
                insertSql.Append(bindDic["JYUSIN_YMD"]).Append(" , ");
                insertSql.Append(bindDic["JYUSIN_TM"]);
                insertSql.Append(" ) ");

                insertSqlList.Add(insertSql.ToString());
            }

            // 単一INSERTをまとめて、マルチインサート文を作成
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT ALL");
            foreach (string sqlpart in insertSqlList)
            {
                sql.AppendLine(sqlpart);
            }
            sql.AppendLine("SELECT 1 FROM DUAL");

            return sql.ToString();
        }
        #endregion

        #region 削除条件設定
        /// <summary>
        /// ReplaceDeleteWherePart 削除条件設定
        /// </summary>
        /// <param name="formVO">Ti040f01Form</param>
        /// <param name="FindSqlResultTable">rtChk</param>
        /// <returns></returns>
        private void ReplaceDeleteWherePart(Ti040f01Form formVO, FindSqlResultTable reader)
        {

            // 店舗コードを設定
            reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND T1.TENPO_CD = ");
            reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
            reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));

            // ラベル発行機ＩＤFROMを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)]))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_CD_FROM", " AND T1.LABEL_CD >= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_CD_FROM", "BIND02");
                reader.BindValue("BIND02", ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)]).PadLeft(4, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)]).PadLeft(3, '0'));
            }

            // ラベル発行機ＩＤTOを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)]))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_CD_TO", " AND T1.LABEL_CD <= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_CD_TO", "BIND03");
                reader.BindValue("BIND03", ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)]).PadLeft(4, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)]).PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰFROMを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)])  &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)]))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_IP_FROM", " AND T1.LABEL_IP >= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_IP_FROM", "BIND04");
                reader.BindValue("BIND04", ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)]).PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰTOを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)])  &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)]))
            {
                reader.ReplaceAdd("REPLACE_ID_LABEL_IP_TO", " AND T1.LABEL_IP <= ");
                reader.ReplaceAddBind("REPLACE_ID_LABEL_IP_TO", "BIND05");
                reader.BindValue("BIND05", ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)]).PadLeft(3, '0') +
                                           ((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)]).PadLeft(3, '0'));
            }

            // ラベル発行機名を設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)]))
            {
                string strLabelnm = "AND T1.LABEL_NM LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)] + "%'";
                reader.ReplaceAdd("REPLACE_ID_LABEL_NM", strLabelnm);
            }

            // 備考を設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)]))
            {
                string strLabelbiko = "AND T1.LABEL_BIKO LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)] + "%'";
                reader.ReplaceAdd("REPLACE_ID_LABEL_BIKO", strLabelbiko);
            }

        }
        #endregion

        #region 更新条件設定
        /// <summary>
        /// ReplaceUpdateWherePart 更新条件設定
        /// </summary>
        /// <param name="prmTenpoCd">店舗コード</param>
        /// <param name="prmM1formVO">Ti040f01M1Form</param>
        /// <param name="loginInfoVO">LoginInfoVO</param>
        /// <param name="sysDateVO">SysDateVO</param>
        /// <param name="FindSqlResultTable">rtChk</param>
        /// <returns></returns>
        private void ReplaceUpdateWherePart(string prmTenpoCd, Ti040f01M1Form prmM1formVO, LoginInfoVO loginInfoVO, SysDateVO sysDateVO, FindSqlResultTable reader)
        {
            // 店舗コードを設定
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(prmTenpoCd));
            // ラベル発行機ＩＤ
            string strLabelcd = prmM1formVO.M1label_cd.PadLeft(4, '0') + prmM1formVO.M1label_cd2.PadLeft(3, '0');
            reader.BindValue("BIND_LABEL_CD", strLabelcd);

            // ラベル発行機名
            reader.BindValue("BIND_LABEL_NM", prmM1formVO.M1label_nm);
            // ラベル備考
            reader.BindValue("BIND_LABEL_BIKO", prmM1formVO.M1label_biko);
            // 更新日
            reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
            // 更新時間
            reader.BindValue("BIND_UPD_TM", sysDateVO.Systime);
            // 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfoVO.LoginId));
        }
        #endregion

        #region ラベル発行機IDの存在チェックを行う。
        /// <summary>
        /// ラベル発行機IDの存在チェックを行う。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="prmM1formVO">Ti040f01M1Form</param>
        /// <param name="formVO">Ti040f01Form</param>
        /// <returns>true Or false</returns>
        private bool Chk_Labelcd(IFacadeContext facadeContext, Ti040f01M1Form prmM1formVO, Ti040f01Form formVO)
        {
            bool retbool = true;

            FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Ti040p01Constant.SQL_ID_07, facadeContext.DBContext);

            #region 検索条件設定

            // 店舗コードを設定
            rtChk.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));

            // ラベル発行機ＩＤを設定
            string strLabel_cd = prmM1formVO.M1label_cd.PadLeft(4, '0') +
                                 prmM1formVO.M1label_cd2.PadLeft(3, '0');
            rtChk.BindValue("BIND_LABEL_CD", strLabel_cd);


            // 店舗コードを設定
            rtChk.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND TENPO_CD = ");
            rtChk.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
            rtChk.BindValue("BIND01", BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));

            // ラベル発行機ＩＤFROMを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)]))
            {
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_CD_FROM", " AND LABEL_CD >= ");
                rtChk.ReplaceAddBind("REPLACE_ID_LABEL_CD_FROM", "BIND02");
                rtChk.BindValue("BIND02", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from)].ToString().PadLeft(4, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_from2)].ToString().PadLeft(3, '0'));
            }

            // ラベル発行機ＩＤTOを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)]))
            {
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_CD_TO", " AND LABEL_CD <= ");
                rtChk.ReplaceAddBind("REPLACE_ID_LABEL_CD_TO", "BIND03");
                rtChk.BindValue("BIND03", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to)].ToString().PadLeft(4, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_cd_to2)].ToString().PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰFROMを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)])  &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)]))
            {
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_IP_FROM", " AND LABEL_IP >= ");
                rtChk.ReplaceAddBind("REPLACE_ID_LABEL_IP_FROM", "BIND04");
                rtChk.BindValue("BIND04", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from)].ToString().PadLeft(3, '0')  +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from2)].ToString().PadLeft(3, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from3)].ToString().PadLeft(3, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_from4)].ToString().PadLeft(3, '0'));
            }

            // ラベル発行機ＩＰTOを設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)])  &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)]) &&
                !string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)]))
            {
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_IP_TO", " AND LABEL_IP <= ");
                rtChk.ReplaceAddBind("REPLACE_ID_LABEL_IP_TO", "BIND05");
                rtChk.BindValue("BIND05", formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to)].ToString().PadLeft(3, '0')  +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to2)].ToString().PadLeft(3, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to3)].ToString().PadLeft(3, '0') +
                                          formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_ip_to4)].ToString().PadLeft(3, '0'));
            }

            // ラベル発行機名を設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)]))
            {
                string strLabelnm = "AND LABEL_NM LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_nm)] + "%'";
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_NM", strLabelnm);
            }

            // 備考を設定
            if (!string.IsNullOrEmpty((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)]))
            {
                string strLabelbiko = "AND LABEL_BIKO LIKE '%" + (String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Label_biko)] + "%'";
                rtChk.ReplaceAdd("REPLACE_ID_LABEL_BIKO", strLabelbiko);
            }

            #endregion

            #region SQL実行

            //検索結果を取得します
            rtChk.CreateDbCommand();
            IList<Hashtable> tableListcnt = rtChk.Execute();

            BoSystemLog.logOut("SQL: " + rtChk.LogSql);

            if (tableListcnt == null || tableListcnt.Count <= 0)
            {
                retbool = false;
            }
            else
            {
                Hashtable resultTbl = tableListcnt[0];
                Decimal dCnt = (Decimal)resultTbl["CNT"];

                if (dCnt == 0)
                {
                    retbool = false;
                }
            }

            #endregion

            return retbool;
        }
        #endregion
	}
}
