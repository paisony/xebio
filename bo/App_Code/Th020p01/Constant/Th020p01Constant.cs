namespace com.xebio.bo.Th020p01.Constant
{
  /// <summary>
  /// Th020p01の定数を定義するクラスです。
  /// </summary>
  public static class Th020p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Th020p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// 在庫検索_一覧
		/// </summary>
		public const string FORMID_01 = "Th020f01";
		/// <summary>
		/// 明細画面フォームID
		/// 在庫検索_明細（店舗別）
		/// </summary>
		public const string FORMID_02 = "Th020f02";
		/// <summary>
		/// 明細画面フォームID
		/// 在庫検索_明細（エリア別）
		/// </summary>
		public const string FORMID_03 = "Th020f03";
		/// <summary>
		/// 明細画面フォームID
		/// 在庫検索_明細（消化率）
		/// </summary>
		public const string FORMID_04 = "Th020f04";

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

		#region 在庫検索_明細(店舗別)

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO_02 = "FCDUO_F01VO_02";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO_02 = "FCDUO_F01M1VO_02";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_02 = "FCDUO_NEXTVO_02";

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM_02 = "FCDUO_FOCUSITEM_02";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW_02 = "FCDUO_FOCUSROW_02";
		#endregion

		#region 在庫検索-明細(エリア別)
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO_03 = "FCDUO_F01VO_03";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO_03 = "FCDUO_F01M1VO_03";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_03 = "FCDUO_NEXTVO_03";

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM_03 = "FCDUO_FOCUSITEM_03";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW_03 = "FCDUO_FOCUSROW_03";
		#endregion

		#region 在庫検索-明細(消化率)
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO_04 = "FCDUO_F01VO_04";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO_04 = "FCDUO_F01M1VO_04";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_04 = "FCDUO_NEXTVO_04";

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM_04 = "FCDUO_FOCUSITEM_04";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW_04 = "FCDUO_FOCUSROW_04";
		#endregion


		#endregion

		#region SQL-ID

		/// <summary>
		/// 在庫検索-一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TH020P01-01";

		/// <summary>
		/// 在庫検索-一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TH020P01-02";

		/// <summary>
		/// 在庫検索-明細(店舗別) サイズリンク
		/// </summary>
		public const string SQL_ID_03 = "TH020P01-03";

		/// <summary>
		/// 在庫検索 展開区分取得
		/// </summary>
		public const string SQL_ID_04 = "TH020P01-04";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 置き換え変数 検索条件
		/// </summary>
		public const string REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// 在庫検索-一覧 検索 
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string REP_ADD_TABLE = "ADD_TABLE";

		/// <summary>
		/// 在庫検索-一覧 検索 
		/// 置き換え変数 テーブル結合
		/// </summary>
		public const string REP_ADD_JOIN = "ADD_JOIN";

		/// <summary>
		/// 在庫検索-明細(店舗別) サイズリンク
		/// 置き換え変数 サブクエリ_商品×店舗
		/// </summary>
		public const string REP_ADD_SUBQUERY_1 = "ADD_SUBQUERY_1";

		/// <summary>
		/// 在庫検索-明細(店舗別) サイズリンク
		/// バインド変数 JANコード
		/// </summary>
		public const string REP_BIND_JAN_CD_W1 = "BIND_JAN_CD_W1";

		/// <summary>
		/// 在庫検索-明細(店舗別) サイズリンク
		/// バインド変数 店舗コード
		/// </summary>
		public const string REP_BIND_TENPO_CD_W1 = "BIND_TENPO_CD_W1";

		/// <summary>
		/// 在庫検索 展開区分取得
		/// バインド変数 自社品番
		/// </summary>
		public const string REP_BIND_JISHAHIN = "BIND_JISHAHIN";

		/// <summary>
		/// 在庫検索 展開区分取得
		/// バインド変数 色コード
		/// </summary>
		public const string REP_BIND_IRO_CD = "BIND_IRO_CD";

		#endregion

		#region oracle packageName
		/// <summary>
		/// 在庫検索明細のデータを取得します。(店舗)
		/// </summary>
		public const string ORACLE_PACKAGE_TENPO = "MDSERCHSTOCK_NEWBO.SELECT_STOCK_SEARCH_DETAIL";

		/// <summary>
		/// 在庫検索明細のデータを取得します。(エリア)
		/// </summary>
		public const string ORACLE_PACKAGE_ERA = "MDSERCHSTOCK_NEWBO.SELECT_STOCK_SEARCH_DETAIL_ERA";

		#endregion

		#region 一覧画面 カード部 ディクショナリ

		/// <summary>
		/// カード部 ディクショナリ
		/// エリアコード
		/// </summary>
		public const string DIC_AREA_CD = "DIC_AREA_CD";

		/// <summary>
		/// カード部 ディクショナリ
		/// エリアコード(背景色色変更)
		/// </summary>
		public const string DIC_AREA_CD_IROCHANGE = "DIC_AREA_CD_IROCHANGE";

		/// <summary>
		/// カード部 ディクショナリ
		/// 在庫検索選択
		/// </summary>
		public const string DIC_ZAIKO_SERCHSTK = "DIC_ZAIKO_SERCHSTK";

		#endregion

		#region 一覧画面 明細部 ディクショナリ

		/// <summary>
		/// 明細部 ディクショナリ
		/// 自社品番
		/// </summary>
		public const string DIC_M1JISYA_HBN = "DIC_M1JISYA_HBN";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string DIC_M1MAKERCOLOR_CD = "DIC_M1MAKERCOLOR_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";

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
		/// 明細部 選択行No
		/// 選択行No
		/// </summary>
		public const string DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";

		#endregion

		#region 明細画面(在庫検索_明細) ディクショナリ
		/// <summary>
		/// 明細部　明細標題
		/// 明細ヘッダ色、JANコード、商品コード格納 ハッシュテーブル
		/// </summary>
		public const string DIC_M1HEAD_HASH = "DIC_M1HEAD_HASH";

		/// <summary>
		/// 明細部　明細リンク
		/// エリア名称
		/// </summary>
		public const string DIC_M1AREA_NM = "DIC_M1AREA_NM";

		/// <summary>
		/// カード部
		/// 展開区分
		/// </summary>
		public const string DIC_TENKAI_KBN = "DIC_TENKAI_KBN";

		/// <summary>
		/// ディクショナリ
		/// 一覧.選択モード
		/// </summary>
		public const string DIC_STKMODENO = "DIC_STKMODENO";

		/// <summary>
		/// ディクショナリ
		/// 一覧.スキャンコードFROM
		/// </summary>
		public const string DIC_SCAN_CD_FROM = "DIC_SCAN_CD_FROM";

		/// <summary>
		/// ディクショナリ
		/// 一覧.スキャンコードTO
		/// </summary>
		/// 
		public const string DIC_SCAN_CD_TO = "DIC_SCAN_CD_TO";

		/// <summary>
		/// ディクショナリ
		/// 一覧.店舗コード
		/// </summary>
		/// 
		public const string DIC_TENPO_CD = "DIC_TENPO_CD";

		/// <summary>
		/// 明細部　明細標題 選択情報
		/// JANコード
		/// </summary>
		public const string DIC_M1HEAD_SELECT_JAN_CD = "DIC_M1HEAD_SELECT_JAN_CD";

		/// <summary>
		/// 明細部　明細標題 選択情報
		/// サイズ
		/// </summary>
		public const string DIC_M1HEAD_SELECT_SIZE_NM = "DIC_M1HEAD_SELECT_SIZE_NM";

		/// <summary>
		/// 明細(消化率)　前画面表示モード
		/// </summary>
		public const string DIC_PREV_ACTION_MODE = "DIC_PREV_ACTION_MODE";

		/// <summary>
		/// 明細(店舗別)　前画面フォームID
		/// </summary>
		public const string DIC_PREV_FORMID = "DIC_PREV_FORMID";

		#endregion

		#region 処理モード

		/// <summary>
		/// 在庫検索-明細 次へボタン
		/// </summary>
		public const string ACTION_NEXT = "ACTION_NEXT";

		/// <summary>
		/// 在庫検索-明細 前へボタン
		/// </summary>
		public const string ACTION_PREV = "ACTION_PREV";

		#endregion

	}
}
