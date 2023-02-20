using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tg040p01.Formvo.Baseform
{
  /// <summary>
  /// Tg040f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg040f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「YMD_FROM(日付)」の値
		/// </summary>
		private string _ymd_from;
		/// <summary>
		/// 項目「YMD_TO()」の値
		/// </summary>
		private string _ymd_to;
		/// <summary>
		/// 項目「STOCK_NO(ストックNo.)」の値
		/// </summary>
		private string _stock_no;
		/// <summary>
		/// 項目「TAN_CD(担当者)」の値
		/// </summary>
		private string _tan_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日)」の値
		/// </summary>
		private string _hanbaikanryo_ymd_from;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO()」の値
		/// </summary>
		private string _hanbaikanryo_ymd_to;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;

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
		/// 項目「YMD_FROM(日付)」の値を取得または設定する。
		/// </summary>
		public virtual string Ymd_from
		{
			get
			{
				return this._ymd_from;
			}
			set
			{
				this._ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Ymd_to
		{
			get
			{
				return this._ymd_to;
			}
			set
			{
				this._ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「STOCK_NO(ストックNo.)」の値を取得または設定する。
		/// </summary>
		public virtual string Stock_no
		{
			get
			{
				return this._stock_no;
			}
			set
			{
				this._stock_no = value;
			}
		}
		/// <summary>
		/// 項目「TAN_CD(担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Tan_cd
		{
			get
			{
				return this._tan_cd;
			}
			set
			{
				this._tan_cd = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm
		{
			get
			{
				return this._hanbaiin_nm;
			}
			set
			{
				this._hanbaiin_nm = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn
		{
			get
			{
				return this._old_jisya_hbn;
			}
			set
			{
				this._old_jisya_hbn = value;
			}
		}
		/// <summary>
		/// 項目「MAKER_HBN()」の値を取得または設定する。
		/// </summary>
		public virtual string Maker_hbn
		{
			get
			{
				return this._maker_hbn;
			}
			set
			{
				this._maker_hbn = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd
		{
			get
			{
				return this._scan_cd;
			}
			set
			{
				this._scan_cd = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaikanryo_ymd_from
		{
			get
			{
				return this._hanbaikanryo_ymd_from;
			}
			set
			{
				this._hanbaikanryo_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaikanryo_ymd_to
		{
			get
			{
				return this._hanbaikanryo_ymd_to;
			}
			set
			{
				this._hanbaikanryo_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「SEARCHCNT()」の値を取得または設定する。
		/// </summary>
		public virtual string Searchcnt
		{
			get
			{
				return this._searchcnt;
			}
			set
			{
				this._searchcnt = value;
			}
		}
		/// <summary>
		/// 項目「MODENO()」の値を取得または設定する。
		/// </summary>
		public virtual string Modeno
		{
			get
			{
				return this._modeno;
			}
			set
			{
				this._modeno = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg040f01BaseForm() : base()
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
			sb.Append("Ymd_from:").Append(this._ymd_from).AppendLine();
			sb.Append("Ymd_to:").Append(this._ymd_to).AppendLine();
			sb.Append("Stock_no:").Append(this._stock_no).AppendLine();
			sb.Append("Tan_cd:").Append(this._tan_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Hanbaikanryo_ymd_from:").Append(this._hanbaikanryo_ymd_from).AppendLine();
			sb.Append("Hanbaikanryo_ymd_to:").Append(this._hanbaikanryo_ymd_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
		
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
			return "Tg040f01";
		}
		#endregion

		#endregion
	}
}
