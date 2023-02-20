using com.xebio.bo.Ti010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.DateUtil;
using Common.Standard.Base;

namespace com.xebio.bo.Ti010p01.Facade
{
  /// <summary>
  /// Ti010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ti010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ti010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ti010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti010f01Facade()
			: base()
		{
		}
		#endregion

		#region Ti010f01画面データを作成する。
		/// <summary>
		/// Ti010f01画面データを作成する。
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
				Ti010f01Form ti010f01Form = (Ti010f01Form)facadeContext.FormVO;
				
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得
				// 営業日を取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				System.DateTime dZejitsu = BoSystemDate.toDatetime(sysDateVO.Sysdate.ToString()).AddDays(-1);
				ti010f01Form.Eigyo_ymd = dZejitsu.ToString("yyyy/MM/dd");
				
				
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
