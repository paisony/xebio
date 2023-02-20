namespace com.xebio.bo.Tj100p01.Constant
{
  /// <summary>
  /// Tj100p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj100p01Constant
	{

		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tj100p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tj100f01";

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
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		#endregion

		#region	カード部 ディクショナリ

		/// <summary>
		/// カード部 ディクショナリ
		/// 更新日
		/// </summary>
		public const string DIC_UPD_YMD = "DIC_UPD_YMD";
		/// <summary>
		/// カード部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string DIC_UPD_TIM = "DIC_UPD_TIM";
		/// <summary>
		/// カード部 ディクショナリ
		/// 棚卸基準日
		/// </summary>
		public const string DIC_TANAOROSIKIJUN_YMD = "DIC_TANAOROSIKIJUN_YMD";
		#endregion

		#region 明細部　ディクショナリ
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ1
		/// </summary>
		public const string DIC_M1FLG1 = "DIC_M1FLG1";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ2
		/// </summary>
		public const string DIC_M1FLG2 = "DIC_M1FLG2";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ3
		/// </summary>
		public const string DIC_M1FLG3 = "DIC_M1FLG3";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ4
		/// </summary>
		public const string DIC_M1FLG4 = "DIC_M1FLG4";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ5
		/// </summary>
		public const string DIC_M1FLG5 = "DIC_M1FLG5";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ6
		/// </summary>
		public const string DIC_M1FLG6 = "DIC_M1FLG6";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フラグ7
		/// </summary>
		public const string DIC_M1FLG7 = "DIC_M1FLG7";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード1
		/// </summary>
		public const string DIC_M1TENPO_CD1 = "DIC_M1TENPO_CD1";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード2
		/// </summary>
		public const string DIC_M1TENPO_CD2 = "DIC_M1TENPO_CD2";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード3
		/// </summary>
		public const string DIC_M1TENPO_CD3 = "DIC_M1TENPO_CD3";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード4
		/// </summary>
		public const string DIC_M1TENPO_CD4 = "DIC_M1TENPO_CD4";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード5
		/// </summary>
		public const string DIC_M1TENPO_CD5 = "DIC_M1TENPO_CD5";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード6
		/// </summary>
		public const string DIC_M1TENPO_CD6 = "DIC_M1TENPO_CD6";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード7
		/// </summary>
		public const string DIC_M1TENPO_CD7 = "DIC_M1TENPO_CD7";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 列1
		/// </summary>
		public const string DIC_M1RETU1 = "DIC_M1RETU1";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 列2
		/// </summary>
		public const string DIC_M1RETU2 = "DIC_M1RETU2";
		/// <summary>
		/// 明細部 ディクショナリ
		///  列3
		/// </summary>
		public const string DIC_M1RETU3 = "DIC_M1RETU3";
		/// <summary>
		/// 明細部 ディクショナリ
		///  列4
		/// </summary>
		public const string DIC_M1RETU4 = "DIC_M1RETU4";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 列5
		/// </summary>
		public const string DIC_M1RETU5 = "DIC_M1RETU5";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 列6
		/// </summary>
		public const string DIC_M1RETU6 = "DIC_M1RETU6";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 列7
		/// </summary>
		public const string DIC_M1RETU7 = "DIC_M1RETU7";

		#endregion

		#region oracle packageName
		/// <summary>
		/// 棚卸取漏れ/欠番検索(カウント用)
		/// </summary>
		public const string ORACLE_PACKAGE_01_COUNT = "MdInventoryNew_v.countInventoryMissingSearch";

		/// <summary>
		/// 棚卸取漏れ/欠番検索(検索)
		/// </summary>
		public const string ORACLE_PACKAGE_01 = "MdInventoryNew_v.searchInventoryMissingSearch";

		#endregion

		#region SQL-ID
		/// <summary>
		/// 棚卸取漏れ欠番検索(V) 確定ボタン
		/// 棚卸欠番TBL]削除
		/// </summary>
		public const string SQL_ID_01 = "TJ100P01-01";
		/// <summary>
		/// 棚卸取漏れ欠番検索(V) 確定ボタン
		/// 棚卸確定TBL(H)存在チェック
		/// </summary>
		public const string SQL_ID_02 = "TJ100P01-02";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 棚卸取漏れ欠番検索(V) 確定ボタン
		/// 棚卸確定TBL(H)存在チェック
		/// </summary>
		public const string SQL_ID_02_REP_ADD_WHERE = "REP_ADD_WHERE";

		#endregion

		#region プログラム用固定値

		/// <summary>
		/// 取漏リスト
		/// フェイスNOFROM、TO区切り文字
		/// </summary>
		public const string FACE_NO_DELIMITER = "～";

		#endregion

	}
}
