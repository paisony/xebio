using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf030p01.Formvo.Baseform
{
  /// <summary>
  /// Tf030f02 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf030f02M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1TEKIYO_CD(摘要)」の値
		/// </summary>
		private string _m1tekiyo_cd;


		/// <summary>
		/// 項目「M1TEKIYO_NM()」の値
		/// </summary>
		private string _m1tekiyo_nm;

		/// <summary>
		/// 項目「M1SURYO(数量)」の値
		/// </summary>
		private string _m1suryo;

		/// <summary>
		/// 項目「M1TNK(単価)」の値
		/// </summary>
		private string _m1tnk;

		/// <summary>
		/// 項目「M1KINGAKU(金額)」の値
		/// </summary>
		private string _m1kingaku;

		/// <summary>
		/// 項目「M1SURYO_HDN()」の値
		/// </summary>
		private string _m1suryo_hdn;

		/// <summary>
		/// 項目「M1KINGAKU_HDN()」の値
		/// </summary>
		private string _m1kingaku_hdn;

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
		/// 項目「M1TEKIYO_CD(摘要)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tekiyo_cd
		{
			get
			{
				return this._m1tekiyo_cd;
			}
			set
			{
				this._m1tekiyo_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1TEKIYO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tekiyo_nm
		{
			get
			{
				return this._m1tekiyo_nm;
			}
			set
			{
				this._m1tekiyo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SURYO(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1suryo
		{
			get
			{
				return this._m1suryo;
			}
			set
			{
				this._m1suryo = value;
			}
		}

		/// <summary>
		/// 項目「M1TNK(単価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tnk
		{
			get
			{
				return this._m1tnk;
			}
			set
			{
				this._m1tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1KINGAKU(金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kingaku
		{
			get
			{
				return this._m1kingaku;
			}
			set
			{
				this._m1kingaku = value;
			}
		}

		/// <summary>
		/// 項目「M1SURYO_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1suryo_hdn
		{
			get
			{
				return this._m1suryo_hdn;
			}
			set
			{
				this._m1suryo_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1KINGAKU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1kingaku_hdn
		{
			get
			{
				return this._m1kingaku_hdn;
			}
			set
			{
				this._m1kingaku_hdn = value;
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
		public Tf030f02M1BaseForm()
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
			Tf030f02M1BaseForm compare = null;
			if (obj is Tf030f02M1BaseForm)
			{
				compare = (Tf030f02M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1tekiyo_cd != compare.M1tekiyo_cd)
			{
				return false;
			}
			if (_m1tekiyo_nm != compare.M1tekiyo_nm)
			{
				return false;
			}
			if (_m1suryo != compare.M1suryo)
			{
				return false;
			}
			if (_m1tnk != compare.M1tnk)
			{
				return false;
			}
			if (_m1kingaku != compare.M1kingaku)
			{
				return false;
			}
			if (_m1suryo_hdn != compare.M1suryo_hdn)
			{
				return false;
			}
			if (_m1kingaku_hdn != compare.M1kingaku_hdn)
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
		/// <returns>現在のcom.xebio.bo.Tf030p01.Formvo.Tf030f02M1Formのハッシュ コード。</returns>
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
			str.Append("M1tekiyo_cd:").Append(this._m1tekiyo_cd).AppendLine();
			str.Append("M1tekiyo_nm:").Append(this._m1tekiyo_nm).AppendLine();
			str.Append("M1suryo:").Append(this._m1suryo).AppendLine();
			str.Append("M1tnk:").Append(this._m1tnk).AppendLine();
			str.Append("M1kingaku:").Append(this._m1kingaku).AppendLine();
			str.Append("M1suryo_hdn:").Append(this._m1suryo_hdn).AppendLine();
			str.Append("M1kingaku_hdn:").Append(this._m1kingaku_hdn).AppendLine();
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
			return "Tf030f02";
		}
		#endregion
		#endregion

	}
}
