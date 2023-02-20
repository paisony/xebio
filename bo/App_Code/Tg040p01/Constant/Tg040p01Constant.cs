namespace com.xebio.bo.Tg040p01.Constant
{
  /// <summary>
  /// Tg040p01の定数を定義するクラスです。
  /// </summary>
  public static class Tg040p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tg040p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tg040f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tg040f02";
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

		#region SESSION_KEY
		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";
		#endregion

		#region サイズ検索
		/// <summary>
		/// サイズ検索　KEY
		/// </summary>
		public const string DIC_SIZE_SEARCH_RESULT = "DIC_SIZE_SEARCH_RESULT";
		/// <summary>
		/// サイズ検索　INDEX
		/// </summary>
		public const string DIC_FOCUS_INDEX = "DIC_FOCUS_INDEX";
		#endregion

		#region シール発行用
		/// <summary>
		/// ファサード ユーザオブジェクト
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_SEAL_CSVFLNM = "FCDUO_SEAL_CSVFLNM";
		/// <summary>
		/// ファサード ユーザオブジェクト
		/// 出力プライスシールレイアウト名
		/// </summary>
		public const string FCDUO_SEAL_LAYOUTNM = "FCDUO_SEAL_LAYOUTNM";
		#endregion

		#region SQL-ID
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 検索
		/// </summary>
		public const string SQL_ID_01 = "TG040P01-01";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 Ｍ１日付リンク
		/// </summary>
		public const string SQL_ID_02 = "TG040P01-02";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 CSV出力処理
		/// </summary>
		public const string SQL_ID_03 = "TG040P01-03";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書TBL(H)]削除処理
		/// </summary>
		public const string SQL_ID_04 = "TG040P01-04";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書TBL(B)]削除処理
		/// </summary>
		public const string SQL_ID_05 = "TG040P01-05";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書一時TBL]登録
		/// </summary>
		public const string SQL_ID_06 = "TG040P01-06";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書TBL(H)]更新
		/// </summary>
		public const string SQL_ID_07 = "TG040P01-07";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書TBL(B)]削除
		/// </summary>
		public const string SQL_ID_08 = "TG040P01-08";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 [商品明細書TBL(B)]登録
		/// </summary>
		public const string SQL_ID_09 = "TG040P01-09";
		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 検索
		/// 置き換え変数 CSV出力
		/// </summary>
		public const string SQL_ID_03_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 日付リンク
		/// 置き換え変数 処理日付
		/// </summary>
		public const string REP_SYORI_YMD = "BIND_SYORI_YMD";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 日付リンク
		/// 置き換え変数 管理№
		/// </summary>
		public const string REP_KANRI_NO = "BIND_KANRI_NO";
		/// <summary>
		/// 商品ｽﾄｯｸ明細書発行 日付リンク
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string REP_TENPO_CD = "BIND_TENPO_CD";

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
		/// Ｍ１日付リンク
		/// </summary>
		public const string DIC_M1YMD = "DIC_M1YMD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 管理No
		/// </summary>
		public const string DIC_KANRI_NO = "DIC_KANRI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 担当者コード
		/// </summary>
		public const string DIC_TANCD = "DIC_TANCD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理日付
		/// </summary>
		public const string DIC_SYORI_YMD = "DIC_SYORI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理時間
		/// </summary>
		public const string DIC_SYORI_TM = "DIC_SYORI_TM";

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
		/// 部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自社品番
		/// </summary>
		public const string DIC_M1XEBIO_CD = "DIC_M1XEBIO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// メーカー品番
		/// </summary>
		public const string DIC_M1HIN_NBR = "DIC_M1HIN_NBR";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 商品名(カナ)
		/// </summary>
		public const string DIC_M1SYONMK = "DIC_M1SYONMK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 販売完了日
		/// </summary>
		public const string DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サイズ略名称カナ
		/// </summary>
		public const string DIC_M1SIZE_NM = "DIC_M1SIZE_NM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１日付リンク_画面表示用
		/// </summary>
		public const string DIC_M1YMD_DISP = "DIC_M1YMD_DISP";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１時間_画面表示用
		/// </summary>
		public const string DIC_M1TM_DISP = "DIC_M1TM_DISP";
		#endregion

		#region Dictionary 排他ＳＱＬ
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１更新日
		/// </summary>
		public const string DIC_UPD_YMD = "DIC_UPD_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１更新時間
		/// </summary>
		public const string DIC_UPD_TM = "DIC_UPD_TM";
		#endregion

		#region Dictionary シール発行
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品区分
		/// </summary>
		public const string DIC_M1ITEMKBN = "DIC_M1ITEMKBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入区分
		/// </summary>
		public const string DIC_M1SIIRE_KB = "DIC_M1SIIRE_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１調達区分
		/// </summary>
		public const string DIC_M1TYOTATSU_KB = "DIC_M1TYOTATSU_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 現売価
		/// </summary>
		public const string DIC_SLPR = "DIC_SLPR";
		/// <summary>
		/// 明細部 ディクショナリ
		/// メーカー希望小売価格
		/// </summary>
		public const string DIC_JODAI2_TNK = "DIC_JODAI2_TNK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入先コード
		/// </summary>
		public const string DIC_SIIRESAKI_CD = "DIC_SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１税区分
		/// </summary>
		public const string DIC_M1ZEI_KB = "DIC_M1ZEI_KB";
		#endregion

	}
}
