using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tl030p01.Formvo.Baseform
{
  /// <summary>
  /// Tl030f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl030f02BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

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
		/// 項目「SHINSEIMOTO_NM(申請元)」の値
		/// </summary>
		private string _shinseimoto_nm;
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値
		/// </summary>
		private string _sinseitan_cd;
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値
		/// </summary>
		private string _sinseitan_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「BAIHEN_SHIJI_NO(売変指示No.)」の値
		/// </summary>
		private string _baihen_shiji_no;
		/// <summary>
		/// 項目「BAIHEN_RIYU_NM(売変理由)」の値
		/// </summary>
		private string _baihen_riyu_nm;
		/// <summary>
		/// 項目「AIHENSAGYOKAISI_YMD(作業開始日)」の値
		/// </summary>
		private string _aihensagyokaisi_ymd;
		/// <summary>
		/// 項目「BAIHENKAISI_YMD(開始日)」の値
		/// </summary>
		private string _baihenkaisi_ymd;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
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
		/// 項目「SHINSEIMOTO_NM(申請元)」の値を取得または設定する。
		/// </summary>
		public virtual string Shinseimoto_nm
		{
			get
			{
				return this._shinseimoto_nm;
			}
			set
			{
				this._shinseimoto_nm = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_CD(申請担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_cd
		{
			get
			{
				return this._sinseitan_cd;
			}
			set
			{
				this._sinseitan_cd = value;
			}
		}
		/// <summary>
		/// 項目「SINSEITAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Sinseitan_nm
		{
			get
			{
				return this._sinseitan_nm;
			}
			set
			{
				this._sinseitan_nm = value;
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
		/// 項目「BAIHEN_SHIJI_NO(売変指示No.)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_shiji_no
		{
			get
			{
				return this._baihen_shiji_no;
			}
			set
			{
				this._baihen_shiji_no = value;
			}
		}
		/// <summary>
		/// 項目「BAIHEN_RIYU_NM(売変理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihen_riyu_nm
		{
			get
			{
				return this._baihen_riyu_nm;
			}
			set
			{
				this._baihen_riyu_nm = value;
			}
		}
		/// <summary>
		/// 項目「AIHENSAGYOKAISI_YMD(作業開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Aihensagyokaisi_ymd
		{
			get
			{
				return this._aihensagyokaisi_ymd;
			}
			set
			{
				this._aihensagyokaisi_ymd = value;
			}
		}
		/// <summary>
		/// 項目「BAIHENKAISI_YMD(開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string Baihenkaisi_ymd
		{
			get
			{
				return this._baihenkaisi_ymd;
			}
			set
			{
				this._baihenkaisi_ymd = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl030f02BaseForm() : base()
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
		public virtual IDataList GetList(string listId)
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
		public virtual void SetList(string listId, ICollection list)
		{
			if (listId.Equals("M1"))
			{
				m1List.SetAll(list);
			}
		}

		/// <summary>
		/// 明細の現在のページの画面表示分のリストを取得します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細の現在のページの画面表示分のリスト</returns>
		public virtual IList GetPageViewList(string listId)
		{
			if (listId.Equals("M1"))
			{
				return m1List.GetPageViewList();
			}
			return null;
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
			sb.Append("Shinseimoto_nm:").Append(this._shinseimoto_nm).AppendLine();
			sb.Append("Sinseitan_cd:").Append(this._sinseitan_cd).AppendLine();
			sb.Append("Sinseitan_nm:").Append(this._sinseitan_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Baihen_shiji_no:").Append(this._baihen_shiji_no).AppendLine();
			sb.Append("Baihen_riyu_nm:").Append(this._baihen_riyu_nm).AppendLine();
			sb.Append("Aihensagyokaisi_ymd:").Append(this._aihensagyokaisi_ymd).AppendLine();
			sb.Append("Baihenkaisi_ymd:").Append(this._baihenkaisi_ymd).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Tl030f02";
		}
		#endregion

		#endregion
	}
}
