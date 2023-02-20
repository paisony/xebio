using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tf030p01.Formvo
{
  /// <summary>
  /// Tf030f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tf030f01FormCondition : IConditionVO
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
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値
		/// </summary>
		//private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値
		/// </summary>
		//private string _add_ymd_to;
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗コードＦＲＯＭ)」の値
		/// </summary>
		//private string _tenpo_cd_from;
		/// <summary>
		/// 項目「TENPO_NM_FROM(店舗名ＦＲＯＭ)」の値
		/// </summary>
		//private string _tenpo_nm_from;
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗コードＴＯ)」の値
		/// </summary>
		//private string _tenpo_cd_to;
		/// <summary>
		/// 項目「TENPO_NM_TO(店舗名ＴＯ)」の値
		/// </summary>
		//private string _tenpo_nm_to;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先コード)」の値
		/// </summary>
		//private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM(仕入先略式名称)」の値
		/// </summary>
		//private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値
		/// </summary>
		//private string _denpyo_bango_to;
		/// <summary>
		/// 項目「MOTODENPYO_BANGO_FROM(元伝票番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _motodenpyo_bango_from;
		/// <summary>
		/// 項目「MOTODENPYO_BANGO_TO(元伝票番号ＴＯ)」の値
		/// </summary>
		//private string _motodenpyo_bango_to;
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
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Add_ymd_from
		//{
		//	get
		//	{
		//		return this._add_ymd_from;
		//	}
		//	set
		//	{
		//		this._add_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Add_ymd_to
		//{
		//	get
		//	{
		//		return this._add_ymd_to;
		//	}
		//	set
		//	{
		//		this._add_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_cd_from
		//{
		//	get
		//	{
		//		return this._tenpo_cd_from;
		//	}
		//	set
		//	{
		//		this._tenpo_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_NM_FROM(店舗名ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_nm_from
		//{
		//	get
		//	{
		//		return this._tenpo_nm_from;
		//	}
		//	set
		//	{
		//		this._tenpo_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗コードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_cd_to
		//{
		//	get
		//	{
		//		return this._tenpo_cd_to;
		//	}
		//	set
		//	{
		//		this._tenpo_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_NM_TO(店舗名ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_nm_to
		//{
		//	get
		//	{
		//		return this._tenpo_nm_to;
		//	}
		//	set
		//	{
		//		this._tenpo_nm_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Siiresaki_cd
		//{
		//	get
		//	{
		//		return this._siiresaki_cd;
		//	}
		//	set
		//	{
		//		this._siiresaki_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM(仕入先略式名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Siiresaki_ryaku_nm
		//{
		//	get
		//	{
		//		return this._siiresaki_ryaku_nm;
		//	}
		//	set
		//	{
		//		this._siiresaki_ryaku_nm = value;
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
		/// 項目「MOTODENPYO_BANGO_FROM(元伝票番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Motodenpyo_bango_from
		//{
		//	get
		//	{
		//		return this._motodenpyo_bango_from;
		//	}
		//	set
		//	{
		//		this._motodenpyo_bango_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「MOTODENPYO_BANGO_TO(元伝票番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Motodenpyo_bango_to
		//{
		//	get
		//	{
		//		return this._motodenpyo_bango_to;
		//	}
		//	set
		//	{
		//		this._motodenpyo_bango_to = value;
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
		public Tf030f01FormCondition() : base()
		{
		}
		#endregion
	}
}
