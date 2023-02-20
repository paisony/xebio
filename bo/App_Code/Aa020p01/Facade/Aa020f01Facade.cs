using com.xebio.bo.Aa020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.LabelUtil;
using Common.Standard.Base;

namespace com.xebio.bo.Aa020p01.Facade
{
  /// <summary>
  /// Aa020f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Aa020f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Aa020p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Aa020f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Aa020f01Facade()
			: base()
		{
		}
		#endregion

		#region Aa020f01画面データを作成する。
		/// <summary>
		/// Aa020f01画面データを作成する。
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
				Aa020f01Form aa020f01Form = (Aa020f01Form)facadeContext.FormVO;

				// ラベル情報を設定
				BoSystemLabelUtil.SetLabelInfo<Aa020f01Form>(aa020f01Form, facadeContext);



				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........


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
