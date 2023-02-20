namespace com.xebio.bo.Tl020p01.Constant
{
  /// <summary>
  /// Tl020p01の定数を定義するクラスです。
  /// </summary>
  public static class Tl020p01Constant
	{
		#region プログラムID

		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tl020p01";

		#endregion

		#region フォームID

		/// <summary>
		/// 画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tl020f01";
		public const string FORMID_02 = "Tl020f02";

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
		/// フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

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

		#endregion

		#region SQL-ID

		/// <summary>
		/// 売変検索(X)-一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TL020P01-01";
		/// <summary>
		/// 売変検索(X)-一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TL020P01-02";
		/// <summary>
		/// 売変検索(X)-一覧 印刷
		/// </summary>
		public const string SQL_ID_03 = "TL020P01-03";
		/// <summary>
		/// 売変検索(X)-一覧 M1部門リンク（予定）
		/// </summary>
		public const string SQL_ID_04 = "TL020P01-04";
		/// <summary>
		/// 売変検索(X)-一覧 M1部門リンク（確定）
		/// </summary>
		public const string SQL_ID_05 = "TL020P01-05";
		/// <summary>
		/// 売変検索(X)-一覧 M1部門リンク（指示）
		/// </summary>
		public const string SQL_ID_06 = "TL020P01-06";

		/// <summary>
		/// 売変検索(X)-一覧 印刷ボタン
		/// </summary>
		public const string SQL_ID_07 = "TL020P01-07";

		/// <summary>
		/// 売変検索(X)-シール発行
		/// </summary>
		public const string SQL_ID_08 = "TL020P01-08";

		#endregion

		#region SQL-REPLACE-ID

		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 確定状態
		/// </summary>
		public const string DIC_KAKUTEI_JYOTAI = "DIC_KAKUTEI_JYOTAI";

		/// <summary>
		/// カード部 ディクショナリ
		/// 出力シール名称
		/// </summary>
		public const string DIC_SYUTSURYOKU_SEAL = "DIC_SYUTSURYOKU_SEAL";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD = "DIC_SEARCH_XEBIOCD";

		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名(明細表示用)
		/// </summary>
		public const string DIC_M1BUMON_NM_MEISAI = "DIC_M1BUMON_NM_MEISAI";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 申請元区分
		/// </summary>
		public const string DIC_M1SINSEIMOTO_KBN = "DIC_M1SINSEIMOTO_KBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１申請担当者コード
		/// </summary>
		public const string DIC_M1SINSEITAN_CD = "DIC_M1SINSEITAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１登録確定者コード
		/// </summary>
		public const string DIC_M1TOROKUKAK_CD = "DIC_M1TOROKUKAK_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１申請コメント
		/// </summary>
		public const string DIC_M1SINSEICOMMENT_NM = "DIC_M1SINSEICOMMENT_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１売変理由コード
		/// </summary>
		public const string DIC_M1BAIHEN_RIYTU = "DIC_M1BAIHEN_RIYTU";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１売変No
		/// </summary>
		public const string DIC_M1BAIHEN_NO = "DIC_M1BAIHEN_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１売変作業開始日
		/// </summary>
		public const string DIC_M1BAIHENSAGYOKAISI_YMD = "DIC_M1BAIHENSAGYOKAISI_YMD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 開始状態
		/// </summary>
		public const string DIC_M1KAISISTATE = "DIC_M1KAISISTATE";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 開始状態名
		/// </summary>
		public const string DIC_M1KAISISTATE_NM = "DIC_M1KAISISTATE_NM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 売変行No
		/// </summary>
		public const string DIC_M1BAIHENGYO_NO = "DIC_M1BAIHENGYO_NO";

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

		#region 定数
		/// <summary>
		/// 識別コード
		/// </summary>
		public const string SIKIBETSU_CD = "SLYT";

		#endregion
	}
}
