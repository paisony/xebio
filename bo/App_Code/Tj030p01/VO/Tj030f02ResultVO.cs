using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj030p01.VO
{
  /// <summary>
  /// Tj030f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj030f02ResultVO : StandardBaseVO
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
		/// 項目「FACE_NO(フェイスNo)」の値
		/// </summary>
		private string _face_no;
		/// <summary>
		/// 項目「TANA_DAN(棚段)」の値
		/// </summary>
		private string _tana_dan;
		/// <summary>
		/// 項目「KAI_SU(回数)」の値
		/// </summary>
		private string _kai_su;
		/// <summary>
		/// 項目「TENPO_GYOSYA_NM(店舗／業者)」の値
		/// </summary>
		private string _tenpo_gyosya_nm;
		/// <summary>
		/// 項目「TENPO_GYOSYA_KB()」の値
		/// </summary>
		private string _tenpo_gyosya_kb;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「NYURYOKU_YMD(入力日)」の値
		/// </summary>
		private string _nyuryoku_ymd;
		/// <summary>
		/// 項目「SOSIN_YMD(送信日)」の値
		/// </summary>
		private string _sosin_ymd;
		/// <summary>
		/// 項目「GOKEISCAN_SU(合計)」の値
		/// </summary>
		private string _gokeiscan_su;

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
		/// 項目「FACE_NO(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string Face_no
		{
			get
			{
				return this._face_no;
			}
			set
			{
				this._face_no = value;
			}
		}
		/// <summary>
		/// 項目「TANA_DAN(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string Tana_dan
		{
			get
			{
				return this._tana_dan;
			}
			set
			{
				this._tana_dan = value;
			}
		}
		/// <summary>
		/// 項目「KAI_SU(回数)」の値を取得または設定する。
		/// </summary>
		public virtual string Kai_su
		{
			get
			{
				return this._kai_su;
			}
			set
			{
				this._kai_su = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_GYOSYA_NM(店舗／業者)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_gyosya_nm
		{
			get
			{
				return this._tenpo_gyosya_nm;
			}
			set
			{
				this._tenpo_gyosya_nm = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_GYOSYA_KB()」の値を取得または設定する。
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
		/// 項目「NYURYOKU_YMD(入力日)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyuryoku_ymd
		{
			get
			{
				return this._nyuryoku_ymd;
			}
			set
			{
				this._nyuryoku_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SOSIN_YMD(送信日)」の値を取得または設定する。
		/// </summary>
		public virtual string Sosin_ymd
		{
			get
			{
				return this._sosin_ymd;
			}
			set
			{
				this._sosin_ymd = value;
			}
		}
		/// <summary>
		/// 項目「GOKEISCAN_SU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeiscan_su
		{
			get
			{
				return this._gokeiscan_su;
			}
			set
			{
				this._gokeiscan_su = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj030f02ResultVO() : base()
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
			sb.Append("Face_no:").Append(this._face_no).AppendLine();
			sb.Append("Tana_dan:").Append(this._tana_dan).AppendLine();
			sb.Append("Kai_su:").Append(this._kai_su).AppendLine();
			sb.Append("Tenpo_gyosya_nm:").Append(this._tenpo_gyosya_nm).AppendLine();
			sb.Append("Tenpo_gyosya_kb:").Append(this._tenpo_gyosya_kb).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Nyuryoku_ymd:").Append(this._nyuryoku_ymd).AppendLine();
			sb.Append("Sosin_ymd:").Append(this._sosin_ymd).AppendLine();
			sb.Append("Gokeiscan_su:").Append(this._gokeiscan_su).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
