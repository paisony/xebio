namespace com.xebio.bo.Te130p01.Constant
{
  /// <summary>
  /// Te130p01の定数を定義するクラスです。
  /// </summary>
  public static class Te130p01Constant
	{
		#region プログラムID

		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Te130p01";

		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Te130f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Te130f02";

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

		#region プログラム固定値
		/// <summary>
		/// チェックモード 印刷
		/// </summary>
		public const string CHECK_MODE_BTNPRINT = "0";
		/// <summary>
		/// 参照テーブル 移動出荷履歴TBL
		/// </summary>
		public const string REF_TBL_RIREKI = "2";
		/// <summary>
		/// 明細用 ディクショナリ
		/// 参照テーブル 
		/// </summary>
		public const string DIC_REF_TBL = "DIC_REF_TBL";
		/// <summary>
		/// 参照テーブル 移動出荷確定TBL
		/// </summary>
		public const string REF_TBL_KAKU = "1";
		
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
		/// 送信済みフラグ
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 
		/// </summary>
		public const string DIC_M1SCM_CD = "DIC_M1SCM_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷会社コード
		/// </summary>
		public const string DIC_M1NYUKAKAI_CD = "DIC_M1NYUKAKAI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷会社名
		/// </summary>
		public const string DIC_M1NYUKAKAI_NM = "DIC_M1NYUKAKAI_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録担当者名
		/// </summary>
		public const string DIC_M1ADDTAN_CD = "DIC_M1ADDTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷担当者名
		/// </summary>
		public const string DIC_M1NYUKAHANBAI_NM = "DIC_M1NYUKAHANBAI_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷会社コード
		/// </summary>
		public const string DIC_M1SYUKKAKAI_CD = "DIC_M1SYUKKAKAI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷会社名
		/// </summary>
		public const string DIC_M1SYUKKAKAI_NM = "DIC_M1SYUKKAKAI_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷担当者コード
		/// </summary>
		public const string DIC_M1SYUKKATAN_CD = "DIC_M1SYUKKATAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷担当者名
		/// </summary>
		public const string DIC_M1SYUKKAHANBAI_NM = "DIC_M1SYUKKAHANBAI_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYOBANGO = "DIC_M1DENPYOBANGO";
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

		#region SQL-ID
		/// <summary>
		/// 企業間仕入伝票 [企業間仕入伝票TBL(H)]件数チェック1
		/// </summary>
		public const string SQL_ID_01 = "Te130p01-011";
		/// <summary>
		/// 企業間仕入伝票 [企業間仕入伝票TBL(H)]件数チェック2
		/// </summary>
		public const string SQL_ID_02 = "Te130p01-02";
		/// <summary>
		/// 企業間仕入伝票 [企業間仕入伝票TBL(B)]件数チェック
		/// </summary>
		public const string SQL_ID_03 = "Te130p02-01";
		/// <summary>
		/// 企業間明細一覧 CSV(履歴テーブル)
		/// </summary>
		public const string SQL_ID_11 = "TE130P01-11";
		/// <summary>
		/// 企業間一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID1 = "TABLE_ID1";
		/// <summary>
		/// 企業間一覧 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE1 = "ADD_WHERE1";

		/// <summary>
		/// 企業間仕入れテーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDNT0060 = "MDNT0060";

		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 補充依頼結果 [補充依頼結果TBL(H) 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// 補充依頼結果 [補充依頼結果TBL(H) 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_02_REP_ADD_MEISAI = "MEISAI";

		/// <summary>
		/// 置き換え変数 ソート条件自社会社1
		/// </summary>
		public const string REP_ORDER_JISYAKAIASYA1 = "BIND_JISYAKAIASYA1";
		/// <summary>
		/// 置き換え変数 ソート条件自社会社2
		/// </summary>
		public const string REP_ORDER_JISYAKAIASYA2 = "BIND_JISYAKAIASYA2";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数 入荷会社コード
		/// </summary>
		public const string SQL_ID_02_JYURYOKAISYA_CD = "JYURYOKAISYA_CD";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_02_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数 入荷店コード
		/// </summary>
		public const string SQL_ID_02_JYURYOTEN_CD = "JYURYOTEN_CD";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数 入荷日
		/// </summary>
		public const string SQL_ID_02_JYURYO_YMD = "JYURYO_YMD";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数　履歴No
		/// </summary>
		public const string SQL_ID_02_RIREKI_NO = "RIREKI_NO";
		/// <summary>
		/// 企業間仕入明細 
		/// 置き換え変数 赤黒区分
		/// </summary>
		public const string SQL_ID_02_AKAKURO_KBN = "AKAKURO_KBN";



		#endregion
	}
}
