using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f02Facade : StandardBaseFacade
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
			//Td010f02Form td010f02Form = (Td010f02Form)facadeContext.FormVO;
			//IDataList m1List = td010f02Form.GetList("M1");
	
			////行オブジェクトを生成し、リストに追加する。
			//Td010f02M1Form td010f02M1Form = new Td010f02M1Form();
			//td010f02M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(td010f02M1Form, true);
			//m1List.SetBtmPage();

			//Hashtable ht = new Hashtable();
			//ht.Add("M1suryo", "0");
			//ht.Add("M1scan_cd", "123");
			//AddRowCls.AddEmptyRow<Td010f02M1Form>("M1", "M1rowno", (Td010f02Form)facadeContext.FormVO, 2, ht);

			#region 業務チェック
			// 1-1 明細数が最大行数の場合、エラー
			decimal maxCnt = GetMaxCntCls.GetMaxCnt(Td010p01Constant.FORMID_02.ToUpper());
			if (((Td010f02Form)facadeContext.FormVO).GetList("M1").Count >= maxCnt)
			{
				// 最大行数です。これ以上は追加できません。
				ErrMsgCls.AddErrMsg("E147", string.Empty, facadeContext);
			}

			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion

			#region 行追加処理
			AddRowCls.AddEmptyRow<Td010f02M1Form>("M1", "M1rowno", (Td010f02Form)facadeContext.FormVO, 1);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");
			#endregion
		}
		#endregion
	}
}
