using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using com.xebio.bo.Td050p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td050f01Facade : StandardBaseFacade
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

                #region 初期化

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Td050f01Form f01VO = (Td050f01Form)facadeContext.FormVO;
                IDataList m1List = f01VO.GetList("M1");

                #endregion
				#region 業務チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 排他チェック
				ChkUpdHaita(facadeContext, m1List);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
                #region 更新処理
                // システム日付取得
                SysDateVO sysDateVO = new SysDateVO();
                sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                for (int i = 0; i < m1List.Count; i++)
                {
                    Td050f01M1Form f01m1VO = (Td050f01M1Form)m1List[i];
                    if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                    {
                        #region  赤伝票で検索
                        // [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
                        BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 START");
						int Inscntrirekih_aka = Td050p01Util.Ins_HenpinRirekih(facadeContext, f01m1VO, logininfo, sysDateVO, true, Td050p01Constant.SYORI_SB_TEISEI_DEL, Convert.ToDecimal(f01m1VO.M1aka_denpyo_bango));
                        BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 END");

                        // [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
                        BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 START");
						int Inscntrirekib_aka = Td050p01Util.Ins_HenpinRirekib(facadeContext, f01m1VO, logininfo, sysDateVO, true, Convert.ToDecimal(f01m1VO.M1aka_denpyo_bango));
                        BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 END");
                        #endregion
                        #region  黒伝票で検索
                        // [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
                        BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 START");
						int Inscntrirekih_kuro = Td050p01Util.Ins_HenpinRirekih(facadeContext, f01m1VO, logininfo, sysDateVO, true, Td050p01Constant.SYORI_SB_TEISEI_DEL, Convert.ToDecimal(f01m1VO.M1kuro_denpyo_bango));
                        BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 END");

                        // [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
                        BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 START");
						int Inscntrirekib_kuro = Td050p01Util.Ins_HenpinRirekib(facadeContext, f01m1VO, logininfo, sysDateVO, true, Convert.ToDecimal(f01m1VO.M1kuro_denpyo_bango));
                        BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 END");
                        #endregion

                        // [返品確定TBL(B)]を削除する。(元伝票)
                        BoSystemLog.logOut("[返品確定TBL(B)]を削除 START");
						int Delcnkakuteib = Del_HenpinKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, Convert.ToDecimal((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO]));
                        BoSystemLog.logOut("[返品確定TBL(B)]を削除 END");
                        // [返品確定TBL(H)]を削除する。(元伝票)
                        BoSystemLog.logOut("[返品確定TBL(H)]を削除 START");
						int Delcnkakuteih = Del_HenpinKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, Convert.ToDecimal((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO]));
                        BoSystemLog.logOut("[返品確定TBL(H)]を削除 END");

                        // [返品確定TBL(H)]を更新する。
                        BoSystemLog.logOut("[返品確定TBL(H)]を更新 START");
						int Inscnth = Td050p01Util.Upd_HenpinKakuteih(facadeContext, f01m1VO, logininfo, sysDateVO, true, Convert.ToDecimal((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO]));
                        BoSystemLog.logOut("[返品確定TBL(H)]を更新 END");

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

    }
}
