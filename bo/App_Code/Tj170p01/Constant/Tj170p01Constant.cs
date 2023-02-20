namespace com.xebio.bo.Tj170p01.Constant
{
  /// <summary>
  /// Tj170p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj170p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tj170p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tj170f01";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tj170f02";
		#endregion

		#region Facade用UserObject

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";

		/// <summary>
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";
		#endregion

		#region 一覧画面 明細部 ディクショナリ

		/// <summary>
		/// 明細部 ディクショナリ
		/// M1商品群1コード
		/// </summary>
		public const string DIC_M1SYOHINGUN1_CD = "DIC_M1SYOHINGUN1_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// M1商品群1名
		/// </summary>
		public const string DIC_M1SYOHINGUN1_RYAKU_NM = "DIC_M1SYOHINGUN1_RYAKU_NM";
		
		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行のM1VO
		/// </summary>
		public const string DIC_M1SELCETVO = "DIC_M1SELCETVO";
		
		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行
		/// </summary>
		public const string DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";
		#endregion

		#region SQL-ID

		/// <summary>
		/// 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TJ170P01-01";
		/// <summary>
		/// 検索処理
		/// </summary>
		public const string SQL_ID_02 = "TJ170P01-02";
		/// <summary>
		/// 明細検索
		/// </summary>
		public const string SQL_ID_03 = "TJ170P01-03";
		/// <summary>
		/// 棚卸ロスリスト出力
		/// </summary>
		public const string SQL_ID_04 = "TJ170P01-04";
		/// <summary>
		/// 業者棚卸データ存在チェック
		/// </summary>
		public const string SQL_ID_05 = "TJ170P01-05";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 
		/// 置き換えテーブル
		/// </summary>
		public const string SQL_ID_REP_TABLE = "REP_ID_TABLE_NAME";
		/// <summary>
		/// 
		/// 置き換え条件
		/// </summary>
		public const string REP_ADD_SELECT = "REP_ADD_SELECT";
		/// <summary>
		/// 
		/// 置き換え条件
		/// </summary>
		public const string REP_ADD_WHERE = "REP_ADD_WHERE";
		/// <summary>
		/// 
		/// 置き換え条件
		/// </summary>
		public const string REP_SUB = "REP_SUB";
		/// <summary>
		/// 
		/// 置き換え集計条件
		/// </summary>
		public const string REP_ADD_GROUP_BY = "REP_ADD_GROUP_BY";

		/// <summary>
		/// 
		/// 置き換えソート条件
		/// </summary>
		public const string REP_ADD_ORDER_BY = "REP_ADD_ORDER_BY";

		/// <summary>
		/// 
		/// 発注マスタ追加
		/// </summary>
		public const string REP_ADD_HATYUMST = "REP_ADD_HATYUMST";



		
		#endregion


	}
}
