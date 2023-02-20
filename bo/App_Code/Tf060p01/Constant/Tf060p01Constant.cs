namespace com.xebio.bo.Tf060p01.Constant
{
  /// <summary>
  /// Tf060p01の定数を定義するクラスです。
  /// </summary>
  public static class Tf060p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tf060p01";
		#endregion

		#region フォームID
		/// <summary>
		/// フォームID
		/// </summary>
		public const string FORMID_01 = "Tf060f01";
		#endregion

		#region SQL-ID

		/// <summary>
		/// 予算登録 検索
		/// </summary>
		public const string SQL_ID_01 = "TF060P01-01";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 予算登録 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 予算登録 検索 
		/// 置き換え変数 月度
		/// </summary>
		public const string REP_GETUDO = "BIND_GETUDO";

		#endregion

		#region Dictionary

		/// <summary>
		/// 年月
		/// </summary>
		public const string DIC_YYYYMM = "DIC_YYYYMM";
		/// <summary>
		/// 更新日（配列）
		/// </summary>
		public const string DIC_UPD_YMD_LIST = "DIC_UPD_YMD_LIST";
		/// <summary>
		/// 更新時間（配列）
		/// </summary>
		public const string DIC_UPD_TM_LIST = "DIC_UPD_TM_LIST";

		/// <summary>
		/// CSV取込 ディクショナリ
		/// CSV取込結果
		/// </summary>
		public const string DIC_CSV_IMPORT_RESULT = "DIC_CSV_IMPORT_RESULT";
		/// <summary>
		/// CSV取込 ディクショナリ
		/// CSV取込結果チェック
		/// </summary>
		public const string DIC_CSV_CHECK_INFO = "DIC_CSV_CHECK_INFO";

		#endregion

		#region 定数

		/// <summary>
		/// 金額の最大値
		/// </summary>
		public const decimal MAX_KINGAKU = 999999;

		#endregion

	}
}
