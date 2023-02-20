using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf070p01.Formvo.Baseform
{
  /// <summary>
  /// Tf070f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf070f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1JIKOHASSEI_YMD(事故発生日)」の値
		/// </summary>
		private string _m1jikohassei_ymd;

		/// <summary>
		/// 項目「M1HOKOKU_YMD(報告日)」の値
		/// </summary>
		private string _m1hokoku_ymd;

		/// <summary>
		/// 項目「M1HOKOKUTAN_NM(報告者名)」の値
		/// </summary>
		private string _m1hokokutan_nm;

		/// <summary>
		/// 項目「M1TENTYOTAN_NM(店長名)」の値
		/// </summary>
		private string _m1tentyotan_nm;

		/// <summary>
		/// 項目「M1KEISATSUTODOKE_YMD(警察届出日)」の値
		/// </summary>
		private string _m1keisatsutodoke_ymd;

		/// <summary>
		/// 項目「M1TODOKEDESAKIKEISATSU_NM(届出警察署)」の値
		/// </summary>
		private string _m1todokedesakikeisatsu_nm;

		/// <summary>
		/// 項目「M1JYURI_NO(受理番号)」の値
		/// </summary>
		private string _m1jyuri_no;

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
		/// 項目「M1JIKOHASSEI_YMD(事故発生日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jikohassei_ymd
		{
			get
			{
				return this._m1jikohassei_ymd;
			}
			set
			{
				this._m1jikohassei_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HOKOKU_YMD(報告日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hokoku_ymd
		{
			get
			{
				return this._m1hokoku_ymd;
			}
			set
			{
				this._m1hokoku_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HOKOKUTAN_NM(報告者名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hokokutan_nm
		{
			get
			{
				return this._m1hokokutan_nm;
			}
			set
			{
				this._m1hokokutan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1TENTYOTAN_NM(店長名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tentyotan_nm
		{
			get
			{
				return this._m1tentyotan_nm;
			}
			set
			{
				this._m1tentyotan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1KEISATSUTODOKE_YMD(警察届出日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1keisatsutodoke_ymd
		{
			get
			{
				return this._m1keisatsutodoke_ymd;
			}
			set
			{
				this._m1keisatsutodoke_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1TODOKEDESAKIKEISATSU_NM(届出警察署)」の値を取得または設定する。
		/// </summary>
		public virtual string M1todokedesakikeisatsu_nm
		{
			get
			{
				return this._m1todokedesakikeisatsu_nm;
			}
			set
			{
				this._m1todokedesakikeisatsu_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuri_no
		{
			get
			{
				return this._m1jyuri_no;
			}
			set
			{
				this._m1jyuri_no = value;
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
		public Tf070f01M1BaseForm()
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
			Tf070f01M1BaseForm compare = null;
			if (obj is Tf070f01M1BaseForm)
			{
				compare = (Tf070f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1jikohassei_ymd != compare.M1jikohassei_ymd)
			{
				return false;
			}
			if (_m1hokoku_ymd != compare.M1hokoku_ymd)
			{
				return false;
			}
			if (_m1hokokutan_nm != compare.M1hokokutan_nm)
			{
				return false;
			}
			if (_m1tentyotan_nm != compare.M1tentyotan_nm)
			{
				return false;
			}
			if (_m1keisatsutodoke_ymd != compare.M1keisatsutodoke_ymd)
			{
				return false;
			}
			if (_m1todokedesakikeisatsu_nm != compare.M1todokedesakikeisatsu_nm)
			{
				return false;
			}
			if (_m1jyuri_no != compare.M1jyuri_no)
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
		/// <returns>現在のcom.xebio.bo.Tf070p01.Formvo.Tf070f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1jikohassei_ymd:").Append(this._m1jikohassei_ymd).AppendLine();
			str.Append("M1hokoku_ymd:").Append(this._m1hokoku_ymd).AppendLine();
			str.Append("M1hokokutan_nm:").Append(this._m1hokokutan_nm).AppendLine();
			str.Append("M1tentyotan_nm:").Append(this._m1tentyotan_nm).AppendLine();
			str.Append("M1keisatsutodoke_ymd:").Append(this._m1keisatsutodoke_ymd).AppendLine();
			str.Append("M1todokedesakikeisatsu_nm:").Append(this._m1todokedesakikeisatsu_nm).AppendLine();
			str.Append("M1jyuri_no:").Append(this._m1jyuri_no).AppendLine();
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
			return "Tf070f01";
		}
		#endregion
		#endregion

	}
}
