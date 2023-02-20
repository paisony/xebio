using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb020p01.Formvo.Baseform
{
  /// <summary>
  /// Tb020f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb020f02BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値
		/// </summary>
		private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値
		/// </summary>
		private string _scm_cd;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _nyukayotei_ymd;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD(仕入確定日)」の値
		/// </summary>
		private string _siire_kakutei_ymd;
		/// <summary>
		/// 項目「SCM_JOTAINM(SCM状態)」の値
		/// </summary>
		private string _scm_jotainm;
		/// <summary>
		/// 項目「GOKEI_SURYO()」の値
		/// </summary>
		private string _gokei_suryo;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値
		/// </summary>
		private string _genka_kin_gokei;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値を取得または設定する。
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
		/// 項目「NYUKAYOTEI_YMD(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd
		{
			get
			{
				return this._nyukayotei_ymd;
			}
			set
			{
				this._nyukayotei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD(仕入確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd
		{
			get
			{
				return this._siire_kakutei_ymd;
			}
			set
			{
				this._siire_kakutei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SCM_JOTAINM(SCM状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Scm_jotainm
		{
			get
			{
				return this._scm_jotainm;
			}
			set
			{
				this._scm_jotainm = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo
		{
			get
			{
				return this._gokei_suryo;
			}
			set
			{
				this._gokei_suryo = value;
			}
		}
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Genka_kin_gokei
		{
			get
			{
				return this._genka_kin_gokei;
			}
			set
			{
				this._genka_kin_gokei = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb020f02BaseForm() : base()
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
			sb.Append("Scm_cd:").Append(this._scm_cd).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Nyukayotei_ymd:").Append(this._nyukayotei_ymd).AppendLine();
			sb.Append("Siire_kakutei_ymd:").Append(this._siire_kakutei_ymd).AppendLine();
			sb.Append("Scm_jotainm:").Append(this._scm_jotainm).AppendLine();
			sb.Append("Gokei_suryo:").Append(this._gokei_suryo).AppendLine();
			sb.Append("Genka_kin_gokei:").Append(this._genka_kin_gokei).AppendLine();
		
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
			return "Tb020f02";
		}
		#endregion

		#endregion
	}
}
