namespace com.xebio.bo.Td020p01.Constant
{
  /// <summary>
  /// Td020p01の定数を定義するクラスです。
  /// </summary>
  public static class Td020p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Td020p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Td020f01";
		#endregion

		#region	Facade用UserObject
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO = "FCDUO_F01VO";
		/// <summary>
		/// 画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM = "FCDUO_FOCUSITEM";
		/// <summary>
		/// 画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";
		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_PRT_FLNM = "FCDUO_PRT_FLNM";

		/// <summary>
		/// 画面サイズ選択　サイズ検索戻り値
		/// </summary>
		public const string KEY_SIZE_SEARCH_RESULT = "SIZE_SEARCH_RESULT";
		/// <summary>
		/// 画面サイズ選択  フォーカスインデックス
		/// </summary>
		public const string KEY_SIZE_FOCUS_INDEX = "SIZE_FOCUS_INDEX";

		/// <summary>
		/// CSV取込 CSV取込戻り用
		/// </summary>
		public const string KEY_CSV_IMPORT_RESULT = "CSV_IMPORT_RESULT";
		/// <summary>
		/// CSV取込 結果チェック
		/// </summary>
		public const string KEY_CSV_CHECK_INFO = "CSV_CHECK_INFO";
		/// <summary>
		/// CSV取込 結果チェック
		/// </summary>
		public const string KEY_CSV_FOCUS_INDEX = "CSV_FOCUS_INDEX ";

		#endregion
		#region	SQL-ID
		/// <summary>
		/// 返品入力（ﾏﾆｭｱﾙ） 返品指示理由取得
		/// </summary>
		public const string SQL_ID_01 = "Td020P01-01";
		/// <summary>
		/// 返品入力（ﾏﾆｭｱﾙ） 返品指示数取得
		/// </summary>
		public const string SQL_ID_02 = "Td020P01-02";
		#endregion

		#region	SQL-REPLACE-ID
		#endregion

		#region	Dictionary カード部
		#endregion

		#region	Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日
		/// </summary>
		public const string DIC_M1UPD_YMD = "DIC_M1UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string DIC_M1UPD_TM = "DIC_M1UPD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入先コード
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サブ仕入先コード
		/// </summary>
		public const string DIC_M1SUBSIIRESAKI_CD = "DIC_M1SUBSIIRESAKI_CD";


		/// <summary>
		/// 明細部 ディクショナリ
		/// 最新仕入日
		/// </summary>
		public const string DIC_M1SAISIN_SIIRE_YMD = "DIC_M1SAISIN_SIIRE_YMD";	
		/// <summary>
		/// 明細部 ディクショナリ
		/// 発注書文言印刷フラグ
		/// </summary>
		public const string DIC_M1HATTYUSYO_MONGON_INSATSU_FLG = "DIC_M1HATTYUSYO_MONGON_INSATSU_FLG";	
		/// <summary>
		/// 明細部 ディクショナリ
		/// 調達区分
		/// </summary>
		public const string DIC_M1TYOTATSU_KB = "DIC_M1TYOTATSU_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 保証書発行フラグ
		/// </summary>
		public const string DIC_M1HOSYOUSYO_HAKKOU_FLG = "DIC_M1HOSYOUSYO_HAKKOU_FLG";
		#endregion
		#region プログラム固定値
		/// <summary>
		/// フラグOFF
		/// </summary>
		public const decimal FLG_OFF = 0;
		/// <summary>
		/// フラグON
		/// </summary>
		public const decimal FLG_ON = 1;
		/// <summary>
		/// 返品指示理由 「初期値:0]」
		/// </summary>
		public const string HENPIN_SIJI_RIYU_DEF = "0";
		/// <summary>
		/// 返品指示理由 「客注:1]」
		/// </summary>
		public const string HENPIN_SIJI_RIYU_CUSTORDER = "1";
		/// <summary>
		/// 確定種別 通常
		/// </summary>
		public const decimal KAKUTEI_SB_TSUJO = 0;
		/// <summary>
		/// 確定種別 ﾏﾆｭｱﾙ出荷
		/// </summary>
		public const decimal KAKUTEI_SB_MANUAL = 1;
		/// <summary>
		/// 名称マスタ 識別コード 「会社:KASY」
		/// </summary>
		public const string SIKIBETSU_CD_KAISYA = "KASY";
		/// <summary>
		/// 名称マスタ 識別コード 「:RTFM」
		/// </summary>
		public const string SIKIBETSU_CD_RTFM = "RTFM";
		/// <summary>
		/// 名称マスタ 識別コード 「RT」名称コード
		/// </summary>
		public const string SIKIBETSU_CD_RT_MEISYO_1 = "1";
		/// <summary>
		/// 名称マスタ 識別コード 「RT」名称コード
		/// </summary>
		public const string SIKIBETSU_CD_RT_MEISYO_2 = "2";
		/// <summary>
		/// 名称マスタ 識別コード 「:RTFD」
		/// </summary>
		public const string SIKIBETSU_CD_RTFD = "RTFD";
		/// <summary>
		/// 店舗マスタ 店舗形態区分 「LC店舗」
		/// </summary>
		public const string TENPOKEITAI_KB_LC = "2";


		#endregion

		#region SESSION_KEY

		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion
	}
}
