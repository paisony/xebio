using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tf020p01.Formvo
{
  /// <summary>
  /// Tf020f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tf020f01FormCondition : IConditionVO
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
		/// 項目「MODENO(モードNO)」の値
		/// </summary>
		//private string _modeno;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;
		/// <summary>
		/// 項目「SYONIN_FLG(承認状態)」の値
		/// </summary>
		//private string _syonin_flg;
		/// <summary>
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値
		/// </summary>
		//private string _apply_ymd_from;
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値
		/// </summary>
		//private string _apply_ymd_to;
		/// <summary>
		/// 項目「KAKUTEI_YMD_FROM(確定日ＦＲＯＭ)」の値
		/// </summary>
		//private string _kakutei_ymd_from;
		/// <summary>
		/// 項目「KAKUTEI_YMD_TO(確定日ＴＯ)」の値
		/// </summary>
		//private string _kakutei_ymd_to;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値
		/// </summary>
		//private string _denpyo_bango_to;
		/// <summary>
		/// 項目「KAMOKU_CD_FROM(科目コードＦＲＯＭ)」の値
		/// </summary>
		//private string _kamoku_cd_from;
		/// <summary>
		/// 項目「KAMOKU_NM_FROM(科目名ＦＲＯＭ)」の値
		/// </summary>
		//private string _kamoku_nm_from;
		/// <summary>
		/// 項目「KAMOKU_CD_TO(科目コードＴＯ)」の値
		/// </summary>
		//private string _kamoku_cd_to;
		/// <summary>
		/// 項目「KAMOKU_NM_TO(科目名ＴＯ)」の値
		/// </summary>
		//private string _kamoku_nm_to;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値
		/// </summary>
		//private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者名称)」の値
		/// </summary>
		//private string _sinseitan_nm;
		/// <summary>
		/// 項目「JYURI_NO_FROM(受理番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _jyuri_no_from;
		/// <summary>
		/// 項目「JYURI_NO_TO(受理番号ＴＯ)」の値
		/// </summary>
		//private string _jyuri_no_to;
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値
		/// </summary>
		//private string _searchcnt;


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
		/// 項目「MODENO(モードNO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Modeno
		//{
		//	get
		//	{
		//		return this._modeno;
		//	}
		//	set
		//	{
		//		this._modeno = value;
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
		/// 項目「SYONIN_FLG(承認状態)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syonin_flg
		//{
		//	get
		//	{
		//		return this._syonin_flg;
		//	}
		//	set
		//	{
		//		this._syonin_flg = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_ymd_from
		//{
		//	get
		//	{
		//		return this._apply_ymd_from;
		//	}
		//	set
		//	{
		//		this._apply_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_ymd_to
		//{
		//	get
		//	{
		//		return this._apply_ymd_to;
		//	}
		//	set
		//	{
		//		this._apply_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAKUTEI_YMD_FROM(確定日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kakutei_ymd_from
		//{
		//	get
		//	{
		//		return this._kakutei_ymd_from;
		//	}
		//	set
		//	{
		//		this._kakutei_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAKUTEI_YMD_TO(確定日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kakutei_ymd_to
		//{
		//	get
		//	{
		//		return this._kakutei_ymd_to;
		//	}
		//	set
		//	{
		//		this._kakutei_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Denpyo_bango_from
		//{
		//	get
		//	{
		//		return this._denpyo_bango_from;
		//	}
		//	set
		//	{
		//		this._denpyo_bango_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Denpyo_bango_to
		//{
		//	get
		//	{
		//		return this._denpyo_bango_to;
		//	}
		//	set
		//	{
		//		this._denpyo_bango_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_CD_FROM(科目コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_cd_from
		//{
		//	get
		//	{
		//		return this._kamoku_cd_from;
		//	}
		//	set
		//	{
		//		this._kamoku_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_NM_FROM(科目名ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_nm_from
		//{
		//	get
		//	{
		//		return this._kamoku_nm_from;
		//	}
		//	set
		//	{
		//		this._kamoku_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_CD_TO(科目コードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_cd_to
		//{
		//	get
		//	{
		//		return this._kamoku_cd_to;
		//	}
		//	set
		//	{
		//		this._kamoku_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAMOKU_NM_TO(科目名ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kamoku_nm_to
		//{
		//	get
		//	{
		//		return this._kamoku_nm_to;
		//	}
		//	set
		//	{
		//		this._kamoku_nm_to = value;
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
		/// 項目「JYURI_NO_FROM(受理番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuri_no_from
		//{
		//	get
		//	{
		//		return this._jyuri_no_from;
		//	}
		//	set
		//	{
		//		this._jyuri_no_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURI_NO_TO(受理番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuri_no_to
		//{
		//	get
		//	{
		//		return this._jyuri_no_to;
		//	}
		//	set
		//	{
		//		this._jyuri_no_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Searchcnt
		//{
		//	get
		//	{
		//		return this._searchcnt;
		//	}
		//	set
		//	{
		//		this._searchcnt = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf020f01FormCondition() : base()
		{
		}
		#endregion
	}
}
