using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tl030p01.Formvo
{
  /// <summary>
  /// Tl030f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tl030f01FormCondition : IConditionVO
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
		/// 項目「SINSEIMOTO(申請元)」の値
		/// </summary>
		//private string _sinseimoto;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門コードFROM)」の値
		/// </summary>
		//private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM(部門名FROM)」の値
		/// </summary>
		//private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門コードTO)」の値
		/// </summary>
		//private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO(部門名TO)」の値
		/// </summary>
		//private string _bumon_nm_to;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値
		/// </summary>
		//private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者名称)」の値
		/// </summary>
		//private string _sinseitan_nm;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示NoFROM)」の値
		/// </summary>
		//private string _baihen_shiji_no_from;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示NoTO)」の値
		/// </summary>
		//private string _baihen_shiji_no_to;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(売変作業開始日FROM)」の値
		/// </summary>
		//private string _baihensagyokaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_TO(売変作業開始日TO)」の値
		/// </summary>
		//private string _baihensagyokaisi_ymd_to;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_FROM(売変開始日FROM)」の値
		/// </summary>
		//private string _baihenkaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(売変開始日TO)」の値
		/// </summary>
		//private string _baihenkaisi_ymd_to;
		/// <summary>
		/// 項目「GENBAIKA_SHIJIBAIKA_FLG(現売価＝指示売価のみフラグ)」の値
		/// </summary>
		//private string _genbaika_shijibaika_flg;
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値
		/// </summary>
		//private string _searchcnt;
		/// <summary>
		/// 項目「LABEL_CD(ラベル発行機ＩＤ)」の値
		/// </summary>
		//private string _label_cd;
		/// <summary>
		/// 項目「LABEL_IP(ラベル発行機ＩＰ)」の値
		/// </summary>
		//private string _label_ip;
		/// <summary>
		/// 項目「LABEL_NM(ラベル発行機名)」の値
		/// </summary>
		//private string _label_nm;


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
		/// 項目「SINSEIMOTO(申請元)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinseimoto
		//{
		//	get
		//	{
		//		return this._sinseimoto;
		//	}
		//	set
		//	{
		//		this._sinseimoto = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門コードFROM)」の値を取得または設定する。
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
		/// 項目「BUMON_NM_FROM(部門名FROM)」の値を取得または設定する。
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
		/// 項目「BUMON_CD_TO(部門コードTO)」の値を取得または設定する。
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
		/// 項目「BUMON_NM_TO(部門名TO)」の値を取得または設定する。
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
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示NoFROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihen_shiji_no_from
		//{
		//	get
		//	{
		//		return this._baihen_shiji_no_from;
		//	}
		//	set
		//	{
		//		this._baihen_shiji_no_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示NoTO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihen_shiji_no_to
		//{
		//	get
		//	{
		//		return this._baihen_shiji_no_to;
		//	}
		//	set
		//	{
		//		this._baihen_shiji_no_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(売変作業開始日FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihensagyokaisi_ymd_from
		//{
		//	get
		//	{
		//		return this._baihensagyokaisi_ymd_from;
		//	}
		//	set
		//	{
		//		this._baihensagyokaisi_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_TO(売変作業開始日TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihensagyokaisi_ymd_to
		//{
		//	get
		//	{
		//		return this._baihensagyokaisi_ymd_to;
		//	}
		//	set
		//	{
		//		this._baihensagyokaisi_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_FROM(売変開始日FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihenkaisi_ymd_from
		//{
		//	get
		//	{
		//		return this._baihenkaisi_ymd_from;
		//	}
		//	set
		//	{
		//		this._baihenkaisi_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(売変開始日TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Baihenkaisi_ymd_to
		//{
		//	get
		//	{
		//		return this._baihenkaisi_ymd_to;
		//	}
		//	set
		//	{
		//		this._baihenkaisi_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「GENBAIKA_SHIJIBAIKA_FLG(現売価＝指示売価のみフラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Genbaika_shijibaika_flg
		//{
		//	get
		//	{
		//		return this._genbaika_shijibaika_flg;
		//	}
		//	set
		//	{
		//		this._genbaika_shijibaika_flg = value;
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
		/// <summary>
		/// 項目「LABEL_CD(ラベル発行機ＩＤ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Label_cd
		//{
		//	get
		//	{
		//		return this._label_cd;
		//	}
		//	set
		//	{
		//		this._label_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「LABEL_IP(ラベル発行機ＩＰ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Label_ip
		//{
		//	get
		//	{
		//		return this._label_ip;
		//	}
		//	set
		//	{
		//		this._label_ip = value;
		//	}
		//}
		/// <summary>
		/// 項目「LABEL_NM(ラベル発行機名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Label_nm
		//{
		//	get
		//	{
		//		return this._label_nm;
		//	}
		//	set
		//	{
		//		this._label_nm = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl030f01FormCondition() : base()
		{
		}
		#endregion
	}
}
