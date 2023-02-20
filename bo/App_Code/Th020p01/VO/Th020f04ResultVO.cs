using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th020p01.VO
{
  /// <summary>
  /// Th020f04のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Th020f04ResultVO : StandardBaseVO
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
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「HINSYU_CD()」の値
		/// </summary>
		private string _hinsyu_cd;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値
		/// </summary>
		private string _syohin_zokusei;
		/// <summary>
		/// 項目「SYONMK(商品名)」の値
		/// </summary>
		private string _syonmk;
		/// <summary>
		/// 項目「IRO_NM(色)」の値
		/// </summary>
		private string _iro_nm;
		/// <summary>
		/// 項目「SIZE_NM(サイズ)」の値
		/// </summary>
		private string _size_nm;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;

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
		/// 項目「KAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_cd
		{
			get
			{
				return this._kaisya_cd;
			}
			set
			{
				this._kaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「KAISYA_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Kaisya_nm
		{
			get
			{
				return this._kaisya_nm;
			}
			set
			{
				this._kaisya_nm = value;
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
		/// 項目「HINSYU_RYAKU_NM(品種)」の値を取得または設定する。
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
		/// 項目「HINSYU_CD()」の値を取得または設定する。
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
		/// 項目「JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisya_hbn
		{
			get
			{
				return this._jisya_hbn;
			}
			set
			{
				this._jisya_hbn = value;
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
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohin_zokusei
		{
			get
			{
				return this._syohin_zokusei;
			}
			set
			{
				this._syohin_zokusei = value;
			}
		}
		/// <summary>
		/// 項目「SYONMK(商品名)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonmk
		{
			get
			{
				return this._syonmk;
			}
			set
			{
				this._syonmk = value;
			}
		}
		/// <summary>
		/// 項目「IRO_NM(色)」の値を取得または設定する。
		/// </summary>
		public virtual string Iro_nm
		{
			get
			{
				return this._iro_nm;
			}
			set
			{
				this._iro_nm = value;
			}
		}
		/// <summary>
		/// 項目「SIZE_NM(サイズ)」の値を取得または設定する。
		/// </summary>
		public virtual string Size_nm
		{
			get
			{
				return this._size_nm;
			}
			set
			{
				this._size_nm = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f04ResultVO() : base()
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
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Jisya_hbn:").Append(this._jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Syohin_zokusei:").Append(this._syohin_zokusei).AppendLine();
			sb.Append("Syonmk:").Append(this._syonmk).AppendLine();
			sb.Append("Iro_nm:").Append(this._iro_nm).AppendLine();
			sb.Append("Size_nm:").Append(this._size_nm).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
