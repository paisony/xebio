using com.xebio.bo.Ta010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f02Facade : StandardBaseFacade
	{
		#region M1明細の行を一括で増やします。(ボタンID : Btnpageins)
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnpageins)
		/// アクションID(MINSX)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPAGEINS_MINSX(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");
			//M1明細リストを取得
			Ta010f02Form ta010f02Form = (Ta010f02Form)facadeContext.FormVO;
			IDataList m1List = ta010f02Form.GetList("M1");
			//明細フォーカスセット用インデックスをセットします。
			facadeContext.SetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX, GetDetailFocusIndex(m1List));

			//1度に追加する行数を設定します。
			int addCount = m1List.DispRow;
			//表示している件数を取得
			int rowCount = m1List.Count;
			//表示後件数
			int afterCount = addCount + rowCount;
			#region 件数チェック
			ChkDetailCount(facadeContext, Convert.ToDecimal(afterCount));
			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion
			// 初期値設定
			Hashtable defVal = new Hashtable();

			// 1ページ分の行数を追加
			AddRowCls.AddEmptyRow<Ta010f02M1Form>("M1", "M1rowno", (Ta010f02Form)facadeContext.FormVO, m1List.DispRow, defVal);

			// 表示ページ設定
			int dispPageNo = afterCount / m1List.DispRow;
			m1List.SetPage(dispPageNo);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
