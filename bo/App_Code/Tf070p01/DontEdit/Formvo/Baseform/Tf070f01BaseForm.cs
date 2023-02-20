using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf070p01.Formvo.Baseform
{
  /// <summary>
  /// Tf070f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf070f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「TONANHINKANRI_NO_FROM(管理番号ＦＲＯＭ)」の値
		/// </summary>
		private string _tonanhinkanri_no_from;
		/// <summary>
		/// 項目「TONANHINKANRI_NO_TO(管理番号ＴＯ)」の値
		/// </summary>
		private string _tonanhinkanri_no_to;
		/// <summary>
		/// 項目「JIKOHASSEI_YMD_FROM(事故発生日ＦＲＯＭ)」の値
		/// </summary>
		private string _jikohassei_ymd_from;
		/// <summary>
		/// 項目「JIKOHASSEI_YMD_TO(事故発生日ＴＯ)」の値
		/// </summary>
		private string _jikohassei_ymd_to;
		/// <summary>
		/// 項目「HOKOKU_YMD_FROM(報告日ＦＲＯＭ)」の値
		/// </summary>
		private string _hokoku_ymd_from;
		/// <summary>
		/// 項目「HOKOKU_YMD_TO(報告日ＴＯ)」の値
		/// </summary>
		private string _hokoku_ymd_to;
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告者)」の値
		/// </summary>
		private string _hokokutan_cd;
		/// <summary>
		/// 項目「HOKOKUTAN_NM()」の値
		/// </summary>
		private string _hokokutan_nm;
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD_FROM(警察届出日ＦＲＯＭ)」の値
		/// </summary>
		private string _keisatsutodoke_ymd_from;
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD_TO(警察届出日ＴＯ)」の値
		/// </summary>
		private string _keisatsutodoke_ymd_to;
		/// <summary>
		/// 項目「JYURI_NO_FROM(受理番号ＦＲＯＭ)」の値
		/// </summary>
		private string _jyuri_no_from;
		/// <summary>
		/// 項目「JYURI_NO_TO(受理番号ＴＯ)」の値
		/// </summary>
		private string _jyuri_no_to;
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
		/// 項目「TONANHINKANRI_NO_FROM(管理番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tonanhinkanri_no_from
		{
			get
			{
				return this._tonanhinkanri_no_from;
			}
			set
			{
				this._tonanhinkanri_no_from = value;
			}
		}
		/// <summary>
		/// 項目「TONANHINKANRI_NO_TO(管理番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Tonanhinkanri_no_to
		{
			get
			{
				return this._tonanhinkanri_no_to;
			}
			set
			{
				this._tonanhinkanri_no_to = value;
			}
		}
		/// <summary>
		/// 項目「JIKOHASSEI_YMD_FROM(事故発生日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jikohassei_ymd_from
		{
			get
			{
				return this._jikohassei_ymd_from;
			}
			set
			{
				this._jikohassei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「JIKOHASSEI_YMD_TO(事故発生日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jikohassei_ymd_to
		{
			get
			{
				return this._jikohassei_ymd_to;
			}
			set
			{
				this._jikohassei_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKU_YMD_FROM(報告日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Hokoku_ymd_from
		{
			get
			{
				return this._hokoku_ymd_from;
			}
			set
			{
				this._hokoku_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKU_YMD_TO(報告日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Hokoku_ymd_to
		{
			get
			{
				return this._hokoku_ymd_to;
			}
			set
			{
				this._hokoku_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告者)」の値を取得または設定する。
		/// </summary>
		public virtual string Hokokutan_cd
		{
			get
			{
				return this._hokokutan_cd;
			}
			set
			{
				this._hokokutan_cd = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKUTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hokokutan_nm
		{
			get
			{
				return this._hokokutan_nm;
			}
			set
			{
				this._hokokutan_nm = value;
			}
		}
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD_FROM(警察届出日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Keisatsutodoke_ymd_from
		{
			get
			{
				return this._keisatsutodoke_ymd_from;
			}
			set
			{
				this._keisatsutodoke_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD_TO(警察届出日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Keisatsutodoke_ymd_to
		{
			get
			{
				return this._keisatsutodoke_ymd_to;
			}
			set
			{
				this._keisatsutodoke_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「JYURI_NO_FROM(受理番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuri_no_from
		{
			get
			{
				return this._jyuri_no_from;
			}
			set
			{
				this._jyuri_no_from = value;
			}
		}
		/// <summary>
		/// 項目「JYURI_NO_TO(受理番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuri_no_to
		{
			get
			{
				return this._jyuri_no_to;
			}
			set
			{
				this._jyuri_no_to = value;
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
		public Tf070f01BaseForm() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Tonanhinkanri_no_from:").Append(this._tonanhinkanri_no_from).AppendLine();
			sb.Append("Tonanhinkanri_no_to:").Append(this._tonanhinkanri_no_to).AppendLine();
			sb.Append("Jikohassei_ymd_from:").Append(this._jikohassei_ymd_from).AppendLine();
			sb.Append("Jikohassei_ymd_to:").Append(this._jikohassei_ymd_to).AppendLine();
			sb.Append("Hokoku_ymd_from:").Append(this._hokoku_ymd_from).AppendLine();
			sb.Append("Hokoku_ymd_to:").Append(this._hokoku_ymd_to).AppendLine();
			sb.Append("Hokokutan_cd:").Append(this._hokokutan_cd).AppendLine();
			sb.Append("Hokokutan_nm:").Append(this._hokokutan_nm).AppendLine();
			sb.Append("Keisatsutodoke_ymd_from:").Append(this._keisatsutodoke_ymd_from).AppendLine();
			sb.Append("Keisatsutodoke_ymd_to:").Append(this._keisatsutodoke_ymd_to).AppendLine();
			sb.Append("Jyuri_no_from:").Append(this._jyuri_no_from).AppendLine();
			sb.Append("Jyuri_no_to:").Append(this._jyuri_no_to).AppendLine();
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
			return "Tf070f01";
		}
		#endregion

		#endregion
	}
}
