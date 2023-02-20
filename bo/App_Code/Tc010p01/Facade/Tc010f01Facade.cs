using Common.Business.C01000.C01001;
using com.xebio.bo.Tc010p01.Formvo;
using Common.Standard.Base;
using Common.Advanced.Model.Context;

namespace com.xebio.bo.Tc010p01.Facade
{
	/// <summary>
	/// Tc010f01のFacadeクラスです
	/// 画面データのロード業務ロジックを実装します。
	/// </summary>
	public partial class Tc010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tc010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tc010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tc010f01Facade()
			: base()
		{
		}
		#endregion

		#region Tc010f01画面データを作成する。
		/// <summary>
		/// Tc010f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
			
				//カード部を取得します。
				Tc010f01Form tc010f01Form = (Tc010f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 日付FROMと日付TO
				tc010f01Form.Nyukayotei_ymd_from = sysDateVO.Sysdate.ToString();
				tc010f01Form.Nyukayotei_ymd_to = sysDateVO.Sysdate.ToString();
				tc010f01Form.Siire_kakutei_ymd_from = sysDateVO.Sysdate.ToString();
				tc010f01Form.Siire_kakutei_ymd_to = sysDateVO.Sysdate.ToString();
			
			
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
