using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f02Facade : StandardBaseFacade
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
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				Tg040f02Form tg040f02Form = (Tg040f02Form)facadeContext.FormVO;
				IDataList m1List = tg040f02Form.GetList("M1");

				#region 業務チェック
				// 1-1 選択行
				// 選択行が存在しない場合はエラー
				bool selFlg = false;
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Tg040f02M1Form m1Form = (Tg040f02M1Form)m1List[i];

					if (m1Form.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 選択フラグＯＮの場合
						selFlg = true;
						break;
					}
				}
				if (!selFlg)
				{
					// 選択されていない場合
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				// 合計計算用ロジック
				ArrayList alList = new ArrayList();
				// 合計数量
				alList.Add(new string[] { "M1suryo", "Gokei_suryo" });

				int addRowFlg = 0;

				// モードが「新規作成」の場合
				if (tg040f02Form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					addRowFlg = 1;	// 行追加あり
				}
				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Tg040f02Form, Tg040f02M1Form>("M1", "M1rowno", (Tg040f02Form)facadeContext.FormVO, alList, addRowFlg);

				facadeContext.SetUserObject(Tg040p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

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
