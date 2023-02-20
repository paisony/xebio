using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Ta080p01.Formvo
{
  /// <summary>
  /// Ta080f03のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Ta080f03FormCondition : IConditionVO
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
		/// 項目「MEISAI_MODENO(明細モードNO)」の値
		/// </summary>
		//private string _meisai_modeno;
		/// <summary>
		/// 項目「MEISAI_STKMODENO(明細選択モードNO)」の値
		/// </summary>
		//private string _meisai_stkmodeno;
		/// <summary>
		/// 項目「YOSAN_YMD(年月度)」の値
		/// </summary>
		//private string _yosan_ymd;
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠グループコード)」の値
		/// </summary>
		//private string _yosan_cd;
		/// <summary>
		/// 項目「YOSAN_NM(仕入枠グループ名)」の値
		/// </summary>
		//private string _yosan_nm;
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値
		/// </summary>
		//private string _yosan_kin;
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値
		/// </summary>
		//private string _misinsei_su;
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値
		/// </summary>
		//private string _misinsei_kin;
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値
		/// </summary>
		//private string _apply_su;
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値
		/// </summary>
		//private string _apply_kin;
		/// <summary>
		/// 項目「JISSEKI_SU(実績数)」の値
		/// </summary>
		//private string _jisseki_su;
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値
		/// </summary>
		//private string _jisseki_kin;
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値
		/// </summary>
		//private string _zan_kin;
		/// <summary>
		/// 項目「YOSAN_YMD1(年月度1)」の値
		/// </summary>
		//private string _yosan_ymd1;
		/// <summary>
		/// 項目「YOSAN_CD1(仕入枠グループコード1)」の値
		/// </summary>
		//private string _yosan_cd1;
		/// <summary>
		/// 項目「YOSAN_NM1(仕入枠グループ名1)」の値
		/// </summary>
		//private string _yosan_nm1;
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
		/// 項目「HINSYU_CD_ALL(品種-ALL)」の値
		/// </summary>
		//private string _hinsyu_cd_all;
		/// <summary>
		/// 項目「HINSYU_CD1(品種-1)」の値
		/// </summary>
		//private string _hinsyu_cd1;
		/// <summary>
		/// 項目「HINSYU_CD2(品種-2)」の値
		/// </summary>
		//private string _hinsyu_cd2;
		/// <summary>
		/// 項目「HINSYU_CD3(品種-3)」の値
		/// </summary>
		//private string _hinsyu_cd3;
		/// <summary>
		/// 項目「HINSYU_CD4(品種-4)」の値
		/// </summary>
		//private string _hinsyu_cd4;
		/// <summary>
		/// 項目「HINSYU_CD5(品種-5)」の値
		/// </summary>
		//private string _hinsyu_cd5;
		/// <summary>
		/// 項目「HINSYU_CD6(品種-6)」の値
		/// </summary>
		//private string _hinsyu_cd6;
		/// <summary>
		/// 項目「HINSYU_CD7(品種-7)」の値
		/// </summary>
		//private string _hinsyu_cd7;
		/// <summary>
		/// 項目「HINSYU_CD8(品種-8)」の値
		/// </summary>
		//private string _hinsyu_cd8;
		/// <summary>
		/// 項目「HINSYU_CD9(品種-9)」の値
		/// </summary>
		//private string _hinsyu_cd9;
		/// <summary>
		/// 項目「BURANDO_CD(ブランドコード)」の値
		/// </summary>
		//private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド名)」の値
		/// </summary>
		//private string _burando_nm;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(旧自社品番)」の値
		/// </summary>
		//private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		//private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		//private string _scan_cd;
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値
		/// </summary>
		//private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値
		/// </summary>
		//private string _add_ymd_to;
		/// <summary>
		/// 項目「TANTOSYA_CD(登録担当者コード)」の値
		/// </summary>
		//private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM(登録担当者名)」の値
		/// </summary>
		//private string _hanbaiin_nm;
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由コード1)」の値
		/// </summary>
		//private string _irairiyu_cd1;
		/// <summary>
		/// 項目「IRAIRIYU_CD2(依頼理由コード２)」の値
		/// </summary>
		//private string _irairiyu_cd2;
		/// <summary>
		/// 項目「HYOKA_KB_MISE(店評価)」の値
		/// </summary>
		//private string _hyoka_kb_mise;
		/// <summary>
		/// 項目「HYOKA_KB_ALL(全評価)」の値
		/// </summary>
		//private string _hyoka_kb_all;
		/// <summary>
		/// 項目「SORTKB1(並び順１)」の値
		/// </summary>
		//private string _sortkb1;
		/// <summary>
		/// 項目「SORTOPTIONKB1(並び順１昇降)」の値
		/// </summary>
		//private string _sortoptionkb1;
		/// <summary>
		/// 項目「SORTKB2(並び順２)」の値
		/// </summary>
		//private string _sortkb2;
		/// <summary>
		/// 項目「SORTOPTIONKB2(並び順２昇降)」の値
		/// </summary>
		//private string _sortoptionkb2;
		/// <summary>
		/// 項目「SORTKB3(並び順３)」の値
		/// </summary>
		//private string _sortkb3;
		/// <summary>
		/// 項目「SORTOPTIONKB3(並び順３昇降)」の値
		/// </summary>
		//private string _sortoptionkb3;
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計依頼数量)」の値
		/// </summary>
		//private string _gokei_irai_su;
		/// <summary>
		/// 項目「GOKEI_GENKAKIN(合計原価金額)」の値
		/// </summary>
		//private string _gokei_genkakin;
		/// <summary>
		/// 項目「FOOTER_ZAN_KIN(残金額１)」の値
		/// </summary>
		//private string _footer_zan_kin;


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
		/// 項目「MEISAI_MODENO(明細モードNO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisai_modeno
		//{
		//	get
		//	{
		//		return this._meisai_modeno;
		//	}
		//	set
		//	{
		//		this._meisai_modeno = value;
		//	}
		//}
		/// <summary>
		/// 項目「MEISAI_STKMODENO(明細選択モードNO)」の値を取得または設定する。
		/// </summary>
		//public virtual string Meisai_stkmodeno
		//{
		//	get
		//	{
		//		return this._meisai_stkmodeno;
		//	}
		//	set
		//	{
		//		this._meisai_stkmodeno = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_YMD(年月度)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_ymd
		//{
		//	get
		//	{
		//		return this._yosan_ymd;
		//	}
		//	set
		//	{
		//		this._yosan_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠グループコード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_cd
		//{
		//	get
		//	{
		//		return this._yosan_cd;
		//	}
		//	set
		//	{
		//		this._yosan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_NM(仕入枠グループ名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_nm
		//{
		//	get
		//	{
		//		return this._yosan_nm;
		//	}
		//	set
		//	{
		//		this._yosan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_kin
		//{
		//	get
		//	{
		//		return this._yosan_kin;
		//	}
		//	set
		//	{
		//		this._yosan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Misinsei_su
		//{
		//	get
		//	{
		//		return this._misinsei_su;
		//	}
		//	set
		//	{
		//		this._misinsei_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Misinsei_kin
		//{
		//	get
		//	{
		//		return this._misinsei_kin;
		//	}
		//	set
		//	{
		//		this._misinsei_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_su
		//{
		//	get
		//	{
		//		return this._apply_su;
		//	}
		//	set
		//	{
		//		this._apply_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_kin
		//{
		//	get
		//	{
		//		return this._apply_kin;
		//	}
		//	set
		//	{
		//		this._apply_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「JISSEKI_SU(実績数)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jisseki_su
		//{
		//	get
		//	{
		//		return this._jisseki_su;
		//	}
		//	set
		//	{
		//		this._jisseki_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jisseki_kin
		//{
		//	get
		//	{
		//		return this._jisseki_kin;
		//	}
		//	set
		//	{
		//		this._jisseki_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Zan_kin
		//{
		//	get
		//	{
		//		return this._zan_kin;
		//	}
		//	set
		//	{
		//		this._zan_kin = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_YMD1(年月度1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_ymd1
		//{
		//	get
		//	{
		//		return this._yosan_ymd1;
		//	}
		//	set
		//	{
		//		this._yosan_ymd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_CD1(仕入枠グループコード1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_cd1
		//{
		//	get
		//	{
		//		return this._yosan_cd1;
		//	}
		//	set
		//	{
		//		this._yosan_cd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_NM1(仕入枠グループ名1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_nm1
		//{
		//	get
		//	{
		//		return this._yosan_nm1;
		//	}
		//	set
		//	{
		//		this._yosan_nm1 = value;
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
		/// 項目「HINSYU_CD_ALL(品種-ALL)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd_all
		//{
		//	get
		//	{
		//		return this._hinsyu_cd_all;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd_all = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD1(品種-1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd1
		//{
		//	get
		//	{
		//		return this._hinsyu_cd1;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD2(品種-2)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd2
		//{
		//	get
		//	{
		//		return this._hinsyu_cd2;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD3(品種-3)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd3
		//{
		//	get
		//	{
		//		return this._hinsyu_cd3;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD4(品種-4)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd4
		//{
		//	get
		//	{
		//		return this._hinsyu_cd4;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd4 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD5(品種-5)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd5
		//{
		//	get
		//	{
		//		return this._hinsyu_cd5;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd5 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD6(品種-6)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd6
		//{
		//	get
		//	{
		//		return this._hinsyu_cd6;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd6 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD7(品種-7)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd7
		//{
		//	get
		//	{
		//		return this._hinsyu_cd7;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd7 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD8(品種-8)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd8
		//{
		//	get
		//	{
		//		return this._hinsyu_cd8;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd8 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HINSYU_CD9(品種-9)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hinsyu_cd9
		//{
		//	get
		//	{
		//		return this._hinsyu_cd9;
		//	}
		//	set
		//	{
		//		this._hinsyu_cd9 = value;
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
		/// 項目「TANTOSYA_CD(登録担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Tantosya_cd
		//{
		//	get
		//	{
		//		return this._tantosya_cd;
		//	}
		//	set
		//	{
		//		this._tantosya_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「HANBAIIN_NM(登録担当者名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hanbaiin_nm
		//{
		//	get
		//	{
		//		return this._hanbaiin_nm;
		//	}
		//	set
		//	{
		//		this._hanbaiin_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由コード1)」の値を取得または設定する。
		/// </summary>
		//public virtual string Irairiyu_cd1
		//{
		//	get
		//	{
		//		return this._irairiyu_cd1;
		//	}
		//	set
		//	{
		//		this._irairiyu_cd1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「IRAIRIYU_CD2(依頼理由コード２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Irairiyu_cd2
		//{
		//	get
		//	{
		//		return this._irairiyu_cd2;
		//	}
		//	set
		//	{
		//		this._irairiyu_cd2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「HYOKA_KB_MISE(店評価)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hyoka_kb_mise
		//{
		//	get
		//	{
		//		return this._hyoka_kb_mise;
		//	}
		//	set
		//	{
		//		this._hyoka_kb_mise = value;
		//	}
		//}
		/// <summary>
		/// 項目「HYOKA_KB_ALL(全評価)」の値を取得または設定する。
		/// </summary>
		//public virtual string Hyoka_kb_all
		//{
		//	get
		//	{
		//		return this._hyoka_kb_all;
		//	}
		//	set
		//	{
		//		this._hyoka_kb_all = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTKB1(並び順１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortkb1
		//{
		//	get
		//	{
		//		return this._sortkb1;
		//	}
		//	set
		//	{
		//		this._sortkb1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTOPTIONKB1(並び順１昇降)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortoptionkb1
		//{
		//	get
		//	{
		//		return this._sortoptionkb1;
		//	}
		//	set
		//	{
		//		this._sortoptionkb1 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTKB2(並び順２)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortkb2
		//{
		//	get
		//	{
		//		return this._sortkb2;
		//	}
		//	set
		//	{
		//		this._sortkb2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTOPTIONKB2(並び順２昇降)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortoptionkb2
		//{
		//	get
		//	{
		//		return this._sortoptionkb2;
		//	}
		//	set
		//	{
		//		this._sortoptionkb2 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTKB3(並び順３)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortkb3
		//{
		//	get
		//	{
		//		return this._sortkb3;
		//	}
		//	set
		//	{
		//		this._sortkb3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「SORTOPTIONKB3(並び順３昇降)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sortoptionkb3
		//{
		//	get
		//	{
		//		return this._sortoptionkb3;
		//	}
		//	set
		//	{
		//		this._sortoptionkb3 = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計依頼数量)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_irai_su
		//{
		//	get
		//	{
		//		return this._gokei_irai_su;
		//	}
		//	set
		//	{
		//		this._gokei_irai_su = value;
		//	}
		//}
		/// <summary>
		/// 項目「GOKEI_GENKAKIN(合計原価金額)」の値を取得または設定する。
		/// </summary>
		//public virtual string Gokei_genkakin
		//{
		//	get
		//	{
		//		return this._gokei_genkakin;
		//	}
		//	set
		//	{
		//		this._gokei_genkakin = value;
		//	}
		//}
		/// <summary>
		/// 項目「FOOTER_ZAN_KIN(残金額１)」の値を取得または設定する。
		/// </summary>
		//public virtual string Footer_zan_kin
		//{
		//	get
		//	{
		//		return this._footer_zan_kin;
		//	}
		//	set
		//	{
		//		this._footer_zan_kin = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080f03FormCondition() : base()
		{
		}
		#endregion
	}
}
