using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ti030p01.Formvo.Baseform
{
  /// <summary>
  /// Ti030f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti030f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SYOHIZEI_RTU1(消費税率１)」の値
		/// </summary>
		private string _syohizei_rtu1;
		/// <summary>
		/// 項目「SYOHIZEIKAISI_YMD1(税率１開始日)」の値
		/// </summary>
		private string _syohizeikaisi_ymd1;
		/// <summary>
		/// 項目「ZEISYORI_KB1(税処理区分1)」の値
		/// </summary>
		private string _zeisyori_kb1;
		/// <summary>
		/// 項目「SYOHIZEI_RTU2(消費税率２)」の値
		/// </summary>
		private string _syohizei_rtu2;
		/// <summary>
		/// 項目「SYOHIZEIKAISI_YMD2(税率２開始日)」の値
		/// </summary>
		private string _syohizeikaisi_ymd2;
		/// <summary>
		/// 項目「ZEISYORI_KB2(税処理区分2)」の値
		/// </summary>
		private string _zeisyori_kb2;

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
		/// 項目「SYOHIZEI_RTU1(消費税率１)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohizei_rtu1
		{
			get
			{
				return this._syohizei_rtu1;
			}
			set
			{
				this._syohizei_rtu1 = value;
			}
		}
		/// <summary>
		/// 項目「SYOHIZEIKAISI_YMD1(税率１開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohizeikaisi_ymd1
		{
			get
			{
				return this._syohizeikaisi_ymd1;
			}
			set
			{
				this._syohizeikaisi_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「ZEISYORI_KB1(税処理区分1)」の値を取得または設定する。
		/// </summary>
		public virtual string Zeisyori_kb1
		{
			get
			{
				return this._zeisyori_kb1;
			}
			set
			{
				this._zeisyori_kb1 = value;
			}
		}
		/// <summary>
		/// 項目「SYOHIZEI_RTU2(消費税率２)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohizei_rtu2
		{
			get
			{
				return this._syohizei_rtu2;
			}
			set
			{
				this._syohizei_rtu2 = value;
			}
		}
		/// <summary>
		/// 項目「SYOHIZEIKAISI_YMD2(税率２開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohizeikaisi_ymd2
		{
			get
			{
				return this._syohizeikaisi_ymd2;
			}
			set
			{
				this._syohizeikaisi_ymd2 = value;
			}
		}
		/// <summary>
		/// 項目「ZEISYORI_KB2(税処理区分2)」の値を取得または設定する。
		/// </summary>
		public virtual string Zeisyori_kb2
		{
			get
			{
				return this._zeisyori_kb2;
			}
			set
			{
				this._zeisyori_kb2 = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti030f01BaseForm() : base()
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
			sb.Append("Syohizei_rtu1:").Append(this._syohizei_rtu1).AppendLine();
			sb.Append("Syohizeikaisi_ymd1:").Append(this._syohizeikaisi_ymd1).AppendLine();
			sb.Append("Zeisyori_kb1:").Append(this._zeisyori_kb1).AppendLine();
			sb.Append("Syohizei_rtu2:").Append(this._syohizei_rtu2).AppendLine();
			sb.Append("Syohizeikaisi_ymd2:").Append(this._syohizeikaisi_ymd2).AppendLine();
			sb.Append("Zeisyori_kb2:").Append(this._zeisyori_kb2).AppendLine();
		
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
			return "Ti030f01";
		}
		#endregion

		#endregion
	}
}
