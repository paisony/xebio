using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj130p01.VO
{
  /// <summary>
  /// Tj130f02 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tj130f02M1ResultVO : StandardBaseVO
	{

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
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

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
		/// 項目「M1HYOJI_SYOHIN_CD(商品コード)」の値
		/// </summary>
		private string _m1hyoji_syohin_cd;

		/// <summary>
		/// 項目「M1SCAN_SU(ｽｷｬﾝ数量)」の値
		/// </summary>
		private string _m1scan_su;

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数量)」の値
		/// </summary>
		private string _m1teisei_suryo;

		/// <summary>
		/// 項目「M1GOKEI_SURYO(合計数量)」の値
		/// </summary>
		private string _m1gokei_suryo;

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
		/// 項目「M1HYOJI_SYOHIN_CD(商品コード)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyoji_syohin_cd
		{
			get
			{
				return this._m1hyoji_syohin_cd;
			}
			set
			{
				this._m1hyoji_syohin_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SCAN_SU(ｽｷｬﾝ数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scan_su
		{
			get
			{
				return this._m1scan_su;
			}
			set
			{
				this._m1scan_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TEISEI_SURYO(訂正数量)」の値を取得または設定する。
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
		/// 項目「M1GOKEI_SURYO(合計数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1gokei_suryo
		{
			get
			{
				return this._m1gokei_suryo;
			}
			set
			{
				this._m1gokei_suryo = value;
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
		public Tj130f02M1ResultVO() : base()
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
			Tj130f02M1ResultVO compare = null;
			if (obj is Tj130f02M1ResultVO)
			{
				compare = (Tj130f02M1ResultVO)obj;
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
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
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
			if (_m1hyoji_syohin_cd != compare.M1hyoji_syohin_cd)
			{
				return false;
			}
			if (_m1scan_su != compare.M1scan_su)
			{
				return false;
			}
			if (_m1teisei_suryo != compare.M1teisei_suryo)
			{
				return false;
			}
			if (_m1gokei_suryo != compare.M1gokei_suryo)
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
		/// <returns>現在のcom.xebio.bo.Tj130p01.Formvo.Tj130f02M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1hyoji_syohin_cd:").Append(this._m1hyoji_syohin_cd).AppendLine();
			str.Append("M1scan_su:").Append(this._m1scan_su).AppendLine();
			str.Append("M1teisei_suryo:").Append(this._m1teisei_suryo).AppendLine();
			str.Append("M1gokei_suryo:").Append(this._m1gokei_suryo).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
