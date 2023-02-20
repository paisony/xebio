﻿using com.xebio.bo.Tk030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Standard.Base;

namespace com.xebio.bo.Tk030p01.Facade
{
  /// <summary>
  /// Tk030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnikkatsusyonin)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnikkatsusyonin)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNIKKATSUSYONIN_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNIKKATSUSYONIN_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// FormVO取得
				// 画面より情報を取得する。
				Tk030f01Form f01VO = (Tk030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 全明細の承認にチェックを付ける。
				for (int i = 0; i < m1List.Count; i++)
				{
					Tk030f01M1Form f01m1VO = (Tk030f01M1Form)m1List[i];
					f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
				}

				// 全明細の却下のチェックを外す。
				for (int i = 0; i < m1List.Count; i++)
				{
					Tk030f01M1Form f01m1VO = (Tk030f01M1Form)m1List[i];
					f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNIKKATSUSYONIN_FRM");

		}
		#endregion
	}
}
