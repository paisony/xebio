using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f02Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				Tj190f02Form tj190f02Form = (Tj190f02Form)facadeContext.FormVO;
				IDataList m1List = tj190f02Form.GetList("M1");

				// 合計計算用ロジック
				ArrayList alList = new ArrayList();
				// 合計棚時帳簿数
				string[] goukeitanajityobo_su = { "M1tanajityobo_su", "Gokeitanajityobo_su" };
				alList.Add(goukeitanajityobo_su);
				// 合計棚時積送数
				string[] gokeitanajisekiso_su = { "M1tanajisekiso_su", "Gokeitanajisekiso_su" };
				alList.Add(gokeitanajisekiso_su);
				// 合計実棚数
				string[] gokeijitana_su = { "M1jitana_su", "Gokeijitana_su" };
				alList.Add(gokeijitana_su);
				// 合計ロス数
				string[] gokeiloss_su = { "M1loss_su", "Gokeiloss_su" };
				alList.Add(gokeiloss_su);
				// 合計ロス金額
				string[] gokeiloss_kin = { "M1loss_kin", "Gokeiloss_kin" };
				alList.Add(gokeiloss_kin);

				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Tj190f02Form, Tj190f02M1Form>("M1", "M1rowno", (Tj190f02Form)facadeContext.FormVO, alList);

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
				facadeContext.SetUserObject(Tj190p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
