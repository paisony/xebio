using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl020p01.VO
{
  /// <summary>
  /// Tl020f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tl020f02ResultVO : StandardBaseVO
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
		/// 項目「SHINSEIMOTO_NM(申請元)」の値
		/// </summary>
		private string _shinseimoto_nm;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値
		/// </summary>
		private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者)」の値
		/// </summary>
		private string _sinseitan_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO(売変指示Ｎｏ)」の値
		/// </summary>
		private string _baihen_shiji_no;
		/// <summary>
		/// 項目「BAIHEN_RIYU_NM(売変理由)」の値
		/// </summary>
		private string _baihen_riyu_nm;
		/// <summary>
		/// 項目「TOROKUKAK_CD(登録確定者)」の値
		/// </summary>
		private string _torokukak_cd;
		/// <summary>
		/// 項目「TOROKUKAK_NM()」の値
		/// </summary>
		private string _torokukak_nm;
		/// <summary>
		/// 項目「COMMENT_NM(コメント)」の値
		/// </summary>
		private string _comment_nm;
		/// <summary>
		/// 項目「AIHENSAGYOKAISI_YMD(作業開始日)」の値
		/// </summary>
		private string _aihensagyokaisi_ymd;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD(開始日)」の値
		/// </summary>
		private string _baihenkaisi_ymd;
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
		/// 項目「SHINSEIMOTO_NM(申請元)」の値を取得または設定する。
		/// </summary>
		public virtual string Shinseimoto_nm
		{
			get
			{
				return this._shinseimoto_nm;
			}
			set
			{
				this._shinseimoto_nm = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者コード)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_cd
		{
			get
			{
				return this._sinseitan_cd;
			}
			set
			{
				this._sinseitan_cd = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_NM(申請担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_nm
		{
			get
			{
				return this._sinseitan_nm;
			}
			set
			{
				this._sinseitan_nm = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd
		{
			get
			{
				return this._bumon_cd;
			}
			set
			{
				this._bumon_cd = value;
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
		/// 項目「BAIHEN_SHIJI_NO(売変指示Ｎｏ)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_shiji_no
		{
			get
			{
				return this._baihen_shiji_no;
			}
			set
			{
				this._baihen_shiji_no = value;
			}
		}
		/// <summary>
		/// 項目「BAIHEN_RIYU_NM(売変理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_riyu_nm
		{
			get
			{
				return this._baihen_riyu_nm;
			}
			set
			{
				this._baihen_riyu_nm = value;
			}
		}
		/// <summary>
		/// 項目「TOROKUKAK_CD(登録確定者)」の値を取得または設定する。
		/// </summary>
		public virtual string Torokukak_cd
		{
			get
			{
				return this._torokukak_cd;
			}
			set
			{
				this._torokukak_cd = value;
			}
		}
		/// <summary>
		/// 項目「TOROKUKAK_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Torokukak_nm
		{
			get
			{
				return this._torokukak_nm;
			}
			set
			{
				this._torokukak_nm = value;
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
		/// 項目「AIHENSAGYOKAISI_YMD(作業開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Aihensagyokaisi_ymd
		{
			get
			{
				return this._aihensagyokaisi_ymd;
			}
			set
			{
				this._aihensagyokaisi_ymd = value;
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
		public Tl020f02ResultVO() : base()
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
			sb.Append("Shinseimoto_nm:").Append(this._shinseimoto_nm).AppendLine();
			sb.Append("Sinseitan_cd:").Append(this._sinseitan_cd).AppendLine();
			sb.Append("Sinseitan_nm:").Append(this._sinseitan_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Baihen_shiji_no:").Append(this._baihen_shiji_no).AppendLine();
			sb.Append("Baihen_riyu_nm:").Append(this._baihen_riyu_nm).AppendLine();
			sb.Append("Torokukak_cd:").Append(this._torokukak_cd).AppendLine();
			sb.Append("Torokukak_nm:").Append(this._torokukak_nm).AppendLine();
			sb.Append("Comment_nm:").Append(this._comment_nm).AppendLine();
			sb.Append("Aihensagyokaisi_ymd:").Append(this._aihensagyokaisi_ymd).AppendLine();
			sb.Append("Baihenkaisi_ymd:").Append(this._baihenkaisi_ymd).AppendLine();
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
