using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Ta080p01.Formvo
{
  /// <summary>
  /// Ta080f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Ta080f01FormCondition : IConditionVO
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
		/// 項目「YOSAN_YMD_FROM(年月度ＦＲＯＭ)」の値
		/// </summary>
		//private string _yosan_ymd_from;
		/// <summary>
		/// 項目「YOSAN_YMD_TO(年月度ＴＯ)」の値
		/// </summary>
		//private string _yosan_ymd_to;
		/// <summary>
		/// 項目「YOSAN_CD_FROM(仕入枠グループコードＦＲＯＭ)」の値
		/// </summary>
		//private string _yosan_cd_from;
		/// <summary>
		/// 項目「YOSAN_NM_FROM(仕入枠グループ名ＦＲＯＭ)」の値
		/// </summary>
		//private string _yosan_nm_from;
		/// <summary>
		/// 項目「YOSAN_CD_TO(仕入枠グループコードＴＯ)」の値
		/// </summary>
		//private string _yosan_cd_to;
		/// <summary>
		/// 項目「YOSAN_NM_TO(仕入枠グループ名ＴＯ)」の値
		/// </summary>
		//private string _yosan_nm_to;
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
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値
		/// </summary>
		//private string _apply_ymd_from;
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値
		/// </summary>
		//private string _apply_ymd_to;
		/// <summary>
		/// 項目「SINSEI_SB(申請種別)」の値
		/// </summary>
		//private string _sinsei_sb;
		/// <summary>
		/// 項目「IRAIRIYU_CD(依頼理由コード)」の値
		/// </summary>
		//private string _irairiyu_cd;
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由コード1)」の値
		/// </summary>
		//private string _irairiyu_cd1;
		/// <summary>
		/// 項目「JOTAI_KBN(状態)」の値
		/// </summary>
		//private string _jotai_kbn;
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
		/// 項目「YOSAN_YMD_FROM(年月度ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_ymd_from
		//{
		//	get
		//	{
		//		return this._yosan_ymd_from;
		//	}
		//	set
		//	{
		//		this._yosan_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_YMD_TO(年月度ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_ymd_to
		//{
		//	get
		//	{
		//		return this._yosan_ymd_to;
		//	}
		//	set
		//	{
		//		this._yosan_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_CD_FROM(仕入枠グループコードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_cd_from
		//{
		//	get
		//	{
		//		return this._yosan_cd_from;
		//	}
		//	set
		//	{
		//		this._yosan_cd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_NM_FROM(仕入枠グループ名ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_nm_from
		//{
		//	get
		//	{
		//		return this._yosan_nm_from;
		//	}
		//	set
		//	{
		//		this._yosan_nm_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_CD_TO(仕入枠グループコードＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_cd_to
		//{
		//	get
		//	{
		//		return this._yosan_cd_to;
		//	}
		//	set
		//	{
		//		this._yosan_cd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「YOSAN_NM_TO(仕入枠グループ名ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Yosan_nm_to
		//{
		//	get
		//	{
		//		return this._yosan_nm_to;
		//	}
		//	set
		//	{
		//		this._yosan_nm_to = value;
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
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_ymd_from
		//{
		//	get
		//	{
		//		return this._apply_ymd_from;
		//	}
		//	set
		//	{
		//		this._apply_ymd_from = value;
		//	}
		//}
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値を取得または設定する。
		/// </summary>
		//public virtual string Apply_ymd_to
		//{
		//	get
		//	{
		//		return this._apply_ymd_to;
		//	}
		//	set
		//	{
		//		this._apply_ymd_to = value;
		//	}
		//}
		/// <summary>
		/// 項目「SINSEI_SB(申請種別)」の値を取得または設定する。
		/// </summary>
		//public virtual string Sinsei_sb
		//{
		//	get
		//	{
		//		return this._sinsei_sb;
		//	}
		//	set
		//	{
		//		this._sinsei_sb = value;
		//	}
		//}
		/// <summary>
		/// 項目「IRAIRIYU_CD(依頼理由コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Irairiyu_cd
		//{
		//	get
		//	{
		//		return this._irairiyu_cd;
		//	}
		//	set
		//	{
		//		this._irairiyu_cd = value;
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
		/// 項目「JOTAI_KBN(状態)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jotai_kbn
		//{
		//	get
		//	{
		//		return this._jotai_kbn;
		//	}
		//	set
		//	{
		//		this._jotai_kbn = value;
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
		public Ta080f01FormCondition() : base()
		{
		}
		#endregion
	}
}
