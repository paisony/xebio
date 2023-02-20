using com.xebio.bo.Ti040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Ti040p01.Facade
{
  /// <summary>
  /// Ti040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ti040f01Facade : StandardBaseFacade
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
            Ti040f01Form ti040f01Form = (Ti040f01Form)facadeContext.FormVO;
            IDataList m1List = ti040f01Form.GetList("M1");
	
            // 最大件数チェック
            V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), m1List.Count + 1, facadeContext);

            //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
            if (MessageDisplayUtil.HasError(facadeContext))
            {
                return;
            }

            AddRowCls.AddEmptyRow<Ti040f01M1Form>("M1", "M1rowno", (Ti040f01Form)facadeContext.FormVO, 1);

            // 検索件数の設定
            ti040f01Form.Searchcnt = m1List.Count.ToString();

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
