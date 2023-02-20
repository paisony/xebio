using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl010p01.VO
{
  /// <summary>
  /// Tl010f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tl010f02ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値
		/// </summary>
		private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「BUMON_CD_BO(部門)」の値
		/// </summary>
		private string _bumon_cd_bo;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD(開始日)」の値
		/// </summary>
		private string _baihenkaisi_ymd;
		/// <summary>
		/// 項目「KAISHI_JYOTAI_NM(開始状態)」の値
		/// </summary>
		private string _kaishi_jyotai_nm;
		/// <summary>
		/// 項目「COMMENT_NM(コメント)」の値
		/// </summary>
		private string _comment_nm;
		/// <summary>
		/// 項目「SHUTURYOKU_SEAL(出力シール)」の値
		/// </summary>
		private string _shuturyoku_seal;
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
		/// M1明細リスト
		/// </summary>
		protected IList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値を取得または設定する。
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
		/// 項目「BUMON_CD_BO(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_bo
		{
			get
			{
				return this._bumon_cd_bo;
			}
			set
			{
				this._bumon_cd_bo = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm
		{
			get
			{
				return this._bumon_nm;
			}
			set
			{
				this._bumon_nm = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD(開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihenkaisi_ymd
		{
			get
			{
				return this._baihenkaisi_ymd;
			}
			set
			{
				this._baihenkaisi_ymd = value;
			}
		}
		/// <summary>
		/// 項目「KAISHI_JYOTAI_NM(開始状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaishi_jyotai_nm
		{
			get
			{
				return this._kaishi_jyotai_nm;
			}
			set
			{
				this._kaishi_jyotai_nm = value;
			}
		}
		/// <summary>
		/// 項目「COMMENT_NM(コメント)」の値を取得または設定する。
		/// </summary>
		public virtual string Comment_nm
		{
			get
			{
				return this._comment_nm;
			}
			set
			{
				this._comment_nm = value;
			}
		}
		/// <summary>
		/// 項目「SHUTURYOKU_SEAL(出力シール)」の値を取得または設定する。
		/// </summary>
		public virtual string Shuturyoku_seal
		{
			get
			{
				return this._shuturyoku_seal;
			}
			set
			{
				this._shuturyoku_seal = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl010f02ResultVO() : base()
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
			sb.Append("Bumon_cd_bo:").Append(this._bumon_cd_bo).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Baihenkaisi_ymd:").Append(this._baihenkaisi_ymd).AppendLine();
			sb.Append("Kaishi_jyotai_nm:").Append(this._kaishi_jyotai_nm).AppendLine();
			sb.Append("Comment_nm:").Append(this._comment_nm).AppendLine();
			sb.Append("Shuturyoku_seal:").Append(this._shuturyoku_seal).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
