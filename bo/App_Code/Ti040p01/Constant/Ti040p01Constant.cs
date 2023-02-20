namespace com.xebio.bo.Ti040p01.Constant
{
  /// <summary>
  /// Ti040p01の定数を定義するクラスです。
  /// </summary>
  public static class Ti040p01Constant
	{
        #region プログラムID

        /// <summary>
        /// プログラムID
        /// </summary>
        public const string PGID = "Ti040p01";

        #endregion

        #region フォームID

        /// <summary>
        /// 画面フォームID
        /// </summary>
        public const string FORMID_01 = "Ti040f01";

        #endregion

        #region Facade用UserObject

        /// <summary>
        /// ラベル発行機ID桁数
        /// </summary>
        public const int LEN_LABEL_CD = 7;

        /// <summary>
        /// フォーカス情報 行数
        /// </summary>
        public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";

        #endregion

        #region SQL-ID

        /// <summary>
        /// ラベルプリンタ管理 件数チェック
        /// </summary>
        public const string SQL_ID_01 = "TI040P01-01";
        /// <summary>
        /// ラベルプリンタ管理 検索(ラベルプリンタ管理MST)
        /// </summary>
        public const string SQL_ID_02 = "TI040P01-02";
        /// <summary>
        /// ラベルプリンタ管理 削除(ラベルプリンタ管理MST)
        /// </summary>
        public const string SQL_ID_03 = "TI040P01-03";
        /// <summary>
        /// ラベルプリンタ管理 登録(ラベルプリンタ管理MST)
        /// </summary>
        public const string SQL_ID_04 = "TI040P01-04";
        /// <summary>
        /// ラベルプリンタ管理 更新(ラベルプリンタ管理MST)
        /// </summary>
        public const string SQL_ID_05 = "TI040P01-05";
        /// <summary>
        /// ラベルプリンタ管理 他店舗で同一IP存在チェック
        /// </summary>
        public const string SQL_ID_06 = "TI040P01-06";
        /// <summary>
        /// ラベルプリンタ管理 ラベル発行機IDの存在チェック
        /// </summary>
        public const string SQL_ID_07 = "TI040P01-07";

        #endregion

        #region SQL-REPLACE-ID


        #endregion

        #region Dictionary カード部


        #endregion

        #region Dictionary 明細部

        /// <summary>
        /// 明細部 ディクショナリ
        /// ラベル発行機ＩＤ
        /// </summary>
        public const string DIC_M1LABEL_CD = "DIC_M1LABEL_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// ラベル発行機ＩＤ２
        /// </summary>
        public const string DIC_M1LABEL_CD2 = "DIC_M1LABEL_CD2";
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

        #endregion

    }
}
