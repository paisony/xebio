using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th020p01.VO
{
  /// <summary>
  /// Th020f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Th020f02ResultVO : StandardBaseVO
	{

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
		/// 項目「SURYO1()」の値
		/// </summary>
		private string _suryo1;
		/// <summary>
		/// 項目「SURYO2()」の値
		/// </summary>
		private string _suryo2;
		/// <summary>
		/// 項目「SURYO3()」の値
		/// </summary>
		private string _suryo3;
		/// <summary>
		/// 項目「SURYO4()」の値
		/// </summary>
		private string _suryo4;
		/// <summary>
		/// 項目「SURYO5()」の値
		/// </summary>
		private string _suryo5;
		/// <summary>
		/// 項目「SURYO6()」の値
		/// </summary>
		private string _suryo6;
		/// <summary>
		/// 項目「SURYO7()」の値
		/// </summary>
		private string _suryo7;
		/// <summary>
		/// 項目「SURYO8()」の値
		/// </summary>
		private string _suryo8;
		/// <summary>
		/// 項目「SURYO9()」の値
		/// </summary>
		private string _suryo9;
		/// <summary>
		/// 項目「SURYO10()」の値
		/// </summary>
		private string _suryo10;
		/// <summary>
		/// 項目「SURYO11()」の値
		/// </summary>
		private string _suryo11;
		/// <summary>
		/// 項目「SURYO12()」の値
		/// </summary>
		private string _suryo12;
		/// <summary>
		/// 項目「SURYO13()」の値
		/// </summary>
		private string _suryo13;
		/// <summary>
		/// 項目「SURYO14()」の値
		/// </summary>
		private string _suryo14;
		/// <summary>
		/// 項目「SURYO15()」の値
		/// </summary>
		private string _suryo15;
		/// <summary>
		/// 項目「SURYO16()」の値
		/// </summary>
		private string _suryo16;
		/// <summary>
		/// 項目「SURYO17()」の値
		/// </summary>
		private string _suryo17;
		/// <summary>
		/// 項目「SURYO18()」の値
		/// </summary>
		private string _suryo18;
		/// <summary>
		/// 項目「SURYO19()」の値
		/// </summary>
		private string _suryo19;
		/// <summary>
		/// 項目「SURYO20()」の値
		/// </summary>
		private string _suryo20;
		/// <summary>
		/// 項目「SURYO21()」の値
		/// </summary>
		private string _suryo21;
		/// <summary>
		/// 項目「SURYO22()」の値
		/// </summary>
		private string _suryo22;
		/// <summary>
		/// 項目「SURYO23()」の値
		/// </summary>
		private string _suryo23;
		/// <summary>
		/// 項目「SURYO24()」の値
		/// </summary>
		private string _suryo24;
		/// <summary>
		/// 項目「SURYO25()」の値
		/// </summary>
		private string _suryo25;
		/// <summary>
		/// 項目「SURYO26()」の値
		/// </summary>
		private string _suryo26;
		/// <summary>
		/// 項目「SURYO27()」の値
		/// </summary>
		private string _suryo27;
		/// <summary>
		/// 項目「SURYO28()」の値
		/// </summary>
		private string _suryo28;
		/// <summary>
		/// 項目「SURYO29()」の値
		/// </summary>
		private string _suryo29;
		/// <summary>
		/// 項目「SURYO30()」の値
		/// </summary>
		private string _suryo30;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IList m1List;
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
		/// 項目「SURYO1()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo1
		{
			get
			{
				return this._suryo1;
			}
			set
			{
				this._suryo1 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO2()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo2
		{
			get
			{
				return this._suryo2;
			}
			set
			{
				this._suryo2 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO3()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo3
		{
			get
			{
				return this._suryo3;
			}
			set
			{
				this._suryo3 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO4()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo4
		{
			get
			{
				return this._suryo4;
			}
			set
			{
				this._suryo4 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO5()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo5
		{
			get
			{
				return this._suryo5;
			}
			set
			{
				this._suryo5 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO6()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo6
		{
			get
			{
				return this._suryo6;
			}
			set
			{
				this._suryo6 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO7()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo7
		{
			get
			{
				return this._suryo7;
			}
			set
			{
				this._suryo7 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO8()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo8
		{
			get
			{
				return this._suryo8;
			}
			set
			{
				this._suryo8 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO9()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo9
		{
			get
			{
				return this._suryo9;
			}
			set
			{
				this._suryo9 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO10()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo10
		{
			get
			{
				return this._suryo10;
			}
			set
			{
				this._suryo10 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO11()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo11
		{
			get
			{
				return this._suryo11;
			}
			set
			{
				this._suryo11 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO12()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo12
		{
			get
			{
				return this._suryo12;
			}
			set
			{
				this._suryo12 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO13()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo13
		{
			get
			{
				return this._suryo13;
			}
			set
			{
				this._suryo13 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO14()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo14
		{
			get
			{
				return this._suryo14;
			}
			set
			{
				this._suryo14 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO15()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo15
		{
			get
			{
				return this._suryo15;
			}
			set
			{
				this._suryo15 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO16()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo16
		{
			get
			{
				return this._suryo16;
			}
			set
			{
				this._suryo16 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO17()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo17
		{
			get
			{
				return this._suryo17;
			}
			set
			{
				this._suryo17 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO18()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo18
		{
			get
			{
				return this._suryo18;
			}
			set
			{
				this._suryo18 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO19()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo19
		{
			get
			{
				return this._suryo19;
			}
			set
			{
				this._suryo19 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO20()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo20
		{
			get
			{
				return this._suryo20;
			}
			set
			{
				this._suryo20 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO21()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo21
		{
			get
			{
				return this._suryo21;
			}
			set
			{
				this._suryo21 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO22()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo22
		{
			get
			{
				return this._suryo22;
			}
			set
			{
				this._suryo22 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO23()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo23
		{
			get
			{
				return this._suryo23;
			}
			set
			{
				this._suryo23 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO24()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo24
		{
			get
			{
				return this._suryo24;
			}
			set
			{
				this._suryo24 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO25()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo25
		{
			get
			{
				return this._suryo25;
			}
			set
			{
				this._suryo25 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO26()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo26
		{
			get
			{
				return this._suryo26;
			}
			set
			{
				this._suryo26 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO27()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo27
		{
			get
			{
				return this._suryo27;
			}
			set
			{
				this._suryo27 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO28()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo28
		{
			get
			{
				return this._suryo28;
			}
			set
			{
				this._suryo28 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO29()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo29
		{
			get
			{
				return this._suryo29;
			}
			set
			{
				this._suryo29 = value;
			}
		}
		/// <summary>
		/// 項目「SURYO30()」の値を取得または設定する。
		/// </summary>
		public virtual string Suryo30
		{
			get
			{
				return this._suryo30;
			}
			set
			{
				this._suryo30 = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f02ResultVO() : base()
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
		public virtual IList GetList(string listId)
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
		public virtual void SetList(string listId, IList list)
		{
			if (listId.Equals("M1"))
			{
				m1List = list;
			}
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
			sb.Append("Tenpo_nm:").Append(this._tenpo_nm).AppendLine();
			sb.Append("Tenpo_cd:").Append(this._tenpo_cd).AppendLine();
			sb.Append("All_gokei_suryo:").Append(this._all_gokei_suryo).AppendLine();
			sb.Append("Suryo1:").Append(this._suryo1).AppendLine();
			sb.Append("Suryo2:").Append(this._suryo2).AppendLine();
			sb.Append("Suryo3:").Append(this._suryo3).AppendLine();
			sb.Append("Suryo4:").Append(this._suryo4).AppendLine();
			sb.Append("Suryo5:").Append(this._suryo5).AppendLine();
			sb.Append("Suryo6:").Append(this._suryo6).AppendLine();
			sb.Append("Suryo7:").Append(this._suryo7).AppendLine();
			sb.Append("Suryo8:").Append(this._suryo8).AppendLine();
			sb.Append("Suryo9:").Append(this._suryo9).AppendLine();
			sb.Append("Suryo10:").Append(this._suryo10).AppendLine();
			sb.Append("Suryo11:").Append(this._suryo11).AppendLine();
			sb.Append("Suryo12:").Append(this._suryo12).AppendLine();
			sb.Append("Suryo13:").Append(this._suryo13).AppendLine();
			sb.Append("Suryo14:").Append(this._suryo14).AppendLine();
			sb.Append("Suryo15:").Append(this._suryo15).AppendLine();
			sb.Append("Suryo16:").Append(this._suryo16).AppendLine();
			sb.Append("Suryo17:").Append(this._suryo17).AppendLine();
			sb.Append("Suryo18:").Append(this._suryo18).AppendLine();
			sb.Append("Suryo19:").Append(this._suryo19).AppendLine();
			sb.Append("Suryo20:").Append(this._suryo20).AppendLine();
			sb.Append("Suryo21:").Append(this._suryo21).AppendLine();
			sb.Append("Suryo22:").Append(this._suryo22).AppendLine();
			sb.Append("Suryo23:").Append(this._suryo23).AppendLine();
			sb.Append("Suryo24:").Append(this._suryo24).AppendLine();
			sb.Append("Suryo25:").Append(this._suryo25).AppendLine();
			sb.Append("Suryo26:").Append(this._suryo26).AppendLine();
			sb.Append("Suryo27:").Append(this._suryo27).AppendLine();
			sb.Append("Suryo28:").Append(this._suryo28).AppendLine();
			sb.Append("Suryo29:").Append(this._suryo29).AppendLine();
			sb.Append("Suryo30:").Append(this._suryo30).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
