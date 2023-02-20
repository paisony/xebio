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
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				// 単品レポートデータでない場合、残金の計算も行う
				if (Ta080p01Constant.FLG_ON.Equals(Convert.ToDecimal(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG])))
				{
					foreach (Ta080f03M1Form f03MVO in f03VO.GetList("M1").ListData)
					{
						f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
					}
				}
				else
				{
					decimal zankin = Convert.ToDecimal(f03VO.Zan_kin);
					foreach (Ta080f03M1Form f03MVO in f03VO.GetList("M1").ListData)
					{
						f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_ON;
						// 残金計算
						if(BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
						{
							// モード「申請」の場合、残金から各行の現価金額を引く
							zankin -= Convert.ToDecimal(f03MVO.M1genkakin);
						}
						else if (BoSystemConstant.MODE_SINSEIZUMITORIKESI.Equals(f03VO.Stkmodeno))
						{
							// モード「申請取消」の場合、残金から各行の現価金額を足す
							zankin += Convert.ToDecimal(f03MVO.M1genkakin);
						}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENSTK_FRM");

		}
		#endregion
	}
}
