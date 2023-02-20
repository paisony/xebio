using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tb020p01.Formvo.Baseform
{
  /// <summary>
  /// Tb020f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb020f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1SIIRE_KAKUTEI_YMD(仕入確定日)」の値
		/// </summary>
		private string _m1siire_kakutei_ymd;


		/// <summary>
		/// 項目「M1GOKEI_SURYO(数量)」の値
		/// </summary>
		private string _m1gokei_suryo;

		/// <summary>
		/// 項目「M1GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1genka_kin;

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
		/// 項目「M1GOKEI_SURYO(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1gokei_suryo
		{
			get
			{
				return this._m1gokei_suryo;
			}
			set
			{
				this._m1gokei_suryo = value;
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
		public Tb020f01M1BaseForm()
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
			Tb020f01M1BaseForm compare = null;
			if (obj is Tb020f01M1BaseForm)
			{
				compare = (Tb020f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
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
			if (_m1siire_kakutei_ymd != compare.M1siire_kakutei_ymd)
			{
				return false;
			}
			if (_m1gokei_suryo != compare.M1gokei_suryo)
			{
				return false;
			}
			if (_m1genka_kin != compare.M1genka_kin)
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
		/// <returns>現在のcom.xebio.bo.Tb020p01.Formvo.Tb020f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1nyukayotei_ymd:").Append(this._m1nyukayotei_ymd).AppendLine();
			str.Append("M1siire_kakutei_ymd:").Append(this._m1siire_kakutei_ymd).AppendLine();
			str.Append("M1gokei_suryo:").Append(this._m1gokei_suryo).AppendLine();
			str.Append("M1genka_kin:").Append(this._m1genka_kin).AppendLine();
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
			return "Tb020f01";
		}
		#endregion
		#endregion

	}
}
