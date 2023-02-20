namespace com.xebio.bo.Tm040p01.Constant
{
  /// <summary>
  /// Tm040p01の定数を定義するクラスです。
  /// </summary>
  public static class Tm040p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tm040p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tm040f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tm040f02";
		#endregion

		#region ディクショナリのキー

		#region 起動パラメータ保持用
		/// <summary>
		/// ディクショナリキー　呼出元画面ID
		/// </summary>
		public const string DIC_FORM_ID = "DIC_FORM_ID";
		/// <summary>
		/// ディクショナリキー　現在行数
		/// </summary>
		public const string DIC_CUR_ROW_CNT = "DIC_CUR_ROW_CNT";
		/// <summary>
		/// ディクショナリキー　最大行数
		/// </summary>
		public const string DIC_MAX_ROW_CNT = "DIC_MAX_ROW_CNT";
		/// <summary>
		/// ディクショナリキー　店舗コード
		/// </summary>
		public const string DIC_TENPO_CD = "DIC_TENPO_CD";
		/// <summary>
		/// ディクショナリキー　指示番号
		/// </summary>
		public const string DIC_SIJI_BANGO = "DIC_SIJI_BANGO";
		/// <summary>
		/// ディクショナリキー　出荷会社コード
		/// </summary>
		public const string DIC_SYUKKA_KAISYA_CD = "DIC_SYUKKA_KAISYA_CD";
		/// <summary>
		/// ディクショナリキー　入荷会社コード
		/// </summary>
		public const string DIC_JURYO_KAISYA_CD = "DIC_JURYO_KAISYA_CD";
		/// <summary>
		/// ディクショナリキー　出荷店コード
		/// </summary>
		public const string DIC_SYUKKA_TEN_CD = "DIC_SYUKKA_TEN_CD";
		/// <summary>
		/// ディクショナリキー　補充依頼区分
		/// </summary>
		public const string DIC_HOJUIRAI_KBN = "DIC_HOJUIRAI_KBN";
		#endregion

		#region 明細隠し項目保持用
		/// <summary>
		/// ディクショナリキー　Ｍ１色リンク
		/// </summary>
		public const string DIC_M1IRO_NM = "DIC_M1IRO_NM";
		/// <summary>
		/// ディクショナリキー　Ｍ１色コード
		/// </summary>
		public const string DIC_M1MAKERCOLOR_CD = "DIC_M1MAKERCOLOR_CD";
		/// <summary>
		/// ディクショナリキー　Ｍ１展開区分
		/// </summary>
		public const string DIC_M1TENKAI_KB = "DIC_M1TENKAI_KB";

		/// <summary>
		/// ディクショナリキー　Ｍ１発注マスタ情報
		/// </summary>
		public const string DIC_M1HACHU_MST_INFO = "DIC_M1HACHU_MST_INFO";

		/// <summary>
		/// ディクショナリキー　インデックス（入力行リストにて保持用）
		/// </summary>
		public const string DIC_INDEX = "DIC_INDEX";
		#endregion

		#region Facade用UserObject
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　プログラムVOのディクショナリ
		/// </summary>
		public const string FCDUO_PGFORM_DICTIONARY = "FCDUO_PGFORM_DICTIONARY";
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　明細画面フォームVO
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　発注MST情報
		/// </summary>
		public const string FCDUO_HACHU_MST_INFO = "FCDUO_HACHU_MST_INFO";
		#endregion

		#region 選択行情報保持用
		/// <summary>
		/// ディクショナリキー　選択行インデックス
		/// </summary>
		public const string DIC_SELECT_ROWIDX = "DIC_SELECT_ROWIDX";
		#endregion

		#endregion

		#region SQL-ID
		/// <summary>
		/// サイズ検索色選択 検索
		/// </summary>
		public const string SQL_ID_01 = "TM040P01-01";
		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// サイズ検索色選択 検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
		#endregion

		#region 呼出元画面ID
		/// <summary>
		/// 呼出元画面ID　補充依頼入力-明細
		/// </summary>
		public const string FORMID_TA010F02 = "TA010F02";
		/// <summary>
		/// 呼出元画面ID　補充・仕入稟議検索-明細
		/// </summary>
		public const string FORMID_TA080F03 = "TA080F03";
		/// <summary>
		/// 呼出元画面ID　出荷要望入力-明細
		/// </summary>
		public const string FORMID_TA020F02 = "TA020F02";
		/// <summary>
		/// 呼出元画面ID　自動定数変更
		/// </summary>
		public const string FORMID_TA070F01 = "TA070F01";
		/// <summary>
		/// 呼出元画面ID　マニュアル仕入
		/// </summary>
		public const string FORMID_TB050F01 = "TB050F01";
		/// <summary>
		/// 呼出元画面ID　返品入力（ﾏﾆｭｱﾙ）
		/// </summary>
		public const string FORMID_TD020F01 = "TD020F01";
		/// <summary>
		/// 呼出元画面ID　移動出荷入力（ﾏﾆｭｱﾙ）
		/// </summary>
		public const string FORMID_TE020F01 = "TE020F01";
		/// <summary>
		/// 呼出元画面ID　移動出荷入力（再入荷防止）
		/// </summary>
		public const string FORMID_TE040F01 = "TE040F01";
		/// <summary>
		/// 呼出元画面ID　プライスシール発行
		/// </summary>
		public const string FORMID_TG010F01 = "TG010F01";
		/// <summary>
		/// 呼出元画面ID　商品ｽﾄｯｸ明細書発行-明細
		/// </summary>
		public const string FORMID_TG040F02 = "TG040F02";
		/// <summary>
		/// 呼出元画面ID　臨時棚卸検索-明細
		/// </summary>
		public const string FORMID_TJ190F02 = "TJ190F02";
		#endregion

		#region 各画面の数量項目最大値
		/// <summary>
		/// 数量項目最大値　TA010F02(補充依頼入力-明細）
		/// </summary>
		public const decimal TA010F02_MAX_SURYO = 9999999;
		/// <summary>
		/// 数量項目最大値　TA080F03(補充・仕入稟議検索-明細）
		/// </summary>
		public const decimal TA080F03_MAX_SURYO = 9999999;
		/// <summary>
		/// 数量項目最大値　TA020F02(出荷要望入力-明細）
		/// </summary>
		public const decimal TA020F02_MAX_SURYO = 9999999;
		/// <summary>
		/// 数量項目最大値　TA070F01(自動定数変更）
		/// </summary>
		public const decimal TA070F01_MAX_SURYO = 99999;
		/// <summary>
		/// 数量項目最大値　TB050F01(マニュアル仕入）
		/// </summary>
		public const decimal TB050F01_MAX_SURYO = 9999999;
		/// <summary>
		/// 数量項目最大値　TD020F01(返品入力（ﾏﾆｭｱﾙ））
		/// </summary>
		public const decimal TD020F01_MAX_SURYO = 9999999;
		/// <summary>
		/// 数量項目最大値　TE020F01(移動出荷入力（ﾏﾆｭｱﾙ））
		/// </summary>
		public const decimal TE020F01_MAX_SURYO = 999999;
		/// <summary>
		/// 数量項目最大値　TE040F01(移動出荷入力（再入荷防止））
		/// </summary>
		public const decimal TE040F01_MAX_SURYO = 999999;
		/// <summary>
		/// 数量項目最大値　TG010F01(プライスシール発行）
		/// </summary>
		public const decimal TG010F01_MAX_SURYO = 999;
		/// <summary>
		/// 数量項目最大値　TG040F02(商品ｽﾄｯｸ明細書発行-明細）
		/// </summary>
		public const decimal TG040F02_MAX_SURYO = 9999;
		/// <summary>
		/// 数量項目最大値　TJ190F02(臨時棚卸検索-明細）
		/// </summary>
		public const decimal TJ190F02_MAX_SURYO = 9999;
		#endregion

		/// <summary>
		/// TM040F02 M1 表示件数
		/// </summary>
		public const int TM040F02M1_DISP_CNT = 30;

	}
}
