using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te130p01.Formvo.Baseform
{
  /// <summary>
  /// Te130f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te130f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「HEAD_TENPO_NM(ヘッダ店舗名)」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値
		/// </summary>
		private string _denpyo_jyotai;
		/// <summary>
		/// 項目「DENPYO_BANGO_FROM(伝票番号ＦＲＯＭ)」の値
		/// </summary>
		private string _denpyo_bango_from;
		/// <summary>
		/// 項目「DENPYO_BANGO_TO(伝票番号ＴＯ)」の値
		/// </summary>
		private string _denpyo_bango_to;
		/// <summary>
		/// 項目「IDODENPYO_BANGO_FROM(移動伝票番号ＦＲＯＭ)」の値
		/// </summary>
		private string _idodenpyo_bango_from;
		/// <summary>
		/// 項目「IDODENPYO_BANGO_TO(移動伝票番号ＴＯ)」の値
		/// </summary>
		private string _idodenpyo_bango_to;
		/// <summary>
		/// 項目「SIJI_BANGO_FROM(指示番号ＦＲＯＭ)」の値
		/// </summary>
		private string _siji_bango_from;
		/// <summary>
		/// 項目「SIJI_BANGO_TO(指示番号ＴＯ)」の値
		/// </summary>
		private string _siji_bango_to;
		/// <summary>
		/// 項目「JYURYOKAISYA_CD(入荷会社)」の値
		/// </summary>
		private string _jyuryokaisya_cd;
		/// <summary>
		/// 項目「NYUKAKAISYA_NM(入荷会社)」の値
		/// </summary>
		private string _nyukakaisya_nm;
		/// <summary>
		/// 項目「JYURYOTEN_CD(入荷店)」の値
		/// </summary>
		private string _jyuryoten_cd;
		/// <summary>
		/// 項目「JURYOTEN_NM()」の値
		/// </summary>
		private string _juryoten_nm;
		/// <summary>
		/// 項目「JYURYO_YMD_FROM(入荷日ＦＲＯＭ)」の値
		/// </summary>
		private string _jyuryo_ymd_from;
		/// <summary>
		/// 項目「JYURYO_YMD_TO(入荷日ＴＯ)」の値
		/// </summary>
		private string _jyuryo_ymd_to;
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD(出荷会社)」の値
		/// </summary>
		private string _syukkakaisya_cd;
		/// <summary>
		/// 項目「SYUKKAKAISYA_NM()」の値
		/// </summary>
		private string _syukkakaisya_nm;
		/// <summary>
		/// 項目「SYUKKATEN_CD(出荷店)」の値
		/// </summary>
		private string _syukkaten_cd;
		/// <summary>
		/// 項目「SYUKKATENPO_NM()」の値
		/// </summary>
		private string _syukkatenpo_nm;
		/// <summary>
		/// 項目「SYUKKA_YMD_FROM(出荷日ＦＲＯＭ)」の値
		/// </summary>
		private string _syukka_ymd_from;
		/// <summary>
		/// 項目「SYUKKA_YMD_TO(出荷日ＴＯ)」の値
		/// </summary>
		private string _syukka_ymd_to;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
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
		/// 項目「HEAD_TENPO_NM(ヘッダ店舗名)」の値を取得または設定する。
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
		/// 項目「IDODENPYO_BANGO_FROM(移動伝票番号ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Idodenpyo_bango_from
		{
			get
			{
				return this._idodenpyo_bango_from;
			}
			set
			{
				this._idodenpyo_bango_from = value;
			}
		}
		/// <summary>
		/// 項目「IDODENPYO_BANGO_TO(移動伝票番号ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Idodenpyo_bango_to
		{
			get
			{
				return this._idodenpyo_bango_to;
			}
			set
			{
				this._idodenpyo_bango_to = value;
			}
		}
		/// <summary>
		/// 項目「SIJI_BANGO_FROM(指示番号ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「SIJI_BANGO_TO(指示番号ＴＯ)」の値を取得または設定する。
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
		/// 項目「JYURYOKAISYA_CD(入荷会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryokaisya_cd
		{
			get
			{
				return this._jyuryokaisya_cd;
			}
			set
			{
				this._jyuryokaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAKAISYA_NM(入荷会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukakaisya_nm
		{
			get
			{
				return this._nyukakaisya_nm;
			}
			set
			{
				this._nyukakaisya_nm = value;
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
		/// 項目「SYUKKAKAISYA_CD(出荷会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkakaisya_cd
		{
			get
			{
				return this._syukkakaisya_cd;
			}
			set
			{
				this._syukkakaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKAKAISYA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkakaisya_nm
		{
			get
			{
				return this._syukkakaisya_nm;
			}
			set
			{
				this._syukkakaisya_nm = value;
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
		/// 項目「SYUKKATENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkatenpo_nm
		{
			get
			{
				return this._syukkatenpo_nm;
			}
			set
			{
				this._syukkatenpo_nm = value;
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
		/// 項目「SCAN_CD(スキャンコード)」の値を取得または設定する。
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
		public Te130f01BaseForm() : base()
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
			sb.Append("Denpyo_jyotai:").Append(this._denpyo_jyotai).AppendLine();
			sb.Append("Denpyo_bango_from:").Append(this._denpyo_bango_from).AppendLine();
			sb.Append("Denpyo_bango_to:").Append(this._denpyo_bango_to).AppendLine();
			sb.Append("Idodenpyo_bango_from:").Append(this._idodenpyo_bango_from).AppendLine();
			sb.Append("Idodenpyo_bango_to:").Append(this._idodenpyo_bango_to).AppendLine();
			sb.Append("Siji_bango_from:").Append(this._siji_bango_from).AppendLine();
			sb.Append("Siji_bango_to:").Append(this._siji_bango_to).AppendLine();
			sb.Append("Jyuryokaisya_cd:").Append(this._jyuryokaisya_cd).AppendLine();
			sb.Append("Nyukakaisya_nm:").Append(this._nyukakaisya_nm).AppendLine();
			sb.Append("Jyuryoten_cd:").Append(this._jyuryoten_cd).AppendLine();
			sb.Append("Juryoten_nm:").Append(this._juryoten_nm).AppendLine();
			sb.Append("Jyuryo_ymd_from:").Append(this._jyuryo_ymd_from).AppendLine();
			sb.Append("Jyuryo_ymd_to:").Append(this._jyuryo_ymd_to).AppendLine();
			sb.Append("Syukkakaisya_cd:").Append(this._syukkakaisya_cd).AppendLine();
			sb.Append("Syukkakaisya_nm:").Append(this._syukkakaisya_nm).AppendLine();
			sb.Append("Syukkaten_cd:").Append(this._syukkaten_cd).AppendLine();
			sb.Append("Syukkatenpo_nm:").Append(this._syukkatenpo_nm).AppendLine();
			sb.Append("Syukka_ymd_from:").Append(this._syukka_ymd_from).AppendLine();
			sb.Append("Syukka_ymd_to:").Append(this._syukka_ymd_to).AppendLine();
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
			return "Te130f01";
		}
		#endregion

		#endregion
	}
}
