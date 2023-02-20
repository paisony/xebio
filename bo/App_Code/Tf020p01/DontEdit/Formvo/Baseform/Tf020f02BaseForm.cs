using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf020p01.Formvo.Baseform
{
  /// <summary>
  /// Tf020f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf020f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「APPLY_YMD(申請日)」の値
		/// </summary>
		private string _apply_ymd;
		/// <summary>
		/// 項目「SINSEIRIYU_KB(申請理由)」の値
		/// </summary>
		private string _sinseiriyu_kb;
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値
		/// </summary>
		private string _sinseiriyu;
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		private string _denpyo_bango;
		/// <summary>
		/// 項目「KAMOKU_CD(科目)」の値
		/// </summary>
		private string _kamoku_cd;
		/// <summary>
		/// 項目「KAMOKU_NM()」の値
		/// </summary>
		private string _kamoku_nm;
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値
		/// </summary>
		private string _kyakkariyu;
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値
		/// </summary>
		private string _jyuri_no;
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値
		/// </summary>
		private string _syonin_flg_nm;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値
		/// </summary>
		private string _gokei_suryo;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI(原価合計)」の値
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
		/// 項目「APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_ymd
		{
			get
			{
				return this._apply_ymd;
			}
			set
			{
				this._apply_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SINSEIRIYU_KB(申請理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseiriyu_kb
		{
			get
			{
				return this._sinseiriyu_kb;
			}
			set
			{
				this._sinseiriyu_kb = value;
			}
		}
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseiriyu
		{
			get
			{
				return this._sinseiriyu;
			}
			set
			{
				this._sinseiriyu = value;
			}
		}
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_bango
		{
			get
			{
				return this._denpyo_bango;
			}
			set
			{
				this._denpyo_bango = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_CD(科目)」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_cd
		{
			get
			{
				return this._kamoku_cd;
			}
			set
			{
				this._kamoku_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_nm
		{
			get
			{
				return this._kamoku_nm;
			}
			set
			{
				this._kamoku_nm = value;
			}
		}
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Kyakkariyu
		{
			get
			{
				return this._kyakkariyu;
			}
			set
			{
				this._kyakkariyu = value;
			}
		}
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuri_no
		{
			get
			{
				return this._jyuri_no;
			}
			set
			{
				this._jyuri_no = value;
			}
		}
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonin_flg_nm
		{
			get
			{
				return this._syonin_flg_nm;
			}
			set
			{
				this._syonin_flg_nm = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値を取得または設定する。
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
		/// 項目「GENKA_KIN_GOKEI(原価合計)」の値を取得または設定する。
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
		public Tf020f02BaseForm() : base()
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
			sb.Append("Apply_ymd:").Append(this._apply_ymd).AppendLine();
			sb.Append("Sinseiriyu_kb:").Append(this._sinseiriyu_kb).AppendLine();
			sb.Append("Sinseiriyu:").Append(this._sinseiriyu).AppendLine();
			sb.Append("Denpyo_bango:").Append(this._denpyo_bango).AppendLine();
			sb.Append("Kamoku_cd:").Append(this._kamoku_cd).AppendLine();
			sb.Append("Kamoku_nm:").Append(this._kamoku_nm).AppendLine();
			sb.Append("Kyakkariyu:").Append(this._kyakkariyu).AppendLine();
			sb.Append("Jyuri_no:").Append(this._jyuri_no).AppendLine();
			sb.Append("Syonin_flg_nm:").Append(this._syonin_flg_nm).AppendLine();
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
			return "Tf020f02";
		}
		#endregion

		#endregion
	}
}
