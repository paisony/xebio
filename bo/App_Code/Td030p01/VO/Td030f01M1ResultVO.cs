using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Td030p01.VO
{
  /// <summary>
  /// Td030f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Td030f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1BUMON_CD_BO1(部門)」の値
		/// </summary>
		private string _m1bumon_cd_bo1;

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
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1HENPIN_KAKUTEI_YMD(返品確定日)」の値
		/// </summary>
		private string _m1henpin_kakutei_ymd;

		/// <summary>
		/// 項目「M1ADD_YMD(登録日)」の値
		/// </summary>
		private string _m1add_ymd;



		/// <summary>
		/// 項目「M1SIJI_BANGO(指示番号)」の値
		/// </summary>
		private string _m1siji_bango;

		/// <summary>
		/// 項目「M1MOTODENPYO_BANGO(元伝票番号)」の値
		/// </summary>
		private string _m1motodenpyo_bango;

		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値
		/// </summary>
		private string _m1itemsu;

		/// <summary>
		/// 項目「M1GENKAKIN(原価金額)」の値
		/// </summary>
		private string _m1genkakin;

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値
		/// </summary>
		private string _m1nyuryokutan_nm;

		/// <summary>
		/// 項目「M1KAKUTEITAN_NM(確定担当者)」の値
		/// </summary>
		private string _m1kakuteitan_nm;

		/// <summary>
		/// 項目「M1HENPIN_RIYU_NM(返品理由)」の値
		/// </summary>
		private string _m1henpin_riyu_nm;

		/// <summary>
		/// 項目「M1DENPYO_JYOTAINM(伝票状態)」の値
		/// </summary>
		private string _m1denpyo_jyotainm;

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値
		/// </summary>
		private string _m1syorinm;

		/// <summary>
		/// 項目「M1SYORIYMD(処理日)」の値
		/// </summary>
		private string _m1syoriymd;

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値
		/// </summary>
		private string _m1syori_tm;

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
		/// 項目「M1BUMON_CD_BO1(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_cd_bo1
		{
			get
			{
				return this._m1bumon_cd_bo1;
			}
			set
			{
				this._m1bumon_cd_bo1 = value;
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
		/// 項目「M1HENPIN_KAKUTEI_YMD(返品確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henpin_kakutei_ymd
		{
			get
			{
				return this._m1henpin_kakutei_ymd;
			}
			set
			{
				this._m1henpin_kakutei_ymd = value;
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
		/// 項目「M1SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siji_bango
		{
			get
			{
				return this._m1siji_bango;
			}
			set
			{
				this._m1siji_bango = value;
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
		/// 項目「M1HENPIN_RIYU_NM(返品理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henpin_riyu_nm
		{
			get
			{
				return this._m1henpin_riyu_nm;
			}
			set
			{
				this._m1henpin_riyu_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1DENPYO_JYOTAINM(伝票状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1denpyo_jyotainm
		{
			get
			{
				return this._m1denpyo_jyotainm;
			}
			set
			{
				this._m1denpyo_jyotainm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syorinm
		{
			get
			{
				return this._m1syorinm;
			}
			set
			{
				this._m1syorinm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORIYMD(処理日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syoriymd
		{
			get
			{
				return this._m1syoriymd;
			}
			set
			{
				this._m1syoriymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syori_tm
		{
			get
			{
				return this._m1syori_tm;
			}
			set
			{
				this._m1syori_tm = value;
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
		public Td030f01M1ResultVO() : base()
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
			Td030f01M1ResultVO compare = null;
			if (obj is Td030f01M1ResultVO)
			{
				compare = (Td030f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumon_cd_bo1 != compare.M1bumon_cd_bo1)
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
			if (_m1burando_nm != compare.M1burando_nm)
			{
				return false;
			}
			if (_m1henpin_kakutei_ymd != compare.M1henpin_kakutei_ymd)
			{
				return false;
			}
			if (_m1add_ymd != compare.M1add_ymd)
			{
				return false;
			}
			if (_m1siji_bango != compare.M1siji_bango)
			{
				return false;
			}
			if (_m1motodenpyo_bango != compare.M1motodenpyo_bango)
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
			if (_m1nyuryokutan_nm != compare.M1nyuryokutan_nm)
			{
				return false;
			}
			if (_m1kakuteitan_nm != compare.M1kakuteitan_nm)
			{
				return false;
			}
			if (_m1henpin_riyu_nm != compare.M1henpin_riyu_nm)
			{
				return false;
			}
			if (_m1denpyo_jyotainm != compare.M1denpyo_jyotainm)
			{
				return false;
			}
			if (_m1syorinm != compare.M1syorinm)
			{
				return false;
			}
			if (_m1syoriymd != compare.M1syoriymd)
			{
				return false;
			}
			if (_m1syori_tm != compare.M1syori_tm)
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
		/// <returns>現在のcom.xebio.bo.Td030p01.Formvo.Td030f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd_bo1:").Append(this._m1bumon_cd_bo1).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1siiresaki_cd:").Append(this._m1siiresaki_cd).AppendLine();
			str.Append("M1siiresaki_ryaku_nm:").Append(this._m1siiresaki_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1henpin_kakutei_ymd:").Append(this._m1henpin_kakutei_ymd).AppendLine();
			str.Append("M1add_ymd:").Append(this._m1add_ymd).AppendLine();
			str.Append("M1siji_bango:").Append(this._m1siji_bango).AppendLine();
			str.Append("M1motodenpyo_bango:").Append(this._m1motodenpyo_bango).AppendLine();
			str.Append("M1itemsu:").Append(this._m1itemsu).AppendLine();
			str.Append("M1genkakin:").Append(this._m1genkakin).AppendLine();
			str.Append("M1nyuryokutan_nm:").Append(this._m1nyuryokutan_nm).AppendLine();
			str.Append("M1kakuteitan_nm:").Append(this._m1kakuteitan_nm).AppendLine();
			str.Append("M1henpin_riyu_nm:").Append(this._m1henpin_riyu_nm).AppendLine();
			str.Append("M1denpyo_jyotainm:").Append(this._m1denpyo_jyotainm).AppendLine();
			str.Append("M1syorinm:").Append(this._m1syorinm).AppendLine();
			str.Append("M1syoriymd:").Append(this._m1syoriymd).AppendLine();
			str.Append("M1syori_tm:").Append(this._m1syori_tm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
