namespace com.xebio.bo.Tb020p01.Constant
{
  /// <summary>
  /// Tb020p01の定数を定義するクラスです。
  /// </summary>
  public static class Tb020p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tb020p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tb020f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tb020f02";

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
		/// SCM仕入入荷検索-一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TB020P01-01";
		/// <summary>
		/// SCM仕入入荷検索-一覧 検索(予定)
		/// </summary>
		public const string SQL_ID_02 = "TB020P01-02";
		/// <summary>
		/// SCM仕入入荷検索-一覧 検索(確定)
		/// </summary>
		public const string SQL_ID_03 = "TB020P01-03";
		/// <summary>
		/// SCM仕入入荷検索-明細 件数チェック
		/// </summary>
		public const string SQL_ID_04 = "TB020P01-04";
		/// <summary>
		/// SCM仕入入荷検索-明細 検索(予定)
		/// </summary>
		public const string SQL_ID_05 = "TB020P01-05";
		/// <summary>
		/// SCM仕入入荷検索-明細 検索(確定)
		/// </summary>
		public const string SQL_ID_06 = "TB020P01-06";
		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// SCM仕入入荷検索 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID = "TABLE_ID";
		/// <summary>
		/// SCM仕入入荷検索 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// SCM仕入入荷検索-明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_04_REP_TENPO_CD = "TENPO_CD";
		/// <summary>
		/// SCM仕入入荷検索-明細 検索 
		/// 置き換え変数 SCMコード
		/// </summary>
		public const string SQL_ID_04_REP_SCM_CD = "SCM_CD";
		/// <summary>
		/// SCM仕入入荷検索-明細 検索 
		/// 置き換え変数 納入先着予定日
		/// </summary>
		public const string SQL_ID_04_REP_NONYUTYAKUYOTEI_YMD = "NONYUTYAKUYOTEI_YMD";
		#endregion

		#region Dictionary カード部
		#endregion

		#region Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ＮＯ
		/// </summary>
		public const string DIC_M1ROWNUM = "DIC_M1ROWNUM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入先コード
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入先名称
		/// </summary>
		public const string DIC_M1SIIRESAKI_RYAKU_NM = "DIC_M1SIIRESAKI_RYAKU_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１入荷予定日
		/// </summary>
		public const string DIC_M1NONYUTYAKUYOTEI_YMD = "DIC_M1NONYUTYAKUYOTEI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入確定日
		/// </summary>
		public const string DIC_M1ADD_YMD = "DIC_M1ADD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１SCMコードリンク
		/// </summary>
		public const string DIC_M1SCM_CD = "DIC_M1SCM_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１合計数量
		/// </summary>
		public const string DIC_M1SYUKKA_SU = "DIC_M1SYUKKA_SU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１原価金額
		/// </summary>
		public const string DIC_M1GENKA_KIN = "DIC_M1GENKA_KIN";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１客注
		/// </summary>
		public const string DIC_M1KYAKUTYU_FLG = "DIC_M1KYAKUTYU_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１値書き
		/// </summary>
		public const string DIC_M1NEGAKIHIN_FLG = "DIC_M1NEGAKIHIN_FLG";


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
