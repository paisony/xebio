namespace com.xebio.bo.Tm050p01.Constant
{
  /// <summary>
  /// Tm050p01の定数を定義するクラスです。
  /// </summary>
  public static class Tm050p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tm050p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tm050f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "";
		#endregion

		#region ディクショナリのキー

		#region 起動パラメータ保持用
		/// <summary>
		/// ディクショナリキー　呼出元画面ID
		/// </summary>
		public const string DIC_FORM_ID = "DIC_FORM_ID";
		/// <summary>
		/// ディクショナリキー　現在行数
		/// </summary>
		public const string DIC_CUR_ROW_CNT = "DIC_CUR_ROW_CNT";
		/// <summary>
		/// ディクショナリキー　最大行数
		/// </summary>
		public const string DIC_MAX_ROW_CNT = "DIC_MAX_ROW_CNT";
		/// <summary>
		/// ディクショナリキー　CSV名称
		/// </summary>
		public const string DIC_CSV_NAME = "DIC_CSV_NAME";
		/// <summary>
		/// ディクショナリキー　CSVチェック情報
		/// </summary>
		public const string DIC_CSV_CHECK_INFO = "DIC_CSV_CHECK_INFO";
		#endregion

		#region Facade用UserObject
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　プログラムVOのディクショナリ
		/// </summary>
		public const string FCDUO_PGFORM_DICTIONARY = "FCDUO_PGFORM_DICTIONARY";
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　アップロード情報
		/// </summary>
		public const string FCDUO_UPLOAD_INFO = "FCDUO_UPLOAD_INFO";
		/// <summary>
		/// ファサードコンテキストのディクショナリキー　取込情報
		/// </summary>
		public const string FCDUO_IMPORT_INFO = "FCDUO_IMPORT_INFO";
		#endregion

		#endregion

		#region 呼出元画面ID
		/// <summary>
		/// 呼出元画面ID　マニュアル仕入
		/// </summary>
		public const string FORMID_TB050F01 = "TB050F01";
		/// <summary>
		/// 呼出元画面ID　返品入力（ﾏﾆｭｱﾙ）
		/// </summary>
		public const string FORMID_TD020F01 = "TD020F01";
		/// <summary>
		/// 呼出元画面ID　移動出荷入力（ﾏﾆｭｱﾙ）
		/// </summary>
		public const string FORMID_TE020F01 = "TE020F01";
		/// <summary>
		/// 呼出元画面ID　商品経費振替申請(V)-明細
		/// </summary>
		public const string FORMID_TF020F02 = "TF020F02";
		/// <summary>
		/// 呼出元画面ID　商品経費振替申請(X)-明細
		/// </summary>
		public const string FORMID_TF021F02 = "TF021F02";
		/// <summary>
		/// 呼出元画面ID　予算登録
		/// </summary>
		public const string FORMID_TF060F01 = "TF060F01";
		/// <summary>
		/// 呼出元画面ID　盗難品登録-明細
		/// </summary>
		public const string FORMID_TF070F02 = "TF070F02";
		#endregion

	}
}
