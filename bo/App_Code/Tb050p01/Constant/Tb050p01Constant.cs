namespace com.xebio.bo.Tb050p01.Constant
{
  /// <summary>
  /// Tb050p01の定数を定義するクラスです。
  /// </summary>
  public static class Tb050p01Constant
	{

		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tb050p01";

		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tb050f01";

		#endregion

		#region Facade用UserObject

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM = "FCDUO_FOCUSITEM";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		#endregion

		#region SESSION_KEY

		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion

		#region サイズ検索
		/// <summary>
		/// サイズ検索　KEY
		/// </summary>
		public const string DIC_SIZE_SEARCH_RESULT = "DIC_SIZE_SEARCH_RESULT";
		/// <summary>
		/// サイズ検索　INDEX
		/// </summary>
		public const string DIC_FOCUS_INDEX = "DIC_FOCUS_INDEX";

		#endregion

		#region SQL-ID

		/// <summary>
		/// [仕入確定一時TBL]を登録
		/// </summary>
		public const string SQL_ID_01 = "TB050P01-01";

		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入先コード
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１サブ仕入先コード
		/// </summary>
		public const string DIC_M1SUBSIIRESAKI_CD = "DIC_M1SUBSIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１上代１（現売価）
		/// </summary>
		public const string DIC_M1SLPR = "DIC_M1SLPR";

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
	}
}
