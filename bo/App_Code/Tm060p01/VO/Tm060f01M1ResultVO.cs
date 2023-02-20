using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tm060p01.VO
{
  /// <summary>
  /// Tm060f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tm060f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1TANTOSYA_CD(担当者)」の値
		/// </summary>
		private string _m1tantosya_cd;

		/// <summary>
		/// 項目「M1HANBAIIN_NM()」の値
		/// </summary>
		private string _m1hanbaiin_nm;

		/// <summary>
		/// 項目「M1SYOKUSEI_KB_NM(職制)」の値
		/// </summary>
		private string _m1syokusei_kb_nm;

		/// <summary>
		/// 項目「M1KENGEN_KB(権限)」の値
		/// </summary>
		private string _m1kengen_kb;

		/// <summary>
		/// 項目「M1PASSWARDSYOKIKA(パスワード初期化)」の値
		/// </summary>
		private string _m1passwardsyokika;

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
		/// 項目「M1TANTOSYA_CD(担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tantosya_cd
		{
			get
			{
				return this._m1tantosya_cd;
			}
			set
			{
				this._m1tantosya_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaiin_nm
		{
			get
			{
				return this._m1hanbaiin_nm;
			}
			set
			{
				this._m1hanbaiin_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYOKUSEI_KB_NM(職制)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syokusei_kb_nm
		{
			get
			{
				return this._m1syokusei_kb_nm;
			}
			set
			{
				this._m1syokusei_kb_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1KENGEN_KB(権限)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kengen_kb
		{
			get
			{
				return this._m1kengen_kb;
			}
			set
			{
				this._m1kengen_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1PASSWARDSYOKIKA(パスワード初期化)」の値を取得または設定する。
		/// </summary>
		public virtual string M1passwardsyokika
		{
			get
			{
				return this._m1passwardsyokika;
			}
			set
			{
				this._m1passwardsyokika = value;
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
		public Tm060f01M1ResultVO() : base()
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
			Tm060f01M1ResultVO compare = null;
			if (obj is Tm060f01M1ResultVO)
			{
				compare = (Tm060f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1tantosya_cd != compare.M1tantosya_cd)
			{
				return false;
			}
			if (_m1hanbaiin_nm != compare.M1hanbaiin_nm)
			{
				return false;
			}
			if (_m1syokusei_kb_nm != compare.M1syokusei_kb_nm)
			{
				return false;
			}
			if (_m1kengen_kb != compare.M1kengen_kb)
			{
				return false;
			}
			if (_m1passwardsyokika != compare.M1passwardsyokika)
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
		/// <returns>現在のcom.xebio.bo.Tm060p01.Formvo.Tm060f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1tantosya_cd:").Append(this._m1tantosya_cd).AppendLine();
			str.Append("M1hanbaiin_nm:").Append(this._m1hanbaiin_nm).AppendLine();
			str.Append("M1syokusei_kb_nm:").Append(this._m1syokusei_kb_nm).AppendLine();
			str.Append("M1kengen_kb:").Append(this._m1kengen_kb).AppendLine();
			str.Append("M1passwardsyokika:").Append(this._m1passwardsyokika).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
