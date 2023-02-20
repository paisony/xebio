using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
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
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				//M1明細リストを取得
				Tk020f01Form tk020f01Form = (Tk020f01Form)facadeContext.FormVO;
				IDataList m1List = tk020f01Form.GetList("M1");

				// 削除行をListRemovedDataに追加
				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[iRow];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						//リストオブジェクトにM1Formを追加します。
						m1List.ListRemovedData.Add(f01m1VO);
					}
				}

				// 合計計算用ロジック
				ArrayList alList = new ArrayList();
				// 合計数量
				string[] goukeiSuryo = { "M1hyokason_su", "Gokei_suryo" };
				alList.Add(goukeiSuryo);
				// 原価金額合計
				string[] gokeiHaibunKin = { "M1haibun_kin", "Haibun_kin_gokei" };
				alList.Add(gokeiHaibunKin);

				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Tk020f01Form, Tk020f01M1Form>("M1", "M1rowno", (Tk020f01Form)facadeContext.FormVO, alList);

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
				tk020f01Form.Searchcnt = (m1List.Count).ToString();

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Tk020p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

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
