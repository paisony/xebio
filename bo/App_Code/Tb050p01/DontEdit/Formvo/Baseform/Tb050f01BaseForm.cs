using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb050p01.Formvo.Baseform
{
  /// <summary>
  /// Tb050f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb050f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「BIKO_KB(備考欄)」の値
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
		/// 項目「GOKEI_KENSU(合計)」の値
		/// </summary>
		private string _gokei_kensu;
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
		/// 項目「BIKO_KB(備考欄)」の値を取得または設定する。
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
		/// 項目「GOKEI_KENSU(合計)」の値を取得または設定する。
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
		public Tb050f01BaseForm() : base()
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
			sb.Append("Biko_kb:").Append(this._biko_kb).AppendLine();
			sb.Append("Biko1:").Append(this._biko1).AppendLine();
			sb.Append("Biko2:").Append(this._biko2).AppendLine();
			sb.Append("Gokei_kensu:").Append(this._gokei_kensu).AppendLine();
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
			return "Tb050f01";
		}
		#endregion

		#endregion
	}
}
