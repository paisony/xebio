namespace com.xebio.bo.Tk020p01.Constant
{
  /// <summary>
  /// Tk020p01の定数を定義するクラスです。
  /// </summary>
  public static class Tk020p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tk020p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// 評価損処理
		/// </summary>
		public const string FORMID_01 = "Tk020f01";
		#endregion

		#region Facade用UserObject
		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";
		#endregion

		#region SESSION_KEY
		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";
		#endregion

		#region SQL-ID
		/// <summary>
		/// 評価損処理 
		/// 置き換え変数 承認状態
		/// </summary>
		public const string REPLACE_ID_SYONIN_FLG = "REPLACE_ID_SYONIN_FLG";
		/// <summary>
		/// 評価損処理 
		/// 置き換え変数 再申請済みフラグ
		/// </summary>
		public const string REPLACE_ID_SAISHINSEIZUMI_FLG = "REPLACE_ID_SAISHINSEIZUMI_FLG";
		/// <summary>
		/// 評価損処理 
		/// 置き換え変数 却下フラグ
		/// </summary>
		public const string REPLACE_ID_KYAKKA_FLG = "REPLACE_ID_KYAKKA_FLG";
			
		/// <summary>
		/// 評価損処理 
		/// 置き換え変数 ソート条件
		/// </summary>
		public const string REP_ADD_ORDER = "REPLACE_ID_ORDER_BY";

		/// <summary>
		/// 評価損処理 モード：申請、修正
		/// </summary>
		public const string SQL_ID_01 = "TK020P01-01";
		/// <summary>
		/// 評価損処理 モード：再申請、照会
		/// </summary>
		public const string SQL_ID_02 = "TK020P01-02";
		/// <summary>
		/// 評価損処理 モード：決裁状況
		/// </summary>
		public const string SQL_ID_03 = "TK020P01-03";
		/// <summary>
		/// 評価損処理 関連チェック
		/// </summary>
		public const string SQL_ID_04 = "TK020P01-04";
		#endregion

		#region SQL-REPLACE-ID
		#region チェック
		/// <summary>
		/// 評価損処理 チェック 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_04_REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 評価損処理 チェック 
		/// 置き換え変数 申請日
		/// </summary>
		public const string SQL_ID_04_REP_APPLY_YMD = "BIND_APPLY_YMD";
		/// <summary>
		/// 評価損処理 チェック 
		/// 置き換え変数 [申請状態]
		/// </summary>
		public const string SQL_ID_04_REP_SAISHINSEI_FLG = "BIND_SAISHINSEI_FLG";

		#endregion

		#region [選択モードNo]が「申請」「修正」の場合、評価損申請TBLから検索
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_01_REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 処理日
		/// </summary>
		public const string SQL_ID_01_REP_SYORI_YMD = "BIND_SYORI_YMD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 [申請状態]
		/// </summary>
		public const string SQL_ID_01_REP_SAISHINSEI_FLG = "BIND_SHINSEI_FLG";
		#endregion

		#region [選択モードNo]が「再申請」「照会」の場合、評価損確定TBLと評価損申請TBLから検索
		/// <summary>
		/// 評価損処理 チェック 
		/// 置き換え変数 選択モードNo
		/// </summary>
		public const string SQL_ID_02_MODE = "BIND_MODE";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 照会モード
		/// </summary>
		public const string SQL_ID_02_CONS_MODEREF = "BIND_CONS_MODEREF";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_02_REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 処理日
		/// </summary>
		public const string SQL_ID_02_REP_SYORI_YMD = "BIND_SYORI_YMD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 [申請状態]
		/// </summary>
		public const string SQL_ID_02_REP_SAISHINSEI_FLG = "BIND_SAISHINSEI_FLG";
		#endregion

		#region [選択モードNo]が「決裁状況」の場合、評価損確定TBLと評価損申請TBLから検索
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_03_REP_TENPO_CD = "BIND_TENPO_CD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 処理日
		/// </summary>
		public const string SQL_ID_03_REP_SYORI_YMD = "BIND_SYORI_YMD";
		/// <summary>
		/// 評価損処理 検索
		/// 置き換え変数 却下フラグ
		/// </summary>
		public const string SQL_ID_03_REPLACE_ID_KYAKKA_FLG = "REPLACE_ID_KYAKKA_FLG";
		#endregion

		#endregion

		#region Dictionary 条件部
		/// <summary>
		/// 条件部 ディクショナリ
		/// 決裁状態区分
		/// </summary>
		public const string DIC_KESSAI_JOTAI_KB = "DIC_KESSAI_JOTAI_KB";
		
		/// <summary>
		/// 条件部 ディクショナリ
		/// 承認状態区分
		/// </summary>
		public const string DIC_SYONIN_JOTAI_KB = "DIC_SYONIN_JOTAI_KB";

		/// <summary>
		/// 条件部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_TENPO_CD = "DIC_TENPO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１再申請フラグ
		/// </summary>
		public const string DIC_SAISHINSEI_FLG = "DIC_SAISHINSEI_FLG";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１更新日
		/// </summary>
		public const string DIC_UPD_YMD = "DIC_UPD_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１更新時間
		/// </summary>
		public const string DIC_UPD_TM = "DIC_UPD_TM";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１管理No
		/// </summary>
		public const string DIC_KANRI_NO = "DIC_KANRI_NO";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１処理日付
		/// </summary>
		public const string DIC_SYORI_YMD = "DIC_SYORI_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１処理時間
		/// </summary>
		public const string DIC_SYORI_TM = "DIC_SYORI_TM";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１行No
		/// </summary>
		public const string DIC_GYO_NBR = "DIC_GYO_NBR";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１行No(再申請用)
		/// </summary>
		public const string DIC_GYONBR_SAI = "DIC_GYONBR_SAI";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１ブランドコード
		/// </summary>
		public const string DIC_BURANDO_CD = "DIC_BURANDO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１色コード
		/// </summary>
		public const string DIC_IRO_CD = "DIC_IRO_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１サイズコード
		/// </summary>
		public const string DIC_SIZE_CD = "DIC_SIZE_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// Ｍ１商品コード
		/// </summary>
		public const string DIC_SYOHIN_CD = "DIC_SYOHIN_CD";

		#endregion

		#region Dictionary 更新条件
		/// <summary>
		/// 条件部 ディクショナリ
		/// 部門コード
		/// </summary>
		public const string DIC_BUMON_CD = "DIC_BUMON_CD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string DIC_HINSYU_CD = "DIC_HINSYU_CD";

		/// <summary>
		/// 条件部 ディクショナリ
		/// メーカー品番
		/// </summary>
		public const string DIC_MAKER_HBN = "DIC_MAKER_HBN";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 商品名(カナ)
		/// </summary>
		public const string DIC_SYONMK = "DIC_SYONMK";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 自社品番
		/// </summary>
		public const string DIC_JISYA_HBN = "DIC_JISYA_HBN";
		/// <summary>
		/// 条件部 ディクショナリ
		/// ＪＡＮコード
		/// </summary>
		public const string DIC_JAN_CD = "DIC_JAN_CD";

		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損数量
		/// </summary>
		public const string DIC_HYOKASON_SU = "DIC_HYOKASON_SU";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 販売完了日
		/// </summary>
		public const string DIC_HANBAIKANRYO_YMD = "DIC_HANBAIKANRYO_YMD";

		/// <summary>
		/// 条件部 ディクショナリ
		/// サイズ名
		/// </summary>
		public const string DIC_SIZE_NM = "DIC_SIZE_NM";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 原単価
		/// </summary>
		public const string DIC_GEN_TNK = "DIC_GEN_TNK";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 上代1
		/// </summary>
		public const string DIC_JODAI1_TNK = "DIC_JODAI1_TNK";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損種別区分
		/// </summary>
		public const string DIC_HYOKASONSYUBETSU_KB = "DIC_HYOKASONSYUBETSU_KB";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損理由区分
		/// </summary>
		public const string DIC_HYOKASONRIYU_KB = "DIC_HYOKASONRIYU_KB";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 評価損理由
		/// </summary>
		public const string DIC_HYOKASONRIYU = "DIC_HYOKASONRIYU";

		/// <summary>
		/// 条件部 ディクショナリ
		/// 申請日
		/// </summary>
		public const string DIC_APPLY_YMD = "DIC_APPLY_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 調達区分
		/// </summary>
		public const string DIC_TYOTATSU_KB = "DIC_TYOTATSU_KB";

		/// <summary>
		/// 条件部 ディクショナリ
		/// 更新日
		/// </summary>
		public const string DIC_ADD_YMD = "DIC_ADD_YMD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string DIC_ADD_TM = "DIC_ADD_TM";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 更新担当者コード
		/// </summary>
		public const string DIC_ADDTAN_CD = "DIC_ADDTAN_CD";

		/// <summary>
		/// 条件部 ディクショナリ
		/// HHTシリアル番号
		/// </summary>
		public const string DIC_HHTSERIAL_NO = "DIC_HHTSERIAL_NO";
		/// <summary>
		/// 条件部 ディクショナリ
		/// HHTシーケンスNo.
		/// </summary>
		public const string DIC_HHTSEQUENCE_NO = "DIC_HHTSEQUENCE_NO";

		/// <summary>
		/// 条件部 ディクショナリ
		/// 更新担当者コード
		/// </summary>
		public const string DIC_UPD_TANCD = "DIC_UPD_TANCD";
		/// <summary>
		/// 条件部 ディクショナリ
		/// 削除フラグ
		/// </summary>
		public const string DIC_SAKUJYO_FLG = "DIC_SAKUJYO_FLG";
		#endregion

		#region Dictionary 定数
		/// <summary>
		/// 定数 ディクショナリ
		/// 日付
		/// </summary>
		public const string DIC_SYSDATE = "DIC_SYSDATE";

		/// <summary>
		/// 定数 ディクショナリ
		/// 時刻
		/// </summary>
		public const string DIC_SYSTIME = "DIC_SYSTIME";

		/// <summary>
		/// 定数 ディクショナリ
		/// １画面表示件数(MAX)
		/// </summary>
		public const int PAGE_PER_COUNT = 100;
		#endregion

		#region プログラム固定値
		/// <summary>
		/// 名称マスタ 識別コード 評価損種別
		/// </summary>
		public const string MEISHO_SIKIBETSU_CD_SYUBETSU = "HKSB";
		/// <summary>
		/// 名称マスタ 識別コード 評価損理由
		/// </summary>
		public const string MEISHO_SIKIBETSU_CD_RIYU = "HKRY";

		/// <summary>
		/// 採番済みフラグ
		/// </summary>
		public const string DIC_NUMBERING = "DIC_NUMBERING";
		#endregion

		#region ツールチップ
		/// <summary>
		/// ツールチップ ディクショナリ
		/// 部門名
		/// </summary>
		public const string DIC_BUMON_NM = "DIC_BUMON_NM";

		/// <summary>
		/// ツールチップ ディクショナリ
		/// 品種略名称
		/// </summary>
		public const string DIC_HINSYU_NM = "DIC_HINSYU_NM";
		#endregion

	}
}
