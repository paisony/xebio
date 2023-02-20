using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te130p01.Formvo.Baseform
{
  /// <summary>
  /// Te130f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te130f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SCM_CD(SCMコード)」の値
		/// </summary>
		private string _scm_cd;
		/// <summary>
		/// 項目「JYURYOKAISYA_CD(入荷会社)」の値
		/// </summary>
		private string _jyuryokaisya_cd;
		/// <summary>
		/// 項目「NYUKAKAISYA_NM()」の値
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
		/// 項目「NYUKAYOTEI_SU_GOKEI()」の値
		/// </summary>
		private string _nyukayotei_su_gokei;
		/// <summary>
		/// 項目「NYUKAJISSEKI_SU_GOKEI()」の値
		/// </summary>
		private string _nyukajisseki_su_gokei;
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
		/// 項目「NYUKAKAISYA_NM()」の値を取得または設定する。
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
		/// 項目「NYUKAYOTEI_SU_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_su_gokei
		{
			get
			{
				return this._nyukayotei_su_gokei;
			}
			set
			{
				this._nyukayotei_su_gokei = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAJISSEKI_SU_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukajisseki_su_gokei
		{
			get
			{
				return this._nyukajisseki_su_gokei;
			}
			set
			{
				this._nyukajisseki_su_gokei = value;
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
		public Te130f02BaseForm() : base()
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
			sb.Append("Scm_cd:").Append(this._scm_cd).AppendLine();
			sb.Append("Jyuryokaisya_cd:").Append(this._jyuryokaisya_cd).AppendLine();
			sb.Append("Nyukakaisya_nm:").Append(this._nyukakaisya_nm).AppendLine();
			sb.Append("Jyuryoten_cd:").Append(this._jyuryoten_cd).AppendLine();
			sb.Append("Juryoten_nm:").Append(this._juryoten_nm).AppendLine();
			sb.Append("Nyukatan_cd:").Append(this._nyukatan_cd).AppendLine();
			sb.Append("Nyukatan_nm:").Append(this._nyukatan_nm).AppendLine();
			sb.Append("Jyuryo_ymd:").Append(this._jyuryo_ymd).AppendLine();
			sb.Append("Syukkakaisya_cd:").Append(this._syukkakaisya_cd).AppendLine();
			sb.Append("Syukkakaisya_nm:").Append(this._syukkakaisya_nm).AppendLine();
			sb.Append("Syukkaten_cd:").Append(this._syukkaten_cd).AppendLine();
			sb.Append("Syukkatenpo_nm:").Append(this._syukkatenpo_nm).AppendLine();
			sb.Append("Syukkatan_cd:").Append(this._syukkatan_cd).AppendLine();
			sb.Append("Syukkatan_nm:").Append(this._syukkatan_nm).AppendLine();
			sb.Append("Syukka_ymd:").Append(this._syukka_ymd).AppendLine();
			sb.Append("Syorinm:").Append(this._syorinm).AppendLine();
			sb.Append("Syoriymd:").Append(this._syoriymd).AppendLine();
			sb.Append("Syori_tm:").Append(this._syori_tm).AppendLine();
			sb.Append("Nyukayotei_su_gokei:").Append(this._nyukayotei_su_gokei).AppendLine();
			sb.Append("Nyukajisseki_su_gokei:").Append(this._nyukajisseki_su_gokei).AppendLine();
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
			return "Te130f02";
		}
		#endregion

		#endregion
	}
}
