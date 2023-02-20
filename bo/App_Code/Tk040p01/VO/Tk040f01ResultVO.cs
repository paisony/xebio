using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tk040p01.VO
{
  /// <summary>
  /// Tk040f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tk040f01ResultVO : StandardBaseVO
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
		/// 項目「BUMON_CD_FROM(部門)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO()」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日)」の値
		/// </summary>
		private string _hanbaikanryo_ymd_from;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO()」の値
		/// </summary>
		private string _hanbaikanryo_ymd_to;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
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
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「SCAN_CD2(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd2;
		/// <summary>
		/// 項目「SCAN_CD3(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd3;
		/// <summary>
		/// 項目「SCAN_CD4(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd4;
		/// <summary>
		/// 項目「SCAN_CD5(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd5;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;

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
		/// 項目「BUMON_CD_FROM(部門)」の値を取得または設定する。
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
		/// 項目「BUMON_CD_TO()」の値を取得または設定する。
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
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaikanryo_ymd_from
		{
			get
			{
				return this._hanbaikanryo_ymd_from;
			}
			set
			{
				this._hanbaikanryo_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaikanryo_ymd_to
		{
			get
			{
				return this._hanbaikanryo_ymd_to;
			}
			set
			{
				this._hanbaikanryo_ymd_to = value;
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
		/// 項目「SCAN_CD2(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd2
		{
			get
			{
				return this._scan_cd2;
			}
			set
			{
				this._scan_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD3(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd3
		{
			get
			{
				return this._scan_cd3;
			}
			set
			{
				this._scan_cd3 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD4(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd4
		{
			get
			{
				return this._scan_cd4;
			}
			set
			{
				this._scan_cd4 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD5(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd5
		{
			get
			{
				return this._scan_cd5;
			}
			set
			{
				this._scan_cd5 = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk040f01ResultVO() : base()
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
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Hanbaikanryo_ymd_from:").Append(this._hanbaikanryo_ymd_from).AppendLine();
			sb.Append("Hanbaikanryo_ymd_to:").Append(this._hanbaikanryo_ymd_to).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Old_jisya_hbn2:").Append(this._old_jisya_hbn2).AppendLine();
			sb.Append("Old_jisya_hbn3:").Append(this._old_jisya_hbn3).AppendLine();
			sb.Append("Old_jisya_hbn4:").Append(this._old_jisya_hbn4).AppendLine();
			sb.Append("Old_jisya_hbn5:").Append(this._old_jisya_hbn5).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Scan_cd2:").Append(this._scan_cd2).AppendLine();
			sb.Append("Scan_cd3:").Append(this._scan_cd3).AppendLine();
			sb.Append("Scan_cd4:").Append(this._scan_cd4).AppendLine();
			sb.Append("Scan_cd5:").Append(this._scan_cd5).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
