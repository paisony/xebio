using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tm070p01.VO
{
  /// <summary>
  /// Tm070f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tm070f01ResultVO : StandardBaseVO
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
		/// 項目「HENKO_YMD_FROM(変更日ＦＲＯＭ)」の値
		/// </summary>
		private string _henko_ymd_from;
		/// <summary>
		/// 項目「HENKO_YMD_TO(変更日ＴＯ)」の値
		/// </summary>
		private string _henko_ymd_to;
		/// <summary>
		/// 項目「MOTO_TENPO_CD_FROM(元店舗ＦＲＯＭ)」の値
		/// </summary>
		private string _moto_tenpo_cd_from;
		/// <summary>
		/// 項目「MOTO_TENPO_NM_FROM()」の値
		/// </summary>
		private string _moto_tenpo_nm_from;
		/// <summary>
		/// 項目「MOTO_TENPO_CD_TO(元店舗ＴＯ)」の値
		/// </summary>
		private string _moto_tenpo_cd_to;
		/// <summary>
		/// 項目「MOTO_TENPO_NM_TO()」の値
		/// </summary>
		private string _moto_tenpo_nm_to;
		/// <summary>
		/// 項目「TAN_CD_FROM(担当者ＦＲＯＭ)」の値
		/// </summary>
		private string _tan_cd_from;
		/// <summary>
		/// 項目「TAN_NM_FROM()」の値
		/// </summary>
		private string _tan_nm_from;
		/// <summary>
		/// 項目「TAN_CD_TO(担当者ＴＯ)」の値
		/// </summary>
		private string _tan_cd_to;
		/// <summary>
		/// 項目「TAN_NM_TO()」の値
		/// </summary>
		private string _tan_nm_to;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
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
		/// 項目「HENKO_YMD_FROM(変更日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Henko_ymd_from
		{
			get
			{
				return this._henko_ymd_from;
			}
			set
			{
				this._henko_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HENKO_YMD_TO(変更日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Henko_ymd_to
		{
			get
			{
				return this._henko_ymd_to;
			}
			set
			{
				this._henko_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「MOTO_TENPO_CD_FROM(元店舗ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Moto_tenpo_cd_from
		{
			get
			{
				return this._moto_tenpo_cd_from;
			}
			set
			{
				this._moto_tenpo_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「MOTO_TENPO_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Moto_tenpo_nm_from
		{
			get
			{
				return this._moto_tenpo_nm_from;
			}
			set
			{
				this._moto_tenpo_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「MOTO_TENPO_CD_TO(元店舗ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Moto_tenpo_cd_to
		{
			get
			{
				return this._moto_tenpo_cd_to;
			}
			set
			{
				this._moto_tenpo_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「MOTO_TENPO_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Moto_tenpo_nm_to
		{
			get
			{
				return this._moto_tenpo_nm_to;
			}
			set
			{
				this._moto_tenpo_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「TAN_CD_FROM(担当者ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tan_cd_from
		{
			get
			{
				return this._tan_cd_from;
			}
			set
			{
				this._tan_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「TAN_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tan_nm_from
		{
			get
			{
				return this._tan_nm_from;
			}
			set
			{
				this._tan_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「TAN_CD_TO(担当者ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tan_cd_to
		{
			get
			{
				return this._tan_cd_to;
			}
			set
			{
				this._tan_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「TAN_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tan_nm_to
		{
			get
			{
				return this._tan_nm_to;
			}
			set
			{
				this._tan_nm_to = value;
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
		public Tm070f01ResultVO() : base()
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
			sb.Append("Henko_ymd_from:").Append(this._henko_ymd_from).AppendLine();
			sb.Append("Henko_ymd_to:").Append(this._henko_ymd_to).AppendLine();
			sb.Append("Moto_tenpo_cd_from:").Append(this._moto_tenpo_cd_from).AppendLine();
			sb.Append("Moto_tenpo_nm_from:").Append(this._moto_tenpo_nm_from).AppendLine();
			sb.Append("Moto_tenpo_cd_to:").Append(this._moto_tenpo_cd_to).AppendLine();
			sb.Append("Moto_tenpo_nm_to:").Append(this._moto_tenpo_nm_to).AppendLine();
			sb.Append("Tan_cd_from:").Append(this._tan_cd_from).AppendLine();
			sb.Append("Tan_nm_from:").Append(this._tan_nm_from).AppendLine();
			sb.Append("Tan_cd_to:").Append(this._tan_cd_to).AppendLine();
			sb.Append("Tan_nm_to:").Append(this._tan_nm_to).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
