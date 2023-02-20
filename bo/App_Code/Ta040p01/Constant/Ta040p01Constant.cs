namespace com.xebio.bo.Ta040p01.Constant
{
  /// <summary>
  /// Ta040p01の定数を定義するクラスです。
  /// </summary>
  public static class Ta040p01Constant
    {
        #region プログラムID
        /// <summary>
        /// プログラムID
        /// </summary>
        public const string PGID = "Ta040p01";
        #endregion

        #region フォームID

        /// <summary>
        /// 一覧画面フォームID
        /// </summary>
        public const string FORMID_01 = "Ta040f01";
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const string FORMID_02 = "Ta040f02";

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
        /// 部門カナ名
        /// </summary>
        public const string DIC_M1BUMONKANA_NM = "DIC_M1BUMONKANA_NM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 変更区分
        /// </summary>
        public const string DIC_M1HENKO_KBN = "DIC_M1HENKO_KBN";
         /// <summary>
        /// 明細部 ディクショナリ
        /// 店舗コード
        /// </summary>
        public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 決済日
        /// </summary>
        public const string DIC_M1KESSAI_YMD = "DIC_M1KESSAI_YMD";
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
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

        #region SQL-ID
        /// <summary>
        /// 補充依頼結果 [補充依頼結果TBL(H)]件数チェック
        /// </summary>
        public const string SQL_ID_01 = "TA040P01-01";
        /// <summary>
        /// 補充依頼結果 [補充依頼結果TBL(H)]検索
        /// </summary>
        public const string SQL_ID_02 = "TA040P01-02";
        /// <summary>
        /// 補充依頼結果 [補充依頼結果TBL(B)]件数チェック
        /// </summary>
        public const string SQL_ID_03 = "TA040P01-03";

        #endregion

        #region SQL-REPLACE-ID
        /// <summary>
        /// 補充依頼結果 [補充依頼結果TBL(H) 件数チェック／検索
        /// 置き換え変数 検索条件
        /// </summary>
        public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
        /// <summary>
        /// 返品確定明細 検索 
        /// 置き換え変数 店舗コード
        /// </summary>
        public const string SQL_ID_02_REP_TENPO_CD = "TENPO_CD";
        /// <summary>
        /// 返品確定明細 検索 
        /// 置き換え変数 決裁日
        /// </summary>
        public const string SQL_ID_03_REP_KESSAI_YMD = "KESSAI_YMD";
        /// <summary>
        /// 返品確定明細 検索 
        /// 置き換え変数 変更区分
        /// </summary>
        public const string SQL_ID_04_REP_HENKO_KBN = "HENKO_KBN";
        /// <summary>
        /// 返品確定明細 検索 
        /// 置き換え変数 部門コード
        /// </summary>
        public const string SQL_ID_05_REP_BUMON_CD = "BUMON_CD";


        #endregion
    }
}
