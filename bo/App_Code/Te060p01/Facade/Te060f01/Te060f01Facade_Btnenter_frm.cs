using com.xebio.bo.Te060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Te060p01.Facade
{
  /// <summary>
  /// Te060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te060f01Facade : StandardBaseFacade
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
				Te060f01Form f01VO = (Te060f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion
				#region 業務チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 単項目チェック
				ChkUpdSingleItem ( facadeContext, f01VO, sysDateVO );
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                // 排他チェック
				ChkUpdHaita ( facadeContext, m1List );
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 更新処理
				int iUpdSelCnt = 0;
				foreach (Te060f01M1Form f01m1VO in m1List.ListData)
				{
					// 対象行のみ実施
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [再入荷防止TBL]を更新する。
						BoSystemLog.logOut("[再入荷防止TBL]を更新[MODE=" + f01VO.Modeno +"] START");
						int updcnt = Upd_SaiNyuKa(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO.Modeno, f01VO.Stop_ymd);
						BoSystemLog.logOut("[再入荷防止TBL]を更新 END");
					}
					iUpdSelCnt++;
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
