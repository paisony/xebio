using com.xebio.bo.Tj150p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Conditions;
using Common.Standard.Base;

namespace com.xebio.bo.Tj150p01.Facade
{
  /// <summary>
  /// Tj150f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj150f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj150p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj150f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj150f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj150f01画面データを作成する。
		/// <summary>
		/// Tj150f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
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
				Tj150f01Form tj150f01Form = (Tj150f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 棚卸終了区分初期値設定
				tj150f01Form.Tanaorosisyuryo_kb = ConditionTanaorosi_syuryo_kbn.VALUE_TANAOROSI_SYURYO_KBN1;
			
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
