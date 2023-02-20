using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tk010p01.Formvo.Baseform
{
  /// <summary>
  /// Tk010f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk010f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「HYOKASONSYUBETSU_KB(評価損種別)」の値
		/// </summary>
		private string _hyokasonsyubetsu_kb;
		/// <summary>
		/// 項目「SYONIN_FLG(承認状態)」の値
		/// </summary>
		private string _syonin_flg;
		/// <summary>
		/// 項目「KESSAI_FLG(決裁状態)」の値
		/// </summary>
		private string _kessai_flg;
		/// <summary>
		/// 項目「SINSEI_KB(申請区分)」の値
		/// </summary>
		private string _sinsei_kb;
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗FROM)」の値
		/// </summary>
		private string _tenpo_cd_from;
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値
		/// </summary>
		private string _tenpo_nm_from;
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗TO)」の値
		/// </summary>
		private string _tenpo_cd_to;
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値
		/// </summary>
		private string _tenpo_nm_to;
		/// <summary>
		/// 項目「SYORI_YM(処理月)」の値
		/// </summary>
		private string _syori_ym;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値
		/// </summary>
		private string _gokei_suryo;
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
		/// 項目「HYOKASONSYUBETSU_KB(評価損種別)」の値を取得または設定する。
		/// </summary>
		public virtual string Hyokasonsyubetsu_kb
		{
			get
			{
				return this._hyokasonsyubetsu_kb;
			}
			set
			{
				this._hyokasonsyubetsu_kb = value;
			}
		}
		/// <summary>
		/// 項目「SYONIN_FLG(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonin_flg
		{
			get
			{
				return this._syonin_flg;
			}
			set
			{
				this._syonin_flg = value;
			}
		}
		/// <summary>
		/// 項目「KESSAI_FLG(決裁状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Kessai_flg
		{
			get
			{
				return this._kessai_flg;
			}
			set
			{
				this._kessai_flg = value;
			}
		}
		/// <summary>
		/// 項目「SINSEI_KB(申請区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinsei_kb
		{
			get
			{
				return this._sinsei_kb;
			}
			set
			{
				this._sinsei_kb = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗FROM)」の値を取得または設定する。
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
		/// 項目「TENPO_CD_TO(店舗TO)」の値を取得または設定する。
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
		public Tk010f01BaseForm() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Hyokasonsyubetsu_kb:").Append(this._hyokasonsyubetsu_kb).AppendLine();
			sb.Append("Syonin_flg:").Append(this._syonin_flg).AppendLine();
			sb.Append("Kessai_flg:").Append(this._kessai_flg).AppendLine();
			sb.Append("Sinsei_kb:").Append(this._sinsei_kb).AppendLine();
			sb.Append("Tenpo_cd_from:").Append(this._tenpo_cd_from).AppendLine();
			sb.Append("Tenpo_nm_from:").Append(this._tenpo_nm_from).AppendLine();
			sb.Append("Tenpo_cd_to:").Append(this._tenpo_cd_to).AppendLine();
			sb.Append("Tenpo_nm_to:").Append(this._tenpo_nm_to).AppendLine();
			sb.Append("Syori_ym:").Append(this._syori_ym).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Gokei_suryo:").Append(this._gokei_suryo).AppendLine();
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
			return "Tk010f01";
		}
		#endregion

		#endregion
	}
}
