using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj080p01.VO
{
  /// <summary>
  /// Tj080f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tj080f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1TENPO_CD(店舗)」の値
		/// </summary>
		private string _m1tenpo_cd;

		/// <summary>
		/// 項目「M1TENPO_NM()」の値
		/// </summary>
		private string _m1tenpo_nm;

		/// <summary>
		/// 項目「M1SOSIN_KAK_YMD(送信確定日)」の値
		/// </summary>
		private string _m1sosin_kak_ymd;

		/// <summary>
		/// 項目「M1TENPO_KAKUTEI_JYOKYO(店舗確定状況)」の値
		/// </summary>
		private string _m1tenpo_kakutei_jyokyo;

		/// <summary>
		/// 項目「M1TENPO_KAKUTEI_JYOKYO_NM()」の値
		/// </summary>
		private string _m1tenpo_kakutei_jyokyo_nm;

		/// <summary>
		/// 項目「M1MD_SOSIN_JYOKYO(ＭＤ送信状況)」の値
		/// </summary>
		private string _m1md_sosin_jyokyo;

		/// <summary>
		/// 項目「M1MD_SOSIN_JYOKYO_NM()」の値
		/// </summary>
		private string _m1md_sosin_jyokyo_nm;

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
		/// 項目「M1TENPO_CD(店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_cd
		{
			get
			{
				return this._m1tenpo_cd;
			}
			set
			{
				this._m1tenpo_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_nm
		{
			get
			{
				return this._m1tenpo_nm;
			}
			set
			{
				this._m1tenpo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SOSIN_KAK_YMD(送信確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sosin_kak_ymd
		{
			get
			{
				return this._m1sosin_kak_ymd;
			}
			set
			{
				this._m1sosin_kak_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPO_KAKUTEI_JYOKYO(店舗確定状況)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_kakutei_jyokyo
		{
			get
			{
				return this._m1tenpo_kakutei_jyokyo;
			}
			set
			{
				this._m1tenpo_kakutei_jyokyo = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPO_KAKUTEI_JYOKYO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_kakutei_jyokyo_nm
		{
			get
			{
				return this._m1tenpo_kakutei_jyokyo_nm;
			}
			set
			{
				this._m1tenpo_kakutei_jyokyo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1MD_SOSIN_JYOKYO(ＭＤ送信状況)」の値を取得または設定する。
		/// </summary>
		public virtual string M1md_sosin_jyokyo
		{
			get
			{
				return this._m1md_sosin_jyokyo;
			}
			set
			{
				this._m1md_sosin_jyokyo = value;
			}
		}

		/// <summary>
		/// 項目「M1MD_SOSIN_JYOKYO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1md_sosin_jyokyo_nm
		{
			get
			{
				return this._m1md_sosin_jyokyo_nm;
			}
			set
			{
				this._m1md_sosin_jyokyo_nm = value;
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
		public Tj080f01M1ResultVO() : base()
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
			Tj080f01M1ResultVO compare = null;
			if (obj is Tj080f01M1ResultVO)
			{
				compare = (Tj080f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1tenpo_cd != compare.M1tenpo_cd)
			{
				return false;
			}
			if (_m1tenpo_nm != compare.M1tenpo_nm)
			{
				return false;
			}
			if (_m1sosin_kak_ymd != compare.M1sosin_kak_ymd)
			{
				return false;
			}
			if (_m1tenpo_kakutei_jyokyo != compare.M1tenpo_kakutei_jyokyo)
			{
				return false;
			}
			if (_m1tenpo_kakutei_jyokyo_nm != compare.M1tenpo_kakutei_jyokyo_nm)
			{
				return false;
			}
			if (_m1md_sosin_jyokyo != compare.M1md_sosin_jyokyo)
			{
				return false;
			}
			if (_m1md_sosin_jyokyo_nm != compare.M1md_sosin_jyokyo_nm)
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
		/// <returns>現在のcom.xebio.bo.Tj080p01.Formvo.Tj080f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1tenpo_cd:").Append(this._m1tenpo_cd).AppendLine();
			str.Append("M1tenpo_nm:").Append(this._m1tenpo_nm).AppendLine();
			str.Append("M1sosin_kak_ymd:").Append(this._m1sosin_kak_ymd).AppendLine();
			str.Append("M1tenpo_kakutei_jyokyo:").Append(this._m1tenpo_kakutei_jyokyo).AppendLine();
			str.Append("M1tenpo_kakutei_jyokyo_nm:").Append(this._m1tenpo_kakutei_jyokyo_nm).AppendLine();
			str.Append("M1md_sosin_jyokyo:").Append(this._m1md_sosin_jyokyo).AppendLine();
			str.Append("M1md_sosin_jyokyo_nm:").Append(this._m1md_sosin_jyokyo_nm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
