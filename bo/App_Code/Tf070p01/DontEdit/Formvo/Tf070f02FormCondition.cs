using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tf070p01.Formvo
{
  /// <summary>
  /// Tf070f02のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tf070f02FormCondition : IConditionVO
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
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		//private string _stkmodeno;
		/// <summary>
		/// 項目「TONANHINKANRI_NO(盗難品管理番号)」の値
		/// </summary>
		//private string _tonanhinkanri_no;
		/// <summary>
		/// 項目「JIKOHASSEI_YMD(事故発生日)」の値
		/// </summary>
		//private string _jikohassei_ymd;
		/// <summary>
		/// 項目「HOKOKU_YMD(報告日)」の値
		/// </summary>
		//private string _hokoku_ymd;
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告担当者コード)」の値
		/// </summary>
		//private string _hokokutan_cd;
		/// <summary>
		/// 項目「HOKOKUTAN_NM(報告担当者名称)」の値
		/// </summary>
		//private string _hokokutan_nm;
		/// <summary>
		/// 項目「TENTYOTAN_CD(店長担当者コード)」の値
		/// </summary>
		//private string _tentyotan_cd;
		/// <summary>
		/// 項目「TENTYOTAN_NM(店長担当者名称)」の値
		/// </summary>
		//private string _tentyotan_nm;
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD(警察届出日)」の値
		/// </summary>
		//private string _keisatsutodoke_ymd;
		/// <summary>
		/// 項目「TODOKEDESAKIKEISATSU_NM(届出先警察署名)」の値
		/// </summary>
		//private string _todokedesakikeisatsu_nm;
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値
		/// </summary>
		//private string _jyuri_no;
		/// <summary>
		/// 項目「GOKEISINSEI_SU(合計申請数)」の値
		/// </summary>
		//private string _gokeisinsei_su;
		/// <summary>
		/// 項目「GOKEIJYURI_SU(合計受理数)」の値
		/// </summary>
		//private string _gokeijyuri_su;
		/// <summary>
		/// 項目「GOKEIBAIKA_KIN(合計売価金額)」の値
		/// </summary>
		//private string _gokeibaika_kin;


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
		/// 項目「TONANHINKANRI_NO(盗難品管理番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tonanhinkanri_no
		//{
		//	get
		//	{
		//		return this._tonanhinkanri_no;
		//	}
		//	set
		//	{
		//		this._tonanhinkanri_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「JIKOHASSEI_YMD(事故発生日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jikohassei_ymd
		//{
		//	get
		//	{
		//		return this._jikohassei_ymd;
		//	}
		//	set
		//	{
		//		this._jikohassei_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HOKOKU_YMD(報告日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hokoku_ymd
		//{
		//	get
		//	{
		//		return this._hokoku_ymd;
		//	}
		//	set
		//	{
		//		this._hokoku_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hokokutan_cd
		//{
		//	get
		//	{
		//		return this._hokokutan_cd;
		//	}
		//	set
		//	{
		//		this._hokokutan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HOKOKUTAN_NM(報告担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hokokutan_nm
		//{
		//	get
		//	{
		//		return this._hokokutan_nm;
		//	}
		//	set
		//	{
		//		this._hokokutan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENTYOTAN_CD(店長担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tentyotan_cd
		//{
		//	get
		//	{
		//		return this._tentyotan_cd;
		//	}
		//	set
		//	{
		//		this._tentyotan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「TENTYOTAN_NM(店長担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tentyotan_nm
		//{
		//	get
		//	{
		//		return this._tentyotan_nm;
		//	}
		//	set
		//	{
		//		this._tentyotan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD(警察届出日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Keisatsutodoke_ymd
		//{
		//	get
		//	{
		//		return this._keisatsutodoke_ymd;
		//	}
		//	set
		//	{
		//		this._keisatsutodoke_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「TODOKEDESAKIKEISATSU_NM(届出先警察署名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Todokedesakikeisatsu_nm
		//{
		//	get
		//	{
		//		return this._todokedesakikeisatsu_nm;
		//	}
		//	set
		//	{
		//		this._todokedesakikeisatsu_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuri_no
		//{
		//	get
		//	{
		//		return this._jyuri_no;
		//	}
		//	set
		//	{
		//		this._jyuri_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEISINSEI_SU(合計申請数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeisinsei_su
		//{
		//	get
		//	{
		//		return this._gokeisinsei_su;
		//	}
		//	set
		//	{
		//		this._gokeisinsei_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEIJYURI_SU(合計受理数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeijyuri_su
		//{
		//	get
		//	{
		//		return this._gokeijyuri_su;
		//	}
		//	set
		//	{
		//		this._gokeijyuri_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEIBAIKA_KIN(合計売価金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeibaika_kin
		//{
		//	get
		//	{
		//		return this._gokeibaika_kin;
		//	}
		//	set
		//	{
		//		this._gokeibaika_kin = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf070f02FormCondition() : base()
		{
		}
		#endregion
	}
}
