using System;

namespace com.xebio.bo.Ta080p01.Constant
{
  /// <summary>
  /// Ta080p01の定数を定義するクラスです。
  /// </summary>
  public static class Ta080p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string PGID = "Ta080p01";
		#endregion

		#region フォームID
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string FORMID_01 = "Ta080f01";
		/// <summary>
		/// 実績明細画面フォームID
		/// </summary>
		public const string FORMID_02 = "Ta080f02";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FORMID_03 = "Ta080f03";

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
		/// 実績明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_02 = "FCDUO_NEXTVO_02";

		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string FCDUO_NEXTVO_03 = "FCDUO_NEXTVO_03";

		/// <summary>
		/// 印刷PDFファイル名
		/// </summary>
		public const string FCDUO_RRT_FLNM = "FCDUO_RRT_FLNM";

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
		/// 一覧画面_検索処理_件数チェック
		/// </summary>
		public const string SQL_ID_01 = "TA080P01-01";
		/// <summary>
		/// 一覧画面_検索処理
		/// </summary>
		public const string SQL_ID_02 = "TA080P01-02";
		/// <summary>
		/// 一覧画面_リンク処理_モード申請/申請前修正
		/// </summary>
		public const string SQL_ID_03 = "TA080P01-03";
		/// <summary>
		/// 一覧画面_リンク処理_モード申請取消
		/// </summary>
		public const string SQL_ID_04 = "TA080P01-04";
		/// <summary>
		/// 一覧画面_リンク処理_モード登録履歴照会
		/// </summary>
		public const string SQL_ID_05 = "TA080P01-05";
		/// <summary>
		/// 一覧画面_リンク処理_モード稟議結果照会
		/// </summary>
		public const string SQL_ID_06 = "TA080P01-06";
		/// <summary>
		/// 一覧画面_排他処理
		/// </summary>
		public const string SQL_ID_07 = "TA080P01-07";
		/// <summary>
		/// 補充依頼申請TBL更新
		/// </summary>
		public const string SQL_ID_08 = "TA080P01-08";
		/// <summary>
		/// 補充依頼確定TBL登録(申請テーブル参照)
		/// </summary>
		public const string SQL_ID_09 = "TA080P01-09";
		/// <summary>
		/// 補充依頼確定TBL更新(メッセージ区分設定)
		/// </summary>
		public const string SQL_ID_10 = "TA080P01-10";
		/// <summary>
		/// 補充依頼確定TBL削除
		/// </summary>
		public const string SQL_ID_11 = "TA080P01-11";
		/// <summary>
		/// 補充依頼申請TBL削除
		/// </summary>
		public const string SQL_ID_12 = "TA080P01-12";
		/// <summary>
		/// 補充依頼確定TBL登録(各項目指定)
		/// </summary>
		public const string SQL_ID_13 = "TA080P01-13";


		
		#endregion

		#region SQL-REPLACE-ID

		#endregion

		#region	Dictionary カード部
		/// <summary>
		/// フォーム ディクショナリ
		/// 検索実行時のフォームVO
		/// </summary>
		public const string DIC_SEARCH_F01VO = "DIC_SEARCH_F01VO";

		/// <summary>
		/// カード部 ディクショナリ
		/// 検索自社品番
		/// </summary>
		public const string DIC_SEARCH_XEBIOCD = "DIC_SEARCH_XEBIOCD";

		public const string DIC_ATODENAMAEKAERU = "AAAAAAA";

		#endregion

		#region Dictionary 明細部
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１仕入枠グループコード
		/// </summary>
		public const string DIC_M1YOSAN_CD = "DIC_M1YOSAN_CD";
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１仕入枠グループ名
		/// </summary>
		public const string DIC_M1YOSAN_NM = "DIC_M1YOSAN_NM";
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１リンク先件数
		/// </summary>
		public const string DIC_M1LINKED_ITEM_SU = "DIC_M1LINKED_ITEM_SU";
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１リンク先最新更新日時
		/// </summary>
		public const string DIC_M1LINKED_LAST_UPD_DATETIME = "DIC_M1LINKED_LAST_UPD_DATETIME";
		
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１許容金額
		/// </summary>
		public const string DIC_M1KYOYO_KIN = "DIC_M1KYOYO_KIN";

		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１未申請数(PC未送信)
		/// </summary>
		public const string DIC_M1SINSEI_SU_MISOSIN = "DIC_M1SINSEI_SU_MISOSIN";
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１未申請金額(PC未送信)
		/// </summary>
		public const string DIC_M1SINSEI_KIN_MISOSIN = "DIC_M1SINSEI_KIN_MISOSIN";
		/// <summary>
		/// 一覧明細部 ディクショナリ
		/// Ｍ１送信済み未確定金額
		/// </summary>
		public const string DIC_M1SINSEIZUMI_MIKAKUTEI_KIN = "DIC_M1SINSEIZUMI_MIKAKUTEI_KIN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色フラグ_計画期間
		/// </summary>
		public const string DIC_IROFLG_M1_M1KEIKAKU_YMD = "DIC_IROFLG_M1_M1KEIKAKU_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色フラグ_スキャンコード
		/// </summary>
		public const string DIC_IROFLG_M1_M1SCAN_CD = "DIC_IROFLG_M1_M1SCAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色フラグ_依頼数
		/// </summary>
		public const string DIC_IROFLG_M1_M1IRAI_SU = "DIC_IROFLG_M1_M1IRAI_SU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色フラグ_担当者名
		/// </summary>
		public const string DIC_IROFLG_M1_M1HANBAIIN_NM = "DIC_IROFLG_M1_M1HANBAIIN_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色フラグ_販完日
		/// </summary>
		public const string DIC_IROFLG_M1_M1HANBAIKANRYO_YMD = "DIC_IROFLG_M1_M1HANBAIKANRYO_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 代表自社品番振替確認フラグ
		/// </summary>
		public const string DIC_M1DAIHYO_JISYAHB_HK_FLG = "DIC_M1DAIHYO_JISYAHB_HK_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 当初売価
		/// </summary>
		public const string DIC_M1TOSYOBAIKA_TNK = "DIC_M1TOSYOBAIKA_TNK";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録日
		/// </summary>
		public const string DIC_M1ADD_YMD = "DIC_M1ADD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録時間
		/// </summary>
		public const string DIC_M1ADD_TM = "DIC_M1ADD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 登録担当者
		/// </summary>
		public const string DIC_M1ADDTAN_CD = "DIC_M1ADDTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHT登録日
		/// </summary>
		public const string DIC_M1HHTADD_YMD = "DIC_M1HHTADD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHT登録担当者
		/// </summary>
		public const string DIC_M1HHTADDTAN_CD = "DIC_M1HHTADDTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自動定数
		/// </summary>
		public const string DIC_M1JIDO_SU = "DIC_M1JIDO_SU";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 代表自社品番振替時の商品情報
		/// </summary>
		public const string DIC_M1DAIHYOF_SYOHININF = "DIC_M1DAIHYOF_SYOHININF";

		/// <summary>
		/// 明細部 ディクショナリ
		/// 単品エラーリスト
		/// </summary>
		public const string DIC_TANPIN_ERRLIST = "DIC_TANPIN_ERRLIST";
		
		#endregion

		#region	Dictionary 明細部2
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
		/// 行№
		/// </summary>
		public const string DIC_M1GYO_NO = "DIC_M1GYO_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 区分コード
		/// </summary>
		public const string DIC_M1KBN_CD = "DIC_M1KBN_CD";
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
		/// 補充発注対象商品区分
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
		/// 可能数越可能取引フラグ
		/// </summary>
		public const string DIC_M1KANOUSUGOE_FLG = "DIC_M1KANOUSUGOE_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 本宮商品フラグ
		/// </summary>
		public const string DIC_M1MOTOMIYASYOHIN_FLG = "DIC_M1MOTOMIYASYOHIN_FLG";
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
		/// 明細用 ディクショナリ
		/// 単品レポートフラグ（明細単位）
		/// </summary>
		public const string DIC_M1TANPIN_REPORT_FLG = "DIC_M1TANPIN_REPORT_FLG";
		/// <summary>
		/// 明細用 ディクショナリ
		/// 数量修正フラグ（明細単位）
		/// </summary>
		public const string DIC_M1TANPIN_UPD_FLG = "DIC_M1TANPIN_UPD_FLG";
		/// <summary>
		/// 明細用 ディクショナリ
		/// 単品レポートフラグ
		/// </summary>
		public const string DIC_TANPIN_REPORT_FLG = "DIC_TANPIN_REPORT_FLG";
		/// <summary>
		/// 明細用 ディクショナリ
		/// 単品登録モードフラグ
		/// </summary>
		public const string DIC_TANPIN_TOUROKU_MODE_FLG = "DIC_TANPIN_TOUROKU_MODE_FLG";

		#endregion

		#region プログラム固定値
		/// <summary>
		/// 理由コメント 業務区分 「補充:002」
		/// </summary>
		public const string RIYU_GYOMU_HOJYU = "002";
		/// <summary>
		/// 理由コメント 業務区分 「単品:012」
		/// </summary>
		public const string RIYU_GYOMU_TANPIN = "012";
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
		/// 発注メッセージ 本部配分 区分
		/// </summary>
		public const decimal HTMS_HONBU_KB = 1;
		/// <summary>
		/// 発注メッセージ 売上実績なし
		/// </summary>
		public const string HTMS_URI = "売上実績なし";
		/// <summary>
		/// 発注メッセージ 売上実績なし 区分
		/// </summary>
		public const decimal HTMS_URI_KB = 2;
		/// <summary>
		/// 発注メッセージ 入荷予定あり
		/// </summary>
		public const string HTMS_NYU = "入荷予定あり";
		/// <summary>
		/// 発注メッセージ 入荷予定あり 区分
		/// </summary>
		public const decimal HTMS_NYU_KB = 3;
		/// <summary>
		/// 発注メッセージ 販売完了間近
		/// </summary>
		public const string HTMS_HANKAN_MADIKA = "販売完了間近";
		/// <summary>
		/// 発注メッセージ 販売完了間近 区分
		/// </summary>
		public const decimal HTMS_HANKAN_MADIKA_KB = 4;
		/// <summary>
		/// 発注メッセージ 自店舗未展開 
		/// </summary>
		public const string HTMS_JITENPO_MITENKAI = "自店舗未展開";
		/// <summary>
		/// 発注メッセージ 自店舗未展開 区分
		/// </summary>
		public const decimal HTMS_JITENPO_MITENKAI_KB = 5;
		/// <summary>
		/// 発注メッセージ 投入直後
		/// </summary>
		public const string HTMS_TONYUTYOKUGO = "投入直後";
		/// <summary>
		/// 発注メッセージ 投入直後 区分
		/// </summary>
		public const decimal HTMS_TONYUTYOKUGO_KB = 6;
		
		
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

		/// <summary>
		/// 補充依頼申請TBL MDOT0110
		/// </summary>
		public const string TBLID_HOJUIARI_SINSEI = "MDOT0110";
		/// <summary>
		/// 補充依頼確定TBL MDOT0120
		/// </summary>
		public const string TBLID_HOJUIRAI_KAKUTEI = "MDOT0120";
		/// <summary>
		/// 店舗補充実績TBL(H) MDOT0130
		/// </summary>
		public const string TBLID_TENPO_HOJUIRAI_JISSEKI_H = "MDOT0130";
		/// <summary>
		/// 店舗補充実績TBL(B) MDOT0131
		/// </summary>
		public const string TBLID_TENPO_HOJUIRAI_JISSEKI_B = "MDOT0131";
		#endregion

		#region 区分値
		/// <summary>
		/// 補充依頼申請TBL/補充依頼確定TBL
		/// 区分コード_補充依頼 1
		/// </summary>
		public const string KBN_KBN_CD_HOJUIRAI = "1";
		/// <summary>
		/// 補充依頼申請TBL/補充依頼確定TBL
		/// 区分コード_単品レポート 2
		/// </summary>
		public const string KBN_KBN_CD_TANPINREPORT = "2";
		/// <summary>
		/// SQL_SORT_昇順
		/// </summary>
		public const string KBN_SORTOPTION1 = " ASC";
		/// <summary>
		/// SQL_SORT_降順
		/// </summary>
		public const string KBN_SORTOPTION2 = " DESC";
		/// <summary>
		/// SORT_1:商品順 =
		///		部門コード、品種コード、ブランドコード、自社品番、色コード、サイズコード
		/// </summary>
		public const String KBN_SORT_1 = "BUMON_CD,HINSYU_CD,BURANDO_CD,JISYA_HBN,IRO_CD,SIZE_CD";
		/// <summary>
		/// SORT_2	店舗評価 ※A、B、C、-、NULLの順で並べる
		/// </summary>
		public const string KBN_SORT_2 = "TEN_HYOKA_KB_SORT";
		/// <summary>
		/// SORT_3	全体評価 ※A、B、C、-、NULLの順で並べる
		/// </summary>
		public const string KBN_SORT_3 = "ALL_HYOKA_KB_SORT";
		/// <summary>
		/// SORT_4	当週売上
		/// </summary>
		public const string KBN_SORT_4 = "TOSYU_URIAGE_SU";
		/// <summary>
		/// SORT_5	前週売上
		/// </summary>
		public const string KBN_SORT_5 = "ZENSYU_URIAGE_SU";
		/// <summary>
		/// SORT_6	前々週売上
		/// </summary>
		public const string KBN_SORT_6 = "ZENZENSYU_URIAGE_SU";
		/// <summary>
		/// SORT_7	入荷
		/// </summary>
		public const string KBN_SORT_7 = "NYUKAYOTEI_SU";
		/// <summary>
		/// SORT_8	在庫
		/// </summary>
		public const string KBN_SORT_8 = "TENZAIKO_SU";
		/// <summary>
		/// SORT_9	自動定数
		/// </summary>
		public const string KBN_SORT_9 = "JIDO_SU";
		/// <summary>
		/// SORT_10	配可数
		/// </summary>
		public const string KBN_SORT_10 = "HAIBUNKANO_SU";
		/// <summary>
		/// SORT_11	依頼数
		/// </summary>
		public const string KBN_SORT_11 = "IRAI_SU";
		/// <summary>
		/// SORT_12	原価金額
		/// </summary>
		public const string KBN_SORT_12 = "IRAI_KIN";
		/// <summary>
		/// SORT_13	担当者
		/// </summary>
		public const string KBN_SORT_13 = "ADDTAN_CD";
		/// <summary>
		/// SORT_14	登録日
		/// </summary>
		public const string KBN_SORT_14 = "ADD_YMD";
		/// <summary>
		/// SORT_15	依頼理由
		/// </summary>
		public const string KBN_SORT_15 = "IRAIRIYU_CD";
		/// <summary>
		/// 評価区分_ハイフン
		/// </summary>
		public const string KBN_HYOKA_HYPHEN = "-";
		/// <summary>
		/// 評価区分_A
		/// </summary>
		public const string KBN_HYOKA_A = "A";
		/// <summary>
		/// 評価区分_B
		/// </summary>
		public const string KBN_HYOKA_B = "B";
		/// <summary>
		/// 評価区分_C
		/// </summary>
		public const string KBN_HYOKA_C = "C";
		#endregion

	}
}
