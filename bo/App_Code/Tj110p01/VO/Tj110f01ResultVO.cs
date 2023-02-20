using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj110p01.VO
{
  /// <summary>
  /// Tj110f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj110f01ResultVO : StandardBaseVO
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
		/// 項目「TORIMORE_KETSUBAN(取漏れ／欠番)」の値
		/// </summary>
		private string _torimore_ketsuban;
		/// <summary>
		/// 項目「FACE_NO_FROM(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from;
		/// <summary>
		/// 項目「FACE_NO_TO(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to;
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
		/// 項目「TORIMORE_KETSUBAN(取漏れ／欠番)」の値を取得または設定する。
		/// </summary>
		public virtual string Torimore_ketsuban
		{
			get
			{
				return this._torimore_ketsuban;
			}
			set
			{
				this._torimore_ketsuban = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from
		{
			get
			{
				return this._face_no_from;
			}
			set
			{
				this._face_no_from = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to
		{
			get
			{
				return this._face_no_to;
			}
			set
			{
				this._face_no_to = value;
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
		public Tj110f01ResultVO() : base()
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
			sb.Append("Torimore_ketsuban:").Append(this._torimore_ketsuban).AppendLine();
			sb.Append("Face_no_from:").Append(this._face_no_from).AppendLine();
			sb.Append("Face_no_to:").Append(this._face_no_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
