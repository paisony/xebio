using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl020p01.VO
{
  /// <summary>
  /// Tl020f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tl020f01ResultVO : StandardBaseVO
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
		/// 項目「KAKUTEI_JYOTAI(確定状態)」の値
		/// </summary>
		private string _kakutei_jyotai;
		/// <summary>
		/// 項目「SINSEIMOTO(申請元)」の値
		/// </summary>
		private string _sinseimoto;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門ＦＲＯＭ)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門ＴＯ)」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示ＮｏＦＲＯＭ)」の値
		/// </summary>
		private string _baihen_shiji_no_from;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示ＮｏTO)」の値
		/// </summary>
		private string _baihen_shiji_no_to;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(作業開始日ＦＲＯＭ)」の値
		/// </summary>
		private string _baihensagyokaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENSAGYOKAISI_YMD_TO(作業開始日TO)」の値
		/// </summary>
		private string _baihensagyokaisi_ymd_to;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_FROM(開始日ＦＲＯＭ)」の値
		/// </summary>
		private string _baihenkaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(開始日TO)」の値
		/// </summary>
		private string _baihenkaisi_ymd_to;
		/// <summary>
		/// 項目「KAKUTEI_YMD_FROM(確定日ＦＲＯＭ)」の値
		/// </summary>
		private string _kakutei_ymd_from;
		/// <summary>
		/// 項目「KAKUTEI_YMD_TO(確定日TO)」の値
		/// </summary>
		private string _kakutei_ymd_to;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「TOROKUKAK_CD(登録確定者)」の値
		/// </summary>
		private string _torokukak_cd;
		/// <summary>
		/// 項目「TOROKUKAK_NM()」の値
		/// </summary>
		private string _torokukak_nm;
		/// <summary>
		/// 項目「BAIHEN_RIYTU(売変理由)」の値
		/// </summary>
		private string _baihen_riytu;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
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
		/// 項目「KAKUTEI_JYOTAI(確定状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakutei_jyotai
		{
			get
			{
				return this._kakutei_jyotai;
			}
			set
			{
				this._kakutei_jyotai = value;
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
		/// 項目「BUMON_CD_FROM(部門ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「BUMON_CD_TO(部門ＴＯ)」の値を取得または設定する。
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
		/// 項目「BAIHEN_SHIJI_NO_FROM(売変指示ＮｏＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「BAIHEN_SHIJI_NO_TO(売変指示ＮｏTO)」の値を取得または設定する。
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
		/// 項目「BAIHENSAGYOKAISI_YMD_FROM(作業開始日ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「BAIHENKAISI_YMD_FROM(開始日ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「KAKUTEI_YMD_FROM(確定日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakutei_ymd_from
		{
			get
			{
				return this._kakutei_ymd_from;
			}
			set
			{
				this._kakutei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「KAKUTEI_YMD_TO(確定日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakutei_ymd_to
		{
			get
			{
				return this._kakutei_ymd_to;
			}
			set
			{
				this._kakutei_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn
		{
			get
			{
				return this._old_jisya_hbn;
			}
			set
			{
				this._old_jisya_hbn = value;
			}
		}
		/// <summary>
		/// 項目「MAKER_HBN()」の値を取得または設定する。
		/// </summary>
		public virtual string Maker_hbn
		{
			get
			{
				return this._maker_hbn;
			}
			set
			{
				this._maker_hbn = value;
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
		/// 項目「BAIHEN_RIYTU(売変理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_riytu
		{
			get
			{
				return this._baihen_riytu;
			}
			set
			{
				this._baihen_riytu = value;
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
		public Tl020f01ResultVO() : base()
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
			sb.Append("Kakutei_jyotai:").Append(this._kakutei_jyotai).AppendLine();
			sb.Append("Sinseimoto:").Append(this._sinseimoto).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Baihen_shiji_no_from:").Append(this._baihen_shiji_no_from).AppendLine();
			sb.Append("Baihen_shiji_no_to:").Append(this._baihen_shiji_no_to).AppendLine();
			sb.Append("Baihensagyokaisi_ymd_from:").Append(this._baihensagyokaisi_ymd_from).AppendLine();
			sb.Append("Baihensagyokaisi_ymd_to:").Append(this._baihensagyokaisi_ymd_to).AppendLine();
			sb.Append("Baihenkaisi_ymd_from:").Append(this._baihenkaisi_ymd_from).AppendLine();
			sb.Append("Baihenkaisi_ymd_to:").Append(this._baihenkaisi_ymd_to).AppendLine();
			sb.Append("Kakutei_ymd_from:").Append(this._kakutei_ymd_from).AppendLine();
			sb.Append("Kakutei_ymd_to:").Append(this._kakutei_ymd_to).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Torokukak_cd:").Append(this._torokukak_cd).AppendLine();
			sb.Append("Torokukak_nm:").Append(this._torokukak_nm).AppendLine();
			sb.Append("Baihen_riytu:").Append(this._baihen_riytu).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
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
