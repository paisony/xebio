using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj160p01.Formvo.Baseform
{
  /// <summary>
  /// Tj160f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj160f01BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

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
		/// 項目「FACE_NO_FROM(フェイスNo.FROM)」の値
		/// </summary>
		private string _face_no_from;
		/// <summary>
		/// 項目「FACE_NO_TO(フェイスNo.TO)」の値
		/// </summary>
		private string _face_no_to;
		/// <summary>
		/// 項目「NYURYOKU_YMD_FROM(入力日FROM)」の値
		/// </summary>
		private string _nyuryoku_ymd_from;
		/// <summary>
		/// 項目「NYURYOKU_YMD_TO(入力日TO)」の値
		/// </summary>
		private string _nyuryoku_ymd_to;
		/// <summary>
		/// 項目「TYOHUKU_UMU(重複有無)」の値
		/// </summary>
		private string _tyohuku_umu;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
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
		/// 項目「FACE_NO_FROM(フェイスNo.FROM)」の値を取得または設定する。
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
		/// 項目「FACE_NO_TO(フェイスNo.TO)」の値を取得または設定する。
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
		/// 項目「NYURYOKU_YMD_FROM(入力日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryoku_ymd_from
		{
			get
			{
				return this._nyuryoku_ymd_from;
			}
			set
			{
				this._nyuryoku_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKU_YMD_TO(入力日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryoku_ymd_to
		{
			get
			{
				return this._nyuryoku_ymd_to;
			}
			set
			{
				this._nyuryoku_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「TYOHUKU_UMU(重複有無)」の値を取得または設定する。
		/// </summary>
		public virtual string Tyohuku_umu
		{
			get
			{
				return this._tyohuku_umu;
			}
			set
			{
				this._tyohuku_umu = value;
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
		public Tj160f01BaseForm() : base()
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
			sb.Append("Face_no_from:").Append(this._face_no_from).AppendLine();
			sb.Append("Face_no_to:").Append(this._face_no_to).AppendLine();
			sb.Append("Nyuryoku_ymd_from:").Append(this._nyuryoku_ymd_from).AppendLine();
			sb.Append("Nyuryoku_ymd_to:").Append(this._nyuryoku_ymd_to).AppendLine();
			sb.Append("Tyohuku_umu:").Append(this._tyohuku_umu).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
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
			return "Tj160f01";
		}
		#endregion

		#endregion
	}
}
