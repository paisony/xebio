namespace com.xebio.bo.Ta030p01.Constant
{
  /// <summary>
  /// Ta030p01の定数を定義するクラスです。
  /// </summary>
  public static class Ta030p01Constant
	{
        #region プログラムID
        /// <summary>
        /// プログラムID
        /// </summary>
        public const string PGID = "Ta030p01";
        #endregion

        #region フォームID

        /// <summary>
        /// 一覧画面フォームID
        /// </summary>
        public const string FORMID_01 = "Ta030f01";
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const string FORMID_02 = "Ta030f02";

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


		#endregion


		#region SQL_HEAD-ID

		/// <summary>
		/// 補充依頼申請検索（SQL_HEAD①）
		/// </summary>
		public const string SQL_HEAD_ID_01 = "TA030P01-01";
		/// <summary>
		/// 補充依頼確定検索（SQL_HEAD②）
		/// </summary>
		public const string SQL_HEAD_ID_02 = "TA030P01-02";
		/// <summary>
		/// 補充依頼申請検索（SQL_HEAD①）UNION ALL 補充依頼確定検索（SQL_HEAD②）
		/// </summary>
		public const string SQL_HEAD_ID_01_02 = "TA030P01-01_02";
		/// <summary>
		/// 出荷要望申請検索（SQL_HEAD③）
		/// </summary>
		public const string SQL_HEAD_ID_03 = "TA030P01-03";
		/// <summary>
		/// 出荷要望確定検索（SQL_HEAD④）
		/// </summary>
		public const string SQL_HEAD_ID_04 = "TA030P01-04";
		/// <summary>
		/// 出荷要望申請検索（SQL_HEAD③）UNION ALL 出荷要望確定検索（SQL_HEAD④）
		/// </summary>
		public const string SQL_HEAD_ID_03_04 = "TA030P01-03_04";
		/// <summary>
		/// 補充依頼申請検索（SQL_HEAD①）UNION ALL 出荷要望申請検索（SQL_HEAD③）
		/// </summary>
		public const string SQL_HEAD_ID_01_03 = "TA030P01-01_03";
		/// <summary>
		/// 補充依頼確定検索（SQL_HEAD②）UNION ALL 出荷要望確定検索（SQL_HEAD④）
		/// </summary>
		public const string SQL_HEAD_ID_02_04 = "TA030P01-02_04";
		/// <summary>
		/// 補充依頼申請検索（SQL_HEAD①）UNION ALL 補充依頼確定検索（SQL_HEAD②）UNION ALL 出荷要望申請検索（SQL_HEAD③）UNION ALL 出荷要望確定検索（SQL_BMN_Search④）
		/// </summary>
		public const string SQL_HEAD_ID_01_02_03_04 = "TA030P01-01_02_03_04";

		#endregion

		#region SQL_DETAIL-ID
		/// <summary>
		/// 補充依頼申請検索（SQL_DETAIL①）
		/// </summary>
		public const string SQL_DETAIL_ID_01 = "TA030P02-01";
		/// <summary>
		/// 補充依頼確定検索（SQL_DETAIL②）
		/// </summary>
		public const string SQL_DETAIL_ID_02 = "TA030P02-02";
		/// <summary>
		/// 出荷要望申請検索（SQL_DETAIL③）
		/// </summary>
		public const string SQL_DETAIL_ID_03 = "TA030P02-03";
		/// <summary>
		/// 出荷要望確定検索（SQL_DETAIL④）
		/// </summary>
		public const string SQL_DETAIL_ID_04 = "TA030P02-04";

		#endregion

		#region SQL_DETAIL-ID
		/// <summary>
		/// 補充依頼申請検索（SQL_DETAIL①）UNION ALL 補充依頼確定検索（SQL_DETAIL②）
		/// </summary>
		public const string SQL_DETAIL_ID_01_02 = "TA030P02-01_02";
		/// <summary>
		/// 出荷要望申請検索（SQL_DETAIL③）UNION ALL 出荷要望確定検索（SQL_DETAIL④）
		/// </summary>
		public const string SQL_DETAIL_ID_03_04 = "TA030P02-03_04";
		/// <summary>
		/// 補充依頼申請検索（SQL_DETAIL①）UNION ALL 出荷要望申請検索（SQL_DETAIL③）
		/// </summary>
		public const string SQL_DETAIL_ID_01_03 = "TA030P02-01_03";
		/// <summary>
		/// 補充依頼確定検索（SQL_DETAIL②）UNION ALL 出荷要望確定検索（SQL_DETAIL④）
		/// </summary>
		public const string SQL_DETAIL_ID_02_04 = "TA030P02-02_04";
		/// <summary>
		/// 補充依頼申請検索（SQL_DETAIL①）UNION ALL 補充依頼確定検索（SQL_DETAIL②）UNION ALL 出荷要望申請検索（SQL_DETAIL③）UNION ALL 出荷要望確定検索（SQL_DETAIL④）
		/// </summary>
		public const string SQL_DETAIL_ID_01_02_03_04 = "TA030P02-01_02_03_04";


		#endregion




		#region SQL_HEAD-REPLACE-ID

		/// <summary>
		/// 補充依頼申請テーブル検索（SQL_HEAD①）
        /// バインド 検索条件
        /// </summary>
		public const string SQL_HEAD_ID_01_ADD_WHERE = "SQL_HEAD_ID_01_ADD_WHERE";

		/// <summary>
		/// 補充依頼確定テーブル検索（SQL_HEAD②）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_HEAD_ID_02_ADD_WHERE = "SQL_HEAD_ID_02_ADD_WHERE";

		/// <summary>
		/// 出荷要望申請テーブル検索（SQL_HEAD③）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_HEAD_ID_03_ADD_WHERE = "SQL_HEAD_ID_03_ADD_WHERE";

		/// <summary>
		/// 出荷要望確定テーブル検索（SQL_HEAD④）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_HEAD_ID_04_ADD_WHERE = "SQL_HEAD_ID_04_ADD_WHERE";
		#endregion


		#region SQL_DETAIL-REPLACE-ID

		/// <summary>
		/// 補充依頼申請テーブル検索（SQL_DETAIL①）
        /// バインド 検索条件
        /// </summary>
		public const string SQL_DETAIL_ID_01_ADD_WHERE = "SQL_DETAIL_ID_01_ADD_WHERE";

		/// <summary>
		/// 補充依頼確定テーブル検索（SQL_DETAIL②）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_DETAIL_ID_02_ADD_WHERE = "SQL_DETAIL_ID_02_ADD_WHERE";

		/// <summary>
		/// 出荷要望申請テーブル検索（SQL_DETAIL③）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_DETAIL_ID_03_ADD_WHERE = "SQL_DETAIL_ID_03_ADD_WHERE";

		/// <summary>
		/// 出荷要望確定テーブル検索（SQL_DETAIL④）
		/// バインド 検索条件
		/// </summary>
		public const string SQL_DETAIL_ID_04_ADD_WHERE = "SQL_DETAIL_ID_04_ADD_WHERE";

		#endregion


		#region 置き換え変数

		/// <summary>
        /// 補充依頼明細 検索 
        /// 置き換え変数 店舗コード
        /// </summary>
		public const string SQL_REP_TENPO_CD = "TENPO_CD";
			
		/// <summary>
        /// 補充依頼明細 検索 
        /// 置き換え変数 区分
        /// </summary>
        public const string SQL_REP_KBN_CD = "KBN_CD";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 申請状態
		/// </summary>
		public const string SQL_REP_SHINSEI_FLG = "SHINSEI_FLG";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 仕入先
		/// </summary>
		public const string SQL_REP_SIIRESAKI_CD = "SIIRESAKI_CD";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 部門
		/// </summary>
		public const string SQL_REP_BUMON_CD = "BUMON_CD";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 ブランド
		/// </summary>
		public const string SQL_REP_BURANDO_CD = "BURANDO_CD";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 発注日FROM
		/// </summary>
		public const string SQL_REP_UPD_YMD_FROM = "UPD_YMD_FROM";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 発注日TO
		/// </summary>
		public const string SQL_REP_UPD_YMD_TO = "UPD_YMD_TO";
		
		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 旧自社品番
		/// </summary>
		public const string SQL_REP_OLD_XEBIO_CD = "OLD_XEBIO_CD";

		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 自社品番
		/// </summary>
		public const string SQL_REP_JISYA_HBN = "JISYA_HBN";
		
		/// <summary>
		/// 補充依頼明細 検索 
		/// 置き換え変数 スキャンコード
		/// </summary>
		public const string SQL_REP_JAN_CD = "JAN_CD";







        #endregion




        #region Dictionary カード部

		/// <summary>
		/// カード部 ディクショナリ
		/// フォーカス項目
		/// </summary>
		public const string DIC_FOCUS_ITEM = "DIC_FOCUS_ITEM";

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

		#region Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門コード
		/// </summary>
		public const string DIC_M1BUMON_CD = "DIC_M1BUMON_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門カナ名
		/// </summary>
		public const string DIC_M1BUMONKANA_NM = "DIC_M1BUMONKANA_NM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 区分コード
		/// </summary>
		public const string DIC_M1KBN_CD = "DIC_M1KBN_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 申請状態
		/// </summary>
		public const string DIC_M1SHINSEI_FLG = "DIC_M1SHINSEI_FLG";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 仕入先
		/// </summary>
		public const string DIC_M1SIIRESAKI_CD = "DIC_M1SIIRESAKI_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランド
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 発注日FROM
		/// </summary>
		public const string DIC_M1UPD_YMD_FROM = "DIC_M1UPD_YMD_FROM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 発注日TO
		/// </summary>
		public const string DIC_M1UPD_YMD_TO = "DIC_M1UPD_YMD_TO";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 自社品番
		/// </summary>
		public const string DIC_M1JISYA_HBN = "DIC_M1JISYA_HBN";

		/// <summary>
		/// 明細部 ディクショナリ
		/// スキャンコード
		/// </summary>
		public const string DIC_M1JAN_CD = "DIC_M1JAN_CD";


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
		/// 参照テーブル
		/// </summary>
		/// 
		public const string DIC_MODENO = "DIC_MODENO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 参照テーブル
		/// </summary>
		/// 
		public const string DIC_M1TBL_KBN = "DIC_M1TBL_KBN";

		#endregion

		#region 参照テーブル

		/// <summary>
		/// 参照テーブル 返品予定テーブル
		/// </summary>
		public const string TBL_YOTEI = "1";
		/// <summary>
		/// 参照テーブル 返品確定テーブル
		/// </summary>
		public const string TBL_KAKUTEI = "2";
		/// <summary>
		/// 参照テーブル 返品確定履歴テーブル
		/// </summary>
		public const string TBL_RIREKI = "3";

		#endregion

	}
}
