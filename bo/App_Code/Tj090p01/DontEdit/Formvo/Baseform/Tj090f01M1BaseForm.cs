using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj090p01.Formvo.Baseform
{
  /// <summary>
  /// Tj090f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj090f01M1BaseForm : StandardBaseM1Form
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド

		/// <summary>
		/// 項目「M1FACE_NO(ﾌｪｲｽNo)」の値
		/// </summary>
		private string _m1face_no;

		/// <summary>
		/// 項目「M1TANA_DAN(棚段)」の値
		/// </summary>
		private string _m1tana_dan;

		/// <summary>
		/// 項目「M1KAI_SU(回数)」の値
		/// </summary>
		private string _m1kai_su;

		/// <summary>
		/// 項目「M1TENSUTANAOROSINYURYOKU_SU(入力数量)」の値
		/// </summary>
		private string _m1tensutanaorosinyuryoku_su;

		/// <summary>
		/// 項目「M1TENSUTANAOROSITEISEI_SU(訂正数量)」の値
		/// </summary>
		private string _m1tensutanaorositeisei_su;

		/// <summary>
		/// 項目「M1TENSUTANAOROSITEISEI_SU_HDN()」の値
		/// </summary>
		private string _m1tensutanaorositeisei_su_hdn;

		/// <summary>
		/// 項目「M1TENSUTANAOROSIGOKEI_SU(合計数量)」の値
		/// </summary>
		private string _m1tensutanaorosigokei_su;

		/// <summary>
		/// 項目「M1SCAN_SU(ｽｷｬﾝ数量)」の値
		/// </summary>
		private string _m1scan_su;

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数量)」の値
		/// </summary>
		private string _m1teisei_suryo;

		/// <summary>
		/// 項目「M1GOKEI_SURYO(合計数量)」の値
		/// </summary>
		private string _m1gokei_suryo;

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値
		/// </summary>
		private string _m1nyuryokutan_nm;

		/// <summary>
		/// 項目「M1RIYUCOMMENT_NM(棚卸理由)」の値
		/// </summary>
		private string _m1riyucomment_nm;

		/// <summary>
		/// 項目「M1NYURYOKU_YMD(入力日)」の値
		/// </summary>
		private string _m1nyuryoku_ymd;

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
		/// 項目「M1FACE_NO(ﾌｪｲｽNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no
		{
			get
			{
				return this._m1face_no;
			}
			set
			{
				this._m1face_no = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan
		{
			get
			{
				return this._m1tana_dan;
			}
			set
			{
				this._m1tana_dan = value;
			}
		}

		/// <summary>
		/// 項目「M1KAI_SU(回数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kai_su
		{
			get
			{
				return this._m1kai_su;
			}
			set
			{
				this._m1kai_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TENSUTANAOROSINYURYOKU_SU(入力数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tensutanaorosinyuryoku_su
		{
			get
			{
				return this._m1tensutanaorosinyuryoku_su;
			}
			set
			{
				this._m1tensutanaorosinyuryoku_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TENSUTANAOROSITEISEI_SU(訂正数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tensutanaorositeisei_su
		{
			get
			{
				return this._m1tensutanaorositeisei_su;
			}
			set
			{
				this._m1tensutanaorositeisei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TENSUTANAOROSITEISEI_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tensutanaorositeisei_su_hdn
		{
			get
			{
				return this._m1tensutanaorositeisei_su_hdn;
			}
			set
			{
				this._m1tensutanaorositeisei_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1TENSUTANAOROSIGOKEI_SU(合計数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tensutanaorosigokei_su
		{
			get
			{
				return this._m1tensutanaorosigokei_su;
			}
			set
			{
				this._m1tensutanaorosigokei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1SCAN_SU(ｽｷｬﾝ数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scan_su
		{
			get
			{
				return this._m1scan_su;
			}
			set
			{
				this._m1scan_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1teisei_suryo
		{
			get
			{
				return this._m1teisei_suryo;
			}
			set
			{
				this._m1teisei_suryo = value;
			}
		}

		/// <summary>
		/// 項目「M1GOKEI_SURYO(合計数量)」の値を取得または設定する。
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
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyuryokutan_nm
		{
			get
			{
				return this._m1nyuryokutan_nm;
			}
			set
			{
				this._m1nyuryokutan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1RIYUCOMMENT_NM(棚卸理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1riyucomment_nm
		{
			get
			{
				return this._m1riyucomment_nm;
			}
			set
			{
				this._m1riyucomment_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1NYURYOKU_YMD(入力日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyuryoku_ymd
		{
			get
			{
				return this._m1nyuryoku_ymd;
			}
			set
			{
				this._m1nyuryoku_ymd = value;
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
		public Tj090f01M1BaseForm()
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
			Tj090f01M1BaseForm compare = null;
			if (obj is Tj090f01M1BaseForm)
			{
				compare = (Tj090f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1face_no != compare.M1face_no)
			{
				return false;
			}
			if (_m1tana_dan != compare.M1tana_dan)
			{
				return false;
			}
			if (_m1kai_su != compare.M1kai_su)
			{
				return false;
			}
			if (_m1tensutanaorosinyuryoku_su != compare.M1tensutanaorosinyuryoku_su)
			{
				return false;
			}
			if (_m1tensutanaorositeisei_su != compare.M1tensutanaorositeisei_su)
			{
				return false;
			}
			if (_m1tensutanaorositeisei_su_hdn != compare.M1tensutanaorositeisei_su_hdn)
			{
				return false;
			}
			if (_m1tensutanaorosigokei_su != compare.M1tensutanaorosigokei_su)
			{
				return false;
			}
			if (_m1scan_su != compare.M1scan_su)
			{
				return false;
			}
			if (_m1teisei_suryo != compare.M1teisei_suryo)
			{
				return false;
			}
			if (_m1gokei_suryo != compare.M1gokei_suryo)
			{
				return false;
			}
			if (_m1nyuryokutan_nm != compare.M1nyuryokutan_nm)
			{
				return false;
			}
			if (_m1riyucomment_nm != compare.M1riyucomment_nm)
			{
				return false;
			}
			if (_m1nyuryoku_ymd != compare.M1nyuryoku_ymd)
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
		/// <returns>現在のcom.xebio.bo.Tj090p01.Formvo.Tj090f01M1Formのハッシュ コード。</returns>
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

			str.Append("M1face_no:").Append(this._m1face_no).AppendLine();
			str.Append("M1tana_dan:").Append(this._m1tana_dan).AppendLine();
			str.Append("M1kai_su:").Append(this._m1kai_su).AppendLine();
			str.Append("M1tensutanaorosinyuryoku_su:").Append(this._m1tensutanaorosinyuryoku_su).AppendLine();
			str.Append("M1tensutanaorositeisei_su:").Append(this._m1tensutanaorositeisei_su).AppendLine();
			str.Append("M1tensutanaorositeisei_su_hdn:").Append(this._m1tensutanaorositeisei_su_hdn).AppendLine();
			str.Append("M1tensutanaorosigokei_su:").Append(this._m1tensutanaorosigokei_su).AppendLine();
			str.Append("M1scan_su:").Append(this._m1scan_su).AppendLine();
			str.Append("M1teisei_suryo:").Append(this._m1teisei_suryo).AppendLine();
			str.Append("M1gokei_suryo:").Append(this._m1gokei_suryo).AppendLine();
			str.Append("M1nyuryokutan_nm:").Append(this._m1nyuryokutan_nm).AppendLine();
			str.Append("M1riyucomment_nm:").Append(this._m1riyucomment_nm).AppendLine();
			str.Append("M1nyuryoku_ymd:").Append(this._m1nyuryoku_ymd).AppendLine();
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
			return "Tj090f01";
		}
		#endregion
		#endregion

	}
}
