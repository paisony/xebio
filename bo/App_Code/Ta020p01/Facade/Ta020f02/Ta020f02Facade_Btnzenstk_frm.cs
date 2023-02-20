using com.xebio.bo.Ta020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Ta020p01.Facade
{
  /// <summary>
  /// Ta020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta020f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnzenstk)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenstk)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENSTK_FRM(IFacadeContext facadeContext)
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

			try
			{
				//	//DBコンテキストを設定する。
				//	SetDBContext(facadeContext);
				//	//コネクションを取得して、トランザクションを開始する。
				//	BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				Ta020f02Form f02VO = (Ta020f02Form)facadeContext.FormVO;
				foreach (Ta020f02M1Form f02m1VO in f02VO.GetList("M1").ListData)
				{
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
				}

				//	//トランザクションをコミットする。
				//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//	//トランザクションをロールバックする。
				//	RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//	//コネクションを開放する。
				//	CloseConnection(facadeContext);
				//}
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

		}
		#endregion
	}
}
