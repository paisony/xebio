namespace com.xebio.bo.Tj040p01.Constant
{
  /// <summary>
  /// Tj040p01の定数を定義するクラスです。
  /// </summary>
  public static class Tj040p01Constant
	{
        #region プログラムID

        /// <summary>
        /// プログラムID
        /// </summary>
        public const string PGID = "Tj040p01";

        #endregion

        #region フォームID

        /// <summary>
        /// 画面フォームID
        /// </summary>
        public const string FORMID_01 = "Tj040f01";
        public const string FORMID_02 = "Tj040f02";

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

        /// <summary>
        /// 出力CSVファイル名
        /// </summary>
        public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";

        #endregion

        #region SQL-ID

        /// <summary>
        /// 棚卸検索(X)-一覧 件数チェック
        /// </summary>
        public const string SQL_ID_01 = "TJ040P01-01";
        /// <summary>
        /// 棚卸検索(X)-一覧 検索(店舗／業者)
        /// </summary>
        public const string SQL_ID_02 = "TJ040P01-02";
        /// <summary>
        /// 棚卸検索(X)-一覧 CSV出力(店舗／業者)
        /// </summary>
        public const string SQL_ID_03 = "TJ040P01-03";
        /// <summary>
        /// 棚卸検索(X)-一覧 M1フェイスNoリンク(店舗)
        /// </summary>
        public const string SQL_ID_04 = "TJ040P01-04";
        /// <summary>
        /// 棚卸検索(X)-一覧 M1フェイスNoリンク(業者)
        /// </summary>
        public const string SQL_ID_05 = "TJ040P01-05";
        /// <summary>
        /// 棚卸検索(X)-一覧 [棚卸確定TBL(H)]の削除
        /// </summary>
        public const string SQL_ID_06 = "TJ040P01-06";
        /// <summary>
        /// 棚卸検索(X)-一覧・明細 [棚卸確定TBL(B)]の削除
        /// </summary>
        public const string SQL_ID_07 = "TJ040P01-07";
        /// <summary>
        /// 棚卸検索(X)-明細 [棚卸欠番TBL]の削除
        /// </summary>
        public const string SQL_ID_08 = "TJ040P01-08";
        /// <summary>
        /// 棚卸検索(X)-明細 [棚卸確定TBL(H)]の更新
        /// </summary>
        public const string SQL_ID_09 = "TJ040P01-09";
		/// <summary>
		/// 棚卸検索(X)-明細 回数の取得
		/// </summary>
		public const string SQL_ID_10 = "TJ040P01-10";
		/// <summary>
		/// 棚卸検索(X)-明細 フェイスＮｏ、棚段の存在チェック
		/// </summary>
		public const string SQL_ID_11 = "TJ040P01-11";

        #endregion

        #region SQL-REPLACE-ID


        #endregion

        #region Dictionary カード部

        /// <summary>
        /// カード部 ディクショナリ
        /// 棚卸基準日
        /// </summary>
        public const string DIC_TANAOROSIKIJUN_YMD = "DIC_TANAOROSIKIJUN_YMD";


        /// <summary>
        /// カード部 ディクショナリ
        /// フェイスNo
        /// </summary>
        public const string DIC_FACE_NO = "DIC_FACE_NO";
        /// <summary>
        /// カード部 ディクショナリ
        /// 棚段
        /// </summary>
        public const string DIC_TANA_DAN = "DIC_TANA_DAN";
        /// <summary>
        /// カード部 ディクショナリ
        /// 棚卸日
        /// </summary>
        public const string DIC_TANAOROSI_YMD = "DIC_TANAOROSI_YMD";
        /// <summary>
        /// カード部 ディクショナリ
        /// 送信回数
        /// </summary>
        public const string DIC_SOSINKAI_SU = "DIC_SOSINKAI_SU";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番 １～５
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD1 = "DIC_SEARCH_XEBIOCD1";
		public const string DIC_SEARCH_XEBIOCD2 = "DIC_SEARCH_XEBIOCD2";
		public const string DIC_SEARCH_XEBIOCD3 = "DIC_SEARCH_XEBIOCD3";
		public const string DIC_SEARCH_XEBIOCD4 = "DIC_SEARCH_XEBIOCD4";
		public const string DIC_SEARCH_XEBIOCD5 = "DIC_SEARCH_XEBIOCD5";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索JANコード １～５
		/// </summary>
		public const string DIC_SEARCH_JANCD1 = "DIC_SEARCH_JANCD1";
		public const string DIC_SEARCH_JANCD2 = "DIC_SEARCH_JANCD2";
		public const string DIC_SEARCH_JANCD3 = "DIC_SEARCH_JANCD3";
		public const string DIC_SEARCH_JANCD4 = "DIC_SEARCH_JANCD4";
		public const string DIC_SEARCH_JANCD5 = "DIC_SEARCH_JANCD5";

        #endregion

        #region Dictionary 明細部

        /// <summary>
        /// 明細部 ディクショナリ
        /// 棚卸日
        /// </summary>
        public const string DIC_M1TANAOROSI_YMD = "DIC_M1TANAOROSI_YMD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 送信回数
        /// </summary>
        public const string DIC_M1SOSINKAI_SU = "DIC_M1SOSINKAI_SU";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 入力担当者コード
        /// </summary>
        public const string DIC_M1NYURYOKUTAN_CD = "DIC_M1NYURYOKUTAN_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 訂正担当者コード
        /// </summary>
        public const string DIC_M1TEISEITAN_CD = "DIC_M1TEISEITAN_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 理由コード
        /// </summary>
        public const string DIC_M1RIYUCOMMENT_CD = "DIC_M1RIYUCOMMENT_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 店舗／業者区分
        /// </summary>
        public const string DIC_M1TENPO_GYOSYA_KB = "DIC_M1TENPO_GYOSYA_KB";

        /// <summary>
        /// 明細部 ディクショナリ
        /// フェイスNo
        /// </summary>
        public const string DIC_M1FACE_NO = "DIC_M1FACE_NO";

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
        /// 更新担当者コード
        /// </summary>
        public const string DIC_M1UPD_TANCD = "DIC_M1UPD_TANCD";

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
        /// 訂正フラグ
        /// </summary>
        public const string DIC_M1TEISEI_FLG = "DIC_M1TEISEI_FLG";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 商品コード
        /// </summary>
        public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";

        #endregion

		#region 定数
		/// <summary>
		/// 訂正フラグ 訂正あり
		/// </summary>
		public const string TEISEI_FLG_1 = "1";
		#endregion

	}
}
