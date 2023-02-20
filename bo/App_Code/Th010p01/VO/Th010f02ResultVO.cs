using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th010p01.VO
{
  /// <summary>
  /// Th010f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Th010f02ResultVO : StandardBaseVO
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
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「GENKA_FLG(原価)」の値
		/// </summary>
		private string _genka_flg;
		/// <summary>
		/// 項目「GENKA()」の値
		/// </summary>
		private string _genka;
		/// <summary>
		/// 項目「GENBAIKA_FLG(現売価)」の値
		/// </summary>
		private string _genbaika_flg;
		/// <summary>
		/// 項目「GENBAIKA_TNK()」の値
		/// </summary>
		private string _genbaika_tnk;
		/// <summary>
		/// 項目「MAKERKAKAKU_FLG(ﾒｰｶｰ価格)」の値
		/// </summary>
		private string _makerkakaku_flg;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK()」の値
		/// </summary>
		private string _makerkakaku_tnk;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「SYOHINMST_SERCHSTK(商品マスタ検索選択)」の値
		/// </summary>
		private string _syohinmst_serchstk;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;

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
		/// 項目「BURANDO_CD(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd
		{
			get
			{
				return this._burando_cd;
			}
			set
			{
				this._burando_cd = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm
		{
			get
			{
				return this._burando_nm;
			}
			set
			{
				this._burando_nm = value;
			}
		}
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値を取得または設定する。
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
		/// 項目「GENKA_FLG(原価)」の値を取得または設定する。
		/// </summary>
		public virtual string Genka_flg
		{
			get
			{
				return this._genka_flg;
			}
			set
			{
				this._genka_flg = value;
			}
		}
		/// <summary>
		/// 項目「GENKA()」の値を取得または設定する。
		/// </summary>
		public virtual string Genka
		{
			get
			{
				return this._genka;
			}
			set
			{
				this._genka = value;
			}
		}
		/// <summary>
		/// 項目「GENBAIKA_FLG(現売価)」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_flg
		{
			get
			{
				return this._genbaika_flg;
			}
			set
			{
				this._genbaika_flg = value;
			}
		}
		/// <summary>
		/// 項目「GENBAIKA_TNK()」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_tnk
		{
			get
			{
				return this._genbaika_tnk;
			}
			set
			{
				this._genbaika_tnk = value;
			}
		}
		/// <summary>
		/// 項目「MAKERKAKAKU_FLG(ﾒｰｶｰ価格)」の値を取得または設定する。
		/// </summary>
		public virtual string Makerkakaku_flg
		{
			get
			{
				return this._makerkakaku_flg;
			}
			set
			{
				this._makerkakaku_flg = value;
			}
		}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK()」の値を取得または設定する。
		/// </summary>
		public virtual string Makerkakaku_tnk
		{
			get
			{
				return this._makerkakaku_tnk;
			}
			set
			{
				this._makerkakaku_tnk = value;
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
		/// 項目「SYOHINMST_SERCHSTK(商品マスタ検索選択)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohinmst_serchstk
		{
			get
			{
				return this._syohinmst_serchstk;
			}
			set
			{
				this._syohinmst_serchstk = value;
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
		public Th010f02ResultVO() : base()
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
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Genka_flg:").Append(this._genka_flg).AppendLine();
			sb.Append("Genka:").Append(this._genka).AppendLine();
			sb.Append("Genbaika_flg:").Append(this._genbaika_flg).AppendLine();
			sb.Append("Genbaika_tnk:").Append(this._genbaika_tnk).AppendLine();
			sb.Append("Makerkakaku_flg:").Append(this._makerkakaku_flg).AppendLine();
			sb.Append("Makerkakaku_tnk:").Append(this._makerkakaku_tnk).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Syohinmst_serchstk:").Append(this._syohinmst_serchstk).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
