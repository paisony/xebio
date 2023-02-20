using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj170p01.VO
{
  /// <summary>
  /// Tj170f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tj170f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;



		/// <summary>
		/// 項目「M1SYOHINGUN2_CD(商品群2)」の値
		/// </summary>
		private string _m1syohingun2_cd;

		/// <summary>
		/// 項目「M1GRPNM()」の値
		/// </summary>
		private string _m1grpnm;

		/// <summary>
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

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
		/// 項目「M1IKOUKEBARAI_SU(以降受払数)」の値
		/// </summary>
		private string _m1ikoukebarai_su;

		/// <summary>
		/// 項目「M1RIRONZAIKO_SU(理論在庫数)」の値
		/// </summary>
		private string _m1rironzaiko_su;

		/// <summary>
		/// 項目「M1RIRONTANAOROSI_SU(理論棚卸数)」の値
		/// </summary>
		private string _m1rirontanaorosi_su;

		/// <summary>
		/// 項目「M1LOSS_SU(ロス数)」の値
		/// </summary>
		private string _m1loss_su;

		/// <summary>
		/// 項目「M1LOSS_KIN(ロス金額)」の値
		/// </summary>
		private string _m1loss_kin;

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
		/// 項目「M1SYOHINGUN2_CD(商品群2)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syohingun2_cd
		{
			get
			{
				return this._m1syohingun2_cd;
			}
			set
			{
				this._m1syohingun2_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1GRPNM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1grpnm
		{
			get
			{
				return this._m1grpnm;
			}
			set
			{
				this._m1grpnm = value;
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
		/// 項目「M1IKOUKEBARAI_SU(以降受払数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1ikoukebarai_su
		{
			get
			{
				return this._m1ikoukebarai_su;
			}
			set
			{
				this._m1ikoukebarai_su = value;
			}
		}

		/// <summary>
		/// 項目「M1RIRONZAIKO_SU(理論在庫数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rironzaiko_su
		{
			get
			{
				return this._m1rironzaiko_su;
			}
			set
			{
				this._m1rironzaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1RIRONTANAOROSI_SU(理論棚卸数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rirontanaorosi_su
		{
			get
			{
				return this._m1rirontanaorosi_su;
			}
			set
			{
				this._m1rirontanaorosi_su = value;
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
		public Tj170f01M1ResultVO() : base()
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
			Tj170f01M1ResultVO compare = null;
			if (obj is Tj170f01M1ResultVO)
			{
				compare = (Tj170f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1syohingun2_cd != compare.M1syohingun2_cd)
			{
				return false;
			}
			if (_m1grpnm != compare.M1grpnm)
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
			if (_m1ikoukebarai_su != compare.M1ikoukebarai_su)
			{
				return false;
			}
			if (_m1rironzaiko_su != compare.M1rironzaiko_su)
			{
				return false;
			}
			if (_m1rirontanaorosi_su != compare.M1rirontanaorosi_su)
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
		/// <returns>現在のcom.xebio.bo.Tj170p01.Formvo.Tj170f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1syohingun2_cd:").Append(this._m1syohingun2_cd).AppendLine();
			str.Append("M1grpnm:").Append(this._m1grpnm).AppendLine();
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1tanajityobo_su:").Append(this._m1tanajityobo_su).AppendLine();
			str.Append("M1tanajisekiso_su:").Append(this._m1tanajisekiso_su).AppendLine();
			str.Append("M1jitana_su:").Append(this._m1jitana_su).AppendLine();
			str.Append("M1ikoukebarai_su:").Append(this._m1ikoukebarai_su).AppendLine();
			str.Append("M1rironzaiko_su:").Append(this._m1rironzaiko_su).AppendLine();
			str.Append("M1rirontanaorosi_su:").Append(this._m1rirontanaorosi_su).AppendLine();
			str.Append("M1loss_su:").Append(this._m1loss_su).AppendLine();
			str.Append("M1loss_kin:").Append(this._m1loss_kin).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
