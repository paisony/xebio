namespace com.xebio.bo.Td040p01.Constant
{
  /// <summary>
  /// Td040p01の定数を定義するクラスです。
  /// </summary>
  public static class Td040p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Td040p01";
		#endregion

		#region Facade用UserObject

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Td040f01";

		#endregion

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD = "DIC_SEARCH_XEBIOCD";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索JANコード
		/// </summary>
		public const string DIC_SEARCH_JANCD = "DIC_SEARCH_JANCD";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 返品実績確認一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TD040P01-01";

		/// <summary>
		/// 返品実績確認一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_02 = "TD040P01-02";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 返品実績確認一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID = "TABLE_ID";

		/// <summary>
		/// 返品実績確認一覧 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE1 = "ADD_WHERE1";

		/// <summary>
		/// 返品実績確認一覧 件数チェック／検索
		/// 置き換え変数 検索条件2
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE2 = "ADD_WHERE2";

		#endregion
	}
}
