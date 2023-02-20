using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tk010p01.VO
{
  /// <summary>
  /// Tk010f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tk010f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;



		/// <summary>
		/// 項目「M1APPLY_YMD(申請日)」の値
		/// </summary>
		private string _m1apply_ymd;

		/// <summary>
		/// 項目「M1SINSEI_KB_NM(再申請)」の値
		/// </summary>
		private string _m1sinsei_kb_nm;

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認)」の値
		/// </summary>
		private string _m1syonin_flg_nm;

		/// <summary>
		/// 項目「M1KESSAI_FLG_NM(決裁)」の値
		/// </summary>
		private string _m1kessai_flg_nm;

		/// <summary>
		/// 項目「M1NOTNB_SURYO(数量)」の値
		/// </summary>
		private string _m1notnb_suryo;

		/// <summary>
		/// 項目「M1NOTNB_GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1notnb_genka_kin;

		/// <summary>
		/// 項目「M1NB_SURYO(数量)」の値
		/// </summary>
		private string _m1nb_suryo;

		/// <summary>
		/// 項目「M1NB_GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1nb_genka_kin;

		/// <summary>
		/// 項目「M1TENPOGOKEI_SU(数量)」の値
		/// </summary>
		private string _m1tenpogokei_su;

		/// <summary>
		/// 項目「M1TENPOGOKEI_GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1tenpogokei_genka_kin;

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
		/// 項目「M1APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1apply_ymd
		{
			get
			{
				return this._m1apply_ymd;
			}
			set
			{
				this._m1apply_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEI_KB_NM(再申請)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_kb_nm
		{
			get
			{
				return this._m1sinsei_kb_nm;
			}
			set
			{
				this._m1sinsei_kb_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonin_flg_nm
		{
			get
			{
				return this._m1syonin_flg_nm;
			}
			set
			{
				this._m1syonin_flg_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1KESSAI_FLG_NM(決裁)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kessai_flg_nm
		{
			get
			{
				return this._m1kessai_flg_nm;
			}
			set
			{
				this._m1kessai_flg_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1NOTNB_SURYO(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1notnb_suryo
		{
			get
			{
				return this._m1notnb_suryo;
			}
			set
			{
				this._m1notnb_suryo = value;
			}
		}

		/// <summary>
		/// 項目「M1NOTNB_GENKA_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1notnb_genka_kin
		{
			get
			{
				return this._m1notnb_genka_kin;
			}
			set
			{
				this._m1notnb_genka_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1NB_SURYO(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nb_suryo
		{
			get
			{
				return this._m1nb_suryo;
			}
			set
			{
				this._m1nb_suryo = value;
			}
		}

		/// <summary>
		/// 項目「M1NB_GENKA_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nb_genka_kin
		{
			get
			{
				return this._m1nb_genka_kin;
			}
			set
			{
				this._m1nb_genka_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPOGOKEI_SU(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpogokei_su
		{
			get
			{
				return this._m1tenpogokei_su;
			}
			set
			{
				this._m1tenpogokei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPOGOKEI_GENKA_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpogokei_genka_kin
		{
			get
			{
				return this._m1tenpogokei_genka_kin;
			}
			set
			{
				this._m1tenpogokei_genka_kin = value;
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


		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk010f01M1ResultVO() : base()
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
			Tk010f01M1ResultVO compare = null;
			if (obj is Tk010f01M1ResultVO)
			{
				compare = (Tk010f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1apply_ymd != compare.M1apply_ymd)
			{
				return false;
			}
			if (_m1sinsei_kb_nm != compare.M1sinsei_kb_nm)
			{
				return false;
			}
			if (_m1syonin_flg_nm != compare.M1syonin_flg_nm)
			{
				return false;
			}
			if (_m1kessai_flg_nm != compare.M1kessai_flg_nm)
			{
				return false;
			}
			if (_m1notnb_suryo != compare.M1notnb_suryo)
			{
				return false;
			}
			if (_m1notnb_genka_kin != compare.M1notnb_genka_kin)
			{
				return false;
			}
			if (_m1nb_suryo != compare.M1nb_suryo)
			{
				return false;
			}
			if (_m1nb_genka_kin != compare.M1nb_genka_kin)
			{
				return false;
			}
			if (_m1tenpogokei_su != compare.M1tenpogokei_su)
			{
				return false;
			}
			if (_m1tenpogokei_genka_kin != compare.M1tenpogokei_genka_kin)
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
		/// <returns>現在のcom.xebio.bo.Tk010p01.Formvo.Tk010f01M1Formのハッシュ コード。</returns>
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
			StringBuilder str = new StringBuilder();

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1apply_ymd:").Append(this._m1apply_ymd).AppendLine();
			str.Append("M1sinsei_kb_nm:").Append(this._m1sinsei_kb_nm).AppendLine();
			str.Append("M1syonin_flg_nm:").Append(this._m1syonin_flg_nm).AppendLine();
			str.Append("M1kessai_flg_nm:").Append(this._m1kessai_flg_nm).AppendLine();
			str.Append("M1notnb_suryo:").Append(this._m1notnb_suryo).AppendLine();
			str.Append("M1notnb_genka_kin:").Append(this._m1notnb_genka_kin).AppendLine();
			str.Append("M1nb_suryo:").Append(this._m1nb_suryo).AppendLine();
			str.Append("M1nb_genka_kin:").Append(this._m1nb_genka_kin).AppendLine();
			str.Append("M1tenpogokei_su:").Append(this._m1tenpogokei_su).AppendLine();
			str.Append("M1tenpogokei_genka_kin:").Append(this._m1tenpogokei_genka_kin).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
