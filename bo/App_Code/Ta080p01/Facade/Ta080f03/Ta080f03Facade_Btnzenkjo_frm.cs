using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnzenkjo)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenkjo)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENKJO_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

			try
			{
				//DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				// 単品レポートデータでない場合、残金の計算も行う
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				if (Ta080p01Constant.FLG_ON.Equals(Convert.ToDecimal(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG])))
				{
					foreach (Ta080f03M1Form f03MVO in f03VO.GetList("M1").ListData)
					{
						f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					}
				}
				else
				{
					decimal zankin = Convert.ToDecimal(f03VO.Zan_kin);
					foreach (Ta080f03M1Form f03MVO in f03VO.GetList("M1").ListData)
					{
						f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					}
					//  残金をフォームに設定
					f03VO.Footer_zan_kin = zankin.ToString();
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENKJO_FRM");

		}
		#endregion
	}
}
