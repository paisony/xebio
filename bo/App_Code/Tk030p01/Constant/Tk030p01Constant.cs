namespace com.xebio.bo.Tk030p01.Constant
{
  /// <summary>
  /// Tk030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tk030p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tk030p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// 評価損処理
		/// </summary>
		public const string FORMID_01 = "Tk030f01";
		#endregion

		#region SQL-ID
		/// <summary>
		/// 評価損NB一括確定 検索
		/// </summary>
		public const string SQL_ID_01 = "TK030P01-01";
		/// <summary>
		/// 評価損NB一括確定
		/// </summary>
		public const string SQL_ID_02 = "TK030P01-02";
		/// <summary>
		/// 評価損NB一括確定
		/// </summary>
		public const string SQL_ID_03 = "TK030P01-03";
		/// <summary>
		/// 評価損NB一括確定
		/// </summary>
		public const string SQL_ID_04 = "TK030P01-04";

		/// <summary>
		/// 評価損NB一括確定
		/// 置き換え変数 店舗コード FROM
		/// </summary>
		public const string REPLACE_ID_TENPO_CD_FROM = "REPLACE_ID_TENPO_CD_FROM";
		/// <summary>
		/// 評価損NB一括確定
		/// 置き換え変数 店舗コード TO
		/// </summary>
		public const string REPLACE_ID_TENPO_CD_TO = "REPLACE_ID_TENPO_CD_TO";
		/// <summary>
		/// 評価損NB一括確定
		/// 置き換え変数 処理月
		/// </summary>
		public const string REPLACE_ID_SYORI_YM = "REPLACE_ID_SYORI_YM";
		/// <summary>
		/// 評価損NB一括確定
		/// 置き換え変数 調達区分
		/// </summary>
		public const string REPLACE_ID_TYOTATSU_KB = "REPLACE_ID_TYOTATSU_KB";
		#endregion

		#region Dictionary 更新条件
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
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１店舗コード
		/// </summary>
		public const string DIC_TENPO_CD = "DIC_TENPO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１管理No
		/// </summary>
		public const string DIC_KANRI_NO = "DIC_KANRI_NO";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１処理日付
		/// </summary>
		public const string DIC_SYORI_YMD = "DIC_SYORI_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１処理時間
		/// </summary>
		public const string DIC_SYORI_TM = "DIC_SYORI_TM";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１行No
		/// </summary>
		public const string DIC_GYO_NBR = "DIC_GYO_NBR";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_BURANDO_CD = "DIC_BURANDO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１色コード
		/// </summary>
		public const string DIC_IRO_CD = "DIC_IRO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１サイズコード
		/// </summary>
		public const string DIC_SIZE_CD = "DIC_SIZE_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１商品コード
		/// </summary>
		public const string DIC_SYOHIN_CD = "DIC_SYOHIN_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 調達区分
		/// </summary>
		public const string DIC_TYOTATSU_KB = "DIC_TYOTATSU_KB";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損種別区分
		/// </summary>
		public const string DIC_HYOKASONSYUBETSU_KB_WK = "DIC_HYOKASONSYUBETSU_KB_WK";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損理由区分
		/// </summary>
		public const string DIC_HYOKASONRIYU_KB = "DIC_HYOKASONRIYU_KB";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損理由
		/// </summary>
		public const string DIC_HYOKASONRIYU_WK = "DIC_HYOKASONRIYU_WK";

		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１申請日
		/// </summary>
		public const string DIC_M1APPLY_YMD = "DIC_M1APPLY_YMD";
		#endregion

		#region Dictionary 定数
		/// <summary>
		/// 定数 ディクショナリ
		/// 日付
		/// </summary>
		public const string DIC_SYSDATE = "DIC_SYSDATE";

		/// <summary>
		/// 定数 ディクショナリ
		/// 時刻
		/// </summary>
		public const string DIC_SYSTIME = "DIC_SYSTIME";
		#endregion

		#region Dictionary ツールチップ
		/// <summary>
		/// 定数 ツールチップ
		/// 店舗名
		/// </summary>
		public const string DIC_TENPO_NM = "DIC_TENPO_NM";
		/// <summary>
		/// 定数 ツールチップ
		/// 部門カナ名
		/// </summary>
		public const string DIC_BUMONKANA_NM = "DIC_BUMONKANA_NM";
		/// <summary>
		/// 定数 ツールチップ
		/// 品種略名称
		/// </summary>
		public const string DIC_HINSYU_RYAKU_NM = "DIC_HINSYU_RYAKU_NM";
		#endregion


		#region 定数

		/// <summary>
		/// 名称マスタ 識別コード 却下理由
		/// </summary>
		public const string MEISHO_SIKIBETSU_CD_KYAKKARIYU = "HKKR";

		#endregion

	}
}
