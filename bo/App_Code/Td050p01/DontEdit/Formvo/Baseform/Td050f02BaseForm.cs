using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Td050p01.Formvo.Baseform
{
  /// <summary>
  /// Td050f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td050f02BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「HEAD_TENPO_CD(店舗)」の値
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
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「KAKUTEITAN_CD(確定担当者)」の値
		/// </summary>
		private string _kakuteitan_cd;
		/// <summary>
		/// 項目「KAKUTEITAN_NM()」の値
		/// </summary>
		private string _kakuteitan_nm;
		/// <summary>
		/// 項目「HENPIN_RIYU_NM(返品理由)」の値
		/// </summary>
		private string _henpin_riyu_nm;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「SIJI_BANGO(指示番号)」の値
		/// </summary>
		private string _siji_bango;
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD(返品確定日)」の値
		/// </summary>
		private string _henpin_kakutei_ymd;
		/// <summary>
		/// 項目「ADD_YMD(登録日)」の値
		/// </summary>
		private string _add_ymd;
		/// <summary>
		/// 項目「BIKO(備考)」の値
		/// </summary>
		private string _biko;
		/// <summary>
		/// 項目「GOKEITEISEI_SURYO(合計)」の値
		/// </summary>
		private string _gokeiteisei_suryo;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値
		/// </summary>
		private string _genka_kin_gokei;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「HEAD_TENPO_CD(店舗)」の値を取得または設定する。
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
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_cd
		{
			get
			{
				return this._nyuryokutan_cd;
			}
			set
			{
				this._nyuryokutan_cd = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_nm
		{
			get
			{
				return this._nyuryokutan_nm;
			}
			set
			{
				this._nyuryokutan_nm = value;
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
		/// 項目「HENPIN_RIYU_NM(返品理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Henpin_riyu_nm
		{
			get
			{
				return this._henpin_riyu_nm;
			}
			set
			{
				this._henpin_riyu_nm = value;
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
		/// 項目「SIIRESAKI_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_ryaku_nm
		{
			get
			{
				return this._siiresaki_ryaku_nm;
			}
			set
			{
				this._siiresaki_ryaku_nm = value;
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
		/// 項目「SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Siji_bango
		{
			get
			{
				return this._siji_bango;
			}
			set
			{
				this._siji_bango = value;
			}
		}
		/// <summary>
		/// 項目「HENPIN_KAKUTEI_YMD(返品確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Henpin_kakutei_ymd
		{
			get
			{
				return this._henpin_kakutei_ymd;
			}
			set
			{
				this._henpin_kakutei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD(登録日)」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd
		{
			get
			{
				return this._add_ymd;
			}
			set
			{
				this._add_ymd = value;
			}
		}
		/// <summary>
		/// 項目「BIKO(備考)」の値を取得または設定する。
		/// </summary>
		public virtual string Biko
		{
			get
			{
				return this._biko;
			}
			set
			{
				this._biko = value;
			}
		}
		/// <summary>
		/// 項目「GOKEITEISEI_SURYO(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeiteisei_suryo
		{
			get
			{
				return this._gokeiteisei_suryo;
			}
			set
			{
				this._gokeiteisei_suryo = value;
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
		public Td050f02BaseForm() : base()
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
		public virtual IDataList GetList(string listId)
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
		public virtual void SetList(string listId, ICollection list)
		{
			if (listId.Equals("M1"))
			{
				m1List.SetAll(list);
			}
		}

		/// <summary>
		/// 明細の現在のページの画面表示分のリストを取得します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細の現在のページの画面表示分のリスト</returns>
		public virtual IList GetPageViewList(string listId)
		{
			if (listId.Equals("M1"))
			{
				return m1List.GetPageViewList();
			}
			return null;
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
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Kakuteitan_cd:").Append(this._kakuteitan_cd).AppendLine();
			sb.Append("Kakuteitan_nm:").Append(this._kakuteitan_nm).AppendLine();
			sb.Append("Henpin_riyu_nm:").Append(this._henpin_riyu_nm).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Siji_bango:").Append(this._siji_bango).AppendLine();
			sb.Append("Henpin_kakutei_ymd:").Append(this._henpin_kakutei_ymd).AppendLine();
			sb.Append("Add_ymd:").Append(this._add_ymd).AppendLine();
			sb.Append("Biko:").Append(this._biko).AppendLine();
			sb.Append("Gokeiteisei_suryo:").Append(this._gokeiteisei_suryo).AppendLine();
			sb.Append("Genka_kin_gokei:").Append(this._genka_kin_gokei).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Td050f02";
		}
		#endregion

		#endregion
	}
}
