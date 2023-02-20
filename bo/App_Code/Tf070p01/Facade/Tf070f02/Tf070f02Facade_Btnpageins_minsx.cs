using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f02Facade : StandardBaseFacade
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
			Tf070f02Form tf070f02Form = (Tf070f02Form)facadeContext.FormVO;
			IDataList m1List = tf070f02Form.GetList("M1");
			//明細フォーカスセット用インデックスをセットします。
			facadeContext.SetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX, GetDetailFocusIndex(m1List));

			////1度に追加する行数を設定します。
			//int addCount = DEFAULTADDROWCOUNT;
			//for (int i = 0; i < addCount; i++)
			//{
			//	//行オブジェクトを生成し、リストに追加する。
			//	Tf070f02M1Form tf070f02M1Form = new Tf070f02M1Form();
			//	tf070f02M1Form.Commode = DbuModeCode.INSERT;
			//	m1List.Add(tf070f02M1Form, true);
			//}
			//SetPageIndex(m1List, addCount);

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			#region 業務チェック
			// 件数チェック
			// 1-1 明細数
			// 明細数が最大行数の場合、エラー
			decimal curCnt = m1List.Count;
			decimal maxCnt = GetMaxCntCls.GetMaxCnt(FORMID.ToUpper(), Tf070p01Constant.MAX_CNT_EDABAN_SHINKI);

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
			#endregion

			//1度に追加する行数を設定します。
			int addCount = m1List.DispRow;

			// 行追加処理
			AddRowCls.AddEmptyRow<Tf070f02M1Form>("M1", "M1rowno", (Tf070f02Form)facadeContext.FormVO, addCount);

			// 表示ページ設定
			m1List.SetPage(m1List.PageCount);
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
