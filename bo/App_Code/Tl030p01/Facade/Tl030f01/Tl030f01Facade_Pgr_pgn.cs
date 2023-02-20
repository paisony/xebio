using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f01Facade : StandardBaseFacade
	{
		#region M1明細部のページング処理を行います。(ボタンID : Pgr)
		/// <summary>
		/// M1明細部のページング処理を行います。
		/// ボタンID(Pgr)
		/// アクションID(PGN)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="pageIndex">ページインデックス</param>
		public void DoPGR_PGN(IFacadeContext facadeContext, int pageIndex)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoPGR_PGN");
			
			Tl030f01Form tl030f01Form = (Tl030f01Form)facadeContext.FormVO;
			tl030f01Form.GetList("M1").SetPage(pageIndex);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoPGR_PGN");

		}
		#endregion
	}
}
