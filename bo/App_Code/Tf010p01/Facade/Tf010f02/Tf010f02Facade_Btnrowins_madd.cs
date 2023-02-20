using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f02Facade : StandardBaseFacade
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
			Tf010f02Form tf010f02Form = (Tf010f02Form)facadeContext.FormVO;
			IDataList m1List = tf010f02Form.GetList("M1");

			#region 件数チェック

			//1度に追加する行数を設定します。
			int addCount = 1;
			//表示している件数を取得
			int rowCount = m1List.Count;
			//表示後件数
			int afterCount = addCount + rowCount;

			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			if (Convert.ToDecimal(afterCount) > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}

			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}

			#endregion

			// 行追加
			AddRowCls.AddEmptyRow<Tf010f02M1Form>("M1", "M1rowno", (Tf010f02Form)facadeContext.FormVO, addCount);

			////行オブジェクトを生成し、リストに追加する。
			//Tf010f02M1Form tf010f02M1Form = new Tf010f02M1Form();
			//tf010f02M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(tf010f02M1Form, true);
			//m1List.SetBtmPage();

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
