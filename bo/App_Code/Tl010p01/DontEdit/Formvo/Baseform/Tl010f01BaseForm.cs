using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl010p01.Formvo.Baseform
{
  /// <summary>
  /// Tl010f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl010f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「KAISHI_JYOTAI(開始状態)」の値
		/// </summary>
		private string _kaishi_jyotai;
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
		/// 項目「BAIHENKAISI_YMD_FROM(開始日ＦＲＯＭ)」の値
		/// </summary>
		private string _baihenkaisi_ymd_from;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD_TO(開始日TO)」の値
		/// </summary>
		private string _baihenkaisi_ymd_to;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「EIGYO_YMD_HDN()」の値
		/// </summary>
		private string _eigyo_ymd_hdn;
		/// <summary>
		/// 項目「EIGYO_YMD_HDN2()」の値
		/// </summary>
		private string _eigyo_ymd_hdn2;
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
		/// 項目「KAISHI_JYOTAI(開始状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaishi_jyotai
		{
			get
			{
				return this._kaishi_jyotai;
			}
			set
			{
				this._kaishi_jyotai = value;
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
		/// <summary>
		/// 項目「EIGYO_YMD_HDN2()」の値を取得または設定する。
		/// </summary>
		public virtual string Eigyo_ymd_hdn2
		{
			get
			{
				return this._eigyo_ymd_hdn2;
			}
			set
			{
				this._eigyo_ymd_hdn2 = value;
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
		public Tl010f01BaseForm() : base()
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
			sb.Append("Kaishi_jyotai:").Append(this._kaishi_jyotai).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Baihenkaisi_ymd_from:").Append(this._baihenkaisi_ymd_from).AppendLine();
			sb.Append("Baihenkaisi_ymd_to:").Append(this._baihenkaisi_ymd_to).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Eigyo_ymd_hdn:").Append(this._eigyo_ymd_hdn).AppendLine();
			sb.Append("Eigyo_ymd_hdn2:").Append(this._eigyo_ymd_hdn2).AppendLine();
			sb.Append("Shuturyoku_seal:").Append(this._shuturyoku_seal).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
		
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
			return "Tl010f01";
		}
		#endregion

		#endregion
	}
}
