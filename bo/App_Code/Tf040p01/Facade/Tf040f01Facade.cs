using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf040p01.Facade
{
  /// <summary>
  /// Tf040f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tf040f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tf040p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tf040f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf040f01Facade()
			: base()
		{
		}
		#endregion

		#region Tf040f01画面データを作成する。
		/// <summary>
		/// Tf040f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			//try
			//{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを開きます。
			//	OpenConnection(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				
			//	//カード部を取得します。
			//	Tf040f01Form tf040f01Form = (Tf040f01Form)facadeContext.FormVO;
				
			//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
			//	//M1明細部のデータを作成します。
			//	DoM1ListLoad(facadeContext);
				
			//}
			//catch (System.Exception ex)
			//{
			//	//例外処理を実行する。
			//	ThrowException(ex, facadeContext);
			//}
			//finally
			//{
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			//}
			////メソッドの終了処理を実行する。
			//EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

		
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion

		#region 合計行を計算
		/// <summary>
		/// 合計行を計算する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void SetGokeiGyo(IFacadeContext facadeContext)
		{
			// FormVO取得
			// 画面より情報を取得する。
			Tf040f01Form f01VO = (Tf040f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");

			// 合計残高の加算
			decimal dSumZan = 0;
			decimal dnyukin ;	// Ｍ１入金（作業用）
			decimal dsyukkin ;	// Ｍ１出金（作業用）

			for (int i = 0; i < m1List.Count; i++)
			{
				Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[i];

				#region 作業用変数にコピー
				// 値が入力されていない場合、0に設定
				// Ｍ１入金
				if (string.IsNullOrEmpty(f01m1VO.M1nyukin))
				{
					dnyukin = 0;
				}
				else
				{
					dnyukin = Convert.ToDecimal(f01m1VO.M1nyukin);
				}

				// Ｍ１出金
				if (string.IsNullOrEmpty(f01m1VO.M1syukkin))
				{
					dsyukkin = 0;
				}
				else
				{
					dsyukkin = Convert.ToDecimal(f01m1VO.M1syukkin);
				}
				#endregion
				
				// 合計値加算
				dSumZan += (dnyukin - dsyukkin);
			}

			// 残高設定
			f01VO.Gokei_zandaka = dSumZan.ToString();
		}
		#endregion

	}
}
