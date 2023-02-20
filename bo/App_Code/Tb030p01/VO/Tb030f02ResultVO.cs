using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb030p01.VO
{
  /// <summary>
  /// Tb030f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tb030f02ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値
		/// </summary>
		private string _head_tenpo_cd;
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値
		/// </summary>
		private string _head_tenpo_nm;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		private string _denpyo_bango;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM1()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm1;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者)」の値
		/// </summary>
		private string _kakuteitan_cd;
		/// <summary>
		/// 項目「KAKUTEITAN_NM()」の値
		/// </summary>
		private string _kakuteitan_nm;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _nyukayotei_ymd;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD(仕入確定日)」の値
		/// </summary>
		private string _siire_kakutei_ymd;
		/// <summary>
		/// 項目「DENPYO_JYOTAINM(伝票状態)」の値
		/// </summary>
		private string _denpyo_jyotainm;
		/// <summary>
		/// 項目「GOKEI_KENSU()」の値
		/// </summary>
		private string _gokei_kensu;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値
		/// </summary>
		private string _genka_kin_gokei;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Head_tenpo_cd
		{
			get
			{
				return this._head_tenpo_cd;
			}
			set
			{
				this._head_tenpo_cd = value;
			}
		}
		/// <summary>
		/// 項目「HEAD_TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Head_tenpo_nm
		{
			get
			{
				return this._head_tenpo_nm;
			}
			set
			{
				this._head_tenpo_nm = value;
			}
		}
		/// <summary>
		/// 項目「STKMODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Stkmodeno
		{
			get
			{
				return this._stkmodeno;
			}
			set
			{
				this._stkmodeno = value;
			}
		}
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_bango
		{
			get
			{
				return this._denpyo_bango;
			}
			set
			{
				this._denpyo_bango = value;
			}
		}
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_cd
		{
			get
			{
				return this._siiresaki_cd;
			}
			set
			{
				this._siiresaki_cd = value;
			}
		}
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM1()」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_ryaku_nm1
		{
			get
			{
				return this._siiresaki_ryaku_nm1;
			}
			set
			{
				this._siiresaki_ryaku_nm1 = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd
		{
			get
			{
				return this._bumon_cd;
			}
			set
			{
				this._bumon_cd = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm
		{
			get
			{
				return this._bumon_nm;
			}
			set
			{
				this._bumon_nm = value;
			}
		}
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakuteitan_cd
		{
			get
			{
				return this._kakuteitan_cd;
			}
			set
			{
				this._kakuteitan_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAKUTEITAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kakuteitan_nm
		{
			get
			{
				return this._kakuteitan_nm;
			}
			set
			{
				this._kakuteitan_nm = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd
		{
			get
			{
				return this._nyukayotei_ymd;
			}
			set
			{
				this._nyukayotei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD(仕入確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd
		{
			get
			{
				return this._siire_kakutei_ymd;
			}
			set
			{
				this._siire_kakutei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「DENPYO_JYOTAINM(伝票状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_jyotainm
		{
			get
			{
				return this._denpyo_jyotainm;
			}
			set
			{
				this._denpyo_jyotainm = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_KENSU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_kensu
		{
			get
			{
				return this._gokei_kensu;
			}
			set
			{
				this._gokei_kensu = value;
			}
		}
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Genka_kin_gokei
		{
			get
			{
				return this._genka_kin_gokei;
			}
			set
			{
				this._genka_kin_gokei = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb030f02ResultVO() : base()
		{
		}
		#endregion

		#region メソッド
		
		#region IFormVO メンバ
		/// <summary>
		/// 明細リストを取得します。
		/// 引数の明細IDに対応する明細リストが存在しない場合はnullを返却します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細リスト</returns>
		public virtual IList GetList(string listId)
		{
			if (listId.Equals("M1"))
			{
				return m1List;
			}
			return null;
		}

		/// <summary>
		/// 明細リストを設定します。
		/// 引数の明細IDに対応する明細リストが存在しない場合は何もしません。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <param name="list">全件リスト</param>
		public virtual void SetList(string listId, IList list)
		{
			if (listId.Equals("M1"))
			{
				m1List = list;
			}
		}

		#endregion
		/// <summary>
		/// このオブジェクトの内容を文字列で取得する。
		/// </summary>
		/// <returns>オブジェクトの内容</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
		
			sb.AppendLine("カード部：");
			sb.Append("Head_tenpo_cd:").Append(this._head_tenpo_cd).AppendLine();
			sb.Append("Head_tenpo_nm:").Append(this._head_tenpo_nm).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Denpyo_bango:").Append(this._denpyo_bango).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm1:").Append(this._siiresaki_ryaku_nm1).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Kakuteitan_cd:").Append(this._kakuteitan_cd).AppendLine();
			sb.Append("Kakuteitan_nm:").Append(this._kakuteitan_nm).AppendLine();
			sb.Append("Nyukayotei_ymd:").Append(this._nyukayotei_ymd).AppendLine();
			sb.Append("Siire_kakutei_ymd:").Append(this._siire_kakutei_ymd).AppendLine();
			sb.Append("Denpyo_jyotainm:").Append(this._denpyo_jyotainm).AppendLine();
			sb.Append("Gokei_kensu:").Append(this._gokei_kensu).AppendLine();
			sb.Append("Genka_kin_gokei:").Append(this._genka_kin_gokei).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
