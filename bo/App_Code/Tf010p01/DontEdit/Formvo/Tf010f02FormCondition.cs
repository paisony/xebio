using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tf010p01.Formvo
{
  /// <summary>
  /// Tf010f02のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tf010f02FormCondition : IConditionVO
	{

		#region 実装可能
		//
		// 原則として、条件記憶対象となる項目のコメントをはずしてください。。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD(ヘッダ店舗コード)」の値
		/// </summary>
		//private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM(ヘッダ店舗名)」の値
		/// </summary>
		//private string _head_tenpo_nm;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;
		/// <summary>
		/// 項目「APPLY_YMD(申請日)」の値
		/// </summary>
		//private string _apply_ymd;
		/// <summary>
		/// 項目「SHINSEI_TENPO_CD(申請店舗コード)」の値
		/// </summary>
		//private string _shinsei_tenpo_cd;
		/// <summary>
		/// 項目「SHINSEI_TENPO_NM(申請店舗名)」の値
		/// </summary>
		//private string _shinsei_tenpo_nm;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値
		/// </summary>
		//private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者名称)」の値
		/// </summary>
		//private string _sinseitan_nm;
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		//private string _denpyo_bango;
		/// <summary>
		/// 項目「SINSEIRIYU_KB(申請理由区分)」の値
		/// </summary>
		//private string _sinseiriyu_kb;
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値
		/// </summary>
		//private string _sinseiriyu;
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者コード)」の値
		/// </summary>
		//private string _kakuteitan_cd;
		/// <summary>
		/// 項目「KAKUTEITAN_NM(確定担当者名称)」の値
		/// </summary>
		//private string _kakuteitan_nm;
		/// <summary>
		/// 項目「KAKUTEI_YMD(確定日)」の値
		/// </summary>
		//private string _kakutei_ymd;
		/// <summary>
		/// 項目「KAMOKU_CD(科目コード)」の値
		/// </summary>
		//private string _kamoku_cd;
		/// <summary>
		/// 項目「KAMOKU_NM(科目名)」の値
		/// </summary>
		//private string _kamoku_nm;
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値
		/// </summary>
		//private string _kyakkariyu;
		/// <summary>
		/// 項目「GYOMURINGI_NO(業務稟議No)」の値
		/// </summary>
		//private string _gyomuringi_no;
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値
		/// </summary>
		//private string _jyuri_no;
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態名称)」の値
		/// </summary>
		//private string _syonin_flg_nm;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計数量)」の値
		/// </summary>
		//private string _gokei_suryo;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI1(合計原価金額)」の値
		/// </summary>
		//private string _genka_kin_gokei1;


		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD(ヘッダ店舗コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Head_tenpo_cd
		//{
		//	get
		//	{
		//		return this._head_tenpo_cd;
		//	}
		//	set
		//	{
		//		this._head_tenpo_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HEAD_TENPO_NM(ヘッダ店舗名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Head_tenpo_nm
		//{
		//	get
		//	{
		//		return this._head_tenpo_nm;
		//	}
		//	set
		//	{
		//		this._head_tenpo_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Stkmodeno
		//{
		//	get
		//	{
		//		return this._stkmodeno;
		//	}
		//	set
		//	{
		//		this._stkmodeno = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_ymd
		//{
		//	get
		//	{
		//		return this._apply_ymd;
		//	}
		//	set
		//	{
		//		this._apply_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SHINSEI_TENPO_CD(申請店舗コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Shinsei_tenpo_cd
		//{
		//	get
		//	{
		//		return this._shinsei_tenpo_cd;
		//	}
		//	set
		//	{
		//		this._shinsei_tenpo_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SHINSEI_TENPO_NM(申請店舗名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Shinsei_tenpo_nm
		//{
		//	get
		//	{
		//		return this._shinsei_tenpo_nm;
		//	}
		//	set
		//	{
		//		this._shinsei_tenpo_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinseitan_cd
		//{
		//	get
		//	{
		//		return this._sinseitan_cd;
		//	}
		//	set
		//	{
		//		this._sinseitan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinseitan_nm
		//{
		//	get
		//	{
		//		return this._sinseitan_nm;
		//	}
		//	set
		//	{
		//		this._sinseitan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Denpyo_bango
		//{
		//	get
		//	{
		//		return this._denpyo_bango;
		//	}
		//	set
		//	{
		//		this._denpyo_bango = value;
		//	}
		//}
		/// <summary>
		/// 項目「SINSEIRIYU_KB(申請理由区分)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinseiriyu_kb
		//{
		//	get
		//	{
		//		return this._sinseiriyu_kb;
		//	}
		//	set
		//	{
		//		this._sinseiriyu_kb = value;
		//	}
		//}
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinseiriyu
		//{
		//	get
		//	{
		//		return this._sinseiriyu;
		//	}
		//	set
		//	{
		//		this._sinseiriyu = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kakuteitan_cd
		//{
		//	get
		//	{
		//		return this._kakuteitan_cd;
		//	}
		//	set
		//	{
		//		this._kakuteitan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAKUTEITAN_NM(確定担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kakuteitan_nm
		//{
		//	get
		//	{
		//		return this._kakuteitan_nm;
		//	}
		//	set
		//	{
		//		this._kakuteitan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAKUTEI_YMD(確定日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kakutei_ymd
		//{
		//	get
		//	{
		//		return this._kakutei_ymd;
		//	}
		//	set
		//	{
		//		this._kakutei_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_CD(科目コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_cd
		//{
		//	get
		//	{
		//		return this._kamoku_cd;
		//	}
		//	set
		//	{
		//		this._kamoku_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_NM(科目名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_nm
		//{
		//	get
		//	{
		//		return this._kamoku_nm;
		//	}
		//	set
		//	{
		//		this._kamoku_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kyakkariyu
		//{
		//	get
		//	{
		//		return this._kyakkariyu;
		//	}
		//	set
		//	{
		//		this._kyakkariyu = value;
		//	}
		//}
		/// <summary>
		/// 項目「GYOMURINGI_NO(業務稟議No)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gyomuringi_no
		//{
		//	get
		//	{
		//		return this._gyomuringi_no;
		//	}
		//	set
		//	{
		//		this._gyomuringi_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuri_no
		//{
		//	get
		//	{
		//		return this._jyuri_no;
		//	}
		//	set
		//	{
		//		this._jyuri_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syonin_flg_nm
		//{
		//	get
		//	{
		//		return this._syonin_flg_nm;
		//	}
		//	set
		//	{
		//		this._syonin_flg_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO(合計数量)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo
		//{
		//	get
		//	{
		//		return this._gokei_suryo;
		//	}
		//	set
		//	{
		//		this._gokei_suryo = value;
		//	}
		//}
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI1(合計原価金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Genka_kin_gokei1
		//{
		//	get
		//	{
		//		return this._genka_kin_gokei1;
		//	}
		//	set
		//	{
		//		this._genka_kin_gokei1 = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf010f02FormCondition() : base()
		{
		}
		#endregion
	}
}
