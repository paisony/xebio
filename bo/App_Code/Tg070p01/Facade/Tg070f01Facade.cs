using com.xebio.bo.Tg070p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.DateUtil;
using Common.Standard.Base;

namespace com.xebio.bo.Tg070p01.Facade
{
  /// <summary>
  /// Tg070f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tg070f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tg070p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tg070f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg070f01Facade()
			: base()
		{
		}
		#endregion

		#region Tg070f01画面データを作成する。
		/// <summary>
		/// Tg070f01画面データを作成する。
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
				Tg070f01Form tg070f01Form = (Tg070f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........
				// 営業日を取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				System.DateTime dZejitsu = BoSystemDate.toDatetime(sysDateVO.Sysdate.ToString()).AddDays(-1);
				tg070f01Form.Hurikae_ymd_from = dZejitsu.ToString("yyyy/MM/dd");
				tg070f01Form.Hurikae_ymd_to = dZejitsu.ToString("yyyy/MM/dd");
				
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
