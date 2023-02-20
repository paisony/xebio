namespace com.xebio.bo.Tm070p01.Constant
{
  /// <summary>
  /// Tm070p01の定数を定義するクラスです。
  /// </summary>
  public static class Tm070p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tm070p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tm070f01";
		#endregion

		#region	Facade用UserObject
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO = "FCDUO_F01VO";
		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM = "FCDUO_FOCUSITEM";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";
		/// <summary>
		/// 明細画面サイズ選択　サイズ検索戻り値
		/// </summary>
		public const string KEY_SIZE_SEARCH_RESULT = "SIZE_SEARCH_RESULT";
		/// <summary>
		/// 明細画面サイズ選択  フォーカスインデックス
		/// </summary>
		public const string KEY_SIZE_FOCUS_INDEX = "SIZE_FOCUS_INDEX";
		#endregion

		#region SQL-ID
		/// <summary>
		/// 担当者所属店変更履歴 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TM070P01-01";
		/// <summary>
		/// 担当者所属店変更履歴 検索
		/// </summary>
		public const string SQL_ID_02 = "TM070P01-02";
		/// <summary>
		/// 担当者マスタ 更新
		/// </summary>
		public const string SQL_ID_03 = "TM070P01-03";
		/// <summary>
		/// 担当者所属店変更履歴 登録
		/// </summary>
		public const string SQL_ID_04 = "TM070P01-04";
		/// <summary>
		/// 所属店舗取得
		/// </summary>
		public const string SQL_ID_05 = "TM070P01-05";
		/// <summary>
		/// 担当者マスタ チェック
		/// </summary>
		public const string SQL_ID_06 = "TM070P01-06";
		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 担当者所属店変更履歴 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string REP_ADD_WHERE1 = "ADD_WHERE1";
		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 初期化フラグ
		/// </summary>
		public const string DIC_M1SHOKIKA_FLG = "DIC_M1SHOKIKA_FLG";

		#endregion

		#region 初期化可能フラグ
		/// <summary>
		/// 項目「SHOKIKA_FLG(可)」のコンディション値
		/// </summary>
		public const string VALUE_SHOKIKA_ON = "1";
		/// <summary>
		/// 項目「SHOKIKA_FLG(不可)」のコンディション値
		/// </summary>
		public const string VALUE_SHOKIKA_OFF = "0";

		#endregion

	}
}
