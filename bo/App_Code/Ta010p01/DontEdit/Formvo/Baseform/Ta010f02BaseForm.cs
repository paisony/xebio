using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta010p01.Formvo.Baseform
{
  /// <summary>
  /// Ta010f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta010f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「KBN_CD(区分)」の値
		/// </summary>
		private string _kbn_cd;
		/// <summary>
		/// 項目「HATTYU_YMD(発注日)」の値
		/// </summary>
		private string _hattyu_ymd;
		/// <summary>
		/// 項目「TANTOSYA_CD(担当者)」の値
		/// </summary>
		private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「IRAIRIYU_CD1(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd1;
		/// <summary>
		/// 項目「IRAIRIYU_CD2(依頼理由)」の値
		/// </summary>
		private string _irairiyu_cd2;
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計)」の値
		/// </summary>
		private string _gokei_irai_su;
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値
		/// </summary>
		private string _gokei_genkakin;

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
		/// 項目「KBN_CD(区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Kbn_cd
		{
			get
			{
				return this._kbn_cd;
			}
			set
			{
				this._kbn_cd = value;
			}
		}
		/// <summary>
		/// 項目「HATTYU_YMD(発注日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hattyu_ymd
		{
			get
			{
				return this._hattyu_ymd;
			}
			set
			{
				this._hattyu_ymd = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD(担当者)」の値を取得または設定する。
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
		/// 項目「IRAIRIYU_CD2(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Irairiyu_cd2
		{
			get
			{
				return this._irairiyu_cd2;
			}
			set
			{
				this._irairiyu_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_IRAI_SU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_irai_su
		{
			get
			{
				return this._gokei_irai_su;
			}
			set
			{
				this._gokei_irai_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_genkakin
		{
			get
			{
				return this._gokei_genkakin;
			}
			set
			{
				this._gokei_genkakin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta010f02BaseForm() : base()
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
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Kbn_cd:").Append(this._kbn_cd).AppendLine();
			sb.Append("Hattyu_ymd:").Append(this._hattyu_ymd).AppendLine();
			sb.Append("Tantosya_cd:").Append(this._tantosya_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Irairiyu_cd1:").Append(this._irairiyu_cd1).AppendLine();
			sb.Append("Irairiyu_cd2:").Append(this._irairiyu_cd2).AppendLine();
			sb.Append("Gokei_irai_su:").Append(this._gokei_irai_su).AppendLine();
			sb.Append("Gokei_genkakin:").Append(this._gokei_genkakin).AppendLine();
		
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
			return "Ta010f02";
		}
		#endregion

		#endregion
	}
}
