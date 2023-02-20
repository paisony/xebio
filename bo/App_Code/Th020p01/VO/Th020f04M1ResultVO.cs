using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Th020p01.VO
{
  /// <summary>
  /// Th020f04 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Th020f04M1ResultVO : StandardBaseVO
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
		/// 項目「M1URIAGE_SU(売上数)」の値
		/// </summary>
		private string _m1uriage_su;

		/// <summary>
		/// 項目「M1FREEZAIKO_SU(販売可能在庫)」の値
		/// </summary>
		private string _m1freezaiko_su;

		/// <summary>
		/// 項目「M1SYOKA_RTU(消化率)」の値
		/// </summary>
		private string _m1syoka_rtu;

		/// <summary>
		/// 項目「M1TYOBOZAIKO_SU(帳簿在庫数)」の値
		/// </summary>
		private string _m1tyobozaiko_su;

		/// <summary>
		/// 項目「M1AZUKARIYOYAKU_SU(預り予約数)」の値
		/// </summary>
		private string _m1azukariyoyaku_su;

		/// <summary>
		/// 項目「M1SEKISO_SU(積送中)」の値
		/// </summary>
		private string _m1sekiso_su;

		/// <summary>
		/// 項目「M1TONAN_SU(盗難品)」の値
		/// </summary>
		private string _m1tonan_su;

		/// <summary>
		/// 項目「M1HYOKASONSINSEI_SU(評価損申請)」の値
		/// </summary>
		private string _m1hyokasonsinsei_su;

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
		/// 項目「M1URIAGE_SU(売上数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1uriage_su
		{
			get
			{
				return this._m1uriage_su;
			}
			set
			{
				this._m1uriage_su = value;
			}
		}

		/// <summary>
		/// 項目「M1FREEZAIKO_SU(販売可能在庫)」の値を取得または設定する。
		/// </summary>
		public virtual string M1freezaiko_su
		{
			get
			{
				return this._m1freezaiko_su;
			}
			set
			{
				this._m1freezaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1SYOKA_RTU(消化率)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syoka_rtu
		{
			get
			{
				return this._m1syoka_rtu;
			}
			set
			{
				this._m1syoka_rtu = value;
			}
		}

		/// <summary>
		/// 項目「M1TYOBOZAIKO_SU(帳簿在庫数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tyobozaiko_su
		{
			get
			{
				return this._m1tyobozaiko_su;
			}
			set
			{
				this._m1tyobozaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1AZUKARIYOYAKU_SU(預り予約数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1azukariyoyaku_su
		{
			get
			{
				return this._m1azukariyoyaku_su;
			}
			set
			{
				this._m1azukariyoyaku_su = value;
			}
		}

		/// <summary>
		/// 項目「M1SEKISO_SU(積送中)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sekiso_su
		{
			get
			{
				return this._m1sekiso_su;
			}
			set
			{
				this._m1sekiso_su = value;
			}
		}

		/// <summary>
		/// 項目「M1TONAN_SU(盗難品)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tonan_su
		{
			get
			{
				return this._m1tonan_su;
			}
			set
			{
				this._m1tonan_su = value;
			}
		}

		/// <summary>
		/// 項目「M1HYOKASONSINSEI_SU(評価損申請)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hyokasonsinsei_su
		{
			get
			{
				return this._m1hyokasonsinsei_su;
			}
			set
			{
				this._m1hyokasonsinsei_su = value;
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
		public Th020f04M1ResultVO() : base()
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
			Th020f04M1ResultVO compare = null;
			if (obj is Th020f04M1ResultVO)
			{
				compare = (Th020f04M1ResultVO)obj;
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
			if (_m1uriage_su != compare.M1uriage_su)
			{
				return false;
			}
			if (_m1freezaiko_su != compare.M1freezaiko_su)
			{
				return false;
			}
			if (_m1syoka_rtu != compare.M1syoka_rtu)
			{
				return false;
			}
			if (_m1tyobozaiko_su != compare.M1tyobozaiko_su)
			{
				return false;
			}
			if (_m1azukariyoyaku_su != compare.M1azukariyoyaku_su)
			{
				return false;
			}
			if (_m1sekiso_su != compare.M1sekiso_su)
			{
				return false;
			}
			if (_m1tonan_su != compare.M1tonan_su)
			{
				return false;
			}
			if (_m1hyokasonsinsei_su != compare.M1hyokasonsinsei_su)
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
		/// <returns>現在のcom.xebio.bo.Th020p01.Formvo.Th020f04M1Formのハッシュ コード。</returns>
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
			str.Append("M1uriage_su:").Append(this._m1uriage_su).AppendLine();
			str.Append("M1freezaiko_su:").Append(this._m1freezaiko_su).AppendLine();
			str.Append("M1syoka_rtu:").Append(this._m1syoka_rtu).AppendLine();
			str.Append("M1tyobozaiko_su:").Append(this._m1tyobozaiko_su).AppendLine();
			str.Append("M1azukariyoyaku_su:").Append(this._m1azukariyoyaku_su).AppendLine();
			str.Append("M1sekiso_su:").Append(this._m1sekiso_su).AppendLine();
			str.Append("M1tonan_su:").Append(this._m1tonan_su).AppendLine();
			str.Append("M1hyokasonsinsei_su:").Append(this._m1hyokasonsinsei_su).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
