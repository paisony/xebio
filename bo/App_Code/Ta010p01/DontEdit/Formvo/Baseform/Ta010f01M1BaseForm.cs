using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta010p01.Formvo.Baseform
{
  /// <summary>
  /// Ta010f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta010f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1HOJUIRAI_KBN_NM(区分)」の値
		/// </summary>
		private string _m1hojuirai_kbn_nm;


		/// <summary>
		/// 項目「M1HATTYU_YMD(発注日)」の値
		/// </summary>
		private string _m1hattyu_ymd;

		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値
		/// </summary>
		private string _m1itemsu;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1HANBAIIN_NM(担当者)」の値
		/// </summary>
		private string _m1hanbaiin_nm;

		/// <summary>
		/// 項目「M1IRAI_RIYU(依頼理由)」の値
		/// </summary>
		private string _m1irai_riyu;

		/// <summary>
		/// 項目「M1SINSEI_JOTAINM(状態)」の値
		/// </summary>
		private string _m1sinsei_jotainm;

		/// <summary>
		/// 項目「M1APPLY_YMD(申請日)」の値
		/// </summary>
		private string _m1apply_ymd;

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
		/// 項目「M1HOJUIRAI_KBN_NM(区分)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hojuirai_kbn_nm
		{
			get
			{
				return this._m1hojuirai_kbn_nm;
			}
			set
			{
				this._m1hojuirai_kbn_nm = value;
			}
		}


		/// <summary>
		/// 項目「M1HATTYU_YMD(発注日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hattyu_ymd
		{
			get
			{
				return this._m1hattyu_ymd;
			}
			set
			{
				this._m1hattyu_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1itemsu
		{
			get
			{
				return this._m1itemsu;
			}
			set
			{
				this._m1itemsu = value;
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
		/// 項目「M1HANBAIIN_NM(担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaiin_nm
		{
			get
			{
				return this._m1hanbaiin_nm;
			}
			set
			{
				this._m1hanbaiin_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAI_RIYU(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1irai_riyu
		{
			get
			{
				return this._m1irai_riyu;
			}
			set
			{
				this._m1irai_riyu = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEI_JOTAINM(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_jotainm
		{
			get
			{
				return this._m1sinsei_jotainm;
			}
			set
			{
				this._m1sinsei_jotainm = value;
			}
		}

		/// <summary>
		/// 項目「M1APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1apply_ymd
		{
			get
			{
				return this._m1apply_ymd;
			}
			set
			{
				this._m1apply_ymd = value;
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
		public Ta010f01M1BaseForm()
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
			Ta010f01M1BaseForm compare = null;
			if (obj is Ta010f01M1BaseForm)
			{
				compare = (Ta010f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1hojuirai_kbn_nm != compare.M1hojuirai_kbn_nm)
			{
				return false;
			}
			if (_m1hattyu_ymd != compare.M1hattyu_ymd)
			{
				return false;
			}
			if (_m1itemsu != compare.M1itemsu)
			{
				return false;
			}
			if (_m1genkakin != compare.M1genkakin)
			{
				return false;
			}
			if (_m1hanbaiin_nm != compare.M1hanbaiin_nm)
			{
				return false;
			}
			if (_m1irai_riyu != compare.M1irai_riyu)
			{
				return false;
			}
			if (_m1sinsei_jotainm != compare.M1sinsei_jotainm)
			{
				return false;
			}
			if (_m1apply_ymd != compare.M1apply_ymd)
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
		/// <returns>現在のcom.xebio.bo.Ta010p01.Formvo.Ta010f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1hojuirai_kbn_nm:").Append(this._m1hojuirai_kbn_nm).AppendLine();
			str.Append("M1hattyu_ymd:").Append(this._m1hattyu_ymd).AppendLine();
			str.Append("M1itemsu:").Append(this._m1itemsu).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1hanbaiin_nm:").Append(this._m1hanbaiin_nm).AppendLine();
			str.Append("M1irai_riyu:").Append(this._m1irai_riyu).AppendLine();
			str.Append("M1sinsei_jotainm:").Append(this._m1sinsei_jotainm).AppendLine();
			str.Append("M1apply_ymd:").Append(this._m1apply_ymd).AppendLine();
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
			return "Ta010f01";
		}
		#endregion
		#endregion

	}
}
