using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tj170p01.Formvo
{
  /// <summary>
  /// Tj170f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tj170f01FormCondition : IConditionVO
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
		/// 項目「TANAOROSIKIJUN_YMD(今回棚卸基準日(隠し))」の値
		/// </summary>
		//private string _tanaorosikijun_ymd;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(今回棚卸実施日)」の値
		/// </summary>
		//private string _tanaorosijissi_ymd1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(今回棚卸期間FROM)」の値
		/// </summary>
		//private string _tanaorosikikan_from1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1(今回棚卸期間TO)」の値
		/// </summary>
		//private string _tanaorosikikan_to1;
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1(前回棚卸基準日(隠し))」の値
		/// </summary>
		//private string _tanaorosikijun_ymd1;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD11(前回棚卸実施日)」の値
		/// </summary>
		//private string _tanaorosijissi_ymd11;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM11(前回棚卸期間FROM)」の値
		/// </summary>
		//private string _tanaorosikikan_from11;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO11(前回棚卸期間TO)」の値
		/// </summary>
		//private string _tanaorosikikan_to11;
		/// <summary>
		/// 項目「SYOHINGUN1_CD(商品群1コード)」の値
		/// </summary>
		//private string _syohingun1_cd;
		/// <summary>
		/// 項目「SYOHINGUN1_RYAKU_NM(商品群1略式名称)」の値
		/// </summary>
		//private string _syohingun1_ryaku_nm;
		/// <summary>
		/// 項目「SYOHINGUN2_CD(商品群2コード)」の値
		/// </summary>
		//private string _syohingun2_cd;
		/// <summary>
		/// 項目「GRPNM(商品群2名称)」の値
		/// </summary>
		//private string _grpnm;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門コードFROM)」の値
		/// </summary>
		//private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM(部門名FROM)」の値
		/// </summary>
		//private string _bumon_nm_from;
		/// <summary>
		/// 項目「HINSYU_CD_FROM(品種コードFROM)」の値
		/// </summary>
		//private string _hinsyu_cd_from;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_FROM(品種略名称FROM)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門コードTO)」の値
		/// </summary>
		//private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO(部門名TO)」の値
		/// </summary>
		//private string _bumon_nm_to;
		/// <summary>
		/// 項目「HINSYU_CD_TO(品種コードTO)」の値
		/// </summary>
		//private string _hinsyu_cd_to;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_TO(品種略名称TO)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm_to;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「LOSS_TENSU(ロス点数)」の値
		/// </summary>
		//private string _loss_tensu;
		/// <summary>
		/// 項目「LOSS_ARI_FLG(ロス有フラグ)」の値
		/// </summary>
		//private string _loss_ari_flg;
		/// <summary>
		/// 項目「SHUTURYOKU_TANI(出力単位)」の値
		/// </summary>
		//private string _shuturyoku_tani;
		/// <summary>
		/// 項目「SORT_JUN(ソート順)」の値
		/// </summary>
		//private string _sort_jun;
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値
		/// </summary>
		//private string _searchcnt;
		/// <summary>
		/// 項目「SHUTURYOKU_PRINT(出力帳票)」の値
		/// </summary>
		//private string _shuturyoku_print;


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
		/// 項目「TANAOROSIKIJUN_YMD(今回棚卸基準日(隠し))」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikijun_ymd
		//{
		//	get
		//	{
		//		return this._tanaorosikijun_ymd;
		//	}
		//	set
		//	{
		//		this._tanaorosikijun_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(今回棚卸実施日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosijissi_ymd1
		//{
		//	get
		//	{
		//		return this._tanaorosijissi_ymd1;
		//	}
		//	set
		//	{
		//		this._tanaorosijissi_ymd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(今回棚卸期間FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikikan_from1
		//{
		//	get
		//	{
		//		return this._tanaorosikikan_from1;
		//	}
		//	set
		//	{
		//		this._tanaorosikikan_from1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1(今回棚卸期間TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikikan_to1
		//{
		//	get
		//	{
		//		return this._tanaorosikikan_to1;
		//	}
		//	set
		//	{
		//		this._tanaorosikikan_to1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1(前回棚卸基準日(隠し))」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikijun_ymd1
		//{
		//	get
		//	{
		//		return this._tanaorosikijun_ymd1;
		//	}
		//	set
		//	{
		//		this._tanaorosikijun_ymd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD11(前回棚卸実施日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosijissi_ymd11
		//{
		//	get
		//	{
		//		return this._tanaorosijissi_ymd11;
		//	}
		//	set
		//	{
		//		this._tanaorosijissi_ymd11 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM11(前回棚卸期間FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikikan_from11
		//{
		//	get
		//	{
		//		return this._tanaorosikikan_from11;
		//	}
		//	set
		//	{
		//		this._tanaorosikikan_from11 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO11(前回棚卸期間TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanaorosikikan_to11
		//{
		//	get
		//	{
		//		return this._tanaorosikikan_to11;
		//	}
		//	set
		//	{
		//		this._tanaorosikikan_to11 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYOHINGUN1_CD(商品群1コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syohingun1_cd
		//{
		//	get
		//	{
		//		return this._syohingun1_cd;
		//	}
		//	set
		//	{
		//		this._syohingun1_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYOHINGUN1_RYAKU_NM(商品群1略式名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syohingun1_ryaku_nm
		//{
		//	get
		//	{
		//		return this._syohingun1_ryaku_nm;
		//	}
		//	set
		//	{
		//		this._syohingun1_ryaku_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYOHINGUN2_CD(商品群2コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syohingun2_cd
		//{
		//	get
		//	{
		//		return this._syohingun2_cd;
		//	}
		//	set
		//	{
		//		this._syohingun2_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「GRPNM(商品群2名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Grpnm
		//{
		//	get
		//	{
		//		return this._grpnm;
		//	}
		//	set
		//	{
		//		this._grpnm = value;
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
		/// 項目「HINSYU_CD_FROM(品種コードFROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd_from
		//{
		//	get
		//	{
		//		return this._hinsyu_cd_from;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_FROM(品種略名称FROM)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_ryaku_nm_from
		//{
		//	get
		//	{
		//		return this._hinsyu_ryaku_nm_from;
		//	}
		//	set
		//	{
		//		this._hinsyu_ryaku_nm_from = value;
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
		/// 項目「HINSYU_CD_TO(品種コードTO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd_to
		//{
		//	get
		//	{
		//		return this._hinsyu_cd_to;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_TO(品種略名称TO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_ryaku_nm_to
		//{
		//	get
		//	{
		//		return this._hinsyu_ryaku_nm_to;
		//	}
		//	set
		//	{
		//		this._hinsyu_ryaku_nm_to = value;
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
		/// 項目「LOSS_TENSU(ロス点数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Loss_tensu
		//{
		//	get
		//	{
		//		return this._loss_tensu;
		//	}
		//	set
		//	{
		//		this._loss_tensu = value;
		//	}
		//}
		/// <summary>
		/// 項目「LOSS_ARI_FLG(ロス有フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Loss_ari_flg
		//{
		//	get
		//	{
		//		return this._loss_ari_flg;
		//	}
		//	set
		//	{
		//		this._loss_ari_flg = value;
		//	}
		//}
		/// <summary>
		/// 項目「SHUTURYOKU_TANI(出力単位)」の値を取得または設定する。
		/// </summary>
		//public virtual string Shuturyoku_tani
		//{
		//	get
		//	{
		//		return this._shuturyoku_tani;
		//	}
		//	set
		//	{
		//		this._shuturyoku_tani = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORT_JUN(ソート順)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sort_jun
		//{
		//	get
		//	{
		//		return this._sort_jun;
		//	}
		//	set
		//	{
		//		this._sort_jun = value;
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
		/// 項目「SHUTURYOKU_PRINT(出力帳票)」の値を取得または設定する。
		/// </summary>
		//public virtual string Shuturyoku_print
		//{
		//	get
		//	{
		//		return this._shuturyoku_print;
		//	}
		//	set
		//	{
		//		this._shuturyoku_print = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj170f01FormCondition() : base()
		{
		}
		#endregion
	}
}
