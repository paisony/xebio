﻿using Common.Advanced.Model.Context;
using Common.Standard.Base;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Meisaihead_iro_nm17)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm17)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoMEISAIHEAD_IRO_NM17_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoMEISAIHEAD_IRO_NM17_FRM");

			//try
			//{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				
			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			//}
			//catch (System.Exception ex)
			//{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
			//	//例外処理を実行する。
			//	ThrowException(ex, facadeContext);
			//}
			//finally
			//{
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			//}
			////メソッドの終了処理を実行する。
			//EndMethod(facadeContext, this.GetType().Name + ".DoMEISAIHEAD_IRO_NM17_FRM");

		}
		#endregion
	}
}
