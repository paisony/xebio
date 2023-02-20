using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Td060p01.VO
{
  /// <summary>
  /// Td060f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Td060f01ResultVO : StandardBaseVO
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
		/// 項目「SHUTURYOKU_KBN(出力区分)」の値
		/// </summary>
		private string _shuturyoku_kbn;
		/// <summary>
		/// 項目「CHANGE_YMD_FROM(変更日FROM)」の値
		/// </summary>
		private string _change_ymd_from;
		/// <summary>
		/// 項目「CHANGE_YMD_TO(変更日TO)」の値
		/// </summary>
		private string _change_ymd_to;
		/// <summary>
		/// 項目「CHANGE_YMD_HDN()」の値
		/// </summary>
		private string _change_ymd_hdn;

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
		/// 項目「SHUTURYOKU_KBN(出力区分)」の値を取得または設定する。
		/// </summary>
		public virtual string Shuturyoku_kbn
		{
			get
			{
				return this._shuturyoku_kbn;
			}
			set
			{
				this._shuturyoku_kbn = value;
			}
		}
		/// <summary>
		/// 項目「CHANGE_YMD_FROM(変更日FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Change_ymd_from
		{
			get
			{
				return this._change_ymd_from;
			}
			set
			{
				this._change_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「CHANGE_YMD_TO(変更日TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Change_ymd_to
		{
			get
			{
				return this._change_ymd_to;
			}
			set
			{
				this._change_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「CHANGE_YMD_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string Change_ymd_hdn
		{
			get
			{
				return this._change_ymd_hdn;
			}
			set
			{
				this._change_ymd_hdn = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td060f01ResultVO() : base()
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
			sb.Append("Shuturyoku_kbn:").Append(this._shuturyoku_kbn).AppendLine();
			sb.Append("Change_ymd_from:").Append(this._change_ymd_from).AppendLine();
			sb.Append("Change_ymd_to:").Append(this._change_ymd_to).AppendLine();
			sb.Append("Change_ymd_hdn:").Append(this._change_ymd_hdn).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
