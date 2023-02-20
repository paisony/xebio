using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tg010p01.VO
{
  /// <summary>
  /// Tg010f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tg010f01ResultVO : StandardBaseVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「OLD_JISYA_HBN2()」の値
		/// </summary>
		private string _old_jisya_hbn2;
		/// <summary>
		/// 項目「OLD_JISYA_HBN3()」の値
		/// </summary>
		private string _old_jisya_hbn3;
		/// <summary>
		/// 項目「OLD_JISYA_HBN4()」の値
		/// </summary>
		private string _old_jisya_hbn4;
		/// <summary>
		/// 項目「OLD_JISYA_HBN5()」の値
		/// </summary>
		private string _old_jisya_hbn5;
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
		/// 項目「BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「LABEL_CD()」の値
		/// </summary>
		private string _label_cd;
		/// <summary>
		/// 項目「LABEL_IP()」の値
		/// </summary>
		private string _label_ip;
		/// <summary>
		/// 項目「LABEL_NM()」の値
		/// </summary>
		private string _label_nm;

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
		/// 項目「OLD_JISYA_HBN2()」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn2
		{
			get
			{
				return this._old_jisya_hbn2;
			}
			set
			{
				this._old_jisya_hbn2 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN3()」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn3
		{
			get
			{
				return this._old_jisya_hbn3;
			}
			set
			{
				this._old_jisya_hbn3 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN4()」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn4
		{
			get
			{
				return this._old_jisya_hbn4;
			}
			set
			{
				this._old_jisya_hbn4 = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN5()」の値を取得または設定する。
		/// </summary>
		public virtual string Old_jisya_hbn5
		{
			get
			{
				return this._old_jisya_hbn5;
			}
			set
			{
				this._old_jisya_hbn5 = value;
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
		/// 項目「BURANDO_NM(ブランド)」の値を取得または設定する。
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
		/// 項目「LABEL_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Label_cd
		{
			get
			{
				return this._label_cd;
			}
			set
			{
				this._label_cd = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_IP()」の値を取得または設定する。
		/// </summary>
		public virtual string Label_ip
		{
			get
			{
				return this._label_ip;
			}
			set
			{
				this._label_ip = value;
			}
		}
		/// <summary>
		/// 項目「LABEL_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Label_nm
		{
			get
			{
				return this._label_nm;
			}
			set
			{
				this._label_nm = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg010f01ResultVO() : base()
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
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Old_jisya_hbn2:").Append(this._old_jisya_hbn2).AppendLine();
			sb.Append("Old_jisya_hbn3:").Append(this._old_jisya_hbn3).AppendLine();
			sb.Append("Old_jisya_hbn4:").Append(this._old_jisya_hbn4).AppendLine();
			sb.Append("Old_jisya_hbn5:").Append(this._old_jisya_hbn5).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
