using com.xebio.bo.Tm030p01.Constant;
using com.xebio.bo.Tm030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tm030p01.Facade
{
  /// <summary>
  /// Tm030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnprint)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

				#region 初期化
				// ログイン情報取得
				LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

				// システム日付情報取得
				SysDateVO sysdateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tm030f01Form f01VO = (Tm030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 更新処理

				for (int i = 0; i < m1List.Count; i++)
				{
					Tm030f01M1Form m1Form = (Tm030f01M1Form)m1List[i];

					switch ((string)m1Form.Dictionary[Tm030p01Constant.DIC_M1TYOHYO_ID])
					{
						case Tm030p01Constant.LIST_ID_TD060L01:

							// [返品指示変更履歴TBL]を更新する。
							BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 START");
							Upd_MDRT0060(facadeContext, loginInfo, sysdateVO);
							BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 END");
							break;
						case Tm030p01Constant.LIST_ID_TE030L01:

							// [移動出荷差異リスト]を更新する。
							BoSystemLog.logOut("[移動出荷差異リスト]を更新 START");
							Upd_MDNT0030(facadeContext, loginInfo, sysdateVO);
							BoSystemLog.logOut("[移動出荷差異リスト]を更新 END");
							break;
						case Tm030p01Constant.LIST_ID_TG050L01:

							// [エラー品番TBL]を更新する。
							BoSystemLog.logOut("[エラー品番TBL]を更新 START");
							Upd_MDBT0080(facadeContext, loginInfo, sysdateVO);
							BoSystemLog.logOut("[エラー品番TBL]を更新 END");
							break;
						case Tm030p01Constant.LIST_ID_TG070L01:

							// [インストアコード振替データTBL]を更新する。
							BoSystemLog.logOut("[インストアコード振替データTBL]を更新 START");
							Upd_MDBT0090(facadeContext, loginInfo, sysdateVO);
							BoSystemLog.logOut("[インストアコード振替データTBL]を更新 END");
							break;
						default:
							break;
					}
				}
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

		}
		#endregion
	}
}
