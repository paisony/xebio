using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th020p01.VO
{
  /// <summary>
  /// Th020f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Th020f01ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD(店舗)」の値
		/// </summary>
		private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「OLD_JISYA_HBN_FROM(自社品番FROM)」の値
		/// </summary>
		private string _old_jisya_hbn_from;
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(自社品番TO)」の値
		/// </summary>
		private string _old_jisya_hbn_to;
		/// <summary>
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番（複数）)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「OLD_JISYA_HBN2(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn2;
		/// <summary>
		/// 項目「OLD_JISYA_HBN3(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn3;
		/// <summary>
		/// 項目「OLD_JISYA_HBN4(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn4;
		/// <summary>
		/// 項目「OLD_JISYA_HBN5(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn5;
		/// <summary>
		/// 項目「KAISYA_CD2(会社)」の値
		/// </summary>
		private string _kaisya_cd2;
		/// <summary>
		/// 項目「KAISYA_NM2()」の値
		/// </summary>
		private string _kaisya_nm2;
		/// <summary>
		/// 項目「SCAN_CD_FROM(スキャンコードFROM)」の値
		/// </summary>
		private string _scan_cd_from;
		/// <summary>
		/// 項目「SCAN_CD_TO(スキャンコードTO)」の値
		/// </summary>
		private string _scan_cd_to;
		/// <summary>
		/// 項目「KAISYA_CD3(会社)」の値
		/// </summary>
		private string _kaisya_cd3;
		/// <summary>
		/// 項目「KAISYA_NM3()」の値
		/// </summary>
		private string _kaisya_nm3;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「KAISYA_CD4(会社)」の値
		/// </summary>
		private string _kaisya_cd4;
		/// <summary>
		/// 項目「KAISYA_NM4()」の値
		/// </summary>
		private string _kaisya_nm4;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「ZAIKO_SERCHSTK()」の値
		/// </summary>
		private string _zaiko_serchstk;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD(店舗)」の値を取得または設定する。
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
		/// 項目「MODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Modeno
		{
			get
			{
				return this._modeno;
			}
			set
			{
				this._modeno = value;
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
		/// 項目「OLD_JISYA_HBN_FROM(自社品番FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn_from
		{
			get
			{
				return this._old_jisya_hbn_from;
			}
			set
			{
				this._old_jisya_hbn_from = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(自社品番TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn_to
		{
			get
			{
				return this._old_jisya_hbn_to;
			}
			set
			{
				this._old_jisya_hbn_to = value;
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
		/// 項目「OLD_JISYA_HBN(自社品番（複数）)」の値を取得または設定する。
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
		/// 項目「OLD_JISYA_HBN2(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn2
		{
			get
			{
				return this._old_jisya_hbn2;
			}
			set
			{
				this._old_jisya_hbn2 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN3(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn3
		{
			get
			{
				return this._old_jisya_hbn3;
			}
			set
			{
				this._old_jisya_hbn3 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN4(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn4
		{
			get
			{
				return this._old_jisya_hbn4;
			}
			set
			{
				this._old_jisya_hbn4 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN5(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn5
		{
			get
			{
				return this._old_jisya_hbn5;
			}
			set
			{
				this._old_jisya_hbn5 = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_CD2(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd2
		{
			get
			{
				return this._kaisya_cd2;
			}
			set
			{
				this._kaisya_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM2()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm2
		{
			get
			{
				return this._kaisya_nm2;
			}
			set
			{
				this._kaisya_nm2 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD_FROM(スキャンコードFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd_from
		{
			get
			{
				return this._scan_cd_from;
			}
			set
			{
				this._scan_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD_TO(スキャンコードTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd_to
		{
			get
			{
				return this._scan_cd_to;
			}
			set
			{
				this._scan_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_CD3(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd3
		{
			get
			{
				return this._kaisya_cd3;
			}
			set
			{
				this._kaisya_cd3 = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM3()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm3
		{
			get
			{
				return this._kaisya_nm3;
			}
			set
			{
				this._kaisya_nm3 = value;
			}
		}
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値を取得または設定する。
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
		/// 項目「KAISYA_CD4(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd4
		{
			get
			{
				return this._kaisya_cd4;
			}
			set
			{
				this._kaisya_cd4 = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM4()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm4
		{
			get
			{
				return this._kaisya_nm4;
			}
			set
			{
				this._kaisya_nm4 = value;
			}
		}
		/// <summary>
		/// 項目「SEARCHCNT()」の値を取得または設定する。
		/// </summary>
		public virtual string Searchcnt
		{
			get
			{
				return this._searchcnt;
			}
			set
			{
				this._searchcnt = value;
			}
		}
		/// <summary>
		/// 項目「ZAIKO_SERCHSTK()」の値を取得または設定する。
		/// </summary>
		public virtual string Zaiko_serchstk
		{
			get
			{
				return this._zaiko_serchstk;
			}
			set
			{
				this._zaiko_serchstk = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f01ResultVO() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Old_jisya_hbn_from:").Append(this._old_jisya_hbn_from).AppendLine();
			sb.Append("Old_jisya_hbn_to:").Append(this._old_jisya_hbn_to).AppendLine();
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Old_jisya_hbn2:").Append(this._old_jisya_hbn2).AppendLine();
			sb.Append("Old_jisya_hbn3:").Append(this._old_jisya_hbn3).AppendLine();
			sb.Append("Old_jisya_hbn4:").Append(this._old_jisya_hbn4).AppendLine();
			sb.Append("Old_jisya_hbn5:").Append(this._old_jisya_hbn5).AppendLine();
			sb.Append("Kaisya_cd2:").Append(this._kaisya_cd2).AppendLine();
			sb.Append("Kaisya_nm2:").Append(this._kaisya_nm2).AppendLine();
			sb.Append("Scan_cd_from:").Append(this._scan_cd_from).AppendLine();
			sb.Append("Scan_cd_to:").Append(this._scan_cd_to).AppendLine();
			sb.Append("Kaisya_cd3:").Append(this._kaisya_cd3).AppendLine();
			sb.Append("Kaisya_nm3:").Append(this._kaisya_nm3).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Kaisya_cd4:").Append(this._kaisya_cd4).AppendLine();
			sb.Append("Kaisya_nm4:").Append(this._kaisya_nm4).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Zaiko_serchstk:").Append(this._zaiko_serchstk).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
