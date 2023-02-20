namespace com.xebio.bo.Tf040p01.Constant
{
  /// <summary>
  /// Tf040p01の定数を定義するクラスです。
  /// </summary>
  public static class Tf040p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tf040p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tf040f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tf040f02";
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
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
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

		#region SQL-ID
		/// <summary>
		/// 小口現金登録 月次繰越件数、小口現金件数取得
		/// </summary>
		public const string SQL_ID_01 = "TF040P01-01";

		/// <summary>
		/// 小口現金登録 [月次繰越件数] <> 0 、[小口現金件数] <> 0の場合
		/// </summary>
		public const string SQL_ID_02 = "TF040P01-02";
		/// <summary>
		/// 小口現金登録 [月次繰越件数] <> 0 、[小口現金件数] == 0の場合
		/// </summary>
		public const string SQL_ID_03 = "TF040P01-03";
		/// <summary>
		/// 小口現金登録 [月次繰越件数] == 0 、[小口現金件数] <> 0の場合
		/// </summary>
		public const string SQL_ID_04 = "TF040P01-04";
		/// <summary>
		/// 小口現金登録 [月次繰越件数] == 0 、[小口現金件数] == 0の場合
		/// </summary>
		public const string SQL_ID_05 = "TF040P01-05";
		/// <summary>
		/// 小口現金登録 登録処理
		/// </summary>
		public const string SQL_ID_06 = "TF040P01-06";

		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 小口現金登録 
		/// 置き換え変数 検索条件
		/// </summary>
		public const string REP_ADD_WHERE = "ADD_WHERE";
		/// <summary>
		/// 小口現金登録 
		/// 置き換え変数 検索条件
		/// </summary>
		public const string REP_ADD_WHERE2 = "ADD_WHERE2";

		/// <summary>
		/// 小口現金登録 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string REP_TENPO_CD = "TENPO_CD";
		/// <summary>
		/// 小口現金登録 検索 
		/// 置き換え変数 計上日
		/// </summary>
		public const string REP_KEIJO_YMD = "KEIJO_YMD";
		/// <summary>
		/// 小口現金登録 検索 
		/// 置き換え変数 日付調整変数
		/// </summary>
		public const string REP_DATE_ADJUST = "DATE_ADJUST";

		#endregion

		#region Dictionary カード部
		#endregion

		#region Dictionary 明細部
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

		/// <summary>
		/// 明細部 ディクショナリ
		/// システム日付
		/// </summary>
		public const string DIC_SYSDATE = "DIC_SYSDATE";
        #endregion

        #region 定数
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const int PAGE_PER_COUNT = 50;

        /// <summary>
        /// 明細画面フォームID
        /// 入出金区分
        /// </summary>
        public const string CONST_NYUKIN_KB = "0";
		#endregion
	}
}
