using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tg020p01.VO
{
  /// <summary>
  /// Tg020f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tg020f01ResultVO : StandardBaseVO
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
		/// 項目「WARIRIT(割引率)」の値
		/// </summary>
		private string _waririt;
		/// <summary>
		/// 項目「MAISU(発行枚数)」の値
		/// </summary>
		private string _maisu;
		/// <summary>
		/// 項目「INJI_COMMENT(印字コメント)」の値
		/// </summary>
		private string _inji_comment;
		/// <summary>
		/// 項目「INJI_COMMENT_NM()」の値
		/// </summary>
		private string _inji_comment_nm;
		/// <summary>
		/// 項目「WARIGAK(割引額)」の値
		/// </summary>
		private string _warigak;
		/// <summary>
		/// 項目「MAISU2(発行枚数)」の値
		/// </summary>
		private string _maisu2;
		/// <summary>
		/// 項目「INJI_COMMENT2(印字コメント)」の値
		/// </summary>
		private string _inji_comment2;
		/// <summary>
		/// 項目「INJI_COMMENT_NM2()」の値
		/// </summary>
		private string _inji_comment_nm2;
		/// <summary>
		/// 項目「LABEL_CD()」の値
		/// </summary>
		private string _label_cd;
		/// <summary>
		/// 項目「LABEL_IP()」の値
		/// </summary>
		private string _label_ip;
		/// <summary>
		/// 項目「LABEL_NM()」の値
		/// </summary>
		private string _label_nm;
		/// <summary>
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;

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
		/// 項目「WARIRIT(割引率)」の値を取得または設定する。
		/// </summary>
		public virtual string Waririt
		{
			get
			{
				return this._waririt;
			}
			set
			{
				this._waririt = value;
			}
		}
		/// <summary>
		/// 項目「MAISU(発行枚数)」の値を取得または設定する。
		/// </summary>
		public virtual string Maisu
		{
			get
			{
				return this._maisu;
			}
			set
			{
				this._maisu = value;
			}
		}
		/// <summary>
		/// 項目「INJI_COMMENT(印字コメント)」の値を取得または設定する。
		/// </summary>
		public virtual string Inji_comment
		{
			get
			{
				return this._inji_comment;
			}
			set
			{
				this._inji_comment = value;
			}
		}
		/// <summary>
		/// 項目「INJI_COMMENT_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Inji_comment_nm
		{
			get
			{
				return this._inji_comment_nm;
			}
			set
			{
				this._inji_comment_nm = value;
			}
		}
		/// <summary>
		/// 項目「WARIGAK(割引額)」の値を取得または設定する。
		/// </summary>
		public virtual string Warigak
		{
			get
			{
				return this._warigak;
			}
			set
			{
				this._warigak = value;
			}
		}
		/// <summary>
		/// 項目「MAISU2(発行枚数)」の値を取得または設定する。
		/// </summary>
		public virtual string Maisu2
		{
			get
			{
				return this._maisu2;
			}
			set
			{
				this._maisu2 = value;
			}
		}
		/// <summary>
		/// 項目「INJI_COMMENT2(印字コメント)」の値を取得または設定する。
		/// </summary>
		public virtual string Inji_comment2
		{
			get
			{
				return this._inji_comment2;
			}
			set
			{
				this._inji_comment2 = value;
			}
		}
		/// <summary>
		/// 項目「INJI_COMMENT_NM2()」の値を取得または設定する。
		/// </summary>
		public virtual string Inji_comment_nm2
		{
			get
			{
				return this._inji_comment_nm2;
			}
			set
			{
				this._inji_comment_nm2 = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd
		{
			get
			{
				return this._label_cd;
			}
			set
			{
				this._label_cd = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP()」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip
		{
			get
			{
				return this._label_ip;
			}
			set
			{
				this._label_ip = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_NM()」の値を取得または設定する。
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg020f01ResultVO() : base()
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
			sb.Append("Waririt:").Append(this._waririt).AppendLine();
			sb.Append("Maisu:").Append(this._maisu).AppendLine();
			sb.Append("Inji_comment:").Append(this._inji_comment).AppendLine();
			sb.Append("Inji_comment_nm:").Append(this._inji_comment_nm).AppendLine();
			sb.Append("Warigak:").Append(this._warigak).AppendLine();
			sb.Append("Maisu2:").Append(this._maisu2).AppendLine();
			sb.Append("Inji_comment2:").Append(this._inji_comment2).AppendLine();
			sb.Append("Inji_comment_nm2:").Append(this._inji_comment_nm2).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
