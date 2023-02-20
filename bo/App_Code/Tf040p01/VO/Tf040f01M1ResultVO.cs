using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf040p01.VO
{
  /// <summary>
  /// Tf040f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tf040f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1KANRI_NO(管理No)」の値
		/// </summary>
		private string _m1kanri_no;

		/// <summary>
		/// 項目「M1MOTOKANRI_NO(元No)」の値
		/// </summary>
		private string _m1motokanri_no;

		/// <summary>
		/// 項目「M1KEIJO_YMD(日付)」の値
		/// </summary>
		private string _m1keijo_ymd;

		/// <summary>
		/// 項目「M1KAMOKU_CD(科目)」の値
		/// </summary>
		private string _m1kamoku_cd;


		/// <summary>
		/// 項目「M1KAMOKU_NM()」の値
		/// </summary>
		private string _m1kamoku_nm;

		/// <summary>
		/// 項目「M1NYUKIN(入金)」の値
		/// </summary>
		private string _m1nyukin;

		/// <summary>
		/// 項目「M1NYUKIN_HDN()」の値
		/// </summary>
		private string _m1nyukin_hdn;

		/// <summary>
		/// 項目「M1SYUKKIN(出金)」の値
		/// </summary>
		private string _m1syukkin;

		/// <summary>
		/// 項目「M1SYUKKIN_HDN()」の値
		/// </summary>
		private string _m1syukkin_hdn;

		/// <summary>
		/// 項目「M1TEKIYOU(摘要)」の値
		/// </summary>
		private string _m1tekiyou;

		/// <summary>
		/// 項目「M1HURIKAETENPO_CD(振替店舗)」の値
		/// </summary>
		private string _m1hurikaetenpo_cd;


		/// <summary>
		/// 項目「M1HURIKAETENPO_NM()」の値
		/// </summary>
		private string _m1hurikaetenpo_nm;

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
		/// 項目「M1KANRI_NO(管理No)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kanri_no
		{
			get
			{
				return this._m1kanri_no;
			}
			set
			{
				this._m1kanri_no = value;
			}
		}

		/// <summary>
		/// 項目「M1MOTOKANRI_NO(元No)」の値を取得または設定する。
		/// </summary>
		public virtual string M1motokanri_no
		{
			get
			{
				return this._m1motokanri_no;
			}
			set
			{
				this._m1motokanri_no = value;
			}
		}

		/// <summary>
		/// 項目「M1KEIJO_YMD(日付)」の値を取得または設定する。
		/// </summary>
		public virtual string M1keijo_ymd
		{
			get
			{
				return this._m1keijo_ymd;
			}
			set
			{
				this._m1keijo_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1KAMOKU_CD(科目)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kamoku_cd
		{
			get
			{
				return this._m1kamoku_cd;
			}
			set
			{
				this._m1kamoku_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1KAMOKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1kamoku_nm
		{
			get
			{
				return this._m1kamoku_nm;
			}
			set
			{
				this._m1kamoku_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKIN(入金)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukin
		{
			get
			{
				return this._m1nyukin;
			}
			set
			{
				this._m1nyukin = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukin_hdn
		{
			get
			{
				return this._m1nyukin_hdn;
			}
			set
			{
				this._m1nyukin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKIN(出金)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkin
		{
			get
			{
				return this._m1syukkin;
			}
			set
			{
				this._m1syukkin = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkin_hdn
		{
			get
			{
				return this._m1syukkin_hdn;
			}
			set
			{
				this._m1syukkin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1TEKIYOU(摘要)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tekiyou
		{
			get
			{
				return this._m1tekiyou;
			}
			set
			{
				this._m1tekiyou = value;
			}
		}

		/// <summary>
		/// 項目「M1HURIKAETENPO_CD(振替店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hurikaetenpo_cd
		{
			get
			{
				return this._m1hurikaetenpo_cd;
			}
			set
			{
				this._m1hurikaetenpo_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1HURIKAETENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hurikaetenpo_nm
		{
			get
			{
				return this._m1hurikaetenpo_nm;
			}
			set
			{
				this._m1hurikaetenpo_nm = value;
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
		public Tf040f01M1ResultVO() : base()
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
			Tf040f01M1ResultVO compare = null;
			if (obj is Tf040f01M1ResultVO)
			{
				compare = (Tf040f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1kanri_no != compare.M1kanri_no)
			{
				return false;
			}
			if (_m1motokanri_no != compare.M1motokanri_no)
			{
				return false;
			}
			if (_m1keijo_ymd != compare.M1keijo_ymd)
			{
				return false;
			}
			if (_m1kamoku_cd != compare.M1kamoku_cd)
			{
				return false;
			}
			if (_m1kamoku_nm != compare.M1kamoku_nm)
			{
				return false;
			}
			if (_m1nyukin != compare.M1nyukin)
			{
				return false;
			}
			if (_m1nyukin_hdn != compare.M1nyukin_hdn)
			{
				return false;
			}
			if (_m1syukkin != compare.M1syukkin)
			{
				return false;
			}
			if (_m1syukkin_hdn != compare.M1syukkin_hdn)
			{
				return false;
			}
			if (_m1tekiyou != compare.M1tekiyou)
			{
				return false;
			}
			if (_m1hurikaetenpo_cd != compare.M1hurikaetenpo_cd)
			{
				return false;
			}
			if (_m1hurikaetenpo_nm != compare.M1hurikaetenpo_nm)
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
		/// <returns>現在のcom.xebio.bo.Tf040p01.Formvo.Tf040f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1kanri_no:").Append(this._m1kanri_no).AppendLine();
			str.Append("M1motokanri_no:").Append(this._m1motokanri_no).AppendLine();
			str.Append("M1keijo_ymd:").Append(this._m1keijo_ymd).AppendLine();
			str.Append("M1kamoku_cd:").Append(this._m1kamoku_cd).AppendLine();
			str.Append("M1kamoku_nm:").Append(this._m1kamoku_nm).AppendLine();
			str.Append("M1nyukin:").Append(this._m1nyukin).AppendLine();
			str.Append("M1nyukin_hdn:").Append(this._m1nyukin_hdn).AppendLine();
			str.Append("M1syukkin:").Append(this._m1syukkin).AppendLine();
			str.Append("M1syukkin_hdn:").Append(this._m1syukkin_hdn).AppendLine();
			str.Append("M1tekiyou:").Append(this._m1tekiyou).AppendLine();
			str.Append("M1hurikaetenpo_cd:").Append(this._m1hurikaetenpo_cd).AppendLine();
			str.Append("M1hurikaetenpo_nm:").Append(this._m1hurikaetenpo_nm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
