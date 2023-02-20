using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Th020p01.Formvo
{
  /// <summary>
  /// Th020f03のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Th020f03FormCondition : IConditionVO
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
		/// 項目「KAISYA_CD(会社コード)」の値
		/// </summary>
		//private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM(会社名称)」の値
		/// </summary>
		//private string _kaisya_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門コード)」の値
		/// </summary>
		//private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM(部門名)」の値
		/// </summary>
		//private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種略名称)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「HINSYU_CD(品種コード)」の値
		/// </summary>
		//private string _hinsyu_cd;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「JISYA_HBN(自社品番)」の値
		/// </summary>
		//private string _jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		//private string _maker_hbn;
		/// <summary>
		/// 項目「SYOHIN_ZOKUSEI(商品属性)」の値
		/// </summary>
		//private string _syohin_zokusei;
		/// <summary>
		/// 項目「SYONMK(商品名(カナ))」の値
		/// </summary>
		//private string _syonmk;
		/// <summary>
		/// 項目「IRO_NM(色)」の値
		/// </summary>
		//private string _iro_nm;
		/// <summary>
		/// 項目「ZENTENZAIKO_SU(全店在庫数)」の値
		/// </summary>
		//private string _zentenzaiko_su;
		/// <summary>
		/// 項目「ZENTENSYOKA_RTU(全店消化率)」の値
		/// </summary>
		//private string _zentensyoka_rtu;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM1(明細ヘッダ色１)」の値
		/// </summary>
		//private string _meisaihead_iro_nm1;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM2(明細ヘッダ色２)」の値
		/// </summary>
		//private string _meisaihead_iro_nm2;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM3(明細ヘッダ色３)」の値
		/// </summary>
		//private string _meisaihead_iro_nm3;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM4(明細ヘッダ色４)」の値
		/// </summary>
		//private string _meisaihead_iro_nm4;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM5(明細ヘッダ色５)」の値
		/// </summary>
		//private string _meisaihead_iro_nm5;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM6(明細ヘッダ色６)」の値
		/// </summary>
		//private string _meisaihead_iro_nm6;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM7(明細ヘッダ色７)」の値
		/// </summary>
		//private string _meisaihead_iro_nm7;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM8(明細ヘッダ色８)」の値
		/// </summary>
		//private string _meisaihead_iro_nm8;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM9(明細ヘッダ色９)」の値
		/// </summary>
		//private string _meisaihead_iro_nm9;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM10(明細ヘッダ色１０)」の値
		/// </summary>
		//private string _meisaihead_iro_nm10;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM11(明細ヘッダ色１１)」の値
		/// </summary>
		//private string _meisaihead_iro_nm11;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM12(明細ヘッダ色１２)」の値
		/// </summary>
		//private string _meisaihead_iro_nm12;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM13(明細ヘッダ色１３)」の値
		/// </summary>
		//private string _meisaihead_iro_nm13;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM14(明細ヘッダ色１４)」の値
		/// </summary>
		//private string _meisaihead_iro_nm14;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM15(明細ヘッダ色１５)」の値
		/// </summary>
		//private string _meisaihead_iro_nm15;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM16(明細ヘッダ色１６)」の値
		/// </summary>
		//private string _meisaihead_iro_nm16;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM17(明細ヘッダ色１７)」の値
		/// </summary>
		//private string _meisaihead_iro_nm17;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM18(明細ヘッダ色１８)」の値
		/// </summary>
		//private string _meisaihead_iro_nm18;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM19(明細ヘッダ色１９)」の値
		/// </summary>
		//private string _meisaihead_iro_nm19;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM20(明細ヘッダ色２０)」の値
		/// </summary>
		//private string _meisaihead_iro_nm20;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM21(明細ヘッダ色２１)」の値
		/// </summary>
		//private string _meisaihead_iro_nm21;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM22(明細ヘッダ色２２)」の値
		/// </summary>
		//private string _meisaihead_iro_nm22;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM23(明細ヘッダ色２３)」の値
		/// </summary>
		//private string _meisaihead_iro_nm23;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM24(明細ヘッダ色２４)」の値
		/// </summary>
		//private string _meisaihead_iro_nm24;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM25(明細ヘッダ色２５)」の値
		/// </summary>
		//private string _meisaihead_iro_nm25;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM26(明細ヘッダ色２６)」の値
		/// </summary>
		//private string _meisaihead_iro_nm26;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM27(明細ヘッダ色２７)」の値
		/// </summary>
		//private string _meisaihead_iro_nm27;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM28(明細ヘッダ色２８)」の値
		/// </summary>
		//private string _meisaihead_iro_nm28;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM29(明細ヘッダ色２９)」の値
		/// </summary>
		//private string _meisaihead_iro_nm29;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM30(明細ヘッダ色３０)」の値
		/// </summary>
		//private string _meisaihead_iro_nm30;
		/// <summary>
		/// 項目「TENPO_NM(店舗名)」の値
		/// </summary>
		//private string _tenpo_nm;
		/// <summary>
		/// 項目「TENPO_CD(店舗コード)」の値
		/// </summary>
		//private string _tenpo_cd;
		/// <summary>
		/// 項目「ALL_GOKEI_SURYO(総合計数量)」の値
		/// </summary>
		//private string _all_gokei_suryo;
		/// <summary>
		/// 項目「GOKEI_SURYO1(合計数量１)」の値
		/// </summary>
		//private string _gokei_suryo1;
		/// <summary>
		/// 項目「GOKEI_SURYO2(合計数量２)」の値
		/// </summary>
		//private string _gokei_suryo2;
		/// <summary>
		/// 項目「GOKEI_SURYO3(合計数量３)」の値
		/// </summary>
		//private string _gokei_suryo3;
		/// <summary>
		/// 項目「GOKEI_SURYO4(合計数量４)」の値
		/// </summary>
		//private string _gokei_suryo4;
		/// <summary>
		/// 項目「GOKEI_SURYO5(合計数量５)」の値
		/// </summary>
		//private string _gokei_suryo5;
		/// <summary>
		/// 項目「GOKEI_SURYO6(合計数量６)」の値
		/// </summary>
		//private string _gokei_suryo6;
		/// <summary>
		/// 項目「GOKEI_SURYO7(合計数量７)」の値
		/// </summary>
		//private string _gokei_suryo7;
		/// <summary>
		/// 項目「GOKEI_SURYO8(合計数量８)」の値
		/// </summary>
		//private string _gokei_suryo8;
		/// <summary>
		/// 項目「GOKEI_SURYO9(合計数量９)」の値
		/// </summary>
		//private string _gokei_suryo9;
		/// <summary>
		/// 項目「GOKEI_SURYO10(合計数量１０)」の値
		/// </summary>
		//private string _gokei_suryo10;
		/// <summary>
		/// 項目「GOKEI_SURYO11(合計数量１１)」の値
		/// </summary>
		//private string _gokei_suryo11;
		/// <summary>
		/// 項目「GOKEI_SURYO12(合計数量１２)」の値
		/// </summary>
		//private string _gokei_suryo12;
		/// <summary>
		/// 項目「GOKEI_SURYO13(合計数量１３)」の値
		/// </summary>
		//private string _gokei_suryo13;
		/// <summary>
		/// 項目「GOKEI_SURYO14(合計数量１４)」の値
		/// </summary>
		//private string _gokei_suryo14;
		/// <summary>
		/// 項目「GOKEI_SURYO15(合計数量１５)」の値
		/// </summary>
		//private string _gokei_suryo15;
		/// <summary>
		/// 項目「GOKEI_SURYO16(合計数量１６)」の値
		/// </summary>
		//private string _gokei_suryo16;
		/// <summary>
		/// 項目「GOKEI_SURYO17(合計数量１７)」の値
		/// </summary>
		//private string _gokei_suryo17;
		/// <summary>
		/// 項目「GOKEI_SURYO18(合計数量１８)」の値
		/// </summary>
		//private string _gokei_suryo18;
		/// <summary>
		/// 項目「GOKEI_SURYO19(合計数量１９)」の値
		/// </summary>
		//private string _gokei_suryo19;
		/// <summary>
		/// 項目「GOKEI_SURYO20(合計数量２０)」の値
		/// </summary>
		//private string _gokei_suryo20;
		/// <summary>
		/// 項目「GOKEI_SURYO21(合計数量２１)」の値
		/// </summary>
		//private string _gokei_suryo21;
		/// <summary>
		/// 項目「GOKEI_SURYO22(合計数量２２)」の値
		/// </summary>
		//private string _gokei_suryo22;
		/// <summary>
		/// 項目「GOKEI_SURYO23(合計数量２３)」の値
		/// </summary>
		//private string _gokei_suryo23;
		/// <summary>
		/// 項目「GOKEI_SURYO24(合計数量２４)」の値
		/// </summary>
		//private string _gokei_suryo24;
		/// <summary>
		/// 項目「GOKEI_SURYO25(合計数量２５)」の値
		/// </summary>
		//private string _gokei_suryo25;
		/// <summary>
		/// 項目「GOKEI_SURYO26(合計数量２６)」の値
		/// </summary>
		//private string _gokei_suryo26;
		/// <summary>
		/// 項目「GOKEI_SURYO27(合計数量２７)」の値
		/// </summary>
		//private string _gokei_suryo27;
		/// <summary>
		/// 項目「GOKEI_SURYO28(合計数量２８)」の値
		/// </summary>
		//private string _gokei_suryo28;
		/// <summary>
		/// 項目「GOKEI_SURYO29(合計数量２９)」の値
		/// </summary>
		//private string _gokei_suryo29;
		/// <summary>
		/// 項目「GOKEI_SURYO30(合計数量３０)」の値
		/// </summary>
		//private string _gokei_suryo30;


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
		/// 項目「KAISYA_CD(会社コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kaisya_cd
		//{
		//	get
		//	{
		//		return this._kaisya_cd;
		//	}
		//	set
		//	{
		//		this._kaisya_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「KAISYA_NM(会社名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Kaisya_nm
		//{
		//	get
		//	{
		//		return this._kaisya_nm;
		//	}
		//	set
		//	{
		//		this._kaisya_nm = value;
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
		/// 項目「JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jisya_hbn
		//{
		//	get
		//	{
		//		return this._jisya_hbn;
		//	}
		//	set
		//	{
		//		this._jisya_hbn = value;
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
		/// 項目「SYOHIN_ZOKUSEI(商品属性)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syohin_zokusei
		//{
		//	get
		//	{
		//		return this._syohin_zokusei;
		//	}
		//	set
		//	{
		//		this._syohin_zokusei = value;
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
		/// 項目「IRO_NM(色)」の値を取得または設定する。
		/// </summary>
		//public virtual string Iro_nm
		//{
		//	get
		//	{
		//		return this._iro_nm;
		//	}
		//	set
		//	{
		//		this._iro_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「ZENTENZAIKO_SU(全店在庫数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Zentenzaiko_su
		//{
		//	get
		//	{
		//		return this._zentenzaiko_su;
		//	}
		//	set
		//	{
		//		this._zentenzaiko_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「ZENTENSYOKA_RTU(全店消化率)」の値を取得または設定する。
		/// </summary>
		//public virtual string Zentensyoka_rtu
		//{
		//	get
		//	{
		//		return this._zentensyoka_rtu;
		//	}
		//	set
		//	{
		//		this._zentensyoka_rtu = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM1(明細ヘッダ色１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm1
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm1;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM2(明細ヘッダ色２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm2
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm2;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM3(明細ヘッダ色３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm3
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm3;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM4(明細ヘッダ色４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm4
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm4;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm4 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM5(明細ヘッダ色５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm5
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm5;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm5 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM6(明細ヘッダ色６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm6
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm6;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm6 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM7(明細ヘッダ色７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm7
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm7;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm7 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM8(明細ヘッダ色８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm8
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm8;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm8 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM9(明細ヘッダ色９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm9
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm9;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm9 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM10(明細ヘッダ色１０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm10
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm10;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm10 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM11(明細ヘッダ色１１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm11
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm11;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm11 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM12(明細ヘッダ色１２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm12
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm12;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm12 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM13(明細ヘッダ色１３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm13
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm13;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm13 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM14(明細ヘッダ色１４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm14
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm14;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm14 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM15(明細ヘッダ色１５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm15
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm15;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm15 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM16(明細ヘッダ色１６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm16
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm16;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm16 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM17(明細ヘッダ色１７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm17
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm17;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm17 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM18(明細ヘッダ色１８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm18
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm18;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm18 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM19(明細ヘッダ色１９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm19
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm19;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm19 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM20(明細ヘッダ色２０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm20
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm20;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm20 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM21(明細ヘッダ色２１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm21
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm21;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm21 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM22(明細ヘッダ色２２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm22
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm22;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm22 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM23(明細ヘッダ色２３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm23
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm23;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm23 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM24(明細ヘッダ色２４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm24
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm24;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm24 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM25(明細ヘッダ色２５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm25
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm25;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm25 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM26(明細ヘッダ色２６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm26
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm26;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm26 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM27(明細ヘッダ色２７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm27
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm27;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm27 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM28(明細ヘッダ色２８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm28
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm28;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm28 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM29(明細ヘッダ色２９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm29
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm29;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm29 = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM30(明細ヘッダ色３０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisaihead_iro_nm30
		//{
		//	get
		//	{
		//		return this._meisaihead_iro_nm30;
		//	}
		//	set
		//	{
		//		this._meisaihead_iro_nm30 = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENPO_NM(店舗名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_nm
		//{
		//	get
		//	{
		//		return this._tenpo_nm;
		//	}
		//	set
		//	{
		//		this._tenpo_nm = value;
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
		/// 項目「ALL_GOKEI_SURYO(総合計数量)」の値を取得または設定する。
		/// </summary>
		//public virtual string All_gokei_suryo
		//{
		//	get
		//	{
		//		return this._all_gokei_suryo;
		//	}
		//	set
		//	{
		//		this._all_gokei_suryo = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO1(合計数量１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo1
		//{
		//	get
		//	{
		//		return this._gokei_suryo1;
		//	}
		//	set
		//	{
		//		this._gokei_suryo1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO2(合計数量２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo2
		//{
		//	get
		//	{
		//		return this._gokei_suryo2;
		//	}
		//	set
		//	{
		//		this._gokei_suryo2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO3(合計数量３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo3
		//{
		//	get
		//	{
		//		return this._gokei_suryo3;
		//	}
		//	set
		//	{
		//		this._gokei_suryo3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO4(合計数量４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo4
		//{
		//	get
		//	{
		//		return this._gokei_suryo4;
		//	}
		//	set
		//	{
		//		this._gokei_suryo4 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO5(合計数量５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo5
		//{
		//	get
		//	{
		//		return this._gokei_suryo5;
		//	}
		//	set
		//	{
		//		this._gokei_suryo5 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO6(合計数量６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo6
		//{
		//	get
		//	{
		//		return this._gokei_suryo6;
		//	}
		//	set
		//	{
		//		this._gokei_suryo6 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO7(合計数量７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo7
		//{
		//	get
		//	{
		//		return this._gokei_suryo7;
		//	}
		//	set
		//	{
		//		this._gokei_suryo7 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO8(合計数量８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo8
		//{
		//	get
		//	{
		//		return this._gokei_suryo8;
		//	}
		//	set
		//	{
		//		this._gokei_suryo8 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO9(合計数量９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo9
		//{
		//	get
		//	{
		//		return this._gokei_suryo9;
		//	}
		//	set
		//	{
		//		this._gokei_suryo9 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO10(合計数量１０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo10
		//{
		//	get
		//	{
		//		return this._gokei_suryo10;
		//	}
		//	set
		//	{
		//		this._gokei_suryo10 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO11(合計数量１１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo11
		//{
		//	get
		//	{
		//		return this._gokei_suryo11;
		//	}
		//	set
		//	{
		//		this._gokei_suryo11 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO12(合計数量１２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo12
		//{
		//	get
		//	{
		//		return this._gokei_suryo12;
		//	}
		//	set
		//	{
		//		this._gokei_suryo12 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO13(合計数量１３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo13
		//{
		//	get
		//	{
		//		return this._gokei_suryo13;
		//	}
		//	set
		//	{
		//		this._gokei_suryo13 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO14(合計数量１４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo14
		//{
		//	get
		//	{
		//		return this._gokei_suryo14;
		//	}
		//	set
		//	{
		//		this._gokei_suryo14 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO15(合計数量１５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo15
		//{
		//	get
		//	{
		//		return this._gokei_suryo15;
		//	}
		//	set
		//	{
		//		this._gokei_suryo15 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO16(合計数量１６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo16
		//{
		//	get
		//	{
		//		return this._gokei_suryo16;
		//	}
		//	set
		//	{
		//		this._gokei_suryo16 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO17(合計数量１７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo17
		//{
		//	get
		//	{
		//		return this._gokei_suryo17;
		//	}
		//	set
		//	{
		//		this._gokei_suryo17 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO18(合計数量１８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo18
		//{
		//	get
		//	{
		//		return this._gokei_suryo18;
		//	}
		//	set
		//	{
		//		this._gokei_suryo18 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO19(合計数量１９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo19
		//{
		//	get
		//	{
		//		return this._gokei_suryo19;
		//	}
		//	set
		//	{
		//		this._gokei_suryo19 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO20(合計数量２０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo20
		//{
		//	get
		//	{
		//		return this._gokei_suryo20;
		//	}
		//	set
		//	{
		//		this._gokei_suryo20 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO21(合計数量２１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo21
		//{
		//	get
		//	{
		//		return this._gokei_suryo21;
		//	}
		//	set
		//	{
		//		this._gokei_suryo21 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO22(合計数量２２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo22
		//{
		//	get
		//	{
		//		return this._gokei_suryo22;
		//	}
		//	set
		//	{
		//		this._gokei_suryo22 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO23(合計数量２３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo23
		//{
		//	get
		//	{
		//		return this._gokei_suryo23;
		//	}
		//	set
		//	{
		//		this._gokei_suryo23 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO24(合計数量２４)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo24
		//{
		//	get
		//	{
		//		return this._gokei_suryo24;
		//	}
		//	set
		//	{
		//		this._gokei_suryo24 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO25(合計数量２５)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo25
		//{
		//	get
		//	{
		//		return this._gokei_suryo25;
		//	}
		//	set
		//	{
		//		this._gokei_suryo25 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO26(合計数量２６)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo26
		//{
		//	get
		//	{
		//		return this._gokei_suryo26;
		//	}
		//	set
		//	{
		//		this._gokei_suryo26 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO27(合計数量２７)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo27
		//{
		//	get
		//	{
		//		return this._gokei_suryo27;
		//	}
		//	set
		//	{
		//		this._gokei_suryo27 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO28(合計数量２８)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo28
		//{
		//	get
		//	{
		//		return this._gokei_suryo28;
		//	}
		//	set
		//	{
		//		this._gokei_suryo28 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO29(合計数量２９)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo29
		//{
		//	get
		//	{
		//		return this._gokei_suryo29;
		//	}
		//	set
		//	{
		//		this._gokei_suryo29 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_SURYO30(合計数量３０)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_suryo30
		//{
		//	get
		//	{
		//		return this._gokei_suryo30;
		//	}
		//	set
		//	{
		//		this._gokei_suryo30 = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f03FormCondition() : base()
		{
		}
		#endregion
	}
}
