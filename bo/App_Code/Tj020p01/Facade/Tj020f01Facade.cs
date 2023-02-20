using com.xebio.bo.Tj020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Conditions;
using Common.Standard.Base;

namespace com.xebio.bo.Tj020p01.Facade
{
  /// <summary>
  /// Tj020f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj020f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj020p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj020f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj020f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj020f01画面データを作成する。
		/// <summary>
		/// Tj020f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
			
				//カード部を取得します。
				Tj020f01Form tj020f01Form = (Tj020f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........
				
				//棚卸送信状態初期値設定 
				tj020f01Form.Tanaorosi_sosin_jyotai = ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1;
	
			
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

	}
}
