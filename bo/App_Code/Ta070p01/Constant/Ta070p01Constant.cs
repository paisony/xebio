namespace com.xebio.bo.Ta070p01.Constant
{
  /// <summary>
  /// Ta070p01の定数を定義するクラスです。
  /// </summary>
  public static class Ta070p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Ta070p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Ta070f01";
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
		#region	SQL-ID
		/// <summary>
		/// 自動定数変更 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TA070P01-01";
		/// <summary>
		/// 自動定数変更 検索
		/// </summary>
		public const string SQL_ID_02 = "TA070P01-02";
		/// <summary>
		/// 自動定数変更 マージ
		/// </summary>
		public const string SQL_ID_03 = "TA070P01-03";
		/// <summary>
		/// 自動定数変更 削除
		/// </summary>
		public const string SQL_ID_04 = "TA070P01-04";
		#endregion

		#region	SQL-REPLACE-ID
		/// <summary>
		/// 自動定数変更  件数チェック／検索
		/// 置き換え変数 依頼 検索条件 依頼
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_IRAI = "ADD_WHERE_IRAI";
		/// <summary>
		/// 自動定数変更  件数チェック／検索
		/// 置き換え変数 検索条件 検索条件 マスタ
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_MST = "ADD_WHERE_MST";
		/// <summary>
		/// 自動定数変更  件数チェック／検索
		/// 置き換え変数 検索条件 依頼有効可否
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_KAHI_IRAI = "ADD_WHERE_KAHI_IRAI";
		/// <summary>
		/// 自動定数変更  件数チェック／検索
		/// 置き換え変数 検索条件 マスタ有効可否
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_KAHI_MST = "ADD_WHERE_KAHI_MST";
		#endregion

		#region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD = "DIC_SEARCH_XEBIOCD";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索JANコード
		/// </summary>
		public const string DIC_SEARCH_JANCD = "DIC_SEARCH_JANCD";

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
		/// 管理№
		/// </summary>
		public const string DIC_M1KANRI_NO = "DIC_M1KANRI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 区分コード
		/// </summary>
		public const string DIC_M1KBN_CD = "DIC_M1KBN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 依頼理由コード
		/// </summary>
		public const string DIC_M1IRAIRIYU_CD = "DIC_M1IRAIRIYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 依頼状態
		/// </summary>
		public const string DIC_M1SHIN_FLG = "DIC_M1SHIN_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 担当者コード
		/// </summary>
		public const string DIC_M1TANTOSYA_CD = "DIC_M1TANTOSYA_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 補充区分
		/// </summary>
		public const string DIC_M1HATYUTAISYO_KB = "DIC_M1HATYUTAISYO_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 評価区分
		/// </summary>
		public const string DIC_M1HYOKA_KB = "DIC_M1HYOKA_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// メッセージ区分
		/// </summary>
		public const string DIC_M1MESSEGE_KB = "DIC_M1MESSEGE_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 本宮商品フラグ
		/// </summary>
		public const string DIC_M1MOTOMIYASYOHIN_FLG = "DIC_M1MOTOMIYASYOHIN_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自動補充区分
		/// </summary>
		public const string DIC_M1SYOHIN_ZOKUSEI = "DIC_M1SYOHIN_ZOKUSEI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 原単価
		/// </summary>
		public const string DIC_M1GENKA = "DIC_M1GENKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 発注パターン区分
		/// </summary>
		public const string DIC_M1HATTYUPTN_KBN = "DIC_M1HATTYUPTN_KBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自動区分
		/// </summary>
		public const string DIC_M1JIDO_KBN = "DIC_M1JIDO_KBN";


		/// <summary>
		/// 明細部 ディクショナリ
		/// 販売完了日
		/// </summary>
		public const string DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 可能数越可能取引フラグ
		/// </summary>
		public const string DIC_M1KANOUSUGOE_FLG = "DIC_M1KANOUSUGOE_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自動発注可能フラグ
		/// </summary>
		public const string DIC_M1JIDOHATTYUKANO_FLG = "DIC_M1JIDOHATTYUKANO_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 配分可能数
		/// </summary>
		public const string DIC_M1HAIBUNKANO_SU = "DIC_M1HAIBUNKANO_SU";

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
		/// 明細用 ディクショナリ
		/// 単品レポートフラグ
		/// </summary>
		public const string DIC_M1TANPIN_REPORT_FLG = "DIC_M1TANPIN_REPORT_FLG";
		/// <summary>
		/// 明細用 ディクショナリ
		/// 単品登録モードフラグ
		/// </summary>
		public const string DIC_M1TANPIN_TOUROKU_MODE_FLG = "DIC_M1TANPIN_TOUROKU_MODE_FLG";

		#endregion

		#region プログラム固定値
		/// <summary>
		/// 理由コメント 業務区分 「定番定数変更理由:014」
		/// </summary>
		public const string RIYU_GYOMU_TEIBAN = "014";
		/// <summary>
		/// 検索条件 有効可否 可
		/// </summary>
		public const string SERCH_YUKO_KA = "0=0";
		/// <summary>
		/// 検索条件 有効可否 否
		/// </summary>
		public const string SERCH_YUKO_HI = "0=1";
		/// <summary>
		/// チェックモード 新規作成
		/// </summary>
		public const string CHECK_MODE_BTNINSERT = "0";
		/// <summary>
		/// チェックモード 検索
		/// </summary>
		public const string CHECK_MODE_BTNSEARCH = "1";
		/// <summary>
		/// 本宮商品フラグ チェック用１
		/// </summary>
		public const decimal CHECK_MOTOMIYASYOHIN_FLG1 = 2;
		/// <summary>
		/// 本宮商品フラグ チェック用２
		/// </summary>
		public const decimal CHECK_MOTOMIYASYOHIN_FLG2 = 4;

		/// <summary>
		/// 発注メッセージ 本部配分
		/// </summary>
		public const string HTMS_HONBU = "本部配分";
		/// <summary>
		/// 発注メッセージ 売上実績なし
		/// </summary>
		public const string HTMS_URI = "売上実績なし";
		/// <summary>
		/// 発注メッセージ 入荷予定あり
		/// </summary>
		public const string HTMS_NYU = "入荷予定あり";
		/// <summary>
		/// フラグOFF
		/// </summary>
		public const decimal FLG_OFF = 0;
		/// <summary>
		/// フラグON
		/// </summary>
		public const decimal FLG_ON = 1;
		/// <summary>
		/// 削除区分 0:依頼HEAD
		/// </summary>
		public const decimal DEL_KBN_IRAI_HEAD = 0;
		/// <summary>
		/// 削除区分 1:依頼BODY
		/// </summary>
		public const decimal DEL_KBN_IRAI_BODY = 1;
		/// <summary>
		/// 削除区分 2:マスタHEAD
		/// </summary>
		public const decimal DEL_KBN_MST_HEAD = 2;
		/// <summary>
		/// 削除区分 3:マスタBODY
		/// </summary>
		public const decimal DEL_KBN_MST_BODY = 3;
		/// <summary>
		/// 登録区分 0:依頼TBL
		/// </summary>
		public const decimal REG_KBN_IRAISEI = 0;
		/// <summary>
		/// 登録区分 1:マスタTBL
		/// </summary>
		public const decimal REG_KBN_MST = 1;
		/// <summary>
		/// 登録区分 1:マスタTBL
		/// </summary>
		public const decimal REG_KBN_TEMP = 2;
		/// <summary>
		/// 登録画面 0:一覧画面
		/// </summary>
		public const decimal REG_GAMEN_ITIRAN = 0;
		/// <summary>
		/// 登録画面 1:明細画面
		/// </summary>
		public const decimal REG_GAMEN_MEISAI = 1;
		#endregion


	}
}
