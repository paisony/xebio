using System;

namespace com.xebio.bo.Ta080p01.Util
{
  /// <summary>
  /// Ta080f03 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class BackDetailVO
	{
		
		#region フィールド
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

		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「M1BUMONKANA_NM(部門)」の値を取得または設定する。
		/// </summary>
		public string M1bumonkana_nm
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
		public string M1ten_hyoka_kb
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
		public string M1all_hyoka_kb
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
		public string M1tosyu_uriage_su
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
		public string M1hinsyu_ryaku_nm
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
		public string M1zensyu_uriage_su
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
		public string M1zenzensyu_uriage_su
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
		public string M1burando_nm
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
		public string M1nyukayotei_su
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
		public string M1tenzaiko_su
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
		public string M1jido_su
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
		public string M1haibunkano_su
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
		public string M1jisya_hbn
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
		public string M1keikaku_ymd
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
		public string M1syohin_zokusei
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
		public string M1lot_su
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
		public string M1maker_hbn
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
		public string M1syonmk
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
		public string M1iro_nm
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
		public string M1size_nm
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
		public string M1scan_cd
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
		public string M1irai_su
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
		public string M1hatchu_msg
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
		public string M1genkakin
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
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値を取得または設定する。
		/// </summary>
		public string M1hanbaikanryo_ymd
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
		public string M1uriage_su_hdn
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
		public string M1irai_su_hdn
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
		public string M1irairiyu_cd_hdn1
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
		public string M1irairiyu_cd_hdn2
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
		public string M1gen_tnk
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
		public string M1genkakin_hdn
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

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public BackDetailVO()
		{
		}
		#endregion

		#region メソッド

		#endregion

	}
}
