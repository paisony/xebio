using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te010p01.Formvo.Baseform
{
  /// <summary>
  /// Te010f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te010f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		private string _denpyo_bango;
		/// <summary>
		/// 項目「SIJI_BANGO(指示番号)」の値
		/// </summary>
		private string _siji_bango;
		/// <summary>
		/// 項目「SCM_CD(SCMコード)」の値
		/// </summary>
		private string _scm_cd;
		/// <summary>
		/// 項目「SHUKKARIYU_NM(出荷理由)」の値
		/// </summary>
		private string _shukkariyu_nm;
		/// <summary>
		/// 項目「SYUKKATAN_CD(出荷担当者)」の値
		/// </summary>
		private string _syukkatan_cd;
		/// <summary>
		/// 項目「SYUKKATAN_NM()」の値
		/// </summary>
		private string _syukkatan_nm;
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値
		/// </summary>
		private string _syukka_ymd;
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
		/// 項目「NYUKATAN_CD(入荷担当者)」の値
		/// </summary>
		private string _nyukatan_cd;
		/// <summary>
		/// 項目「NYUKATAN_NM()」の値
		/// </summary>
		private string _nyukatan_nm;
		/// <summary>
		/// 項目「JYURYO_YMD(入荷日)」の値
		/// </summary>
		private string _jyuryo_ymd;
		/// <summary>
		/// 項目「SYORINM(処理)」の値
		/// </summary>
		private string _syorinm;
		/// <summary>
		/// 項目「SYORIYMD(処理日)」の値
		/// </summary>
		private string _syoriymd;
		/// <summary>
		/// 項目「SYORI_TM(処理時間)」の値
		/// </summary>
		private string _syori_tm;
		/// <summary>
		/// 項目「SYUKKASURYO_GOKEI(合計)」の値
		/// </summary>
		private string _syukkasuryo_gokei;
		/// <summary>
		/// 項目「GOKEIKAKUTEI_SU()」の値
		/// </summary>
		private string _gokeikakutei_su;
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
		/// 項目「SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Siji_bango
		{
			get
			{
				return this._siji_bango;
			}
			set
			{
				this._siji_bango = value;
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
		/// 項目「SHUKKARIYU_NM(出荷理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Shukkariyu_nm
		{
			get
			{
				return this._shukkariyu_nm;
			}
			set
			{
				this._shukkariyu_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKATAN_CD(出荷担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkatan_cd
		{
			get
			{
				return this._syukkatan_cd;
			}
			set
			{
				this._syukkatan_cd = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKATAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkatan_nm
		{
			get
			{
				return this._syukkatan_nm;
			}
			set
			{
				this._syukkatan_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukka_ymd
		{
			get
			{
				return this._syukka_ymd;
			}
			set
			{
				this._syukka_ymd = value;
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
		/// 項目「NYUKATAN_CD(入荷担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukatan_cd
		{
			get
			{
				return this._nyukatan_cd;
			}
			set
			{
				this._nyukatan_cd = value;
			}
		}
		/// <summary>
		/// 項目「NYUKATAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukatan_nm
		{
			get
			{
				return this._nyukatan_nm;
			}
			set
			{
				this._nyukatan_nm = value;
			}
		}
		/// <summary>
		/// 項目「JYURYO_YMD(入荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryo_ymd
		{
			get
			{
				return this._jyuryo_ymd;
			}
			set
			{
				this._jyuryo_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SYORINM(処理)」の値を取得または設定する。
		/// </summary>
		public virtual string Syorinm
		{
			get
			{
				return this._syorinm;
			}
			set
			{
				this._syorinm = value;
			}
		}
		/// <summary>
		/// 項目「SYORIYMD(処理日)」の値を取得または設定する。
		/// </summary>
		public virtual string Syoriymd
		{
			get
			{
				return this._syoriymd;
			}
			set
			{
				this._syoriymd = value;
			}
		}
		/// <summary>
		/// 項目「SYORI_TM(処理時間)」の値を取得または設定する。
		/// </summary>
		public virtual string Syori_tm
		{
			get
			{
				return this._syori_tm;
			}
			set
			{
				this._syori_tm = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKASURYO_GOKEI(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkasuryo_gokei
		{
			get
			{
				return this._syukkasuryo_gokei;
			}
			set
			{
				this._syukkasuryo_gokei = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIKAKUTEI_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeikakutei_su
		{
			get
			{
				return this._gokeikakutei_su;
			}
			set
			{
				this._gokeikakutei_su = value;
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
		public Te010f02BaseForm() : base()
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
			sb.Append("Denpyo_bango:").Append(this._denpyo_bango).AppendLine();
			sb.Append("Siji_bango:").Append(this._siji_bango).AppendLine();
			sb.Append("Scm_cd:").Append(this._scm_cd).AppendLine();
			sb.Append("Shukkariyu_nm:").Append(this._shukkariyu_nm).AppendLine();
			sb.Append("Syukkatan_cd:").Append(this._syukkatan_cd).AppendLine();
			sb.Append("Syukkatan_nm:").Append(this._syukkatan_nm).AppendLine();
			sb.Append("Syukka_ymd:").Append(this._syukka_ymd).AppendLine();
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Jyuryoten_cd:").Append(this._jyuryoten_cd).AppendLine();
			sb.Append("Juryoten_nm:").Append(this._juryoten_nm).AppendLine();
			sb.Append("Nyukatan_cd:").Append(this._nyukatan_cd).AppendLine();
			sb.Append("Nyukatan_nm:").Append(this._nyukatan_nm).AppendLine();
			sb.Append("Jyuryo_ymd:").Append(this._jyuryo_ymd).AppendLine();
			sb.Append("Syorinm:").Append(this._syorinm).AppendLine();
			sb.Append("Syoriymd:").Append(this._syoriymd).AppendLine();
			sb.Append("Syori_tm:").Append(this._syori_tm).AppendLine();
			sb.Append("Syukkasuryo_gokei:").Append(this._syukkasuryo_gokei).AppendLine();
			sb.Append("Gokeikakutei_su:").Append(this._gokeikakutei_su).AppendLine();
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
			return "Te010f02";
		}
		#endregion

		#endregion
	}
}
