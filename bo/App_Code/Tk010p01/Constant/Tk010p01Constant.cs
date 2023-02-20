namespace com.xebio.bo.Tk010p01.Constant
{
  /// <summary>
  /// Tk010p01の定数を定義するクラスです。
  /// </summary>
  public static class Tk010p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Tk010p01";
		#endregion

		#region フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Tk010f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Tk010f02";

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
		/// <summary>
		/// 印刷PDFファイル名2
		/// </summary>
		public const string FCDUO_RRT_FLNM_2 = "FCDUO_RRT_FLNM_2";
		/// <summary>
		/// 出力CSVファイル名
		/// </summary>
		public const string FCDUO_CSV_FLNM = "FCDUO_CSV_FLNM";

		#endregion

		#region SQL-ID

		/// <summary>
		/// 評価損確定-一覧 件数チェック(確定モード)
		/// </summary>
		public const string SQL_ID_01 = "TK010P01-01";

		/// <summary>
		/// 評価損確定-一覧 件数チェック(修正モード)
		/// </summary>
		public const string SQL_ID_02 = "TK010P01-02";

		/// <summary>
		/// 評価損確定-一覧 件数チェック(照会モード)
		/// </summary>
		public const string SQL_ID_03 = "TK010P01-03";

		/// <summary>
		/// 評価損確定-一覧 検索(確定モード)
		/// </summary>
		public const string SQL_ID_04 = "TK010P01-04";

		/// <summary>
		/// 評価損確定-一覧 検索(修正モード)
		/// </summary>
		public const string SQL_ID_05 = "TK010P01-05";

		/// <summary>
		/// 評価損確定-一覧 検索(照会モード)
		/// </summary>
		public const string SQL_ID_06 = "TK010P01-06";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク(申請テーブル参照)
		/// </summary>
		public const string SQL_ID_07 = "TK010P01-07";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク(確定テーブル参照)
		/// </summary>
		public const string SQL_ID_08 = "TK010P01-08";

		/// <summary>
		/// 評価損確定-一覧 確定 [評価損確定TBL]を登録
		/// </summary>
		public const string SQL_ID_09 = "TK010P01-09";

		/// <summary>
		/// 評価損確定-一覧 確定 [評価損申請TBL]を更新
		/// </summary>
		public const string SQL_ID_10 = "TK010P01-10";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損申請TBL]を更新
		/// </summary>
		public const string SQL_ID_11 = "TK010P01-11";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損確定TBL]を登録
		/// </summary>
		public const string SQL_ID_12 = "TK010P01-12";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損申請履歴TBL]登録
		/// </summary>
		public const string SQL_ID_13 = "TK010P01-13";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損申請TBL]更新(保留)
		/// </summary>
		public const string SQL_ID_14 = "TK010P01-14";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損確定TBL]更新
		/// </summary>
		public const string SQL_ID_15 = "TK010P01-15";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損申請TBL]を更新(修正時保留)
		/// </summary>
		public const string SQL_ID_16 = "TK010P01-16";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損確定TBL]を削除 
		/// </summary>
		public const string SQL_ID_17 = "TK010P01-17";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損申請TBL]更新日付最新化
		/// </summary>
		public const string SQL_ID_18 = "TK010P01-18";

		/// <summary>
		/// 評価損確定-明細 確定 [評価損確定TBL]更新日付最新化
		/// </summary>
		public const string SQL_ID_19 = "TK010P01-19";

		#endregion

		#region SQL-REPLACE-ID

		/// <summary>
		/// 評価損確定-一覧 件数チェック/検索
		/// 置き換え条件1
		/// </summary>
		public const string SQL_REP_ADD_WHERE_1 = "REP_ADD_WHERE_1";

		/// <summary>
		/// 評価損確定-一覧 件数チェック/検索
		/// 置き換え条件2
		/// </summary>
		public const string SQL_REP_ADD_WHERE_2 = "REP_ADD_WHERE_2";

		#endregion

		#region SQL-BIND-ID

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 店舗コード
		/// </summary>
		public const string BIND_TENPO_CD = "BIND_TENPO_CD";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 申請日
		/// </summary>
		public const string BIND_APPLY_YMD = "BIND_APPLY_YMD";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 処理日付
		/// </summary>
		public const string BIND_SYORI_YMD = "BIND_SYORI_YMD";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 再申請フラグ
		/// </summary>
		public const string BIND_SAISHINSEI_FLG = "BIND_SAISHINSEI_FLG";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 評価損種別1
		/// </summary>
		public const string BIND1_HYOKASONSYUBETSU = "BIND1_HYOKASONSYUBETSU";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 評価損種別2
		/// </summary>
		public const string BIND2_HYOKASONSYUBETSU = "BIND2_HYOKASONSYUBETSU";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 承認フラグ (確定テーブルのみ使用)
		/// </summary>
		public const string BIND_SYONIN_FLG = "BIND_SYONIN_FLG";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 修正モードフラグ1 (確定テーブルのみ使用)
		/// </summary>
		public const string BIND1_UPD_FLG = "BIND1_UPD_FLG";

		/// <summary>
		/// 評価損確定-一覧 店舗リンク
		/// 修正モードフラグ2 (確定テーブルのみ使用)
		/// </summary>
		public const string BIND2_UPD_FLG = "BIND2_UPD_FLG";

		/// <summary>
		/// 評価損確定 更新処理
		/// 登録日
		/// </summary>
		public const string BIND_ADD_YMD = "BIND_ADD_YMD";

		/// <summary>
		/// 評価損確定 更新処理
		/// 登録時間
		/// </summary>
		public const string BIND_ADD_TM = "BIND_ADD_TM";

		/// <summary>
		/// 評価損確定 更新処理
		/// 登録担当者コード
		/// </summary>
		public const string BIND_ADD_TANCD = "BIND_ADD_TANCD";

		/// <summary>
		/// 評価損確定 更新処理
		/// 更新日
		/// </summary>
		public const string BIND_UPD_YMD = "BIND_UPD_YMD";

		/// <summary>
		/// 評価損確定 更新処理
		/// 更新時間
		/// </summary>
		public const string BIND_UPD_TM = "BIND_UPD_TM";

		/// <summary>
		/// 評価損確定 更新処理
		/// 更新担当者コード
		/// </summary>
		public const string BIND_UPD_TANCD = "BIND_UPD_TANCD";

		/// <summary>
		/// 評価損確定 更新処理
		/// 削除日
		/// </summary>
		public const string BIND_DEL_YMD = "BIND_DEL_YMD";

		/// <summary>
		/// 評価損確定-一覧 更新処理
		/// 申請日1
		/// </summary>
		public const string BIND1_APPLY_YMD = "BIND1_APPLY_YMD";

		/// <summary>
		/// 評価損確定-一覧 更新処理
		/// 申請日2
		/// </summary>
		public const string BIND2_APPLY_YMD = "BIND2_APPLY_YMD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 管理No
		/// </summary>
		public const string BIND_KANRI_NO = "BIND_KANRI_NO";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 行No
		/// </summary>
		public const string BIND_GYO_NBR = "BIND_GYO_NBR";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 処理時間BIND_BUMON_CD
		/// </summary>
		public const string BIND_SYORI_TM = "BIND_SYORI_TM";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 部門コード
		/// </summary>
		public const string BIND_BUMON_CD = "BIND_BUMON_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 品種コード
		/// </summary>
		public const string BIND_HINSYU_CD = "BIND_HINSYU_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// ブランドコード
		/// </summary>
		public const string BIND_BURANDO_CD = "BIND_BURANDO_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// メーカー品番
		/// </summary>
		public const string BIND_MAKER_HBN = "BIND_MAKER_HBN";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 商品名(カナ)
		/// </summary>
		public const string BIND_SYONMK = "BIND_SYONMK";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 自社品番
		/// </summary>
		public const string BIND_JISYA_HBN = "BIND_JISYA_HBN";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// JANコード
		/// </summary>
		public const string BIND_JAN_CD = "BIND_JAN_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 商品コード
		/// </summary>
		public const string BIND_SYOHIN_CD = "BIND_SYOHIN_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 評価損数量 
		/// </summary>
		public const string BIND_HYOKASON_SU = "BIND_HYOKASON_SU";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 販売完了日
		/// </summary>
		public const string BIND_HANBAIKANRYO_YMD = "BIND_HANBAIKANRYO_YMD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 色コード
		/// </summary>
		public const string BIND_IRO_CD = "BIND_IRO_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// サイズコード
		/// </summary>
		public const string BIND_SIZE_CD = "BIND_SIZE_CD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// サイズ名
		/// </summary>
		public const string BIND_SIZE_NM = "BIND_SIZE_NM";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 原単価
		/// </summary>
		public const string BIND_GEN_TNK = "BIND_GEN_TNK";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 上代1
		/// </summary>
		public const string BIND_JODAI1_TNK = "BIND_JODAI1_TNK";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 評価損種別区分
		/// </summary>
		public const string BIND_HYOKASONSYUBETSU_KB = "BIND_HYOKASONSYUBETSU_KB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 評価損理由区分
		/// </summary>
		public const string BIND_HYOKASONRIYU_KB = "BIND_HYOKASONRIYU_KB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 評価損理由
		/// </summary>
		public const string BIND_HYOKASONRIYU = "BIND_HYOKASONRIYU";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 却下理由区分
		/// </summary>
		public const string BIND_KYAKKARIYU_KB = "BIND_KYAKKARIYU_KB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 却下理由
		/// </summary>
		public const string BIND_KYAKKARIYU = "BIND_KYAKKARIYU";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 調達区分
		/// </summary>
		public const string BIND_TYOTATSU_KB = "BIND_TYOTATSU_KB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 赤黒区分
		/// </summary>
		public const string BIND_AKAKURO_KBN = "BIND_AKAKURO_KBN";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 履歴処理日付
		/// </summary>
		public const string BIND_RIREKI_SYORI_YMD = "BIND_RIREKI_SYORI_YMD";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 履歴処理時間
		/// </summary>
		public const string BIND_RIREKI_SYORI_TM = "BIND_RIREKI_SYORI_TM";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 処理種別　0:黒伝 1:赤伝
		/// </summary>
		public const string BIND_SYORI_SB = "BIND_SYORI_SB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 履歴画面表示区分
		/// </summary>
		public const string BIND_RIREKI_DISP_KB = "BIND_RIREKI_DISP_KB";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 送信依頼フラグ
		/// </summary>
		public const string BIND_SOSINIRAI_FLG = "BIND_SOSINIRAI_FLG";

		/// <summary>
		/// 評価損確定-明細 更新処理
		/// 履歴No種別
		/// </summary>
		public const string BIND_RIREKI_SB = "BIND_RIREKI_SB";


		#endregion

		#region 明細部 ディクショナリ

		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string DIC_M1TENPO_CD = "DIC_M1TENPO_CD";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗名
		/// </summary>
		public const string DIC_M1TENPO_NM = "DIC_M1TENPO_NM";
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
		/// 決裁状態区分
		/// </summary>
		public const string DIC_M1KESSAI_FLG = "DIC_M1KESSAI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 承認状態区分
		/// </summary>
		public const string DIC_M1SYONIN_FLG = "DIC_M1SYONIN_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 再申請フラグ
		/// </summary>
		public const string DIC_M1SAISHINSEI_FLG = "DIC_M1SAISHINSEI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 明細リンク使用不可フラグ 0:使用可 1:使用不可
		/// </summary>
		public const string DIC_M1LINKFLG = "DIC_M1LINKFLG";


		#endregion

		#region 明細画面 カード部 ディクショナリ

		/// <summary>
		/// 選択行のM1VO
		/// </summary>
		public const string DIC_M1SELCETVO = "DIC_M1SELCETVO";

		/// <summary>
		/// 選択行に対する承認状態の行
		/// </summary>
		public const string DIC_M1SELCETVO2 = "DIC_M1SELCETVO2";

		/// <summary>
		/// 選択行
		/// </summary>
		public const string DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";

		/// <summary>
		/// 一覧画面カード部Vo
		/// </summary>
		public const string DIC_F1VO = "DIC_F1VO";

		/// <summary>
		/// 定数 ディクショナリ
		/// システム日付
		/// </summary>
		public const string DIC_SYSDATE = "DIC_SYSDATE";

		#endregion

		#region 明細画面 明細部 ディクショナリ

		/// <summary>
		/// 管理No
		/// </summary>
		public const string DIC_M1KANRI_NO = "DIC_M1KANRI_NO";

		/// <summary>
		/// 処理日付
		/// </summary>
		public const string DIC_M1SYORI_YMD = "DIC_M1SYORI_YMD";

		/// <summary>
		/// 処理時間
		/// </summary>
		public const string DIC_M1SYORI_TM = "DIC_M1SYORI_TM";

		/// <summary>
		/// ブランドコード
		/// </summary>
		public const string DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";

		/// <summary>
		/// サイズコード
		/// </summary>
		public const string DIC_M1SIZE_CD = "DIC_M1SIZE_CD";

		/// <summary>
		/// 色コード
		/// </summary>
		public const string DIC_M1IRO_CD = "DIC_M1IRO_CD";

		/// <summary>
		/// 商品コード
		/// </summary>
		public const string DIC_M1SYOHIN_CD = "DIC_M1SYOHIN_CD";

		/// <summary>
		/// 調達区分
		/// </summary>
		public const string DIC_M1TYOTATSU_KB = "DIC_M1TYOTATSU_KB";

		/// <summary>
		/// 行No
		/// </summary>
		public const string DIC_M1GYO_NBR = "DIC_M1GYO_NBR";

		/// <summary>
		/// 販売完了日(yyyymmdd)
		/// </summary>
		public const string DIC_M1HANBAIKANRYO_YMD = "DIC_M1HANBAIKANRYO_YMD";

		/// <summary>
		/// 更新状態 1:確定 2:保留
		/// </summary>
		public const string DIC_M1UPD_JOTAI = "DIC_M1UPD_JOTAI";

		/// <summary>
		/// 元数量
		/// </summary>
		public const string DIC_M1SURYO_MOTO = "DIC_M1SURYO_MOTO";

		/// <summary>
		/// 元原価金額
		/// </summary>
		public const string DIC_M1GENKA_KIN_MOTO = "DIC_M1GENKA_KIN_MOTO";

		/// <summary>
		/// 元調達区分
		/// </summary>
		public const string DIC_M1TYOTATSU_KB_MOTO = "DIC_M1TYOTATSU_KB_MOTO";

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
		/// 名称マスタ 識別コード 却下理由
		/// </summary>
		public const string MEISHO_SIKIBETSU_CD_KYAKKARIYU = "HKKR";
		/// <summary>
		/// 評価損申請TBL テーブルID
		/// </summary>
		public const string TABLE_MDIT0060 = "MDIT0060";
		/// <summary>
		/// 評価損確定TBL テーブルID
		/// </summary>
		public const string TABLE_MDIT0070 = "MDIT0070";
		/// <summary>
		/// 更新状態 確定
		/// </summary>
		public const string UPD_JOTAI_KAKUTEI = "1";
		/// <summary>
		/// 更新状態 保留
		/// </summary>
		public const string UPD_JOTAI_HORYU = "2";
		/// <summary>
		/// 明細リンクフラグ 使用可能
		/// </summary>
		public const string MEISAI_LINK_KANO_FLG = "0";
		/// <summary>
		/// 明細リンクフラグ 使用不可
		/// </summary>
		public const string MEISAI_LINK_FUKA_FLG = "1";
		/// <summary>
		/// 一覧明細行更新日更新フラグ(選択した行に対する行用)
		/// </summary>
		public const string MEISAI_DATE_UPD_FLG = "MEISAI_DATE_UPD_FLG";

		#endregion
	}
}
