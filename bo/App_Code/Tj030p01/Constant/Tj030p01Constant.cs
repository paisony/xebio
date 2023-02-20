namespace com.xebio.bo.Tj030p01.Constant
{
  /// <summary>
  /// Tj030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj030p01Constant
	{

		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tj030p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tj030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tj030f02";

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
		/// <summary>
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 棚卸検索(V)-一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TJ030P01-01";
		/// <summary>
		/// 棚卸検索(V)-一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TJ030P01-02";
		/// <summary>
		/// 棚卸検索(V)-一覧 CSV出力
		/// </summary>
		public const string SQL_ID_03 = "TJ030P01-03";
		/// <summary>
		/// 棚卸検索(V)-一覧 Ｍ１フェイスNoリンク(店舗)
		/// </summary>
		public const string SQL_ID_04 = "TJ030P01-04";
		/// <summary>
		/// 棚卸検索(V)-一覧 Ｍ１フェイスNoリンク(業者)
		/// </summary>
		public const string SQL_ID_05 = "TJ030P01-05";
		/// <summary>
		/// 棚卸検索(V)-一覧 確定ボタン
		/// 棚卸確定TBL(H)削除
		/// </summary>
		public const string SQL_ID_06 = "TJ030P01-06";
		/// <summary>
		/// 棚卸検索(V)-一覧 確定ボタン
		/// 棚卸確定TBL(B)削除
		/// </summary>
		public const string SQL_ID_07 = "TJ030P01-07";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 棚卸検索(V)-一覧 件数チェック/検索/CSV出力
		/// 置き換え変数
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_1 = "REP_ADD_WHERE_1";
		/// <summary>
		/// 棚卸検索(V)-一覧 件数チェック/検索/CSV出力
		/// 置き換え変数
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_2 = "REP_ADD_WHERE_2";
		/// <summary>
		/// 棚卸検索(V)-一覧 検索 棚卸合計数量取得1(店舗)
		/// 置き換え変数
		/// </summary>
		public const string SQL_ID_02_REP_TANAOROSIGOKEI_SU_1 = "REP_TANAOROSIGOKEI_SU_1";
		/// <summary>
		/// 棚卸検索(V)-一覧 検索 棚卸合計数量取得2(業者)
		/// 置き換え変数
		/// </summary>
		public const string SQL_ID_02_REP_TANAOROSIGOKEI_SU_2 = "REP_TANAOROSIGOKEI_SU_2";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_04_REP_TENCD = "BIND_TENCD";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 フェイス№
		/// </summary>
		public const string SQL_ID_04_REP_FACE_NO = "BIND_FACE_NO";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 棚段
		/// </summary>
		public const string SQL_ID_04_REP_TANA_DAN = "BIND_TANA_DAN";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 回数
		/// </summary>
		public const string SQL_ID_04_REP_KAI_SU = "BIND_KAI_SU";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 棚卸日
		/// </summary>
		public const string SQL_ID_04_REP_TANAOROSI_YMD = "BIND_TANAOROSI_YMD";
		/// <summary>
		/// 棚卸検索(V)-一覧 明細
		/// 置き換え変数 送信回数
		/// </summary>
		public const string SQL_ID_04_REP_SOSINKAI_SU = "BIND_SOSINKAI_SU";

		#endregion

		#region カード部  ディクショナリ

		/// <summary>
		/// カード部  ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_TENPO_CD = "HEAD_TENPO_CD";
		/// <summary>
		/// カード部  ディクショナリ
		/// 店舗名
		/// </summary>
		public const string DIC_TENPO_NM= "HEAD_TENPO_NM";

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番 １～５
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD1 = "DIC_SEARCH_XEBIOCD1";
		public const string DIC_SEARCH_XEBIOCD2 = "DIC_SEARCH_XEBIOCD2";
		public const string DIC_SEARCH_XEBIOCD3 = "DIC_SEARCH_XEBIOCD3";
		public const string DIC_SEARCH_XEBIOCD4 = "DIC_SEARCH_XEBIOCD4";
		public const string DIC_SEARCH_XEBIOCD5 = "DIC_SEARCH_XEBIOCD5";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索JANコード １～５
		/// </summary>
		public const string DIC_SEARCH_JANCD1 = "DIC_SEARCH_JANCD1";
		public const string DIC_SEARCH_JANCD2 = "DIC_SEARCH_JANCD2";
		public const string DIC_SEARCH_JANCD3 = "DIC_SEARCH_JANCD3";
		public const string DIC_SEARCH_JANCD4 = "DIC_SEARCH_JANCD4";
		public const string DIC_SEARCH_JANCD5 = "DIC_SEARCH_JANCD5";

		#endregion
		#endregion

		#region 明細部 ディクショナリ

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
		/// 棚卸日
		/// </summary>
		public const string DIC_M1TANAOROSI_YMD = "DIC_M1TANAOROSI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信回数
		/// </summary>
		public const string DIC_M1SOSINKAI_SU = "DIC_M1SOSINKAI_SU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入力担当者コード
		/// </summary>
		public const string DIC_M1NYURYOKUTAN_CD = "DIC_M1NYURYOKUTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗／業者区分
		/// </summary>
		public const string DIC_M1TENPO_GYOSYA_KB = "DIC_M1TENPO_GYOSYA_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// フェイスNo
		/// </summary>
		public const string DIC_M1FACE_NO = "DIC_M1FACE_NO";
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
