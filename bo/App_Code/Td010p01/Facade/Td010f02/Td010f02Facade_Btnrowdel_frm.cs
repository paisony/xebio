using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Standard.Base;
using System.Collections;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f02Facade : StandardBaseFacade
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
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				
				// 選択行を削除
				ArrayList gokeiCalcList = new ArrayList();
				// 数量の項目を設定
				gokeiCalcList.Add(new string[] { "M1suryo", "Gokei_suryo" });
				// 金額の項目を設定
				gokeiCalcList.Add(new string[] { "M1genkakin", "Genka_kin_gokei" });

				decimal lastRow = DelRowCls.DeleteSelectRow<Td010f02Form, Td010f02M1Form>("M1", "M1rowno", (Td010f02Form)facadeContext.FormVO, gokeiCalcList);
				if (lastRow == -1)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					return;
				}
				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Td010p01Constant.FCDUO_FOCUSROW, lastRow);

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				////コネクションを開放する。
				//CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
