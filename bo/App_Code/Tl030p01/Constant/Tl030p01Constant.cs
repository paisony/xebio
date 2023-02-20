namespace com.xebio.bo.Tl030p01.Constant
{
  /// <summary>
  /// Tl030p01の定数を定義するクラスです。
  /// </summary>
  public static class Tl030p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tl030p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tl030f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tl030f02";

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
		/// <summary>
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";
		/// <summary>
		/// cookieのラベル発行機ID
		/// </summary>
		public const string FCDUO_LABEL_ID = "FCDUO_LABEL_ID";

		#region シール発行用

		/// <summary>
		/// ファサード ユーザオブジェクト
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_SEAL_CSVFLNM = "FCDUO_SEAL_CSVFLNM";
		/// <summary>
		/// ファサード ユーザオブジェクト
		/// 売変シールレイアウト名
		/// </summary>
		public const string FCDUO_SEAL_LAYOUTNM = "FCDUO_SEAL_LAYOUTNM";

		#endregion

		#endregion

		#region カード部  ディクショナリ
		/// <summary>
		/// カード部 ディクショナリ
		/// シーケンス
		/// </summary>
		public const string DIC_SEQ = "DIC_SEQ";
		/// <summary>
		/// 明細画面 システム日付
		/// </summary>
		public const string DIC_SYSDATE = "DIC_SYSDATE";
		/// <summary>
		/// 明細画面
		/// 現売価＝指示売価フラグ
		/// </summary>
		public const string DIC_GENBAIKA_SHIJIBAIKA_FLG = "DIC_GENBAIKA_SHIJIBAIKA_FLG";

		#endregion

		#region 明細部 ディクショナリ

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
		/// 部門名カナ
		/// </summary>
		public const string DIC_M1BUMONKANA_NM = "DIC_M1BUMONKANA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシリアルNo
		/// </summary>
		public const string DIC_M1HHTSERIAL_NO = "DIC_M1HHTSERIAL_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシーケンスNo.
		/// </summary>
		public const string DIC_M1HHTSEQUENCE_NO = "DIC_M1HHTSEQUENCE_NO";
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
		/// 申請担当者コード
		/// </summary>
		public const string DIC_M1SINSEITAN_CD = "DIC_M1SINSEITAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 売変No
		/// </summary>
		public const string DIC_M1BAIHEN_NO = "DIC_M1BAIHEN_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 売変理由
		/// </summary>
		public const string DIC_M1BAIHEN_RIYTU = "DIC_M1BAIHEN_RIYTU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 申請元区分
		/// </summary>
		public const string DIC_M1SINSEIMOTO_KBN = "DIC_M1SINSEIMOTO_KBN";
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
		/// 売変開始日
		/// </summary>
		public const string DIC_M1BAIHENKAISI_YMD = "DIC_M1BAIHENKAISI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 売変終了日
		/// </summary>
		public const string DIC_M1BAIHENSYURYO_YMD = "DIC_M1BAIHENSYURYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 売変行№
		/// </summary>
		public const string DIC_M1BAIHENGYO_NO = "DIC_M1BAIHENGYO_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 上代１
		/// </summary>
		public const string DIC_M1JODAI1_TNK = "DIC_M1JODAI1_TNK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サイズコード
		/// </summary>
		public const string DIC_M1SIZE_NM = "DIC_M1SIZE_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ハンドラベル
		/// </summary>
		public const string DIC_M1HANDLBL_KB = "DIC_M1HANDLBL_KB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 旧自社品番カラー展開フラグ
		/// </summary>
		public const string DIC_M1JISYA_HBN_COLOR_TENKAI_FLG = "DIC_M1JISYA_HBN_COLOR_TENKAI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// カラー展開売変可能フラグ
		/// </summary>
		public const string DIC_M1COLOR_TENKAI_BAIKA_KAHEN_FLG = "DIC_M1COLOR_TENKAI_BAIKA_KAHEN_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自社品番件数
		/// </summary>
		public const string DIC_M1JISYA_HBN_KENSU = "DIC_M1JISYA_HBN_KENSU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定処理フラグ退避用
		/// </summary>
		public const string DIC_M1ENTERSYORIFLG = "DIC_M1ENTERSYORIFLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 行選択不可フラグ
		/// </summary>
		public const string DIC_M1NOTSELECTFLG = "DIC_M1NOTSELECTFLG";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 売変確定(X) 一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TL030P01-01";
		/// <summary>
		/// 売変確定(X) 一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TL030P01-02";
		/// <summary>
		/// 売変確定(X)  ワークテーブル件数チェック
		/// </summary>
		public const string SQL_ID_03 = "TL030P01-03";
		/// <summary>
		/// 売変確定(X) 一覧 部門リンク(売価変更指示TBL)
		/// </summary>
		public const string SQL_ID_04 = "TL030P01-04";
		/// <summary>
		/// 売変確定(X) 一覧 部門リンク(店舗売変予定TBL)
		/// </summary>
		public const string SQL_ID_05 = "TL030P01-05";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 自動売変延長データTBL削除
		/// </summary>
		public const string SQL_ID_06 = "TL030P01-06";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 売変確定一時TBL登録(本部)
		/// </summary>
		public const string SQL_ID_07 = "TL030P01-07";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 事前売変データTBL登録
		/// </summary>
		public const string SQL_ID_08 = "TL030P01-08";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 店舗売変予定TBL更新
		/// </summary>
		public const string SQL_ID_09 = "TL030P01-09";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 店舗売変確定TBL登録
		/// </summary>
		public const string SQL_ID_10 = "TL030P01-10";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 店舗売変確定TBL登録。(カラー管理商品用）
		/// </summary>
		public const string SQL_ID_11 = "TL030P01-11";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 売変確定一時TBL登録(店舗)
		/// </summary>
		public const string SQL_ID_12 = "TL030P01-12";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 店舗売変予定TBL更新
		/// </summary>
		public const string SQL_ID_13 = "TL030P01-13";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 店別単価MST更新
		/// </summary>
		public const string SQL_ID_14 = "TL030P01-14";
		/// <summary>
		/// 売変確定(X) 一覧 確定
		/// 売変確定ワーク削除
		/// </summary>
		public const string SQL_ID_15 = "TL030P01-15";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変期間チェック
		/// </summary>
		public const string SQL_ID_16 = "TL030P01-16";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売価変更指示TBL 更新
		/// </summary>
		public const string SQL_ID_17 = "TL030P01-17";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 事前売変データ存在チェック
		/// </summary>
		public const string SQL_ID_18 = "TL030P01-18";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 事前売変データTBL登録
		/// </summary>
		public const string SQL_ID_19 = "TL030P01-19";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変確定一時TBL登録
		/// </summary>
		public const string SQL_ID_20 = "TL030P01-20";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 事前売変データTBL登録(カラー管理商品)
		/// </summary>
		public const string SQL_ID_21 = "TL030P01-21";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変確定一時TBL登録(カラー管理商品)
		/// </summary>
		public const string SQL_ID_22 = "TL030P01-22";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 自動売変延長データTBL削除
		/// </summary>
		public const string SQL_ID_23 = "TL030P01-23";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 自動売変延長データTBL登録
		/// </summary>
		public const string SQL_ID_24 = "TL030P01-24";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 自動売変延長データTBL削除（カラー管理商品）
		/// </summary>
		public const string SQL_ID_25 = "TL030P01-25";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 自動売変延長データTBL登録（カラー管理商品）
		/// </summary>
		public const string SQL_ID_26 = "TL030P01-26";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 店舗売変確定TBL登録
		/// </summary>
		public const string SQL_ID_27 = "TL030P01-27";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 店舗売変予定TBL更新
		/// </summary>
		public const string SQL_ID_28 = "TL030P01-28";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 店舗売変確定TBL登録（カラー管理商品)
		/// </summary>
		public const string SQL_ID_29 = "TL030P01-29";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変確定一時TBL登録（カラー管理商品)
		/// </summary>
		public const string SQL_ID_30 = "TL030P01-30";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変確定ワーク登録
		/// </summary>
		public const string SQL_ID_31 = "TL030P01-31";
		/// <summary>
		/// 売変確定(X) 一覧 印刷
		/// 印刷用CSV出力
		/// </summary>
		public const string SQL_ID_32 = "TL030P01-32";
		/// <summary>
		/// 売変確定(X) 一覧 シール発行
		/// 売変シール発行用CSV出力
		/// </summary>
		public const string SQL_ID_33 = "TL030P01-33";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変確定一時TBL件数取得
		/// </summary>
		public const string SQL_ID_34 = "TL030P01-34";
		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 売変確定(X) 一覧 件数チェック/検索
		/// WHERE句(売価変更指示TBL)
		/// </summary>
		public const string SQL_ID_01_REP_WHERE_MDCT0010 = "WHERE_01";
		/// <summary>
		/// 売変確定(X) 一覧 件数チェック/検索
		/// WHERE句( 店舗売変予定TBL)
		/// </summary>
		public const string SQL_ID_01_REP_WHERE_MDCT0020 = "WHERE_02";
		/// <summary>
		/// 売変確定(X) 一覧 件数チェック/検索
		/// SELECT句(売価変更指示TBL)
		/// </summary>
		public const string SQL_ID_01_REP_SELECT_MDCT0010 = "SELECT_01";
		/// <summary>
		/// 売変確定(X) 一覧 件数チェック/検索
		/// SELECT句( 店舗売変予定TBL)
		/// </summary>
		public const string SQL_ID_01_REP_SELECT_MDCT0020 = "SELECT_02";
		/// <summary>
		/// 売変確定(X) 明細 確定
		/// 売変期間チェック
		/// </summary>
		public const string SQL_ID_16_REP_WHERE = "WHERE_01";


		#endregion

		#region テーブルID
		/// <summary>
		/// 売価変更指示TBL
		/// </summary>
		public const string TABLE_MDCT0010 = "MDCT0010";
		/// <summary>
		/// 店舗売変予定TBL
		/// </summary>
		public const string TABLE_MDCT0020 = "MDCT0020";

		#endregion

		#region ORACLE PLSQL
		/// <summary>
		/// 売変登録情報の検索(API起動用)
		/// </summary>
		public const string ORACLE_MDPRICECHANGE_X_NEWBO = "MDPRICECHANGE_X_NEWBO.selectPricechangeApiData";

		#endregion

		#region セッションキー
		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion

		#region 合計品番数
		/// <summary>
		/// 合計品番数
		/// </summary>
		public const string GOKEI_HINBAN_SU = "100";

		#endregion

		#region 明細画面状態
		/// <summary>
		/// 明細画面状態
		/// 未選択
		/// </summary>
		public const string JOTAI_NORMAL = "0";
		/// <summary>
		/// 明細画面状態
		/// 承認(売変)
		/// </summary>
		public const string JOTAI_SYONIN = "1";
		/// <summary>
		/// 明細画面状態
		/// 却下(延長)
		/// </summary>
		public const string JOTAI_KYAKKA = "2";
		/// <summary>
		/// 明細画面状態
		/// 確定済み
		/// </summary>
		public const string JOTAI_KAKUTEI = "3";

		#endregion

		#region 一覧明細行選択

		/// <summary>
		/// 一覧明細行選択
		/// 選択可
		/// </summary>
		public const string ITIRAN_SENTAKU_KA = "0";

		/// <summary>
		/// 一覧明細行選択
		/// 選択不可
		/// </summary>
		public const string ITIRAN_SENTAKU_FUKA = "1";

		#endregion

	}
}
