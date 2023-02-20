namespace com.xebio.bo.Tf030p01.Constant
{
  /// <summary>
  /// Tf030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tf030p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tf030p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tf030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tf030f02";

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

		#region SESSION_KEY

		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 経費未払登録一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TF030P01-01";
		/// <summary>
		/// 経費未払登録一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TF030P01-02";
		/// <summary>
		/// 経費未払登録明細 検索
		/// </summary>
		public const string SQL_ID_03 = "TF030P01-03";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 置き換え変数 検索条件
		/// </summary>
		public const string REP_ADD_WHERE = "ADD_WHERE1";

		/// <summary>
		/// 経費未払登録明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string REP_DENPYO_BANGO = "BIND_DENPYO_BANGO";
		/// <summary>
		/// 経費未払登録明細 検索 
		/// 置き換え変数 処理日付
		/// </summary>
		public const string REP_SYORI_YMD = "BIND_SYORI_YMD";
		/// <summary>
		/// 経費未払登録明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string REP_TENPO_CD = "BIND_TENPO_CD";

		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 変更前の店舗コード
		/// </summary>
		public const string DIC_MOTO_TENPO_CD = "DIC_MOTO_TENPO_CD";
		/// <summary>
		/// 処理日付
		/// </summary>
		public const string DIC_SYORI_YMD = "DIC_SYORI_YMD";
		/// <summary>
		/// 処理時間
		/// </summary>
		public const string DIC_SYORI_TM = "DIC_SYORI_TM";
		/// <summary>
		/// 更新日
		/// </summary>
		public const string DIC_UPD_YMD = "DIC_UPD_YMD";
		/// <summary>
		/// 更新時間
		/// </summary>
		public const string DIC_UPD_TM = "DIC_UPD_TM";

		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";
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
		/// 検品者コード
		/// </summary>
		public const string DIC_M1KENPINSYA_CD = "DIC_M1KENPINSYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 検品者名称
		/// </summary>
		public const string DIC_M1KENPINSYA_NM = "DIC_M1KENPINSYA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入力者コード
		/// </summary>
		public const string DIC_M1NYURYOKUTAN_CD = "DIC_M1NYURYOKUTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信済フラグ
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
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
