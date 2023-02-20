using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta080p01.Formvo.Baseform
{
  /// <summary>
  /// Ta080f03のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f03BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値
		/// </summary>
		private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「MEISAI_MODENO()」の値
		/// </summary>
		private string _meisai_modeno;
		/// <summary>
		/// 項目「MEISAI_STKMODENO()」の値
		/// </summary>
		private string _meisai_stkmodeno;
		/// <summary>
		/// 項目「YOSAN_YMD(年月度)」の値
		/// </summary>
		private string _yosan_ymd;
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠ｸﾞﾙｰﾌﾟ)」の値
		/// </summary>
		private string _yosan_cd;
		/// <summary>
		/// 項目「YOSAN_NM()」の値
		/// </summary>
		private string _yosan_nm;
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値
		/// </summary>
		private string _yosan_kin;
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値
		/// </summary>
		private string _misinsei_su;
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値
		/// </summary>
		private string _misinsei_kin;
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値
		/// </summary>
		private string _apply_su;
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値
		/// </summary>
		private string _apply_kin;
		/// <summary>
		/// 項目「JISSEKI_SU(実績数)」の値
		/// </summary>
		private string _jisseki_su;
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値
		/// </summary>
		private string _jisseki_kin;
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値
		/// </summary>
		private string _zan_kin;
		/// <summary>
		/// 項目「YOSAN_YMD1(年月度)」の値
		/// </summary>
		private string _yosan_ymd1;
		/// <summary>
		/// 項目「YOSAN_CD1(仕入枠ｸﾞﾙｰﾌﾟ)」の値
		/// </summary>
		private string _yosan_cd1;
		/// <summary>
		/// 項目「YOSAN_NM1()」の値
		/// </summary>
		private string _yosan_nm1;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門ＦＲＯＭ)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門ＴＯ)」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「HINSYU_CD_ALL(ALL)」の値
		/// </summary>
		private string _hinsyu_cd_all;
		/// <summary>
		/// 項目「HINSYU_CD1(1)」の値
		/// </summary>
		private string _hinsyu_cd1;
		/// <summary>
		/// 項目「HINSYU_CD2(2)」の値
		/// </summary>
		private string _hinsyu_cd2;
		/// <summary>
		/// 項目「HINSYU_CD3(3)」の値
		/// </summary>
		private string _hinsyu_cd3;
		/// <summary>
		/// 項目「HINSYU_CD4(4)」の値
		/// </summary>
		private string _hinsyu_cd4;
		/// <summary>
		/// 項目「HINSYU_CD5(5)」の値
		/// </summary>
		private string _hinsyu_cd5;
		/// <summary>
		/// 項目「HINSYU_CD6(6)」の値
		/// </summary>
		private string _hinsyu_cd6;
		/// <summary>
		/// 項目「HINSYU_CD7(7)」の値
		/// </summary>
		private string _hinsyu_cd7;
		/// <summary>
		/// 項目「HINSYU_CD8(8)」の値
		/// </summary>
		private string _hinsyu_cd8;
		/// <summary>
		/// 項目「HINSYU_CD9(9)」の値
		/// </summary>
		private string _hinsyu_cd9;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日)」の値
		/// </summary>
		private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO()」の値
		/// </summary>
		private string _add_ymd_to;
		/// <summary>
		/// 項目「TANTOSYA_CD(登録担当者)」の値
		/// </summary>
		private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd1;
		/// <summary>
		/// 項目「IRAIRIYU_CD2(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd2;
		/// <summary>
		/// 項目「HYOKA_KB_MISE(評価)」の値
		/// </summary>
		private string _hyoka_kb_mise;
		/// <summary>
		/// 項目「HYOKA_KB_ALL()」の値
		/// </summary>
		private string _hyoka_kb_all;
		/// <summary>
		/// 項目「SORTKB1(並び順)」の値
		/// </summary>
		private string _sortkb1;
		/// <summary>
		/// 項目「SORTOPTIONKB1()」の値
		/// </summary>
		private string _sortoptionkb1;
		/// <summary>
		/// 項目「SORTKB2()」の値
		/// </summary>
		private string _sortkb2;
		/// <summary>
		/// 項目「SORTOPTIONKB2()」の値
		/// </summary>
		private string _sortoptionkb2;
		/// <summary>
		/// 項目「SORTKB3()」の値
		/// </summary>
		private string _sortkb3;
		/// <summary>
		/// 項目「SORTOPTIONKB3()」の値
		/// </summary>
		private string _sortoptionkb3;
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計)」の値
		/// </summary>
		private string _gokei_irai_su;
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値
		/// </summary>
		private string _gokei_genkakin;
		/// <summary>
		/// 項目「FOOTER_ZAN_KIN(残)」の値
		/// </summary>
		private string _footer_zan_kin;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Head_tenpo_cd
		{
			get
			{
				return this._head_tenpo_cd;
			}
			set
			{
				this._head_tenpo_cd = value;
			}
		}
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Head_tenpo_nm
		{
			get
			{
				return this._head_tenpo_nm;
			}
			set
			{
				this._head_tenpo_nm = value;
			}
		}
		/// <summary>
		/// 項目「STKMODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Stkmodeno
		{
			get
			{
				return this._stkmodeno;
			}
			set
			{
				this._stkmodeno = value;
			}
		}
		/// <summary>
		/// 項目「MEISAI_MODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisai_modeno
		{
			get
			{
				return this._meisai_modeno;
			}
			set
			{
				this._meisai_modeno = value;
			}
		}
		/// <summary>
		/// 項目「MEISAI_STKMODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisai_stkmodeno
		{
			get
			{
				return this._meisai_stkmodeno;
			}
			set
			{
				this._meisai_stkmodeno = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_YMD(年月度)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_ymd
		{
			get
			{
				return this._yosan_ymd;
			}
			set
			{
				this._yosan_ymd = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠ｸﾞﾙｰﾌﾟ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_cd
		{
			get
			{
				return this._yosan_cd;
			}
			set
			{
				this._yosan_cd = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_nm
		{
			get
			{
				return this._yosan_nm;
			}
			set
			{
				this._yosan_nm = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_kin
		{
			get
			{
				return this._yosan_kin;
			}
			set
			{
				this._yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string Misinsei_su
		{
			get
			{
				return this._misinsei_su;
			}
			set
			{
				this._misinsei_su = value;
			}
		}
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Misinsei_kin
		{
			get
			{
				return this._misinsei_kin;
			}
			set
			{
				this._misinsei_kin = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_su
		{
			get
			{
				return this._apply_su;
			}
			set
			{
				this._apply_su = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_kin
		{
			get
			{
				return this._apply_kin;
			}
			set
			{
				this._apply_kin = value;
			}
		}
		/// <summary>
		/// 項目「JISSEKI_SU(実績数)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisseki_su
		{
			get
			{
				return this._jisseki_su;
			}
			set
			{
				this._jisseki_su = value;
			}
		}
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisseki_kin
		{
			get
			{
				return this._jisseki_kin;
			}
			set
			{
				this._jisseki_kin = value;
			}
		}
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Zan_kin
		{
			get
			{
				return this._zan_kin;
			}
			set
			{
				this._zan_kin = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_YMD1(年月度)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_ymd1
		{
			get
			{
				return this._yosan_ymd1;
			}
			set
			{
				this._yosan_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_CD1(仕入枠ｸﾞﾙｰﾌﾟ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_cd1
		{
			get
			{
				return this._yosan_cd1;
			}
			set
			{
				this._yosan_cd1 = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_NM1()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_nm1
		{
			get
			{
				return this._yosan_nm1;
			}
			set
			{
				this._yosan_nm1 = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_from
		{
			get
			{
				return this._bumon_cd_from;
			}
			set
			{
				this._bumon_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_from
		{
			get
			{
				return this._bumon_nm_from;
			}
			set
			{
				this._bumon_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_TO(部門ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_to
		{
			get
			{
				return this._bumon_cd_to;
			}
			set
			{
				this._bumon_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_to
		{
			get
			{
				return this._bumon_nm_to;
			}
			set
			{
				this._bumon_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD_ALL(ALL)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd_all
		{
			get
			{
				return this._hinsyu_cd_all;
			}
			set
			{
				this._hinsyu_cd_all = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD1(1)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd1
		{
			get
			{
				return this._hinsyu_cd1;
			}
			set
			{
				this._hinsyu_cd1 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD2(2)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd2
		{
			get
			{
				return this._hinsyu_cd2;
			}
			set
			{
				this._hinsyu_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD3(3)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd3
		{
			get
			{
				return this._hinsyu_cd3;
			}
			set
			{
				this._hinsyu_cd3 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD4(4)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd4
		{
			get
			{
				return this._hinsyu_cd4;
			}
			set
			{
				this._hinsyu_cd4 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD5(5)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd5
		{
			get
			{
				return this._hinsyu_cd5;
			}
			set
			{
				this._hinsyu_cd5 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD6(6)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd6
		{
			get
			{
				return this._hinsyu_cd6;
			}
			set
			{
				this._hinsyu_cd6 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD7(7)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd7
		{
			get
			{
				return this._hinsyu_cd7;
			}
			set
			{
				this._hinsyu_cd7 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD8(8)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd8
		{
			get
			{
				return this._hinsyu_cd8;
			}
			set
			{
				this._hinsyu_cd8 = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD9(9)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd9
		{
			get
			{
				return this._hinsyu_cd9;
			}
			set
			{
				this._hinsyu_cd9 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd
		{
			get
			{
				return this._burando_cd;
			}
			set
			{
				this._burando_cd = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm
		{
			get
			{
				return this._burando_nm;
			}
			set
			{
				this._burando_nm = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn
		{
			get
			{
				return this._old_jisya_hbn;
			}
			set
			{
				this._old_jisya_hbn = value;
			}
		}
		/// <summary>
		/// 項目「MAKER_HBN()」の値を取得または設定する。
		/// </summary>
		public virtual string Maker_hbn
		{
			get
			{
				return this._maker_hbn;
			}
			set
			{
				this._maker_hbn = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd
		{
			get
			{
				return this._scan_cd;
			}
			set
			{
				this._scan_cd = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日)」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_from
		{
			get
			{
				return this._add_ymd_from;
			}
			set
			{
				this._add_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_to
		{
			get
			{
				return this._add_ymd_to;
			}
			set
			{
				this._add_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD(登録担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd
		{
			get
			{
				return this._tantosya_cd;
			}
			set
			{
				this._tantosya_cd = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm
		{
			get
			{
				return this._hanbaiin_nm;
			}
			set
			{
				this._hanbaiin_nm = value;
			}
		}
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd1
		{
			get
			{
				return this._irairiyu_cd1;
			}
			set
			{
				this._irairiyu_cd1 = value;
			}
		}
		/// <summary>
		/// 項目「IRAIRIYU_CD2(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd2
		{
			get
			{
				return this._irairiyu_cd2;
			}
			set
			{
				this._irairiyu_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「HYOKA_KB_MISE(評価)」の値を取得または設定する。
		/// </summary>
		public virtual string Hyoka_kb_mise
		{
			get
			{
				return this._hyoka_kb_mise;
			}
			set
			{
				this._hyoka_kb_mise = value;
			}
		}
		/// <summary>
		/// 項目「HYOKA_KB_ALL()」の値を取得または設定する。
		/// </summary>
		public virtual string Hyoka_kb_all
		{
			get
			{
				return this._hyoka_kb_all;
			}
			set
			{
				this._hyoka_kb_all = value;
			}
		}
		/// <summary>
		/// 項目「SORTKB1(並び順)」の値を取得または設定する。
		/// </summary>
		public virtual string Sortkb1
		{
			get
			{
				return this._sortkb1;
			}
			set
			{
				this._sortkb1 = value;
			}
		}
		/// <summary>
		/// 項目「SORTOPTIONKB1()」の値を取得または設定する。
		/// </summary>
		public virtual string Sortoptionkb1
		{
			get
			{
				return this._sortoptionkb1;
			}
			set
			{
				this._sortoptionkb1 = value;
			}
		}
		/// <summary>
		/// 項目「SORTKB2()」の値を取得または設定する。
		/// </summary>
		public virtual string Sortkb2
		{
			get
			{
				return this._sortkb2;
			}
			set
			{
				this._sortkb2 = value;
			}
		}
		/// <summary>
		/// 項目「SORTOPTIONKB2()」の値を取得または設定する。
		/// </summary>
		public virtual string Sortoptionkb2
		{
			get
			{
				return this._sortoptionkb2;
			}
			set
			{
				this._sortoptionkb2 = value;
			}
		}
		/// <summary>
		/// 項目「SORTKB3()」の値を取得または設定する。
		/// </summary>
		public virtual string Sortkb3
		{
			get
			{
				return this._sortkb3;
			}
			set
			{
				this._sortkb3 = value;
			}
		}
		/// <summary>
		/// 項目「SORTOPTIONKB3()」の値を取得または設定する。
		/// </summary>
		public virtual string Sortoptionkb3
		{
			get
			{
				return this._sortoptionkb3;
			}
			set
			{
				this._sortoptionkb3 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_irai_su
		{
			get
			{
				return this._gokei_irai_su;
			}
			set
			{
				this._gokei_irai_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_genkakin
		{
			get
			{
				return this._gokei_genkakin;
			}
			set
			{
				this._gokei_genkakin = value;
			}
		}
		/// <summary>
		/// 項目「FOOTER_ZAN_KIN(残)」の値を取得または設定する。
		/// </summary>
		public virtual string Footer_zan_kin
		{
			get
			{
				return this._footer_zan_kin;
			}
			set
			{
				this._footer_zan_kin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080f03BaseForm() : base()
		{
		}
		#endregion

		#region メソッド
		
		#region IFormVO メンバ
		/// <summary>
		/// 明細リストを取得します。
		/// 引数の明細IDに対応する明細リストが存在しない場合はnullを返却します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細リスト</returns>
		public virtual IDataList GetList(string listId)
		{
			if (listId.Equals("M1"))
			{
				return m1List;
			}
			return null;
		}

		/// <summary>
		/// 明細リストを設定します。
		/// 引数の明細IDに対応する明細リストが存在しない場合は何もしません。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <param name="list">全件リスト</param>
		public virtual void SetList(string listId, ICollection list)
		{
			if (listId.Equals("M1"))
			{
				m1List.SetAll(list);
			}
		}

		/// <summary>
		/// 明細の現在のページの画面表示分のリストを取得します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細の現在のページの画面表示分のリスト</returns>
		public virtual IList GetPageViewList(string listId)
		{
			if (listId.Equals("M1"))
			{
				return m1List.GetPageViewList();
			}
			return null;
		}
		#endregion
		/// <summary>
		/// このオブジェクトの内容を文字列で取得する。
		/// </summary>
		/// <returns>オブジェクトの内容</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
		
			sb.AppendLine("カード部：");
			sb.Append("Head_tenpo_cd:").Append(this._head_tenpo_cd).AppendLine();
			sb.Append("Head_tenpo_nm:").Append(this._head_tenpo_nm).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Meisai_modeno:").Append(this._meisai_modeno).AppendLine();
			sb.Append("Meisai_stkmodeno:").Append(this._meisai_stkmodeno).AppendLine();
			sb.Append("Yosan_ymd:").Append(this._yosan_ymd).AppendLine();
			sb.Append("Yosan_cd:").Append(this._yosan_cd).AppendLine();
			sb.Append("Yosan_nm:").Append(this._yosan_nm).AppendLine();
			sb.Append("Yosan_kin:").Append(this._yosan_kin).AppendLine();
			sb.Append("Misinsei_su:").Append(this._misinsei_su).AppendLine();
			sb.Append("Misinsei_kin:").Append(this._misinsei_kin).AppendLine();
			sb.Append("Apply_su:").Append(this._apply_su).AppendLine();
			sb.Append("Apply_kin:").Append(this._apply_kin).AppendLine();
			sb.Append("Jisseki_su:").Append(this._jisseki_su).AppendLine();
			sb.Append("Jisseki_kin:").Append(this._jisseki_kin).AppendLine();
			sb.Append("Zan_kin:").Append(this._zan_kin).AppendLine();
			sb.Append("Yosan_ymd1:").Append(this._yosan_ymd1).AppendLine();
			sb.Append("Yosan_cd1:").Append(this._yosan_cd1).AppendLine();
			sb.Append("Yosan_nm1:").Append(this._yosan_nm1).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Hinsyu_cd_all:").Append(this._hinsyu_cd_all).AppendLine();
			sb.Append("Hinsyu_cd1:").Append(this._hinsyu_cd1).AppendLine();
			sb.Append("Hinsyu_cd2:").Append(this._hinsyu_cd2).AppendLine();
			sb.Append("Hinsyu_cd3:").Append(this._hinsyu_cd3).AppendLine();
			sb.Append("Hinsyu_cd4:").Append(this._hinsyu_cd4).AppendLine();
			sb.Append("Hinsyu_cd5:").Append(this._hinsyu_cd5).AppendLine();
			sb.Append("Hinsyu_cd6:").Append(this._hinsyu_cd6).AppendLine();
			sb.Append("Hinsyu_cd7:").Append(this._hinsyu_cd7).AppendLine();
			sb.Append("Hinsyu_cd8:").Append(this._hinsyu_cd8).AppendLine();
			sb.Append("Hinsyu_cd9:").Append(this._hinsyu_cd9).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Add_ymd_from:").Append(this._add_ymd_from).AppendLine();
			sb.Append("Add_ymd_to:").Append(this._add_ymd_to).AppendLine();
			sb.Append("Tantosya_cd:").Append(this._tantosya_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Irairiyu_cd1:").Append(this._irairiyu_cd1).AppendLine();
			sb.Append("Irairiyu_cd2:").Append(this._irairiyu_cd2).AppendLine();
			sb.Append("Hyoka_kb_mise:").Append(this._hyoka_kb_mise).AppendLine();
			sb.Append("Hyoka_kb_all:").Append(this._hyoka_kb_all).AppendLine();
			sb.Append("Sortkb1:").Append(this._sortkb1).AppendLine();
			sb.Append("Sortoptionkb1:").Append(this._sortoptionkb1).AppendLine();
			sb.Append("Sortkb2:").Append(this._sortkb2).AppendLine();
			sb.Append("Sortoptionkb2:").Append(this._sortoptionkb2).AppendLine();
			sb.Append("Sortkb3:").Append(this._sortkb3).AppendLine();
			sb.Append("Sortoptionkb3:").Append(this._sortoptionkb3).AppendLine();
			sb.Append("Gokei_irai_su:").Append(this._gokei_irai_su).AppendLine();
			sb.Append("Gokei_genkakin:").Append(this._gokei_genkakin).AppendLine();
			sb.Append("Footer_zan_kin:").Append(this._footer_zan_kin).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Ta080f03";
		}
		#endregion

		#endregion
	}
}
