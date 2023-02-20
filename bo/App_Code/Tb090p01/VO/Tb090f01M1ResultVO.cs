using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tb090p01.VO
{
  /// <summary>
  /// Tb090f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tb090f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1BUMON_CD_BO(部門)」の値
		/// </summary>
		private string _m1bumon_cd_bo;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _m1siiresaki_cd;

		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _m1siiresaki_ryaku_nm;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _m1nyukayotei_ymd;


		/// <summary>
		/// 項目「M1AKA_DENPYO_BANGO(赤伝)」の値
		/// </summary>
		private string _m1aka_denpyo_bango;

		/// <summary>
		/// 項目「M1KURO_DENPYO_BANGO(黒伝)」の値
		/// </summary>
		private string _m1kuro_denpyo_bango;

		/// <summary>
		/// 項目「M1KENSU(検数)」の値
		/// </summary>
		private string _m1kensu;

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数)」の値
		/// </summary>
		private string _m1teisei_suryo;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1SIIRE_KAKUTEI_YMD(仕入確定日)」の値
		/// </summary>
		private string _m1siire_kakutei_ymd;

		/// <summary>
		/// 項目「M1KAKUTEITAN_NM(確定担当者)」の値
		/// </summary>
		private string _m1kakuteitan_nm;

		/// <summary>
		/// 項目「M1KAKUTEI_SB_NM(確定種別)」の値
		/// </summary>
		private string _m1kakutei_sb_nm;

		/// <summary>
		/// 項目「M1KYAKUCYU(客注)」の値
		/// </summary>
		private string _m1kyakucyu;

		/// <summary>
		/// 項目「M1NEGAKI(値書)」の値
		/// </summary>
		private string _m1negaki;

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
		/// 項目「M1BUMON_CD_BO(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_cd_bo
		{
			get
			{
				return this._m1bumon_cd_bo;
			}
			set
			{
				this._m1bumon_cd_bo = value;
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
		/// 項目「M1SIIRESAKI_CD(仕入先)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siiresaki_cd
		{
			get
			{
				return this._m1siiresaki_cd;
			}
			set
			{
				this._m1siiresaki_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1siiresaki_ryaku_nm
		{
			get
			{
				return this._m1siiresaki_ryaku_nm;
			}
			set
			{
				this._m1siiresaki_ryaku_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukayotei_ymd
		{
			get
			{
				return this._m1nyukayotei_ymd;
			}
			set
			{
				this._m1nyukayotei_ymd = value;
			}
		}


		/// <summary>
		/// 項目「M1AKA_DENPYO_BANGO(赤伝)」の値を取得または設定する。
		/// </summary>
		public virtual string M1aka_denpyo_bango
		{
			get
			{
				return this._m1aka_denpyo_bango;
			}
			set
			{
				this._m1aka_denpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1KURO_DENPYO_BANGO(黒伝)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kuro_denpyo_bango
		{
			get
			{
				return this._m1kuro_denpyo_bango;
			}
			set
			{
				this._m1kuro_denpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1KENSU(検数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kensu
		{
			get
			{
				return this._m1kensu;
			}
			set
			{
				this._m1kensu = value;
			}
		}

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数)」の値を取得または設定する。
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
		/// 項目「M1SIIRE_KAKUTEI_YMD(仕入確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siire_kakutei_ymd
		{
			get
			{
				return this._m1siire_kakutei_ymd;
			}
			set
			{
				this._m1siire_kakutei_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1KAKUTEITAN_NM(確定担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kakuteitan_nm
		{
			get
			{
				return this._m1kakuteitan_nm;
			}
			set
			{
				this._m1kakuteitan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1KAKUTEI_SB_NM(確定種別)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kakutei_sb_nm
		{
			get
			{
				return this._m1kakutei_sb_nm;
			}
			set
			{
				this._m1kakutei_sb_nm = value;
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
		public Tb090f01M1ResultVO() : base()
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
			Tb090f01M1ResultVO compare = null;
			if (obj is Tb090f01M1ResultVO)
			{
				compare = (Tb090f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumon_cd_bo != compare.M1bumon_cd_bo)
			{
				return false;
			}
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
			{
				return false;
			}
			if (_m1siiresaki_cd != compare.M1siiresaki_cd)
			{
				return false;
			}
			if (_m1siiresaki_ryaku_nm != compare.M1siiresaki_ryaku_nm)
			{
				return false;
			}
			if (_m1nyukayotei_ymd != compare.M1nyukayotei_ymd)
			{
				return false;
			}
			if (_m1aka_denpyo_bango != compare.M1aka_denpyo_bango)
			{
				return false;
			}
			if (_m1kuro_denpyo_bango != compare.M1kuro_denpyo_bango)
			{
				return false;
			}
			if (_m1kensu != compare.M1kensu)
			{
				return false;
			}
			if (_m1teisei_suryo != compare.M1teisei_suryo)
			{
				return false;
			}
			if (_m1genkakin != compare.M1genkakin)
			{
				return false;
			}
			if (_m1siire_kakutei_ymd != compare.M1siire_kakutei_ymd)
			{
				return false;
			}
			if (_m1kakuteitan_nm != compare.M1kakuteitan_nm)
			{
				return false;
			}
			if (_m1kakutei_sb_nm != compare.M1kakutei_sb_nm)
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
		/// <returns>現在のcom.xebio.bo.Tb090p01.Formvo.Tb090f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd_bo:").Append(this._m1bumon_cd_bo).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1nyukayotei_ymd:").Append(this._m1nyukayotei_ymd).AppendLine();
			str.Append("M1aka_denpyo_bango:").Append(this._m1aka_denpyo_bango).AppendLine();
			str.Append("M1kuro_denpyo_bango:").Append(this._m1kuro_denpyo_bango).AppendLine();
			str.Append("M1kensu:").Append(this._m1kensu).AppendLine();
			str.Append("M1teisei_suryo:").Append(this._m1teisei_suryo).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1siire_kakutei_ymd:").Append(this._m1siire_kakutei_ymd).AppendLine();
			str.Append("M1kakuteitan_nm:").Append(this._m1kakuteitan_nm).AppendLine();
			str.Append("M1kakutei_sb_nm:").Append(this._m1kakutei_sb_nm).AppendLine();
			str.Append("M1kyakucyu:").Append(this._m1kyakucyu).AppendLine();
			str.Append("M1negaki:").Append(this._m1negaki).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
