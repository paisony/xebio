using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using System.Collections;	

namespace com.xebio.bo.Tf030p01.Facade
{
	/// <summary>
	/// Tf030f02のFacadeクラスです
	/// 各アクションの業務ロジックを実装します。
	/// </summary>
	public partial class Tf030f02Facade : StandardBaseFacade
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
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//M1明細リストを取得
				Tf030f02Form tf030f02Form = (Tf030f02Form)facadeContext.FormVO;
				IDataList m1List = tf030f02Form.GetList("M1");

				int addRowFlg = 0;
				// モードが「新規作成」の場合
				if (BoSystemConstant.MODE_INSERT.Equals(tf030f02Form.Stkmodeno))
				{
					addRowFlg = 1;	// 行追加あり
				}
				// モードが「修正」の場合
				else if (BoSystemConstant.MODE_UPD.Equals(tf030f02Form.Stkmodeno))
				{
					addRowFlg = 0;	// 行追加なし
				}

				// 合計項目の設定
				ArrayList gokeiCalcList = new ArrayList();
				string[] suryocolumn = { "M1suryo", "Gokei_suryo" };
				gokeiCalcList.Add(suryocolumn);
				string[] kingakucolumn = { "M1kingaku", "Gokei_kin" };
				gokeiCalcList.Add(kingakucolumn);

				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Tf030f02Form, Tf030f02M1Form>("M1", "M1rowno", (Tf030f02Form)facadeContext.FormVO, gokeiCalcList, addRowFlg);

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
				facadeContext.SetUserObject(Tf030p01Constant.FCDUO_FOCUSROW, lastRow);

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
