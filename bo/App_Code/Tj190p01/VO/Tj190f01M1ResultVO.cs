using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj190p01.VO
{
  /// <summary>
  /// Tj190f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tj190f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1TENPO_CD(店舗)」の値
		/// </summary>
		private string _m1tenpo_cd;

		/// <summary>
		/// 項目「M1TENPO_NM()」の値
		/// </summary>
		private string _m1tenpo_nm;

		/// <summary>
		/// 項目「M1NYURYOKU_YMD(入力日)」の値
		/// </summary>
		private string _m1nyuryoku_ymd;

		/// <summary>
		/// 項目「M1RINTANA_KANRI_NO(臨棚管理No)」の値
		/// </summary>
		private string _m1rintana_kanri_no;

		/// <summary>
		/// 項目「M1LOSS_KANRI_NO(ロス管理No)」の値
		/// </summary>
		private string _m1loss_kanri_no;


		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1BURANDO_NM1(ブランド1)」の値
		/// </summary>
		private string _m1burando_nm1;

		/// <summary>
		/// 項目「M1BURANDO_NM2(ブランド2)」の値
		/// </summary>
		private string _m1burando_nm2;

		/// <summary>
		/// 項目「M1BURANDO_NM3(ブランド3)」の値
		/// </summary>
		private string _m1burando_nm3;

		/// <summary>
		/// 項目「M1BURANDO_NM4(ブランド4)」の値
		/// </summary>
		private string _m1burando_nm4;

		/// <summary>
		/// 項目「M1BURANDO_NM5(ブランド5)」の値
		/// </summary>
		private string _m1burando_nm5;

		/// <summary>
		/// 項目「M1BURANDO_NM6(ブランド6)」の値
		/// </summary>
		private string _m1burando_nm6;

		/// <summary>
		/// 項目「M1BURANDO_NM7(ブランド7)」の値
		/// </summary>
		private string _m1burando_nm7;

		/// <summary>
		/// 項目「M1BURANDO_NM8(ブランド8)」の値
		/// </summary>
		private string _m1burando_nm8;

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU(棚時帳簿数)」の値
		/// </summary>
		private string _m1tanajityobo_su;

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU(棚時積送数)」の値
		/// </summary>
		private string _m1tanajisekiso_su;

		/// <summary>
		/// 項目「M1JITANA_SU(実棚数)」の値
		/// </summary>
		private string _m1jitana_su;

		/// <summary>
		/// 項目「M1NYURYOKUTAN_NM(入力担当者)」の値
		/// </summary>
		private string _m1nyuryokutan_nm;

		/// <summary>
		/// 項目「M1LOSS_SU(ロス数)」の値
		/// </summary>
		private string _m1loss_su;

		/// <summary>
		/// 項目「M1LOSS_KIN(ロス金額)」の値
		/// </summary>
		private string _m1loss_kin;

		/// <summary>
		/// 項目「M1LOSSKEISAN_YMD(ロス計算日)」の値
		/// </summary>
		private string _m1losskeisan_ymd;

		/// <summary>
		/// 項目「M1LOSSKEISAN_TM()」の値
		/// </summary>
		private string _m1losskeisan_tm;

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
		/// 項目「M1RINTANA_KANRI_NO(臨棚管理No)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rintana_kanri_no
		{
			get
			{
				return this._m1rintana_kanri_no;
			}
			set
			{
				this._m1rintana_kanri_no = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSS_KANRI_NO(ロス管理No)」の値を取得または設定する。
		/// </summary>
		public virtual string M1loss_kanri_no
		{
			get
			{
				return this._m1loss_kanri_no;
			}
			set
			{
				this._m1loss_kanri_no = value;
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
		/// 項目「M1BURANDO_NM1(ブランド1)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm1
		{
			get
			{
				return this._m1burando_nm1;
			}
			set
			{
				this._m1burando_nm1 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM2(ブランド2)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm2
		{
			get
			{
				return this._m1burando_nm2;
			}
			set
			{
				this._m1burando_nm2 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM3(ブランド3)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm3
		{
			get
			{
				return this._m1burando_nm3;
			}
			set
			{
				this._m1burando_nm3 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM4(ブランド4)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm4
		{
			get
			{
				return this._m1burando_nm4;
			}
			set
			{
				this._m1burando_nm4 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM5(ブランド5)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm5
		{
			get
			{
				return this._m1burando_nm5;
			}
			set
			{
				this._m1burando_nm5 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM6(ブランド6)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm6
		{
			get
			{
				return this._m1burando_nm6;
			}
			set
			{
				this._m1burando_nm6 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM7(ブランド7)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm7
		{
			get
			{
				return this._m1burando_nm7;
			}
			set
			{
				this._m1burando_nm7 = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM8(ブランド8)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm8
		{
			get
			{
				return this._m1burando_nm8;
			}
			set
			{
				this._m1burando_nm8 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJITYOBO_SU(棚時帳簿数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajityobo_su
		{
			get
			{
				return this._m1tanajityobo_su;
			}
			set
			{
				this._m1tanajityobo_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TANAJISEKISO_SU(棚時積送数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tanajisekiso_su
		{
			get
			{
				return this._m1tanajisekiso_su;
			}
			set
			{
				this._m1tanajisekiso_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JITANA_SU(実棚数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jitana_su
		{
			get
			{
				return this._m1jitana_su;
			}
			set
			{
				this._m1jitana_su = value;
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
		/// 項目「M1LOSS_SU(ロス数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1loss_su
		{
			get
			{
				return this._m1loss_su;
			}
			set
			{
				this._m1loss_su = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSS_KIN(ロス金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1loss_kin
		{
			get
			{
				return this._m1loss_kin;
			}
			set
			{
				this._m1loss_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSSKEISAN_YMD(ロス計算日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1losskeisan_ymd
		{
			get
			{
				return this._m1losskeisan_ymd;
			}
			set
			{
				this._m1losskeisan_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1LOSSKEISAN_TM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1losskeisan_tm
		{
			get
			{
				return this._m1losskeisan_tm;
			}
			set
			{
				this._m1losskeisan_tm = value;
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
		public Tj190f01M1ResultVO() : base()
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
			Tj190f01M1ResultVO compare = null;
			if (obj is Tj190f01M1ResultVO)
			{
				compare = (Tj190f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
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
			if (_m1nyuryoku_ymd != compare.M1nyuryoku_ymd)
			{
				return false;
			}
			if (_m1rintana_kanri_no != compare.M1rintana_kanri_no)
			{
				return false;
			}
			if (_m1loss_kanri_no != compare.M1loss_kanri_no)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1burando_nm1 != compare.M1burando_nm1)
			{
				return false;
			}
			if (_m1burando_nm2 != compare.M1burando_nm2)
			{
				return false;
			}
			if (_m1burando_nm3 != compare.M1burando_nm3)
			{
				return false;
			}
			if (_m1burando_nm4 != compare.M1burando_nm4)
			{
				return false;
			}
			if (_m1burando_nm5 != compare.M1burando_nm5)
			{
				return false;
			}
			if (_m1burando_nm6 != compare.M1burando_nm6)
			{
				return false;
			}
			if (_m1burando_nm7 != compare.M1burando_nm7)
			{
				return false;
			}
			if (_m1burando_nm8 != compare.M1burando_nm8)
			{
				return false;
			}
			if (_m1tanajityobo_su != compare.M1tanajityobo_su)
			{
				return false;
			}
			if (_m1tanajisekiso_su != compare.M1tanajisekiso_su)
			{
				return false;
			}
			if (_m1jitana_su != compare.M1jitana_su)
			{
				return false;
			}
			if (_m1nyuryokutan_nm != compare.M1nyuryokutan_nm)
			{
				return false;
			}
			if (_m1loss_su != compare.M1loss_su)
			{
				return false;
			}
			if (_m1loss_kin != compare.M1loss_kin)
			{
				return false;
			}
			if (_m1losskeisan_ymd != compare.M1losskeisan_ymd)
			{
				return false;
			}
			if (_m1losskeisan_tm != compare.M1losskeisan_tm)
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
		/// <returns>現在のcom.xebio.bo.Tj190p01.Formvo.Tj190f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1tenpo_cd:").Append(this._m1tenpo_cd).AppendLine();
			str.Append("M1tenpo_nm:").Append(this._m1tenpo_nm).AppendLine();
			str.Append("M1nyuryoku_ymd:").Append(this._m1nyuryoku_ymd).AppendLine();
			str.Append("M1rintana_kanri_no:").Append(this._m1rintana_kanri_no).AppendLine();
			str.Append("M1loss_kanri_no:").Append(this._m1loss_kanri_no).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm1:").Append(this._m1burando_nm1).AppendLine();
			str.Append("M1burando_nm2:").Append(this._m1burando_nm2).AppendLine();
			str.Append("M1burando_nm3:").Append(this._m1burando_nm3).AppendLine();
			str.Append("M1burando_nm4:").Append(this._m1burando_nm4).AppendLine();
			str.Append("M1burando_nm5:").Append(this._m1burando_nm5).AppendLine();
			str.Append("M1burando_nm6:").Append(this._m1burando_nm6).AppendLine();
			str.Append("M1burando_nm7:").Append(this._m1burando_nm7).AppendLine();
			str.Append("M1burando_nm8:").Append(this._m1burando_nm8).AppendLine();
			str.Append("M1tanajityobo_su:").Append(this._m1tanajityobo_su).AppendLine();
			str.Append("M1tanajisekiso_su:").Append(this._m1tanajisekiso_su).AppendLine();
			str.Append("M1jitana_su:").Append(this._m1jitana_su).AppendLine();
			str.Append("M1nyuryokutan_nm:").Append(this._m1nyuryokutan_nm).AppendLine();
			str.Append("M1loss_su:").Append(this._m1loss_su).AppendLine();
			str.Append("M1loss_kin:").Append(this._m1loss_kin).AppendLine();
			str.Append("M1losskeisan_ymd:").Append(this._m1losskeisan_ymd).AppendLine();
			str.Append("M1losskeisan_tm:").Append(this._m1losskeisan_tm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
