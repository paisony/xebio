using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf070p01.VO
{
  /// <summary>
  /// Tf070f02 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tf070f02M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1HASSEI_TM(時間)」の値
		/// </summary>
		private string _m1hassei_tm;

		/// <summary>
		/// 項目「M1HASSEIBASYO(発生場所)」の値
		/// </summary>
		private string _m1hasseibasyo;

		/// <summary>
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1HAKKENTAN_CD(発見者)」の値
		/// </summary>
		private string _m1hakkentan_cd;


		/// <summary>
		/// 項目「M1HAKKENTAN_NM()」の値
		/// </summary>
		private string _m1hakkentan_nm;

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1HAKKENJYOKYO_KB(発見状況)」の値
		/// </summary>
		private string _m1hakkenjyokyo_kb;

		/// <summary>
		/// 項目「M1HAKKENJYOKYO_NM(発見状況)」の値
		/// </summary>
		private string _m1hakkenjyokyo_nm;

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
		/// 項目「M1SINSEI_SU(申請数)」の値
		/// </summary>
		private string _m1sinsei_su;

		/// <summary>
		/// 項目「M1JYURI_SU(受理数)」の値
		/// </summary>
		private string _m1jyuri_su;

		/// <summary>
		/// 項目「M1BAIKA_HON(売価)」の値
		/// </summary>
		private string _m1baika_hon;

		/// <summary>
		/// 項目「M1BAIKA_KIN(売価金額)」の値
		/// </summary>
		private string _m1baika_kin;

		/// <summary>
		/// 項目「M1SINSEI_SU_HDN()」の値
		/// </summary>
		private string _m1sinsei_su_hdn;

		/// <summary>
		/// 項目「M1JYURI_SU_HDN()」の値
		/// </summary>
		private string _m1jyuri_su_hdn;

		/// <summary>
		/// 項目「M1BAIKA_KIN_HDN()」の値
		/// </summary>
		private string _m1baika_kin_hdn;

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
		/// 項目「M1HASSEI_TM(時間)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hassei_tm
		{
			get
			{
				return this._m1hassei_tm;
			}
			set
			{
				this._m1hassei_tm = value;
			}
		}

		/// <summary>
		/// 項目「M1HASSEIBASYO(発生場所)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hasseibasyo
		{
			get
			{
				return this._m1hasseibasyo;
			}
			set
			{
				this._m1hasseibasyo = value;
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
		/// 項目「M1BUMONKANA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumonkana_nm
		{
			get
			{
				return this._m1bumonkana_nm;
			}
			set
			{
				this._m1bumonkana_nm = value;
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
		/// 項目「M1HAKKENTAN_CD(発見者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hakkentan_cd
		{
			get
			{
				return this._m1hakkentan_cd;
			}
			set
			{
				this._m1hakkentan_cd = value;
			}
		}


		/// <summary>
		/// 項目「M1HAKKENTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hakkentan_nm
		{
			get
			{
				return this._m1hakkentan_nm;
			}
			set
			{
				this._m1hakkentan_nm = value;
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
		/// 項目「M1HAKKENJYOKYO_KB(発見状況)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hakkenjyokyo_kb
		{
			get
			{
				return this._m1hakkenjyokyo_kb;
			}
			set
			{
				this._m1hakkenjyokyo_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1HAKKENJYOKYO_NM(発見状況)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hakkenjyokyo_nm
		{
			get
			{
				return this._m1hakkenjyokyo_nm;
			}
			set
			{
				this._m1hakkenjyokyo_nm = value;
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
		/// 項目「M1SINSEI_SU(申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_su
		{
			get
			{
				return this._m1sinsei_su;
			}
			set
			{
				this._m1sinsei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURI_SU(受理数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuri_su
		{
			get
			{
				return this._m1jyuri_su;
			}
			set
			{
				this._m1jyuri_su = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIKA_HON(売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baika_hon
		{
			get
			{
				return this._m1baika_hon;
			}
			set
			{
				this._m1baika_hon = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIKA_KIN(売価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baika_kin
		{
			get
			{
				return this._m1baika_kin;
			}
			set
			{
				this._m1baika_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEI_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_su_hdn
		{
			get
			{
				return this._m1sinsei_su_hdn;
			}
			set
			{
				this._m1sinsei_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURI_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuri_su_hdn
		{
			get
			{
				return this._m1jyuri_su_hdn;
			}
			set
			{
				this._m1jyuri_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIKA_KIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1baika_kin_hdn
		{
			get
			{
				return this._m1baika_kin_hdn;
			}
			set
			{
				this._m1baika_kin_hdn = value;
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
		public Tf070f02M1ResultVO() : base()
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
			Tf070f02M1ResultVO compare = null;
			if (obj is Tf070f02M1ResultVO)
			{
				compare = (Tf070f02M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1hassei_tm != compare.M1hassei_tm)
			{
				return false;
			}
			if (_m1hasseibasyo != compare.M1hasseibasyo)
			{
				return false;
			}
			if (_m1bumon_cd != compare.M1bumon_cd)
			{
				return false;
			}
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1hakkentan_cd != compare.M1hakkentan_cd)
			{
				return false;
			}
			if (_m1hakkentan_nm != compare.M1hakkentan_nm)
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
			if (_m1hakkenjyokyo_kb != compare.M1hakkenjyokyo_kb)
			{
				return false;
			}
			if (_m1hakkenjyokyo_nm != compare.M1hakkenjyokyo_nm)
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
			if (_m1sinsei_su != compare.M1sinsei_su)
			{
				return false;
			}
			if (_m1jyuri_su != compare.M1jyuri_su)
			{
				return false;
			}
			if (_m1baika_hon != compare.M1baika_hon)
			{
				return false;
			}
			if (_m1baika_kin != compare.M1baika_kin)
			{
				return false;
			}
			if (_m1sinsei_su_hdn != compare.M1sinsei_su_hdn)
			{
				return false;
			}
			if (_m1jyuri_su_hdn != compare.M1jyuri_su_hdn)
			{
				return false;
			}
			if (_m1baika_kin_hdn != compare.M1baika_kin_hdn)
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
		/// <returns>現在のcom.xebio.bo.Tf070p01.Formvo.Tf070f02M1Formのハッシュ コード。</returns>
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

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1hassei_tm:").Append(this._m1hassei_tm).AppendLine();
			str.Append("M1hasseibasyo:").Append(this._m1hasseibasyo).AppendLine();
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1hakkentan_cd:").Append(this._m1hakkentan_cd).AppendLine();
			str.Append("M1hakkentan_nm:").Append(this._m1hakkentan_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1hakkenjyokyo_kb:").Append(this._m1hakkenjyokyo_kb).AppendLine();
			str.Append("M1hakkenjyokyo_nm:").Append(this._m1hakkenjyokyo_nm).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1sinsei_su:").Append(this._m1sinsei_su).AppendLine();
			str.Append("M1jyuri_su:").Append(this._m1jyuri_su).AppendLine();
			str.Append("M1baika_hon:").Append(this._m1baika_hon).AppendLine();
			str.Append("M1baika_kin:").Append(this._m1baika_kin).AppendLine();
			str.Append("M1sinsei_su_hdn:").Append(this._m1sinsei_su_hdn).AppendLine();
			str.Append("M1jyuri_su_hdn:").Append(this._m1jyuri_su_hdn).AppendLine();
			str.Append("M1baika_kin_hdn:").Append(this._m1baika_kin_hdn).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
