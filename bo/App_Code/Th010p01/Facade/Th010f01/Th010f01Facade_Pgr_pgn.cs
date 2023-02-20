using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f01Facade : StandardBaseFacade
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
			
			Th010f01Form th010f01Form = (Th010f01Form)facadeContext.FormVO;
			th010f01Form.GetList("M1").SetPage(pageIndex);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoPGR_PGN");

		}
		#endregion
	}
}
