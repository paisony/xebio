using System;

namespace com.xebio.bo.Te010p01.Constant
{
  /// <summary>
  /// Te010p01の定数を定義するクラスです。
  /// </summary>
  public static class Te010p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Te010p01";
		#endregion

		#region	フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Te010f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Te010f02";
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
		/// 一覧画面 帳票ファイル名
		/// </summary>
		public const string FCDUO_PRT_FLNM = "FCDUO_PRT_FLNM";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";
		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";
		#endregion
		#region	SQL-ID
		/// <summary>
		/// 移動出荷検索_一覧 件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TE010P01-01";
		/// <summary>
		/// 移動出荷検索_一覧 検索(移動出荷確定テーブル)
		/// </summary>
		public const string SQL_ID_02 = "TE010P01-02";
		/// <summary>
		/// 移動出荷検索_一覧 検索(移動出荷履歴テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TE010P01-03";
		/// <summary>
		/// 移動出荷検索_一覧 明細(移動出荷確定テーブル及び移動出荷履歴テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TE010P01-04";
		/// <summary>
		/// 移動出荷検索_一覧 [移動入荷予定TBL(H,B)]を削除
		/// </summary>
		public const string SQL_ID_05 = "TE010P01-05";
		/// <summary>
		/// 移動出荷検索_一覧 [移動出荷確定TBL(H)]を検索し、[移動出荷履歴TBL(H)]を登録
		/// </summary>
		public const string SQL_ID_06 = "TE010P01-06";
		/// <summary>
		/// 移動出荷検索_一覧 [移動出荷確定TBL(B)]を検索し、[移動出荷履歴TBL(B)]を登録
		/// </summary>
		public const string SQL_ID_07 = "TE010P01-07";
		/// <summary>
		/// 移動出荷検索_一覧 [移動出荷確定TBL(H,B)]を削除
		/// </summary>
		public const string SQL_ID_08 = "TE010P01-08";
		#endregion
		#region	SQL-REPLACE-ID
		/// <summary>
		/// 移動出荷検索_一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE = "ADD_WHERE";
		/// <summary>
		/// 移動出荷検索_一覧
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ADD_TBLID = "ADD_TBLID";
		#endregion
		#region	Dictionary カード部

		/// <summary>
		/// 明細用 ディクショナリ
		/// 送信済みフラグ
		/// </summary>
		public const string DIC_SOSINZUMI_FLG = "DIC_SOSINZUMI_FLG";
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
		/// <summary>
		/// 明細用 ディクショナリ
		/// 参照テーブル 
		/// </summary>
		public const string DIC_REF_TBL = "DIC_REF_TBL";
		#endregion

		#region	Dictionary 明細部
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日付（出荷確定）
		/// </summary>
		public const string DIC_M1UPD_YMD_SYUKKA = "DIC_M1UPD_YMD_SYUKKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間（出荷確定）
		/// </summary>
		public const string DIC_M1UPD_TM_SYUKKA = "DIC_M1UPD_TM_SYUKKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日付（入荷予定）
		/// </summary>
		public const string DIC_M1UPD_YMD_NYUKA = "DIC_M1UPD_YMD_NYUKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間（入荷予定）
		/// </summary>
		public const string DIC_M1UPD_TM_NYUKA = "DIC_M1UPD_TM_NYUKA";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷日
		/// </summary>
		public const string DIC_M1SYUKKA_YMD = "DIC_M1SYUKKA_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷日
		/// </summary>
		public const string DIC_M1JYURYO_YMD = "DIC_M1JYURYO_YMD";
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
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷担当者名称
		/// </summary>
		public const string DIC_M1NYUKATAN_NM = "DIC_M1NYUKATAN_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷担当者コード
		/// </summary>
		public const string DIC_M1NYUKATAN_CD = "DIC_M1NYUKATAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録担当者名
		/// </summary>
		public const string DIC_M1ADDTAN_NM = "DIC_M1ADDTAN_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録担当者コード
		/// </summary>
		public const string DIC_M1ADDTAN_CD = "DIC_M1ADDTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信済みフラグ（出荷確定）
		/// </summary>
		public const string DIC_M1SOSINZUMI_FLG = "DIC_M1SOSINZUMI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定フラグ（入荷予定）
		/// </summary>
		public const string DIC_M1KAKUTEI_FLG = "DIC_M1KAKUTEI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷会社コード
		/// </summary>
		public const string DIC_M1JYURYOKAISYA_CD = "DIC_M1JYURYOKAISYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷会社名
		/// </summary>
		public const string DIC_M1JYURYOKAISYA_NM = "DIC_M1JYURYOKAISYA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入荷会社名カナ
		/// </summary>
		public const string DIC_M1JYURYOKAISYA_KANA_NM = "DIC_M1JYURYOKAISYA_KANA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷会社コード
		/// </summary>
		public const string DIC_M1SYUKKAKAISYA_CD = "DIC_M1SYUKKAKAISYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷会社名
		/// </summary>
		public const string DIC_M1SYUKKAKAISYA_NM = "DIC_M1SYUKKAKAISYA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出荷会社名カナ
		/// </summary>
		public const string DIC_M1SYUKKAKAISYA_KANA_NM = "DIC_M1SYUKKAKAISYA_KANA_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 出力順
		/// </summary>
		public const string DIC_M1SORTKEY = "DIC_M1SORTKEY";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 履歴No(履歴テーブル用)
		/// </summary>
		public const string DIC_M1RIREKI_NO = "DIC_M1RIREKI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 赤黒区分(履歴テーブル用)
		/// </summary>
		public const string DIC_M1AKAKURO_KBN = "DIC_M1AKAKURO_KBN";

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
		/// 確定種別（移動）　通常
		/// </summary>
		public const string KAKUTEI_SB_IDOU_TSUJO = "0";
		/// <summary>
		/// 確定種別（移動）　ﾏﾆｭｱﾙ出荷
		/// </summary>
		public const string KAKUTEI_SB_IDOU_MANUAL = "1";
		/// <summary>
		/// 名称マスタ 識別コード 「会社:KASY」
		/// </summary>
		public const string SIKIBETSU_CD_KAISYA = "KASY";
		/// <summary>
		/// ｵﾌﾗｲﾝ伝票No桁数チェック
		/// </summary>
		public const Int16 CHECK_OFFLINE_NO = 20;
		/// <summary>
		/// チェックモード 印刷
		/// </summary>
		public const string CHECK_MODE_BTNPRINT = "0";
		/// <summary>
		/// チェックモード 検索
		/// </summary>
		public const string CHECK_MODE_BTNSEARCH = "1";
		/// <summary>
		/// チェックモード 確定
		/// </summary>
		public const string CHECK_MODE_BTNKAKUTEI = "2";
		/// <summary>
		/// 参照テーブル 移動出荷確定TBL
		/// </summary>
		public const string REF_TBL_KAKU = "1";
		/// <summary>
		/// 参照テーブル 移動出荷履歴TBL
		/// </summary>
		public const string REF_TBL_RIREKI = "2";
		/// <summary>
		/// 削除区分 0:予定HEAD
		/// </summary>
		public const decimal DEL_KBN_YOTEI_HEAD = 0;
		/// <summary>
		/// 削除区分 1:予定BODY
		/// </summary>
		public const decimal DEL_KBN_YOTEI_BODY = 1;
		/// <summary>
		/// 削除区分 2:確定HEAD
		/// </summary>
		public const decimal DEL_KBN_KAKUTEI_HEAD = 2;
		/// <summary>
		/// 削除区分 3:確定BODY
		/// </summary>
		public const decimal DEL_KBN_KAKUTEI_BODY = 3;
		/// <summary>
		/// 登録区分 0:HEAD
		/// </summary>
		public const decimal INS_KBN_HEAD = 0;
		/// <summary>
		/// 登録区分 1:BODY
		/// </summary>
		public const decimal INS_KBN_BODY = 1;
		#endregion
	}
}
