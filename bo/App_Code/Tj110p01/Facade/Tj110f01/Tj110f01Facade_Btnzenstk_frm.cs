using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Tj110p01.Facade
{
  /// <summary>
  /// Tj110f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj110f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnzenstk)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenstk)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENSTK_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				//FormVO取得
				//画面より情報を取得する。
				Tj110f01Form f01VO = (Tj110f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 全ての明細行を選択状態にする
				for (int i = 0; i < m1List.Count; i++)
				{
					Tj110f01M1Form f01m1VO = (Tj110f01M1Form)m1List[i];
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox2 = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox3 = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox4 = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox5 = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox6 = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1selectorcheckbox7 = BoSystemConstant.CHECKBOX_ON;

				}

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

		}
		#endregion
	}
}
