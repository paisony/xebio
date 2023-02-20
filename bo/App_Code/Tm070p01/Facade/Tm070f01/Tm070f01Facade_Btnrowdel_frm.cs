using com.xebio.bo.Tm070p01.Constant;
using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C01000.C01018;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tm070p01.Facade
{
  /// <summary>
  /// Tm070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm070f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

			try
			{
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				//M1明細リストを取得
				Tm070f01Form f01VO = (Tm070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択行を削除
				Hashtable defVal = new Hashtable();
				defVal["M1henko_tenpo_cd"] = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)];
				defVal["M1henko_tenpo_nm"] = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)];

				decimal lastRow = DelRowCls.DeleteSelectRow<Tm070f01Form, Tm070f01M1Form>("M1", "M1rowno", (Tm070f01Form)facadeContext.FormVO, null, 1, defVal);

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

				facadeContext.SetUserObject(Tm070p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

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
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
