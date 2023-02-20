using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tf060p01.Formvo
{
  /// <summary>
  /// Tf060f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tf060f01FormCondition : IConditionVO
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
		/// 項目「GETUDO(月度)」の値
		/// </summary>
		//private string _getudo;
		/// <summary>
		/// 項目「TUKIBETU_BUMON1_YOSAN_KIN(月別部門１予算額)」の値
		/// </summary>
		//private string _tukibetu_bumon1_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON2_YOSAN_KIN(月別部門２予算額)」の値
		/// </summary>
		//private string _tukibetu_bumon2_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON3_YOSAN_KIN(月別部門３予算額)」の値
		/// </summary>
		//private string _tukibetu_bumon3_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON4_YOSAN_KIN(月別部門４予算額)」の値
		/// </summary>
		//private string _tukibetu_bumon4_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON5_YOSAN_KIN(月別部門５予算額)」の値
		/// </summary>
		//private string _tukibetu_bumon5_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_YOSAN_KIN_GOKEI(月別予算額合計)」の値
		/// </summary>
		//private string _tukibetu_yosan_kin_gokei;
		/// <summary>
		/// 項目「BUMON1_YOSANGOKEI_KIN(部門１予算額合計)」の値
		/// </summary>
		//private string _bumon1_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON2_YOSANGOKEI_KIN(部門２予算額合計)」の値
		/// </summary>
		//private string _bumon2_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON3_YOSANGOKEI_KIN(部門３予算額合計)」の値
		/// </summary>
		//private string _bumon3_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON4_YOSANGOKEI_KIN(部門４予算額合計)」の値
		/// </summary>
		//private string _bumon4_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON5_YOSANGOKEI_KIN(部門５予算額合計)」の値
		/// </summary>
		//private string _bumon5_yosangokei_kin;
		/// <summary>
		/// 項目「YOSANGOKEI_KIN(予算額合計)」の値
		/// </summary>
		//private string _yosangokei_kin;


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
		/// 項目「GETUDO(月度)」の値を取得または設定する。
		/// </summary>
		//public virtual string Getudo
		//{
		//	get
		//	{
		//		return this._getudo;
		//	}
		//	set
		//	{
		//		this._getudo = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_BUMON1_YOSAN_KIN(月別部門１予算額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_bumon1_yosan_kin
		//{
		//	get
		//	{
		//		return this._tukibetu_bumon1_yosan_kin;
		//	}
		//	set
		//	{
		//		this._tukibetu_bumon1_yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_BUMON2_YOSAN_KIN(月別部門２予算額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_bumon2_yosan_kin
		//{
		//	get
		//	{
		//		return this._tukibetu_bumon2_yosan_kin;
		//	}
		//	set
		//	{
		//		this._tukibetu_bumon2_yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_BUMON3_YOSAN_KIN(月別部門３予算額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_bumon3_yosan_kin
		//{
		//	get
		//	{
		//		return this._tukibetu_bumon3_yosan_kin;
		//	}
		//	set
		//	{
		//		this._tukibetu_bumon3_yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_BUMON4_YOSAN_KIN(月別部門４予算額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_bumon4_yosan_kin
		//{
		//	get
		//	{
		//		return this._tukibetu_bumon4_yosan_kin;
		//	}
		//	set
		//	{
		//		this._tukibetu_bumon4_yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_BUMON5_YOSAN_KIN(月別部門５予算額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_bumon5_yosan_kin
		//{
		//	get
		//	{
		//		return this._tukibetu_bumon5_yosan_kin;
		//	}
		//	set
		//	{
		//		this._tukibetu_bumon5_yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「TUKIBETU_YOSAN_KIN_GOKEI(月別予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tukibetu_yosan_kin_gokei
		//{
		//	get
		//	{
		//		return this._tukibetu_yosan_kin_gokei;
		//	}
		//	set
		//	{
		//		this._tukibetu_yosan_kin_gokei = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON1_YOSANGOKEI_KIN(部門１予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon1_yosangokei_kin
		//{
		//	get
		//	{
		//		return this._bumon1_yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._bumon1_yosangokei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON2_YOSANGOKEI_KIN(部門２予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon2_yosangokei_kin
		//{
		//	get
		//	{
		//		return this._bumon2_yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._bumon2_yosangokei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON3_YOSANGOKEI_KIN(部門３予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon3_yosangokei_kin
		//{
		//	get
		//	{
		//		return this._bumon3_yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._bumon3_yosangokei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON4_YOSANGOKEI_KIN(部門４予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon4_yosangokei_kin
		//{
		//	get
		//	{
		//		return this._bumon4_yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._bumon4_yosangokei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON5_YOSANGOKEI_KIN(部門５予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon5_yosangokei_kin
		//{
		//	get
		//	{
		//		return this._bumon5_yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._bumon5_yosangokei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSANGOKEI_KIN(予算額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosangokei_kin
		//{
		//	get
		//	{
		//		return this._yosangokei_kin;
		//	}
		//	set
		//	{
		//		this._yosangokei_kin = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf060f01FormCondition() : base()
		{
		}
		#endregion
	}
}
