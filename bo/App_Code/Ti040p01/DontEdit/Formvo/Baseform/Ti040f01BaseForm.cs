using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ti040p01.Formvo.Baseform
{
  /// <summary>
  /// Ti040f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti040f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「LABEL_CD_FROM(ラベル発行機ＩＤＦＲＯＭ)」の値
		/// </summary>
		private string _label_cd_from;
		/// <summary>
		/// 項目「LABEL_CD_FROM2(ラベル発行機ＩＤＦＲＯＭ)」の値
		/// </summary>
		private string _label_cd_from2;
		/// <summary>
		/// 項目「LABEL_CD_TO(ラベル発行機ＩＤＴＯ)」の値
		/// </summary>
		private string _label_cd_to;
		/// <summary>
		/// 項目「LABEL_CD_TO2(ラベル発行機ＩＤＴＯ)」の値
		/// </summary>
		private string _label_cd_to2;
		/// <summary>
		/// 項目「LABEL_IP_FROM(ラベル発行機ＩＰＦＲＯＭ)」の値
		/// </summary>
		private string _label_ip_from;
		/// <summary>
		/// 項目「LABEL_IP_FROM2(ラベル発行機ＩＰＦＲＯＭ)」の値
		/// </summary>
		private string _label_ip_from2;
		/// <summary>
		/// 項目「LABEL_IP_FROM3(ラベル発行機ＩＰＦＲＯＭ)」の値
		/// </summary>
		private string _label_ip_from3;
		/// <summary>
		/// 項目「LABEL_IP_FROM4(ラベル発行機ＩＰＦＲＯＭ)」の値
		/// </summary>
		private string _label_ip_from4;
		/// <summary>
		/// 項目「LABEL_IP_TO(ラベル発行機ＩＰＴＯ)」の値
		/// </summary>
		private string _label_ip_to;
		/// <summary>
		/// 項目「LABEL_IP_TO2(ラベル発行機ＩＰＴＯ)」の値
		/// </summary>
		private string _label_ip_to2;
		/// <summary>
		/// 項目「LABEL_IP_TO3(ラベル発行機ＩＰＴＯ)」の値
		/// </summary>
		private string _label_ip_to3;
		/// <summary>
		/// 項目「LABEL_IP_TO4(ラベル発行機ＩＰＴＯ)」の値
		/// </summary>
		private string _label_ip_to4;
		/// <summary>
		/// 項目「LABEL_NM(ラベル発行機名)」の値
		/// </summary>
		private string _label_nm;
		/// <summary>
		/// 項目「LABEL_BIKO(備考)」の値
		/// </summary>
		private string _label_biko;
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
		/// 項目「LABEL_CD_FROM(ラベル発行機ＩＤＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd_from
		{
			get
			{
				return this._label_cd_from;
			}
			set
			{
				this._label_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_CD_FROM2(ラベル発行機ＩＤＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd_from2
		{
			get
			{
				return this._label_cd_from2;
			}
			set
			{
				this._label_cd_from2 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_CD_TO(ラベル発行機ＩＤＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd_to
		{
			get
			{
				return this._label_cd_to;
			}
			set
			{
				this._label_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_CD_TO2(ラベル発行機ＩＤＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd_to2
		{
			get
			{
				return this._label_cd_to2;
			}
			set
			{
				this._label_cd_to2 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_FROM(ラベル発行機ＩＰＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_from
		{
			get
			{
				return this._label_ip_from;
			}
			set
			{
				this._label_ip_from = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_FROM2(ラベル発行機ＩＰＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_from2
		{
			get
			{
				return this._label_ip_from2;
			}
			set
			{
				this._label_ip_from2 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_FROM3(ラベル発行機ＩＰＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_from3
		{
			get
			{
				return this._label_ip_from3;
			}
			set
			{
				this._label_ip_from3 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_FROM4(ラベル発行機ＩＰＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_from4
		{
			get
			{
				return this._label_ip_from4;
			}
			set
			{
				this._label_ip_from4 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_TO(ラベル発行機ＩＰＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_to
		{
			get
			{
				return this._label_ip_to;
			}
			set
			{
				this._label_ip_to = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_TO2(ラベル発行機ＩＰＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_to2
		{
			get
			{
				return this._label_ip_to2;
			}
			set
			{
				this._label_ip_to2 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_TO3(ラベル発行機ＩＰＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_to3
		{
			get
			{
				return this._label_ip_to3;
			}
			set
			{
				this._label_ip_to3 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP_TO4(ラベル発行機ＩＰＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip_to4
		{
			get
			{
				return this._label_ip_to4;
			}
			set
			{
				this._label_ip_to4 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_NM(ラベル発行機名)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_nm
		{
			get
			{
				return this._label_nm;
			}
			set
			{
				this._label_nm = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_BIKO(備考)」の値を取得または設定する。
		/// </summary>
		public virtual string Label_biko
		{
			get
			{
				return this._label_biko;
			}
			set
			{
				this._label_biko = value;
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
		public Ti040f01BaseForm() : base()
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
			sb.Append("Label_cd_from:").Append(this._label_cd_from).AppendLine();
			sb.Append("Label_cd_from2:").Append(this._label_cd_from2).AppendLine();
			sb.Append("Label_cd_to:").Append(this._label_cd_to).AppendLine();
			sb.Append("Label_cd_to2:").Append(this._label_cd_to2).AppendLine();
			sb.Append("Label_ip_from:").Append(this._label_ip_from).AppendLine();
			sb.Append("Label_ip_from2:").Append(this._label_ip_from2).AppendLine();
			sb.Append("Label_ip_from3:").Append(this._label_ip_from3).AppendLine();
			sb.Append("Label_ip_from4:").Append(this._label_ip_from4).AppendLine();
			sb.Append("Label_ip_to:").Append(this._label_ip_to).AppendLine();
			sb.Append("Label_ip_to2:").Append(this._label_ip_to2).AppendLine();
			sb.Append("Label_ip_to3:").Append(this._label_ip_to3).AppendLine();
			sb.Append("Label_ip_to4:").Append(this._label_ip_to4).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
			sb.Append("Label_biko:").Append(this._label_biko).AppendLine();
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
			return "Ti040f01";
		}
		#endregion

		#endregion
	}
}
