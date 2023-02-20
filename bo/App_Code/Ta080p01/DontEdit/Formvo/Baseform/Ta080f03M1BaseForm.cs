using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta080p01.Formvo.Baseform
{
  /// <summary>
  /// Ta080f03 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f03M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1BUMONKANA_NM(部門)」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1TEN_HYOKA_KB(店評価)」の値
		/// </summary>
		private string _m1ten_hyoka_kb;

		/// <summary>
		/// 項目「M1ALL_HYOKA_KB(全評価)」の値
		/// </summary>
		private string _m1all_hyoka_kb;

		/// <summary>
		/// 項目「M1TOSYU_URIAGE_SU(当週売)」の値
		/// </summary>
		private string _m1tosyu_uriage_su;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1ZENSYU_URIAGE_SU(前売)」の値
		/// </summary>
		private string _m1zensyu_uriage_su;

		/// <summary>
		/// 項目「M1ZENZENSYU_URIAGE_SU(前々売)」の値
		/// </summary>
		private string _m1zenzensyu_uriage_su;

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_SU(入荷)」の値
		/// </summary>
		private string _m1nyukayotei_su;

		/// <summary>
		/// 項目「M1TENZAIKO_SU(在庫)」の値
		/// </summary>
		private string _m1tenzaiko_su;

		/// <summary>
		/// 項目「M1JIDO_SU(自動定数)」の値
		/// </summary>
		private string _m1jido_su;

		/// <summary>
		/// 項目「M1HAIBUNKANO_SU(配可数)」の値
		/// </summary>
		private string _m1haibunkano_su;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1KEIKAKU_YMD(計画期間)」の値
		/// </summary>
		private string _m1keikaku_ymd;

		/// <summary>
		/// 項目「M1SYOHIN_ZOKUSEI(コア)」の値
		/// </summary>
		private string _m1syohin_zokusei;

		/// <summary>
		/// 項目「M1LOT_SU(ﾛｯﾄ)」の値
		/// </summary>
		private string _m1lot_su;

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
		/// 項目「M1IRAI_SU(依頼数)」の値
		/// </summary>
		private string _m1irai_su;

		/// <summary>
		/// 項目「M1HATCHU_MSG(メッセージ)」の値
		/// </summary>
		private string _m1hatchu_msg;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1HANBAIIN_NM(登録担当者)」の値
		/// </summary>
		private string _m1hanbaiin_nm;

		/// <summary>
		/// 項目「M1IRAIRIYU_CD1(依頼理由)」の値
		/// </summary>
		private string _m1irairiyu_cd1;

		/// <summary>
		/// 項目「M1IRAIRIYU_CD2()」の値
		/// </summary>
		private string _m1irairiyu_cd2;

		/// <summary>
		/// 項目「M1ADD_YMD(登録日)」の値
		/// </summary>
		private string _m1add_ymd;

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値
		/// </summary>
		private string _m1hanbaikanryo_ymd;

		/// <summary>
		/// 項目「M1URIAGE_SU_HDN()」の値
		/// </summary>
		private string _m1uriage_su_hdn;

		/// <summary>
		/// 項目「M1IRAI_SU_HDN()」の値
		/// </summary>
		private string _m1irai_su_hdn;

		/// <summary>
		/// 項目「M1IRAIRIYU_CD_HDN1()」の値
		/// </summary>
		private string _m1irairiyu_cd_hdn1;

		/// <summary>
		/// 項目「M1IRAIRIYU_CD_HDN2()」の値
		/// </summary>
		private string _m1irairiyu_cd_hdn2;

		/// <summary>
		/// 項目「M1GEN_TNK()」の値
		/// </summary>
		private string _m1gen_tnk;

		/// <summary>
		/// 項目「M1GENKAKIN_HDN()」の値
		/// </summary>
		private string _m1genkakin_hdn;

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
		/// 項目「M1BUMONKANA_NM(部門)」の値を取得または設定する。
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
		/// 項目「M1TEN_HYOKA_KB(店評価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1ten_hyoka_kb
		{
			get
			{
				return this._m1ten_hyoka_kb;
			}
			set
			{
				this._m1ten_hyoka_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1ALL_HYOKA_KB(全評価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1all_hyoka_kb
		{
			get
			{
				return this._m1all_hyoka_kb;
			}
			set
			{
				this._m1all_hyoka_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1TOSYU_URIAGE_SU(当週売)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tosyu_uriage_su
		{
			get
			{
				return this._m1tosyu_uriage_su;
			}
			set
			{
				this._m1tosyu_uriage_su = value;
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
		/// 項目「M1ZENSYU_URIAGE_SU(前売)」の値を取得または設定する。
		/// </summary>
		public virtual string M1zensyu_uriage_su
		{
			get
			{
				return this._m1zensyu_uriage_su;
			}
			set
			{
				this._m1zensyu_uriage_su = value;
			}
		}

		/// <summary>
		/// 項目「M1ZENZENSYU_URIAGE_SU(前々売)」の値を取得または設定する。
		/// </summary>
		public virtual string M1zenzensyu_uriage_su
		{
			get
			{
				return this._m1zenzensyu_uriage_su;
			}
			set
			{
				this._m1zenzensyu_uriage_su = value;
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
		/// 項目「M1NYUKAYOTEI_SU(入荷)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukayotei_su
		{
			get
			{
				return this._m1nyukayotei_su;
			}
			set
			{
				this._m1nyukayotei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TENZAIKO_SU(在庫)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenzaiko_su
		{
			get
			{
				return this._m1tenzaiko_su;
			}
			set
			{
				this._m1tenzaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JIDO_SU(自動定数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jido_su
		{
			get
			{
				return this._m1jido_su;
			}
			set
			{
				this._m1jido_su = value;
			}
		}

		/// <summary>
		/// 項目「M1HAIBUNKANO_SU(配可数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1haibunkano_su
		{
			get
			{
				return this._m1haibunkano_su;
			}
			set
			{
				this._m1haibunkano_su = value;
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
		/// 項目「M1KEIKAKU_YMD(計画期間)」の値を取得または設定する。
		/// </summary>
		public virtual string M1keikaku_ymd
		{
			get
			{
				return this._m1keikaku_ymd;
			}
			set
			{
				this._m1keikaku_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYOHIN_ZOKUSEI(コア)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syohin_zokusei
		{
			get
			{
				return this._m1syohin_zokusei;
			}
			set
			{
				this._m1syohin_zokusei = value;
			}
		}

		/// <summary>
		/// 項目「M1LOT_SU(ﾛｯﾄ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1lot_su
		{
			get
			{
				return this._m1lot_su;
			}
			set
			{
				this._m1lot_su = value;
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
		/// 項目「M1IRAI_SU(依頼数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1irai_su
		{
			get
			{
				return this._m1irai_su;
			}
			set
			{
				this._m1irai_su = value;
			}
		}

		/// <summary>
		/// 項目「M1HATCHU_MSG(メッセージ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hatchu_msg
		{
			get
			{
				return this._m1hatchu_msg;
			}
			set
			{
				this._m1hatchu_msg = value;
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
		/// 項目「M1HANBAIIN_NM(登録担当者)」の値を取得または設定する。
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
		/// 項目「M1IRAIRIYU_CD1(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1irairiyu_cd1
		{
			get
			{
				return this._m1irairiyu_cd1;
			}
			set
			{
				this._m1irairiyu_cd1 = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAIRIYU_CD2()」の値を取得または設定する。
		/// </summary>
		public virtual string M1irairiyu_cd2
		{
			get
			{
				return this._m1irairiyu_cd2;
			}
			set
			{
				this._m1irairiyu_cd2 = value;
			}
		}

		/// <summary>
		/// 項目「M1ADD_YMD(登録日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1add_ymd
		{
			get
			{
				return this._m1add_ymd;
			}
			set
			{
				this._m1add_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値を取得または設定する。
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
		/// 項目「M1URIAGE_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1uriage_su_hdn
		{
			get
			{
				return this._m1uriage_su_hdn;
			}
			set
			{
				this._m1uriage_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAI_SU_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1irai_su_hdn
		{
			get
			{
				return this._m1irai_su_hdn;
			}
			set
			{
				this._m1irai_su_hdn = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAIRIYU_CD_HDN1()」の値を取得または設定する。
		/// </summary>
		public virtual string M1irairiyu_cd_hdn1
		{
			get
			{
				return this._m1irairiyu_cd_hdn1;
			}
			set
			{
				this._m1irairiyu_cd_hdn1 = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAIRIYU_CD_HDN2()」の値を取得または設定する。
		/// </summary>
		public virtual string M1irairiyu_cd_hdn2
		{
			get
			{
				return this._m1irairiyu_cd_hdn2;
			}
			set
			{
				this._m1irairiyu_cd_hdn2 = value;
			}
		}

		/// <summary>
		/// 項目「M1GEN_TNK()」の値を取得または設定する。
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
		/// 項目「M1GENKAKIN_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1genkakin_hdn
		{
			get
			{
				return this._m1genkakin_hdn;
			}
			set
			{
				this._m1genkakin_hdn = value;
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
		public Ta080f03M1BaseForm()
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
			Ta080f03M1BaseForm compare = null;
			if (obj is Ta080f03M1BaseForm)
			{
				compare = (Ta080f03M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
			{
				return false;
			}
			if (_m1ten_hyoka_kb != compare.M1ten_hyoka_kb)
			{
				return false;
			}
			if (_m1all_hyoka_kb != compare.M1all_hyoka_kb)
			{
				return false;
			}
			if (_m1tosyu_uriage_su != compare.M1tosyu_uriage_su)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1zensyu_uriage_su != compare.M1zensyu_uriage_su)
			{
				return false;
			}
			if (_m1zenzensyu_uriage_su != compare.M1zenzensyu_uriage_su)
			{
				return false;
			}
			if (_m1burando_nm != compare.M1burando_nm)
			{
				return false;
			}
			if (_m1nyukayotei_su != compare.M1nyukayotei_su)
			{
				return false;
			}
			if (_m1tenzaiko_su != compare.M1tenzaiko_su)
			{
				return false;
			}
			if (_m1jido_su != compare.M1jido_su)
			{
				return false;
			}
			if (_m1haibunkano_su != compare.M1haibunkano_su)
			{
				return false;
			}
			if (_m1jisya_hbn != compare.M1jisya_hbn)
			{
				return false;
			}
			if (_m1keikaku_ymd != compare.M1keikaku_ymd)
			{
				return false;
			}
			if (_m1syohin_zokusei != compare.M1syohin_zokusei)
			{
				return false;
			}
			if (_m1lot_su != compare.M1lot_su)
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
			if (_m1irai_su != compare.M1irai_su)
			{
				return false;
			}
			if (_m1hatchu_msg != compare.M1hatchu_msg)
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
			if (_m1irairiyu_cd1 != compare.M1irairiyu_cd1)
			{
				return false;
			}
			if (_m1irairiyu_cd2 != compare.M1irairiyu_cd2)
			{
				return false;
			}
			if (_m1add_ymd != compare.M1add_ymd)
			{
				return false;
			}
			if (_m1hanbaikanryo_ymd != compare.M1hanbaikanryo_ymd)
			{
				return false;
			}
			if (_m1uriage_su_hdn != compare.M1uriage_su_hdn)
			{
				return false;
			}
			if (_m1irai_su_hdn != compare.M1irai_su_hdn)
			{
				return false;
			}
			if (_m1irairiyu_cd_hdn1 != compare.M1irairiyu_cd_hdn1)
			{
				return false;
			}
			if (_m1irairiyu_cd_hdn2 != compare.M1irairiyu_cd_hdn2)
			{
				return false;
			}
			if (_m1gen_tnk != compare.M1gen_tnk)
			{
				return false;
			}
			if (_m1genkakin_hdn != compare.M1genkakin_hdn)
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
		/// <returns>現在のcom.xebio.bo.Ta080p01.Formvo.Ta080f03M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1ten_hyoka_kb:").Append(this._m1ten_hyoka_kb).AppendLine();
			str.Append("M1all_hyoka_kb:").Append(this._m1all_hyoka_kb).AppendLine();
			str.Append("M1tosyu_uriage_su:").Append(this._m1tosyu_uriage_su).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1zensyu_uriage_su:").Append(this._m1zensyu_uriage_su).AppendLine();
			str.Append("M1zenzensyu_uriage_su:").Append(this._m1zenzensyu_uriage_su).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1nyukayotei_su:").Append(this._m1nyukayotei_su).AppendLine();
			str.Append("M1tenzaiko_su:").Append(this._m1tenzaiko_su).AppendLine();
			str.Append("M1jido_su:").Append(this._m1jido_su).AppendLine();
			str.Append("M1haibunkano_su:").Append(this._m1haibunkano_su).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1keikaku_ymd:").Append(this._m1keikaku_ymd).AppendLine();
			str.Append("M1syohin_zokusei:").Append(this._m1syohin_zokusei).AppendLine();
			str.Append("M1lot_su:").Append(this._m1lot_su).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1irai_su:").Append(this._m1irai_su).AppendLine();
			str.Append("M1hatchu_msg:").Append(this._m1hatchu_msg).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1hanbaiin_nm:").Append(this._m1hanbaiin_nm).AppendLine();
			str.Append("M1irairiyu_cd1:").Append(this._m1irairiyu_cd1).AppendLine();
			str.Append("M1irairiyu_cd2:").Append(this._m1irairiyu_cd2).AppendLine();
			str.Append("M1add_ymd:").Append(this._m1add_ymd).AppendLine();
			str.Append("M1hanbaikanryo_ymd:").Append(this._m1hanbaikanryo_ymd).AppendLine();
			str.Append("M1uriage_su_hdn:").Append(this._m1uriage_su_hdn).AppendLine();
			str.Append("M1irai_su_hdn:").Append(this._m1irai_su_hdn).AppendLine();
			str.Append("M1irairiyu_cd_hdn1:").Append(this._m1irairiyu_cd_hdn1).AppendLine();
			str.Append("M1irairiyu_cd_hdn2:").Append(this._m1irairiyu_cd_hdn2).AppendLine();
			str.Append("M1gen_tnk:").Append(this._m1gen_tnk).AppendLine();
			str.Append("M1genkakin_hdn:").Append(this._m1genkakin_hdn).AppendLine();
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
			return "Ta080f03";
		}
		#endregion
		#endregion

	}
}
