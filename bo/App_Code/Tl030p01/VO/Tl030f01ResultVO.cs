using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl030p01.VO
{
  /// <summary>
  /// Tl030f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tl030f01ResultVO : StandardBaseVO
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
		/// 項目「SINSEIMOTO(申請元)」の値
		/// </summary>
		private string _sinseimoto;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門FROM)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門TO)」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値
		/// </summary>
		private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値
		/// </summary>
		private string _sinseitan_nm;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示NoFROM)」の値
		/// </summary>
		private string _baihen_shiji_no_from;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示NoTO)」の値
		/// </summary>
		private string _baihen_shiji_no_to;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(作業開始日FROM)」の値
		/// </summary>
		private string _baihensagyokaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_TO(作業開始日TO)」の値
		/// </summary>
		private string _baihensagyokaisi_ymd_to;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_FROM(開始日FROM)」の値
		/// </summary>
		private string _baihenkaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(開始日TO)」の値
		/// </summary>
		private string _baihenkaisi_ymd_to;
		/// <summary>
		/// 項目「GENBAIKA_SHIJIBAIKA_FLG(現売価＝指示売価のみ)」の値
		/// </summary>
		private string _genbaika_shijibaika_flg;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
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
		/// 項目「SINSEIMOTO(申請元)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseimoto
		{
			get
			{
				return this._sinseimoto;
			}
			set
			{
				this._sinseimoto = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_from
		{
			get
			{
				return this._bumon_cd_from;
			}
			set
			{
				this._bumon_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_from
		{
			get
			{
				return this._bumon_nm_from;
			}
			set
			{
				this._bumon_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_TO(部門TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_to
		{
			get
			{
				return this._bumon_cd_to;
			}
			set
			{
				this._bumon_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_to
		{
			get
			{
				return this._bumon_nm_to;
			}
			set
			{
				this._bumon_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値を取得または設定する。
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
		/// 項目「SINSEITAN_NM()」の値を取得または設定する。
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
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示NoFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_shiji_no_from
		{
			get
			{
				return this._baihen_shiji_no_from;
			}
			set
			{
				this._baihen_shiji_no_from = value;
			}
		}
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示NoTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_shiji_no_to
		{
			get
			{
				return this._baihen_shiji_no_to;
			}
			set
			{
				this._baihen_shiji_no_to = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(作業開始日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihensagyokaisi_ymd_from
		{
			get
			{
				return this._baihensagyokaisi_ymd_from;
			}
			set
			{
				this._baihensagyokaisi_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_TO(作業開始日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihensagyokaisi_ymd_to
		{
			get
			{
				return this._baihensagyokaisi_ymd_to;
			}
			set
			{
				this._baihensagyokaisi_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_FROM(開始日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihenkaisi_ymd_from
		{
			get
			{
				return this._baihenkaisi_ymd_from;
			}
			set
			{
				this._baihenkaisi_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(開始日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihenkaisi_ymd_to
		{
			get
			{
				return this._baihenkaisi_ymd_to;
			}
			set
			{
				this._baihenkaisi_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「GENBAIKA_SHIJIBAIKA_FLG(現売価＝指示売価のみ)」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_shijibaika_flg
		{
			get
			{
				return this._genbaika_shijibaika_flg;
			}
			set
			{
				this._genbaika_shijibaika_flg = value;
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
		public Tl030f01ResultVO() : base()
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
			sb.Append("Sinseimoto:").Append(this._sinseimoto).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Sinseitan_cd:").Append(this._sinseitan_cd).AppendLine();
			sb.Append("Sinseitan_nm:").Append(this._sinseitan_nm).AppendLine();
			sb.Append("Baihen_shiji_no_from:").Append(this._baihen_shiji_no_from).AppendLine();
			sb.Append("Baihen_shiji_no_to:").Append(this._baihen_shiji_no_to).AppendLine();
			sb.Append("Baihensagyokaisi_ymd_from:").Append(this._baihensagyokaisi_ymd_from).AppendLine();
			sb.Append("Baihensagyokaisi_ymd_to:").Append(this._baihensagyokaisi_ymd_to).AppendLine();
			sb.Append("Baihenkaisi_ymd_from:").Append(this._baihenkaisi_ymd_from).AppendLine();
			sb.Append("Baihenkaisi_ymd_to:").Append(this._baihenkaisi_ymd_to).AppendLine();
			sb.Append("Genbaika_shijibaika_flg:").Append(this._genbaika_shijibaika_flg).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
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
