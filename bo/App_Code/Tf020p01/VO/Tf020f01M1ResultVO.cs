using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tf020p01.VO
{
  /// <summary>
  /// Tf020f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tf020f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1APPLY_YMD(申請日)」の値
		/// </summary>
		private string _m1apply_ymd;

		/// <summary>
		/// 項目「M1KAKUTEI_YMD(確定日)」の値
		/// </summary>
		private string _m1kakutei_ymd;


		/// <summary>
		/// 項目「M1KAMOKU_CD(科目)」の値
		/// </summary>
		private string _m1kamoku_cd;

		/// <summary>
		/// 項目「M1KAMOKU_NM()」の値
		/// </summary>
		private string _m1kamoku_nm;

		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値
		/// </summary>
		private string _m1itemsu;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1BAIKA_TNK(売価金額)」の値
		/// </summary>
		private string _m1baika_tnk;

		/// <summary>
		/// 項目「M1SINSEITAN_NM(申請担当者)」の値
		/// </summary>
		private string _m1sinseitan_nm;

		/// <summary>
		/// 項目「M1JYURI_NO(受理番号)」の値
		/// </summary>
		private string _m1jyuri_no;

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認状態)」の値
		/// </summary>
		private string _m1syonin_flg_nm;

		/// <summary>
		/// 項目「M1SINSEIRIYU(申請理由)」の値
		/// </summary>
		private string _m1sinseiriyu;

		/// <summary>
		/// 項目「M1KYAKKARIYU(却下理由)」の値
		/// </summary>
		private string _m1kyakkariyu;

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
		/// 項目「M1KAKUTEI_YMD(確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kakutei_ymd
		{
			get
			{
				return this._m1kakutei_ymd;
			}
			set
			{
				this._m1kakutei_ymd = value;
			}
		}


		/// <summary>
		/// 項目「M1KAMOKU_CD(科目)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kamoku_cd
		{
			get
			{
				return this._m1kamoku_cd;
			}
			set
			{
				this._m1kamoku_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1KAMOKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1kamoku_nm
		{
			get
			{
				return this._m1kamoku_nm;
			}
			set
			{
				this._m1kamoku_nm = value;
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
		/// 項目「M1BAIKA_TNK(売価金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baika_tnk
		{
			get
			{
				return this._m1baika_tnk;
			}
			set
			{
				this._m1baika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEITAN_NM(申請担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinseitan_nm
		{
			get
			{
				return this._m1sinseitan_nm;
			}
			set
			{
				this._m1sinseitan_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuri_no
		{
			get
			{
				return this._m1jyuri_no;
			}
			set
			{
				this._m1jyuri_no = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonin_flg_nm
		{
			get
			{
				return this._m1syonin_flg_nm;
			}
			set
			{
				this._m1syonin_flg_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEIRIYU(申請理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinseiriyu
		{
			get
			{
				return this._m1sinseiriyu;
			}
			set
			{
				this._m1sinseiriyu = value;
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
		public Tf020f01M1ResultVO() : base()
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
			Tf020f01M1ResultVO compare = null;
			if (obj is Tf020f01M1ResultVO)
			{
				compare = (Tf020f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1apply_ymd != compare.M1apply_ymd)
			{
				return false;
			}
			if (_m1kakutei_ymd != compare.M1kakutei_ymd)
			{
				return false;
			}
			if (_m1kamoku_cd != compare.M1kamoku_cd)
			{
				return false;
			}
			if (_m1kamoku_nm != compare.M1kamoku_nm)
			{
				return false;
			}
			if (_m1itemsu != compare.M1itemsu)
			{
				return false;
			}
			if (_m1genkakin != compare.M1genkakin)
			{
				return false;
			}
			if (_m1baika_tnk != compare.M1baika_tnk)
			{
				return false;
			}
			if (_m1sinseitan_nm != compare.M1sinseitan_nm)
			{
				return false;
			}
			if (_m1jyuri_no != compare.M1jyuri_no)
			{
				return false;
			}
			if (_m1syonin_flg_nm != compare.M1syonin_flg_nm)
			{
				return false;
			}
			if (_m1sinseiriyu != compare.M1sinseiriyu)
			{
				return false;
			}
			if (_m1kyakkariyu != compare.M1kyakkariyu)
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
		/// <returns>現在のcom.xebio.bo.Tf020p01.Formvo.Tf020f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1apply_ymd:").Append(this._m1apply_ymd).AppendLine();
			str.Append("M1kakutei_ymd:").Append(this._m1kakutei_ymd).AppendLine();
			str.Append("M1kamoku_cd:").Append(this._m1kamoku_cd).AppendLine();
			str.Append("M1kamoku_nm:").Append(this._m1kamoku_nm).AppendLine();
			str.Append("M1itemsu:").Append(this._m1itemsu).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1baika_tnk:").Append(this._m1baika_tnk).AppendLine();
			str.Append("M1sinseitan_nm:").Append(this._m1sinseitan_nm).AppendLine();
			str.Append("M1jyuri_no:").Append(this._m1jyuri_no).AppendLine();
			str.Append("M1syonin_flg_nm:").Append(this._m1syonin_flg_nm).AppendLine();
			str.Append("M1sinseiriyu:").Append(this._m1sinseiriyu).AppendLine();
			str.Append("M1kyakkariyu:").Append(this._m1kyakkariyu).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
