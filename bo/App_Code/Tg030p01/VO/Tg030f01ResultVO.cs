using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tg030p01.VO
{
  /// <summary>
  /// Tg030f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tg030f01ResultVO : StandardBaseVO
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
		/// 項目「MAISU(発行枚数)」の値
		/// </summary>
		private string _maisu;
		/// <summary>
		/// 項目「TANTOSYA_CD(社員コード)」の値
		/// </summary>
		private string _tantosya_cd;
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値
		/// </summary>
		private string _hanbaiin_nm;
		/// <summary>
		/// 項目「TANTOSYA_CD2(社員コード（確認用）)」の値
		/// </summary>
		private string _tantosya_cd2;
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
		/// 項目「MAISU(発行枚数)」の値を取得または設定する。
		/// </summary>
		public virtual string Maisu
		{
			get
			{
				return this._maisu;
			}
			set
			{
				this._maisu = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD(社員コード)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd
		{
			get
			{
				return this._tantosya_cd;
			}
			set
			{
				this._tantosya_cd = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaiin_nm
		{
			get
			{
				return this._hanbaiin_nm;
			}
			set
			{
				this._hanbaiin_nm = value;
			}
		}
		/// <summary>
		/// 項目「TANTOSYA_CD2(社員コード（確認用）)」の値を取得または設定する。
		/// </summary>
		public virtual string Tantosya_cd2
		{
			get
			{
				return this._tantosya_cd2;
			}
			set
			{
				this._tantosya_cd2 = value;
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
		public Tg030f01ResultVO() : base()
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
			sb.Append("Maisu:").Append(this._maisu).AppendLine();
			sb.Append("Tantosya_cd:").Append(this._tantosya_cd).AppendLine();
			sb.Append("Hanbaiin_nm:").Append(this._hanbaiin_nm).AppendLine();
			sb.Append("Tantosya_cd2:").Append(this._tantosya_cd2).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
