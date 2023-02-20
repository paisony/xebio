using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tk030p01.Formvo.Baseform
{
  /// <summary>
  /// Tk030f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk030f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SYORI_YM(処理月)」の値
		/// </summary>
		private string _syori_ym;
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗コードFROM)」の値
		/// </summary>
		private string _tenpo_cd_from;
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値
		/// </summary>
		private string _tenpo_nm_from;
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗コードTO)」の値
		/// </summary>
		private string _tenpo_cd_to;
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値
		/// </summary>
		private string _tenpo_nm_to;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値
		/// </summary>
		private string _gokei_suryo;
		/// <summary>
		/// 項目「HAIBUN_KIN_GOKEI()」の値
		/// </summary>
		private string _haibun_kin_gokei;

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
		/// 項目「SYORI_YM(処理月)」の値を取得または設定する。
		/// </summary>
		public virtual string Syori_ym
		{
			get
			{
				return this._syori_ym;
			}
			set
			{
				this._syori_ym = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗コードFROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_from
		{
			get
			{
				return this._tenpo_cd_from;
			}
			set
			{
				this._tenpo_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_from
		{
			get
			{
				return this._tenpo_nm_from;
			}
			set
			{
				this._tenpo_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗コードTO)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_to
		{
			get
			{
				return this._tenpo_cd_to;
			}
			set
			{
				this._tenpo_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_to
		{
			get
			{
				return this._tenpo_nm_to;
			}
			set
			{
				this._tenpo_nm_to = value;
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
		/// 項目「HAIBUN_KIN_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Haibun_kin_gokei
		{
			get
			{
				return this._haibun_kin_gokei;
			}
			set
			{
				this._haibun_kin_gokei = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk030f01BaseForm() : base()
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
			sb.Append("Syori_ym:").Append(this._syori_ym).AppendLine();
			sb.Append("Tenpo_cd_from:").Append(this._tenpo_cd_from).AppendLine();
			sb.Append("Tenpo_nm_from:").Append(this._tenpo_nm_from).AppendLine();
			sb.Append("Tenpo_cd_to:").Append(this._tenpo_cd_to).AppendLine();
			sb.Append("Tenpo_nm_to:").Append(this._tenpo_nm_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Gokei_suryo:").Append(this._gokei_suryo).AppendLine();
			sb.Append("Haibun_kin_gokei:").Append(this._haibun_kin_gokei).AppendLine();
		
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
			return "Tk030f01";
		}
		#endregion

		#endregion
	}
}
