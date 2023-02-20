using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf060p01.Facade
{
  /// <summary>
  /// Tf060f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tf060f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tf060p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tf060f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf060f01Facade()
			: base()
		{
		}
		#endregion

		#region Tf060f01画面データを作成する。
		/// <summary>
		/// Tf060f01画面データを作成する。
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
				Tf060f01Form tf060f01Form = (Tf060f01Form)facadeContext.FormVO;

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				//月度：システム日付の翌月
				tf060f01Form.Getudo = new DateTime(date.Year, date.Month, date.Day).AddMonths(1).ToString("MM");

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				////M1明細部のデータを作成します。
				//DoM1ListLoad(facadeContext);

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

		#region 共通関数
		
		#region 月度を元に年を取得する。
		/// <summary>
		/// 月度を元に年を取得する。
		/// </summary>
		/// <param name="getudo">月度</param>
		/// <param name="date">システム日付</param>
		/// <returns>年</returns>
		private string getYear(string getudo, DateTime date)
		{
			string sYear = "";

			// 月度がシステム月より小さい場合は来年を返す。
			if (Convert.ToInt16(getudo) < Convert.ToInt16(date.ToString("MM")))
			{
				sYear = new DateTime(date.Year, date.Month, date.Day).AddYears(1).ToString("yyyy");
			}
			else
			{
				sYear = date.ToString("yyyy");
			}

			return sYear;
		}
		#endregion

		#region 合計欄を計算し設定する。
		/// <summary>
		/// 合計欄を計算し設定する。
		/// </summary>
		/// <param name="f01VO">画面VO</param>
		/// <param name="tukibetuSetFlg">月別合計設定有無</param>
		private void setGokei(Tf060f01Form f01VO, bool tukibetuSetFlg)
		{

			// 明細オブジェクト取得
			IDataList m1List = f01VO.GetList("M1");

			// 合計用変数
			decimal dBumon1 = 0;
			decimal dBumon2 = 0;
			decimal dBumon3 = 0;
			decimal dBumon4 = 0;
			decimal dBumon5 = 0;
			decimal dBumon1_gokei = 0;
			decimal dBumon2_gokei = 0;
			decimal dBumon3_gokei = 0;
			decimal dBumon4_gokei = 0;
			decimal dBumon5_gokei = 0;

			// 明細計算
			for (int i = 0; i < m1List.Count; i++)
			{
				Tf060f01M1Form f01m1VO = (Tf060f01M1Form)m1List[i];

				dBumon1 = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon1_yosan_kin, "0"));
				dBumon2 = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon2_yosan_kin, "0"));
				dBumon3 = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon3_yosan_kin, "0"));
				dBumon4 = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon4_yosan_kin, "0"));
				dBumon5 = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon5_yosan_kin, "0"));

				// Ｍ１部門(１～５)予算額を合計用に足し込む
				dBumon1_gokei += dBumon1;
				dBumon2_gokei += dBumon2;
				dBumon3_gokei += dBumon3;
				dBumon4_gokei += dBumon4;
				dBumon5_gokei += dBumon5;

				// Ｍ１日別予算額
				f01m1VO.M1hibetu_yosan_kin = (dBumon1 + dBumon2 + dBumon3 + dBumon4 + dBumon5).ToString();
			}

			// 部門(１～５)予算額合計
			f01VO.Bumon1_yosangokei_kin = dBumon1_gokei.ToString();
			f01VO.Bumon2_yosangokei_kin = dBumon2_gokei.ToString();
			f01VO.Bumon3_yosangokei_kin = dBumon3_gokei.ToString();
			f01VO.Bumon4_yosangokei_kin = dBumon4_gokei.ToString();
			f01VO.Bumon5_yosangokei_kin = dBumon5_gokei.ToString();
			// 予算額合計
			f01VO.Yosangokei_kin = (dBumon1_gokei + dBumon2_gokei + dBumon3_gokei + dBumon4_gokei + dBumon5_gokei).ToString();

			// 月別合計を設定する場合
			if (tukibetuSetFlg)
			{
				// 月別部門(１～５)予算額
				f01VO.Tukibetu_bumon1_yosan_kin = dBumon1_gokei.ToString();
				f01VO.Tukibetu_bumon2_yosan_kin = dBumon2_gokei.ToString();
				f01VO.Tukibetu_bumon3_yosan_kin = dBumon3_gokei.ToString();
				f01VO.Tukibetu_bumon4_yosan_kin = dBumon4_gokei.ToString();
				f01VO.Tukibetu_bumon5_yosan_kin = dBumon5_gokei.ToString();
				// 月別予算額合計
				f01VO.Tukibetu_yosan_kin_gokei = (dBumon1_gokei + dBumon2_gokei + dBumon3_gokei + dBumon4_gokei + dBumon5_gokei).ToString();
			}

		}
		#endregion

		#endregion

	}
}
