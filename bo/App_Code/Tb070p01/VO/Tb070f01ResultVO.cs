using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tb070p01.VO
{
  /// <summary>
  /// Tb070f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tb070f01ResultVO : StandardBaseVO
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
		/// 項目「ADD_YMD_FROM(登録日)」の値
		/// </summary>
		private string _add_ymd_from;
		/// <summary>
		/// 項目「ADD_YMD_TO()」の値
		/// </summary>
		private string _add_ymd_to;

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
		/// 項目「ADD_YMD_FROM(登録日)」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_from
		{
			get
			{
				return this._add_ymd_from;
			}
			set
			{
				this._add_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「ADD_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Add_ymd_to
		{
			get
			{
				return this._add_ymd_to;
			}
			set
			{
				this._add_ymd_to = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb070f01ResultVO() : base()
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
			sb.Append("Add_ymd_from:").Append(this._add_ymd_from).AppendLine();
			sb.Append("Add_ymd_to:").Append(this._add_ymd_to).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
