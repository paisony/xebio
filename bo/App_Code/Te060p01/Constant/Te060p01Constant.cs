namespace com.xebio.bo.Te060p01.Constant
{
  /// <summary>
  /// Te060p01の定数を定義するクラスです。
  /// </summary>
  public static class Te060p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Te060p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Te060f01";
		#endregion

		#region	SQL-ID
		/// <summary>
		/// 再入荷防止 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TE060P01-01";
		/// <summary>
		/// 再入荷防止 検索
		/// </summary>
		public const string SQL_ID_02 = "TE060P01-02";
		/// <summary>
		/// 再入荷防止 修正
		/// </summary>
		public const string SQL_ID_03 = "TE060P01-03";
		/// <summary>
		/// 再入荷防止 取消
		/// </summary>
		public const string SQL_ID_04 = "TE060P01-04";
		#endregion

		#region	SQL-REPLACE-ID
		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
		#endregion

		#region	Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
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
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		#endregion

		#region 区分値
		/// <summary>
		/// フラグOFF
		/// </summary>
		public const decimal FLG_OFF = 0;
		/// <summary>
		/// フラグON
		/// </summary>
		public const decimal FLG_ON = 1;
		/// <summary>
		/// 登録区分　0:店舗
		/// </summary>
		public const decimal ADD_KBN_TENPO = 0;
		/// <summary>
		/// 登録区分　1:本部
		/// </summary>
		public const decimal ADD_KBN_HONBU = 1;
		/// <summary>
		/// 名称マスタ 登録区分
		/// </summary>
		public const string SIKIBETSU_CD_ADKB = "ADKB";
		#endregion

		#region チェック用
		/// <summary>
		/// 販売完了日(初期値:4/1) 
		/// </summary>
		public const string HANBAIKANRYO_YMD_DEF_PTN1 = "0401";
		/// <summary>
		/// 販売完了日(初期値:10/1) 
		/// </summary>
		public const string HANBAIKANRYO_YMD_DEF_PTN2 = "1001";

		/// <summary>
		/// 販売完了日(4/1) _FROM
		/// </summary>
		public const decimal DATE_0401_FROM = 401;
		/// <summary>
		/// 販売完了日(4/1) _TO
		/// </summary>
		public const decimal DATE_0401_TO = 930;
		/// <summary>
		/// 販売完了日(10/1) _FROM
		/// </summary>
		public const decimal DATE_1001_FROM = 1001;
		/// <summary>
		/// 販売完了日(10/1) _TO
		/// </summary>
		public const decimal DATE_1001_TO = 1231;
		/// <summary>
		/// 販売完了日(前年10/1) _FROM
		/// </summary>
		public const decimal DATE_1001_ZEN_FROM = 0101;
		/// <summary>
		/// 販売完了日(前年10/1) _TO
		/// </summary>
		public const decimal DATE_1001_ZEN_TO = 0331;
		#endregion
	}
}
