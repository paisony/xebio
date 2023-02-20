namespace com.xebio.bo.Te040p01.Constant
{
  /// <summary>
  /// Te040p01の定数を定義するクラスです。
  /// </summary>
  public static class Te040p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Te040p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Te040f01";
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

		#endregion

		#region SESSION_KEY

		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion

		#region	SQL-ID
		/// <summary>
		/// 他社の発注MST取得
		/// </summary>
		public const string SQL_ID_01 = "TE040P01-01";
		#endregion

		#region	SQL-REPLACE-ID
		/// <summary>
		/// リプレイスID　テーブルID
		/// </summary>
		public const string REP_TABLE_ID = "REP_TABLE_ID";
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
		/// 商品群１コード
		/// </summary>
		public const string DIC_M1SYOHINGUN1_CD = "DIC_M1SYOHINGUN1_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入先コード
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 評価単価
		/// </summary>
		public const string DIC_M1HYOKA_TNK = "DIC_M1HYOKA_TNK";

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
		/// 確定種別 通常
		/// </summary>
		public const decimal KAKUTEI_SB_TSUJO = 0;
		/// <summary>
		/// 確定種別 ﾏﾆｭｱﾙ出荷
		/// </summary>
		public const decimal KAKUTEI_SB_MANUAL = 1;
		/// <summary>
		/// 移動指示理由 「初期値:0]」
		/// </summary>
		public const string IDOU_SIJI_RIYU_DEF = "0";
		/// <summary>
		/// 移動指示理由 「客注:1]」
		/// </summary>
		public const string IDOU_SIJI_RIYU_CUSTORDER = "1";
		///// <summary>
		///// 名称マスタ 識別コード 「会社:KASY」
		///// </summary>
		//public const string SIKIBETSU_CD_KAISYA = "KASY";
		/// <summary>
		/// 店舗マスタ 店舗形態区分 「LC店舗」
		/// </summary>
		public const string TENPOKEITAI_KB_LC = "2";
		#endregion
	}
}
