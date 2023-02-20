using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tb040p01.VO
{
  /// <summary>
  /// Tb040f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tb040f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _m1siiresaki_cd;


		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _m1siiresaki_ryaku_nm;

		/// <summary>
		/// 項目「M1DENPYO_BARCODE(伝票番号)」の値
		/// </summary>
		private string _m1denpyo_barcode;

		/// <summary>
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _m1nyukayotei_ymd;

		/// <summary>
		/// 項目「M1NOHIN_SU(納品数)」の値
		/// </summary>
		private string _m1nohin_su;

		/// <summary>
		/// 項目「M1GENKA_KIN(原価金額)」の値
		/// </summary>
		private string _m1genka_kin;

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
		/// 項目「M1DENPYO_BARCODE(伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1denpyo_barcode
		{
			get
			{
				return this._m1denpyo_barcode;
			}
			set
			{
				this._m1denpyo_barcode = value;
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
		/// 項目「M1NOHIN_SU(納品数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nohin_su
		{
			get
			{
				return this._m1nohin_su;
			}
			set
			{
				this._m1nohin_su = value;
			}
		}

		/// <summary>
		/// 項目「M1GENKA_KIN(原価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1genka_kin
		{
			get
			{
				return this._m1genka_kin;
			}
			set
			{
				this._m1genka_kin = value;
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
		public Tb040f01M1ResultVO() : base()
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
			Tb040f01M1ResultVO compare = null;
			if (obj is Tb040f01M1ResultVO)
			{
				compare = (Tb040f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
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
			if (_m1denpyo_barcode != compare.M1denpyo_barcode)
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
			if (_m1nyukayotei_ymd != compare.M1nyukayotei_ymd)
			{
				return false;
			}
			if (_m1nohin_su != compare.M1nohin_su)
			{
				return false;
			}
			if (_m1genka_kin != compare.M1genka_kin)
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
		/// <returns>現在のcom.xebio.bo.Tb040p01.Formvo.Tb040f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1denpyo_barcode:").Append(this._m1denpyo_barcode).AppendLine();
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1nyukayotei_ymd:").Append(this._m1nyukayotei_ymd).AppendLine();
			str.Append("M1nohin_su:").Append(this._m1nohin_su).AppendLine();
			str.Append("M1genka_kin:").Append(this._m1genka_kin).AppendLine();
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
