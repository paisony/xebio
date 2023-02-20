using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te070p01.VO
{
  /// <summary>
  /// Te070f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Te070f01ResultVO : StandardBaseVO
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
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値
		/// </summary>
		private string _denpyo_jyotai;
		/// <summary>
		/// 項目「SYUKKA_YMD_FROM(出荷日ＦＲＯＭ)」の値
		/// </summary>
		private string _syukka_ymd_from;
		/// <summary>
		/// 項目「SYUKKA_YMD_TO(出荷日ＴＯ)」の値
		/// </summary>
		private string _syukka_ymd_to;
		/// <summary>
		/// 項目「JYURYO_YMD_FROM(入荷日ＦＲＯＭ)」の値
		/// </summary>
		private string _jyuryo_ymd_from;
		/// <summary>
		/// 項目「JYURYO_YMD_TO(入荷日ＴＯ)」の値
		/// </summary>
		private string _jyuryo_ymd_to;
		/// <summary>
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店)」の値
		/// </summary>
		private string _syukkaten_cd;
		/// <summary>
		/// 項目「SYUKKATEN_NM()」の値
		/// </summary>
		private string _syukkaten_nm;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号FROM)」の値
		/// </summary>
		private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号TO)」の値
		/// </summary>
		private string _denpyo_bango_to;
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値
		/// </summary>
		private string _scm_cd;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「OFFLINE_NO(ｵﾌﾗｲﾝ伝票No)」の値
		/// </summary>
		private string _offline_no;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「EIGYO_YMD_HDN()」の値
		/// </summary>
		private string _eigyo_ymd_hdn;

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
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_jyotai
		{
			get
			{
				return this._denpyo_jyotai;
			}
			set
			{
				this._denpyo_jyotai = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKA_YMD_FROM(出荷日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukka_ymd_from
		{
			get
			{
				return this._syukka_ymd_from;
			}
			set
			{
				this._syukka_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKA_YMD_TO(出荷日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukka_ymd_to
		{
			get
			{
				return this._syukka_ymd_to;
			}
			set
			{
				this._syukka_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「JYURYO_YMD_FROM(入荷日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryo_ymd_from
		{
			get
			{
				return this._jyuryo_ymd_from;
			}
			set
			{
				this._jyuryo_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「JYURYO_YMD_TO(入荷日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryo_ymd_to
		{
			get
			{
				return this._jyuryo_ymd_to;
			}
			set
			{
				this._jyuryo_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd
		{
			get
			{
				return this._kaisya_cd;
			}
			set
			{
				this._kaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm
		{
			get
			{
				return this._kaisya_nm;
			}
			set
			{
				this._kaisya_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkaten_cd
		{
			get
			{
				return this._syukkaten_cd;
			}
			set
			{
				this._syukkaten_cd = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKATEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkaten_nm
		{
			get
			{
				return this._syukkaten_nm;
			}
			set
			{
				this._syukkaten_nm = value;
			}
		}
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_bango_from
		{
			get
			{
				return this._denpyo_bango_from;
			}
			set
			{
				this._denpyo_bango_from = value;
			}
		}
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_bango_to
		{
			get
			{
				return this._denpyo_bango_to;
			}
			set
			{
				this._denpyo_bango_to = value;
			}
		}
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値を取得または設定する。
		/// </summary>
		public virtual string Scm_cd
		{
			get
			{
				return this._scm_cd;
			}
			set
			{
				this._scm_cd = value;
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
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd
		{
			get
			{
				return this._scan_cd;
			}
			set
			{
				this._scan_cd = value;
			}
		}
		/// <summary>
		/// 項目「OFFLINE_NO(ｵﾌﾗｲﾝ伝票No)」の値を取得または設定する。
		/// </summary>
		public virtual string Offline_no
		{
			get
			{
				return this._offline_no;
			}
			set
			{
				this._offline_no = value;
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
		/// 項目「EIGYO_YMD_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string Eigyo_ymd_hdn
		{
			get
			{
				return this._eigyo_ymd_hdn;
			}
			set
			{
				this._eigyo_ymd_hdn = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te070f01ResultVO() : base()
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
			sb.Append("Denpyo_jyotai:").Append(this._denpyo_jyotai).AppendLine();
			sb.Append("Syukka_ymd_from:").Append(this._syukka_ymd_from).AppendLine();
			sb.Append("Syukka_ymd_to:").Append(this._syukka_ymd_to).AppendLine();
			sb.Append("Jyuryo_ymd_from:").Append(this._jyuryo_ymd_from).AppendLine();
			sb.Append("Jyuryo_ymd_to:").Append(this._jyuryo_ymd_to).AppendLine();
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Syukkaten_cd:").Append(this._syukkaten_cd).AppendLine();
			sb.Append("Syukkaten_nm:").Append(this._syukkaten_nm).AppendLine();
			sb.Append("Denpyo_bango_from:").Append(this._denpyo_bango_from).AppendLine();
			sb.Append("Denpyo_bango_to:").Append(this._denpyo_bango_to).AppendLine();
			sb.Append("Scm_cd:").Append(this._scm_cd).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Offline_no:").Append(this._offline_no).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Eigyo_ymd_hdn:").Append(this._eigyo_ymd_hdn).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
