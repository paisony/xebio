using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Td040p01.Formvo.Baseform
{
  /// <summary>
  /// Td040f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td040f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「DENPYO_BANGO_FROM(伝票番号FROM)」の値
		/// </summary>
		private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号TO)」の値
		/// </summary>
		private string _denpyo_bango_to;
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
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_FROM(返品確定日FROM)」の値
		/// </summary>
		private string _henpin_kakutei_ymd_from;
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_TO(返品確定日TO)」の値
		/// </summary>
		private string _henpin_kakutei_ymd_to;
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日FROM)」の値
		/// </summary>
		private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO(登録日TO)」の値
		/// </summary>
		private string _add_ymd_to;
		/// <summary>
		/// 項目「KAI_SU(回数)」の値
		/// </summary>
		private string _kai_su;
		/// <summary>
		/// 項目「HENPIN_RIYU(返品理由)」の値
		/// </summary>
		private string _henpin_riyu;
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
		/// 項目「SEARCHCNT()」の値
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
		/// 項目「SIIRESAKI_CD(仕入先)」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_cd
		{
			get
			{
				return this._siiresaki_cd;
			}
			set
			{
				this._siiresaki_cd = value;
			}
		}
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_ryaku_nm
		{
			get
			{
				return this._siiresaki_ryaku_nm;
			}
			set
			{
				this._siiresaki_ryaku_nm = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd
		{
			get
			{
				return this._burando_cd;
			}
			set
			{
				this._burando_cd = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm
		{
			get
			{
				return this._burando_nm;
			}
			set
			{
				this._burando_nm = value;
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
		/// 項目「HENPIN_KAKUTEI_YMD_FROM(返品確定日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Henpin_kakutei_ymd_from
		{
			get
			{
				return this._henpin_kakutei_ymd_from;
			}
			set
			{
				this._henpin_kakutei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD_TO(返品確定日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Henpin_kakutei_ymd_to
		{
			get
			{
				return this._henpin_kakutei_ymd_to;
			}
			set
			{
				this._henpin_kakutei_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_FROM(登録日FROM)」の値を取得または設定する。
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
		/// 項目「ADD_YMD_TO(登録日TO)」の値を取得または設定する。
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
		/// 項目「KAI_SU(回数)」の値を取得または設定する。
		/// </summary>
		public virtual string Kai_su
		{
			get
			{
				return this._kai_su;
			}
			set
			{
				this._kai_su = value;
			}
		}
		/// <summary>
		/// 項目「HENPIN_RIYU(返品理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Henpin_riyu
		{
			get
			{
				return this._henpin_riyu;
			}
			set
			{
				this._henpin_riyu = value;
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
		public Td040f01BaseForm() : base()
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
			sb.Append("Denpyo_bango_from:").Append(this._denpyo_bango_from).AppendLine();
			sb.Append("Denpyo_bango_to:").Append(this._denpyo_bango_to).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Henpin_kakutei_ymd_from:").Append(this._henpin_kakutei_ymd_from).AppendLine();
			sb.Append("Henpin_kakutei_ymd_to:").Append(this._henpin_kakutei_ymd_to).AppendLine();
			sb.Append("Add_ymd_from:").Append(this._add_ymd_from).AppendLine();
			sb.Append("Add_ymd_to:").Append(this._add_ymd_to).AppendLine();
			sb.Append("Kai_su:").Append(this._kai_su).AppendLine();
			sb.Append("Henpin_riyu:").Append(this._henpin_riyu).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
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
			return "Td040f01";
		}
		#endregion

		#endregion
	}
}
