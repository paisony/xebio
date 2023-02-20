using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj190p01.Formvo.Baseform
{
  /// <summary>
  /// Tj190f02 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj190f02M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _m1maker_hbn;

		/// <summary>
		/// 項目「M1SYONMK(商品名)」の値
		/// </summary>
		private string _m1syonmk;

		/// <summary>
		/// 項目「M1IRO_NM(色)」の値
		/// </summary>
		private string _m1iro_nm;

		/// <summary>
		/// 項目「M1SIZE_NM(サイズ)」の値
		/// </summary>
		private string _m1size_nm;

		/// <summary>
		/// 項目「M1SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _m1scan_cd;

		/// <summary>
		/// 項目「M1HYOKA_TNK(評価単価)」の値
		/// </summary>
		private string _m1hyoka_tnk;

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU(棚時帳簿数)」の値
		/// </summary>
		private string _m1tanajityobo_su;

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU_HDN()」の値
		/// </summary>
		private string _m1tanajityobo_su_hdn;

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU(棚時積送数)」の値
		/// </summary>
		private string _m1tanajisekiso_su;

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU_HDN()」の値
		/// </summary>
		private string _m1tanajisekiso_su_hdn;

		/// <summary>
		/// 項目「M1JITANA_SU(実棚数)」の値
		/// </summary>
		private string _m1jitana_su;

		/// <summary>
		/// 項目「M1JITANA_SU1_HDN()」の値
		/// </summary>
		private string _m1jitana_su1_hdn;

		/// <summary>
		/// 項目「M1LOSS_SU(ロス数)」の値
		/// </summary>
		private string _m1loss_su;

		/// <summary>
		/// 項目「M1LOSS_KIN(ロス金額)」の値
		/// </summary>
		private string _m1loss_kin;

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
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinsyu_ryaku_nm
		{
			get
			{
				return this._m1hinsyu_ryaku_nm;
			}
			set
			{
				this._m1hinsyu_ryaku_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm
		{
			get
			{
				return this._m1burando_nm;
			}
			set
			{
				this._m1burando_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jisya_hbn
		{
			get
			{
				return this._m1jisya_hbn;
			}
			set
			{
				this._m1jisya_hbn = value;
			}
		}

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値を取得または設定する。
		/// </summary>
		public virtual string M1maker_hbn
		{
			get
			{
				return this._m1maker_hbn;
			}
			set
			{
				this._m1maker_hbn = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONMK(商品名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonmk
		{
			get
			{
				return this._m1syonmk;
			}
			set
			{
				this._m1syonmk = value;
			}
		}

		/// <summary>
		/// 項目「M1IRO_NM(色)」の値を取得または設定する。
		/// </summary>
		public virtual string M1iro_nm
		{
			get
			{
				return this._m1iro_nm;
			}
			set
			{
				this._m1iro_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SIZE_NM(サイズ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1size_nm
		{
			get
			{
				return this._m1size_nm;
			}
			set
			{
				this._m1size_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SCAN_CD(スキャンコード)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scan_cd
		{
			get
			{
				return this._m1scan_cd;
			}
			set
			{
				this._m1scan_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKA_TNK(評価単価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyoka_tnk
		{
			get
			{
				return this._m1hyoka_tnk;
			}
			set
			{
				this._m1hyoka_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU(棚時帳簿数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajityobo_su
		{
			get
			{
				return this._m1tanajityobo_su;
			}
			set
			{
				this._m1tanajityobo_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajityobo_su_hdn
		{
			get
			{
				return this._m1tanajityobo_su_hdn;
			}
			set
			{
				this._m1tanajityobo_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU(棚時積送数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajisekiso_su
		{
			get
			{
				return this._m1tanajisekiso_su;
			}
			set
			{
				this._m1tanajisekiso_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajisekiso_su_hdn
		{
			get
			{
				return this._m1tanajisekiso_su_hdn;
			}
			set
			{
				this._m1tanajisekiso_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1JITANA_SU(実棚数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jitana_su
		{
			get
			{
				return this._m1jitana_su;
			}
			set
			{
				this._m1jitana_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JITANA_SU1_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1jitana_su1_hdn
		{
			get
			{
				return this._m1jitana_su1_hdn;
			}
			set
			{
				this._m1jitana_su1_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSS_SU(ロス数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1loss_su
		{
			get
			{
				return this._m1loss_su;
			}
			set
			{
				this._m1loss_su = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSS_KIN(ロス金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1loss_kin
		{
			get
			{
				return this._m1loss_kin;
			}
			set
			{
				this._m1loss_kin = value;
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
		public Tj190f02M1BaseForm()
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
			Tj190f02M1BaseForm compare = null;
			if (obj is Tj190f02M1BaseForm)
			{
				compare = (Tj190f02M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1burando_nm != compare.M1burando_nm)
			{
				return false;
			}
			if (_m1jisya_hbn != compare.M1jisya_hbn)
			{
				return false;
			}
			if (_m1maker_hbn != compare.M1maker_hbn)
			{
				return false;
			}
			if (_m1syonmk != compare.M1syonmk)
			{
				return false;
			}
			if (_m1iro_nm != compare.M1iro_nm)
			{
				return false;
			}
			if (_m1size_nm != compare.M1size_nm)
			{
				return false;
			}
			if (_m1scan_cd != compare.M1scan_cd)
			{
				return false;
			}
			if (_m1hyoka_tnk != compare.M1hyoka_tnk)
			{
				return false;
			}
			if (_m1tanajityobo_su != compare.M1tanajityobo_su)
			{
				return false;
			}
			if (_m1tanajityobo_su_hdn != compare.M1tanajityobo_su_hdn)
			{
				return false;
			}
			if (_m1tanajisekiso_su != compare.M1tanajisekiso_su)
			{
				return false;
			}
			if (_m1tanajisekiso_su_hdn != compare.M1tanajisekiso_su_hdn)
			{
				return false;
			}
			if (_m1jitana_su != compare.M1jitana_su)
			{
				return false;
			}
			if (_m1jitana_su1_hdn != compare.M1jitana_su1_hdn)
			{
				return false;
			}
			if (_m1loss_su != compare.M1loss_su)
			{
				return false;
			}
			if (_m1loss_kin != compare.M1loss_kin)
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
		/// <returns>現在のcom.xebio.bo.Tj190p01.Formvo.Tj190f02M1Formのハッシュ コード。</returns>
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
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1hyoka_tnk:").Append(this._m1hyoka_tnk).AppendLine();
			str.Append("M1tanajityobo_su:").Append(this._m1tanajityobo_su).AppendLine();
			str.Append("M1tanajityobo_su_hdn:").Append(this._m1tanajityobo_su_hdn).AppendLine();
			str.Append("M1tanajisekiso_su:").Append(this._m1tanajisekiso_su).AppendLine();
			str.Append("M1tanajisekiso_su_hdn:").Append(this._m1tanajisekiso_su_hdn).AppendLine();
			str.Append("M1jitana_su:").Append(this._m1jitana_su).AppendLine();
			str.Append("M1jitana_su1_hdn:").Append(this._m1jitana_su1_hdn).AppendLine();
			str.Append("M1loss_su:").Append(this._m1loss_su).AppendLine();
			str.Append("M1loss_kin:").Append(this._m1loss_kin).AppendLine();
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
			return "Tj190f02";
		}
		#endregion
		#endregion

	}
}
