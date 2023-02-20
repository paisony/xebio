using com.xebio.bo.Ta020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Ta020p01.Facade
{
  /// <summary>
  /// Ta020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta020f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnzenstk)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenstk)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENSTK_FRM ( IFacadeContext facadeContext )
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

			try
			{
				Ta020f01Form f01VO = (Ta020f01Form)facadeContext.FormVO;
				foreach (Ta020f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
				{
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
				}
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");
		}
		#endregion
	}
}
