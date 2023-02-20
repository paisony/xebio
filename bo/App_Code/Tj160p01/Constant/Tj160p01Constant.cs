namespace com.xebio.bo.Tj160p01.Constant
{
  /// <summary>
  /// Tj160p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj160p01Constant
	{

		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tj160p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tj160f01";

		#endregion

		#region Facade用UserObject

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO = "FCDUO_F01VO";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO = "FCDUO_F01M1VO";

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		#endregion

		#region oracle packageName
		/// <summary>
		/// 棚卸チェックリスト検索(カウント用)
		/// </summary>
		public const string ORACLE_PACKAGE_01_COUNT = "MdInventoryNew_v.countInventoryCheckList";

		/// <summary>
		/// 棚卸チェックリスト検索(検索)
		/// </summary>
		public const string ORACLE_PACKAGE_01 = "MdInventoryNew_v.selectInventoryCheckList";

		#endregion

		#region データフラグ
		/// <summary>
		/// データフラグ 正常
		/// </summary>
		public const string DATA_FLG_SEIJOU = "0";
		/// <summary>
		/// データフラグ 欠番
		/// </summary>
		public const string DATA_FLG_KETUBAN = "1";
		/// <summary>
		/// データフラグ 重複
		/// </summary>
		public const string DATA_FLG_TYOHUKU = "2";
		/// <summary>
		/// データフラグ 取漏れ
		/// </summary>
		public const string DATA_FLG_TORIMORE = "3";

		#endregion

        #region 表示パターン
        /// <summary>
        /// 表示パターン "XXXXX"
        /// </summary>
        public const string DISP_PTN_NUKEBAN_5 = "XXXXX";
        /// <summary>
        /// 表示パターン "XX"
        /// </summary>
        public const string DISP_PTN_NUKEBAN_2 = "XX";
        /// <summary>
        /// 表示パターン "※欠番あり"
        /// </summary>
        public const string DISP_PTN_KETUBAN = "※欠番あり";
        /// <summary>
        /// 表示パターン "  |  "
        /// </summary>
        public const string DISP_PTN_RENBAN_5 = "|";
        /// <summary>
        /// 表示パターン "|" 
        /// </summary>
        public const string DISP_PTN_RENBAN_2 = "|";
        #endregion

	}
}
