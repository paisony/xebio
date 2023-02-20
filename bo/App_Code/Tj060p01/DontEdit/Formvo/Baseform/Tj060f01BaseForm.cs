using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj060p01.Formvo.Baseform
{
  /// <summary>
  /// Tj060f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj060f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD()」の値
		/// </summary>
		private string _tanaorosikijun_ymd;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD(棚卸実施日)」の値
		/// </summary>
		private string _tanaorosijissi_ymd;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM(棚卸期間)」の値
		/// </summary>
		private string _tanaorosikikan_from;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO()」の値
		/// </summary>
		private string _tanaorosikikan_to;
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1()」の値
		/// </summary>
		private string _tanaorosikijun_ymd1;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(棚卸実施日)」の値
		/// </summary>
		private string _tanaorosijissi_ymd1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(棚卸期間)」の値
		/// </summary>
		private string _tanaorosikikan_from1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1()」の値
		/// </summary>
		private string _tanaorosikikan_to1;
		/// <summary>
		/// 項目「TANAOROSI_HOKOKUSYO_KB()」の値
		/// </summary>
		private string _tanaorosi_hokokusyo_kb;

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
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikijun_ymd
		{
			get
			{
				return this._tanaorosikijun_ymd;
			}
			set
			{
				this._tanaorosikijun_ymd = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD(棚卸実施日)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosijissi_ymd
		{
			get
			{
				return this._tanaorosijissi_ymd;
			}
			set
			{
				this._tanaorosijissi_ymd = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM(棚卸期間)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_from
		{
			get
			{
				return this._tanaorosikikan_from;
			}
			set
			{
				this._tanaorosikikan_from = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_to
		{
			get
			{
				return this._tanaorosikikan_to;
			}
			set
			{
				this._tanaorosikikan_to = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikijun_ymd1
		{
			get
			{
				return this._tanaorosikijun_ymd1;
			}
			set
			{
				this._tanaorosikijun_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(棚卸実施日)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosijissi_ymd1
		{
			get
			{
				return this._tanaorosijissi_ymd1;
			}
			set
			{
				this._tanaorosijissi_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(棚卸期間)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_from1
		{
			get
			{
				return this._tanaorosikikan_from1;
			}
			set
			{
				this._tanaorosikikan_from1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_to1
		{
			get
			{
				return this._tanaorosikikan_to1;
			}
			set
			{
				this._tanaorosikikan_to1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSI_HOKOKUSYO_KB()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosi_hokokusyo_kb
		{
			get
			{
				return this._tanaorosi_hokokusyo_kb;
			}
			set
			{
				this._tanaorosi_hokokusyo_kb = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj060f01BaseForm() : base()
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
		}

		/// <summary>
		/// 明細の現在のページの画面表示分のリストを取得します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細の現在のページの画面表示分のリスト</returns>
		public virtual IList GetPageViewList(string listId)
		{
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Tanaorosikijun_ymd:").Append(this._tanaorosikijun_ymd).AppendLine();
			sb.Append("Tanaorosijissi_ymd:").Append(this._tanaorosijissi_ymd).AppendLine();
			sb.Append("Tanaorosikikan_from:").Append(this._tanaorosikikan_from).AppendLine();
			sb.Append("Tanaorosikikan_to:").Append(this._tanaorosikikan_to).AppendLine();
			sb.Append("Tanaorosikijun_ymd1:").Append(this._tanaorosikijun_ymd1).AppendLine();
			sb.Append("Tanaorosijissi_ymd1:").Append(this._tanaorosijissi_ymd1).AppendLine();
			sb.Append("Tanaorosikikan_from1:").Append(this._tanaorosikikan_from1).AppendLine();
			sb.Append("Tanaorosikikan_to1:").Append(this._tanaorosikikan_to1).AppendLine();
			sb.Append("Tanaorosi_hokokusyo_kb:").Append(this._tanaorosi_hokokusyo_kb).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Tj060f01";
		}
		#endregion

		#endregion
	}
}
