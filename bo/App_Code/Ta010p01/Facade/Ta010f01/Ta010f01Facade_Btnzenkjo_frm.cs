using com.xebio.bo.Ta010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

			try
			{
				//以下に業務ロジックを記述する。
				Ta010f01Form f01VO = (Ta010f01Form)facadeContext.FormVO;
				foreach (Ta010f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
				{
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
				}
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

		}
		#endregion
	}
}
