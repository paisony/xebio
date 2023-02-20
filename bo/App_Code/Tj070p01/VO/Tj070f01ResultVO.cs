using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj070p01.VO
{
  /// <summary>
  /// Tj070f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj070f01ResultVO : StandardBaseVO
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
		/// 項目「TENPO_CD_FROM(店舗)」の値
		/// </summary>
		private string _tenpo_cd_from;
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値
		/// </summary>
		private string _tenpo_nm_from;
		/// <summary>
		/// 項目「TENPO_CD_TO()」の値
		/// </summary>
		private string _tenpo_cd_to;
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値
		/// </summary>
		private string _tenpo_nm_to;
		/// <summary>
		/// 項目「TENPO_KAKUTEI_JYOKYO(店舗確定状況)」の値
		/// </summary>
		private string _tenpo_kakutei_jyokyo;
		/// <summary>
		/// 項目「SOSIN_JYOTAI(送信状態)」の値
		/// </summary>
		private string _sosin_jyotai;
		/// <summary>
		/// 項目「HHTJISSI_YMD_FROM(HHT実施日)」の値
		/// </summary>
		private string _hhtjissi_ymd_from;
		/// <summary>
		/// 項目「HHTJISSI_YMD_TO()」の値
		/// </summary>
		private string _hhtjissi_ymd_to;
		/// <summary>
		/// 項目「SOSIN_KAK_YMD_FROM(送信日)」の値
		/// </summary>
		private string _sosin_kak_ymd_from;
		/// <summary>
		/// 項目「SOSIN_KAK_YMD_TO()」の値
		/// </summary>
		private string _sosin_kak_ymd_to;
		/// <summary>
		/// 項目「KONKAI_FLG(今回分のみ)」の値
		/// </summary>
		private string _konkai_flg;
		/// <summary>
		/// 項目「MEISAI_SORT()」の値
		/// </summary>
		private string _meisai_sort;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
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
		/// 項目「TENPO_CD_FROM(店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_from
		{
			get
			{
				return this._tenpo_cd_from;
			}
			set
			{
				this._tenpo_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_from
		{
			get
			{
				return this._tenpo_nm_from;
			}
			set
			{
				this._tenpo_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_to
		{
			get
			{
				return this._tenpo_cd_to;
			}
			set
			{
				this._tenpo_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_to
		{
			get
			{
				return this._tenpo_nm_to;
			}
			set
			{
				this._tenpo_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_KAKUTEI_JYOKYO(店舗確定状況)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_kakutei_jyokyo
		{
			get
			{
				return this._tenpo_kakutei_jyokyo;
			}
			set
			{
				this._tenpo_kakutei_jyokyo = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_JYOTAI(送信状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_jyotai
		{
			get
			{
				return this._sosin_jyotai;
			}
			set
			{
				this._sosin_jyotai = value;
			}
		}
		/// <summary>
		/// 項目「HHTJISSI_YMD_FROM(HHT実施日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hhtjissi_ymd_from
		{
			get
			{
				return this._hhtjissi_ymd_from;
			}
			set
			{
				this._hhtjissi_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HHTJISSI_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Hhtjissi_ymd_to
		{
			get
			{
				return this._hhtjissi_ymd_to;
			}
			set
			{
				this._hhtjissi_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_KAK_YMD_FROM(送信日)」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_kak_ymd_from
		{
			get
			{
				return this._sosin_kak_ymd_from;
			}
			set
			{
				this._sosin_kak_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_KAK_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_kak_ymd_to
		{
			get
			{
				return this._sosin_kak_ymd_to;
			}
			set
			{
				this._sosin_kak_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「KONKAI_FLG(今回分のみ)」の値を取得または設定する。
		/// </summary>
		public virtual string Konkai_flg
		{
			get
			{
				return this._konkai_flg;
			}
			set
			{
				this._konkai_flg = value;
			}
		}
		/// <summary>
		/// 項目「MEISAI_SORT()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisai_sort
		{
			get
			{
				return this._meisai_sort;
			}
			set
			{
				this._meisai_sort = value;
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
		public Tj070f01ResultVO() : base()
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
			sb.Append("Tenpo_cd_from:").Append(this._tenpo_cd_from).AppendLine();
			sb.Append("Tenpo_nm_from:").Append(this._tenpo_nm_from).AppendLine();
			sb.Append("Tenpo_cd_to:").Append(this._tenpo_cd_to).AppendLine();
			sb.Append("Tenpo_nm_to:").Append(this._tenpo_nm_to).AppendLine();
			sb.Append("Tenpo_kakutei_jyokyo:").Append(this._tenpo_kakutei_jyokyo).AppendLine();
			sb.Append("Sosin_jyotai:").Append(this._sosin_jyotai).AppendLine();
			sb.Append("Hhtjissi_ymd_from:").Append(this._hhtjissi_ymd_from).AppendLine();
			sb.Append("Hhtjissi_ymd_to:").Append(this._hhtjissi_ymd_to).AppendLine();
			sb.Append("Sosin_kak_ymd_from:").Append(this._sosin_kak_ymd_from).AppendLine();
			sb.Append("Sosin_kak_ymd_to:").Append(this._sosin_kak_ymd_to).AppendLine();
			sb.Append("Konkai_flg:").Append(this._konkai_flg).AppendLine();
			sb.Append("Meisai_sort:").Append(this._meisai_sort).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
