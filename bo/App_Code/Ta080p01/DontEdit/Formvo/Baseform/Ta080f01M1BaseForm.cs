using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta080p01.Formvo.Baseform
{
  /// <summary>
  /// Ta080f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1YOSAN_YMD(年月度)」の値
		/// </summary>
		private string _m1yosan_ymd;


		/// <summary>
		/// 項目「M1YOSAN_KIN(予算金額)」の値
		/// </summary>
		private string _m1yosan_kin;

		/// <summary>
		/// 項目「M1MISINSEI_SU(未申請数)」の値
		/// </summary>
		private string _m1misinsei_su;

		/// <summary>
		/// 項目「M1MISINSEI_KIN(未申請金額)」の値
		/// </summary>
		private string _m1misinsei_kin;

		/// <summary>
		/// 項目「M1APPLYGOKEI_SU(申請数)」の値
		/// </summary>
		private string _m1applygokei_su;

		/// <summary>
		/// 項目「M1APPLYGOKEI_KIN(申請金額)」の値
		/// </summary>
		private string _m1applygokei_kin;

		/// <summary>
		/// 項目「M1JISSEKIGOKEI_SU(実績数)」の値
		/// </summary>
		private string _m1jissekigokei_su;

		/// <summary>
		/// 項目「M1JISSEKIGOKEI_KIN(実績金額)」の値
		/// </summary>
		private string _m1jissekigokei_kin;

		/// <summary>
		/// 項目「M1ZAN_KIN(残金額)」の値
		/// </summary>
		private string _m1zan_kin;

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
		/// 項目「M1YOSAN_YMD(年月度)」の値を取得または設定する。
		/// </summary>
		public virtual string M1yosan_ymd
		{
			get
			{
				return this._m1yosan_ymd;
			}
			set
			{
				this._m1yosan_ymd = value;
			}
		}


		/// <summary>
		/// 項目「M1YOSAN_KIN(予算金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1yosan_kin
		{
			get
			{
				return this._m1yosan_kin;
			}
			set
			{
				this._m1yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1MISINSEI_SU(未申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1misinsei_su
		{
			get
			{
				return this._m1misinsei_su;
			}
			set
			{
				this._m1misinsei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1MISINSEI_KIN(未申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1misinsei_kin
		{
			get
			{
				return this._m1misinsei_kin;
			}
			set
			{
				this._m1misinsei_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1APPLYGOKEI_SU(申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1applygokei_su
		{
			get
			{
				return this._m1applygokei_su;
			}
			set
			{
				this._m1applygokei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1APPLYGOKEI_KIN(申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1applygokei_kin
		{
			get
			{
				return this._m1applygokei_kin;
			}
			set
			{
				this._m1applygokei_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1JISSEKIGOKEI_SU(実績数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jissekigokei_su
		{
			get
			{
				return this._m1jissekigokei_su;
			}
			set
			{
				this._m1jissekigokei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JISSEKIGOKEI_KIN(実績金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jissekigokei_kin
		{
			get
			{
				return this._m1jissekigokei_kin;
			}
			set
			{
				this._m1jissekigokei_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1ZAN_KIN(残金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1zan_kin
		{
			get
			{
				return this._m1zan_kin;
			}
			set
			{
				this._m1zan_kin = value;
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
		public Ta080f01M1BaseForm()
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
			Ta080f01M1BaseForm compare = null;
			if (obj is Ta080f01M1BaseForm)
			{
				compare = (Ta080f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1yosan_ymd != compare.M1yosan_ymd)
			{
				return false;
			}
			if (_m1yosan_kin != compare.M1yosan_kin)
			{
				return false;
			}
			if (_m1misinsei_su != compare.M1misinsei_su)
			{
				return false;
			}
			if (_m1misinsei_kin != compare.M1misinsei_kin)
			{
				return false;
			}
			if (_m1applygokei_su != compare.M1applygokei_su)
			{
				return false;
			}
			if (_m1applygokei_kin != compare.M1applygokei_kin)
			{
				return false;
			}
			if (_m1jissekigokei_su != compare.M1jissekigokei_su)
			{
				return false;
			}
			if (_m1jissekigokei_kin != compare.M1jissekigokei_kin)
			{
				return false;
			}
			if (_m1zan_kin != compare.M1zan_kin)
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
		/// <returns>現在のcom.xebio.bo.Ta080p01.Formvo.Ta080f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1yosan_ymd:").Append(this._m1yosan_ymd).AppendLine();
			str.Append("M1yosan_kin:").Append(this._m1yosan_kin).AppendLine();
			str.Append("M1misinsei_su:").Append(this._m1misinsei_su).AppendLine();
			str.Append("M1misinsei_kin:").Append(this._m1misinsei_kin).AppendLine();
			str.Append("M1applygokei_su:").Append(this._m1applygokei_su).AppendLine();
			str.Append("M1applygokei_kin:").Append(this._m1applygokei_kin).AppendLine();
			str.Append("M1jissekigokei_su:").Append(this._m1jissekigokei_su).AppendLine();
			str.Append("M1jissekigokei_kin:").Append(this._m1jissekigokei_kin).AppendLine();
			str.Append("M1zan_kin:").Append(this._m1zan_kin).AppendLine();
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
			return "Ta080f01";
		}
		#endregion
		#endregion

	}
}
