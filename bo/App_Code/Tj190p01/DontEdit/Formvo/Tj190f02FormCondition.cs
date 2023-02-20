using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tj190p01.Formvo
{
  /// <summary>
  /// Tj190f02のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tj190f02FormCondition : IConditionVO
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
		/// 項目「TENPO_CD_HDN(店舗コード隠し)」の値
		/// </summary>
		//private string _tenpo_cd_hdn;
		/// <summary>
		/// 項目「NYURYOKU_YMD(入力日)」の値
		/// </summary>
		//private string _nyuryoku_ymd;
		/// <summary>
		/// 項目「RINTANA_KANRI_NO(臨棚管理№)」の値
		/// </summary>
		//private string _rintana_kanri_no;
		/// <summary>
		/// 項目「LOSS_KANRI_NO(ロス管理№)」の値
		/// </summary>
		//private string _loss_kanri_no;
		/// <summary>
		/// 項目「BUMON_CD_BO(部門コード)」の値
		/// </summary>
		//private string _bumon_cd_bo;
		/// <summary>
		/// 項目「BUMON_NM(部門名)」の値
		/// </summary>
		//private string _bumon_nm;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者コード)」の値
		/// </summary>
		//private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM(入力担当者名称)」の値
		/// </summary>
		//private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「LOSSKEISAN_YMD(ロス計算日)」の値
		/// </summary>
		//private string _losskeisan_ymd;
		/// <summary>
		/// 項目「LOSSKEISAN_TM(ロス計算時間)」の値
		/// </summary>
		//private string _losskeisan_tm;
		/// <summary>
		/// 項目「HINSYU_SITEI_FLG(品種指定フラグ)」の値
		/// </summary>
		//private string _hinsyu_sitei_flg;
		/// <summary>
		/// 項目「HINSYU_CD(品種コード)」の値
		/// </summary>
		//private string _hinsyu_cd;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種略名称)」の値
		/// </summary>
		//private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_SITEI_FLG(ブランド指定フラグ)」の値
		/// </summary>
		//private string _burando_sitei_flg;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「BURANDO_CD1(ブランドコード1)」の値
		/// </summary>
		//private string _burando_cd1;
		/// <summary>
		/// 項目「BURANDO_NM1(ブランド名1)」の値
		/// </summary>
		//private string _burando_nm1;
		/// <summary>
		/// 項目「BURANDO_CD2(ブランドコード2)」の値
		/// </summary>
		//private string _burando_cd2;
		/// <summary>
		/// 項目「BURANDO_NM2(ブランド名2)」の値
		/// </summary>
		//private string _burando_nm2;
		/// <summary>
		/// 項目「BURANDO_CD3(ブランドコード3)」の値
		/// </summary>
		//private string _burando_cd3;
		/// <summary>
		/// 項目「BURANDO_NM3(ブランド名3)」の値
		/// </summary>
		//private string _burando_nm3;
		/// <summary>
		/// 項目「BURANDO_CD4(ブランドコード4)」の値
		/// </summary>
		//private string _burando_cd4;
		/// <summary>
		/// 項目「BURANDO_NM4(ブランド名4)」の値
		/// </summary>
		//private string _burando_nm4;
		/// <summary>
		/// 項目「BURANDO_CD5(ブランドコード5)」の値
		/// </summary>
		//private string _burando_cd5;
		/// <summary>
		/// 項目「BURANDO_NM5(ブランド名5)」の値
		/// </summary>
		//private string _burando_nm5;
		/// <summary>
		/// 項目「BURANDO_CD6(ブランドコード6)」の値
		/// </summary>
		//private string _burando_cd6;
		/// <summary>
		/// 項目「BURANDO_NM6(ブランド名6)」の値
		/// </summary>
		//private string _burando_nm6;
		/// <summary>
		/// 項目「BURANDO_CD7(ブランドコード7)」の値
		/// </summary>
		//private string _burando_cd7;
		/// <summary>
		/// 項目「BURANDO_NM7(ブランド名7)」の値
		/// </summary>
		//private string _burando_nm7;
		/// <summary>
		/// 項目「GOKEITANAJITYOBO_SU(合計棚時帳簿数)」の値
		/// </summary>
		//private string _gokeitanajityobo_su;
		/// <summary>
		/// 項目「GOKEITANAJISEKISO_SU(合計棚時積送数)」の値
		/// </summary>
		//private string _gokeitanajisekiso_su;
		/// <summary>
		/// 項目「GOKEIJITANA_SU(合計実棚数)」の値
		/// </summary>
		//private string _gokeijitana_su;
		/// <summary>
		/// 項目「GOKEILOSS_SU(合計ロス数)」の値
		/// </summary>
		//private string _gokeiloss_su;
		/// <summary>
		/// 項目「GOKEILOSS_KIN(合計ロス金額)」の値
		/// </summary>
		//private string _gokeiloss_kin;


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
		/// 項目「TENPO_CD_HDN(店舗コード隠し)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tenpo_cd_hdn
		//{
		//	get
		//	{
		//		return this._tenpo_cd_hdn;
		//	}
		//	set
		//	{
		//		this._tenpo_cd_hdn = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYURYOKU_YMD(入力日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyuryoku_ymd
		//{
		//	get
		//	{
		//		return this._nyuryoku_ymd;
		//	}
		//	set
		//	{
		//		this._nyuryoku_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「RINTANA_KANRI_NO(臨棚管理№)」の値を取得または設定する。
		/// </summary>
		//public virtual string Rintana_kanri_no
		//{
		//	get
		//	{
		//		return this._rintana_kanri_no;
		//	}
		//	set
		//	{
		//		this._rintana_kanri_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「LOSS_KANRI_NO(ロス管理№)」の値を取得または設定する。
		/// </summary>
		//public virtual string Loss_kanri_no
		//{
		//	get
		//	{
		//		return this._loss_kanri_no;
		//	}
		//	set
		//	{
		//		this._loss_kanri_no = value;
		//	}
		//}
		/// <summary>
		/// 項目「BUMON_CD_BO(部門コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Bumon_cd_bo
		//{
		//	get
		//	{
		//		return this._bumon_cd_bo;
		//	}
		//	set
		//	{
		//		this._bumon_cd_bo = value;
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
		/// 項目「LOSSKEISAN_YMD(ロス計算日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Losskeisan_ymd
		//{
		//	get
		//	{
		//		return this._losskeisan_ymd;
		//	}
		//	set
		//	{
		//		this._losskeisan_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「LOSSKEISAN_TM(ロス計算時間)」の値を取得または設定する。
		/// </summary>
		//public virtual string Losskeisan_tm
		//{
		//	get
		//	{
		//		return this._losskeisan_tm;
		//	}
		//	set
		//	{
		//		this._losskeisan_tm = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_SITEI_FLG(品種指定フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_sitei_flg
		//{
		//	get
		//	{
		//		return this._hinsyu_sitei_flg;
		//	}
		//	set
		//	{
		//		this._hinsyu_sitei_flg = value;
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
		/// 項目「BURANDO_SITEI_FLG(ブランド指定フラグ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_sitei_flg
		//{
		//	get
		//	{
		//		return this._burando_sitei_flg;
		//	}
		//	set
		//	{
		//		this._burando_sitei_flg = value;
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
		/// 項目「BURANDO_CD1(ブランドコード1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd1
		//{
		//	get
		//	{
		//		return this._burando_cd1;
		//	}
		//	set
		//	{
		//		this._burando_cd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM1(ブランド名1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm1
		//{
		//	get
		//	{
		//		return this._burando_nm1;
		//	}
		//	set
		//	{
		//		this._burando_nm1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD2(ブランドコード2)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd2
		//{
		//	get
		//	{
		//		return this._burando_cd2;
		//	}
		//	set
		//	{
		//		this._burando_cd2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM2(ブランド名2)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm2
		//{
		//	get
		//	{
		//		return this._burando_nm2;
		//	}
		//	set
		//	{
		//		this._burando_nm2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD3(ブランドコード3)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd3
		//{
		//	get
		//	{
		//		return this._burando_cd3;
		//	}
		//	set
		//	{
		//		this._burando_cd3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM3(ブランド名3)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm3
		//{
		//	get
		//	{
		//		return this._burando_nm3;
		//	}
		//	set
		//	{
		//		this._burando_nm3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD4(ブランドコード4)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd4
		//{
		//	get
		//	{
		//		return this._burando_cd4;
		//	}
		//	set
		//	{
		//		this._burando_cd4 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM4(ブランド名4)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm4
		//{
		//	get
		//	{
		//		return this._burando_nm4;
		//	}
		//	set
		//	{
		//		this._burando_nm4 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD5(ブランドコード5)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd5
		//{
		//	get
		//	{
		//		return this._burando_cd5;
		//	}
		//	set
		//	{
		//		this._burando_cd5 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM5(ブランド名5)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm5
		//{
		//	get
		//	{
		//		return this._burando_nm5;
		//	}
		//	set
		//	{
		//		this._burando_nm5 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD6(ブランドコード6)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd6
		//{
		//	get
		//	{
		//		return this._burando_cd6;
		//	}
		//	set
		//	{
		//		this._burando_cd6 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM6(ブランド名6)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm6
		//{
		//	get
		//	{
		//		return this._burando_nm6;
		//	}
		//	set
		//	{
		//		this._burando_nm6 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_CD7(ブランドコード7)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_cd7
		//{
		//	get
		//	{
		//		return this._burando_cd7;
		//	}
		//	set
		//	{
		//		this._burando_cd7 = value;
		//	}
		//}
		/// <summary>
		/// 項目「BURANDO_NM7(ブランド名7)」の値を取得または設定する。
		/// </summary>
		//public virtual string Burando_nm7
		//{
		//	get
		//	{
		//		return this._burando_nm7;
		//	}
		//	set
		//	{
		//		this._burando_nm7 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEITANAJITYOBO_SU(合計棚時帳簿数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeitanajityobo_su
		//{
		//	get
		//	{
		//		return this._gokeitanajityobo_su;
		//	}
		//	set
		//	{
		//		this._gokeitanajityobo_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEITANAJISEKISO_SU(合計棚時積送数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeitanajisekiso_su
		//{
		//	get
		//	{
		//		return this._gokeitanajisekiso_su;
		//	}
		//	set
		//	{
		//		this._gokeitanajisekiso_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEIJITANA_SU(合計実棚数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeijitana_su
		//{
		//	get
		//	{
		//		return this._gokeijitana_su;
		//	}
		//	set
		//	{
		//		this._gokeijitana_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEILOSS_SU(合計ロス数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeiloss_su
		//{
		//	get
		//	{
		//		return this._gokeiloss_su;
		//	}
		//	set
		//	{
		//		this._gokeiloss_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEILOSS_KIN(合計ロス金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokeiloss_kin
		//{
		//	get
		//	{
		//		return this._gokeiloss_kin;
		//	}
		//	set
		//	{
		//		this._gokeiloss_kin = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj190f02FormCondition() : base()
		{
		}
		#endregion
	}
}
