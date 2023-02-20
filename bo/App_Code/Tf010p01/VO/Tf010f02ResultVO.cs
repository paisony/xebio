using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf010p01.VO
{
  /// <summary>
  /// Tf010f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tf010f02ResultVO : StandardBaseVO
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
		/// 項目「APPLY_YMD(申請日)」の値
		/// </summary>
		private string _apply_ymd;
		/// <summary>
		/// 項目「SHINSEI_TENPO_CD(申請店舗)」の値
		/// </summary>
		private string _shinsei_tenpo_cd;
		/// <summary>
		/// 項目「SHINSEI_TENPO_NM()」の値
		/// </summary>
		private string _shinsei_tenpo_nm;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値
		/// </summary>
		private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値
		/// </summary>
		private string _sinseitan_nm;
		/// <summary>
		/// 項目「DENPYO_BANGO(伝票番号)」の値
		/// </summary>
		private string _denpyo_bango;
		/// <summary>
		/// 項目「SINSEIRIYU_KB(申請理由)」の値
		/// </summary>
		private string _sinseiriyu_kb;
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値
		/// </summary>
		private string _sinseiriyu;
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者)」の値
		/// </summary>
		private string _kakuteitan_cd;
		/// <summary>
		/// 項目「KAKUTEITAN_NM()」の値
		/// </summary>
		private string _kakuteitan_nm;
		/// <summary>
		/// 項目「KAKUTEI_YMD(確定日)」の値
		/// </summary>
		private string _kakutei_ymd;
		/// <summary>
		/// 項目「KAMOKU_CD(科目)」の値
		/// </summary>
		private string _kamoku_cd;
		/// <summary>
		/// 項目「KAMOKU_NM()」の値
		/// </summary>
		private string _kamoku_nm;
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値
		/// </summary>
		private string _kyakkariyu;
		/// <summary>
		/// 項目「GYOMURINGI_NO(業務稟議No)」の値
		/// </summary>
		private string _gyomuringi_no;
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値
		/// </summary>
		private string _jyuri_no;
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値
		/// </summary>
		private string _syonin_flg_nm;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値
		/// </summary>
		private string _gokei_suryo;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI1(原価合計)」の値
		/// </summary>
		private string _genka_kin_gokei1;

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
		/// 項目「APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_ymd
		{
			get
			{
				return this._apply_ymd;
			}
			set
			{
				this._apply_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SHINSEI_TENPO_CD(申請店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string Shinsei_tenpo_cd
		{
			get
			{
				return this._shinsei_tenpo_cd;
			}
			set
			{
				this._shinsei_tenpo_cd = value;
			}
		}
		/// <summary>
		/// 項目「SHINSEI_TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Shinsei_tenpo_nm
		{
			get
			{
				return this._shinsei_tenpo_nm;
			}
			set
			{
				this._shinsei_tenpo_nm = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_cd
		{
			get
			{
				return this._sinseitan_cd;
			}
			set
			{
				this._sinseitan_cd = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_nm
		{
			get
			{
				return this._sinseitan_nm;
			}
			set
			{
				this._sinseitan_nm = value;
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
		/// 項目「SINSEIRIYU_KB(申請理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseiriyu_kb
		{
			get
			{
				return this._sinseiriyu_kb;
			}
			set
			{
				this._sinseiriyu_kb = value;
			}
		}
		/// <summary>
		/// 項目「SINSEIRIYU(申請理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseiriyu
		{
			get
			{
				return this._sinseiriyu;
			}
			set
			{
				this._sinseiriyu = value;
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
		/// 項目「KAKUTEI_YMD(確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakutei_ymd
		{
			get
			{
				return this._kakutei_ymd;
			}
			set
			{
				this._kakutei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_CD(科目)」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_cd
		{
			get
			{
				return this._kamoku_cd;
			}
			set
			{
				this._kamoku_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAMOKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kamoku_nm
		{
			get
			{
				return this._kamoku_nm;
			}
			set
			{
				this._kamoku_nm = value;
			}
		}
		/// <summary>
		/// 項目「KYAKKARIYU(却下理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Kyakkariyu
		{
			get
			{
				return this._kyakkariyu;
			}
			set
			{
				this._kyakkariyu = value;
			}
		}
		/// <summary>
		/// 項目「GYOMURINGI_NO(業務稟議No)」の値を取得または設定する。
		/// </summary>
		public virtual string Gyomuringi_no
		{
			get
			{
				return this._gyomuringi_no;
			}
			set
			{
				this._gyomuringi_no = value;
			}
		}
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuri_no
		{
			get
			{
				return this._jyuri_no;
			}
			set
			{
				this._jyuri_no = value;
			}
		}
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonin_flg_nm
		{
			get
			{
				return this._syonin_flg_nm;
			}
			set
			{
				this._syonin_flg_nm = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo
		{
			get
			{
				return this._gokei_suryo;
			}
			set
			{
				this._gokei_suryo = value;
			}
		}
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI1(原価合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Genka_kin_gokei1
		{
			get
			{
				return this._genka_kin_gokei1;
			}
			set
			{
				this._genka_kin_gokei1 = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf010f02ResultVO() : base()
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
			sb.Append("Apply_ymd:").Append(this._apply_ymd).AppendLine();
			sb.Append("Shinsei_tenpo_cd:").Append(this._shinsei_tenpo_cd).AppendLine();
			sb.Append("Shinsei_tenpo_nm:").Append(this._shinsei_tenpo_nm).AppendLine();
			sb.Append("Sinseitan_cd:").Append(this._sinseitan_cd).AppendLine();
			sb.Append("Sinseitan_nm:").Append(this._sinseitan_nm).AppendLine();
			sb.Append("Denpyo_bango:").Append(this._denpyo_bango).AppendLine();
			sb.Append("Sinseiriyu_kb:").Append(this._sinseiriyu_kb).AppendLine();
			sb.Append("Sinseiriyu:").Append(this._sinseiriyu).AppendLine();
			sb.Append("Kakuteitan_cd:").Append(this._kakuteitan_cd).AppendLine();
			sb.Append("Kakuteitan_nm:").Append(this._kakuteitan_nm).AppendLine();
			sb.Append("Kakutei_ymd:").Append(this._kakutei_ymd).AppendLine();
			sb.Append("Kamoku_cd:").Append(this._kamoku_cd).AppendLine();
			sb.Append("Kamoku_nm:").Append(this._kamoku_nm).AppendLine();
			sb.Append("Kyakkariyu:").Append(this._kyakkariyu).AppendLine();
			sb.Append("Gyomuringi_no:").Append(this._gyomuringi_no).AppendLine();
			sb.Append("Jyuri_no:").Append(this._jyuri_no).AppendLine();
			sb.Append("Syonin_flg_nm:").Append(this._syonin_flg_nm).AppendLine();
			sb.Append("Gokei_suryo:").Append(this._gokei_suryo).AppendLine();
			sb.Append("Genka_kin_gokei1:").Append(this._genka_kin_gokei1).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
