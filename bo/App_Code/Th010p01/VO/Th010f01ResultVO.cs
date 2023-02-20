using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th010p01.VO
{
  /// <summary>
  /// Th010f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Th010f01ResultVO : StandardBaseVO
	{

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
		/// 項目「OLD_JISYA_HBN_FROM(旧自社品番ＦＲＯＭ)」の値
		/// </summary>
		private string _old_jisya_hbn_from;
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(旧自社品番ＴＯ)」の値
		/// </summary>
		private string _old_jisya_hbn_to;
		/// <summary>
		/// 項目「SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_CD(品種)」の値
		/// </summary>
		private string _hinsyu_cd;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM()」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「GENBAIKA_TNK_FROM(現売価ＦＲＯＭ)」の値
		/// </summary>
		private string _genbaika_tnk_from;
		/// <summary>
		/// 項目「GENBAIKA_TNK_TO(現売価ＴＯ)」の値
		/// </summary>
		private string _genbaika_tnk_to;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_FROM(メーカー価格ＦＲＯＭ)」の値
		/// </summary>
		private string _makerkakaku_tnk_from;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_TO(メーカー価格ＴＯ)」の値
		/// </summary>
		private string _makerkakaku_tnk_to;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日ＦＲＯＭ)」の値
		/// </summary>
		private string _hanbaikanryo_ymd_from;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_TO(販売完了日ＴＯ)」の値
		/// </summary>
		private string _hanbaikanryo_ymd_to;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「SYOHINMST_SERCHSTK(商品マスタ検索選択)」の値
		/// </summary>
		private string _syohinmst_serchstk;
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
		protected IList m1List;
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
		/// 項目「OLD_JISYA_HBN_FROM(旧自社品番ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn_from
		{
			get
			{
				return this._old_jisya_hbn_from;
			}
			set
			{
				this._old_jisya_hbn_from = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN_TO(旧自社品番ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn_to
		{
			get
			{
				return this._old_jisya_hbn_to;
			}
			set
			{
				this._old_jisya_hbn_to = value;
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
		/// 項目「HINSYU_CD(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd
		{
			get
			{
				return this._hinsyu_cd;
			}
			set
			{
				this._hinsyu_cd = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_ryaku_nm
		{
			get
			{
				return this._hinsyu_ryaku_nm;
			}
			set
			{
				this._hinsyu_ryaku_nm = value;
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
		/// 項目「GENBAIKA_TNK_FROM(現売価ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_tnk_from
		{
			get
			{
				return this._genbaika_tnk_from;
			}
			set
			{
				this._genbaika_tnk_from = value;
			}
		}
		/// <summary>
		/// 項目「GENBAIKA_TNK_TO(現売価ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_tnk_to
		{
			get
			{
				return this._genbaika_tnk_to;
			}
			set
			{
				this._genbaika_tnk_to = value;
			}
		}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_FROM(メーカー価格ＦＲＯＭ)」の値を取得または設定する。
		/// </summary>
		public virtual string Makerkakaku_tnk_from
		{
			get
			{
				return this._makerkakaku_tnk_from;
			}
			set
			{
				this._makerkakaku_tnk_from = value;
			}
		}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK_TO(メーカー価格ＴＯ)」の値を取得または設定する。
		/// </summary>
		public virtual string Makerkakaku_tnk_to
		{
			get
			{
				return this._makerkakaku_tnk_to;
			}
			set
			{
				this._makerkakaku_tnk_to = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD_FROM(販売完了日ＦＲＯＭ)」の値を取得または設定する。
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
		/// 項目「HANBAIKANRYO_YMD_TO(販売完了日ＴＯ)」の値を取得または設定する。
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
		public Th010f01ResultVO() : base()
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
			sb.Append("Old_jisya_hbn_from:").Append(this._old_jisya_hbn_from).AppendLine();
			sb.Append("Old_jisya_hbn_to:").Append(this._old_jisya_hbn_to).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Genbaika_tnk_from:").Append(this._genbaika_tnk_from).AppendLine();
			sb.Append("Genbaika_tnk_to:").Append(this._genbaika_tnk_to).AppendLine();
			sb.Append("Makerkakaku_tnk_from:").Append(this._makerkakaku_tnk_from).AppendLine();
			sb.Append("Makerkakaku_tnk_to:").Append(this._makerkakaku_tnk_to).AppendLine();
			sb.Append("Hanbaikanryo_ymd_from:").Append(this._hanbaikanryo_ymd_from).AppendLine();
			sb.Append("Hanbaikanryo_ymd_to:").Append(this._hanbaikanryo_ymd_to).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Syohinmst_serchstk:").Append(this._syohinmst_serchstk).AppendLine();
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
