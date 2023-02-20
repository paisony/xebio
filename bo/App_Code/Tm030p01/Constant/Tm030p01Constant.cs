namespace com.xebio.bo.Tm030p01.Constant
{
  /// <summary>
  /// Tm030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tm030p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tm030p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tm030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "";
		#endregion

		#region ディクショナリキー
		/// <summary>
		/// ディクショナリキー　システム日付情報
		/// </summary>
		public const string DIC_SYSDATE_VO = "DIC_SYSDATE_VO";
		/// <summary>
		/// ディクショナリキー　Ｍ１帳票ID
		/// </summary>
		public const string DIC_M1TYOHYO_ID = "DIC_M1TYOHYO_ID";
		/// <summary>
		/// ディクショナリキー　Ｍ１帳票名
		/// </summary>
		public const string DIC_M1TYOHYO_NM = "DIC_M1TYOHYO_NM";
		/// <summary>
		/// ディクショナリキー　Ｍ１PDFファイルパス
		/// </summary>
		public const string DIC_M1PDF_PATH = "DIC_M1PDF_PATH";
		/// <summary>
		/// ディクショナリキー　一括印刷ボタン表示フラグ
		/// </summary>
		public const string DIC_ALLPRINT_F = "DIC_ALLPRINT_F";
		/// <summary>
		/// ディクショナリキー　一括印刷用PDFファイルパス
		/// </summary>
		public const string DIC_ALLPRINTPDF_PATH = "DIC_ALLPRINTPDF_PATH";
		#endregion

		#region SQL-ID
		/// <summary>
		/// 返品指示変更リスト件数取得
		/// </summary>
		public const string SQL_ID_01 = "TM030P01-01";
		/// <summary>
		/// 移動出荷差異リスト件数取得
		/// </summary>
		public const string SQL_ID_02 = "TM030P01-02";
		/// <summary>
		/// 棚卸重複データ件数取得
		/// </summary>
		public const string SQL_ID_03 = "TM030P01-03";
		/// <summary>
		/// 棚卸アンマッチデータ件数取得
		/// </summary>
		public const string SQL_ID_04 = "TM030P01-04";
		/// <summary>
		/// 経費振替決裁データ件数取得
		/// </summary>
		public const string SQL_ID_05 = "TM030P01-05";
		/// <summary>
		/// エラー品番リスト件数取得
		/// </summary>
		public const string SQL_ID_06 = "TM030P01-06";
		/// <summary>
		/// インストアコード振替リスト件数取得
		/// </summary>
		public const string SQL_ID_07 = "TM030P01-07";
		/// <summary>
		/// 売変作業指示対象データ件数取得（X）
		/// </summary>
		public const string SQL_ID_08 = "TM030P01-08";
		/// <summary>
		/// 売変作業指示対象データ件数取得（V）
		/// </summary>
		public const string SQL_ID_09 = "TM030P01-09";
		/// <summary>
		/// 客注入荷リスト件数取得
		/// </summary>
		public const string SQL_ID_10 = "TM030P01-10";
		/// <summary>
		/// お知らせ情報取得
		/// </summary>
		public const string SQL_ID_11 = "TM030P01-11";

		/// <summary>
		/// 返品指示変更履歴TBL更新
		/// </summary>
		public const string SQL_ID_12 = "TM030P01-12";
		/// <summary>
		/// 移動出荷差異リスト更新
		/// </summary>
		public const string SQL_ID_13 = "TM030P01-13";
		/// <summary>
		/// エラー品番TBL更新
		/// </summary>
		public const string SQL_ID_14 = "TM030P01-14";
		/// <summary>
		/// インストアコード振替データTBL更新
		/// </summary>
		public const string SQL_ID_15 = "TM030P01-15";
		#endregion

		#region 帳票ID
		/// <summary>
		/// 帳票ID　返品指示変更リスト
		/// </summary>
		public const string LIST_ID_TD060L01 = "TD060L01";
		/// <summary>
		/// 帳票ID　出荷差異リスト
		/// </summary>
		public const string LIST_ID_TE030L01 = "TE030L01";
		/// <summary>
		/// 帳票ID　エラー品番リスト
		/// </summary>
		public const string LIST_ID_TG050L01 = "TG050L01";
		/// <summary>
		/// 帳票ID　インストアコード振替リスト
		/// </summary>
		public const string LIST_ID_TG070L01 = "TG070L01";
		/// <summary>
		/// 帳票ID　客注入荷リスト
		/// </summary>
		public const string LIST_ID_TC010L01 = "TC010L01";
		/// <summary>
		/// 帳票ID　一括印刷帳票
		/// </summary>
		public const string LIST_ID_TZ900L01 = "TZ900L01";
		/// <summary>
		/// 帳票名　一括印刷帳票
		/// </summary>
		public const string LIST_NM_TZ900L01 = "お知らせ一括印刷リスト";
		#endregion

		/// <summary>
		/// 担当者コード　バッチ
		/// </summary>
		public const string TANCD_BATCH = "0000000";

		/// <summary>
		/// セッションキー　ダウンロード情報VO
		/// </summary>
		public const string SESSION_DL_CONDITION_VO = "SESSION_DL_CONDITION_VO";
	}
}
