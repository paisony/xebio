using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
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
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f01Facade : StandardBaseFacade
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
                Tj040f01Form formVO = (Tj040f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 業務チェック

                #region 1. 選択チェック

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
                        Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1List[i];
                        if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                        {
                            inputflg = 1;
                            break;
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

                #region 2. 単項目チェック

                // 2-1 ヘッダ店舗コード
                //       モードが取消の場合、棚卸終了の場合エラー                
				if (BoSystemConstant.MODE_DEL.Equals(formVO.Stkmodeno))
                {
                    // 営業日の取得
                    SysDateVO chkSysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                    // 棚卸実施日TBLの検索
                    string retTanaorosisyuryo_flg = SearchInventory.CheckInventoryEnd(BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]),
																					  (String)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSIKIJUN_YMD],
                                                                                      facadeContext,
                                                                                      1);
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

                ArrayList  bindList = null;
                BindInfoVO bindVO   = null;

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1List[i];

                    if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                    {
                        bindList = new ArrayList();
                        bindVO   = new BindInfoVO();

                        // 店舗コード
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_TENPO_CD";
                        bindVO.Value = BoSystemFormat.formatTenpoCd((String)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
                        bindVO.Type   = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // フェイス№
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_FACE_NO";
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj040p01Constant.DIC_M1FACE_NO];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 棚段
                        bindVO = new BindInfoVO();
                        bindVO.BindId = "BIND_TANA_DAN";
                        bindVO.Value  = m1formVO.M1tana_dan;
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
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);

                        // 送信回数
                        bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SOSINKAI_SU";
                        bindVO.Value  = (String)m1formVO.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU];
                        bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                        bindList.Add(bindVO);


                        // 排他チェック
                        V03003Check.CheckHaitaMaxVal(
                                Convert.ToDecimal((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1UPD_YMD]),
                                Convert.ToDecimal((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1UPD_TM]),
                                facadeContext,
                                "MDIT0010",
                                sRepSql.ToString(),
                                bindList,
                                1,
                                null,
                                m1formVO.M1rowno,
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

				for (int i = 0; i < m1List.Count; i++)
				{
                    Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1List[i];

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
                                 Tj040f01Form formVO,
                                 Tj040f01M1Form m1formVO,
                                 LoginInfoVO loginInfo,
                                 SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_06, facadeContext.DBContext);

            // 店舗コード
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
            // フェイス№
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1FACE_NO], "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
            // 回数
			reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日
			reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD], "0")));
            // 送信回数
			reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU], "0")));

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
                                 Tj040f01Form formVO,
                                 Tj040f01M1Form m1formVO,
                                 LoginInfoVO loginInfo,
                                 SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_07, facadeContext.DBContext);

            // 店舗コード
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
            // フェイス№
			reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1FACE_NO], "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1tana_dan, "0")));
            // 回数
            reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1kai_su, "0")));
            // 棚卸日
			reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD], "0")));
            // 送信回数
			reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU], "0")));

            // クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
