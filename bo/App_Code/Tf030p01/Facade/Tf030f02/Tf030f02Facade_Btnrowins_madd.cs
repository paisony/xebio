using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f02Facade : StandardBaseFacade
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
			Tf030f02Form tf030f02Form = (Tf030f02Form)facadeContext.FormVO;
			IDataList m1List = tf030f02Form.GetList("M1");
	
			////行オブジェクトを生成し、リストに追加する。
			//Tf030f02M1Form tf030f02M1Form = new Tf030f02M1Form();
			//tf030f02M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(tf030f02M1Form, true);
			//m1List.SetBtmPage();

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

			// 空行追加
			AddRowCls.AddEmptyRow<Tf030f02M1Form>("M1", "M1rowno", (Tf030f02Form)facadeContext.FormVO, 1);

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
