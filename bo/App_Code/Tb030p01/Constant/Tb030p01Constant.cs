namespace com.xebio.bo.Tb030p01.Constant
{
  /// <summary>
  /// Tb030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tb030p01Constant
	{

		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tb030p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tb030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tb030f02";

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

		#region SQL-ID

		/// <summary>
		/// 仕入入荷確定一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TB030P01-01";

		/// <summary>
		/// 仕入入荷確定一覧 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_02 = "TB010P01-04";

		/// <summary>
		/// 仕入入荷確定一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TB010P01-05";

		/// <summary>
		/// 仕入入荷確定明細 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TB010P01-07";

		/// <summary>
		/// 仕入入荷確定明細 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_05 = "TB010P01-08";

		/// <summary>
		/// SCM予定TBL(B)の取得
		/// </summary>
		public const string SQL_ID_06 = "C01020-01";

		/// <summary>
		/// [SCM予定TBL(H)]のFOR UPDATE
		/// </summary>
		public const string SQL_ID_07 = "C01020-02";

		/// <summary>
		/// [仕入入荷予定TBL(B)]の更新
		/// </summary>
		public const string SQL_ID_08 = "C01020-03";

		/// <summary>
		/// [仕入入荷予定TBL(H)]の更新
		/// </summary>
		public const string SQL_ID_09 = "C01020-04";

		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録
		/// </summary>
		public const string SQL_ID_10 = "C01020-07";

		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録
		/// </summary>
		public const string SQL_ID_11 = "C01020-08";

		/// <summary>
		/// [仕入入荷確定TBL(H)]の削除
		/// </summary>
		public const string SQL_ID_12 = "TB030P01-02";

		/// <summary>
		/// [仕入入荷確定TBL(B)]の削除
		/// </summary>
		public const string SQL_ID_13 = "TB030P01-03";

		/// <summary>
		/// SCM検品督促リストデータ 削除
		/// </summary>
		public const string SQL_ID_14 = "TB030P01-04";

		/// <summary>
		/// [仕入入荷確定TBL(H)]を更新する。
		/// </summary>
		public const string SQL_ID_15 = "TB030P01-05";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 仕入入荷確定一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID = "TABLE_ID1";
		/// <summary>
		/// 仕入入荷確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE1";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 確定種別
		/// </summary>
		public const string SQL_ID_04_REP_KAKUTEI_SB = "KAKUTEI_SB";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 仕入先コード
		/// </summary>
		public const string SQL_ID_04_REP_SIIRESAKI_CD = "SIIRESAKI_CD";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_04_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 入荷予定日
		/// </summary>
		public const string SQL_ID_04_REP_SITEINOHIN_YMD = "SITEINOHIN_YMD";
		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_04_REP_TENPO_CD = "TENPO_CD";

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
		/// 確定担当者コード
		/// </summary>
		public const string DIC_M1FIXED_TANCD = "DIC_M1FIXED_TANCD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定種別
		/// </summary>
		public const string DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信済フラグ
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 納品書日付
		/// </summary>
		public const string DIC_M1NOHINSYO_YMD = "DIC_M1NOHINSYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サブ仕入先コード
		/// </summary>
		public const string DIC_M1SUBSIIRESAKI_CD = "DIC_M1SUBSIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入予定合計数量
		/// </summary>
		public const string DIC_M1SIIREYOTEIGOKEI_SU = "DIC_M1SIIREYOTEIGOKEI_SU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入予定合計金額
		/// </summary>
		public const string DIC_M1SIIREYOTEIGOKEI_KIN = "DIC_M1SIIREYOTEIGOKEI_KIN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定状態
		/// </summary>
		public const string DIC_M1KAKUTEI_JYOTAI = "DIC_M1KAKUTEI_JYOTAI";
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
