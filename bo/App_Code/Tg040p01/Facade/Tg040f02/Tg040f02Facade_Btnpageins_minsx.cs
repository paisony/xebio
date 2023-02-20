using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f02Facade : StandardBaseFacade
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
			////M1明細リストを取得
			Tg040f02Form tg040f02Form = (Tg040f02Form)facadeContext.FormVO;
			IDataList m1List = tg040f02Form.GetList("M1");
			//明細フォーカスセット用インデックスをセットします。
			facadeContext.SetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX, GetDetailFocusIndex(m1List));

			//1度に追加する行数を設定します。
			int addCount = m1List.DispRow; ;
			//表示している件数を取得
			int rowCount = m1List.Count;
			//表示後件数
			int afterCount = addCount + rowCount;

			////1度に追加する行数を設定します。
			//int addCount = DEFAULTADDROWCOUNT;
			//for (int i = 0; i < addCount; i++)
			//{
			//	//行オブジェクトを生成し、リストに追加する。
			//	Tg040f02M1Form tg040f02M1Form = new Tg040f02M1Form();
			//	tg040f02M1Form.Commode = DbuModeCode.INSERT;
			//	m1List.Add(tg040f02M1Form, true);
			//}
			//SetPageIndex(m1List, addCount);

			#region 件数チェック
			// コンフィグファイルより最大件数を取得
			Decimal dMaxCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			// 明細数が最大行数の場合、エラー
			if (m1List.Count >= dMaxCnt)
			{
				//「最大行数です。これ以上は追加できません。」
				ErrMsgCls.AddErrMsg("E147", String.Empty, facadeContext);
			}

			// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion

			// 行追加
			AddRowCls.AddEmptyRow<Tg040f02M1Form>("M1", "M1rowno", (Tg040f02Form)facadeContext.FormVO, addCount);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
