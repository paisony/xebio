namespace com.xebio.bo.Tf021p01.Constant
{
  /// <summary>
  /// Tf021p01の定数を定義するクラスです。
  /// </summary>
  public static class Tf021p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tf021p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tf021f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tf021f02";

		#endregion

		#region Facade用UserObject

		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string FCDUO_FOCUSITEM = "FCDUO_FOCUSITEM";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string FCDUO_FOCUSROW = "FCDUO_FOCUSROW";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO = "FCDUO_NEXTVO";

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

		#endregion

		#region SESSION_KEY

		/// <summary>
		/// ダウンロード情報
		/// </summary>
		public const string SESSION_KEY_DOWNLOAD_INFO = "SESSION_KEY_DOWNLOAD_INFO";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 経費振替申請一覧件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TF021P01-01";

		/// <summary>
		/// 経費振替申請一覧 (予定、申請、確定) 件数チェック
		/// </summary>
		public const string SQL_ID_02 = "TF021P01-02";

		/// <summary>
		/// 経費振替申請一覧 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_03 = "TF021P01-03";

		/// <summary>
		/// 経費振替申請一覧 検索(申請テーブル)
		/// </summary>
		public const string SQL_ID_04 = "TF021P01-04";

		/// <summary>
		/// 経費振替申請一覧 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_05 = "TF021P01-05";

		/// <summary>
		/// 経費振替申請一覧 検索(予定、申請、確定テーブル)
		/// </summary>
		public const string SQL_ID_06 = "TF021P01-06";

		/// <summary>
		/// 経費振替確定明細 検索(予定テーブル)
		/// </summary>
		public const string SQL_ID_07 = "TF021P01-07";

		/// <summary>
		/// 経費振替確定明細 検索(申請テーブル)
		/// </summary>
		public const string SQL_ID_08 = "TF021P01-08";

		/// <summary>
		/// 経費振替確定明細 検索(確定テーブル)
		/// </summary>
		public const string SQL_ID_09 = "TF021P01-09";

		/// <summary>
		/// 経費振替予定TBL(H) 更新（「申請」「申請後取消」モード）
		/// </summary>
		public const string SQL_ID_10 = "TF021P01-10";

		/// <summary>
		/// 経費振替申請TBL(H) 登録（「申請」モード）
		/// </summary>
		public const string SQL_ID_11 = "TF021P01-11";

		/// <summary>
		/// 経費振替申請TBL(B) 登録（「申請」モード）
		/// </summary>
		public const string SQL_ID_12 = "TF021P01-12";

		/// <summary>
		/// 経費振替確定TBL(H) 登録（「申請」モード）
		/// </summary>
		public const string SQL_ID_13 = "TF021P01-13";

		/// <summary>
		/// 経費振替確定TBL(B) 登録（「申請」モード）
		/// </summary>
		public const string SQL_ID_14 = "TF021P01-14";

		/// <summary>
		/// 経費振替予定TBL(H) 削除（「申請前取消」モード）
		/// </summary>
		public const string SQL_ID_15 = "TF021P01-15";

		/// <summary>
		/// 経費振替予定TBL(B) 削除（「申請前取消」モード）
		/// </summary>
		public const string SQL_ID_16 = "TF021P01-16";

		/// <summary>
		/// 経費振替申請TBL(H) 削除（「申請後取消」モード）
		/// </summary>
		public const string SQL_ID_17 = "TF021P01-17";

		/// <summary>
		/// 経費振替申請TBL(B) 削除（「申請後取消」モード）
		/// </summary>
		public const string SQL_ID_18 = "TF021P01-18";

		/// <summary>
		/// 経費振替予定一時TBL(B) 登録（「新規登録」モード）
		/// </summary>
		public const string SQL_ID_19 = "TF021P01-19";

		/// <summary>
		/// 経費振替予定TBL(B) 削除（「申請前修正」モード）
		/// </summary>
		public const string SQL_ID_20 = "TF021P01-20";

		/// <summary>
		/// 経費振替予定TBL(B) 登録（「申請前修正」モード）
		/// </summary>
		public const string SQL_ID_21 = "TF021P01-21";

		/// <summary>
		/// 経費振替予定TBL(B) 更新（「申請前修正」モード）
		/// </summary>
		public const string SQL_ID_22 = "TF021P01-22";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID1 = "TABLE_ID1";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID2 = "TABLE_ID2";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 テーブルID
		/// </summary>
		public const string SQL_ID_01_REP_TABLE_ID3 = "TABLE_ID3";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 検索条件1
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE1 = "ADD_WHERE1";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 検索条件2
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE2 = "ADD_WHERE2";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 検索条件2
		/// </summary>
		public const string SQL_ID_01_REP_ADD_WHERE3 = "ADD_WHERE3";

		/// <summary>
		/// 経費振替申請一覧 件数チェック／検索
		/// 置き換え変数 表示順序
		/// </summary>
		public const string SQL_ID_01_REP_ADD_ORDER1 = "ADD_ORDER1";

		/// <summary>
		/// 経費振替確定明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string SQL_ID_08_REP_TENPO_CD = "BIND_TENPO_CD";

		/// <summary>
		/// 仕入入荷検索明細 検索 
		/// 置き換え変数 処理日
		/// </summary>
		public const string SQL_ID_08_REP_SYORI_YMD = "BIND_SYORI_YMD";

		/// <summary>
		/// 経費振替確定明細 検索 
		/// 置き換え変数 管理No
		/// </summary>
		public const string SQL_ID_08_REP_KANRI_NO = "BIND_KANRI_NO";

		/// <summary>
		/// 経費振替確定明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string SQL_ID_08_REP_DENPYO_BANGO = "BIND_DENPYO_BANGO";

		#endregion

		#region TABLE-ID

		/// <summary>
		/// 経費振替予定(H)テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDAT0100 = "MDAT0100";

		/// <summary>
		/// 経費振替予定(B)テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDAT0101 = "MDAT0101";

		/// <summary>
		/// 経費振替申請(H)テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDAT0020 = "MDAT0020";

		/// <summary>
		/// 経費振替確定(H)テーブル  テーブルID
		/// </summary>
		public const string TABLE_ID_MDAT0030 = "MDAT0030";

		#endregion

		#region Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 伝票番号
		/// </summary>
		public const string DIC_M1DENPYO_BANGO = "DIC_M1DENPYO_BANGO";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 管理No
		/// </summary>
		public const string DIC_M1KANRI_NO = "DIC_M1KANRI_NO";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１テーブル区分
		/// </summary>
		public const string DIC_M1TBLFLG = "DIC_M1TBLFLG";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１処理日付
		/// </summary>
		public const string DIC_M1SYORI_YMD = "DIC_M1SYORI_YMD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１処理時間
		/// </summary>
		public const string DIC_M1SYORI_TM = "DIC_M1SYORI_TM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１更新日
		/// </summary>
		public const string DIC_M1UPD_YMD = "DIC_M1UPD_YMD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１更新時間
		/// </summary>
		public const string DIC_M1UPD_TM = "DIC_M1UPD_TM";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１申請理由区分
		/// </summary>
		public const string DIC_M1SINSEIRIYU_KB = "DIC_M1SINSEIRIYU_KB";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１申請理由
		/// </summary>
		public const string DIC_M1SINSEIRIYU = "DIC_M1SINSEIRIYU";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１承認状態名称
		/// </summary>
		public const string DIC_M1SYONINSTATUS = "DIC_M1SYONINSTATUS";

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
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１最大売価単価
		/// </summary>
		public const string DIC_M1MAX_BAIKA_TNK = "DIC_M1MAX_BAIKA_TNK";

		/// <summary>
		/// 明細部 ディクショナリ
		/// Ｍ１明細画面確定フラグ
		/// </summary>
		public const string DIC_M1F02ENTERSYORI_FLG = "DIC_M1F02ENTERSYORI_FLG";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行のM1VO
		/// </summary>
		public const string DIC_M1SELECTVO = "DIC_M1SELECTVO";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行
		/// </summary>
		public const string DIC_M1SELECTROWIDX = "DIC_M1SELECTROWIDX";

		/// <summary>
		/// CSV取込 ディクショナリ
		/// CSV取込結果
		/// </summary>
		public const string DIC_CSV_IMPORT_RESULT = "DIC_CSV_IMPORT_RESULT";

		/// <summary>
		/// CSV取込 ディクショナリ
		/// CSV取込結果チェック
		/// </summary>
		public const string DIC_CSV_CHECK_INFO = "DIC_CSV_CHECK_INFO";
		/// <summary>
		/// フォーカスINDEX
		/// </summary>
		public const string DIC_FOCUS_INDEX = "DIC_FOCUS_INDEX";

		#endregion

		#region ユーザー定義

		/// <summary>
		/// 申請理由区分 （グループ間取引)
		/// </summary>
		public const string SINSEI_KB_GROUP = "7";

		/// <summary>
		/// 経費振替伝票番号採番最大値
		/// </summary>
		public const int KEIHIHURI_DENPYO_BANGO_MAX = 999999;

		#endregion

	}
}
