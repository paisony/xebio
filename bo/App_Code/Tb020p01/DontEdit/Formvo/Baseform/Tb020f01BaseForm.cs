using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb020p01.Formvo.Baseform
{
  /// <summary>
  /// Tb020f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb020f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SCM_JOTAI(SCM状態)」の値
		/// </summary>
		private string _scm_jotai;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_FROM(入荷予定日ＦＲＯＭ)」の値
		/// </summary>
		private string _nyukayotei_ymd_from;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_TO(入荷予定日ＴＯ)」の値
		/// </summary>
		private string _nyukayotei_ymd_to;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_FROM(仕入確定日ＦＲＯＭ)」の値
		/// </summary>
		private string _siire_kakutei_ymd_from;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_TO(仕入確定日ＴＯ)」の値
		/// </summary>
		private string _siire_kakutei_ymd_to;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「NYUKAYOTEI_KOGUTI_SU(SCM仕入入荷予定小口数)」の値
		/// </summary>
		private string _nyukayotei_koguti_su;
		/// <summary>
		/// 項目「EIGYO_YMD_HDN()」の値
		/// </summary>
		private string _eigyo_ymd_hdn;

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
		/// 項目「SCM_JOTAI(SCM状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Scm_jotai
		{
			get
			{
				return this._scm_jotai;
			}
			set
			{
				this._scm_jotai = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_FROM(入荷予定日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd_from
		{
			get
			{
				return this._nyukayotei_ymd_from;
			}
			set
			{
				this._nyukayotei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_TO(入荷予定日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd_to
		{
			get
			{
				return this._nyukayotei_ymd_to;
			}
			set
			{
				this._nyukayotei_ymd_to = value;
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
		/// 項目「SIIRE_KAKUTEI_YMD_FROM(仕入確定日ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd_from
		{
			get
			{
				return this._siire_kakutei_ymd_from;
			}
			set
			{
				this._siire_kakutei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_TO(仕入確定日ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd_to
		{
			get
			{
				return this._siire_kakutei_ymd_to;
			}
			set
			{
				this._siire_kakutei_ymd_to = value;
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
		/// 項目「NYUKAYOTEI_KOGUTI_SU(SCM仕入入荷予定小口数)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_koguti_su
		{
			get
			{
				return this._nyukayotei_koguti_su;
			}
			set
			{
				this._nyukayotei_koguti_su = value;
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
		public Tb020f01BaseForm() : base()
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
			sb.Append("Scm_jotai:").Append(this._scm_jotai).AppendLine();
			sb.Append("Nyukayotei_ymd_from:").Append(this._nyukayotei_ymd_from).AppendLine();
			sb.Append("Nyukayotei_ymd_to:").Append(this._nyukayotei_ymd_to).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Siire_kakutei_ymd_from:").Append(this._siire_kakutei_ymd_from).AppendLine();
			sb.Append("Siire_kakutei_ymd_to:").Append(this._siire_kakutei_ymd_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Nyukayotei_koguti_su:").Append(this._nyukayotei_koguti_su).AppendLine();
			sb.Append("Eigyo_ymd_hdn:").Append(this._eigyo_ymd_hdn).AppendLine();
		
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
			return "Tb020f01";
		}
		#endregion

		#endregion
	}
}
