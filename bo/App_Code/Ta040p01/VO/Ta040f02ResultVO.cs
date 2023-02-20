using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta040p01.VO
{
  /// <summary>
  /// Ta040f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Ta040f02ResultVO : StandardBaseVO
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
		/// 項目「HENKO_KBN_NM(変更区分)」の値
		/// </summary>
		private string _henko_kbn_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「KESSAI_YMD(決裁日)」の値
		/// </summary>
		private string _kessai_ymd;
		/// <summary>
		/// 項目「GOKEI_HAIBUN_SU()」の値
		/// </summary>
		private string _gokei_haibun_su;
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値
		/// </summary>
		private string _gokei_genkakin;

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
		/// 項目「HENKO_KBN_NM(変更区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Henko_kbn_nm
		{
			get
			{
				return this._henko_kbn_nm;
			}
			set
			{
				this._henko_kbn_nm = value;
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
		/// 項目「KESSAI_YMD(決裁日)」の値を取得または設定する。
		/// </summary>
		public virtual string Kessai_ymd
		{
			get
			{
				return this._kessai_ymd;
			}
			set
			{
				this._kessai_ymd = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_HAIBUN_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_haibun_su
		{
			get
			{
				return this._gokei_haibun_su;
			}
			set
			{
				this._gokei_haibun_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_GENKAKIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_genkakin
		{
			get
			{
				return this._gokei_genkakin;
			}
			set
			{
				this._gokei_genkakin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta040f02ResultVO() : base()
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
			sb.Append("Henko_kbn_nm:").Append(this._henko_kbn_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Kessai_ymd:").Append(this._kessai_ymd).AppendLine();
			sb.Append("Gokei_haibun_su:").Append(this._gokei_haibun_su).AppendLine();
			sb.Append("Gokei_genkakin:").Append(this._gokei_genkakin).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
