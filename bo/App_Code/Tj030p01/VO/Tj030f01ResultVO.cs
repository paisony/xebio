using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj030p01.VO
{
  /// <summary>
  /// Tj030f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj030f01ResultVO : StandardBaseVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「FACE_NO_FROM(フェイスNo)」の値
		/// </summary>
		private string _face_no_from;
		/// <summary>
		/// 項目「FACE_NO_TO()」の値
		/// </summary>
		private string _face_no_to;
		/// <summary>
		/// 項目「TANA_DAN_FROM(棚段)」の値
		/// </summary>
		private string _tana_dan_from;
		/// <summary>
		/// 項目「TANA_DAN_TO()」の値
		/// </summary>
		private string _tana_dan_to;
		/// <summary>
		/// 項目「TENPO_GYOSYA_KB(店舗／業者)」の値
		/// </summary>
		private string _tenpo_gyosya_kb;
		/// <summary>
		/// 項目「NYURYOKU_YMD_FROM(入力日)」の値
		/// </summary>
		private string _nyuryoku_ymd_from;
		/// <summary>
		/// 項目「NYURYOKU_YMD_TO()」の値
		/// </summary>
		private string _nyuryoku_ymd_to;
		/// <summary>
		/// 項目「SOSIN_YMD_FROM(送信日)」の値
		/// </summary>
		private string _sosin_ymd_from;
		/// <summary>
		/// 項目「SOSIN_YMD_TO()」の値
		/// </summary>
		private string _sosin_ymd_to;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
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
		/// 項目「SOSIN_JYOTAI(送信状態)」の値
		/// </summary>
		private string _sosin_jyotai;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「SCAN_CD2()」の値
		/// </summary>
		private string _scan_cd2;
		/// <summary>
		/// 項目「SCAN_CD3()」の値
		/// </summary>
		private string _scan_cd3;
		/// <summary>
		/// 項目「SCAN_CD4()」の値
		/// </summary>
		private string _scan_cd4;
		/// <summary>
		/// 項目「SCAN_CD5()」の値
		/// </summary>
		private string _scan_cd5;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;

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
		/// 項目「FACE_NO_FROM(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_from
		{
			get
			{
				return this._face_no_from;
			}
			set
			{
				this._face_no_from = value;
			}
		}
		/// <summary>
		/// 項目「FACE_NO_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no_to
		{
			get
			{
				return this._face_no_to;
			}
			set
			{
				this._face_no_to = value;
			}
		}
		/// <summary>
		/// 項目「TANA_DAN_FROM(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string Tana_dan_from
		{
			get
			{
				return this._tana_dan_from;
			}
			set
			{
				this._tana_dan_from = value;
			}
		}
		/// <summary>
		/// 項目「TANA_DAN_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tana_dan_to
		{
			get
			{
				return this._tana_dan_to;
			}
			set
			{
				this._tana_dan_to = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_GYOSYA_KB(店舗／業者)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_gyosya_kb
		{
			get
			{
				return this._tenpo_gyosya_kb;
			}
			set
			{
				this._tenpo_gyosya_kb = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKU_YMD_FROM(入力日)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryoku_ymd_from
		{
			get
			{
				return this._nyuryoku_ymd_from;
			}
			set
			{
				this._nyuryoku_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKU_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryoku_ymd_to
		{
			get
			{
				return this._nyuryoku_ymd_to;
			}
			set
			{
				this._nyuryoku_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_YMD_FROM(送信日)」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_ymd_from
		{
			get
			{
				return this._sosin_ymd_from;
			}
			set
			{
				this._sosin_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_ymd_to
		{
			get
			{
				return this._sosin_ymd_to;
			}
			set
			{
				this._sosin_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_cd
		{
			get
			{
				return this._nyuryokutan_cd;
			}
			set
			{
				this._nyuryokutan_cd = value;
			}
		}
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryokutan_nm
		{
			get
			{
				return this._nyuryokutan_nm;
			}
			set
			{
				this._nyuryokutan_nm = value;
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
		/// 項目「SOSIN_JYOTAI(送信状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_jyotai
		{
			get
			{
				return this._sosin_jyotai;
			}
			set
			{
				this._sosin_jyotai = value;
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
		/// 項目「SCAN_CD2()」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd2
		{
			get
			{
				return this._scan_cd2;
			}
			set
			{
				this._scan_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD3()」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd3
		{
			get
			{
				return this._scan_cd3;
			}
			set
			{
				this._scan_cd3 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD4()」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd4
		{
			get
			{
				return this._scan_cd4;
			}
			set
			{
				this._scan_cd4 = value;
			}
		}
		/// <summary>
		/// 項目「SCAN_CD5()」の値を取得または設定する。
		/// </summary>
		public virtual string Scan_cd5
		{
			get
			{
				return this._scan_cd5;
			}
			set
			{
				this._scan_cd5 = value;
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
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj030f01ResultVO() : base()
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
			sb.Append("Face_no_from:").Append(this._face_no_from).AppendLine();
			sb.Append("Face_no_to:").Append(this._face_no_to).AppendLine();
			sb.Append("Tana_dan_from:").Append(this._tana_dan_from).AppendLine();
			sb.Append("Tana_dan_to:").Append(this._tana_dan_to).AppendLine();
			sb.Append("Tenpo_gyosya_kb:").Append(this._tenpo_gyosya_kb).AppendLine();
			sb.Append("Nyuryoku_ymd_from:").Append(this._nyuryoku_ymd_from).AppendLine();
			sb.Append("Nyuryoku_ymd_to:").Append(this._nyuryoku_ymd_to).AppendLine();
			sb.Append("Sosin_ymd_from:").Append(this._sosin_ymd_from).AppendLine();
			sb.Append("Sosin_ymd_to:").Append(this._sosin_ymd_to).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Old_jisya_hbn2:").Append(this._old_jisya_hbn2).AppendLine();
			sb.Append("Old_jisya_hbn3:").Append(this._old_jisya_hbn3).AppendLine();
			sb.Append("Old_jisya_hbn4:").Append(this._old_jisya_hbn4).AppendLine();
			sb.Append("Old_jisya_hbn5:").Append(this._old_jisya_hbn5).AppendLine();
			sb.Append("Sosin_jyotai:").Append(this._sosin_jyotai).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Scan_cd2:").Append(this._scan_cd2).AppendLine();
			sb.Append("Scan_cd3:").Append(this._scan_cd3).AppendLine();
			sb.Append("Scan_cd4:").Append(this._scan_cd4).AppendLine();
			sb.Append("Scan_cd5:").Append(this._scan_cd5).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
