using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ti040p01.Formvo.Baseform
{
  /// <summary>
  /// Ti040f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti040f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1LABEL_CD(ラベル発行機ＩＤ)」の値
		/// </summary>
		private string _m1label_cd;

		/// <summary>
		/// 項目「M1LABEL_CD2(ラベル発行機ＩＤ)」の値
		/// </summary>
		private string _m1label_cd2;

		/// <summary>
		/// 項目「M1LABEL_IP(ラベル発行機ＩＰ)」の値
		/// </summary>
		private string _m1label_ip;

		/// <summary>
		/// 項目「M1LABEL_IP2(ラベル発行機ＩＰ)」の値
		/// </summary>
		private string _m1label_ip2;

		/// <summary>
		/// 項目「M1LABEL_IP3(ラベル発行機ＩＰ)」の値
		/// </summary>
		private string _m1label_ip3;

		/// <summary>
		/// 項目「M1LABEL_IP4(ラベル発行機ＩＰ)」の値
		/// </summary>
		private string _m1label_ip4;

		/// <summary>
		/// 項目「M1LABEL_NM(ラベル発行機名)」の値
		/// </summary>
		private string _m1label_nm;

		/// <summary>
		/// 項目「M1LABEL_BIKO(備考)」の値
		/// </summary>
		private string _m1label_biko;

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
		/// 項目「M1LABEL_CD(ラベル発行機ＩＤ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_cd
		{
			get
			{
				return this._m1label_cd;
			}
			set
			{
				this._m1label_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_CD2(ラベル発行機ＩＤ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_cd2
		{
			get
			{
				return this._m1label_cd2;
			}
			set
			{
				this._m1label_cd2 = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_IP(ラベル発行機ＩＰ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_ip
		{
			get
			{
				return this._m1label_ip;
			}
			set
			{
				this._m1label_ip = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_IP2(ラベル発行機ＩＰ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_ip2
		{
			get
			{
				return this._m1label_ip2;
			}
			set
			{
				this._m1label_ip2 = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_IP3(ラベル発行機ＩＰ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_ip3
		{
			get
			{
				return this._m1label_ip3;
			}
			set
			{
				this._m1label_ip3 = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_IP4(ラベル発行機ＩＰ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_ip4
		{
			get
			{
				return this._m1label_ip4;
			}
			set
			{
				this._m1label_ip4 = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_NM(ラベル発行機名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_nm
		{
			get
			{
				return this._m1label_nm;
			}
			set
			{
				this._m1label_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1LABEL_BIKO(備考)」の値を取得または設定する。
		/// </summary>
		public virtual string M1label_biko
		{
			get
			{
				return this._m1label_biko;
			}
			set
			{
				this._m1label_biko = value;
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
		public Ti040f01M1BaseForm()
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
			Ti040f01M1BaseForm compare = null;
			if (obj is Ti040f01M1BaseForm)
			{
				compare = (Ti040f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1label_cd != compare.M1label_cd)
			{
				return false;
			}
			if (_m1label_cd2 != compare.M1label_cd2)
			{
				return false;
			}
			if (_m1label_ip != compare.M1label_ip)
			{
				return false;
			}
			if (_m1label_ip2 != compare.M1label_ip2)
			{
				return false;
			}
			if (_m1label_ip3 != compare.M1label_ip3)
			{
				return false;
			}
			if (_m1label_ip4 != compare.M1label_ip4)
			{
				return false;
			}
			if (_m1label_nm != compare.M1label_nm)
			{
				return false;
			}
			if (_m1label_biko != compare.M1label_biko)
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
		/// <returns>現在のcom.xebio.bo.Ti040p01.Formvo.Ti040f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1label_cd:").Append(this._m1label_cd).AppendLine();
			str.Append("M1label_cd2:").Append(this._m1label_cd2).AppendLine();
			str.Append("M1label_ip:").Append(this._m1label_ip).AppendLine();
			str.Append("M1label_ip2:").Append(this._m1label_ip2).AppendLine();
			str.Append("M1label_ip3:").Append(this._m1label_ip3).AppendLine();
			str.Append("M1label_ip4:").Append(this._m1label_ip4).AppendLine();
			str.Append("M1label_nm:").Append(this._m1label_nm).AppendLine();
			str.Append("M1label_biko:").Append(this._m1label_biko).AppendLine();
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
			return "Ti040f01";
		}
		#endregion
		#endregion

	}
}
