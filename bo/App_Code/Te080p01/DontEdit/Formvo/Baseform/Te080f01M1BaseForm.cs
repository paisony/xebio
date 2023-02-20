using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Te080p01.Formvo.Baseform
{
  /// <summary>
  /// Te080f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te080f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1KAISYA_CD(会社)」の値
		/// </summary>
		private string _m1kaisya_cd;


		/// <summary>
		/// 項目「M1KAISYA_NM()」の値
		/// </summary>
		private string _m1kaisya_nm;

		/// <summary>
		/// 項目「M1SYUKKATEN_CD(出荷店)」の値
		/// </summary>
		private string _m1syukkaten_cd;


		/// <summary>
		/// 項目「M1SYUKKATEN_NM()」の値
		/// </summary>
		private string _m1syukkaten_nm;

		/// <summary>
		/// 項目「M1SCMDEN_CD(SCMコード/伝票番号)」の値
		/// </summary>
		private string _m1scmden_cd;

		/// <summary>
		/// 項目「M1SCM_CD(SCMコード)」の値
		/// </summary>
		private string _m1scm_cd;

		/// <summary>
		/// 項目「M1DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		private string _m1denpyo_bango;

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値
		/// </summary>
		private string _m1syukka_ymd;

		/// <summary>
		/// 項目「M1YOTEI_SU(予定数量)」の値
		/// </summary>
		private string _m1yotei_su;

		/// <summary>
		/// 項目「M1KYAKUCYU(客注)」の値
		/// </summary>
		private string _m1kyakucyu;

		/// <summary>
		/// 項目「M1NEGAKI(値書)」の値
		/// </summary>
		private string _m1negaki;

		/// <summary>
		/// 項目「M1TENPOLC_KBN_HDN()」の値
		/// </summary>
		private string _m1tenpolc_kbn_hdn;

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
		/// 項目「M1KAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kaisya_cd
		{
			get
			{
				return this._m1kaisya_cd;
			}
			set
			{
				this._m1kaisya_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1KAISYA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1kaisya_nm
		{
			get
			{
				return this._m1kaisya_nm;
			}
			set
			{
				this._m1kaisya_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKATEN_CD(出荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkaten_cd
		{
			get
			{
				return this._m1syukkaten_cd;
			}
			set
			{
				this._m1syukkaten_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1SYUKKATEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkaten_nm
		{
			get
			{
				return this._m1syukkaten_nm;
			}
			set
			{
				this._m1syukkaten_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SCMDEN_CD(SCMコード/伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scmden_cd
		{
			get
			{
				return this._m1scmden_cd;
			}
			set
			{
				this._m1scmden_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SCM_CD(SCMコード)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scm_cd
		{
			get
			{
				return this._m1scm_cd;
			}
			set
			{
				this._m1scm_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1DENPYO_BANGO(伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1denpyo_bango
		{
			get
			{
				return this._m1denpyo_bango;
			}
			set
			{
				this._m1denpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukka_ymd
		{
			get
			{
				return this._m1syukka_ymd;
			}
			set
			{
				this._m1syukka_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1YOTEI_SU(予定数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1yotei_su
		{
			get
			{
				return this._m1yotei_su;
			}
			set
			{
				this._m1yotei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1KYAKUCYU(客注)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kyakucyu
		{
			get
			{
				return this._m1kyakucyu;
			}
			set
			{
				this._m1kyakucyu = value;
			}
		}

		/// <summary>
		/// 項目「M1NEGAKI(値書)」の値を取得または設定する。
		/// </summary>
		public virtual string M1negaki
		{
			get
			{
				return this._m1negaki;
			}
			set
			{
				this._m1negaki = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPOLC_KBN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpolc_kbn_hdn
		{
			get
			{
				return this._m1tenpolc_kbn_hdn;
			}
			set
			{
				this._m1tenpolc_kbn_hdn = value;
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
		public Te080f01M1BaseForm()
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
			Te080f01M1BaseForm compare = null;
			if (obj is Te080f01M1BaseForm)
			{
				compare = (Te080f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1kaisya_cd != compare.M1kaisya_cd)
			{
				return false;
			}
			if (_m1kaisya_nm != compare.M1kaisya_nm)
			{
				return false;
			}
			if (_m1syukkaten_cd != compare.M1syukkaten_cd)
			{
				return false;
			}
			if (_m1syukkaten_nm != compare.M1syukkaten_nm)
			{
				return false;
			}
			if (_m1scmden_cd != compare.M1scmden_cd)
			{
				return false;
			}
			if (_m1scm_cd != compare.M1scm_cd)
			{
				return false;
			}
			if (_m1denpyo_bango != compare.M1denpyo_bango)
			{
				return false;
			}
			if (_m1syukka_ymd != compare.M1syukka_ymd)
			{
				return false;
			}
			if (_m1yotei_su != compare.M1yotei_su)
			{
				return false;
			}
			if (_m1kyakucyu != compare.M1kyakucyu)
			{
				return false;
			}
			if (_m1negaki != compare.M1negaki)
			{
				return false;
			}
			if (_m1tenpolc_kbn_hdn != compare.M1tenpolc_kbn_hdn)
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
		/// <returns>現在のcom.xebio.bo.Te080p01.Formvo.Te080f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1kaisya_cd:").Append(this._m1kaisya_cd).AppendLine();
			str.Append("M1kaisya_nm:").Append(this._m1kaisya_nm).AppendLine();
			str.Append("M1syukkaten_cd:").Append(this._m1syukkaten_cd).AppendLine();
			str.Append("M1syukkaten_nm:").Append(this._m1syukkaten_nm).AppendLine();
			str.Append("M1scmden_cd:").Append(this._m1scmden_cd).AppendLine();
			str.Append("M1scm_cd:").Append(this._m1scm_cd).AppendLine();
			str.Append("M1denpyo_bango:").Append(this._m1denpyo_bango).AppendLine();
			str.Append("M1syukka_ymd:").Append(this._m1syukka_ymd).AppendLine();
			str.Append("M1yotei_su:").Append(this._m1yotei_su).AppendLine();
			str.Append("M1kyakucyu:").Append(this._m1kyakucyu).AppendLine();
			str.Append("M1negaki:").Append(this._m1negaki).AppendLine();
			str.Append("M1tenpolc_kbn_hdn:").Append(this._m1tenpolc_kbn_hdn).AppendLine();
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
			return "Te080f01";
		}
		#endregion
		#endregion

	}
}
