using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf030p01.VO
{
  /// <summary>
  /// Tf030f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tf030f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1ADD_YMD(登録日)」の値
		/// </summary>
		private string _m1add_ymd;

		/// <summary>
		/// 項目「M1TENPO_CD(店舗)」の値
		/// </summary>
		private string _m1tenpo_cd;

		/// <summary>
		/// 項目「M1TENPO_NM()」の値
		/// </summary>
		private string _m1tenpo_nm;

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(取引先)」の値
		/// </summary>
		private string _m1siiresaki_cd;

		/// <summary>
		/// 項目「M1SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _m1siiresaki_ryaku_nm;


		/// <summary>
		/// 項目「M1MOTODENPYO_BANGO(元伝票番号)」の値
		/// </summary>
		private string _m1motodenpyo_bango;

		/// <summary>
		/// 項目「M1NOHIN_YMD(納品日)」の値
		/// </summary>
		private string _m1nohin_ymd;

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値
		/// </summary>
		private string _m1nyuryokutan_nm;

		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値
		/// </summary>
		private string _m1itemsu;

		/// <summary>
		/// 項目「M1KINGAKU(金額)」の値
		/// </summary>
		private string _m1kingaku;

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
		/// 項目「M1TENPO_CD(店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_cd
		{
			get
			{
				return this._m1tenpo_cd;
			}
			set
			{
				this._m1tenpo_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tenpo_nm
		{
			get
			{
				return this._m1tenpo_nm;
			}
			set
			{
				this._m1tenpo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRESAKI_CD(取引先)」の値を取得または設定する。
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
		/// 項目「M1MOTODENPYO_BANGO(元伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1motodenpyo_bango
		{
			get
			{
				return this._m1motodenpyo_bango;
			}
			set
			{
				this._m1motodenpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1NOHIN_YMD(納品日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nohin_ymd
		{
			get
			{
				return this._m1nohin_ymd;
			}
			set
			{
				this._m1nohin_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyuryokutan_nm
		{
			get
			{
				return this._m1nyuryokutan_nm;
			}
			set
			{
				this._m1nyuryokutan_nm = value;
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
		/// 項目「M1KINGAKU(金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kingaku
		{
			get
			{
				return this._m1kingaku;
			}
			set
			{
				this._m1kingaku = value;
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
		public Tf030f01M1ResultVO() : base()
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
			Tf030f01M1ResultVO compare = null;
			if (obj is Tf030f01M1ResultVO)
			{
				compare = (Tf030f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1add_ymd != compare.M1add_ymd)
			{
				return false;
			}
			if (_m1tenpo_cd != compare.M1tenpo_cd)
			{
				return false;
			}
			if (_m1tenpo_nm != compare.M1tenpo_nm)
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
			if (_m1motodenpyo_bango != compare.M1motodenpyo_bango)
			{
				return false;
			}
			if (_m1nohin_ymd != compare.M1nohin_ymd)
			{
				return false;
			}
			if (_m1nyuryokutan_nm != compare.M1nyuryokutan_nm)
			{
				return false;
			}
			if (_m1itemsu != compare.M1itemsu)
			{
				return false;
			}
			if (_m1kingaku != compare.M1kingaku)
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
		/// <returns>現在のcom.xebio.bo.Tf030p01.Formvo.Tf030f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1add_ymd:").Append(this._m1add_ymd).AppendLine();
			str.Append("M1tenpo_cd:").Append(this._m1tenpo_cd).AppendLine();
			str.Append("M1tenpo_nm:").Append(this._m1tenpo_nm).AppendLine();
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1motodenpyo_bango:").Append(this._m1motodenpyo_bango).AppendLine();
			str.Append("M1nohin_ymd:").Append(this._m1nohin_ymd).AppendLine();
			str.Append("M1nyuryokutan_nm:").Append(this._m1nyuryokutan_nm).AppendLine();
			str.Append("M1itemsu:").Append(this._m1itemsu).AppendLine();
			str.Append("M1kingaku:").Append(this._m1kingaku).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
