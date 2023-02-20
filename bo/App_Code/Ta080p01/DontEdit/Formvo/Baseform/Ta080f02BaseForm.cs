using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Ta080p01.Formvo.Baseform
{
  /// <summary>
  /// Ta080f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「YOSAN_YMD(年月度)」の値
		/// </summary>
		private string _yosan_ymd;
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠ｸﾞﾙｰﾌﾟ)」の値
		/// </summary>
		private string _yosan_cd;
		/// <summary>
		/// 項目「YOSAN_NM()」の値
		/// </summary>
		private string _yosan_nm;
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値
		/// </summary>
		private string _yosan_kin;
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値
		/// </summary>
		private string _misinsei_su;
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値
		/// </summary>
		private string _misinsei_kin;
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値
		/// </summary>
		private string _apply_su;
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値
		/// </summary>
		private string _apply_kin;
		/// <summary>
		/// 項目「JISSEKI_SU_BO2(実績数)」の値
		/// </summary>
		private string _jisseki_su_bo2;
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値
		/// </summary>
		private string _jisseki_kin;
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値
		/// </summary>
		private string _zan_kin;

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
		/// 項目「YOSAN_YMD(年月度)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_ymd
		{
			get
			{
				return this._yosan_ymd;
			}
			set
			{
				this._yosan_ymd = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_CD(仕入枠ｸﾞﾙｰﾌﾟ)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_cd
		{
			get
			{
				return this._yosan_cd;
			}
			set
			{
				this._yosan_cd = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_nm
		{
			get
			{
				return this._yosan_nm;
			}
			set
			{
				this._yosan_nm = value;
			}
		}
		/// <summary>
		/// 項目「YOSAN_KIN(予算金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Yosan_kin
		{
			get
			{
				return this._yosan_kin;
			}
			set
			{
				this._yosan_kin = value;
			}
		}
		/// <summary>
		/// 項目「MISINSEI_SU(未申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string Misinsei_su
		{
			get
			{
				return this._misinsei_su;
			}
			set
			{
				this._misinsei_su = value;
			}
		}
		/// <summary>
		/// 項目「MISINSEI_KIN(未申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Misinsei_kin
		{
			get
			{
				return this._misinsei_kin;
			}
			set
			{
				this._misinsei_kin = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_SU(申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_su
		{
			get
			{
				return this._apply_su;
			}
			set
			{
				this._apply_su = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_KIN(申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_kin
		{
			get
			{
				return this._apply_kin;
			}
			set
			{
				this._apply_kin = value;
			}
		}
		/// <summary>
		/// 項目「JISSEKI_SU_BO2(実績数)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisseki_su_bo2
		{
			get
			{
				return this._jisseki_su_bo2;
			}
			set
			{
				this._jisseki_su_bo2 = value;
			}
		}
		/// <summary>
		/// 項目「JISSEKI_KIN(実績金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisseki_kin
		{
			get
			{
				return this._jisseki_kin;
			}
			set
			{
				this._jisseki_kin = value;
			}
		}
		/// <summary>
		/// 項目「ZAN_KIN(残金額)」の値を取得または設定する。
		/// </summary>
		public virtual string Zan_kin
		{
			get
			{
				return this._zan_kin;
			}
			set
			{
				this._zan_kin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080f02BaseForm() : base()
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
			sb.Append("Yosan_ymd:").Append(this._yosan_ymd).AppendLine();
			sb.Append("Yosan_cd:").Append(this._yosan_cd).AppendLine();
			sb.Append("Yosan_nm:").Append(this._yosan_nm).AppendLine();
			sb.Append("Yosan_kin:").Append(this._yosan_kin).AppendLine();
			sb.Append("Misinsei_su:").Append(this._misinsei_su).AppendLine();
			sb.Append("Misinsei_kin:").Append(this._misinsei_kin).AppendLine();
			sb.Append("Apply_su:").Append(this._apply_su).AppendLine();
			sb.Append("Apply_kin:").Append(this._apply_kin).AppendLine();
			sb.Append("Jisseki_su_bo2:").Append(this._jisseki_su_bo2).AppendLine();
			sb.Append("Jisseki_kin:").Append(this._jisseki_kin).AppendLine();
			sb.Append("Zan_kin:").Append(this._zan_kin).AppendLine();
		
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
			return "Ta080f02";
		}
		#endregion

		#endregion
	}
}
