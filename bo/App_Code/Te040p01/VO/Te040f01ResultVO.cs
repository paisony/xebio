using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te040p01.VO
{
  /// <summary>
  /// Te040f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Te040f01ResultVO : StandardBaseVO
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
		/// 項目「SHUKKARIYU_KBN(出荷理由)」の値
		/// </summary>
		private string _shukkariyu_kbn;
		/// <summary>
		/// 項目「KAISYA_CD(会社)」の値
		/// </summary>
		private string _kaisya_cd;
		/// <summary>
		/// 項目「KAISYA_NM()」の値
		/// </summary>
		private string _kaisya_nm;
		/// <summary>
		/// 項目「JYURYOTEN_CD(入荷店)」の値
		/// </summary>
		private string _jyuryoten_cd;
		/// <summary>
		/// 項目「JURYOTEN_NM()」の値
		/// </summary>
		private string _juryoten_nm;
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値
		/// </summary>
		private string _syukka_ymd;
		/// <summary>
		/// 項目「STOP_YMD(防止期限)」の値
		/// </summary>
		private string _stop_ymd;
		/// <summary>
		/// 項目「SYUKKASURYO_GOKEI()」の値
		/// </summary>
		private string _syukkasuryo_gokei;
		/// <summary>
		/// 項目「GENKA_KIN_GOKEI()」の値
		/// </summary>
		private string _genka_kin_gokei;

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
		/// 項目「SHUKKARIYU_KBN(出荷理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Shukkariyu_kbn
		{
			get
			{
				return this._shukkariyu_kbn;
			}
			set
			{
				this._shukkariyu_kbn = value;
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
		/// 項目「JYURYOTEN_CD(入荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryoten_cd
		{
			get
			{
				return this._jyuryoten_cd;
			}
			set
			{
				this._jyuryoten_cd = value;
			}
		}
		/// <summary>
		/// 項目「JURYOTEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Juryoten_nm
		{
			get
			{
				return this._juryoten_nm;
			}
			set
			{
				this._juryoten_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string Syukka_ymd
		{
			get
			{
				return this._syukka_ymd;
			}
			set
			{
				this._syukka_ymd = value;
			}
		}
		/// <summary>
		/// 項目「STOP_YMD(防止期限)」の値を取得または設定する。
		/// </summary>
		public virtual string Stop_ymd
		{
			get
			{
				return this._stop_ymd;
			}
			set
			{
				this._stop_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKASURYO_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkasuryo_gokei
		{
			get
			{
				return this._syukkasuryo_gokei;
			}
			set
			{
				this._syukkasuryo_gokei = value;
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
		public Te040f01ResultVO() : base()
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
			sb.Append("Shukkariyu_kbn:").Append(this._shukkariyu_kbn).AppendLine();
			sb.Append("Kaisya_cd:").Append(this._kaisya_cd).AppendLine();
			sb.Append("Kaisya_nm:").Append(this._kaisya_nm).AppendLine();
			sb.Append("Jyuryoten_cd:").Append(this._jyuryoten_cd).AppendLine();
			sb.Append("Juryoten_nm:").Append(this._juryoten_nm).AppendLine();
			sb.Append("Syukka_ymd:").Append(this._syukka_ymd).AppendLine();
			sb.Append("Stop_ymd:").Append(this._stop_ymd).AppendLine();
			sb.Append("Syukkasuryo_gokei:").Append(this._syukkasuryo_gokei).AppendLine();
			sb.Append("Genka_kin_gokei:").Append(this._genka_kin_gokei).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
