using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tl030p01.Formvo.Baseform
{
  /// <summary>
  /// Tl030f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl030f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1SHINSEIMOTO_NM(申請元)」の値
		/// </summary>
		private string _m1shinseimoto_nm;

		/// <summary>
		/// 項目「M1SINSEITAN_NM(申請担当者)」の値
		/// </summary>
		private string _m1sinseitan_nm;

		/// <summary>
		/// 項目「M1BAIHEN_SHIJI_NO(指示No)」の値
		/// </summary>
		private string _m1baihen_shiji_no;


		/// <summary>
		/// 項目「M1BAIHENSAGYOKAISI_YMD(作業開始日)」の値
		/// </summary>
		private string _m1baihensagyokaisi_ymd;

		/// <summary>
		/// 項目「M1BAIHENKAISI_YMD(開始日)」の値
		/// </summary>
		private string _m1baihenkaisi_ymd;

		/// <summary>
		/// 項目「M1BAIHEN_RIYU_NM(売変理由)」の値
		/// </summary>
		private string _m1baihen_riyu_nm;

		/// <summary>
		/// 項目「M1HINBAN_SU(品番数)」の値
		/// </summary>
		private string _m1hinban_su;

		/// <summary>
		/// 項目「M1ZAIKO_SU(在庫点数)」の値
		/// </summary>
		private string _m1zaiko_su;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX(選択フラグ(隠し))」の値
		/// </summary>
		private string _m1selectorcheckbox;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG(確定処理フラグ(隠し))」の値
		/// </summary>
		private string _m1entersyoriflg;

		/// <summary>
		/// 項目「M1DTLIROKBN(明細色区分(隠し))」の値
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
		/// 項目「M1SHINSEIMOTO_NM(申請元)」の値を取得または設定する。
		/// </summary>
		public virtual string M1shinseimoto_nm
		{
			get
			{
				return this._m1shinseimoto_nm;
			}
			set
			{
				this._m1shinseimoto_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEITAN_NM(申請担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinseitan_nm
		{
			get
			{
				return this._m1sinseitan_nm;
			}
			set
			{
				this._m1sinseitan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIHEN_SHIJI_NO(指示No)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baihen_shiji_no
		{
			get
			{
				return this._m1baihen_shiji_no;
			}
			set
			{
				this._m1baihen_shiji_no = value;
			}
		}


		/// <summary>
		/// 項目「M1BAIHENSAGYOKAISI_YMD(作業開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baihensagyokaisi_ymd
		{
			get
			{
				return this._m1baihensagyokaisi_ymd;
			}
			set
			{
				this._m1baihensagyokaisi_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIHENKAISI_YMD(開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baihenkaisi_ymd
		{
			get
			{
				return this._m1baihenkaisi_ymd;
			}
			set
			{
				this._m1baihenkaisi_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIHEN_RIYU_NM(売変理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baihen_riyu_nm
		{
			get
			{
				return this._m1baihen_riyu_nm;
			}
			set
			{
				this._m1baihen_riyu_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HINBAN_SU(品番数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinban_su
		{
			get
			{
				return this._m1hinban_su;
			}
			set
			{
				this._m1hinban_su = value;
			}
		}

		/// <summary>
		/// 項目「M1ZAIKO_SU(在庫点数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1zaiko_su
		{
			get
			{
				return this._m1zaiko_su;
			}
			set
			{
				this._m1zaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX(選択フラグ(隠し))」の値を取得または設定する。
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
		/// 項目「M1ENTERSYORIFLG(確定処理フラグ(隠し))」の値を取得または設定する。
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
		/// 項目「M1DTLIROKBN(明細色区分(隠し))」の値を取得または設定する。
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
		public Tl030f01M1BaseForm()
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
			Tl030f01M1BaseForm compare = null;
			if (obj is Tl030f01M1BaseForm)
			{
				compare = (Tl030f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1shinseimoto_nm != compare.M1shinseimoto_nm)
			{
				return false;
			}
			if (_m1sinseitan_nm != compare.M1sinseitan_nm)
			{
				return false;
			}
			if (_m1baihen_shiji_no != compare.M1baihen_shiji_no)
			{
				return false;
			}
			if (_m1baihensagyokaisi_ymd != compare.M1baihensagyokaisi_ymd)
			{
				return false;
			}
			if (_m1baihenkaisi_ymd != compare.M1baihenkaisi_ymd)
			{
				return false;
			}
			if (_m1baihen_riyu_nm != compare.M1baihen_riyu_nm)
			{
				return false;
			}
			if (_m1hinban_su != compare.M1hinban_su)
			{
				return false;
			}
			if (_m1zaiko_su != compare.M1zaiko_su)
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
		/// <returns>現在のcom.xebio.bo.Tl030p01.Formvo.Tl030f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1shinseimoto_nm:").Append(this._m1shinseimoto_nm).AppendLine();
			str.Append("M1sinseitan_nm:").Append(this._m1sinseitan_nm).AppendLine();
			str.Append("M1baihen_shiji_no:").Append(this._m1baihen_shiji_no).AppendLine();
			str.Append("M1baihensagyokaisi_ymd:").Append(this._m1baihensagyokaisi_ymd).AppendLine();
			str.Append("M1baihenkaisi_ymd:").Append(this._m1baihenkaisi_ymd).AppendLine();
			str.Append("M1baihen_riyu_nm:").Append(this._m1baihen_riyu_nm).AppendLine();
			str.Append("M1hinban_su:").Append(this._m1hinban_su).AppendLine();
			str.Append("M1zaiko_su:").Append(this._m1zaiko_su).AppendLine();
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
			return "Tl030f01";
		}
		#endregion
		#endregion

	}
}
