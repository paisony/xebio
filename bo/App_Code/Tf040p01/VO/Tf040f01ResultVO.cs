using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tf040p01.VO
{
  /// <summary>
  /// Tf040f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tf040f01ResultVO : StandardBaseVO
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
		/// 項目「ZENJITU_ZANDAKA(前日残高)」の値
		/// </summary>
		private string _zenjitu_zandaka;
		/// <summary>
		/// 項目「ZENGETU_ZANDAKA(前月残高)」の値
		/// </summary>
		private string _zengetu_zandaka;
		/// <summary>
		/// 項目「GOKEI_ZANDAKA(残高)」の値
		/// </summary>
		private string _gokei_zandaka;

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
		/// 項目「ZENJITU_ZANDAKA(前日残高)」の値を取得または設定する。
		/// </summary>
		public virtual string Zenjitu_zandaka
		{
			get
			{
				return this._zenjitu_zandaka;
			}
			set
			{
				this._zenjitu_zandaka = value;
			}
		}
		/// <summary>
		/// 項目「ZENGETU_ZANDAKA(前月残高)」の値を取得または設定する。
		/// </summary>
		public virtual string Zengetu_zandaka
		{
			get
			{
				return this._zengetu_zandaka;
			}
			set
			{
				this._zengetu_zandaka = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_ZANDAKA(残高)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_zandaka
		{
			get
			{
				return this._gokei_zandaka;
			}
			set
			{
				this._gokei_zandaka = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf040f01ResultVO() : base()
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
			sb.Append("Zenjitu_zandaka:").Append(this._zenjitu_zandaka).AppendLine();
			sb.Append("Zengetu_zandaka:").Append(this._zengetu_zandaka).AppendLine();
			sb.Append("Gokei_zandaka:").Append(this._gokei_zandaka).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
