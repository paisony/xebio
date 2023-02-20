using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
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
			Ta080f03Form ta080f03Form = (Ta080f03Form)facadeContext.FormVO;
			IDataList m1List = ta080f03Form.GetList("M1");
			//明細フォーカスセット用インデックスをセットします。
			facadeContext.SetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX, GetDetailFocusIndex(m1List));

			//1度に追加する行数を設定します。
			int addCount = m1List.DispRow;
			//表示している件数を取得
			int rowCount = m1List.Count;
			//表示後件数
			int afterCount = addCount + rowCount;
			#region 件数チェック
			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			if (Convert.ToDecimal(afterCount) > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}
			#endregion
			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			// 初期値設定
			Hashtable defVal = new Hashtable();

			// 1ページ分の行数を追加
			AddRowCls.AddEmptyRow<Ta080f03M1Form>("M1", "M1rowno", (Ta080f03Form)facadeContext.FormVO, m1List.DispRow, defVal);

			// 表示ページ設定
			int dispPageNo = afterCount / m1List.DispRow;
			m1List.SetPage(dispPageNo);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
