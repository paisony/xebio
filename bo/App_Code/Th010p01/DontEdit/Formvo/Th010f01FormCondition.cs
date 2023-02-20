using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Th010p01.Formvo
{
  /// <summary>
  /// Th010f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Th010f01FormCondition : IConditionVO
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
		/// 項目「OLD_JISYA_HBN_FROM(旧自社品番FROM)」の値
		/// </summary>
		//private string _old_jisya_hbn_from;
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(旧自社品番TO)」の値
		/// </summary>
		//private string _old_jisya_hbn_to;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		//private string _scan_cd;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		//private string _maker_hbn;
		/// <summary>
		/// 項目「BUMON_CD(部門コード)」の値
		/// </summary>
		//private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM(部門名)」の値
		/// </summary>
		//private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_CD(品種コード)」の値
		/// </summary>
		//private string _hinsyu_cd;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種略名称)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先コード)」の値
		/// </summary>
		//private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM(仕入先名称)」の値
		/// </summary>
		//private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「GENBAIKA_TNK_FROM(現売価FROM)」の値
		/// </summary>
		//private string _genbaika_tnk_from;
		/// <summary>
		/// 項目「GENBAIKA_TNK_TO(現売価TO)」の値
		/// </summary>
		//private string _genbaika_tnk_to;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_FROM(メーカー価格FROM)」の値
		/// </summary>
		//private string _makerkakaku_tnk_from;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_TO(メーカー価格TO)」の値
		/// </summary>
		//private string _makerkakaku_tnk_to;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日FROM)」の値
		/// </summary>
		//private string _hanbaikanryo_ymd_from;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO(販売完了日TO)」の値
		/// </summary>
		//private string _hanbaikanryo_ymd_to;
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値
		/// </summary>
		//private string _searchcnt;
		/// <summary>
		/// 項目「SYOHINMST_SERCHSTK(商品マスタ検索選択)」の値
		/// </summary>
		//private string _syohinmst_serchstk;
		/// <summary>
		/// 項目「MODENO(モードNO)」の値
		/// </summary>
		//private string _modeno;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;


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
		/// 項目「OLD_JISYA_HBN_FROM(旧自社品番FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Old_jisya_hbn_from
		//{
		//	get
		//	{
		//		return this._old_jisya_hbn_from;
		//	}
		//	set
		//	{
		//		this._old_jisya_hbn_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(旧自社品番TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Old_jisya_hbn_to
		//{
		//	get
		//	{
		//		return this._old_jisya_hbn_to;
		//	}
		//	set
		//	{
		//		this._old_jisya_hbn_to = value;
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
		/// 項目「MAKER_HBN(メーカー品番)」の値を取得または設定する。
		/// </summary>
		//public virtual string Maker_hbn
		//{
		//	get
		//	{
		//		return this._maker_hbn;
		//	}
		//	set
		//	{
		//		this._maker_hbn = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_CD(部門コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_cd
		//{
		//	get
		//	{
		//		return this._bumon_cd;
		//	}
		//	set
		//	{
		//		this._bumon_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_NM(部門名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_nm
		//{
		//	get
		//	{
		//		return this._bumon_nm;
		//	}
		//	set
		//	{
		//		this._bumon_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD(品種コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd
		//{
		//	get
		//	{
		//		return this._hinsyu_cd;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種略名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_ryaku_nm
		//{
		//	get
		//	{
		//		return this._hinsyu_ryaku_nm;
		//	}
		//	set
		//	{
		//		this._hinsyu_ryaku_nm = value;
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
		/// 項目「SIIRESAKI_RYAKU_NM(仕入先名称)」の値を取得または設定する。
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
		/// 項目「GENBAIKA_TNK_FROM(現売価FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Genbaika_tnk_from
		//{
		//	get
		//	{
		//		return this._genbaika_tnk_from;
		//	}
		//	set
		//	{
		//		this._genbaika_tnk_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「GENBAIKA_TNK_TO(現売価TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Genbaika_tnk_to
		//{
		//	get
		//	{
		//		return this._genbaika_tnk_to;
		//	}
		//	set
		//	{
		//		this._genbaika_tnk_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_FROM(メーカー価格FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Makerkakaku_tnk_from
		//{
		//	get
		//	{
		//		return this._makerkakaku_tnk_from;
		//	}
		//	set
		//	{
		//		this._makerkakaku_tnk_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_TO(メーカー価格TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Makerkakaku_tnk_to
		//{
		//	get
		//	{
		//		return this._makerkakaku_tnk_to;
		//	}
		//	set
		//	{
		//		this._makerkakaku_tnk_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hanbaikanryo_ymd_from
		//{
		//	get
		//	{
		//		return this._hanbaikanryo_ymd_from;
		//	}
		//	set
		//	{
		//		this._hanbaikanryo_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO(販売完了日TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hanbaikanryo_ymd_to
		//{
		//	get
		//	{
		//		return this._hanbaikanryo_ymd_to;
		//	}
		//	set
		//	{
		//		this._hanbaikanryo_ymd_to = value;
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
		/// 項目「SYOHINMST_SERCHSTK(商品マスタ検索選択)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syohinmst_serchstk
		//{
		//	get
		//	{
		//		return this._syohinmst_serchstk;
		//	}
		//	set
		//	{
		//		this._syohinmst_serchstk = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th010f01FormCondition() : base()
		{
		}
		#endregion
	}
}
