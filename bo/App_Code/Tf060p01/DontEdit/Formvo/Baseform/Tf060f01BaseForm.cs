using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf060p01.Formvo.Baseform
{
  /// <summary>
  /// Tf060f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf060f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「GETUDO(月度)」の値
		/// </summary>
		private string _getudo;
		/// <summary>
		/// 項目「TUKIBETU_BUMON1_YOSAN_KIN(月別部門合計)」の値
		/// </summary>
		private string _tukibetu_bumon1_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON2_YOSAN_KIN()」の値
		/// </summary>
		private string _tukibetu_bumon2_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON3_YOSAN_KIN()」の値
		/// </summary>
		private string _tukibetu_bumon3_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON4_YOSAN_KIN()」の値
		/// </summary>
		private string _tukibetu_bumon4_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_BUMON5_YOSAN_KIN()」の値
		/// </summary>
		private string _tukibetu_bumon5_yosan_kin;
		/// <summary>
		/// 項目「TUKIBETU_YOSAN_KIN_GOKEI()」の値
		/// </summary>
		private string _tukibetu_yosan_kin_gokei;
		/// <summary>
		/// 項目「BUMON1_YOSANGOKEI_KIN(合計)」の値
		/// </summary>
		private string _bumon1_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON2_YOSANGOKEI_KIN()」の値
		/// </summary>
		private string _bumon2_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON3_YOSANGOKEI_KIN()」の値
		/// </summary>
		private string _bumon3_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON4_YOSANGOKEI_KIN()」の値
		/// </summary>
		private string _bumon4_yosangokei_kin;
		/// <summary>
		/// 項目「BUMON5_YOSANGOKEI_KIN()」の値
		/// </summary>
		private string _bumon5_yosangokei_kin;
		/// <summary>
		/// 項目「YOSANGOKEI_KIN()」の値
		/// </summary>
		private string _yosangokei_kin;

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
		/// 項目「GETUDO(月度)」の値を取得または設定する。
		/// </summary>
		public virtual string Getudo
		{
			get
			{
				return this._getudo;
			}
			set
			{
				this._getudo = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_BUMON1_YOSAN_KIN(月別部門合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_bumon1_yosan_kin
		{
			get
			{
				return this._tukibetu_bumon1_yosan_kin;
			}
			set
			{
				this._tukibetu_bumon1_yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_BUMON2_YOSAN_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_bumon2_yosan_kin
		{
			get
			{
				return this._tukibetu_bumon2_yosan_kin;
			}
			set
			{
				this._tukibetu_bumon2_yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_BUMON3_YOSAN_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_bumon3_yosan_kin
		{
			get
			{
				return this._tukibetu_bumon3_yosan_kin;
			}
			set
			{
				this._tukibetu_bumon3_yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_BUMON4_YOSAN_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_bumon4_yosan_kin
		{
			get
			{
				return this._tukibetu_bumon4_yosan_kin;
			}
			set
			{
				this._tukibetu_bumon4_yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_BUMON5_YOSAN_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_bumon5_yosan_kin
		{
			get
			{
				return this._tukibetu_bumon5_yosan_kin;
			}
			set
			{
				this._tukibetu_bumon5_yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「TUKIBETU_YOSAN_KIN_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Tukibetu_yosan_kin_gokei
		{
			get
			{
				return this._tukibetu_yosan_kin_gokei;
			}
			set
			{
				this._tukibetu_yosan_kin_gokei = value;
			}
		}
		/// <summary>
		/// 項目「BUMON1_YOSANGOKEI_KIN(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon1_yosangokei_kin
		{
			get
			{
				return this._bumon1_yosangokei_kin;
			}
			set
			{
				this._bumon1_yosangokei_kin = value;
			}
		}
		/// <summary>
		/// 項目「BUMON2_YOSANGOKEI_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon2_yosangokei_kin
		{
			get
			{
				return this._bumon2_yosangokei_kin;
			}
			set
			{
				this._bumon2_yosangokei_kin = value;
			}
		}
		/// <summary>
		/// 項目「BUMON3_YOSANGOKEI_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon3_yosangokei_kin
		{
			get
			{
				return this._bumon3_yosangokei_kin;
			}
			set
			{
				this._bumon3_yosangokei_kin = value;
			}
		}
		/// <summary>
		/// 項目「BUMON4_YOSANGOKEI_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon4_yosangokei_kin
		{
			get
			{
				return this._bumon4_yosangokei_kin;
			}
			set
			{
				this._bumon4_yosangokei_kin = value;
			}
		}
		/// <summary>
		/// 項目「BUMON5_YOSANGOKEI_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon5_yosangokei_kin
		{
			get
			{
				return this._bumon5_yosangokei_kin;
			}
			set
			{
				this._bumon5_yosangokei_kin = value;
			}
		}
		/// <summary>
		/// 項目「YOSANGOKEI_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosangokei_kin
		{
			get
			{
				return this._yosangokei_kin;
			}
			set
			{
				this._yosangokei_kin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf060f01BaseForm() : base()
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
			sb.Append("Getudo:").Append(this._getudo).AppendLine();
			sb.Append("Tukibetu_bumon1_yosan_kin:").Append(this._tukibetu_bumon1_yosan_kin).AppendLine();
			sb.Append("Tukibetu_bumon2_yosan_kin:").Append(this._tukibetu_bumon2_yosan_kin).AppendLine();
			sb.Append("Tukibetu_bumon3_yosan_kin:").Append(this._tukibetu_bumon3_yosan_kin).AppendLine();
			sb.Append("Tukibetu_bumon4_yosan_kin:").Append(this._tukibetu_bumon4_yosan_kin).AppendLine();
			sb.Append("Tukibetu_bumon5_yosan_kin:").Append(this._tukibetu_bumon5_yosan_kin).AppendLine();
			sb.Append("Tukibetu_yosan_kin_gokei:").Append(this._tukibetu_yosan_kin_gokei).AppendLine();
			sb.Append("Bumon1_yosangokei_kin:").Append(this._bumon1_yosangokei_kin).AppendLine();
			sb.Append("Bumon2_yosangokei_kin:").Append(this._bumon2_yosangokei_kin).AppendLine();
			sb.Append("Bumon3_yosangokei_kin:").Append(this._bumon3_yosangokei_kin).AppendLine();
			sb.Append("Bumon4_yosangokei_kin:").Append(this._bumon4_yosangokei_kin).AppendLine();
			sb.Append("Bumon5_yosangokei_kin:").Append(this._bumon5_yosangokei_kin).AppendLine();
			sb.Append("Yosangokei_kin:").Append(this._yosangokei_kin).AppendLine();
		
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
			return "Tf060f01";
		}
		#endregion

		#endregion
	}
}
