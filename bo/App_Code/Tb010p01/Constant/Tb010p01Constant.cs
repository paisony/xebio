namespace com.xebio.bo.Tb010p01.Constant
{
  /// <summary>
  /// Tb010p01の定数を定義するクラスです。
  /// </summary>
  public static class Tb010p01Constant
	{
		
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tb010p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tb010f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tb010f02";

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

		/// <summary>
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 仕入入荷検索一覧(予定、確定) 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TB010P01-01";

		/// <summary>
		/// 仕入入荷検索一覧 件数チェック
		/// </summary>
		public const string SQL_ID_02 = "TB010P01-02";

		/// <summary>
		/// 仕入入荷検索一覧 検索(予定、確定テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TB010P01-03";

		/// <summary>
		/// 仕入入荷検索一覧 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TB010P01-04";

		/// <summary>
		/// 仕入入荷検索一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_05 = "TB010P01-05";

		/// <summary>
		/// 仕入入荷検索一覧 検索(履歴テーブル)
		/// </summary>
		public const string SQL_ID_06 = "TB010P01-06";

		/// <summary>
		/// 仕入入荷検索明細 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_07 = "TB010P01-07";

		/// <summary>
		/// 仕入入荷検索明細 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_08 = "TB010P01-08";

		/// <summary>
		/// 仕入入荷検索明細 検索(履歴テーブル)
		/// </summary>
		public const string SQL_ID_09 = "TB010P01-09";

		/// <summary>
		/// 仕入入荷検索一覧 CSV(予定、確定テーブル)
		/// </summary>
		public const string SQL_ID_10 = "TB010P01-10";

		/// <summary>
		/// 仕入入荷検索一覧 CSV(予定テーブル)
		/// </summary>
		public const string SQL_ID_11 = "TB010P01-11";

		/// <summary>
		/// 仕入入荷検索一覧 CSV(確定テーブル)
		/// </summary>
		public const string SQL_ID_12 = "TB010P01-12";

		/// <summary>
		/// 仕入入荷検索一覧 CSV(履歴テーブル)
		/// </summary>
		public const string SQL_ID_13 = "TB010P01-13";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 仕入入荷検索一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID1 = "TABLE_ID1";

		/// <summary>
		/// 仕入入荷検索一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID2 = "TABLE_ID2";

		/// <summary>
		/// 仕入入荷検索一覧 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE1 = "ADD_WHERE1";

		/// <summary>
		/// 仕入入荷検索一覧 件数チェック／検索
		/// 置き換え変数 検索条件2
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE2 = "ADD_WHERE2";

		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 確定種別
		/// </summary>
		public const string SQL_ID_07_REP_KAKUTEI_SB = "KAKUTEI_SB";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 仕入先コード
		/// </summary>
		public const string SQL_ID_07_REP_SIIRESAKI_CD = "SIIRESAKI_CD";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_07_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 入荷予定日
		/// </summary>
		public const string SQL_ID_07_REP_SITEINOHIN_YMD = "SITEINOHIN_YMD";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_07_REP_TENPO_CD = "TENPO_CD";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 履歴No
		/// </summary>
		public const string SQL_ID_07_REP_RIREKI_NO = "RIREKI_NO";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 赤黒区分
		/// </summary>
		public const string SQL_ID_07_REP_AKAKURO_KBN = "AKAKURO_KBN";

		#endregion

		#region TABLE-ID

		/// <summary>
		/// 仕入入荷予定テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDPT0010 = "MDPT0010";

		/// <summary>
		/// 仕入入荷確定テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDPT0020 = "MDPT0020";

		/// <summary>
		/// 仕入入荷履歴テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDPT0060 = "MDPT0060";

		#endregion

		#region 帳票区分

		/// <summary>
		/// 帳票区分  マニュアル仕入伝票
		/// </summary>
		public const string REPORT_KBN_MANUAL = "1";

		/// <summary>
		/// 帳票区分  仕入訂正伝票
		/// </summary>
		public const string REPORT_KBN_TEISEI = "2";

		/// <summary>
		/// 帳票区分  2帳票両方
		/// </summary>
		public const string REPORT_KBN_ALL = "3";

		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 帳票区分
		/// </summary>
		public const string DIC_REPORT_KBN = "DIC_REPORT_KBN";

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
		/// 担当者コード
		/// </summary>
		public const string DIC_M1TANTOSYA_CD = "DIC_M1TANTOSYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 担当者名
		/// </summary>
		public const string DIC_M1TANTOSYA_NM = "DIC_M1TANTOSYA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票状態
		/// </summary>
		public const string DIC_M1DENPYO_JYOTAI = "DIC_M1DENPYO_JYOTAI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定種別
		/// </summary>
		public const string DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
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
		public static object DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";

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
