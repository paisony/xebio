namespace com.xebio.bo.Te070p01.Constant
{
  /// <summary>
  /// Te070p01の定数を定義するクラスです。
  /// </summary>
  public static class Te070p01Constant
	{
        #region プログラムID
        /// <summary>
        /// プログラムID
        /// </summary>
        public const string PGID = "Te070p01";
        #endregion

        #region フォームID

        /// <summary>
        /// 一覧画面フォームID
        /// </summary>
        public const string FORMID_01 = "Te070f01";
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const string FORMID_02 = "Te070f02";
    #endregion

    #region Facade用UserObject
        /// <summary>
        /// 明細画面フォームID
        /// </summary>
        public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
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
        /// 移動入荷検索 件数(移動入荷予定テーブル、移動入荷確定テーブル)チェック
        /// </summary>
        public const string SQL_ID_01 = "TE070P01-01";
        /// <summary>
        /// 移動入荷検索 件数チェック
        /// </summary>
        public const string SQL_ID_02 = "TE070P01-02";
        /// <summary>
        /// 移動入荷検索 検索(移動入荷予定テーブル、移動入荷確定テーブル)
        /// </summary>
        public const string SQL_ID_03 = "TE070P01-03";
        /// <summary>
        /// 移動入荷検索 検索(移動入荷予定テーブル)
        /// </summary>
        public const string SQL_ID_04 = "TE070P01-04";
        /// <summary>
        /// 移動入荷検索 検索(移動入荷確定テーブル)
        /// </summary>
        public const string SQL_ID_05 = "TE070P01-05";
        /// <summary>
        /// 移動入荷検索 検索(移動入荷履歴テーブル)
        /// </summary>
        public const string SQL_ID_06 = "TE070P01-06";
        /// <summary>
        /// 移動入荷予定テーブル 検索(予定テーブル)
        /// </summary>
        public const string SQL_ID_07 = "TE070P01-07";

        /// <summary>
        /// 移動入荷確定テーブル 検索(確定テーブル)
        /// </summary>
        public const string SQL_ID_08 = "TE070P01-08";

        /// <summary>
        /// 移動入荷履歴テーブル 検索(履歴テーブル)
        /// </summary>
        public const string SQL_ID_09 = "TE070P01-09";

        #endregion

        #region SQL-REPLACE-ID
        /// <summary>
        /// 移動入荷検索 件数チェック／検索
        /// 置き換え変数 テーブルID
        /// </summary>
        public const string SQL_ID_01_REP_TABLE_ID1 = "TABLE_ID1";
        /// <summary>
        /// 移動入荷検索 件数チェック／検索
        /// 置き換え変数 テーブルID
        /// </summary>
        public const string SQL_ID_01_REP_TABLE_ID2 = "TABLE_ID2";
        /// <summary>
        /// 移動入荷検索 件数チェック／検索
        /// 置き換え変数 検索条件1
        /// </summary>
        public const string SQL_ID_01_REP_ADD_WHERE1 = "W1";
        /// <summary>
        /// 移動入荷検索 件数チェック／検索
        /// 置き換え変数 検索条件2
        /// </summary>
        public const string SQL_ID_01_REP_ADD_WHERE2 = "W2";
        /// <summary>
        /// 移動入荷検索 ORDER BY用(SELECT)
        /// 置き換え変数 ログイン会社コード
        /// </summary>
        public const string SQL_ID_04_ORD_LOGINTENPO_CD = "BIND_LOGINTENPO_CD";
        /// <summary>
        /// 移動入荷検索 ORDER BY用(UNION ALL)
        /// 置き換え変数 ログイン会社コード
        /// </summary>
        public const string SQL_ID_04_ORD_LOGIN_TENPOCD = "BIND_LOGIN_TENPOCD";
        /// <summary>
        /// 移動入荷検索 ORDER BY用(SELECT)
        /// 置き換え変数 ログイン会社コード
        /// </summary>
        public const string SQL_ID_04_SEL_LOGINTENPO_RE = "BIND_LOGINTENPO_RE";
        /// <summary>
        /// 移動入荷検索 ORDER BY用(UNION ALL)
        /// 置き換え変数 ログイン会社コード
        /// </summary>
        public const string SQL_ID_04_SEL_LOGIN_TENPOCD_RE = "BIND_LOGIN_TENPOCD_RE";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 店舗LC区分
        /// </summary>
        public const string SQL_ID_07_REP_TENPOLC_KBN = "TENPOLC_KBN";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 出荷会社コード
        /// </summary>
        public const string SQL_ID_07_REP_SYUKKAKAISYA_CD = "SYUKKAKAISYA_CD";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 出荷店コード
        /// </summary>
        public const string SQL_ID_07_REP_SYUKKATEN_CD = "SYUKKATEN_CD";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 伝票番号
        /// </summary>
        public const string SQL_ID_07_REP_DENPYO_BANGO = "DENPYO_BANGO";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 出荷日
        /// </summary>
        public const string SQL_ID_07_REP_SYUKKA_YMD = "SYUKKA_YMD";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 履歴No
        /// </summary>
        public const string SQL_ID_07_REP_RIREKI_NO = "RIREKI_NO";
        /// <summary>
        /// 仕入入荷検索明細 検索 
        /// 置き換え変数 赤黒区分
        /// </summary>
        public const string SQL_ID_07_REP_AKAKURO_KBN = "AKAKURO_KBN";


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

        #region TABLE-ID

        /// <summary>
        /// 移動入荷予定テーブル  テーブルID
        /// </summary>
        public const string TABLE_ID_MDNT0010 = "MDNT0010";

        /// <summary>
        /// 移動入荷確定テーブル  テーブルID
        /// </summary>
        public const string TABLE_ID_MDNT0020 = "MDNT0020";

        /// <summary>
        /// 移動入荷履歴テーブル  テーブルID
        /// </summary>
        public const string TABLE_ID_MDNT0040 = "MDNT0040";

        #endregion

        #region Dictionary 明細部

        /// <summary>
        /// 明細部 ディクショナリ
        /// 伝票番号
        /// </summary>
        public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 予定数量　0
        ///// </summary>
        //public const string DIC_M1YOTEISUU = "0";
        /// <summary>
        /// 明細部 ディクショナリ
        /// SCMコード
        /// </summary>
        public const string DIC_M1SCM_CD = "DIC_M1SCM_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 確定フラグ 0
        /// </summary>
        public const string DIC_M1KAKUTEIFLG0 = "0";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 確定フラグ 1
        /// </summary>
        public const string DIC_M1KAKUTEIFLG1 = "1";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 伝票状態
        ///// </summary>
        //public const string DIC_M1DENPYO_JYOTAI = "DIC_M1DENPYO_JYOTAI";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 確定種別
        ///// </summary>
        //public const string DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 部門名
        ///// </summary>
        //public const string DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 履歴No
        ///// </summary>
        //public const string DIC_M1RIREKI_NO = "DIC_M1RIREKI_NO";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 赤黒区分
        ///// </summary>
        //public const string DIC_M1AKAKURO_KBN = "DIC_M1AKAKURO_KBN";
        ///// <summary>
        ///// 明細部 ディクショナリ
        ///// 伝票状態　未処理
        ///// </summary>
        public static object DIC_M1DENPYO_FLG = "0";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 確定フラグ　未確定
        /// </summary>
        public static object DIC_M1KAKUTEI_FLG_MIKAKUTEI = "0";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 確定フラグ　確定
        /// </summary>
        public static object DIC_M1KAKUTEI_FLG_KAKUTEI = "1";

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
        /// 出荷会社コード
        /// </summary>
        public const string DIC_M1SYUKKAKAISYA_CD = "DIC_M1SYUKKAKAISYA_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 出荷会社名称
        /// </summary>
        public const string DIC_M1SYUKKAKAISYA_NM = "DIC_M1SYUKKAKAISYA_NM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 出荷店コード
        /// </summary>
        public const string DIC_M1SYUKKATEN_CD = "DIC_M1SYUKKATEN_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 出荷店名称
        /// </summary>
        public const string DIC_M1TENPO_NM = "DIC_M1TENPO_NM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 店舗ＬＣ区分
        /// </summary>
        public const string DIC_M1TENPOLC_KBN = "DIC_M1TENPOLC_KBN";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 履歴処理日付
        /// </summary>
        public const string DIC_M1RIREKI_SYORIYMD = "DIC_M1RIREKI_SYORIYMD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 履歴処理時間
        /// </summary>
        public const string DIC_M1RIREKI_SYORITM = "DIC_M1RIREKI_SYORITM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 入荷担当者コード
        /// </summary>
        public const string DIC_M1ADDHANBAIIN_CD = "DIC_ADDHANBAIIN_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 入荷担当者名
        /// </summary>
        public const string DIC_M1HANBAIIN_NM = "DIC_M1HANBAIIN_NM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 出荷担当者コード
        /// </summary>
        public const string DIC_M1SYUKKATAN_CD = "DIC_M1SYUKKATAN_CD";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 出荷担当者名
        /// </summary>
        public const string DIC_M1SYUKKATAN_HANBAIIN_NM = "DIC_M1SYUKKATAN_HANBAIIN_NM";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 伝票状態
        /// </summary>
        public const string DIC_M1DENPYO_JYOTAI = "DIC_M1DENPYO_JYOTAI";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 確定フラグ
        /// </summary>
        public const string DIC_M1KAKUTEI_FLG = "DIC_M1KAKUTEI_FLG";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 履歴No.
        /// </summary>
        public const string DIC_M1RIREKI_NO = "DIC_M1RIREKI_NO";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 赤黒区分
        /// </summary>
        public const string DIC_M1AKAKURO_KBN = "DIC_M1AKAKURO_KBN";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 入荷予定合計数量
        /// </summary>
        public const string DIC_NYUKAYOTEIGOUKEI_SU = "DIC_NYUKAYOTEIGOUKEI_SU";
        /// <summary>
        /// 明細部 ディクショナリ
        /// 入荷実績合計数量
        /// </summary>
        public const string NYUKAJISSEKIGOUKEI_SU = "NYUKAJISSEKIGOUKEI_SU";


        #endregion
    }
}
