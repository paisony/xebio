namespace com.xebio.bo.Tj180p01.Constant
{
  /// <summary>
  /// Tj180p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj180p01Constant
	{

		#region SQL-ID

		/// <summary>
		/// 棚卸進捗確認 営業日取得
		/// </summary>
		public const string SQL_ID_01 = "TJ180P01-01";
		/// <summary>
		/// 棚卸進捗確認 基準日前日帳簿在庫数取得
		/// </summary>
		public const string SQL_ID_02 = "TJ180P01-02";
		/// <summary>
		/// 棚卸進捗確認 当日売上数取得
		/// </summary>
		public const string SQL_ID_03 = "TJ180P01-03";
		/// <summary>
		/// 棚卸進捗確認 当日入出荷数取得
		/// </summary>
		public const string SQL_ID_04 = "TJ180P01-04";
		/// <summary>
		/// 棚卸進捗確認 店舗棚卸数取得
		/// </summary>
		public const string SQL_ID_05 = "TJ180P01-05";
		/// <summary>
		/// 棚卸進捗確認 業者棚卸数取得
		/// </summary>
		public const string SQL_ID_06 = "TJ180P01-06";



		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 棚卸進捗確認 
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// 棚卸進捗確認 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_03_REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 棚卸進捗確認 検索 
		/// 置き換え変数 棚卸基準日
		/// </summary>
		public const string SQL_ID_03_REP_TANAOROSIKIJUN_YMD = "BIND_TANAOROSIKIJUN_YMD";
		/// <summary>
		/// <summary>
		/// 棚卸進捗確認 検索 
		/// 置き換え変数 営業日
		/// </summary>
		public const string SQL_ID_03_REP_EIGYO_YMD = "BIND_EIGYO_YMD";
		/// <summary>
		/// 棚卸進捗確認 検索 
		/// 置き換え変数 棚卸実施日
		/// </summary>
		public const string SQL_ID_03_REP_TANAOROSIJISSI_YMD = "BIND_TANAOROSIJISSI_YMD";


		#endregion

		#region Dictionary カード部
		/// <summary>
		/// カード部 ディクショナリ
		/// 基準日前日帳簿在庫数
		/// </summary>
		public const string DIC_KIJUNBIZENJITUTYOUBOZAIKO = "DIC_KIJUNBIZENJITUTYOUBOZAIKO";
		/// <summary>
		/// カード部 ディクショナリ
		/// 当日売上数
		/// </summary>
		public const string DIC_TOJITUURIAGE = "DIC_TOJITUURIAGE";
		/// <summary>
		/// カード部 ディクショナリ
		/// 当日入出荷数
		/// </summary>
		public const string DIC_TOJITUNYUSYUKKA = "DIC_TOJITUNYUSYUKKA";
		/// <summary>
		/// カード部 ディクショナリ
		/// 当日予測在庫数
		/// </summary>
		public const string DIC_TOJITSUYOSOKUZAI_SU = "DIC_TOJITSUYOSOKUZAI_SU";
		/// <summary>
		/// カード部 ディクショナリ
		/// 店舗棚卸数
		/// </summary>
		public const string DIC_TENPOTANAOROSI = "DIC_TENPOTANAOROSI";
		/// <summary>
		/// カード部 ディクショナリ
		/// 業者棚卸数
		/// </summary>
		public const string DIC_GYOSYATANAOROSI = "DIC_GYOSYATANAOROSI";
		/// <summary>
		/// カード部 ディクショナリ
		/// 差異数
		/// </summary>
		public const string DIC_SAI_SU = "DIC_SAI_SU";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";

		#endregion

		#region Dictionary 明細部
		#endregion

	}
}
