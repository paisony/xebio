using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tk020p01.Formvo.Baseform
{
  /// <summary>
  /// Tk020f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk020f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMON_NM_HDN()」の値
		/// </summary>
		private string _m1bumon_nm_hdn;

		/// <summary>
		/// 項目「M1HINSYU_CD(品種)」の値
		/// </summary>
		private string _m1hinsyu_cd;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM_HDN()」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm_hdn;

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販完日)」の値
		/// </summary>
		private string _m1hanbaikanryo_ymd;

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _m1maker_hbn;

		/// <summary>
		/// 項目「M1SYONMK(商品名)」の値
		/// </summary>
		private string _m1syonmk;

		/// <summary>
		/// 項目「M1SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _m1scan_cd;

		/// <summary>
		/// 項目「M1IRO_NM(色)」の値
		/// </summary>
		private string _m1iro_nm;

		/// <summary>
		/// 項目「M1SIZE_NM(サイズ)」の値
		/// </summary>
		private string _m1size_nm;

		/// <summary>
		/// 項目「M1GENBAIKA_TNK(現売価)」の値
		/// </summary>
		private string _m1genbaika_tnk;

		/// <summary>
		/// 項目「M1HYOKASON_SU(数量)」の値
		/// </summary>
		private string _m1hyokason_su;

		/// <summary>
		/// 項目「M1GEN_TNK(原単価)」の値
		/// </summary>
		private string _m1gen_tnk;

		/// <summary>
		/// 項目「M1HAIBUN_KIN(原価金額)」の値
		/// </summary>
		private string _m1haibun_kin;

		/// <summary>
		/// 項目「M1NYURYOKU_YMD(入力日)」の値
		/// </summary>
		private string _m1nyuryoku_ymd;

		/// <summary>
		/// 項目「M1APPLY_YMD(申請日)」の値
		/// </summary>
		private string _m1apply_ymd;

		/// <summary>
		/// 項目「M1NYURYOKUSHA_CD(入力者)」の値
		/// </summary>
		private string _m1nyuryokusha_cd;

		/// <summary>
		/// 項目「M1SINSEISYA_CD(申請者)」の値
		/// </summary>
		private string _m1sinseisya_cd;

		/// <summary>
		/// 項目「M1HYOKASONSYUBETSU_KB(種別)」の値
		/// </summary>
		private string _m1hyokasonsyubetsu_kb;

		/// <summary>
		/// 項目「M1HYOKASONRIYU_KB(評価損理由)」の値
		/// </summary>
		private string _m1hyokasonriyu_kb;

		/// <summary>
		/// 項目「M1HYOKASONRIYU(評価損理由)」の値
		/// </summary>
		private string _m1hyokasonriyu;

		/// <summary>
		/// 項目「M1KYAKKARIYU(却下理由)」の値
		/// </summary>
		private string _m1kyakkariyu;

		/// <summary>
		/// 項目「M1TYOTATSU_NM(調達)」の値
		/// </summary>
		private string _m1tyotatsu_nm;

		/// <summary>
		/// 項目「M1SYONIN_NM(承認)」の値
		/// </summary>
		private string _m1syonin_nm;

		/// <summary>
		/// 項目「M1HYOKASON_SU_HDN()」の値
		/// </summary>
		private string _m1hyokason_su_hdn;

		/// <summary>
		/// 項目「M1HAIBUN_KIN_HDN()」の値
		/// </summary>
		private string _m1haibun_kin_hdn;

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
		/// 項目「M1BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_cd
		{
			get
			{
				return this._m1bumon_cd;
			}
			set
			{
				this._m1bumon_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON_NM_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_nm_hdn
		{
			get
			{
				return this._m1bumon_nm_hdn;
			}
			set
			{
				this._m1bumon_nm_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1HINSYU_CD(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinsyu_cd
		{
			get
			{
				return this._m1hinsyu_cd;
			}
			set
			{
				this._m1hinsyu_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinsyu_ryaku_nm_hdn
		{
			get
			{
				return this._m1hinsyu_ryaku_nm_hdn;
			}
			set
			{
				this._m1hinsyu_ryaku_nm_hdn = value;
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
		/// 項目「M1HANBAIKANRYO_YMD(販完日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaikanryo_ymd
		{
			get
			{
				return this._m1hanbaikanryo_ymd;
			}
			set
			{
				this._m1hanbaikanryo_ymd = value;
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
		/// 項目「M1GENBAIKA_TNK(現売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1genbaika_tnk
		{
			get
			{
				return this._m1genbaika_tnk;
			}
			set
			{
				this._m1genbaika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASON_SU(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokason_su
		{
			get
			{
				return this._m1hyokason_su;
			}
			set
			{
				this._m1hyokason_su = value;
			}
		}

		/// <summary>
		/// 項目「M1GEN_TNK(原単価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1gen_tnk
		{
			get
			{
				return this._m1gen_tnk;
			}
			set
			{
				this._m1gen_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1HAIBUN_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1haibun_kin
		{
			get
			{
				return this._m1haibun_kin;
			}
			set
			{
				this._m1haibun_kin = value;
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
		/// 項目「M1NYURYOKUSHA_CD(入力者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyuryokusha_cd
		{
			get
			{
				return this._m1nyuryokusha_cd;
			}
			set
			{
				this._m1nyuryokusha_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEISYA_CD(申請者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinseisya_cd
		{
			get
			{
				return this._m1sinseisya_cd;
			}
			set
			{
				this._m1sinseisya_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASONSYUBETSU_KB(種別)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokasonsyubetsu_kb
		{
			get
			{
				return this._m1hyokasonsyubetsu_kb;
			}
			set
			{
				this._m1hyokasonsyubetsu_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASONRIYU_KB(評価損理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokasonriyu_kb
		{
			get
			{
				return this._m1hyokasonriyu_kb;
			}
			set
			{
				this._m1hyokasonriyu_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASONRIYU(評価損理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokasonriyu
		{
			get
			{
				return this._m1hyokasonriyu;
			}
			set
			{
				this._m1hyokasonriyu = value;
			}
		}

		/// <summary>
		/// 項目「M1KYAKKARIYU(却下理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kyakkariyu
		{
			get
			{
				return this._m1kyakkariyu;
			}
			set
			{
				this._m1kyakkariyu = value;
			}
		}

		/// <summary>
		/// 項目「M1TYOTATSU_NM(調達)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tyotatsu_nm
		{
			get
			{
				return this._m1tyotatsu_nm;
			}
			set
			{
				this._m1tyotatsu_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONIN_NM(承認)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonin_nm
		{
			get
			{
				return this._m1syonin_nm;
			}
			set
			{
				this._m1syonin_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASON_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokason_su_hdn
		{
			get
			{
				return this._m1hyokason_su_hdn;
			}
			set
			{
				this._m1hyokason_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1HAIBUN_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1haibun_kin_hdn
		{
			get
			{
				return this._m1haibun_kin_hdn;
			}
			set
			{
				this._m1haibun_kin_hdn = value;
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
		public Tk020f01M1BaseForm()
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
			Tk020f01M1BaseForm compare = null;
			if (obj is Tk020f01M1BaseForm)
			{
				compare = (Tk020f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumon_cd != compare.M1bumon_cd)
			{
				return false;
			}
			if (_m1bumon_nm_hdn != compare.M1bumon_nm_hdn)
			{
				return false;
			}
			if (_m1hinsyu_cd != compare.M1hinsyu_cd)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm_hdn != compare.M1hinsyu_ryaku_nm_hdn)
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
			if (_m1hanbaikanryo_ymd != compare.M1hanbaikanryo_ymd)
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
			if (_m1scan_cd != compare.M1scan_cd)
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
			if (_m1genbaika_tnk != compare.M1genbaika_tnk)
			{
				return false;
			}
			if (_m1hyokason_su != compare.M1hyokason_su)
			{
				return false;
			}
			if (_m1gen_tnk != compare.M1gen_tnk)
			{
				return false;
			}
			if (_m1haibun_kin != compare.M1haibun_kin)
			{
				return false;
			}
			if (_m1nyuryoku_ymd != compare.M1nyuryoku_ymd)
			{
				return false;
			}
			if (_m1apply_ymd != compare.M1apply_ymd)
			{
				return false;
			}
			if (_m1nyuryokusha_cd != compare.M1nyuryokusha_cd)
			{
				return false;
			}
			if (_m1sinseisya_cd != compare.M1sinseisya_cd)
			{
				return false;
			}
			if (_m1hyokasonsyubetsu_kb != compare.M1hyokasonsyubetsu_kb)
			{
				return false;
			}
			if (_m1hyokasonriyu_kb != compare.M1hyokasonriyu_kb)
			{
				return false;
			}
			if (_m1hyokasonriyu != compare.M1hyokasonriyu)
			{
				return false;
			}
			if (_m1kyakkariyu != compare.M1kyakkariyu)
			{
				return false;
			}
			if (_m1tyotatsu_nm != compare.M1tyotatsu_nm)
			{
				return false;
			}
			if (_m1syonin_nm != compare.M1syonin_nm)
			{
				return false;
			}
			if (_m1hyokason_su_hdn != compare.M1hyokason_su_hdn)
			{
				return false;
			}
			if (_m1haibun_kin_hdn != compare.M1haibun_kin_hdn)
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
		/// <returns>現在のcom.xebio.bo.Tk020p01.Formvo.Tk020f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumon_nm_hdn:").Append(this._m1bumon_nm_hdn).AppendLine();
			str.Append("M1hinsyu_cd:").Append(this._m1hinsyu_cd).AppendLine();
			str.Append("M1hinsyu_ryaku_nm_hdn:").Append(this._m1hinsyu_ryaku_nm_hdn).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1hanbaikanryo_ymd:").Append(this._m1hanbaikanryo_ymd).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1genbaika_tnk:").Append(this._m1genbaika_tnk).AppendLine();
			str.Append("M1hyokason_su:").Append(this._m1hyokason_su).AppendLine();
			str.Append("M1gen_tnk:").Append(this._m1gen_tnk).AppendLine();
			str.Append("M1haibun_kin:").Append(this._m1haibun_kin).AppendLine();
			str.Append("M1nyuryoku_ymd:").Append(this._m1nyuryoku_ymd).AppendLine();
			str.Append("M1apply_ymd:").Append(this._m1apply_ymd).AppendLine();
			str.Append("M1nyuryokusha_cd:").Append(this._m1nyuryokusha_cd).AppendLine();
			str.Append("M1sinseisya_cd:").Append(this._m1sinseisya_cd).AppendLine();
			str.Append("M1hyokasonsyubetsu_kb:").Append(this._m1hyokasonsyubetsu_kb).AppendLine();
			str.Append("M1hyokasonriyu_kb:").Append(this._m1hyokasonriyu_kb).AppendLine();
			str.Append("M1hyokasonriyu:").Append(this._m1hyokasonriyu).AppendLine();
			str.Append("M1kyakkariyu:").Append(this._m1kyakkariyu).AppendLine();
			str.Append("M1tyotatsu_nm:").Append(this._m1tyotatsu_nm).AppendLine();
			str.Append("M1syonin_nm:").Append(this._m1syonin_nm).AppendLine();
			str.Append("M1hyokason_su_hdn:").Append(this._m1hyokason_su_hdn).AppendLine();
			str.Append("M1haibun_kin_hdn:").Append(this._m1haibun_kin_hdn).AppendLine();
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
			return "Tk020f01";
		}
		#endregion
		#endregion

	}
}
