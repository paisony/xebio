namespace com.xebio.bo.Td010p01.Constant
{
  /// <summary>
  /// Td010p01の定数を定義するクラスです。
  /// </summary>
  public static class Td010p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Td010p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Td010f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Td010f02";

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
		public const string SQL_ID_01 = "TD010P01-01";
		/// <summary>
		/// 返品検索一覧 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_02 = "TD010P01-02";
		/// <summary>
		/// 返品検索一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TD010P01-03";
		/// <summary>
		/// 返品検索明細 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TD010P01-04";
		/// <summary>
		/// 返品検索明細 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_05 = "TD010P01-05";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID = "TABLE_ID";

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 管理No
		/// </summary>
		public const string SQL_ID_04_REP_KANRI_NO = "KANRI_NO";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_04_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 処理日付
		/// </summary>
		public const string SQL_ID_04_REP_SYORI_YMD = "SYORI_YMD";
		/// <summary>
		/// 返品確定明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_04_REP_TENPO_CD = "TENPO_CD";

		#endregion

		#region Dictionary カード部

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
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理日付
		/// </summary>
		public const string DIC_M1SYORI_YMD = "DIC_M1SYORI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理時間
		/// </summary>
		public const string DIC_M1SYORI_TM = "DIC_M1SYORI_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サブ仕入先
		/// </summary>
		public const string DIC_M1SUBSIIRESAKI_CD = "DIC_M1SUBSIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 返品理由
		/// </summary>
		public const string DIC_M1HENPIN_RIYU = "DIC_M1HENPIN_RIYU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 担当者コード
		/// </summary>
		public const string DIC_M1TANTOSYA_CD = "DIC_M1TANTOSYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日付
		/// </summary>
		public const string DIC_M1UPD_YMD = "DIC_M1UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string DIC_M1UPD_TM = "DIC_M1UPD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新担当者コード
		/// </summary>
		public const string DIC_M1UPD_TANCD = "DIC_M1UPD_TANCD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシリアル番号
		/// </summary>
		public const string DIC_M1HHTSERIAL_NO = "DIC_M1HHTSERIAL_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシーケンスNo
		/// </summary>
		public const string DIC_M1HHTSEQUENCE_NO = "DIC_M1HHTSEQUENCE_NO";
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
		/// 更新時、採番した伝票番号
		/// </summary>
		public const string DIC_M1AOUNUM_DENNO = "DIC_M1AOUNUM_DENNO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
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
		/// JANコード
		/// </summary>
		public const string DIC_M1JANCD = "DIC_M1JANCD";

		#endregion

		#region 返品伝票 帳票ID
		///// <summary>
		///// 返品伝票 帳票ID
		///// </summary>
		//public const string REPORTID_HENPINDENPYO = "TD010L01";
		///// <summary>
		///// 返品伝票 帳票名
		///// </summary>
		//public const string REPORTNM_HENPINDENPYO = "返品伝票";


		#endregion

	}
}
