using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
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
		
		#region フォームを呼び出します。(ボタンID : Btnrowdel)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNROWDEL_FRM(IFacadeContext facadeContext)
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

			try
			{
				//M1明細リストを取得
				Ta010f02Form f02Vo = (Ta010f02Form)facadeContext.FormVO;
				IDataList m1List = f02Vo.GetList("M1");

				ArrayList gokeiCalcList = new ArrayList();
				gokeiCalcList.Add(new string[] { "M1irai_su", "Gokei_irai_su" });
				gokeiCalcList.Add(new string[] { "M1genkakin", "Gokei_genkakin" });
				// 行追加フラグ
				int addRowFlg = Convert.ToInt32(Ta010p01Constant.FLG_OFF);
				// 新規作成時は、行追加フラグをＯＮ
				if (BoSystemConstant.MODE_INSERT.Equals(f02Vo.Stkmodeno))
				{
					addRowFlg = Convert.ToInt32(Ta010p01Constant.FLG_ON);
				}
				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Ta010f02Form, Ta010f02M1Form>("M1", "M1rowno", f02Vo, gokeiCalcList, addRowFlg);

				// 削除行が存在しない場合、エラー。
				if (lastRow == -1)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Ta010p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
