using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Te010p01.Formvo.Baseform
{
  /// <summary>
  /// Te010f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te010f01M1BaseForm : StandardBaseM1Form
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1KAISYAKANA_NM(会社)」の値
		/// </summary>
		private string _m1kaisyakana_nm;

		/// <summary>
		/// 項目「M1JYURYOTEN_CD(入荷店)」の値
		/// </summary>
		private string _m1jyuryoten_cd;

		/// <summary>
		/// 項目「M1JURYOTEN_NM()」の値
		/// </summary>
		private string _m1juryoten_nm;

		/// <summary>
		/// 項目「M1SCM_CD(SCMコード)」の値
		/// </summary>
		private string _m1scm_cd;


		/// <summary>
		/// 項目「M1SIJI_BANGO(指示番号)」の値
		/// </summary>
		private string _m1siji_bango;

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値
		/// </summary>
		private string _m1syukka_ymd;

		/// <summary>
		/// 項目「M1JYURYO_YMD(入荷日)」の値
		/// </summary>
		private string _m1jyuryo_ymd;

		/// <summary>
		/// 項目「M1SYUKKA_SU(出荷数量)」の値
		/// </summary>
		private string _m1syukka_su;

		/// <summary>
		/// 項目「M1KAKUTEI_SU(確定数量)」の値
		/// </summary>
		private string _m1kakutei_su;

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値
		/// </summary>
		private string _m1nyuryokutan_nm;

		/// <summary>
		/// 項目「M1SHUKKARIYU_NM(出荷理由)」の値
		/// </summary>
		private string _m1shukkariyu_nm;

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値
		/// </summary>
		private string _m1syorinm;

		/// <summary>
		/// 項目「M1SYORIYMD(処理日)」の値
		/// </summary>
		private string _m1syoriymd;

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値
		/// </summary>
		private string _m1syori_tm;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値
		/// </summary>
		private string _m1selectorcheckbox;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値
		/// </summary>
		private string _m1entersyoriflg;

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値
		/// </summary>
		private string _m1dtlirokbn;

		/// <summary>
		/// 処理モード
		/// </summary>
		private DbuModeCode _commode;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno
		{
			get
			{
				return this._m1rowno;
			}
			set
			{
				this._m1rowno = value;
			}
		}

		/// <summary>
		/// 項目「M1KAISYAKANA_NM(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kaisyakana_nm
		{
			get
			{
				return this._m1kaisyakana_nm;
			}
			set
			{
				this._m1kaisyakana_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURYOTEN_CD(入荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuryoten_cd
		{
			get
			{
				return this._m1jyuryoten_cd;
			}
			set
			{
				this._m1jyuryoten_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1JURYOTEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1juryoten_nm
		{
			get
			{
				return this._m1juryoten_nm;
			}
			set
			{
				this._m1juryoten_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SCM_CD(SCMコード)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scm_cd
		{
			get
			{
				return this._m1scm_cd;
			}
			set
			{
				this._m1scm_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siji_bango
		{
			get
			{
				return this._m1siji_bango;
			}
			set
			{
				this._m1siji_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukka_ymd
		{
			get
			{
				return this._m1syukka_ymd;
			}
			set
			{
				this._m1syukka_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURYO_YMD(入荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuryo_ymd
		{
			get
			{
				return this._m1jyuryo_ymd;
			}
			set
			{
				this._m1jyuryo_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKA_SU(出荷数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukka_su
		{
			get
			{
				return this._m1syukka_su;
			}
			set
			{
				this._m1syukka_su = value;
			}
		}

		/// <summary>
		/// 項目「M1KAKUTEI_SU(確定数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kakutei_su
		{
			get
			{
				return this._m1kakutei_su;
			}
			set
			{
				this._m1kakutei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyuryokutan_nm
		{
			get
			{
				return this._m1nyuryokutan_nm;
			}
			set
			{
				this._m1nyuryokutan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SHUKKARIYU_NM(出荷理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1shukkariyu_nm
		{
			get
			{
				return this._m1shukkariyu_nm;
			}
			set
			{
				this._m1shukkariyu_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syorinm
		{
			get
			{
				return this._m1syorinm;
			}
			set
			{
				this._m1syorinm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORIYMD(処理日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syoriymd
		{
			get
			{
				return this._m1syoriymd;
			}
			set
			{
				this._m1syoriymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syori_tm
		{
			get
			{
				return this._m1syori_tm;
			}
			set
			{
				this._m1syori_tm = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox
		{
			get
			{
				return this._m1selectorcheckbox;
			}
			set
			{
				this._m1selectorcheckbox = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg
		{
			get
			{
				return this._m1entersyoriflg;
			}
			set
			{
				this._m1entersyoriflg = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn
		{
			get
			{
				return this._m1dtlirokbn;
			}
			set
			{
				this._m1dtlirokbn = value;
			}
		}


		/// <summary>
		/// 処理モード
		/// </summary>
		public virtual DbuModeCode Commode
		{
			get
			{
				return this._commode;
			}
			set
			{
				this._commode=value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te010f01M1BaseForm()
		{
		}
		#endregion

		#region メソッド
		
		/// <summary>
		/// 引数のオブジェクトと比較する。
		/// </summary>
		/// <param name="obj">比較するオブジェクト</param>
		/// <returns>結果</returns>
		public override bool Equals(object obj)
		{
			Te010f01M1BaseForm compare = null;
			if (obj is Te010f01M1BaseForm)
			{
				compare = (Te010f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1kaisyakana_nm != compare.M1kaisyakana_nm)
			{
				return false;
			}
			if (_m1jyuryoten_cd != compare.M1jyuryoten_cd)
			{
				return false;
			}
			if (_m1juryoten_nm != compare.M1juryoten_nm)
			{
				return false;
			}
			if (_m1scm_cd != compare.M1scm_cd)
			{
				return false;
			}
			if (_m1siji_bango != compare.M1siji_bango)
			{
				return false;
			}
			if (_m1syukka_ymd != compare.M1syukka_ymd)
			{
				return false;
			}
			if (_m1jyuryo_ymd != compare.M1jyuryo_ymd)
			{
				return false;
			}
			if (_m1syukka_su != compare.M1syukka_su)
			{
				return false;
			}
			if (_m1kakutei_su != compare.M1kakutei_su)
			{
				return false;
			}
			if (_m1nyuryokutan_nm != compare.M1nyuryokutan_nm)
			{
				return false;
			}
			if (_m1shukkariyu_nm != compare.M1shukkariyu_nm)
			{
				return false;
			}
			if (_m1syorinm != compare.M1syorinm)
			{
				return false;
			}
			if (_m1syoriymd != compare.M1syoriymd)
			{
				return false;
			}
			if (_m1syori_tm != compare.M1syori_tm)
			{
				return false;
			}
			if (_m1selectorcheckbox != compare.M1selectorcheckbox)
			{
				return false;
			}
			if (_m1entersyoriflg != compare.M1entersyoriflg)
			{
				return false;
			}
			if (_m1dtlirokbn != compare.M1dtlirokbn)
			{
				return false;
			}

			return true;
		}
		/// <summary>
		/// 特定の型のハッシュ関数として機能します。
		/// ハッシュ アルゴリズムや、ハッシュ テーブルのようなデータ構造での使用に適しています。
		/// </summary>
		/// <returns>現在のcom.xebio.bo.Te010p01.Formvo.Te010f01M1Formのハッシュ コード。</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}
		/// <summary>
		/// このオブジェクトの内容を文字列で取得する。
		/// </summary>
		/// <returns>オブジェクトの内容</returns>
		public override string ToString()
		{
			StringBuilder str=new StringBuilder();

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1kaisyakana_nm:").Append(this._m1kaisyakana_nm).AppendLine();
			str.Append("M1jyuryoten_cd:").Append(this._m1jyuryoten_cd).AppendLine();
			str.Append("M1juryoten_nm:").Append(this._m1juryoten_nm).AppendLine();
			str.Append("M1scm_cd:").Append(this._m1scm_cd).AppendLine();
			str.Append("M1siji_bango:").Append(this._m1siji_bango).AppendLine();
			str.Append("M1syukka_ymd:").Append(this._m1syukka_ymd).AppendLine();
			str.Append("M1jyuryo_ymd:").Append(this._m1jyuryo_ymd).AppendLine();
			str.Append("M1syukka_su:").Append(this._m1syukka_su).AppendLine();
			str.Append("M1kakutei_su:").Append(this._m1kakutei_su).AppendLine();
			str.Append("M1nyuryokutan_nm:").Append(this._m1nyuryokutan_nm).AppendLine();
			str.Append("M1shukkariyu_nm:").Append(this._m1shukkariyu_nm).AppendLine();
			str.Append("M1syorinm:").Append(this._m1syorinm).AppendLine();
			str.Append("M1syoriymd:").Append(this._m1syoriymd).AppendLine();
			str.Append("M1syori_tm:").Append(this._m1syori_tm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
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
