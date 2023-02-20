using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tm070p01.Formvo
{
  /// <summary>
  /// Tm070f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tm070f01FormCondition : IConditionVO
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
		/// 項目「HENKO_YMD_FROM(変更日ＦＲＯＭ)」の値
		/// </summary>
		//private string _henko_ymd_from;
		/// <summary>
		/// 項目「HENKO_YMD_TO(変更日ＴＯ)」の値
		/// </summary>
		//private string _henko_ymd_to;
		/// <summary>
		/// 項目「MOTO_TENPO_CD_FROM(元店舗コードＦＲＯＭ)」の値
		/// </summary>
		//private string _moto_tenpo_cd_from;
		/// <summary>
		/// 項目「MOTO_TENPO_NM_FROM(元店舗名称ＦＲＯＭ)」の値
		/// </summary>
		//private string _moto_tenpo_nm_from;
		/// <summary>
		/// 項目「MOTO_TENPO_CD_TO(元店舗コードＴＯ)」の値
		/// </summary>
		//private string _moto_tenpo_cd_to;
		/// <summary>
		/// 項目「MOTO_TENPO_NM_TO(元店舗名称ＴＯ)」の値
		/// </summary>
		//private string _moto_tenpo_nm_to;
		/// <summary>
		/// 項目「TAN_CD_FROM(担当者コードＦＲＯＭ)」の値
		/// </summary>
		//private string _tan_cd_from;
		/// <summary>
		/// 項目「TAN_NM_FROM(担当者名称ＦＲＯＭ)」の値
		/// </summary>
		//private string _tan_nm_from;
		/// <summary>
		/// 項目「TAN_CD_TO(担当者コードＴＯ)」の値
		/// </summary>
		//private string _tan_cd_to;
		/// <summary>
		/// 項目「TAN_NM_TO(担当者名称ＴＯ)」の値
		/// </summary>
		//private string _tan_nm_to;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;
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
		/// 項目「HENKO_YMD_FROM(変更日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Henko_ymd_from
		//{
		//	get
		//	{
		//		return this._henko_ymd_from;
		//	}
		//	set
		//	{
		//		this._henko_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「HENKO_YMD_TO(変更日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Henko_ymd_to
		//{
		//	get
		//	{
		//		return this._henko_ymd_to;
		//	}
		//	set
		//	{
		//		this._henko_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「MOTO_TENPO_CD_FROM(元店舗コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Moto_tenpo_cd_from
		//{
		//	get
		//	{
		//		return this._moto_tenpo_cd_from;
		//	}
		//	set
		//	{
		//		this._moto_tenpo_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「MOTO_TENPO_NM_FROM(元店舗名称ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Moto_tenpo_nm_from
		//{
		//	get
		//	{
		//		return this._moto_tenpo_nm_from;
		//	}
		//	set
		//	{
		//		this._moto_tenpo_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「MOTO_TENPO_CD_TO(元店舗コードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Moto_tenpo_cd_to
		//{
		//	get
		//	{
		//		return this._moto_tenpo_cd_to;
		//	}
		//	set
		//	{
		//		this._moto_tenpo_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「MOTO_TENPO_NM_TO(元店舗名称ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Moto_tenpo_nm_to
		//{
		//	get
		//	{
		//		return this._moto_tenpo_nm_to;
		//	}
		//	set
		//	{
		//		this._moto_tenpo_nm_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「TAN_CD_FROM(担当者コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tan_cd_from
		//{
		//	get
		//	{
		//		return this._tan_cd_from;
		//	}
		//	set
		//	{
		//		this._tan_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「TAN_NM_FROM(担当者名称ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tan_nm_from
		//{
		//	get
		//	{
		//		return this._tan_nm_from;
		//	}
		//	set
		//	{
		//		this._tan_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「TAN_CD_TO(担当者コードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tan_cd_to
		//{
		//	get
		//	{
		//		return this._tan_cd_to;
		//	}
		//	set
		//	{
		//		this._tan_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「TAN_NM_TO(担当者名称ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tan_nm_to
		//{
		//	get
		//	{
		//		return this._tan_nm_to;
		//	}
		//	set
		//	{
		//		this._tan_nm_to = value;
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
		public Tm070f01FormCondition() : base()
		{
		}
		#endregion
	}
}
