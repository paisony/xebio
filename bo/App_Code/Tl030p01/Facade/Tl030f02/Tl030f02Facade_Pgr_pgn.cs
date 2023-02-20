using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f02Facade : StandardBaseFacade
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
			
			Tl030f02Form tl030f02Form = (Tl030f02Form)facadeContext.FormVO;
			tl030f02Form.GetList("M1").SetPage(pageIndex);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoPGR_PGN");

		}
		#endregion
	}
}
