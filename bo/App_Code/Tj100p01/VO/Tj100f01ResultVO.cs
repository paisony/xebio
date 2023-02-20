using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj100p01.VO
{
  /// <summary>
  /// Tj100f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj100f01ResultVO : StandardBaseVO
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
		/// 項目「FACE_NO_FROM1(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from1;
		/// <summary>
		/// 項目「FACE_NO_TO1(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to1;
		/// <summary>
		/// 項目「FACE_NO_FROM2(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from2;
		/// <summary>
		/// 項目「FACE_NO_TO2(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to2;
		/// <summary>
		/// 項目「FACE_NO_FROM3(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from3;
		/// <summary>
		/// 項目「FACE_NO_TO3(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to3;
		/// <summary>
		/// 項目「FACE_NO_FROM4(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from4;
		/// <summary>
		/// 項目「FACE_NO_TO4(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to4;
		/// <summary>
		/// 項目「FACE_NO_FROM5(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from5;
		/// <summary>
		/// 項目「FACE_NO_TO5(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to5;
		/// <summary>
		/// 項目「FACE_NO_FROM6(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from6;
		/// <summary>
		/// 項目「FACE_NO_TO6(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to6;
		/// <summary>
		/// 項目「FACE_NO_FROM7(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from7;
		/// <summary>
		/// 項目「FACE_NO_TO7(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to7;
		/// <summary>
		/// 項目「FACE_NO_FROM8(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from8;
		/// <summary>
		/// 項目「FACE_NO_TO8(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to8;
		/// <summary>
		/// 項目「FACE_NO_FROM9(フェイスNoFROM)」の値
		/// </summary>
		private string _face_no_from9;
		/// <summary>
		/// 項目「FACE_NO_TO9(フェイスNoTO)」の値
		/// </summary>
		private string _face_no_to9;
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
		/// 項目「FACE_NO_FROM1(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from1
		{
			get
			{
				return this._face_no_from1;
			}
			set
			{
				this._face_no_from1 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO1(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to1
		{
			get
			{
				return this._face_no_to1;
			}
			set
			{
				this._face_no_to1 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM2(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from2
		{
			get
			{
				return this._face_no_from2;
			}
			set
			{
				this._face_no_from2 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO2(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to2
		{
			get
			{
				return this._face_no_to2;
			}
			set
			{
				this._face_no_to2 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM3(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from3
		{
			get
			{
				return this._face_no_from3;
			}
			set
			{
				this._face_no_from3 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO3(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to3
		{
			get
			{
				return this._face_no_to3;
			}
			set
			{
				this._face_no_to3 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM4(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from4
		{
			get
			{
				return this._face_no_from4;
			}
			set
			{
				this._face_no_from4 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO4(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to4
		{
			get
			{
				return this._face_no_to4;
			}
			set
			{
				this._face_no_to4 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM5(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from5
		{
			get
			{
				return this._face_no_from5;
			}
			set
			{
				this._face_no_from5 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO5(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to5
		{
			get
			{
				return this._face_no_to5;
			}
			set
			{
				this._face_no_to5 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM6(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from6
		{
			get
			{
				return this._face_no_from6;
			}
			set
			{
				this._face_no_from6 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO6(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to6
		{
			get
			{
				return this._face_no_to6;
			}
			set
			{
				this._face_no_to6 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM7(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from7
		{
			get
			{
				return this._face_no_from7;
			}
			set
			{
				this._face_no_from7 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO7(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to7
		{
			get
			{
				return this._face_no_to7;
			}
			set
			{
				this._face_no_to7 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM8(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from8
		{
			get
			{
				return this._face_no_from8;
			}
			set
			{
				this._face_no_from8 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO8(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to8
		{
			get
			{
				return this._face_no_to8;
			}
			set
			{
				this._face_no_to8 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_FROM9(フェイスNoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from9
		{
			get
			{
				return this._face_no_from9;
			}
			set
			{
				this._face_no_from9 = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO9(フェイスNoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to9
		{
			get
			{
				return this._face_no_to9;
			}
			set
			{
				this._face_no_to9 = value;
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
		public Tj100f01ResultVO() : base()
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
			sb.Append("Face_no_from1:").Append(this._face_no_from1).AppendLine();
			sb.Append("Face_no_to1:").Append(this._face_no_to1).AppendLine();
			sb.Append("Face_no_from2:").Append(this._face_no_from2).AppendLine();
			sb.Append("Face_no_to2:").Append(this._face_no_to2).AppendLine();
			sb.Append("Face_no_from3:").Append(this._face_no_from3).AppendLine();
			sb.Append("Face_no_to3:").Append(this._face_no_to3).AppendLine();
			sb.Append("Face_no_from4:").Append(this._face_no_from4).AppendLine();
			sb.Append("Face_no_to4:").Append(this._face_no_to4).AppendLine();
			sb.Append("Face_no_from5:").Append(this._face_no_from5).AppendLine();
			sb.Append("Face_no_to5:").Append(this._face_no_to5).AppendLine();
			sb.Append("Face_no_from6:").Append(this._face_no_from6).AppendLine();
			sb.Append("Face_no_to6:").Append(this._face_no_to6).AppendLine();
			sb.Append("Face_no_from7:").Append(this._face_no_from7).AppendLine();
			sb.Append("Face_no_to7:").Append(this._face_no_to7).AppendLine();
			sb.Append("Face_no_from8:").Append(this._face_no_from8).AppendLine();
			sb.Append("Face_no_to8:").Append(this._face_no_to8).AppendLine();
			sb.Append("Face_no_from9:").Append(this._face_no_from9).AppendLine();
			sb.Append("Face_no_to9:").Append(this._face_no_to9).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
