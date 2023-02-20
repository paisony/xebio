using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta040p01.VO
{
  /// <summary>
  /// Ta040f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Ta040f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1HENKO_KBN_NM(変更区分)」の値
		/// </summary>
		private string _m1henko_kbn_nm;


		/// <summary>
		/// 項目「M1HATTYU_SU(発注数量)」の値
		/// </summary>
		private string _m1hattyu_su;

		/// <summary>
		/// 項目「M1HAIBUN_SU(配分数量)」の値
		/// </summary>
		private string _m1haibun_su;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1KESSAI_YMD(決裁日)」の値
		/// </summary>
		private string _m1kessai_ymd;

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
		/// 項目「M1HENKO_KBN_NM(変更区分)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_kbn_nm
		{
			get
			{
				return this._m1henko_kbn_nm;
			}
			set
			{
				this._m1henko_kbn_nm = value;
			}
		}


		/// <summary>
		/// 項目「M1HATTYU_SU(発注数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hattyu_su
		{
			get
			{
				return this._m1hattyu_su;
			}
			set
			{
				this._m1hattyu_su = value;
			}
		}

		/// <summary>
		/// 項目「M1HAIBUN_SU(配分数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1haibun_su
		{
			get
			{
				return this._m1haibun_su;
			}
			set
			{
				this._m1haibun_su = value;
			}
		}

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1genkakin
		{
			get
			{
				return this._m1genkakin;
			}
			set
			{
				this._m1genkakin = value;
			}
		}

		/// <summary>
		/// 項目「M1KESSAI_YMD(決裁日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kessai_ymd
		{
			get
			{
				return this._m1kessai_ymd;
			}
			set
			{
				this._m1kessai_ymd = value;
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
		public Ta040f01M1ResultVO() : base()
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
			Ta040f01M1ResultVO compare = null;
			if (obj is Ta040f01M1ResultVO)
			{
				compare = (Ta040f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1henko_kbn_nm != compare.M1henko_kbn_nm)
			{
				return false;
			}
			if (_m1hattyu_su != compare.M1hattyu_su)
			{
				return false;
			}
			if (_m1haibun_su != compare.M1haibun_su)
			{
				return false;
			}
			if (_m1genkakin != compare.M1genkakin)
			{
				return false;
			}
			if (_m1kessai_ymd != compare.M1kessai_ymd)
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
		/// <returns>現在のcom.xebio.bo.Ta040p01.Formvo.Ta040f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1henko_kbn_nm:").Append(this._m1henko_kbn_nm).AppendLine();
			str.Append("M1hattyu_su:").Append(this._m1hattyu_su).AppendLine();
			str.Append("M1haibun_su:").Append(this._m1haibun_su).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1kessai_ymd:").Append(this._m1kessai_ymd).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
