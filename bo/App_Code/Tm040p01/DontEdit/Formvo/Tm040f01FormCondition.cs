using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tm040p01.Formvo
{
  /// <summary>
  /// Tm040f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tm040f01FormCondition : IConditionVO
	{

		#region 実装可能
		//
		// 原則として、条件記憶対象となる項目のコメントをはずしてください。。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「MODENO(モードNO)」の値
		/// </summary>
		//private string _modeno;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(旧自社品番)」の値
		/// </summary>
		//private string _old_jisya_hbn;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		//private string _scan_cd;
		/// <summary>
		/// 項目「BUMON_NM(部門名)」の値
		/// </summary>
		//private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種略名称)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		//private string _maker_hbn;
		/// <summary>
		/// 項目「SYONMK(商品名(カナ))」の値
		/// </summary>
		//private string _syonmk;
		/// <summary>
		/// 項目「TENPO_CD(店舗コード)」の値
		/// </summary>
		//private string _tenpo_cd;
		/// <summary>
		/// 項目「PLUFLG(店別単価マスタ検索フラグ)」の値
		/// </summary>
		//private string _pluflg;
		/// <summary>
		/// 項目「PRICEFLG(売変検索フラグ)」の値
		/// </summary>
		//private string _priceflg;
		/// <summary>
		/// 項目「ZAIKOFLG(店在庫検索フラグ)」の値
		/// </summary>
		//private string _zaikoflg;
		/// <summary>
		/// 項目「NYUKAFLG(入荷予定数検索フラグ)」の値
		/// </summary>
		//private string _nyukaflg;
		/// <summary>
		/// 項目「URIFLG(売上実績数検索フラグ)」の値
		/// </summary>
		//private string _uriflg;
		/// <summary>
		/// 項目「HOJUFLG(依頼集計数(補充)検索フラグ)」の値
		/// </summary>
		//private string _hojuflg;
		/// <summary>
		/// 項目「TANPINFLG(依頼集計数(単品)検索フラグ)」の値
		/// </summary>
		//private string _tanpinflg;
		/// <summary>
		/// 項目「SIJIFLG(指示検索フラグ)」の値
		/// </summary>
		//private string _sijiflg;
		/// <summary>
		/// 項目「SIJI_BANGO(指示番号)」の値
		/// </summary>
		//private string _siji_bango;
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD(出荷会社コード)」の値
		/// </summary>
		//private string _syukkakaisya_cd;
		/// <summary>
		/// 項目「JYURYOKAISYA_CD(入荷会社コード)」の値
		/// </summary>
		//private string _jyuryokaisya_cd;
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店コード)」の値
		/// </summary>
		//private string _syukkaten_cd;


		#endregion

		#region プロパティ
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
		/// 項目「OLD_JISYA_HBN(旧自社品番)」の値を取得または設定する。
		/// </summary>
		//public virtual string Old_jisya_hbn
		//{
		//	get
		//	{
		//		return this._old_jisya_hbn;
		//	}
		//	set
		//	{
		//		this._old_jisya_hbn = value;
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
		/// 項目「SYONMK(商品名(カナ))」の値を取得または設定する。
		/// </summary>
		//public virtual string Syonmk
		//{
		//	get
		//	{
		//		return this._syonmk;
		//	}
		//	set
		//	{
		//		this._syonmk = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_CD(店舗コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_cd
		//{
		//	get
		//	{
		//		return this._tenpo_cd;
		//	}
		//	set
		//	{
		//		this._tenpo_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「PLUFLG(店別単価マスタ検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Pluflg
		//{
		//	get
		//	{
		//		return this._pluflg;
		//	}
		//	set
		//	{
		//		this._pluflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「PRICEFLG(売変検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Priceflg
		//{
		//	get
		//	{
		//		return this._priceflg;
		//	}
		//	set
		//	{
		//		this._priceflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「ZAIKOFLG(店在庫検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Zaikoflg
		//{
		//	get
		//	{
		//		return this._zaikoflg;
		//	}
		//	set
		//	{
		//		this._zaikoflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYUKAFLG(入荷予定数検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukaflg
		//{
		//	get
		//	{
		//		return this._nyukaflg;
		//	}
		//	set
		//	{
		//		this._nyukaflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「URIFLG(売上実績数検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Uriflg
		//{
		//	get
		//	{
		//		return this._uriflg;
		//	}
		//	set
		//	{
		//		this._uriflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「HOJUFLG(依頼集計数(補充)検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hojuflg
		//{
		//	get
		//	{
		//		return this._hojuflg;
		//	}
		//	set
		//	{
		//		this._hojuflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「TANPINFLG(依頼集計数(単品)検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tanpinflg
		//{
		//	get
		//	{
		//		return this._tanpinflg;
		//	}
		//	set
		//	{
		//		this._tanpinflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「SIJIFLG(指示検索フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sijiflg
		//{
		//	get
		//	{
		//		return this._sijiflg;
		//	}
		//	set
		//	{
		//		this._sijiflg = value;
		//	}
		//}
		/// <summary>
		/// 項目「SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Siji_bango
		//{
		//	get
		//	{
		//		return this._siji_bango;
		//	}
		//	set
		//	{
		//		this._siji_bango = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD(出荷会社コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkakaisya_cd
		//{
		//	get
		//	{
		//		return this._syukkakaisya_cd;
		//	}
		//	set
		//	{
		//		this._syukkakaisya_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURYOKAISYA_CD(入荷会社コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuryokaisya_cd
		//{
		//	get
		//	{
		//		return this._jyuryokaisya_cd;
		//	}
		//	set
		//	{
		//		this._jyuryokaisya_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkaten_cd
		//{
		//	get
		//	{
		//		return this._syukkaten_cd;
		//	}
		//	set
		//	{
		//		this._syukkaten_cd = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm040f01FormCondition() : base()
		{
		}
		#endregion
	}
}
