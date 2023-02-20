using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tb010p01.Formvo.Baseform
{
  /// <summary>
  /// Tb010f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb010f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _m1siiresaki_cd;

		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _m1siiresaki_ryaku_nm;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _m1nyukayotei_ymd;


		/// <summary>
		/// 項目「M1MOTODENPYO_BANGO(元伝票)」の値
		/// </summary>
		private string _m1motodenpyo_bango;

		/// <summary>
		/// 項目「M1NOHIN_SU(納品数)」の値
		/// </summary>
		private string _m1nohin_su;

		/// <summary>
		/// 項目「M1KENSU(検数)」の値
		/// </summary>
		private string _m1kensu;

		/// <summary>
		/// 項目「M1GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1genka_kin;

		/// <summary>
		/// 項目「M1SIIRE_KAKUTEI_YMD(仕入確定日)」の値
		/// </summary>
		private string _m1siire_kakutei_ymd;

		/// <summary>
		/// 項目「M1DENPYO_JYOTAINM(伝票状態)」の値
		/// </summary>
		private string _m1denpyo_jyotainm;

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
		/// 項目「M1BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_cd
		{
			get
			{
				return this._m1bumon_cd;
			}
			set
			{
				this._m1bumon_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumonkana_nm
		{
			get
			{
				return this._m1bumonkana_nm;
			}
			set
			{
				this._m1bumonkana_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(仕入先)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siiresaki_cd
		{
			get
			{
				return this._m1siiresaki_cd;
			}
			set
			{
				this._m1siiresaki_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1siiresaki_ryaku_nm
		{
			get
			{
				return this._m1siiresaki_ryaku_nm;
			}
			set
			{
				this._m1siiresaki_ryaku_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukayotei_ymd
		{
			get
			{
				return this._m1nyukayotei_ymd;
			}
			set
			{
				this._m1nyukayotei_ymd = value;
			}
		}


		/// <summary>
		/// 項目「M1MOTODENPYO_BANGO(元伝票)」の値を取得または設定する。
		/// </summary>
		public virtual string M1motodenpyo_bango
		{
			get
			{
				return this._m1motodenpyo_bango;
			}
			set
			{
				this._m1motodenpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1NOHIN_SU(納品数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nohin_su
		{
			get
			{
				return this._m1nohin_su;
			}
			set
			{
				this._m1nohin_su = value;
			}
		}

		/// <summary>
		/// 項目「M1KENSU(検数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kensu
		{
			get
			{
				return this._m1kensu;
			}
			set
			{
				this._m1kensu = value;
			}
		}

		/// <summary>
		/// 項目「M1GENKA_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1genka_kin
		{
			get
			{
				return this._m1genka_kin;
			}
			set
			{
				this._m1genka_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRE_KAKUTEI_YMD(仕入確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siire_kakutei_ymd
		{
			get
			{
				return this._m1siire_kakutei_ymd;
			}
			set
			{
				this._m1siire_kakutei_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1DENPYO_JYOTAINM(伝票状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1denpyo_jyotainm
		{
			get
			{
				return this._m1denpyo_jyotainm;
			}
			set
			{
				this._m1denpyo_jyotainm = value;
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
		public Tb010f01M1BaseForm()
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
			Tb010f01M1BaseForm compare = null;
			if (obj is Tb010f01M1BaseForm)
			{
				compare = (Tb010f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumon_cd != compare.M1bumon_cd)
			{
				return false;
			}
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
			{
				return false;
			}
			if (_m1siiresaki_cd != compare.M1siiresaki_cd)
			{
				return false;
			}
			if (_m1siiresaki_ryaku_nm != compare.M1siiresaki_ryaku_nm)
			{
				return false;
			}
			if (_m1nyukayotei_ymd != compare.M1nyukayotei_ymd)
			{
				return false;
			}
			if (_m1motodenpyo_bango != compare.M1motodenpyo_bango)
			{
				return false;
			}
			if (_m1nohin_su != compare.M1nohin_su)
			{
				return false;
			}
			if (_m1kensu != compare.M1kensu)
			{
				return false;
			}
			if (_m1genka_kin != compare.M1genka_kin)
			{
				return false;
			}
			if (_m1siire_kakutei_ymd != compare.M1siire_kakutei_ymd)
			{
				return false;
			}
			if (_m1denpyo_jyotainm != compare.M1denpyo_jyotainm)
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
		/// <returns>現在のcom.xebio.bo.Tb010p01.Formvo.Tb010f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1nyukayotei_ymd:").Append(this._m1nyukayotei_ymd).AppendLine();
			str.Append("M1motodenpyo_bango:").Append(this._m1motodenpyo_bango).AppendLine();
			str.Append("M1nohin_su:").Append(this._m1nohin_su).AppendLine();
			str.Append("M1kensu:").Append(this._m1kensu).AppendLine();
			str.Append("M1genka_kin:").Append(this._m1genka_kin).AppendLine();
			str.Append("M1siire_kakutei_ymd:").Append(this._m1siire_kakutei_ymd).AppendLine();
			str.Append("M1denpyo_jyotainm:").Append(this._m1denpyo_jyotainm).AppendLine();
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
			return "Tb010f01";
		}
		#endregion
		#endregion

	}
}
