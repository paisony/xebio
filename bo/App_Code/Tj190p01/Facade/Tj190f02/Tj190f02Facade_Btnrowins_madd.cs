using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f02Facade : StandardBaseFacade
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
			Tj190f02Form tj190f02Form = (Tj190f02Form)facadeContext.FormVO;
			IDataList m1List = tj190f02Form.GetList("M1");

			// 最大件数チェック
			decimal curCnt = ((Tj190f02Form)facadeContext.FormVO).GetList("M1").Count;
			decimal maxCnt = GetMaxCntCls.GetMaxCnt(FORMID.ToUpper());

			if (curCnt.Equals(maxCnt))
			{
				// 現在明細行数＝最大行数の場合
				ErrMsgCls.AddErrMsg("E147", string.Empty, facadeContext);
			}

			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}

			// 行追加
			AddRowCls.AddEmptyRow<Tj190f02M1Form>("M1", "M1rowno", (Tj190f02Form)facadeContext.FormVO, 1);

			//行オブジェクトを生成し、リストに追加する。
			//Tj190f02M1Form tj190f02M1Form = new Tj190f02M1Form();
			//tj190f02M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(tj190f02M1Form, true);
			//m1List.SetBtmPage();

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
