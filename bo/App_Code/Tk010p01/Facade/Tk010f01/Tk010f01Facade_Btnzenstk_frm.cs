using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				// BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。
				// 画面より情報を取得する。
				Tk010f01Form f01VO = (Tk010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];

					// 選択モードNoが「照会」の場合で、[決裁状態]＝[未決裁]の明細については、選択状態としない
					if (BoSystemString.Nvl(f01VO.Stkmodeno).Equals(BoSystemConstant.MODE_REF)
						&& ConditionKessai_jotai.VALUE_KESSAI_JOTAI1.Equals(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG].ToString())
						)
					{
						// 処理しない
					}
					else
					{
						f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
					}
				}
			
				//トランザクションをコミットする。
				// CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				// RollbackTransaction(facadeContext);
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
