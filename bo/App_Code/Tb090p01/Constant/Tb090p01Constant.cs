namespace com.xebio.bo.Tb090p01.Constant
{
  /// <summary>
  /// Tb090p01の定数を定義するクラスです。
  /// </summary>
  public static class Tb090p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tb090p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tb090f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tb090f02";

		#endregion

		#region Facade用UserObject
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
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
		/// 仕入伝票訂正一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TB090P01-01";

		/// <summary>
		/// 仕入伝票訂正一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TB090P01-02";

		/// <summary>
		/// 仕入伝票訂正明細 検索
		/// </summary>
		public const string SQL_ID_03 = "TB010P01-08";

		/// <summary>
		/// 仕入伝票訂正一覧 [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録
		/// </summary>
		public const string SQL_ID_04 = "TB090P01-03";

		/// <summary>
		/// 仕入伝票訂正一覧 [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録
		/// </summary>
		public const string SQL_ID_05 = "TB090P01-04";

		/// <summary>
		/// 仕入入荷確定(B) 削除
		/// </summary>
		public const string SQL_ID_06 = "TB090P01-05";

		/// <summary>
		/// 仕入入荷確定(H) 削除
		/// </summary>
		public const string SQL_ID_07 = "TB090P01-06";

		/// <summary>
		/// 仕入入荷確定(H) 削除
		/// </summary>
		public const string SQL_ID_08 = "TB090P01-07";

		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録
		/// </summary>
		public const string SQL_ID_09 = "TB090P01-08";

		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録
		/// </summary>
		public const string SQL_ID_10 = "TB090P01-09";

		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録
		/// </summary>
		public const string SQL_ID_11 = "TB090P01-10";

		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録
		/// </summary>
		public const string SQL_ID_12 = "TB090P01-11";

		#endregion
		
		#region SQL-REPLACE-ID

		/// <summary>
		/// 仕入伝票訂正一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID = "TABLE_ID1";
		/// <summary>
		/// 仕入伝票訂正一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE1";
		/// <summary>
		/// 仕入伝票訂正明細 検索 
		/// 置き換え変数 確定種別
		/// </summary>
		public const string SQL_ID_03_REP_KAKUTEI_SB = "KAKUTEI_SB";
		/// <summary>
		/// 仕入伝票訂正明細 検索 
		/// 置き換え変数 仕入先コード
		/// </summary>
		public const string SQL_ID_03_REP_SIIRESAKI_CD = "SIIRESAKI_CD";
		/// <summary>
		/// 仕入伝票訂正明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_03_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 仕入伝票訂正明細 検索 
		/// 置き換え変数 入荷予定日
		/// </summary>
		public const string SQL_ID_03_REP_SITEINOHIN_YMD = "SITEINOHIN_YMD";
		/// <summary>
		/// 仕入伝票訂正明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_03_REP_TENPO_CD = "TENPO_CD";
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


		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 元伝票番号
		/// </summary>
		public const string DIC_M1MOTODENPYO_BANGO = "DIC_M1MOTODENPYO_BANGO";
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
		/// 送信済フラグ
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定種別
		/// </summary>
		public const string DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 元確定種別
		/// </summary>
		public const string DIC_M1MOTOKAKUTEI_SB = "DIC_M1MOTOKAKUTEI_SB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 備考区分
		/// </summary>
		public const string DIC_M1BIKO_KB = "DIC_M1BIKO_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 備考１
		/// </summary>
		public const string DIC_M1BIKO1 = "DIC_M1BIKO1";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 備考２
		/// </summary>
		public const string DIC_M1BIKO2 = "DIC_M1BIKO2";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定担当者コード
		/// </summary>
		public const string DIC_M1FIXED_TANCD = "DIC_M1FIXED_TANCD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 上代１
		/// </summary>
		public const string DIC_M1JODAI1_TNK = "DIC_M1JODAI1_TNK";
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
		/// 自社品番
		/// </summary>
		public const string DIC_M1JISYA_HBN = "DIC_M1JISYA_HBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 赤伝票番号
		/// </summary>
		public const string DIC_M1AKADENPYO_BANGO = "DIC_M1AKADENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 黒伝票番号
		/// </summary>
		public const string DIC_M1KURODENPYO_BANGO = "DIC_M1KURODENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// スキャンコード
		/// </summary>
		public const string DIC_M1SCAN_CD = "DIC_M1SCAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 明細情報リスト
		/// </summary>
		public const string DIC_M1MEISAILIST = "DIC_M1MEISAILIST";

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

	}
}
