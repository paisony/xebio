namespace com.xebio.bo.Te050p01.Constant
{
  /// <summary>
  /// Te050p01の定数を定義するクラスです。
  /// </summary>
  public static class Te050p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string	PGID = "Te050p01";
		#endregion

		#region	フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string	FORMID_01 =	"Te050f01";
		#endregion

		#region	SQL-ID
		/// <summary>
		/// 再入荷防止登録 件数チェック
		/// </summary>
		public const string	SQL_ID_01 =	"TE050P01-01";
		/// <summary>
		/// 再入荷防止登録 検索
		/// </summary>
		public const string	SQL_ID_02 =	"TE050P01-02";
		/// <summary>
		/// 再入荷防止登録 全色更新
		/// </summary>
		public const string	SQL_ID_03 =	"TE050P01-03";
		/// <summary>
		/// 再入荷防止登録 一色更新
		/// </summary>
		public const string	SQL_ID_04 =	"TE050P01-04";
		/// <summary>
		/// 再入荷防止登録  件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
		#endregion

		#region	Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string	DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日
		/// </summary>
		public const string	DIC_M1UPD_YMD =	"DIC_M1UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string	DIC_M1UPD_TM = "DIC_M1UPD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 商品群1コード
		/// </summary>
		public const string	DIC_M1SYOHINGUN1_CD = "DIC_M1SYOHINGUN1_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 販売完了日
		/// </summary>
		public const string	DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string	DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入先コード
		/// </summary>
		public const string	DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string	DIC_M1HINSYU_CD	= "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録区分
		/// </summary>
		public const string	DIC_M1ADD_KBN	= "DIC_M1ADD_KBN";
		#endregion

		#region 区分値
		/// <summary>
		/// フラグOFF
		/// </summary>
		public const decimal FLG_OFF = 0;
		/// <summary>
		/// フラグON
		/// </summary>
		public const decimal FLG_ON	= 1;
		/// <summary>
		/// 登録区分　0:店舗
		/// </summary>
		public const decimal ADD_KBN_TENPO = 0;
		/// <summary>
		/// 登録区分　1:本部
		/// </summary>
		public const decimal ADD_KBN_HONBU = 1;
		/// <summary>
		/// 商品区分 商品対象外
		/// </summary>
		public const decimal ITEMKBN_TAISHO_GAI = 0;
		/// <summary>
		/// 名称マスタ 登録区分
		/// </summary>
		public const string SIKIBETSU_CD_ADKB = "ADKB";
		/// <summary>
		/// チェックモード 新規作成
		/// </summary>
		public const string CHECK_MODE_BTNINSERT = "0";
		/// <summary>
		/// チェックモード 新規作成
		/// </summary>
		public const string CHECK_MODE_BTNSEARCH = "1";

		#endregion

	}
}
