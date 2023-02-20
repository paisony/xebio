using com.xebio.bo.Tf020p01.Constant;
using com.xebio.bo.Tf020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tf020p01.Facade
{
  /// <summary>
  /// Tf020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf020f02Facade : StandardBaseFacade
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
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
				Tf020f02Form f02VO = (Tf020f02Form)facadeContext.FormVO;

				// 行追加フラグ
				int addRowflg = 0;
				if (BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno))
				{
					addRowflg = 1;
				}

				// 合計計算用ロジック
				ArrayList alList = new ArrayList();
				// 合計数量
				string[] goukeitanajityobo_su = { "M1suryo", "Gokei_suryo" };
				alList.Add(goukeitanajityobo_su);
				// 合計原価金額
				string[] gokeitanajisekiso_su = { "M1genka_kin", "Genka_kin_gokei" };
				alList.Add(gokeitanajisekiso_su);

				decimal lastRow = DelRowCls.DeleteSelectRow<Tf020f02Form, Tf020f02M1Form>("M1", "M1rowno", (Tf020f02Form)facadeContext.FormVO, alList, addRowflg);

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
				facadeContext.SetUserObject(Tf020p01Constant.FCDUO_FOCUSROW, lastRow);

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
