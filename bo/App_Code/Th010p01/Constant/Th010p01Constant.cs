namespace com.xebio.bo.Th010p01.Constant
{
  /// <summary>
  /// Th010p01の定数を定義するクラスです。
  /// </summary>
  public static class Th010p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Th010p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// 商品マスタ検索_一覧
		/// </summary>
		public const string FORMID_01 = "Th010f01";
		/// <summary>
		/// 明細画面フォームID
		/// 商品マスタ検索(メーカー品番)
		/// </summary>
		public const string FORMID_02 = "Th010f02";
		/// <summary>
		/// 明細画面フォームID
		/// 商品マスタ検索（サイズ別＿プライス）
		/// </summary>
		public const string FORMID_03 = "Th010f03";

		#endregion

		#region Facade用UserObject
		
		#region メーカー品番
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO_02 = "FCDUO_F01VO_02";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO_02 = "FCDUO_F01M1VO_02";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_02 = "FCDUO_NEXTVO_02";

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM_02 = "FCDUO_FOCUSITEM_02";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW_02 = "FCDUO_FOCUSROW_02";
		#endregion

		#region サイズ別＿プライス
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FCDUO_F01VO_03 = "FCDUO_F01VO_03";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string FCDUO_F01M1VO_03 = "FCDUO_F01M1VO_03";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_03 = "FCDUO_NEXTVO_03";

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM_03 = "FCDUO_FOCUSITEM_03";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW_03 = "FCDUO_FOCUSROW_03";
		#endregion

		/// <summary>
		/// CSV出力ファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";

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
		/// 商品マスタ検索-一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TH010P01-01";
		#endregion

		#region Dictionary カード部
		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ＮＯ
		/// </summary>
		public const string DIC_M1ROWNUM = "DIC_M1ROWNUM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入先コード
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１仕入先名称
		/// </summary>
		public const string DIC_M1SIIRESAKI_RYAKU_NM = "DIC_M1SIIRESAKI_RYAKU_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１部門名
		/// </summary>
		public const string DIC_BUMON_NM = "DIC_BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１部門カナ名
		/// </summary>
		public const string DIC_M1BUMONKANA_NM = "DIC_M1BUMONKANA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１品種略名称
		/// </summary>
		public const string DIC_M1HINSYU_RYAKU_NM = "DIC_M1HINSYU_RYAKU_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ブランド名
		/// </summary>
		public const string DIC_M1BURANDO_NM = "DIC_M1BURANDO_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１自社品番リンク
		/// </summary>
		public const string DIC_M1XEBIO_CD = "DIC_M1XEBIO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１旧自社品番リンク
		/// </summary>
		public const string DIC_M1OLD_XEBIO_CD = "DIC_M1OLD_XEBIO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品属性
		/// </summary>
		public const string DIC_M1SYOHIN_ZOKUSEI = "DIC_M1SYOHIN_ZOKUSEI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１メーカー品番
		/// </summary>
		public const string DIC_M1MAKER_HBN = "DIC_M1MAKER_HBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品名(カナ)
		/// </summary>
		public const string DIC_M1SYONMK = "DIC_M1SYONMK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１色
		/// </summary>
		public const string DIC_M1IRO_NM = "DIC_M1IRO_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１販売完了日
		/// </summary>
		public const string DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１最新売価
		/// </summary>
		public const string DIC_M1SAISINBAIKA_TNK = "DIC_M1SAISINBAIKA_TNK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１原価
		public const string DIC_M1GENKA = "DIC_M1GENKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１現売価
		/// </summary>
		public const string DIC_M1GENBAIKA_TNK = "DIC_M1GENBAIKA_TNK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１メーカー価格
		/// </summary>
		public const string DIC_M1MAKERKAKAKU_TNK = "DIC_M1MAKERKAKAKU_TNK";


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
		/// Ｍ１税区分
		/// </summary>
		public const string DIC_M1ZEI_KB = "DIC_M1ZEI_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１税率コード
		/// </summary>
		public const string DIC_M1ZEIRITSU_CD = "DIC_M1ZEIRITSU_CD";

		#endregion

		#region Dictionary 条件部
		
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１展開区分
		public const string DIC_M1TENKAI_KB = "DIC_M1TENKAI_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１色コード
		/// </summary>
		public const string DIC_M1MAKERCOLOR_CD = "DIC_M1MAKERCOLOR_CD";

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
		/// ID
		/// </summary>
		public const string DIC_M1ID = "DIC_M1ID";
		/// <summary>
		/// 明細部 ディクショナリ
		/// BACKID
		/// </summary>
		public const string DIC_M1BACKID = "DIC_M1BACKID";
		/// <summary>
		/// カード部 ディクショナリ
		/// 出力シール名称
		/// </summary>
		public const string DIC_SYUTSURYOKU_SEAL = "DIC_SYUTSURYOKU_SEAL";

		#endregion

		#region 定数
		/// <summary>
		/// 識別コード
		/// </summary>
		public const string SIKIBETSU_CD = "SLYT";
		/// <summary>
		/// 自社品番
		/// </summary>
		public const string M1JISYA_HBN = "M1jisya_hbn";
		/// <summary>D
		/// 旧自社品番
		/// </summary>
		public const string M1OLD_JISYA_HBN = "M1old_jisya_hbn";
		/// <summary>
		/// 税区分　5％
		/// </summary>
		public const string ZEI_KBN_5 = "５％";
		/// <summary>
		/// 税区分　＋税
		/// </summary>
		public const string ZEI_KBN_PLUS = "＋税";
		/// <summary>
		/// 税区分　8％
		/// </summary>
		public const string ZEI_KBN_8 = "８％";
		#endregion
	}
}
