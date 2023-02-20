using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tm060p01.VO
{
  /// <summary>
  /// Tm060f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tm060f01ResultVO : StandardBaseVO
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
		/// 項目「TANTOSYA_CD_FROM(担当者コードＦＲＯＭ)」の値
		/// </summary>
		private string _tantosya_cd_from;
		/// <summary>
		/// 項目「HANBAIIN_NM_FROM()」の値
		/// </summary>
		private string _hanbaiin_nm_from;
		/// <summary>
		/// 項目「TANTOSYA_CD_TO(担当者コードＴＯ)」の値
		/// </summary>
		private string _tantosya_cd_to;
		/// <summary>
		/// 項目「HANBAIIN_NM_TO()」の値
		/// </summary>
		private string _hanbaiin_nm_to;
		/// <summary>
		/// 項目「SYOKUSEI_KB(職制区分)」の値
		/// </summary>
		private string _syokusei_kb;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「KENGEN_KB(権限)」の値
		/// </summary>
		private string _kengen_kb;

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
		/// 項目「TANTOSYA_CD_FROM(担当者コードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd_from
		{
			get
			{
				return this._tantosya_cd_from;
			}
			set
			{
				this._tantosya_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm_from
		{
			get
			{
				return this._hanbaiin_nm_from;
			}
			set
			{
				this._hanbaiin_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD_TO(担当者コードＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd_to
		{
			get
			{
				return this._tantosya_cd_to;
			}
			set
			{
				this._tantosya_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm_to
		{
			get
			{
				return this._hanbaiin_nm_to;
			}
			set
			{
				this._hanbaiin_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「SYOKUSEI_KB(職制区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Syokusei_kb
		{
			get
			{
				return this._syokusei_kb;
			}
			set
			{
				this._syokusei_kb = value;
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
		/// 項目「KENGEN_KB(権限)」の値を取得または設定する。
		/// </summary>
		public virtual string Kengen_kb
		{
			get
			{
				return this._kengen_kb;
			}
			set
			{
				this._kengen_kb = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm060f01ResultVO() : base()
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
			sb.Append("Tantosya_cd_from:").Append(this._tantosya_cd_from).AppendLine();
			sb.Append("Hanbaiin_nm_from:").Append(this._hanbaiin_nm_from).AppendLine();
			sb.Append("Tantosya_cd_to:").Append(this._tantosya_cd_to).AppendLine();
			sb.Append("Hanbaiin_nm_to:").Append(this._hanbaiin_nm_to).AppendLine();
			sb.Append("Syokusei_kb:").Append(this._syokusei_kb).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Kengen_kb:").Append(this._kengen_kb).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
