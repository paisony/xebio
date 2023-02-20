using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf070p01.VO
{
  /// <summary>
  /// Tf070f02のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tf070f02ResultVO : StandardBaseVO
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
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「TONANHINKANRI_NO(管理番号)」の値
		/// </summary>
		private string _tonanhinkanri_no;
		/// <summary>
		/// 項目「JIKOHASSEI_YMD(事故発生日)」の値
		/// </summary>
		private string _jikohassei_ymd;
		/// <summary>
		/// 項目「HOKOKU_YMD(報告日)」の値
		/// </summary>
		private string _hokoku_ymd;
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告者)」の値
		/// </summary>
		private string _hokokutan_cd;
		/// <summary>
		/// 項目「HOKOKUTAN_NM()」の値
		/// </summary>
		private string _hokokutan_nm;
		/// <summary>
		/// 項目「TENTYOTAN_CD(店長)」の値
		/// </summary>
		private string _tentyotan_cd;
		/// <summary>
		/// 項目「TENTYOTAN_NM()」の値
		/// </summary>
		private string _tentyotan_nm;
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD(警察届出日)」の値
		/// </summary>
		private string _keisatsutodoke_ymd;
		/// <summary>
		/// 項目「TODOKEDESAKIKEISATSU_NM(届出警察署)」の値
		/// </summary>
		private string _todokedesakikeisatsu_nm;
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値
		/// </summary>
		private string _jyuri_no;
		/// <summary>
		/// 項目「GOKEISINSEI_SU(合計)」の値
		/// </summary>
		private string _gokeisinsei_su;
		/// <summary>
		/// 項目「GOKEIJYURI_SU()」の値
		/// </summary>
		private string _gokeijyuri_su;
		/// <summary>
		/// 項目「GOKEIBAIKA_KIN()」の値
		/// </summary>
		private string _gokeibaika_kin;

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
		/// 項目「TONANHINKANRI_NO(管理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Tonanhinkanri_no
		{
			get
			{
				return this._tonanhinkanri_no;
			}
			set
			{
				this._tonanhinkanri_no = value;
			}
		}
		/// <summary>
		/// 項目「JIKOHASSEI_YMD(事故発生日)」の値を取得または設定する。
		/// </summary>
		public virtual string Jikohassei_ymd
		{
			get
			{
				return this._jikohassei_ymd;
			}
			set
			{
				this._jikohassei_ymd = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKU_YMD(報告日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hokoku_ymd
		{
			get
			{
				return this._hokoku_ymd;
			}
			set
			{
				this._hokoku_ymd = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKUTAN_CD(報告者)」の値を取得または設定する。
		/// </summary>
		public virtual string Hokokutan_cd
		{
			get
			{
				return this._hokokutan_cd;
			}
			set
			{
				this._hokokutan_cd = value;
			}
		}
		/// <summary>
		/// 項目「HOKOKUTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hokokutan_nm
		{
			get
			{
				return this._hokokutan_nm;
			}
			set
			{
				this._hokokutan_nm = value;
			}
		}
		/// <summary>
		/// 項目「TENTYOTAN_CD(店長)」の値を取得または設定する。
		/// </summary>
		public virtual string Tentyotan_cd
		{
			get
			{
				return this._tentyotan_cd;
			}
			set
			{
				this._tentyotan_cd = value;
			}
		}
		/// <summary>
		/// 項目「TENTYOTAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tentyotan_nm
		{
			get
			{
				return this._tentyotan_nm;
			}
			set
			{
				this._tentyotan_nm = value;
			}
		}
		/// <summary>
		/// 項目「KEISATSUTODOKE_YMD(警察届出日)」の値を取得または設定する。
		/// </summary>
		public virtual string Keisatsutodoke_ymd
		{
			get
			{
				return this._keisatsutodoke_ymd;
			}
			set
			{
				this._keisatsutodoke_ymd = value;
			}
		}
		/// <summary>
		/// 項目「TODOKEDESAKIKEISATSU_NM(届出警察署)」の値を取得または設定する。
		/// </summary>
		public virtual string Todokedesakikeisatsu_nm
		{
			get
			{
				return this._todokedesakikeisatsu_nm;
			}
			set
			{
				this._todokedesakikeisatsu_nm = value;
			}
		}
		/// <summary>
		/// 項目「JYURI_NO(受理番号)」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuri_no
		{
			get
			{
				return this._jyuri_no;
			}
			set
			{
				this._jyuri_no = value;
			}
		}
		/// <summary>
		/// 項目「GOKEISINSEI_SU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeisinsei_su
		{
			get
			{
				return this._gokeisinsei_su;
			}
			set
			{
				this._gokeisinsei_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIJYURI_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeijyuri_su
		{
			get
			{
				return this._gokeijyuri_su;
			}
			set
			{
				this._gokeijyuri_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIBAIKA_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeibaika_kin
		{
			get
			{
				return this._gokeibaika_kin;
			}
			set
			{
				this._gokeibaika_kin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf070f02ResultVO() : base()
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
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Tonanhinkanri_no:").Append(this._tonanhinkanri_no).AppendLine();
			sb.Append("Jikohassei_ymd:").Append(this._jikohassei_ymd).AppendLine();
			sb.Append("Hokoku_ymd:").Append(this._hokoku_ymd).AppendLine();
			sb.Append("Hokokutan_cd:").Append(this._hokokutan_cd).AppendLine();
			sb.Append("Hokokutan_nm:").Append(this._hokokutan_nm).AppendLine();
			sb.Append("Tentyotan_cd:").Append(this._tentyotan_cd).AppendLine();
			sb.Append("Tentyotan_nm:").Append(this._tentyotan_nm).AppendLine();
			sb.Append("Keisatsutodoke_ymd:").Append(this._keisatsutodoke_ymd).AppendLine();
			sb.Append("Todokedesakikeisatsu_nm:").Append(this._todokedesakikeisatsu_nm).AppendLine();
			sb.Append("Jyuri_no:").Append(this._jyuri_no).AppendLine();
			sb.Append("Gokeisinsei_su:").Append(this._gokeisinsei_su).AppendLine();
			sb.Append("Gokeijyuri_su:").Append(this._gokeijyuri_su).AppendLine();
			sb.Append("Gokeibaika_kin:").Append(this._gokeibaika_kin).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
