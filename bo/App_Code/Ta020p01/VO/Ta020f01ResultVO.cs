using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta020p01.VO
{
  /// <summary>
  /// Ta020f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Ta020f01ResultVO : StandardBaseVO
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
		/// 項目「IRAI_YMD_FROM(依頼日)」の値
		/// </summary>
		private string _irai_ymd_from;
		/// <summary>
		/// 項目「IRAI_YMD_TO()」の値
		/// </summary>
		private string _irai_ymd_to;
		/// <summary>
		/// 項目「TANTOSYA_CD(担当者)」の値
		/// </summary>
		private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「IRAIRIYU_CD(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd;
		/// <summary>
		/// 項目「SHINSEI_FLG(状態)」の値
		/// </summary>
		private string _shinsei_flg;
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値
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
		/// 項目「IRAI_YMD_FROM(依頼日)」の値を取得または設定する。
		/// </summary>
		public virtual string Irai_ymd_from
		{
			get
			{
				return this._irai_ymd_from;
			}
			set
			{
				this._irai_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「IRAI_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Irai_ymd_to
		{
			get
			{
				return this._irai_ymd_to;
			}
			set
			{
				this._irai_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD(担当者)」の値を取得または設定する。
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
		/// 項目「IRAIRIYU_CD(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd
		{
			get
			{
				return this._irairiyu_cd;
			}
			set
			{
				this._irairiyu_cd = value;
			}
		}
		/// <summary>
		/// 項目「SHINSEI_FLG(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Shinsei_flg
		{
			get
			{
				return this._shinsei_flg;
			}
			set
			{
				this._shinsei_flg = value;
			}
		}
		/// <summary>
		/// 項目「SEARCHCNT(検索件数)」の値を取得または設定する。
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
		public Ta020f01ResultVO() : base()
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
			sb.Append("Irai_ymd_from:").Append(this._irai_ymd_from).AppendLine();
			sb.Append("Irai_ymd_to:").Append(this._irai_ymd_to).AppendLine();
			sb.Append("Tantosya_cd:").Append(this._tantosya_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Irairiyu_cd:").Append(this._irairiyu_cd).AppendLine();
			sb.Append("Shinsei_flg:").Append(this._shinsei_flg).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
