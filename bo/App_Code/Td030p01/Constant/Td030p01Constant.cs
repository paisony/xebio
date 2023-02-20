namespace com.xebio.bo.Td030p01.Constant
{
  /// <summary>
  /// Td030p01の定数を定義するクラスです。
  /// </summary>
  public static class Td030p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Td030p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Td030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Td030f02";

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

		#region SQL-ID

		/// <summary>
		/// 返品検索一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TD030P01-01";
		/// <summary>
		/// 返品検索一覧 件数チェック（伝票状態＝空白）
		/// </summary>
		public const string SQL_ID_02 = "TD030P01-02";
		/// <summary>
		/// 返品検索一覧 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TD030P01-03";
		/// <summary>
		/// 返品検索一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TD030P01-04";
		/// <summary>
		/// 返品検索一覧 検索(履歴テーブル)
		/// </summary>
		public const string SQL_ID_05 = "TD030P01-05";
		/// <summary>
		/// 返品検索一覧 検索(予定・確定テーブル)
		/// </summary>
        public const string SQL_ID_06 = "TD030P01-06";
		/// <summary>
		/// 返品検索明細 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_07 = "TD030P01-07";
		/// <summary>
		/// 返品検索明細 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_08 = "TD030P01-08";
		/// <summary>
		/// 返品検索明細 検索(履歴テーブル)
		/// </summary>
		public const string SQL_ID_09 = "TD030P01-09";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string REP_TABLE_ID = "TABLE_ID";

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string REP_ADD_WHERE1 = "ADD_WHERE1";

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件2（伝票状態＝空白）
		/// </summary>
		public const string REP_ADD_WHERE2 = "ADD_WHERE2";

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 バインド変数1
		/// </summary>
		public const string REP_ADD_BIND1 = "B1";

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 バインド変数2（伝票状態＝空白）
		/// </summary>
		public const string REP_ADD_BIND2 = "B2";

		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 管理No
		/// </summary>
		public const string SQL_REP_KANRI_NO = "KANRI_NO";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 処理日付
		/// </summary>
		public const string SQL_REP_SYORI_YMD = "SYORI_YMD";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_REP_TENPO_CD = "TENPO_CD";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 履歴No
		/// </summary>
		public const string SQL_REP_RIREKI_NO = "RIREKI_NO";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 赤黒区分
		/// </summary>
		public const string SQL_REP_AKAKURO_KBN = "AKAKURO_KBN";
		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// フォーカス項目
		/// </summary>
		public const string DIC_FOCUS_ITEM = "DIC_FOCUS_ITEM";

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
		/// 管理No
		/// </summary>
		public const string DIC_M1KANRI_NO = "DIC_M1KANRI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入力担当者コード
		/// </summary>
		public const string DIC_M1NYURYOKUTAN_CD = "DIC_M1NYURYOKUTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確認担当者コード
		/// </summary>
		public const string DIC_M1KAKUTEITAN_CD = "DIC_M1KAKUTEITAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理日付
		/// </summary>
		public const string DIC_M1SYORI_YMD = "DIC_M1SYORI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 履歴No
		/// </summary>
		public const string DIC_M1RIREKI_NO = "DIC_M1RIREKI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 赤黒区分
		/// </summary>
		public const string DIC_M1AKAKURO_KBN = "DIC_M1AKAKURO_KBN";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信済フラグ
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
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
		/// 参照テーブル
		/// </summary>
		public const string DIC_M1TBL_KBN = "DIC_M1TBL_KBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定種別
		/// </summary>
		public const string DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";

		#endregion

		#region 参照テーブル

		/// <summary>
		/// 参照テーブル 返品予定テーブル
		/// </summary>
		public const string TBL_YOTEI = "1";
		/// <summary>
		/// 参照テーブル 返品確定テーブル
		/// </summary>
		public const string TBL_KAKUTEI = "2";
		/// <summary>
		/// 参照テーブル 返品確定履歴テーブル
		/// </summary>
		public const string TBL_RIREKI = "3";

		#endregion

	}
}
