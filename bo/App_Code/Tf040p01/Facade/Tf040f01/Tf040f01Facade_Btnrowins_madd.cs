using com.xebio.bo.Tf040p01.Constant;
using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using System.Collections;

namespace com.xebio.bo.Tf040p01.Facade
{
  /// <summary>
  /// Tf040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf040f01Facade : StandardBaseFacade
	{
		#region M1明細の行を増やします。(ボタンID : Btnrowins)
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins)
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNROWINS_MADD(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

			//M1明細リストを取得
			Tf040f01Form tf040f01Form = (Tf040f01Form)facadeContext.FormVO;
			//IDataList m1List = tf040f01Form.GetList("M1");
	
			//行オブジェクトを生成し、リストに追加する。
			//Tf040f01M1Form tf040f01M1Form = new Tf040f01M1Form();
			//tf040f01M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(tf040f01M1Form, true);
			//m1List.SetBtmPage();
			
			// 初期値設定
			Hashtable defVal = new Hashtable();
			defVal["M1keijo_ymd"] = tf040f01Form.Dictionary[Tf040p01Constant.DIC_SYSDATE].ToString(); // システム日付

			AddRowCls.AddEmptyRow<Tf040f01M1Form>("M1", "M1rowno", (Tf040f01Form)facadeContext.FormVO, 1, defVal);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
