using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf060p01.VO
{
  /// <summary>
  /// Tf060f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tf060f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1GETUNAI_HIDUKE(日)」の値
		/// </summary>
		private string _m1getunai_hiduke;

		/// <summary>
		/// 項目「M1YOBI(曜日)」の値
		/// </summary>
		private string _m1yobi;

		/// <summary>
		/// 項目「M1BUMON1_YOSAN_KIN(部門１)」の値
		/// </summary>
		private string _m1bumon1_yosan_kin;

		/// <summary>
		/// 項目「M1BUMON2_YOSAN_KIN(部門２)」の値
		/// </summary>
		private string _m1bumon2_yosan_kin;

		/// <summary>
		/// 項目「M1BUMON3_YOSAN_KIN(部門３)」の値
		/// </summary>
		private string _m1bumon3_yosan_kin;

		/// <summary>
		/// 項目「M1BUMON4_YOSAN_KIN(部門４)」の値
		/// </summary>
		private string _m1bumon4_yosan_kin;

		/// <summary>
		/// 項目「M1BUMON5_YOSAN_KIN(部門５)」の値
		/// </summary>
		private string _m1bumon5_yosan_kin;

		/// <summary>
		/// 項目「M1HIBETU_YOSAN_KIN(合計)」の値
		/// </summary>
		private string _m1hibetu_yosan_kin;

		/// <summary>
		/// 項目「M1BUMON1_YOSAN_KIN_HDN()」の値
		/// </summary>
		private string _m1bumon1_yosan_kin_hdn;

		/// <summary>
		/// 項目「M1BUMON2_YOSAN_KIN_HDN()」の値
		/// </summary>
		private string _m1bumon2_yosan_kin_hdn;

		/// <summary>
		/// 項目「M1BUMON3_YOSAN_KIN_HDN()」の値
		/// </summary>
		private string _m1bumon3_yosan_kin_hdn;

		/// <summary>
		/// 項目「M1BUMON4_YOSAN_KIN_HDN()」の値
		/// </summary>
		private string _m1bumon4_yosan_kin_hdn;

		/// <summary>
		/// 項目「M1BUMON5_YOSAN_KIN_HDN()」の値
		/// </summary>
		private string _m1bumon5_yosan_kin_hdn;

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
		/// 項目「M1GETUNAI_HIDUKE(日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1getunai_hiduke
		{
			get
			{
				return this._m1getunai_hiduke;
			}
			set
			{
				this._m1getunai_hiduke = value;
			}
		}

		/// <summary>
		/// 項目「M1YOBI(曜日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1yobi
		{
			get
			{
				return this._m1yobi;
			}
			set
			{
				this._m1yobi = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON1_YOSAN_KIN(部門１)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon1_yosan_kin
		{
			get
			{
				return this._m1bumon1_yosan_kin;
			}
			set
			{
				this._m1bumon1_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON2_YOSAN_KIN(部門２)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon2_yosan_kin
		{
			get
			{
				return this._m1bumon2_yosan_kin;
			}
			set
			{
				this._m1bumon2_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON3_YOSAN_KIN(部門３)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon3_yosan_kin
		{
			get
			{
				return this._m1bumon3_yosan_kin;
			}
			set
			{
				this._m1bumon3_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON4_YOSAN_KIN(部門４)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon4_yosan_kin
		{
			get
			{
				return this._m1bumon4_yosan_kin;
			}
			set
			{
				this._m1bumon4_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON5_YOSAN_KIN(部門５)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon5_yosan_kin
		{
			get
			{
				return this._m1bumon5_yosan_kin;
			}
			set
			{
				this._m1bumon5_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1HIBETU_YOSAN_KIN(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hibetu_yosan_kin
		{
			get
			{
				return this._m1hibetu_yosan_kin;
			}
			set
			{
				this._m1hibetu_yosan_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON1_YOSAN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon1_yosan_kin_hdn
		{
			get
			{
				return this._m1bumon1_yosan_kin_hdn;
			}
			set
			{
				this._m1bumon1_yosan_kin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON2_YOSAN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon2_yosan_kin_hdn
		{
			get
			{
				return this._m1bumon2_yosan_kin_hdn;
			}
			set
			{
				this._m1bumon2_yosan_kin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON3_YOSAN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon3_yosan_kin_hdn
		{
			get
			{
				return this._m1bumon3_yosan_kin_hdn;
			}
			set
			{
				this._m1bumon3_yosan_kin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON4_YOSAN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon4_yosan_kin_hdn
		{
			get
			{
				return this._m1bumon4_yosan_kin_hdn;
			}
			set
			{
				this._m1bumon4_yosan_kin_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON5_YOSAN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon5_yosan_kin_hdn
		{
			get
			{
				return this._m1bumon5_yosan_kin_hdn;
			}
			set
			{
				this._m1bumon5_yosan_kin_hdn = value;
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
		public Tf060f01M1ResultVO() : base()
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
			Tf060f01M1ResultVO compare = null;
			if (obj is Tf060f01M1ResultVO)
			{
				compare = (Tf060f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1getunai_hiduke != compare.M1getunai_hiduke)
			{
				return false;
			}
			if (_m1yobi != compare.M1yobi)
			{
				return false;
			}
			if (_m1bumon1_yosan_kin != compare.M1bumon1_yosan_kin)
			{
				return false;
			}
			if (_m1bumon2_yosan_kin != compare.M1bumon2_yosan_kin)
			{
				return false;
			}
			if (_m1bumon3_yosan_kin != compare.M1bumon3_yosan_kin)
			{
				return false;
			}
			if (_m1bumon4_yosan_kin != compare.M1bumon4_yosan_kin)
			{
				return false;
			}
			if (_m1bumon5_yosan_kin != compare.M1bumon5_yosan_kin)
			{
				return false;
			}
			if (_m1hibetu_yosan_kin != compare.M1hibetu_yosan_kin)
			{
				return false;
			}
			if (_m1bumon1_yosan_kin_hdn != compare.M1bumon1_yosan_kin_hdn)
			{
				return false;
			}
			if (_m1bumon2_yosan_kin_hdn != compare.M1bumon2_yosan_kin_hdn)
			{
				return false;
			}
			if (_m1bumon3_yosan_kin_hdn != compare.M1bumon3_yosan_kin_hdn)
			{
				return false;
			}
			if (_m1bumon4_yosan_kin_hdn != compare.M1bumon4_yosan_kin_hdn)
			{
				return false;
			}
			if (_m1bumon5_yosan_kin_hdn != compare.M1bumon5_yosan_kin_hdn)
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
		/// <returns>現在のcom.xebio.bo.Tf060p01.Formvo.Tf060f01M1Formのハッシュ コード。</returns>
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

			str.Append("M1getunai_hiduke:").Append(this._m1getunai_hiduke).AppendLine();
			str.Append("M1yobi:").Append(this._m1yobi).AppendLine();
			str.Append("M1bumon1_yosan_kin:").Append(this._m1bumon1_yosan_kin).AppendLine();
			str.Append("M1bumon2_yosan_kin:").Append(this._m1bumon2_yosan_kin).AppendLine();
			str.Append("M1bumon3_yosan_kin:").Append(this._m1bumon3_yosan_kin).AppendLine();
			str.Append("M1bumon4_yosan_kin:").Append(this._m1bumon4_yosan_kin).AppendLine();
			str.Append("M1bumon5_yosan_kin:").Append(this._m1bumon5_yosan_kin).AppendLine();
			str.Append("M1hibetu_yosan_kin:").Append(this._m1hibetu_yosan_kin).AppendLine();
			str.Append("M1bumon1_yosan_kin_hdn:").Append(this._m1bumon1_yosan_kin_hdn).AppendLine();
			str.Append("M1bumon2_yosan_kin_hdn:").Append(this._m1bumon2_yosan_kin_hdn).AppendLine();
			str.Append("M1bumon3_yosan_kin_hdn:").Append(this._m1bumon3_yosan_kin_hdn).AppendLine();
			str.Append("M1bumon4_yosan_kin_hdn:").Append(this._m1bumon4_yosan_kin_hdn).AppendLine();
			str.Append("M1bumon5_yosan_kin_hdn:").Append(this._m1bumon5_yosan_kin_hdn).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
