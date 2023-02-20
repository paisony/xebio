using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Advanced.Util;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
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
			Tg010f01Form tg010f01Form = (Tg010f01Form)facadeContext.FormVO;
			IDataList m1List = tg010f01Form.GetList("M1");
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
			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion

			for (int i = 0; i < addCount; i++)
			{
				//行オブジェクトを生成し、リストに追加する。
				Tg010f01M1Form tg010f01M1Form = new Tg010f01M1Form();
				tg010f01M1Form.Commode = DbuModeCode.INSERT;
				tg010f01M1Form.M1rowno = (rowCount + i + 1).ToString();
				m1List.Add(tg010f01M1Form, true);
			}

			// 検索件数更新
			tg010f01Form.Searchcnt = afterCount.ToString();

			SetPageIndex(m1List, addCount);


			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
