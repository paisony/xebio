using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf020p01.VO
{
  /// <summary>
  /// Tf020f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tf020f01ResultVO : StandardBaseVO
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
		/// 項目「SYONIN_FLG(承認状態)」の値
		/// </summary>
		private string _syonin_flg;
		/// <summary>
		/// 項目「APPLY_YMD_FROM(申請日ＦＲＯＭ)」の値
		/// </summary>
		private string _apply_ymd_from;
		/// <summary>
		/// 項目「APPLY_YMD_TO(申請日ＴＯ)」の値
		/// </summary>
		private string _apply_ymd_to;
		/// <summary>
		/// 項目「KAKUTEI_YMD_FROM(確定日ＦＲＯＭ)」の値
		/// </summary>
		private string _kakutei_ymd_from;
		/// <summary>
		/// 項目「KAKUTEI_YMD_TO(確定日ＴＯ)」の値
		/// </summary>
		private string _kakutei_ymd_to;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値
		/// </summary>
		private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値
		/// </summary>
		private string _denpyo_bango_to;
		/// <summary>
		/// 項目「KAMOKU_CD_FROM(科目ＦＲＯＭ)」の値
		/// </summary>
		private string _kamoku_cd_from;
		/// <summary>
		/// 項目「KAMOKU_NM_FROM()」の値
		/// </summary>
		private string _kamoku_nm_from;
		/// <summary>
		/// 項目「KAMOKU_CD_TO(科目ＴＯ)」の値
		/// </summary>
		private string _kamoku_cd_to;
		/// <summary>
		/// 項目「KAMOKU_NM_TO()」の値
		/// </summary>
		private string _kamoku_nm_to;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請者)」の値
		/// </summary>
		private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値
		/// </summary>
		private string _sinseitan_nm;
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
		/// 項目「SYONIN_FLG(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonin_flg
		{
			get
			{
				return this._syonin_flg;
			}
			set
			{
				this._syonin_flg = value;
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
		/// 項目「KAKUTEI_YMD_TO(確定日ＴＯ)」の値を取得または設定する。
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
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値を取得または設定する。
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
		/// 項目「KAMOKU_CD_FROM(科目ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_cd_from
		{
			get
			{
				return this._kamoku_cd_from;
			}
			set
			{
				this._kamoku_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_nm_from
		{
			get
			{
				return this._kamoku_nm_from;
			}
			set
			{
				this._kamoku_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_CD_TO(科目ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_cd_to
		{
			get
			{
				return this._kamoku_cd_to;
			}
			set
			{
				this._kamoku_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_nm_to
		{
			get
			{
				return this._kamoku_nm_to;
			}
			set
			{
				this._kamoku_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請者)」の値を取得または設定する。
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
		public Tf020f01ResultVO() : base()
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
			sb.Append("Syonin_flg:").Append(this._syonin_flg).AppendLine();
			sb.Append("Apply_ymd_from:").Append(this._apply_ymd_from).AppendLine();
			sb.Append("Apply_ymd_to:").Append(this._apply_ymd_to).AppendLine();
			sb.Append("Kakutei_ymd_from:").Append(this._kakutei_ymd_from).AppendLine();
			sb.Append("Kakutei_ymd_to:").Append(this._kakutei_ymd_to).AppendLine();
			sb.Append("Denpyo_bango_from:").Append(this._denpyo_bango_from).AppendLine();
			sb.Append("Denpyo_bango_to:").Append(this._denpyo_bango_to).AppendLine();
			sb.Append("Kamoku_cd_from:").Append(this._kamoku_cd_from).AppendLine();
			sb.Append("Kamoku_nm_from:").Append(this._kamoku_nm_from).AppendLine();
			sb.Append("Kamoku_cd_to:").Append(this._kamoku_cd_to).AppendLine();
			sb.Append("Kamoku_nm_to:").Append(this._kamoku_nm_to).AppendLine();
			sb.Append("Sinseitan_cd:").Append(this._sinseitan_cd).AppendLine();
			sb.Append("Sinseitan_nm:").Append(this._sinseitan_nm).AppendLine();
			sb.Append("Jyuri_no_from:").Append(this._jyuri_no_from).AppendLine();
			sb.Append("Jyuri_no_to:").Append(this._jyuri_no_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
