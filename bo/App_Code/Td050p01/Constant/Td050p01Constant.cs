using System;

namespace com.xebio.bo.Td050p01.Constant
{
  ///	<summary>
  ///	Td050p01の定数を定義するクラスです。
  ///	</summary>
  public static class	Td050p01Constant
	{
		#region プログラムID
		/// <summary>
		/// プログラムID
		/// </summary>
		public const string	PGID = "Td050p01";
		#endregion

		#region	フォームID

		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string	FORMID_01 =	"Td050f01";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string	FORMID_02 =	"Td050f02";

		#endregion

		#region	Facade用UserObject
		/// <summary>
		/// 一覧画面フォームID
		/// </summary>
		public const string	FCDUO_F01VO	= "FCDUO_F01VO";
		/// <summary>
		/// 一覧画面 明細フォームID(M1)
		/// </summary>
		public const string	FCDUO_F01M1VO =	"FCDUO_F01M1VO";
		/// <summary>
		/// 明細画面フォームID
		/// </summary>
		public const string	FCDUO_NEXTVO = "FCDUO_NEXTVO";
		/// <summary>
		/// 明細画面フォーカス情報 項目
		/// </summary>
		public const string	FCDUO_FOCUSITEM	= "FCDUO_FOCUSITEM";
		/// <summary>
		/// 明細画面フォーカス情報 行数
		/// </summary>
		public const string	FCDUO_FOCUSROW = "FCDUO_FOCUSROW";
		/// <summary>
		/// 明細画面 帳票ファイル名
		/// </summary>
		public const string FCDUO_PRT_FLNM = "FCDUO_PRT_FLNM";


		#endregion


		#region	SQL-ID

		/// <summary>
		/// 返品伝票訂正一覧 件数チェック
		/// </summary>
		public const string	SQL_ID_01 =	"TD050P01-01";
		/// <summary>
		/// 返品伝票訂正一覧 検索
		/// </summary>
		public const string	SQL_ID_02 =	"TD050P01-02";
		/// <summary>
		/// 返品伝票訂正明細 検索
		/// </summary>
		public const string	SQL_ID_03 =	"TD050P01-03";
		/// <summary>
		/// 返品確定履歴TBL(H) 登録
		/// </summary>
		public const string	SQL_ID_04 =	"TD050P01-04";
		/// <summary>
		/// 返品確定履歴TBL(B) 登録
		/// </summary>
		public const string	SQL_ID_05 =	"TD050P01-05";
		/// <summary>
		/// 返品確定TBL(B) 削除（元伝票）
		/// </summary>
		public const string	SQL_ID_06 =	"TD050P01-06";
		/// <summary>
		/// 返品確定TBL(H) 削除（元伝票）
		/// </summary>
		public const string	SQL_ID_07 =	"TD050P01-07";
		/// <summary>
		/// 返品確定TBL(H) 更新（新黒区分）
		/// </summary>
		public const string	SQL_ID_08 =	"TD050P01-08";
		/// <summary>
		/// 返品指示存在チェック
		/// </summary>
		public const string	SQL_ID_09 =	"TD050P01-09";
		/// <summary>
		/// [返品確定TBL(B)]を検索し、[返品確定TBL(B)]を登録
		/// </summary>
		public const string	SQL_ID_10 =	"TD050P01-10";
		/// <summary>
		/// [返品確定TBL(H)]を検索して[返品確定TBL(H) 登録
		/// </summary>
		public const string	SQL_ID_11 =	"TD050P01-11";
		/// <summary>
		/// 返品確定TBL(H) 登録
		/// </summary>
		public const string	SQL_ID_12 =	"TD050P01-12";
		/// <summary>
		/// 返品確定TBL(B) 登録
		/// </summary>
		public const string	SQL_ID_13 =	"TD050P01-13";
		#endregion
		#region	SQL-REPLACE-ID

		/// <summary>
		/// 返品確定一覧 件数チェック／検索
		/// 置き換え変数 検索条件
		/// </summary>
		public const string	SQL_ID_01_REP_ADD_WHERE	= "ADD_WHERE";
		/// <summary>
		/// 返品伝票訂正明細 検索 
		/// 置き換え変数 伝票番号
		/// </summary>
		public const string	SQL_ID_03_REP_DENPYO_BANGO = "DENPYO_BANGO";
		/// <summary>
		/// 返品伝票訂正明細 検索 
		/// 置き換え変数 処理日付
		/// </summary>
		public const string	SQL_ID_03_REP_SYORI_YMD	= "SYORI_YMD";
		/// <summary>
		/// 返品伝票訂正明細 検索 
		/// 置き換え変数 店舗コード
		/// </summary>
		public const string	SQL_ID_03_REP_TENPO_CD = "TENPO_CD";

		#endregion


		#region	Dictionary カード部

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

		#region	Dictionary 明細部

		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新日
		/// </summary>
		public const string	DIC_M1UPD_YMD =	"DIC_M1UPD_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 更新時間
		/// </summary>
		public const string	DIC_M1UPD_TM = "DIC_M1UPD_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 元伝票番号
		/// </summary>
		public const string	DIC_M1MOTODENPYO_BANGO = "DIC_M1MOTODENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 黒伝票番号
		/// </summary>
		public const string DIC_M1KURODENPYO_BANGO = "DIC_M1KURODENPYO_BANGO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理日付
		/// </summary>
		public const string	DIC_M1SYORI_YMD	= "DIC_M1SYORI_YMD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 処理時間
		/// </summary>
		public const string	DIC_M1SYORI_TM = "DIC_M1SYORI_TM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 管理№
		/// </summary>
		public const string	DIC_M1KANRI_NO = "DIC_M1KANRI_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定種別
		/// </summary>
		public const string	DIC_M1KAKUTEI_SB = "DIC_M1KAKUTEI_SB";
		/// <summary>
		/// 明細部 ディクショナリ
		/// ブランドコード
		/// </summary>
		public const string	DIC_M1BURANDO_CD = "DIC_M1BURANDO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サブ仕入先コード
		/// </summary>
		public const string	DIC_M1SUBSIIRESAKI_CD =	"DIC_M1SUBSIIRESAKI_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 返品予定合計数量
		/// </summary>
		public const string	DIC_M1HENPINYOTEIGOKEI_SU =	"DIC_M1HENPINYOTEIGOKEI_SU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 返品予定合計金額
		/// </summary>
		public const string	DIC_M1HENPINYOTEIGOUKEI_KIN	= "DIC_M1HENPINYOTEIGOUKEI_KIN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 返品理由
		/// </summary>
		public const string	DIC_M1HENPIN_RIYU =	"DIC_M1HENPIN_RIYU";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 担当者コード
		/// </summary>
		public const string	DIC_M1TANTOSYA_CD =	"DIC_M1TANTOSYA_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 入力担当者コード
		/// </summary>
		public const string	DIC_M1HHTADDTAN_CD = "DIC_M1HHTADDTAN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 確定担当者コード
		/// </summary>
		public const string	DIC_M1UPD_TANCD	= "DIC_M1UPD_TANCD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 送信済フラグ
		/// </summary>
		public const string	DIC_M1SOSINZUMI_FLG	= "DIC_M1SOSINZUMI_FLG";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシリアル番号
		/// </summary>
		public const string	DIC_M1HHTSERIAL_NO = "DIC_M1HHTSERIAL_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// HHTシーケンスNo.
		/// </summary>
		public const string	DIC_M1HHTSEQUENCE_NO = "DIC_M1HHTSEQUENCE_NO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 部門名
		/// </summary>
		public const string	DIC_M1BUMON_NM = "DIC_M1BUMON_NM";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 備考
		/// </summary>
		public const string	DIC_M1BIKO = "DIC_M1BIKO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 店舗コード
		/// </summary>
		public const string	DIC_M1TENPO_CD = "DIC_M1TENPO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 品種コード
		/// </summary>
		public const string	DIC_M1HINSYU_CD	= "DIC_M1HINSYU_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 色コード
		/// </summary>
		public const string	DIC_M1IRO_CD = "DIC_M1IRO_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// サイズコード
		/// </summary>
		public const string	DIC_M1SIZE_CD =	"DIC_M1SIZE_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 商品コード
		/// </summary>
		public const string	DIC_M1SYOHIN_CD	= "DIC_M1SYOHIN_CD";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 自社品番
		/// </summary>
		public const string	DIC_M1JISYA_HBN	= "DIC_M1JISYA_HBN";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行のM1VO
		/// </summary>
		public const string	DIC_M1SELCETVO = "DIC_M1SELCETVO";
		/// <summary>
		/// 明細部 ディクショナリ
		/// 選択行
		/// </summary>
		public const string	DIC_M1SELCETROWIDX = "DIC_M1SELCETROWIDX";

		#endregion
		/// <summary>
		/// 返品確定日FROM初期値
		/// </summary>
		public const String HENPIN_KAKUTEI_YMD_INIT = "01";
		/// <summary>
		/// フラグOFF
		/// </summary>
		public const decimal FLG_OFF = 0;
		/// <summary>
		/// フラグON
		/// </summary>
		public const decimal FLG_ON	= 1;
		/// <summary>
		/// 処理種別 （訂正）
		/// </summary>
		public const decimal SYORI_SB_TEISEI = 3;
		/// <summary>
		/// 処理種別 （訂正修正）
		/// </summary>
		public const decimal SYORI_SB_TEISEI_UPD = 4;
		/// <summary>
		/// 処理種別 （訂正取消）
		/// </summary>
		public const decimal SYORI_SB_TEISEI_DEL = 5;

		/// <summary>
		/// 返品番号採番最大値
		/// </summary>
		public const int HENPIN_DENPYO_BANGO_MAX = 999999;
	}
}
