using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta080p01.VO
{
  /// <summary>
  /// Ta080f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Ta080f01ResultVO : StandardBaseVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「YOSAN_YMD_FROM(年月度ＦＲＯＭ)」の値
		/// </summary>
		private string _yosan_ymd_from;
		/// <summary>
		/// 項目「YOSAN_YMD_TO(年月度ＴＯ)」の値
		/// </summary>
		private string _yosan_ymd_to;
		/// <summary>
		/// 項目「YOSAN_CD_FROM(仕入枠グループコードＦＲＯＭ)」の値
		/// </summary>
		private string _yosan_cd_from;
		/// <summary>
		/// 項目「YOSAN_NM_FROM()」の値
		/// </summary>
		private string _yosan_nm_from;
		/// <summary>
		/// 項目「YOSAN_CD_TO(仕入枠グループコードＴＯ)」の値
		/// </summary>
		private string _yosan_cd_to;
		/// <summary>
		/// 項目「YOSAN_NM_TO()」の値
		/// </summary>
		private string _yosan_nm_to;
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値
		/// </summary>
		private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値
		/// </summary>
		private string _add_ymd_to;
		/// <summary>
		/// 項目「TANTOSYA_CD(登録担当者)」の値
		/// </summary>
		private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値
		/// </summary>
		private string _apply_ymd_from;
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値
		/// </summary>
		private string _apply_ymd_to;
		/// <summary>
		/// 項目「SINSEI_SB(申請種別)」の値
		/// </summary>
		private string _sinsei_sb;
		/// <summary>
		/// 項目「IRAIRIYU_CD(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd;
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd1;
		/// <summary>
		/// 項目「JOTAI_KBN(状態)」の値
		/// </summary>
		private string _jotai_kbn;
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
		/// 項目「SEARCHCNT(検索件数)」の値
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
		/// 項目「YOSAN_YMD_FROM(年月度ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_ymd_from
		{
			get
			{
				return this._yosan_ymd_from;
			}
			set
			{
				this._yosan_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_YMD_TO(年月度ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_ymd_to
		{
			get
			{
				return this._yosan_ymd_to;
			}
			set
			{
				this._yosan_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_CD_FROM(仕入枠グループコードＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_cd_from
		{
			get
			{
				return this._yosan_cd_from;
			}
			set
			{
				this._yosan_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_nm_from
		{
			get
			{
				return this._yosan_nm_from;
			}
			set
			{
				this._yosan_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_CD_TO(仕入枠グループコードＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_cd_to
		{
			get
			{
				return this._yosan_cd_to;
			}
			set
			{
				this._yosan_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_nm_to
		{
			get
			{
				return this._yosan_nm_to;
			}
			set
			{
				this._yosan_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_from
		{
			get
			{
				return this._add_ymd_from;
			}
			set
			{
				this._add_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_to
		{
			get
			{
				return this._add_ymd_to;
			}
			set
			{
				this._add_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD(登録担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd
		{
			get
			{
				return this._tantosya_cd;
			}
			set
			{
				this._tantosya_cd = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm
		{
			get
			{
				return this._hanbaiin_nm;
			}
			set
			{
				this._hanbaiin_nm = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_ymd_from
		{
			get
			{
				return this._apply_ymd_from;
			}
			set
			{
				this._apply_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_ymd_to
		{
			get
			{
				return this._apply_ymd_to;
			}
			set
			{
				this._apply_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「SINSEI_SB(申請種別)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinsei_sb
		{
			get
			{
				return this._sinsei_sb;
			}
			set
			{
				this._sinsei_sb = value;
			}
		}
		/// <summary>
		/// 項目「IRAIRIYU_CD(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd
		{
			get
			{
				return this._irairiyu_cd;
			}
			set
			{
				this._irairiyu_cd = value;
			}
		}
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd1
		{
			get
			{
				return this._irairiyu_cd1;
			}
			set
			{
				this._irairiyu_cd1 = value;
			}
		}
		/// <summary>
		/// 項目「JOTAI_KBN(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Jotai_kbn
		{
			get
			{
				return this._jotai_kbn;
			}
			set
			{
				this._jotai_kbn = value;
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
		/// 項目「SEARCHCNT(検索件数)」の値を取得または設定する。
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
		public Ta080f01ResultVO() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Yosan_ymd_from:").Append(this._yosan_ymd_from).AppendLine();
			sb.Append("Yosan_ymd_to:").Append(this._yosan_ymd_to).AppendLine();
			sb.Append("Yosan_cd_from:").Append(this._yosan_cd_from).AppendLine();
			sb.Append("Yosan_nm_from:").Append(this._yosan_nm_from).AppendLine();
			sb.Append("Yosan_cd_to:").Append(this._yosan_cd_to).AppendLine();
			sb.Append("Yosan_nm_to:").Append(this._yosan_nm_to).AppendLine();
			sb.Append("Add_ymd_from:").Append(this._add_ymd_from).AppendLine();
			sb.Append("Add_ymd_to:").Append(this._add_ymd_to).AppendLine();
			sb.Append("Tantosya_cd:").Append(this._tantosya_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Apply_ymd_from:").Append(this._apply_ymd_from).AppendLine();
			sb.Append("Apply_ymd_to:").Append(this._apply_ymd_to).AppendLine();
			sb.Append("Sinsei_sb:").Append(this._sinsei_sb).AppendLine();
			sb.Append("Irairiyu_cd:").Append(this._irairiyu_cd).AppendLine();
			sb.Append("Irairiyu_cd1:").Append(this._irairiyu_cd1).AppendLine();
			sb.Append("Jotai_kbn:").Append(this._jotai_kbn).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
