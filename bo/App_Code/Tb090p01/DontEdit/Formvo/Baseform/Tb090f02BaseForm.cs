using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb090p01.Formvo.Baseform
{
  /// <summary>
  /// Tb090f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb090f02BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

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
		/// 項目「KAKUTEI_SB_NM(確定種別)」の値
		/// </summary>
		private string _kakutei_sb_nm;
		/// <summary>
		/// 項目「BIKO_KB(備考)」の値
		/// </summary>
		private string _biko_kb;
		/// <summary>
		/// 項目「BIKO1(①)」の値
		/// </summary>
		private string _biko1;
		/// <summary>
		/// 項目「BIKO2(②)」の値
		/// </summary>
		private string _biko2;
		/// <summary>
		/// 項目「GOKEI_TEISEI_SURYO()」の値
		/// </summary>
		private string _gokei_teisei_suryo;
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値
		/// </summary>
		private string _gokei_genkakin;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
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
		/// 項目「KAKUTEI_SB_NM(確定種別)」の値を取得または設定する。
		/// </summary>
		public virtual string Kakutei_sb_nm
		{
			get
			{
				return this._kakutei_sb_nm;
			}
			set
			{
				this._kakutei_sb_nm = value;
			}
		}
		/// <summary>
		/// 項目「BIKO_KB(備考)」の値を取得または設定する。
		/// </summary>
		public virtual string Biko_kb
		{
			get
			{
				return this._biko_kb;
			}
			set
			{
				this._biko_kb = value;
			}
		}
		/// <summary>
		/// 項目「BIKO1(①)」の値を取得または設定する。
		/// </summary>
		public virtual string Biko1
		{
			get
			{
				return this._biko1;
			}
			set
			{
				this._biko1 = value;
			}
		}
		/// <summary>
		/// 項目「BIKO2(②)」の値を取得または設定する。
		/// </summary>
		public virtual string Biko2
		{
			get
			{
				return this._biko2;
			}
			set
			{
				this._biko2 = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_TEISEI_SURYO()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_teisei_suryo
		{
			get
			{
				return this._gokei_teisei_suryo;
			}
			set
			{
				this._gokei_teisei_suryo = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_genkakin
		{
			get
			{
				return this._gokei_genkakin;
			}
			set
			{
				this._gokei_genkakin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb090f02BaseForm() : base()
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
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Kakuteitan_cd:").Append(this._kakuteitan_cd).AppendLine();
			sb.Append("Kakuteitan_nm:").Append(this._kakuteitan_nm).AppendLine();
			sb.Append("Nyukayotei_ymd:").Append(this._nyukayotei_ymd).AppendLine();
			sb.Append("Siire_kakutei_ymd:").Append(this._siire_kakutei_ymd).AppendLine();
			sb.Append("Kakutei_sb_nm:").Append(this._kakutei_sb_nm).AppendLine();
			sb.Append("Biko_kb:").Append(this._biko_kb).AppendLine();
			sb.Append("Biko1:").Append(this._biko1).AppendLine();
			sb.Append("Biko2:").Append(this._biko2).AppendLine();
			sb.Append("Gokei_teisei_suryo:").Append(this._gokei_teisei_suryo).AppendLine();
			sb.Append("Gokei_genkakin:").Append(this._gokei_genkakin).AppendLine();
		
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
			return "Tb090f02";
		}
		#endregion

		#endregion
	}
}
