using com.xebio.bo.Tf040p01.Constant;
using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tf040p01.Facade
{
  /// <summary>
  /// Tf040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf040f01Facade : StandardBaseFacade
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

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tf040f01Form f01VO = (Tf040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック
				int iSelCnt = 0;	// 選択カウント
				for (int i = 0; i < m1List.Count; i++)
				{
					Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						iSelCnt++ ;	// 選択明細あり
						if(!string.IsNullOrEmpty(f01m1VO.M1kanri_no))
						{
							// 確定済みのデータに対して削除は行えません。
							ErrMsgCls.AddErrMsg(
								"E232"
								, string.Empty
								, facadeContext
								, null
								, f01m1VO.M1rowno
								, i.ToString()
								, "M1"
							);
						}
					}
				}

				// 選択明細なしの場合
				if (iSelCnt == 0)
				{
					// {対象行}を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
			
				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Tf040f01Form, Tf040f01M1Form>("M1", "M1rowno", (Tf040f01Form)facadeContext.FormVO, null);

				// 合計行の設定
				SetGokeiGyo(facadeContext);

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Tf040p01Constant.FCDUO_FOCUSROW, lastRow);
				

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
