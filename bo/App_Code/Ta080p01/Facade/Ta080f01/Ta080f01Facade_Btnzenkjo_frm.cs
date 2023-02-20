using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnzenkjo)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenkjo)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENKJO_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

			try
			{
				//	//DBコンテキストを設定する。
				//	SetDBContext(facadeContext);
				//	//コネクションを取得して、トランザクションを開始する。
				//	BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				Ta080f01Form f01VO = (Ta080f01Form)facadeContext.FormVO;
				foreach (Ta080f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
				{
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
				}

				//	//トランザクションをコミットする。
				//	CommitTransaction(facadeContext);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

		}
		#endregion
	}
}
