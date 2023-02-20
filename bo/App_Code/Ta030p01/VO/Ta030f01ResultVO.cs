using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta030p01.VO
{
  /// <summary>
  /// Ta030f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Ta030f01ResultVO : StandardBaseVO
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
		/// 項目「MODENO(モードNO)」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO(選択モードNO)」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「KBN_CD(区分)」の値
		/// </summary>
		private string _kbn_cd;
		/// <summary>
		/// 項目「SHINSEI_FLG(状態)」の値
		/// </summary>
		private string _shinsei_flg;
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
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「HATTYU_YMD_FROM(発注日FROM)」の値
		/// </summary>
		private string _hattyu_ymd_from;
		/// <summary>
		/// 項目「HATTYU_YMD_TO(発注日TO)」の値
		/// </summary>
		private string _hattyu_ymd_to;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「GOKEI_ITEMSU(合計)」の値
		/// </summary>
		private string _gokei_itemsu;
		/// <summary>
		/// 項目「GOKEI_KINGAKU()」の値
		/// </summary>
		private string _gokei_kingaku;

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
		/// 項目「MODENO(モードNO)」の値を取得または設定する。
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
		/// 項目「STKMODENO(選択モードNO)」の値を取得または設定する。
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
		/// 項目「KBN_CD(区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Kbn_cd
		{
			get
			{
				return this._kbn_cd;
			}
			set
			{
				this._kbn_cd = value;
			}
		}
		/// <summary>
		/// 項目「SHINSEI_FLG(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Shinsei_flg
		{
			get
			{
				return this._shinsei_flg;
			}
			set
			{
				this._shinsei_flg = value;
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
		/// 項目「HATTYU_YMD_FROM(発注日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Hattyu_ymd_from
		{
			get
			{
				return this._hattyu_ymd_from;
			}
			set
			{
				this._hattyu_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「HATTYU_YMD_TO(発注日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Hattyu_ymd_to
		{
			get
			{
				return this._hattyu_ymd_to;
			}
			set
			{
				this._hattyu_ymd_to = value;
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
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値を取得または設定する。
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
		/// 項目「GOKEI_ITEMSU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_itemsu
		{
			get
			{
				return this._gokei_itemsu;
			}
			set
			{
				this._gokei_itemsu = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_KINGAKU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_kingaku
		{
			get
			{
				return this._gokei_kingaku;
			}
			set
			{
				this._gokei_kingaku = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta030f01ResultVO() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Kbn_cd:").Append(this._kbn_cd).AppendLine();
			sb.Append("Shinsei_flg:").Append(this._shinsei_flg).AppendLine();
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Hattyu_ymd_from:").Append(this._hattyu_ymd_from).AppendLine();
			sb.Append("Hattyu_ymd_to:").Append(this._hattyu_ymd_to).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Gokei_itemsu:").Append(this._gokei_itemsu).AppendLine();
			sb.Append("Gokei_kingaku:").Append(this._gokei_kingaku).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
