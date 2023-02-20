namespace com.xebio.bo.Tm060p01.Constant
{
  /// <summary>
  /// Tm060p01の定数を定義するクラスです。
  /// </summary>
  public static class Tm060p01Constant
	{
		#region SQL-ID

		/// <summary>
		/// 担当者マスタメンテナンス [担当者権限MST]件数チェック(職制区分なし)
		/// </summary>
		public const string SQL_ID_01 = "TM060P01-01";

		/// <summary>
		/// 担当者マスタメンテナンス [担当者権限MST]件数チェック(職制区分あり)
		/// </summary>
		public const string SQL_ID_02 = "TM060P01-02";

		/// <summary>
		/// 担当者マスタメンテナンス [担当者権限MST]検索用(職制区分なし)
		/// </summary>
		public const string SQL_ID_03 = "TM060P01-03";

		/// <summary>
		/// 担当者マスタメンテナンス [担当者権限MST]検索用(職制区分あり)
		/// </summary>
		public const string SQL_ID_04 = "TM060P01-04";

		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		///  [担当者権限MST 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE1 = "ADD_WHERE1";
		/// <summary>
		///  [担当者権限MST 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE2 = "ADD_WHERE2";

		/// <summary>
		/// 置き換え変数 INNER1
		/// </summary>
		public const string REP_FROM_INNER_1 = "BIND_TENPO_CD";
		/// <summary>
		/// 置き換え変数 INNER2
		/// </summary>
		public const string REP_FROM_INNER_2 = "BIND_SYOKUSEI_KB_1";
		/// <summary>
		/// 置き換え変数 INNER3
		/// </summary>
		public const string REP_FROM_INNER_3 = "BIND_SYOKUSEI_KB_2";

		#endregion

		#region 明細のDICTIONARY
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
		/// 担当者コード
		/// </summary>
		public const string DIC_M1TAN_CD = "DIC_M1TAN_CD";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";


		#endregion

		#region DICTIONARY
		/// <summary>
		/// 更新日
		/// </summary>
		public const string DIC_UPD_YMD = "DIC_UPD_YMD";
		/// <summary>
		/// 更新時間
		/// </summary>
		public const string DIC_UPD_TM = "DIC_UPD_TM";
		/// <summary>
		/// 担当者コード
		/// </summary>
		public const string DIC_TAN_CD = "DIC_TAN_CD";

		#endregion
	}
}
