using com.xebio.bo.Tg050p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.FormatUtil;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg050p01.Facade
{
  /// <summary>
  /// Tg050f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tg050f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tg050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tg050f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg050f01Facade()
			: base()
		{
		}
		#endregion

		#region Tg050f01画面データを作成する。
		/// <summary>
		/// Tg050f01画面データを作成する。
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
				Tg050f01Form tg050f01Form = (Tg050f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				DateTime dtsysDate = DateTime.ParseExact(sysDateVO.Sysdate.ToString(), "yyyyMMdd", null);

				// 営業日-1日
				tg050f01Form.Uriage_ymd_from = BoSystemFormat.formatDate(dtsysDate.AddDays(-1).ToString());	// 売上日付FROM
				tg050f01Form.Uriage_ymd_to = BoSystemFormat.formatDate(dtsysDate.AddDays(-1).ToString());	// 売上日付TO

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
