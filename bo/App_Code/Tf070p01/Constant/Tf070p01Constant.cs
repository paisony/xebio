namespace com.xebio.bo.Tf070p01.Constant
{
  /// <summary>
  /// Tf070p01の定数を定義するクラスです。
  /// </summary>
  public static class Tf070p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tf070p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tf070f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tf070f02";

		#endregion

		#region Facade用UserObject

		/// <summary>
		/// 一覧画面フォームVO
		/// </summary>
		public const string FCDUO_F01VO = "FCDUO_F01VO";
		/// <summary>
		/// 一覧画面 明細フォームVO(M1)
		/// </summary>
		public const string FCDUO_F01M1VO = "FCDUO_F01M1VO";

		/// <summary>
		/// 明細画面フォームVO
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
		/// ユーザマップキー　登録伝票情報
		/// </summary>
		public const string FCDUO_TOROKU_DENPYO_JOHO = "FCDUO_TOROKU_DENPYO_JOHO";
		#endregion

		#region SQL-ID

		#region 一覧画面
		/// <summary>
		/// 一覧検索件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TF070P01-01";
		/// <summary>
		/// 一覧検索
		/// </summary>
		public const string SQL_ID_02 = "TF070P01-02";
		/// <summary>
		/// 明細検索
		/// </summary>
		public const string SQL_ID_03 = "TF070P01-03";

		/// <summary>
		/// 経費振替申請TBL(B)削除
		/// </summary>
		public const string SQL_ID_04 = "TF070P01-04";
		/// <summary>
		/// 経費振替申請TBL(H)削除
		/// </summary>
		public const string SQL_ID_05 = "TF070P01-05";
		/// <summary>
		/// 盗難品TBL(H)更新
		/// </summary>
		public const string SQL_ID_06 = "TF070P01-06";
		/// <summary>
		/// 盗難品履歴TBL(B)登録
		/// </summary>
		public const string SQL_ID_07 = "TF070P01-07";
		/// <summary>
		/// 盗難品TBL(B)削除
		/// </summary>
		public const string SQL_ID_08 = "TF070P01-08";
		/// <summary>
		/// 盗難品履歴TBL(H)登録
		/// </summary>
		public const string SQL_ID_09 = "TF070P01-09";
		/// <summary>
		/// 盗難品TBL(H)削除
		/// </summary>
		public const string SQL_ID_10 = "TF070P01-10";
		#endregion

		#region 明細画面
		/// <summary>
		/// 盗難品履歴TBL(B)登録（赤）
		/// </summary>
		public const string SQL_ID_11 = "TF070P01-11";
		/// <summary>
		/// 盗難品履歴TBL(B)削除
		/// </summary>
		public const string SQL_ID_12 = "TF070P01-12";
		/// <summary>
		/// 盗難品履歴TBL(B)登録（黒）
		/// </summary>
		public const string SQL_ID_13 = "TF070P01-13";
		/// <summary>
		/// 盗難品履歴TBL(H)登録（赤）
		/// </summary>
		public const string SQL_ID_14 = "TF070P01-14";
		/// <summary>
		/// 盗難品TBL(H)更新
		/// </summary>
		public const string SQL_ID_15 = "TF070P01-15";
		/// <summary>
		/// 盗難品履歴TBL(H)登録（黒）
		/// </summary>
		public const string SQL_ID_16 = "TF070P01-16";
		/// <summary>
		/// 経費振替伝票番号存在チェック
		/// </summary>
		public const string SQL_ID_17 = "TF070P01-17";
		/// <summary>
		/// 経費振替申請TBL(H)登録
		/// </summary>
		public const string SQL_ID_18 = "TF070P01-18";
		/// <summary>
		/// 経費振替申請TBL(B)登録
		/// </summary>
		public const string SQL_ID_19 = "TF070P01-19";
		#endregion

		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_REP_ADD_WHERE = "ADD_WHERE";

		/// <summary>
		/// バインド変数 店舗コード
		/// </summary>
		public const string SQL_BIND_TENPO_CD = "TENPO_CD";
		/// <summary>
		/// バインド変数 管理No
		/// </summary>
		public const string SQL_BIND_KANRI_NO = "KANRI_NO";
		/// <summary>
		/// バインド変数 処理日付
		/// </summary>
		public const string SQL_BIND_SYORI_YMD = "SYORI_YMD";
		#endregion

		#region Dictionary カード部
		/// <summary>
		/// カード部 ディクショナリ
		/// 一覧画面で選択したM1VO
		/// </summary>
		public const string DIC_M1SELCETVO = "DIC_M1SELCETVO";
		/// <summary>
		/// カード部 ディクショナリ
		/// 一覧画面で選択した行インデックス
		/// </summary>
		public const string DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";
		/// <summary>
		/// カード部 ディクショナリ
		/// 一覧画面で選択したＭ１確定処理フラグ
		/// </summary>
		public const string DIC_KAKUTEISYORI_FLG = "DIC_KAKUTEISYORI_FLG";
		#endregion

		#region Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日付
		/// </summary>
		public const string DIC_M1UPD_YMD = "DIC_M1UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string DIC_M1UPD_TM = "DIC_M1UPD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 管理No
		/// </summary>
		public const string DIC_M1KANRI_NO = "DIC_M1KANRI_NO";
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
		/// 経費申請フラグ
		/// </summary>
		public const string DIC_M1KEIHISINSEI_FLG = "DIC_M1KEIHISINSEI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 経費申請日
		/// </summary>
		public const string DIC_M1KEIHISINSEI_YMD = "DIC_M1KEIHISINSEI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 経費申請更新日
		/// </summary>
		public const string DIC_M1KEIHISINSEI_UPD_YMD = "DIC_M1KEIHISINSEI_UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 経費申請更新時間
		/// </summary>
		public const string DIC_M1KEIHISINSEI_UPD_TM = "DIC_M1KEIHISINSEI_UPD_TM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 報告担当者コード
		/// </summary>
		public const string DIC_M1HOKOKUTAN_CD = "DIC_M1HOKOKUTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店長担当者コード
		/// </summary>
		public const string DIC_M1TENTYOTAN_CD = "DIC_M1TENTYOTAN_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１品種コード
		/// </summary>
		public const string DIC_M1HINSYU_CD = "DIC_M1HINSYU_CD";
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
		/// Ｍ１サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１ＪＡＮコード
		/// </summary>
		public const string DIC_M1JAN_CD = "DIC_M1JAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";
		#endregion

		/// <summary>
		/// 最大件数取得時の枝番　新規作成モード
		/// </summary>
		public const string MAX_CNT_EDABAN_SHINKI = "1";
		/// <summary>
		/// 最大件数取得時の枝番　新規作成モード以外
		/// </summary>
		public const string MAX_CNT_EDABAN_NOT_SHINKI = "2";

		/// <summary>
		/// プロシージャ名　盗難品登録処理
		/// </summary>
		public const string PROC_NAME_INSERT_STOLEN_ITEM = "MDSTOLENITEM.INSERTSTOLENITEM";

		#region 帳票パラメータ関連

		#region 商品盗難事故報告書　印刷モード
		/// <summary>
		/// 印刷モード　経費申請
		/// </summary>
		public const string PRINT_MODE_KEIHISHINSEI = "1";
		/// <summary>
		/// 印刷モード　新規作成
		/// </summary>
		public const string PRINT_MODE_SHINKISAKUSEI = "2";
		/// <summary>
		/// 印刷モード　照会
		/// </summary>
		public const string PRINT_MODE_SHOKAI = "3";
		#endregion

		#region 店舗控えフラグ
		/// <summary>
		/// 店舗控えフラグ　出力なし
		/// </summary>
		public const string TENPO_HIKAE_FLG_OFF = "0";
		/// <summary>
		/// 店舗控えフラグ　出力あり
		/// </summary>
		public const string TENPO_HIKAE_FLG_ON = "1";
		#endregion

		#region 商品経費振替伝票　テーブル区分
		/// <summary>
		/// テーブル区分　申請
		/// </summary>
		public const string TABLE_KBN_SHINSEI = "1";
		/// <summary>
		/// テーブル区分　確定
		/// </summary>
		public const string TABLE_KBN_KAKUTEI = "2";
		#endregion

		#endregion

		#region CSV取込関連
		/// <summary>
		/// CSV項目ID　発生時間
		/// </summary>
		public const string CSV_ITEM_ID_HASSEI_JIKAN = "HASSEI_JIKAN";
		/// <summary>
		/// CSV項目ID　発生場所
		/// </summary>
		public const string CSV_ITEM_ID_HASSEI_BASHO = "HASSEI_BASHO";
		/// <summary>
		/// CSV項目ID　発見者コード
		/// </summary>
		public const string CSV_ITEM_ID_HAKKENSHA_CD = "HAKKENSHA_CD";
		/// <summary>
		/// CSV項目ID　発見状況区分
		/// </summary>
		public const string CSV_ITEM_ID_HAKKENJOKYO_KBN = "HAKKENJOKYO_KBN";
		/// <summary>
		/// CSV項目ID　発見状況テキスト
		/// </summary>
		public const string CSV_ITEM_ID_HAKKENJOKYO_TEXT = "HAKKENJOKYO_TEXT";
		/// <summary>
		/// CSV項目ID　スキャンコード
		/// </summary>
		public const string CSV_ITEM_ID_SCAN_CD = "SCAN_CD";
		/// <summary>
		/// CSV項目ID　申請数
		/// </summary>
		public const string CSV_ITEM_ID_SINSEI_SU = "SINSEI_SU";
		/// <summary>
		/// CSV項目ID　受理数
		/// </summary>
		public const string CSV_ITEM_ID_JURI_SU = "JURI_SU";

		/// <summary>
		/// 現在行数
		/// </summary>
		public const string DIC_CUR_ROW_CNT = "DIC_CUR_ROW_CNT";
		/// <summary>
		/// CSV取込画面戻り値
		/// </summary>
		public const string DIC_CSV_IMPORT_RESULT = "DIC_CSV_IMPORT_RESULT";
		/// <summary>
		/// フォーカスインデックス
		/// </summary>
		public const string DIC_FOCUS_INDEX = "DIC_FOCUS_INDEX";

		#endregion

		/// <summary>
		/// セッションキー　ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";
	}
}
