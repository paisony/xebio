using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tm070p01.VO
{
  /// <summary>
  /// Tm070f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tm070f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1TAN_CD(担当者)」の値
		/// </summary>
		private string _m1tan_cd;

		/// <summary>
		/// 項目「M1TAN_NM()」の値
		/// </summary>
		private string _m1tan_nm;

		/// <summary>
		/// 項目「M1MOTO_TENPO_CD(元店舗)」の値
		/// </summary>
		private string _m1moto_tenpo_cd;

		/// <summary>
		/// 項目「M1MOTO_TENPO_NM()」の値
		/// </summary>
		private string _m1moto_tenpo_nm;

		/// <summary>
		/// 項目「M1HENKO_TENPO_CD(変更店舗)」の値
		/// </summary>
		private string _m1henko_tenpo_cd;

		/// <summary>
		/// 項目「M1HENKO_TENPO_NM()」の値
		/// </summary>
		private string _m1henko_tenpo_nm;

		/// <summary>
		/// 項目「M1HENKO_YMD(変更日)」の値
		/// </summary>
		private string _m1henko_ymd;

		/// <summary>
		/// 項目「M1HENKO_TM()」の値
		/// </summary>
		private string _m1henko_tm;

		/// <summary>
		/// 項目「M1SHOZOKUTEN_SHOKIKA_CHECK(所属店初期化)」の値
		/// </summary>
		private string _m1shozokuten_shokika_check;

		/// <summary>
		/// 項目「M1UPD_YMD()」の値
		/// </summary>
		private string _m1upd_ymd;

		/// <summary>
		/// 項目「M1UPD_TM()」の値
		/// </summary>
		private string _m1upd_tm;

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
		/// 項目「M1TAN_CD(担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tan_cd
		{
			get
			{
				return this._m1tan_cd;
			}
			set
			{
				this._m1tan_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1TAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tan_nm
		{
			get
			{
				return this._m1tan_nm;
			}
			set
			{
				this._m1tan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1MOTO_TENPO_CD(元店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string M1moto_tenpo_cd
		{
			get
			{
				return this._m1moto_tenpo_cd;
			}
			set
			{
				this._m1moto_tenpo_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1MOTO_TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1moto_tenpo_nm
		{
			get
			{
				return this._m1moto_tenpo_nm;
			}
			set
			{
				this._m1moto_tenpo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HENKO_TENPO_CD(変更店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_tenpo_cd
		{
			get
			{
				return this._m1henko_tenpo_cd;
			}
			set
			{
				this._m1henko_tenpo_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HENKO_TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_tenpo_nm
		{
			get
			{
				return this._m1henko_tenpo_nm;
			}
			set
			{
				this._m1henko_tenpo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HENKO_YMD(変更日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_ymd
		{
			get
			{
				return this._m1henko_ymd;
			}
			set
			{
				this._m1henko_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HENKO_TM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_tm
		{
			get
			{
				return this._m1henko_tm;
			}
			set
			{
				this._m1henko_tm = value;
			}
		}

		/// <summary>
		/// 項目「M1SHOZOKUTEN_SHOKIKA_CHECK(所属店初期化)」の値を取得または設定する。
		/// </summary>
		public virtual string M1shozokuten_shokika_check
		{
			get
			{
				return this._m1shozokuten_shokika_check;
			}
			set
			{
				this._m1shozokuten_shokika_check = value;
			}
		}

		/// <summary>
		/// 項目「M1UPD_YMD()」の値を取得または設定する。
		/// </summary>
		public virtual string M1upd_ymd
		{
			get
			{
				return this._m1upd_ymd;
			}
			set
			{
				this._m1upd_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1UPD_TM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1upd_tm
		{
			get
			{
				return this._m1upd_tm;
			}
			set
			{
				this._m1upd_tm = value;
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
		public Tm070f01M1ResultVO() : base()
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
			Tm070f01M1ResultVO compare = null;
			if (obj is Tm070f01M1ResultVO)
			{
				compare = (Tm070f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1tan_cd != compare.M1tan_cd)
			{
				return false;
			}
			if (_m1tan_nm != compare.M1tan_nm)
			{
				return false;
			}
			if (_m1moto_tenpo_cd != compare.M1moto_tenpo_cd)
			{
				return false;
			}
			if (_m1moto_tenpo_nm != compare.M1moto_tenpo_nm)
			{
				return false;
			}
			if (_m1henko_tenpo_cd != compare.M1henko_tenpo_cd)
			{
				return false;
			}
			if (_m1henko_tenpo_nm != compare.M1henko_tenpo_nm)
			{
				return false;
			}
			if (_m1henko_ymd != compare.M1henko_ymd)
			{
				return false;
			}
			if (_m1henko_tm != compare.M1henko_tm)
			{
				return false;
			}
			if (_m1shozokuten_shokika_check != compare.M1shozokuten_shokika_check)
			{
				return false;
			}
			if (_m1upd_ymd != compare.M1upd_ymd)
			{
				return false;
			}
			if (_m1upd_tm != compare.M1upd_tm)
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
		/// <returns>現在のcom.xebio.bo.Tm070p01.Formvo.Tm070f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1tan_cd:").Append(this._m1tan_cd).AppendLine();
			str.Append("M1tan_nm:").Append(this._m1tan_nm).AppendLine();
			str.Append("M1moto_tenpo_cd:").Append(this._m1moto_tenpo_cd).AppendLine();
			str.Append("M1moto_tenpo_nm:").Append(this._m1moto_tenpo_nm).AppendLine();
			str.Append("M1henko_tenpo_cd:").Append(this._m1henko_tenpo_cd).AppendLine();
			str.Append("M1henko_tenpo_nm:").Append(this._m1henko_tenpo_nm).AppendLine();
			str.Append("M1henko_ymd:").Append(this._m1henko_ymd).AppendLine();
			str.Append("M1henko_tm:").Append(this._m1henko_tm).AppendLine();
			str.Append("M1shozokuten_shokika_check:").Append(this._m1shozokuten_shokika_check).AppendLine();
			str.Append("M1upd_ymd:").Append(this._m1upd_ymd).AppendLine();
			str.Append("M1upd_tm:").Append(this._m1upd_tm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
