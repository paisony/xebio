namespace com.xebio.bo.Ta020p01.Constant
{
  /// <summary>
  /// Ta020p01の定数を定義するクラスです。
  /// </summary>
  public static class Ta020p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Ta020p01";
		#endregion
		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Ta020f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Ta020f02";
		#endregion

		#region	Facade用UserObject
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
		/// 出荷要望入力_一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TA020P01-01";
		/// <summary>
		/// 出荷要望入力_一覧 検索
		/// </summary>
		public const string SQL_ID_02 = "TA020P01-02";
		/// <summary>
		/// 出荷要望入力_一覧 明細（未申請）
		/// </summary>
		public const string SQL_ID_03 = "TA020P01-03";
		/// <summary>
		/// 出荷要望入力_一覧 明細（申請済み）
		/// </summary>
		public const string SQL_ID_04 = "TA020P01-04";
		/// <summary>
		/// 出荷要望入力_一覧 出荷要望申請TBL(H)更新
		/// </summary>
		public const string SQL_ID_05 = "TA020P01-05";
		/// <summary>
		/// 出荷要望入力_一覧 [出荷要望申請TBL(B)]を検索し、[出荷要望確定TBL(B)]を登録
		/// </summary>
		public const string SQL_ID_06 = "TA020P01-06";
		/// <summary>
		/// 出荷要望入力_一覧 出荷要望確定TBL(B)更新（メッセージ区分）
		/// </summary>
		public const string SQL_ID_07 = "TA020P01-07";
		/// <summary>
		/// 出荷要望入力_一覧 [出荷要望申請TBL(H)]を検索し、[出荷要望確定TBL(H)]を登録
		/// </summary>
		public const string SQL_ID_08 = "TA020P01-08";
		/// <summary>
		/// 出荷要望入力_一覧 [出荷要望確定TBL(H,B)]を削除
		/// </summary>
		public const string SQL_ID_09 = "TA020P01-09";

		/// <summary>
		/// 出荷要望入力_明細 [補充発注一時TBL]を登録
		/// </summary>
		public const string SQL_ID_10 = "TA020P01-10";

		/// <summary>
		/// 出荷要望入力_明細 補発注入力ヘッダ更新(出荷要望申請TBL(H))
		/// </summary>
		public const string SQL_ID_11 = "TA020P01-11";

		/// <summary>
		/// 出荷要望入力_明細 補充発注入力ヘッダ更新(出荷要望確定TBL(H))
		/// </summary>
		public const string SQL_ID_12 = "TA020P01-12";

		/// <summary>
		/// 出荷要望入力_明細 補充発注入力明細登録(出荷要望申請TBL(B))
		/// </summary>
		public const string SQL_ID_13 = "TA020P01-13";

		/// <summary>
		/// 出荷要望入力_明細 補充発注入力明細登録(出荷要望確定TBL(B))
		/// </summary>
		public const string SQL_ID_14 = "TA020P01-14";
		#endregion
		#region	SQL-REPLACE-ID
		/// <summary>
		/// 出荷要望入力_一覧  件数チェック／検索
		/// 置き換え変数 申請 検索条件 申請
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_SHIN = "ADD_WHERE_SHIN";
		/// <summary>
		/// 出荷要望入力_一覧  件数チェック／検索
		/// 置き換え変数 検索条件 検索条件 確定
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_KAKU = "ADD_WHERE_KAKU";
		/// <summary>
		/// 出荷要望入力_一覧  件数チェック／検索
		/// 置き換え変数 検索条件 申請有効可否
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN = "ADD_WHERE_KAHI_SHIN";
		/// <summary>
		/// 出荷要望入力_一覧  件数チェック／検索
		/// 置き換え変数 検索条件 確定有効可否
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU = "ADD_WHERE_KAHI_KAKU";
		/// <summary>
		/// 出荷要望入力
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ADD_TBLID = "ADD_TBLID";
		#endregion
		
		#region	Dictionary カード部
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
		/// 依頼理由コード
		/// </summary>
		public const string DIC_M1IRAIRIYU_CD = "DIC_M1IRAIRIYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 申請状態
		/// </summary>
		public const string DIC_M1SHINSEI_FLG = "DIC_M1SHINSEI_FLG";
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
		/// 販売完了日
		/// </summary>
		public const string DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";
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
		/// 選択行のM1VO
		/// </summary>
		public const string DIC_M1SELCETVO = "DIC_M1SELCETVO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行
		/// </summary>
		public const string DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";

		#endregion
		#region プログラム固定値
		/// <summary>
		/// 理由コメント 業務区分 「出荷要望店舗依頼:013」
		/// </summary>
		public const string RIYU_GYOMU_SYUTUKA = "013";
		/// <summary>
		/// 名称マスタ 識別コード 「申請状態名称:HTST」
		/// </summary>
		public const string MEISHO_SIKIBETSU_CD_SHINSEI = "HTST";
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
		/// 削除区分 0:申請HEAD
		/// </summary>
		public const decimal DEL_KBN_SHINSEI_HEAD = 0;
		/// <summary>
		/// 削除区分 1:申請BODY
		/// </summary>
		public const decimal DEL_KBN_SHINSEI_BODY = 1;
		/// <summary>
		/// 削除区分 2:確定HEAD
		/// </summary>
		public const decimal DEL_KBN_KAKUTEI_HEAD = 2;
		/// <summary>
		/// 削除区分 3:確定BODY
		/// </summary>
		public const decimal DEL_KBN_KAKUTEI_BODY = 3;
		/// <summary>
		/// 登録区分 0:申請TBL
		/// </summary>
		public const decimal REG_KBN_SHINSEI = 0;
		/// <summary>
		/// 登録区分 1:確定TBL
		/// </summary>
		public const decimal REG_KBN_KAKUTEI = 1;
		/// <summary>
		/// 登録区分 1:確定TBL
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
