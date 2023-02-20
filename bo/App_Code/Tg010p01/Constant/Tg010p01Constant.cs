namespace com.xebio.bo.Tg010p01.Constant
{
  /// <summary>
  /// Tg010p01の定数を定義するクラスです。
  /// </summary>
  public static class Tg010p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tg010p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tg010f01";
		
		#endregion

		#region Dictionary カード部
		/// <summary>
		/// カード部 ディクショナリ
		/// 出力シール名称
		/// </summary>
		public const string DIC_SYUTSURYOKU_SEAL = "DIC_SYUTSURYOKU_SEAL";
		#endregion Dictionary カード部

		#region Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１自社品番リンク
		/// </summary>
		public const string DIC_M1ZEI_KB = "DIC_M1ZEI_KB";
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

	}
}
