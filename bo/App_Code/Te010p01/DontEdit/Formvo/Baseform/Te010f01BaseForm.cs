using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te010p01.Formvo.Baseform
{
  /// <summary>
  /// Te010f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te010f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値
		/// </summary>
		private string _denpyo_jyotai;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号FROM)」の値
		/// </summary>
		private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号TO)」の値
		/// </summary>
		private string _denpyo_bango_to;
		/// <summary>
		/// 項目「SIJI_BANGO_FROM(指示番号FROM)」の値
		/// </summary>
		private string _siji_bango_from;
		/// <summary>
		/// 項目「SIJI_BANGO_TO(指示番号TO)」の値
		/// </summary>
		private string _siji_bango_to;
		/// <summary>
		/// 項目「SYUKKA_YMD_FROM(出荷日)」の値
		/// </summary>
		private string _syukka_ymd_from;
		/// <summary>
		/// 項目「SYUKKA_YMD_TO()」の値
		/// </summary>
		private string _syukka_ymd_to;
		/// <summary>
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「JYURYOTEN_CD(入荷店)」の値
		/// </summary>
		private string _jyuryoten_cd;
		/// <summary>
		/// 項目「JURYOTEN_NM()」の値
		/// </summary>
		private string _juryoten_nm;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO()」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「SHUKKARIYU_KBN(出荷理由)」の値
		/// </summary>
		private string _shukkariyu_kbn;
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
		/// 項目「SEARCHCNT(検索件数)」の値
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
		/// 項目「SIJI_BANGO_FROM(指示番号FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Siji_bango_from
		{
			get
			{
				return this._siji_bango_from;
			}
			set
			{
				this._siji_bango_from = value;
			}
		}
		/// <summary>
		/// 項目「SIJI_BANGO_TO(指示番号TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Siji_bango_to
		{
			get
			{
				return this._siji_bango_to;
			}
			set
			{
				this._siji_bango_to = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKA_YMD_FROM(出荷日)」の値を取得または設定する。
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
		/// 項目「SYUKKA_YMD_TO()」の値を取得または設定する。
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
		/// 項目「JYURYOTEN_CD(入荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryoten_cd
		{
			get
			{
				return this._jyuryoten_cd;
			}
			set
			{
				this._jyuryoten_cd = value;
			}
		}
		/// <summary>
		/// 項目「JURYOTEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Juryoten_nm
		{
			get
			{
				return this._juryoten_nm;
			}
			set
			{
				this._juryoten_nm = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_cd
		{
			get
			{
				return this._nyuryokutan_cd;
			}
			set
			{
				this._nyuryokutan_cd = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_nm
		{
			get
			{
				return this._nyuryokutan_nm;
			}
			set
			{
				this._nyuryokutan_nm = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門)」の値を取得または設定する。
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
		/// 項目「BUMON_CD_TO()」の値を取得または設定する。
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
		/// 項目「SHUKKARIYU_KBN(出荷理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Shukkariyu_kbn
		{
			get
			{
				return this._shukkariyu_kbn;
			}
			set
			{
				this._shukkariyu_kbn = value;
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
		public Te010f01BaseForm() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Denpyo_jyotai:").Append(this._denpyo_jyotai).AppendLine();
			sb.Append("Denpyo_bango_from:").Append(this._denpyo_bango_from).AppendLine();
			sb.Append("Denpyo_bango_to:").Append(this._denpyo_bango_to).AppendLine();
			sb.Append("Siji_bango_from:").Append(this._siji_bango_from).AppendLine();
			sb.Append("Siji_bango_to:").Append(this._siji_bango_to).AppendLine();
			sb.Append("Syukka_ymd_from:").Append(this._syukka_ymd_from).AppendLine();
			sb.Append("Syukka_ymd_to:").Append(this._syukka_ymd_to).AppendLine();
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Jyuryoten_cd:").Append(this._jyuryoten_cd).AppendLine();
			sb.Append("Juryoten_nm:").Append(this._juryoten_nm).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Shukkariyu_kbn:").Append(this._shukkariyu_kbn).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Offline_no:").Append(this._offline_no).AppendLine();
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
			return "Te010f01";
		}
		#endregion

		#endregion
	}
}
