using com.xebio.bo.Tj040p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f02Facade : StandardBaseFacade
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
			
			Tj040f02Form tj040f02Form = (Tj040f02Form)facadeContext.FormVO;
			tj040f02Form.GetList("M1").SetPage(pageIndex);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoPGR_PGN");

		}
		#endregion
	}
}
