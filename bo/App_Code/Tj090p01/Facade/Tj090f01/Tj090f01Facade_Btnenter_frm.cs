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
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f01Facade : StandardBaseFacade
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

                // FormVO取得
                // 画面より情報を取得する。
                Tj090f01Form formVO = (Tj090f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

				// 警告メッセージの応答結果を取得
				string waningflg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0");

                #region 業務チェック

				if (!"1".Equals(waningflg))
				{

					#region 1. 選択状態

					// 1-1 選択状態
					//       1件も選択されていない場合、エラー 
					if (m1List == null || m1List.Count <= 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
					}
					else
					{
						int inputflg = 0;
						for (int i = 0; i < m1List.Count; i++)
						{
							Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];

							// 照会
							if (BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Stkmodeno)))
							{
								if (m1formVO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
								{
									inputflg = 1;
									break;
								}
							}
							// 取消
							else if (BoSystemConstant.MODE_DEL.Equals(BoSystemString.Nvl(formVO.Stkmodeno)))
							{
								if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
								{
									inputflg = 1;
									break;
								}
							}
						}
						if (inputflg == 0)
						{
							// 確定対象がありません。
							ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
						}
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 2. マスタ存在チェック

					// 2-1 ヘッダ店舗コード
					//       棚卸終了処理が行われている場合、エラー  

					// 営業日の取得
					SysDateVO chkSysDateVO = SysdateCls.GetSysdateTime(facadeContext);

					// 棚卸実施日TBLの検索
					string retTanaorosisyuryo_flg = SearchInventory.CheckInventoryEnd(BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]),
																					  (String)formVO.Dictionary[Tj090p01Constant.DIC_TANAOROSIKIJUN_YMD],
																					  facadeContext,
																					  1);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}


					// 2-2 Ｍ１棚段
					//       棚段が1～16の間以外で入力されている場合、エラー
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj090f01M1Form f01m1VO = (Tj090f01M1Form)m1List[i];
						decimal tanadan = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tana_dan, "0"));
						if (tanadan < 1 || tanadan > BoSystemConstant.TANA_DAN_MAX_X)
						{
							ErrMsgCls.AddErrMsg("E173"
											, new[] { "棚段", "1", BoSystemConstant.TANA_DAN_MAX_X.ToString() }
											, facadeContext
											, new[] { "M1tana_dan" }
											, f01m1VO.Dictionary[Tj090p01Constant.DIC_M1ROWNO].ToString()
											, i.ToString()
											, "M1");
						}
					}
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}  


					// 2-3 Ｍ１フェイスＮｏ、Ｍ１棚段
					//       棚卸確定TBLを検索し、存在していた場合、警告メッセージを表示する。  

					for (int i = 0; i < m1List.Count; i++)
					{
						Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];

						if (m1formVO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							if (Chk_FaceTanada(facadeContext, formVO, m1formVO))
							{
								InfoMsgCls.AddWarnMsg("W100", string.Empty, facadeContext);
							}

							if (InfoMsgCls.HasWarn(facadeContext))
							{
								break;
							}
						}
					}

					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}

					#endregion

				}

                #region 3. 入力値チェック

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];

					if (m1formVO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
                    {
                        // 3-1 訂正数量
                        //       入力数量との合計が7桁以上の場合、エラー 
						decimal dNyuryokusuu = Convert.ToDecimal(m1formVO.M1tensutanaorosinyuryoku_su);
						decimal dTeiseisuu   = Convert.ToDecimal(m1formVO.M1tensutanaorositeisei_su);
                       
                        if (Convert.ToString(dNyuryokusuu + dTeiseisuu).Length >= 7)
                        {
                            ErrMsgCls.AddErrMsg("E108",
												new[] { "入力数量との合計", "6" },
												facadeContext,
												new[] { "M1tensutanaorositeisei_su" },
												(String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1ROWNO],
												i.ToString(),
												"M1");
                            break;
                        }
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 3. 排他チェック

                StringBuilder sRepSql = new StringBuilder();

                sRepSql.Append(" AND TENPO_CD      = :BIND_TENPO_CD");
                sRepSql.Append(" AND FACE_NO       = :BIND_FACE_NO");
                sRepSql.Append(" AND TANA_DAN      = :BIND_TANA_DAN");
                sRepSql.Append(" AND KAI_SU        = :BIND_KAI_SU");
                sRepSql.Append(" AND TANAOROSI_YMD = :BIND_TANAOROSI_YMD");
                sRepSql.Append(" AND SOSINKAI_SU   = :BIND_SOSINKAI_SU");

                ArrayList bindList = null;
                BindInfoVO bindVO = null;

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];

                    if ((BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Stkmodeno)) &&
						 m1formVO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)) ||
						(BoSystemConstant.MODE_DEL.Equals(BoSystemString.Nvl(formVO.Stkmodeno)) &&
						 m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)))
                    {
                        bindList = new ArrayList();
                        bindVO   = new BindInfoVO();

                        // 店舗コード
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_TENPO_CD";
                        bindVO.Value = BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);
                        bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // フェイス№
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_FACE_NO";
                        bindVO.Value = (String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO];
                        bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 棚段
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_TANA_DAN";
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 回数
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_KAI_SU";
                        bindVO.Value  = m1formVO.M1kai_su;
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 棚卸日
                        bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TANAOROSI_YMD";
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 送信回数
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_SOSINKAI_SU";
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);


                        // 排他チェック
                        V03003Check.CheckHaitaMaxVal(
                                Convert.ToDecimal((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1UPD_YMD]),
                                Convert.ToDecimal((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1UPD_TM]),
                                facadeContext,
                                "MDIT0010",
                                sRepSql.ToString(),
                                bindList,
                                1,
                                null,
                                (String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1ROWNO],
                                i.ToString(),
                                "M1",
                                100
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

                #region 更新処理

                // システム日付取得
                SysDateVO sysDateVO = new SysDateVO();
                sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                #region 棚卸基準日の取得

                string strTanaorosikijun_ymd = string.Empty;

                // 棚卸実施日TBLの検索
                Hashtable hsMdit0030 = new Hashtable();
                hsMdit0030 = SearchInventory.SearchMdit0030(BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd),
                                                            sysDateVO.Sysdate.ToString(),
                                                            facadeContext,
                                                            0);
                // 棚卸基準日の設定
                if (hsMdit0030 != null)
                {
                    strTanaorosikijun_ymd = Convert.ToString(hsMdit0030["TANAOROSIKIJUN_YMD"]);
                }

                #endregion

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];

					// [選択モードNo]が「照会」の場合
					if (BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Stkmodeno)))
					{
						if (m1formVO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							#region 訂正有無の取得

							string strTeiseiflg = Get_Teiseiflg(facadeContext, formVO, m1formVO);

							#endregion

							#region 回数の取得

							string strKaisu = Get_Kaisu(facadeContext, formVO, m1formVO);

							#endregion

							// [棚卸確定TBL(H)]を更新する。
							BoSystemLog.logOut("[棚卸確定TBL(H)]を更新 START");
							int Updcntmdit0010 = Upd_Mdit0010(facadeContext, formVO, m1formVO, logininfo, strTeiseiflg, strKaisu, sysDateVO);
							BoSystemLog.logOut("[棚卸確定TBL(H)]を更新 END");

							// [棚卸確定TBL(B)]を更新する。
							BoSystemLog.logOut("[棚卸確定TBL(B)]を更新 START");
							int Updcntmdit0011 = Upd_Mdit0011(facadeContext, formVO, m1formVO, logininfo, strTeiseiflg, strKaisu, sysDateVO);
							BoSystemLog.logOut("[棚卸確定TBL(B)]を更新 END");

							// [棚卸欠番TBL]を削除する。
							BoSystemLog.logOut("[棚卸欠番TBL]を削除 START");
							int Delcntmdit0040 = Del_Mdit0040(facadeContext, formVO, m1formVO, logininfo, strTanaorosikijun_ymd);
							BoSystemLog.logOut("[棚卸欠番TBL]を削除 END");
 						}
					}
					// [選択モードNo]が「取消」の場合
					else if (BoSystemConstant.MODE_DEL.Equals(BoSystemString.Nvl(formVO.Stkmodeno)))
					{
						if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// [棚卸確定TBL(H)]を削除する。
							BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 START");
							int Delcntmdit0010 = Del_Mdit0010(facadeContext, formVO, m1formVO, logininfo, sysDateVO);
							BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 END");

							// [棚卸確定TBL(B)]を削除する。
							BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 START");
							int Delcntmdit0011 = Del_Mdit0011(facadeContext, formVO, m1formVO, logininfo, sysDateVO);
							BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 END");
						}
					}
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

		#region フェイスＮｏ、棚段の存在チェック
		/// <summary>
		/// フェイスＮｏ、棚段の存在チェックの存在チェックを行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="formVO">一覧画面VO</param>
		/// <param name="m1formVO">一覧画面明細VO</param>
		/// <returns>TRUE or FALSE</returns>
		private bool Chk_FaceTanada(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO)
		{
			bool ret = false;

			// フェイスNo、棚段を変更した行のみチェックする
			if (m1formVO.M1face_no.Equals((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO]) &&
				m1formVO.M1tana_dan.Equals((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN]))
			{
				return false;
			}


			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 検索条件設定
			// 店舗コードのバインド
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
			// フェイス№のバインド
			reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
			// 棚段のバインド
			reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
			// 棚卸日のバインド
			reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
			// 元フェイス№のバインド
			reader.BindValue("BIND_MOTO_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO], "0")));
			// 元棚段のバインド
			reader.BindValue("BIND_MOTO_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN], "0")));
			// 元回数のバインド
			reader.BindValue("BIND_MOTO_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj090p01Constant.DIC_M1KAI_SU], "0")));

			#region SQL実行

			//検索結果を取得します
			reader.CreateDbCommand();
			IList<Hashtable> tableListcnt = reader.Execute();

			if (logger.IsDebugEnabled)
			{
				BoSystemLog.logOut("SQL: " + reader.LogSql);
			}

			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
			}
			else
			{
				Hashtable resultTbl = tableListcnt[0];
				Decimal dCnt = (Decimal)resultTbl["CNT"];

				// 0件チェック
				if (dCnt > 0)
				{
					ret = true;
				}
			}

			#endregion

			return ret;
		}
		#endregion

        #region 訂正有無の取得
        /// <summary>
        /// 訂正有無の取得する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="m1formVO">一覧画面選択行のVO</param>
        /// <returns>訂正フラグ</returns>
        private string Get_Teiseiflg(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO)
        {
            string retTeiseiflg = "0";

            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_09, facadeContext.DBContext);

            // 検索条件設定
            // 店舗コードのバインド
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
            // フェイス№のバインド
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO].ToString(), "0")));
            // 棚段のバインド
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN].ToString(), "0")));
            // 回数のバインド
            reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日のバインド
            reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
            // 送信回数のバインド
            reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

            #region SQL実行

            //検索結果を取得します
            reader.CreateDbCommand();
            IList<Hashtable> tableListcnt = reader.Execute();

            if (logger.IsDebugEnabled)
            {
				BoSystemLog.logOut("SQL: " + reader.LogSql);
            }

            if (tableListcnt == null || tableListcnt.Count <= 0)
            {
                // 訂正なし
                retTeiseiflg = "0";
            }
            else
            {
                Hashtable resultTbl = tableListcnt[0];
                Decimal dTeiseiCnt = (Decimal)resultTbl["CNT"];

                // 0件チェック
                if (dTeiseiCnt <= 0)
                {
                    // 訂正なし
                    retTeiseiflg = "0";
                }
                else
                {
                    // 訂正あり
                    retTeiseiflg = "1";
                }
            }            
            
            #endregion


            return retTeiseiflg;
        }
        #endregion

		#region 回数の取得
		/// <summary>
		/// 回数を取得する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="formVO">明細画面VO</param>
		/// <param name="m1formVO">一覧画面選択行のVO</param>
		/// <returns>訂正フラグ</returns>
		private string Get_Kaisu(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO)
		{
			string retKaisu = "0";

			// フェイスNo,棚段に変更ない場合、画面の回数とする
			if (m1formVO.M1face_no.Equals((String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO]) &&
				m1formVO.M1tana_dan.Equals((String)m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN]))
			{
				// 画面の回数
				retKaisu = m1formVO.M1kai_su;
			}
			else
			{
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_10, facadeContext.DBContext);

				// 検索条件設定
				// 店舗コードのバインド
				reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
				// フェイス№のバインド
				reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
				// 棚段のバインド
				reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
				// 棚卸日のバインド
				reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
				// 送信回数のバインド
				reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

				#region SQL実行

				//検索結果を取得します
				reader.CreateDbCommand();
				IList<Hashtable> tableListcnt = reader.Execute();

				if (logger.IsDebugEnabled)
				{
					BoSystemLog.logOut("SQL: " + reader.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// 画面の回数
					retKaisu = m1formVO.M1kai_su;
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];

					if (String.IsNullOrEmpty(resultTbl["KAI_SU"].ToString()))
					{
						// 画面の回数
						retKaisu = m1formVO.M1kai_su;
					}
					else
					{
						retKaisu = Convert.ToString((Decimal)resultTbl["KAI_SU"] + 1);
					}
				}

				#endregion
			}

			return retKaisu;
		}
		#endregion

        #region [棚卸確定TBL(H)]を更新する。
        /// <summary>
        /// [棚卸確定TBL(H)]を更新する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="m1formVO">一覧画面選択行のVO</param>
        /// <param name="loginInfo">ログイン情報</param>
		/// <param name="prmTeiseiflg">訂正有無</param>
		/// <param name="prmKaisu">回数</param>
		/// <param name="sysDateVO">システム日付</param>
        /// <returns>更新件数</returns>
        private int Upd_Mdit0010(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO, LoginInfoVO loginInfo, String prmTeiseiflg, String prmKaisu, SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_04, facadeContext.DBContext);

            // フェイス№
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
			// 回数
			reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prmKaisu, "0")));
            // 点数棚卸訂正数
			reader.BindValue("BIND_TENSUTANATEISEI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tensutanaorositeisei_su, "0")));
            // 点数棚卸合計数
            reader.BindValue("BIND_TENSUTANAGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tensutanaorosigokei_su, "0")));
            // 棚卸スキャン数量
            reader.BindValue("BIND_TANAOROSISCAN_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1scan_su, "0")));
            // 棚卸訂正数量
            reader.BindValue("BIND_TANAOROSITEISEI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1teisei_suryo, "0")));
            // 棚卸合計数量
            reader.BindValue("BIND_TANAOROSIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1gokei_suryo, "0")));

            // 差異フラグ
            if (Convert.ToDecimal(m1formVO.M1tensutanaorosigokei_su) != Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1gokei_suryo, "0")))
            {
                reader.BindValue("BIND_SAI_FLG", 1);
            }
            else
            {
                reader.BindValue("BIND_SAI_FLG", 0);
            }

            // 訂正フラグ
			reader.BindValue("BIND_TEISEI_FLG", Convert.ToDecimal(BoSystemString.Nvl(prmTeiseiflg, "0")));

            // 更新日
            reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
            // 更新時間
            reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
            // 更新担当者コード
            reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
            // 削除日
            reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

            // 元フェイス№
            reader.BindValue("BIND_MOTO_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO].ToString(), "0")));
            // 元棚段
            reader.BindValue("BIND_MOTO_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN].ToString(), "0")));
            // 元回数
            reader.BindValue("BIND_MOTO_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su)));


            // WHERE句
            // 店舗コードのバインド
            reader.BindValue("BIND_WHERE_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
            // フェイス№のバインド
            reader.BindValue("BIND_WHERE_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO].ToString(), "0")));
            // 棚段のバインド
            reader.BindValue("BIND_WHERE_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN].ToString(), "0")));
            // 回数のバインド
            reader.BindValue("BIND_WHERE_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日のバインド
            reader.BindValue("BIND_WHERE_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
            // 送信回数のバインド
            reader.BindValue("BIND_WHERE_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));


            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

		#region [棚卸確定TBL(B)]を更新する。
		/// <summary>
		/// [棚卸確定TBL(B)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="formVO">明細画面VO</param>
		/// <param name="m1formVO">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="prmTeiseiflg">訂正有無</param>
		/// <param name="prmKaisu">回数</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <returns>更新件数</returns>
		private int Upd_Mdit0011(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO, LoginInfoVO loginInfo, String prmTeiseiflg, String prmKaisu, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_11, facadeContext.DBContext);

			// フェイス№
			reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
			// 棚段
			reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
			// 回数
			reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prmKaisu, "0")));


			// WHERE句
			// 店舗コードのバインド
			reader.BindValue("BIND_WHERE_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
			// フェイス№のバインド
			reader.BindValue("BIND_WHERE_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1FACE_NO].ToString(), "0")));
			// 棚段のバインド
			reader.BindValue("BIND_WHERE_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN].ToString(), "0")));
			// 回数のバインド
			reader.BindValue("BIND_WHERE_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
			// 棚卸日のバインド
			reader.BindValue("BIND_WHERE_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
			// 送信回数のバインド
			reader.BindValue("BIND_WHERE_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

        #region [棚卸欠番TBL]を削除する。
        /// <summary>
        /// [棚卸欠番TBL]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="m1formVO">一覧画面選択行のVO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <param name="prmTanaorosikijun_ymd">棚卸基準日</param>
        /// <returns>更新件数</returns>
        private int Del_Mdit0040(IFacadeContext facadeContext, Tj090f01Form formVO, Tj090f01M1Form m1formVO, LoginInfoVO loginInfo, String prmTanaorosikijun_ymd)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_05, facadeContext.DBContext);

            // 店舗コードのバインド
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
            // 棚卸基準日のバインド
			reader.BindValue("BIND_TANAOROSIKIJUN_YMD", Convert.ToDecimal(BoSystemString.Nvl(prmTanaorosikijun_ymd, "0")));
            // フェイス№のバインド
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));

            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region [棚卸確定TBL(H)]を削除する。
        /// <summary>
        /// [棚卸確定TBL(H)]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">一覧画面のVO</param>
        /// <param name="m1formVO">一覧画面選択行のVO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <param name="sysDateVO">システム日付情報</param>
        /// <returns>更新件数</returns>
        private int Del_Mdit0010(IFacadeContext facadeContext,
                                 Tj090f01Form formVO,
                                 Tj090f01M1Form m1formVO,
                                 LoginInfoVO loginInfo,
                                 SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_06, facadeContext.DBContext);

            // 店舗コード
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
            // フェイス№
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
            // 回数
            reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日
            reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
            // 送信回数
            reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

            // クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region [棚卸確定TBL(B)]を削除する。
        /// <summary>
        /// [棚卸確定TBL(B)]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">一覧画面のVO</param>
        /// <param name="m1formVO">一覧画面選択行のVO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <param name="sysDateVO">システム日付情報</param>
        /// <returns>更新件数</returns>
        private int Del_Mdit0011(IFacadeContext facadeContext,
                                 Tj090f01Form formVO,
                                 Tj090f01M1Form m1formVO,
                                 LoginInfoVO loginInfo,
                                 SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_07, facadeContext.DBContext);

            // 店舗コード
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]));
            // フェイス№
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1face_no, "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
            // 回数
            reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日
            reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
            // 送信回数
			reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

            // クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
	}
}
