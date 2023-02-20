namespace com.xebio.bo.Te090p01.Constant
{
  /// <summary>
  /// Te090p01の定数を定義するクラスです。
  /// </summary>
  public static class Te090p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Te090p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Te090f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Te090f02";

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

		#endregion

		#region SQL-ID

		#region 一覧画面
		/// <summary>
		/// 一覧検索件数（入荷確定）
		/// </summary>
		public const string SQL_ID_01 = "TE090P01-01";
		/// <summary>
		/// 一覧検索（入荷確定）
		/// </summary>
		public const string SQL_ID_02 = "TE090P01-02";
		/// <summary>
		/// 一覧検索件数（入荷確定以外）
		/// </summary>
		public const string SQL_ID_03 = "TE090P01-03";
		/// <summary>
		/// 一覧検索（入荷確定以外）
		/// </summary>
		public const string SQL_ID_04 = "TE090P01-04";
		/// <summary>
		/// 明細検索（入荷確定）
		/// </summary>
		public const string SQL_ID_05 = "TE090P01-05";
		/// <summary>
		/// 明細検索（入荷確定以外）
		/// </summary>
		public const string SQL_ID_06 = "TE090P01-06";
		/// <summary>
		/// 移動入荷未存在リスト更新(論理削除)
		/// </summary>
		public const string SQL_ID_08 = "TE090P01-08";
		/// <summary>
		/// 移動入荷確定TBL(H)登録
		/// </summary>
		public const string SQL_ID_09 = "TE090P01-09";
		/// <summary>
		/// 移動入荷確定TBL(B)登録
		/// </summary>
		public const string SQL_ID_10 = "TE090P01-10";
		/// <summary>
		/// [移動入荷確定TBL(H)]更新
		/// </summary>
		public const string SQL_ID_11 = "TE090P01-11";
		/// <summary>
		/// 移動入荷確定TBL(B)登録(明細用)
		/// </summary>
		public const string SQL_ID_12 = "TE090P01-12";
		/// <summary>
		/// 移動入荷予定TBL(H)更新
		/// </summary>
		public const string SQL_ID_15 = "TE090P01-15";
		/// <summary>
		/// 移動入荷履歴TBL(H)登録
		/// </summary>
		public const string SQL_ID_16 = "TE090P01-16";
		/// <summary>
		/// 移動入荷履歴TBL(B)登録
		/// </summary>
		public const string SQL_ID_17 = "TE090P01-17";
		/// <summary>
		/// 移動入荷確定TBL(B)削除
		/// </summary>
		public const string SQL_ID_18 = "TE090P01-18";
		/// <summary>
		/// 移動入荷確定TBL(H)削除
		/// </summary>
		public const string SQL_ID_19 = "TE090P01-19";
		/// <summary>
		/// 移動出荷差異リスト削除
		/// </summary>
		public const string SQL_ID_20 = "TE090P01-20";
		/// <summary>
		/// 移動出荷確定TBL(H)更新(取消用)
		/// </summary>
		public const string SQL_ID_21 = "TE090P01-21";
		/// <summary>
		/// 移動出荷確定TBL(B)更新(取消用)
		/// </summary>
		public const string SQL_ID_22 = "TE090P01-22";
		/// <summary>
		/// 移動出荷確定TBL(H)更新(入荷確定、修正用)
		/// </summary>
		public const string SQL_ID_23 = "TE090P01-23";
		/// <summary>
		/// 移動出荷確定TBL(B)更新(入荷確定、修正用)
		/// </summary>
		public const string SQL_ID_24 = "TE090P01-24";
		/// <summary>
		/// 移動出荷差異TBL登録
		/// </summary>
		public const string SQL_ID_25 = "TE090P01-25";

		#endregion

		#endregion

		#region SQL-REPLACE-ID
		/// <summary>
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_REP_ADD_WHERE = "ADD_WHERE";
		/// <summary>
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_REP_TABLE_ID = "TABLE_ID";

		/// <summary>
		/// バインド変数 店舗ＬＣ区分
		/// </summary>
		public const string SQL_BIND_TENPOLC_KBN = "BIND_TENPOLC_KBN";
		/// <summary>
		/// バインド変数 出荷会社コード
		/// </summary>
		public const string SQL_BIND_SYUKKAKAISYA_CD = "BIND_SYUKKAKAISYA_CD";
		/// <summary>
		/// バインド変数 出荷店コード
		/// </summary>
		public const string SQL_BIND_SYUKKATEN_CD = "BIND_SYUKKATEN_CD";
		/// <summary>
		/// バインド変数 伝票番号
		/// </summary>
		public const string SQL_BIND_DENPYO_BANGO = "BIND_DENPYO_BANGO";
		/// <summary>
		/// バインド変数 出荷日
		/// </summary>
		public const string SQL_BIND_SYUKKA_YMD = "BIND_SYUKKA_YMD";
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
		#endregion

		#region Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗ＬＣ区分
		/// </summary>
		public const string DIC_M1TENPOLC_KBN = "DIC_M1TENPOLC_KBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 会社コード
		/// </summary>
		public const string DIC_M1KAISYA_CD = "DIC_M1KAISYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 会社名
		/// </summary>
		public const string DIC_M1KAISYA_NM = "DIC_M1KAISYA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷担当者コード
		/// </summary>
		public const string DIC_M1SYUKKATAN_CD = "DIC_M1SYUKKATAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷担当者名
		/// </summary>
		public const string DIC_M1SYUKKATAN_NM = "DIC_M1SYUKKATAN_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷担当者コード
		/// </summary>
		public const string DIC_M1NYUKATAN_CD = "DIC_M1NYUKATAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷担当者名
		/// </summary>
		public const string DIC_M1NYUKATAN_NM = "DIC_M1NYUKATAN_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日（予定）
		/// </summary>
		public const string DIC_M1UPD_YMD_YOTEI = "DIC_M1UPD_YMD_YOTEI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間（予定）
		/// </summary>
		public const string DIC_M1UPD_TM_YOTEI = "DIC_M1UPD_TM_YOTEI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日（確定）
		/// </summary>
		public const string DIC_M1UPD_YMD_KAKUTEI = "DIC_M1UPD_YMD_KAKUTEI";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間（確定）
		/// </summary>
		public const string DIC_M1UPD_TM_KAKUTEI = "DIC_M1UPD_TM_KAKUTEI";
		#endregion

		#region 店舗ＬＣ区分
		/// <summary>
		/// 店舗ＬＣ区分　店舗
		/// </summary>
		public const string TENPO_LC_KBN_TENPO = "0";
		/// <summary>
		/// 店舗ＬＣ区分　ＬＣ
		/// </summary>
		public const string TENPO_LC_KBN_LC = "1";
		#endregion

		#region 処理種別

		/// <summary>
		/// 処理種別 入荷確定
		/// </summary>
		public const decimal SYORI_SB_NYUKAKAKUTEI = 1;
		/// <summary>
		/// 処理種別 修正
		/// </summary>
		public const decimal SYORI_SB_UPD = 2;
		/// <summary>
		/// 処理種別 取消
		/// </summary>
		public const decimal SYORI_SB_DEL = 3;

		#endregion

		#region 赤黒区分

		/// <summary>
		/// 赤黒区分 黒
		/// </summary>
		public const decimal AKAKURO_KURO = 0;
		/// <summary>
		/// 赤黒区分 赤
		/// </summary>
		public const decimal AKAKURO_AKA = 1;

		#endregion

	}
}
