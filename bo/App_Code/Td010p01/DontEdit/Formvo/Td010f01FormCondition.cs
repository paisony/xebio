using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Td010p01.Formvo
{
  /// <summary>
  /// Td010f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Td010f01FormCondition : IConditionVO
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
		/// 項目「SIJI_BANGO_FROM(指示番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _siji_bango_from;
		/// <summary>
		/// 項目「SIJI_BANGO_TO(指示番号ＴＯ)」の値
		/// </summary>
		//private string _siji_bango_to;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値
		/// </summary>
		//private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値
		/// </summary>
		//private string _denpyo_bango_to;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先コード)」の値
		/// </summary>
		//private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM(仕入先略式名称)」の値
		/// </summary>
		//private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門コードＦＲＯＭ)」の値
		/// </summary>
		//private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM(部門名ＦＲＯＭ)」の値
		/// </summary>
		//private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門コードＴＯ)」の値
		/// </summary>
		//private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO(部門名ＴＯ)」の値
		/// </summary>
		//private string _bumon_nm_to;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_FROM(返品確定日ＦＲＯＭ)」の値
		/// </summary>
		//private string _henpin_kakutei_ymd_from;
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_TO(返品確定日ＴＯ)」の値
		/// </summary>
		//private string _henpin_kakutei_ymd_to;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者コード)」の値
		/// </summary>
		//private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM(入力担当者名称)」の値
		/// </summary>
		//private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値
		/// </summary>
		//private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値
		/// </summary>
		//private string _add_ymd_to;
		/// <summary>
		/// 項目「HENPIN_RIYU(返品理由)」の値
		/// </summary>
		//private string _henpin_riyu;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		//private string _scan_cd;
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
		/// 項目「SIJI_BANGO_FROM(指示番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Siji_bango_from
		//{
		//	get
		//	{
		//		return this._siji_bango_from;
		//	}
		//	set
		//	{
		//		this._siji_bango_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「SIJI_BANGO_TO(指示番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Siji_bango_to
		//{
		//	get
		//	{
		//		return this._siji_bango_to;
		//	}
		//	set
		//	{
		//		this._siji_bango_to = value;
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
		/// 項目「BUMON_CD_FROM(部門コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_cd_from
		//{
		//	get
		//	{
		//		return this._bumon_cd_from;
		//	}
		//	set
		//	{
		//		this._bumon_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_NM_FROM(部門名ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_nm_from
		//{
		//	get
		//	{
		//		return this._bumon_nm_from;
		//	}
		//	set
		//	{
		//		this._bumon_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_CD_TO(部門コードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_cd_to
		//{
		//	get
		//	{
		//		return this._bumon_cd_to;
		//	}
		//	set
		//	{
		//		this._bumon_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_NM_TO(部門名ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_nm_to
		//{
		//	get
		//	{
		//		return this._bumon_nm_to;
		//	}
		//	set
		//	{
		//		this._bumon_nm_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd
		//{
		//	get
		//	{
		//		return this._burando_cd;
		//	}
		//	set
		//	{
		//		this._burando_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm
		//{
		//	get
		//	{
		//		return this._burando_nm;
		//	}
		//	set
		//	{
		//		this._burando_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_FROM(返品確定日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Henpin_kakutei_ymd_from
		//{
		//	get
		//	{
		//		return this._henpin_kakutei_ymd_from;
		//	}
		//	set
		//	{
		//		this._henpin_kakutei_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_TO(返品確定日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Henpin_kakutei_ymd_to
		//{
		//	get
		//	{
		//		return this._henpin_kakutei_ymd_to;
		//	}
		//	set
		//	{
		//		this._henpin_kakutei_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyuryokutan_cd
		//{
		//	get
		//	{
		//		return this._nyuryokutan_cd;
		//	}
		//	set
		//	{
		//		this._nyuryokutan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYURYOKUTAN_NM(入力担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyuryokutan_nm
		//{
		//	get
		//	{
		//		return this._nyuryokutan_nm;
		//	}
		//	set
		//	{
		//		this._nyuryokutan_nm = value;
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
		/// 項目「HENPIN_RIYU(返品理由)」の値を取得または設定する。
		/// </summary>
		//public virtual string Henpin_riyu
		//{
		//	get
		//	{
		//		return this._henpin_riyu;
		//	}
		//	set
		//	{
		//		this._henpin_riyu = value;
		//	}
		//}
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Scan_cd
		//{
		//	get
		//	{
		//		return this._scan_cd;
		//	}
		//	set
		//	{
		//		this._scan_cd = value;
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
		public Td010f01FormCondition() : base()
		{
		}
		#endregion
	}
}
