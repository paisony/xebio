using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th020p01.Formvo.Baseform
{
  /// <summary>
  /// Th020f03のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Th020f03BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「HINSYU_CD()」の値
		/// </summary>
		private string _hinsyu_cd;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値
		/// </summary>
		private string _syohin_zokusei;
		/// <summary>
		/// 項目「SYONMK(商品名)」の値
		/// </summary>
		private string _syonmk;
		/// <summary>
		/// 項目「IRO_NM(色)」の値
		/// </summary>
		private string _iro_nm;
		/// <summary>
		/// 項目「ZENTENZAIKO_SU(全店在庫数)」の値
		/// </summary>
		private string _zentenzaiko_su;
		/// <summary>
		/// 項目「ZENTENSYOKA_RTU(全店消化率)」の値
		/// </summary>
		private string _zentensyoka_rtu;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM1()」の値
		/// </summary>
		private string _meisaihead_iro_nm1;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM2()」の値
		/// </summary>
		private string _meisaihead_iro_nm2;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM3()」の値
		/// </summary>
		private string _meisaihead_iro_nm3;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM4()」の値
		/// </summary>
		private string _meisaihead_iro_nm4;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM5()」の値
		/// </summary>
		private string _meisaihead_iro_nm5;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM6()」の値
		/// </summary>
		private string _meisaihead_iro_nm6;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM7()」の値
		/// </summary>
		private string _meisaihead_iro_nm7;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM8()」の値
		/// </summary>
		private string _meisaihead_iro_nm8;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM9()」の値
		/// </summary>
		private string _meisaihead_iro_nm9;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM10()」の値
		/// </summary>
		private string _meisaihead_iro_nm10;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM11()」の値
		/// </summary>
		private string _meisaihead_iro_nm11;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM12()」の値
		/// </summary>
		private string _meisaihead_iro_nm12;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM13()」の値
		/// </summary>
		private string _meisaihead_iro_nm13;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM14()」の値
		/// </summary>
		private string _meisaihead_iro_nm14;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM15()」の値
		/// </summary>
		private string _meisaihead_iro_nm15;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM16()」の値
		/// </summary>
		private string _meisaihead_iro_nm16;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM17()」の値
		/// </summary>
		private string _meisaihead_iro_nm17;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM18()」の値
		/// </summary>
		private string _meisaihead_iro_nm18;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM19()」の値
		/// </summary>
		private string _meisaihead_iro_nm19;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM20()」の値
		/// </summary>
		private string _meisaihead_iro_nm20;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM21()」の値
		/// </summary>
		private string _meisaihead_iro_nm21;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM22()」の値
		/// </summary>
		private string _meisaihead_iro_nm22;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM23()」の値
		/// </summary>
		private string _meisaihead_iro_nm23;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM24()」の値
		/// </summary>
		private string _meisaihead_iro_nm24;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM25()」の値
		/// </summary>
		private string _meisaihead_iro_nm25;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM26()」の値
		/// </summary>
		private string _meisaihead_iro_nm26;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM27()」の値
		/// </summary>
		private string _meisaihead_iro_nm27;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM28()」の値
		/// </summary>
		private string _meisaihead_iro_nm28;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM29()」の値
		/// </summary>
		private string _meisaihead_iro_nm29;
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM30()」の値
		/// </summary>
		private string _meisaihead_iro_nm30;
		/// <summary>
		/// 項目「TENPO_NM()」の値
		/// </summary>
		private string _tenpo_nm;
		/// <summary>
		/// 項目「TENPO_CD()」の値
		/// </summary>
		private string _tenpo_cd;
		/// <summary>
		/// 項目「ALL_GOKEI_SURYO()」の値
		/// </summary>
		private string _all_gokei_suryo;
		/// <summary>
		/// 項目「GOKEI_SURYO1()」の値
		/// </summary>
		private string _gokei_suryo1;
		/// <summary>
		/// 項目「GOKEI_SURYO2()」の値
		/// </summary>
		private string _gokei_suryo2;
		/// <summary>
		/// 項目「GOKEI_SURYO3()」の値
		/// </summary>
		private string _gokei_suryo3;
		/// <summary>
		/// 項目「GOKEI_SURYO4()」の値
		/// </summary>
		private string _gokei_suryo4;
		/// <summary>
		/// 項目「GOKEI_SURYO5()」の値
		/// </summary>
		private string _gokei_suryo5;
		/// <summary>
		/// 項目「GOKEI_SURYO6()」の値
		/// </summary>
		private string _gokei_suryo6;
		/// <summary>
		/// 項目「GOKEI_SURYO7()」の値
		/// </summary>
		private string _gokei_suryo7;
		/// <summary>
		/// 項目「GOKEI_SURYO8()」の値
		/// </summary>
		private string _gokei_suryo8;
		/// <summary>
		/// 項目「GOKEI_SURYO9()」の値
		/// </summary>
		private string _gokei_suryo9;
		/// <summary>
		/// 項目「GOKEI_SURYO10()」の値
		/// </summary>
		private string _gokei_suryo10;
		/// <summary>
		/// 項目「GOKEI_SURYO11()」の値
		/// </summary>
		private string _gokei_suryo11;
		/// <summary>
		/// 項目「GOKEI_SURYO12()」の値
		/// </summary>
		private string _gokei_suryo12;
		/// <summary>
		/// 項目「GOKEI_SURYO13()」の値
		/// </summary>
		private string _gokei_suryo13;
		/// <summary>
		/// 項目「GOKEI_SURYO14()」の値
		/// </summary>
		private string _gokei_suryo14;
		/// <summary>
		/// 項目「GOKEI_SURYO15()」の値
		/// </summary>
		private string _gokei_suryo15;
		/// <summary>
		/// 項目「GOKEI_SURYO16()」の値
		/// </summary>
		private string _gokei_suryo16;
		/// <summary>
		/// 項目「GOKEI_SURYO17()」の値
		/// </summary>
		private string _gokei_suryo17;
		/// <summary>
		/// 項目「GOKEI_SURYO18()」の値
		/// </summary>
		private string _gokei_suryo18;
		/// <summary>
		/// 項目「GOKEI_SURYO19()」の値
		/// </summary>
		private string _gokei_suryo19;
		/// <summary>
		/// 項目「GOKEI_SURYO20()」の値
		/// </summary>
		private string _gokei_suryo20;
		/// <summary>
		/// 項目「GOKEI_SURYO21()」の値
		/// </summary>
		private string _gokei_suryo21;
		/// <summary>
		/// 項目「GOKEI_SURYO22()」の値
		/// </summary>
		private string _gokei_suryo22;
		/// <summary>
		/// 項目「GOKEI_SURYO23()」の値
		/// </summary>
		private string _gokei_suryo23;
		/// <summary>
		/// 項目「GOKEI_SURYO24()」の値
		/// </summary>
		private string _gokei_suryo24;
		/// <summary>
		/// 項目「GOKEI_SURYO25()」の値
		/// </summary>
		private string _gokei_suryo25;
		/// <summary>
		/// 項目「GOKEI_SURYO26()」の値
		/// </summary>
		private string _gokei_suryo26;
		/// <summary>
		/// 項目「GOKEI_SURYO27()」の値
		/// </summary>
		private string _gokei_suryo27;
		/// <summary>
		/// 項目「GOKEI_SURYO28()」の値
		/// </summary>
		private string _gokei_suryo28;
		/// <summary>
		/// 項目「GOKEI_SURYO29()」の値
		/// </summary>
		private string _gokei_suryo29;
		/// <summary>
		/// 項目「GOKEI_SURYO30()」の値
		/// </summary>
		private string _gokei_suryo30;

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
		/// 項目「KAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd
		{
			get
			{
				return this._kaisya_cd;
			}
			set
			{
				this._kaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm
		{
			get
			{
				return this._kaisya_nm;
			}
			set
			{
				this._kaisya_nm = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd
		{
			get
			{
				return this._bumon_cd;
			}
			set
			{
				this._bumon_cd = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm
		{
			get
			{
				return this._bumon_nm;
			}
			set
			{
				this._bumon_nm = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_ryaku_nm
		{
			get
			{
				return this._hinsyu_ryaku_nm;
			}
			set
			{
				this._hinsyu_ryaku_nm = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd
		{
			get
			{
				return this._hinsyu_cd;
			}
			set
			{
				this._hinsyu_cd = value;
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
		/// 項目「JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisya_hbn
		{
			get
			{
				return this._jisya_hbn;
			}
			set
			{
				this._jisya_hbn = value;
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
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohin_zokusei
		{
			get
			{
				return this._syohin_zokusei;
			}
			set
			{
				this._syohin_zokusei = value;
			}
		}
		/// <summary>
		/// 項目「SYONMK(商品名)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonmk
		{
			get
			{
				return this._syonmk;
			}
			set
			{
				this._syonmk = value;
			}
		}
		/// <summary>
		/// 項目「IRO_NM(色)」の値を取得または設定する。
		/// </summary>
		public virtual string Iro_nm
		{
			get
			{
				return this._iro_nm;
			}
			set
			{
				this._iro_nm = value;
			}
		}
		/// <summary>
		/// 項目「ZENTENZAIKO_SU(全店在庫数)」の値を取得または設定する。
		/// </summary>
		public virtual string Zentenzaiko_su
		{
			get
			{
				return this._zentenzaiko_su;
			}
			set
			{
				this._zentenzaiko_su = value;
			}
		}
		/// <summary>
		/// 項目「ZENTENSYOKA_RTU(全店消化率)」の値を取得または設定する。
		/// </summary>
		public virtual string Zentensyoka_rtu
		{
			get
			{
				return this._zentensyoka_rtu;
			}
			set
			{
				this._zentensyoka_rtu = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM1()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm1
		{
			get
			{
				return this._meisaihead_iro_nm1;
			}
			set
			{
				this._meisaihead_iro_nm1 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM2()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm2
		{
			get
			{
				return this._meisaihead_iro_nm2;
			}
			set
			{
				this._meisaihead_iro_nm2 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM3()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm3
		{
			get
			{
				return this._meisaihead_iro_nm3;
			}
			set
			{
				this._meisaihead_iro_nm3 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM4()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm4
		{
			get
			{
				return this._meisaihead_iro_nm4;
			}
			set
			{
				this._meisaihead_iro_nm4 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM5()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm5
		{
			get
			{
				return this._meisaihead_iro_nm5;
			}
			set
			{
				this._meisaihead_iro_nm5 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM6()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm6
		{
			get
			{
				return this._meisaihead_iro_nm6;
			}
			set
			{
				this._meisaihead_iro_nm6 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM7()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm7
		{
			get
			{
				return this._meisaihead_iro_nm7;
			}
			set
			{
				this._meisaihead_iro_nm7 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM8()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm8
		{
			get
			{
				return this._meisaihead_iro_nm8;
			}
			set
			{
				this._meisaihead_iro_nm8 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM9()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm9
		{
			get
			{
				return this._meisaihead_iro_nm9;
			}
			set
			{
				this._meisaihead_iro_nm9 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM10()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm10
		{
			get
			{
				return this._meisaihead_iro_nm10;
			}
			set
			{
				this._meisaihead_iro_nm10 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM11()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm11
		{
			get
			{
				return this._meisaihead_iro_nm11;
			}
			set
			{
				this._meisaihead_iro_nm11 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM12()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm12
		{
			get
			{
				return this._meisaihead_iro_nm12;
			}
			set
			{
				this._meisaihead_iro_nm12 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM13()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm13
		{
			get
			{
				return this._meisaihead_iro_nm13;
			}
			set
			{
				this._meisaihead_iro_nm13 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM14()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm14
		{
			get
			{
				return this._meisaihead_iro_nm14;
			}
			set
			{
				this._meisaihead_iro_nm14 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM15()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm15
		{
			get
			{
				return this._meisaihead_iro_nm15;
			}
			set
			{
				this._meisaihead_iro_nm15 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM16()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm16
		{
			get
			{
				return this._meisaihead_iro_nm16;
			}
			set
			{
				this._meisaihead_iro_nm16 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM17()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm17
		{
			get
			{
				return this._meisaihead_iro_nm17;
			}
			set
			{
				this._meisaihead_iro_nm17 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM18()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm18
		{
			get
			{
				return this._meisaihead_iro_nm18;
			}
			set
			{
				this._meisaihead_iro_nm18 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM19()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm19
		{
			get
			{
				return this._meisaihead_iro_nm19;
			}
			set
			{
				this._meisaihead_iro_nm19 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM20()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm20
		{
			get
			{
				return this._meisaihead_iro_nm20;
			}
			set
			{
				this._meisaihead_iro_nm20 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM21()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm21
		{
			get
			{
				return this._meisaihead_iro_nm21;
			}
			set
			{
				this._meisaihead_iro_nm21 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM22()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm22
		{
			get
			{
				return this._meisaihead_iro_nm22;
			}
			set
			{
				this._meisaihead_iro_nm22 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM23()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm23
		{
			get
			{
				return this._meisaihead_iro_nm23;
			}
			set
			{
				this._meisaihead_iro_nm23 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM24()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm24
		{
			get
			{
				return this._meisaihead_iro_nm24;
			}
			set
			{
				this._meisaihead_iro_nm24 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM25()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm25
		{
			get
			{
				return this._meisaihead_iro_nm25;
			}
			set
			{
				this._meisaihead_iro_nm25 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM26()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm26
		{
			get
			{
				return this._meisaihead_iro_nm26;
			}
			set
			{
				this._meisaihead_iro_nm26 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM27()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm27
		{
			get
			{
				return this._meisaihead_iro_nm27;
			}
			set
			{
				this._meisaihead_iro_nm27 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM28()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm28
		{
			get
			{
				return this._meisaihead_iro_nm28;
			}
			set
			{
				this._meisaihead_iro_nm28 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM29()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm29
		{
			get
			{
				return this._meisaihead_iro_nm29;
			}
			set
			{
				this._meisaihead_iro_nm29 = value;
			}
		}
		/// <summary>
		/// 項目「MEISAIHEAD_IRO_NM30()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisaihead_iro_nm30
		{
			get
			{
				return this._meisaihead_iro_nm30;
			}
			set
			{
				this._meisaihead_iro_nm30 = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm
		{
			get
			{
				return this._tenpo_nm;
			}
			set
			{
				this._tenpo_nm = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd
		{
			get
			{
				return this._tenpo_cd;
			}
			set
			{
				this._tenpo_cd = value;
			}
		}
		/// <summary>
		/// 項目「ALL_GOKEI_SURYO()」の値を取得または設定する。
		/// </summary>
		public virtual string All_gokei_suryo
		{
			get
			{
				return this._all_gokei_suryo;
			}
			set
			{
				this._all_gokei_suryo = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO1()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo1
		{
			get
			{
				return this._gokei_suryo1;
			}
			set
			{
				this._gokei_suryo1 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO2()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo2
		{
			get
			{
				return this._gokei_suryo2;
			}
			set
			{
				this._gokei_suryo2 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO3()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo3
		{
			get
			{
				return this._gokei_suryo3;
			}
			set
			{
				this._gokei_suryo3 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO4()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo4
		{
			get
			{
				return this._gokei_suryo4;
			}
			set
			{
				this._gokei_suryo4 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO5()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo5
		{
			get
			{
				return this._gokei_suryo5;
			}
			set
			{
				this._gokei_suryo5 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO6()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo6
		{
			get
			{
				return this._gokei_suryo6;
			}
			set
			{
				this._gokei_suryo6 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO7()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo7
		{
			get
			{
				return this._gokei_suryo7;
			}
			set
			{
				this._gokei_suryo7 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO8()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo8
		{
			get
			{
				return this._gokei_suryo8;
			}
			set
			{
				this._gokei_suryo8 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO9()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo9
		{
			get
			{
				return this._gokei_suryo9;
			}
			set
			{
				this._gokei_suryo9 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO10()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo10
		{
			get
			{
				return this._gokei_suryo10;
			}
			set
			{
				this._gokei_suryo10 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO11()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo11
		{
			get
			{
				return this._gokei_suryo11;
			}
			set
			{
				this._gokei_suryo11 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO12()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo12
		{
			get
			{
				return this._gokei_suryo12;
			}
			set
			{
				this._gokei_suryo12 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO13()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo13
		{
			get
			{
				return this._gokei_suryo13;
			}
			set
			{
				this._gokei_suryo13 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO14()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo14
		{
			get
			{
				return this._gokei_suryo14;
			}
			set
			{
				this._gokei_suryo14 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO15()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo15
		{
			get
			{
				return this._gokei_suryo15;
			}
			set
			{
				this._gokei_suryo15 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO16()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo16
		{
			get
			{
				return this._gokei_suryo16;
			}
			set
			{
				this._gokei_suryo16 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO17()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo17
		{
			get
			{
				return this._gokei_suryo17;
			}
			set
			{
				this._gokei_suryo17 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO18()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo18
		{
			get
			{
				return this._gokei_suryo18;
			}
			set
			{
				this._gokei_suryo18 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO19()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo19
		{
			get
			{
				return this._gokei_suryo19;
			}
			set
			{
				this._gokei_suryo19 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO20()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo20
		{
			get
			{
				return this._gokei_suryo20;
			}
			set
			{
				this._gokei_suryo20 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO21()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo21
		{
			get
			{
				return this._gokei_suryo21;
			}
			set
			{
				this._gokei_suryo21 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO22()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo22
		{
			get
			{
				return this._gokei_suryo22;
			}
			set
			{
				this._gokei_suryo22 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO23()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo23
		{
			get
			{
				return this._gokei_suryo23;
			}
			set
			{
				this._gokei_suryo23 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO24()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo24
		{
			get
			{
				return this._gokei_suryo24;
			}
			set
			{
				this._gokei_suryo24 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO25()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo25
		{
			get
			{
				return this._gokei_suryo25;
			}
			set
			{
				this._gokei_suryo25 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO26()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo26
		{
			get
			{
				return this._gokei_suryo26;
			}
			set
			{
				this._gokei_suryo26 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO27()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo27
		{
			get
			{
				return this._gokei_suryo27;
			}
			set
			{
				this._gokei_suryo27 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO28()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo28
		{
			get
			{
				return this._gokei_suryo28;
			}
			set
			{
				this._gokei_suryo28 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO29()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo29
		{
			get
			{
				return this._gokei_suryo29;
			}
			set
			{
				this._gokei_suryo29 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO30()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo30
		{
			get
			{
				return this._gokei_suryo30;
			}
			set
			{
				this._gokei_suryo30 = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f03BaseForm() : base()
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
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Jisya_hbn:").Append(this._jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Syohin_zokusei:").Append(this._syohin_zokusei).AppendLine();
			sb.Append("Syonmk:").Append(this._syonmk).AppendLine();
			sb.Append("Iro_nm:").Append(this._iro_nm).AppendLine();
			sb.Append("Zentenzaiko_su:").Append(this._zentenzaiko_su).AppendLine();
			sb.Append("Zentensyoka_rtu:").Append(this._zentensyoka_rtu).AppendLine();
			sb.Append("Meisaihead_iro_nm1:").Append(this._meisaihead_iro_nm1).AppendLine();
			sb.Append("Meisaihead_iro_nm2:").Append(this._meisaihead_iro_nm2).AppendLine();
			sb.Append("Meisaihead_iro_nm3:").Append(this._meisaihead_iro_nm3).AppendLine();
			sb.Append("Meisaihead_iro_nm4:").Append(this._meisaihead_iro_nm4).AppendLine();
			sb.Append("Meisaihead_iro_nm5:").Append(this._meisaihead_iro_nm5).AppendLine();
			sb.Append("Meisaihead_iro_nm6:").Append(this._meisaihead_iro_nm6).AppendLine();
			sb.Append("Meisaihead_iro_nm7:").Append(this._meisaihead_iro_nm7).AppendLine();
			sb.Append("Meisaihead_iro_nm8:").Append(this._meisaihead_iro_nm8).AppendLine();
			sb.Append("Meisaihead_iro_nm9:").Append(this._meisaihead_iro_nm9).AppendLine();
			sb.Append("Meisaihead_iro_nm10:").Append(this._meisaihead_iro_nm10).AppendLine();
			sb.Append("Meisaihead_iro_nm11:").Append(this._meisaihead_iro_nm11).AppendLine();
			sb.Append("Meisaihead_iro_nm12:").Append(this._meisaihead_iro_nm12).AppendLine();
			sb.Append("Meisaihead_iro_nm13:").Append(this._meisaihead_iro_nm13).AppendLine();
			sb.Append("Meisaihead_iro_nm14:").Append(this._meisaihead_iro_nm14).AppendLine();
			sb.Append("Meisaihead_iro_nm15:").Append(this._meisaihead_iro_nm15).AppendLine();
			sb.Append("Meisaihead_iro_nm16:").Append(this._meisaihead_iro_nm16).AppendLine();
			sb.Append("Meisaihead_iro_nm17:").Append(this._meisaihead_iro_nm17).AppendLine();
			sb.Append("Meisaihead_iro_nm18:").Append(this._meisaihead_iro_nm18).AppendLine();
			sb.Append("Meisaihead_iro_nm19:").Append(this._meisaihead_iro_nm19).AppendLine();
			sb.Append("Meisaihead_iro_nm20:").Append(this._meisaihead_iro_nm20).AppendLine();
			sb.Append("Meisaihead_iro_nm21:").Append(this._meisaihead_iro_nm21).AppendLine();
			sb.Append("Meisaihead_iro_nm22:").Append(this._meisaihead_iro_nm22).AppendLine();
			sb.Append("Meisaihead_iro_nm23:").Append(this._meisaihead_iro_nm23).AppendLine();
			sb.Append("Meisaihead_iro_nm24:").Append(this._meisaihead_iro_nm24).AppendLine();
			sb.Append("Meisaihead_iro_nm25:").Append(this._meisaihead_iro_nm25).AppendLine();
			sb.Append("Meisaihead_iro_nm26:").Append(this._meisaihead_iro_nm26).AppendLine();
			sb.Append("Meisaihead_iro_nm27:").Append(this._meisaihead_iro_nm27).AppendLine();
			sb.Append("Meisaihead_iro_nm28:").Append(this._meisaihead_iro_nm28).AppendLine();
			sb.Append("Meisaihead_iro_nm29:").Append(this._meisaihead_iro_nm29).AppendLine();
			sb.Append("Meisaihead_iro_nm30:").Append(this._meisaihead_iro_nm30).AppendLine();
			sb.Append("Tenpo_nm:").Append(this._tenpo_nm).AppendLine();
			sb.Append("Tenpo_cd:").Append(this._tenpo_cd).AppendLine();
			sb.Append("All_gokei_suryo:").Append(this._all_gokei_suryo).AppendLine();
			sb.Append("Gokei_suryo1:").Append(this._gokei_suryo1).AppendLine();
			sb.Append("Gokei_suryo2:").Append(this._gokei_suryo2).AppendLine();
			sb.Append("Gokei_suryo3:").Append(this._gokei_suryo3).AppendLine();
			sb.Append("Gokei_suryo4:").Append(this._gokei_suryo4).AppendLine();
			sb.Append("Gokei_suryo5:").Append(this._gokei_suryo5).AppendLine();
			sb.Append("Gokei_suryo6:").Append(this._gokei_suryo6).AppendLine();
			sb.Append("Gokei_suryo7:").Append(this._gokei_suryo7).AppendLine();
			sb.Append("Gokei_suryo8:").Append(this._gokei_suryo8).AppendLine();
			sb.Append("Gokei_suryo9:").Append(this._gokei_suryo9).AppendLine();
			sb.Append("Gokei_suryo10:").Append(this._gokei_suryo10).AppendLine();
			sb.Append("Gokei_suryo11:").Append(this._gokei_suryo11).AppendLine();
			sb.Append("Gokei_suryo12:").Append(this._gokei_suryo12).AppendLine();
			sb.Append("Gokei_suryo13:").Append(this._gokei_suryo13).AppendLine();
			sb.Append("Gokei_suryo14:").Append(this._gokei_suryo14).AppendLine();
			sb.Append("Gokei_suryo15:").Append(this._gokei_suryo15).AppendLine();
			sb.Append("Gokei_suryo16:").Append(this._gokei_suryo16).AppendLine();
			sb.Append("Gokei_suryo17:").Append(this._gokei_suryo17).AppendLine();
			sb.Append("Gokei_suryo18:").Append(this._gokei_suryo18).AppendLine();
			sb.Append("Gokei_suryo19:").Append(this._gokei_suryo19).AppendLine();
			sb.Append("Gokei_suryo20:").Append(this._gokei_suryo20).AppendLine();
			sb.Append("Gokei_suryo21:").Append(this._gokei_suryo21).AppendLine();
			sb.Append("Gokei_suryo22:").Append(this._gokei_suryo22).AppendLine();
			sb.Append("Gokei_suryo23:").Append(this._gokei_suryo23).AppendLine();
			sb.Append("Gokei_suryo24:").Append(this._gokei_suryo24).AppendLine();
			sb.Append("Gokei_suryo25:").Append(this._gokei_suryo25).AppendLine();
			sb.Append("Gokei_suryo26:").Append(this._gokei_suryo26).AppendLine();
			sb.Append("Gokei_suryo27:").Append(this._gokei_suryo27).AppendLine();
			sb.Append("Gokei_suryo28:").Append(this._gokei_suryo28).AppendLine();
			sb.Append("Gokei_suryo29:").Append(this._gokei_suryo29).AppendLine();
			sb.Append("Gokei_suryo30:").Append(this._gokei_suryo30).AppendLine();
		
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
			return "Th020f03";
		}
		#endregion

		#endregion
	}
}
