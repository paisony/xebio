using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Te130p01.Formvo
{
  /// <summary>
  /// Te130f02のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Te130f02FormCondition : IConditionVO
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
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		//private string _denpyo_bango;
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値
		/// </summary>
		//private string _scm_cd;
		/// <summary>
		/// 項目「JYURYOKAISYA_CD(入荷会社コード)」の値
		/// </summary>
		//private string _jyuryokaisya_cd;
		/// <summary>
		/// 項目「NYUKAKAISYA_NM(入荷会社名称)」の値
		/// </summary>
		//private string _nyukakaisya_nm;
		/// <summary>
		/// 項目「JYURYOTEN_CD(入荷店コード)」の値
		/// </summary>
		//private string _jyuryoten_cd;
		/// <summary>
		/// 項目「JURYOTEN_NM(入荷店名称)」の値
		/// </summary>
		//private string _juryoten_nm;
		/// <summary>
		/// 項目「NYUKATAN_CD(入荷担当者コード)」の値
		/// </summary>
		//private string _nyukatan_cd;
		/// <summary>
		/// 項目「NYUKATAN_NM(入荷担当者名称)」の値
		/// </summary>
		//private string _nyukatan_nm;
		/// <summary>
		/// 項目「JYURYO_YMD(入荷日)」の値
		/// </summary>
		//private string _jyuryo_ymd;
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD(出荷会社コード)」の値
		/// </summary>
		//private string _syukkakaisya_cd;
		/// <summary>
		/// 項目「SYUKKAKAISYA_NM(出荷会社名称)」の値
		/// </summary>
		//private string _syukkakaisya_nm;
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店コード)」の値
		/// </summary>
		//private string _syukkaten_cd;
		/// <summary>
		/// 項目「SYUKKATENPO_NM(出荷店舗名)」の値
		/// </summary>
		//private string _syukkatenpo_nm;
		/// <summary>
		/// 項目「SYUKKATAN_CD(出荷担当者コード)」の値
		/// </summary>
		//private string _syukkatan_cd;
		/// <summary>
		/// 項目「SYUKKATAN_NM(出荷担当者名称)」の値
		/// </summary>
		//private string _syukkatan_nm;
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値
		/// </summary>
		//private string _syukka_ymd;
		/// <summary>
		/// 項目「SYORINM(処理名称)」の値
		/// </summary>
		//private string _syorinm;
		/// <summary>
		/// 項目「SYORIYMD(処理日)」の値
		/// </summary>
		//private string _syoriymd;
		/// <summary>
		/// 項目「SYORI_TM(処理時間)」の値
		/// </summary>
		//private string _syori_tm;
		/// <summary>
		/// 項目「NYUKAYOTEI_SU_GOKEI(入荷予定数合計)」の値
		/// </summary>
		//private string _nyukayotei_su_gokei;
		/// <summary>
		/// 項目「NYUKAJISSEKI_SU_GOKEI(入荷実績数合計)」の値
		/// </summary>
		//private string _nyukajisseki_su_gokei;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI(原価金額合計)」の値
		/// </summary>
		//private string _genka_kin_gokei;


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
		/// 項目「DENPYO_BANGO(伝票番号)」の値を取得または設定する。
		/// </summary>
		//public virtual string Denpyo_bango
		//{
		//	get
		//	{
		//		return this._denpyo_bango;
		//	}
		//	set
		//	{
		//		this._denpyo_bango = value;
		//	}
		//}
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Scm_cd
		//{
		//	get
		//	{
		//		return this._scm_cd;
		//	}
		//	set
		//	{
		//		this._scm_cd = value;
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
		/// 項目「NYUKAKAISYA_NM(入荷会社名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukakaisya_nm
		//{
		//	get
		//	{
		//		return this._nyukakaisya_nm;
		//	}
		//	set
		//	{
		//		this._nyukakaisya_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURYOTEN_CD(入荷店コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuryoten_cd
		//{
		//	get
		//	{
		//		return this._jyuryoten_cd;
		//	}
		//	set
		//	{
		//		this._jyuryoten_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「JURYOTEN_NM(入荷店名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Juryoten_nm
		//{
		//	get
		//	{
		//		return this._juryoten_nm;
		//	}
		//	set
		//	{
		//		this._juryoten_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYUKATAN_CD(入荷担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukatan_cd
		//{
		//	get
		//	{
		//		return this._nyukatan_cd;
		//	}
		//	set
		//	{
		//		this._nyukatan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYUKATAN_NM(入荷担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukatan_nm
		//{
		//	get
		//	{
		//		return this._nyukatan_nm;
		//	}
		//	set
		//	{
		//		this._nyukatan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「JYURYO_YMD(入荷日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Jyuryo_ymd
		//{
		//	get
		//	{
		//		return this._jyuryo_ymd;
		//	}
		//	set
		//	{
		//		this._jyuryo_ymd = value;
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
		/// 項目「SYUKKAKAISYA_NM(出荷会社名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkakaisya_nm
		//{
		//	get
		//	{
		//		return this._syukkakaisya_nm;
		//	}
		//	set
		//	{
		//		this._syukkakaisya_nm = value;
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
		/// <summary>
		/// 項目「SYUKKATENPO_NM(出荷店舗名)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkatenpo_nm
		//{
		//	get
		//	{
		//		return this._syukkatenpo_nm;
		//	}
		//	set
		//	{
		//		this._syukkatenpo_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYUKKATAN_CD(出荷担当者コード)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkatan_cd
		//{
		//	get
		//	{
		//		return this._syukkatan_cd;
		//	}
		//	set
		//	{
		//		this._syukkatan_cd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYUKKATAN_NM(出荷担当者名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukkatan_nm
		//{
		//	get
		//	{
		//		return this._syukkatan_nm;
		//	}
		//	set
		//	{
		//		this._syukkatan_nm = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syukka_ymd
		//{
		//	get
		//	{
		//		return this._syukka_ymd;
		//	}
		//	set
		//	{
		//		this._syukka_ymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYORINM(処理名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syorinm
		//{
		//	get
		//	{
		//		return this._syorinm;
		//	}
		//	set
		//	{
		//		this._syorinm = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYORIYMD(処理日)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syoriymd
		//{
		//	get
		//	{
		//		return this._syoriymd;
		//	}
		//	set
		//	{
		//		this._syoriymd = value;
		//	}
		//}
		/// <summary>
		/// 項目「SYORI_TM(処理時間)」の値を取得または設定する。
		/// </summary>
		//public virtual string Syori_tm
		//{
		//	get
		//	{
		//		return this._syori_tm;
		//	}
		//	set
		//	{
		//		this._syori_tm = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYUKAYOTEI_SU_GOKEI(入荷予定数合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukayotei_su_gokei
		//{
		//	get
		//	{
		//		return this._nyukayotei_su_gokei;
		//	}
		//	set
		//	{
		//		this._nyukayotei_su_gokei = value;
		//	}
		//}
		/// <summary>
		/// 項目「NYUKAJISSEKI_SU_GOKEI(入荷実績数合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Nyukajisseki_su_gokei
		//{
		//	get
		//	{
		//		return this._nyukajisseki_su_gokei;
		//	}
		//	set
		//	{
		//		this._nyukajisseki_su_gokei = value;
		//	}
		//}
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI(原価金額合計)」の値を取得または設定する。
		/// </summary>
		//public virtual string Genka_kin_gokei
		//{
		//	get
		//	{
		//		return this._genka_kin_gokei;
		//	}
		//	set
		//	{
		//		this._genka_kin_gokei = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te130f02FormCondition() : base()
		{
		}
		#endregion
	}
}
