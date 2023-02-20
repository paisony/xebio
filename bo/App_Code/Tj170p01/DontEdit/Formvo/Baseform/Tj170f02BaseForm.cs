using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj170p01.Formvo.Baseform
{
  /// <summary>
  /// Tj170f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj170f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「SYOHINGUN1_CD(商品群1)」の値
		/// </summary>
		private string _syohingun1_cd;
		/// <summary>
		/// 項目「SYOHINGUN1_RYAKU_NM()」の値
		/// </summary>
		private string _syohingun1_ryaku_nm;
		/// <summary>
		/// 項目「SYOHINGUN2_CD(商品群2)」の値
		/// </summary>
		private string _syohingun2_cd;
		/// <summary>
		/// 項目「GRPNM()」の値
		/// </summary>
		private string _grpnm;
		/// <summary>
		/// 項目「GOKEITANAJITYOBO_SU(合計)」の値
		/// </summary>
		private string _gokeitanajityobo_su;
		/// <summary>
		/// 項目「GOKEITANAJISEKISO_SU()」の値
		/// </summary>
		private string _gokeitanajisekiso_su;
		/// <summary>
		/// 項目「GOKEIJITANA_SU()」の値
		/// </summary>
		private string _gokeijitana_su;
		/// <summary>
		/// 項目「GOKEIIKOUKEBARAI_SU()」の値
		/// </summary>
		private string _gokeiikoukebarai_su;
		/// <summary>
		/// 項目「GOKEIRIRONZAIKO_SU()」の値
		/// </summary>
		private string _gokeirironzaiko_su;
		/// <summary>
		/// 項目「GOKEIRIRONTANAOROSI_SU()」の値
		/// </summary>
		private string _gokeirirontanaorosi_su;
		/// <summary>
		/// 項目「GOKEILOSS_SU()」の値
		/// </summary>
		private string _gokeiloss_su;
		/// <summary>
		/// 項目「GOKEILOSS_KIN()」の値
		/// </summary>
		private string _gokeiloss_kin;

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
		/// 項目「SYOHINGUN1_CD(商品群1)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohingun1_cd
		{
			get
			{
				return this._syohingun1_cd;
			}
			set
			{
				this._syohingun1_cd = value;
			}
		}
		/// <summary>
		/// 項目「SYOHINGUN1_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Syohingun1_ryaku_nm
		{
			get
			{
				return this._syohingun1_ryaku_nm;
			}
			set
			{
				this._syohingun1_ryaku_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYOHINGUN2_CD(商品群2)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohingun2_cd
		{
			get
			{
				return this._syohingun2_cd;
			}
			set
			{
				this._syohingun2_cd = value;
			}
		}
		/// <summary>
		/// 項目「GRPNM()」の値を取得または設定する。
		/// </summary>
		public virtual string Grpnm
		{
			get
			{
				return this._grpnm;
			}
			set
			{
				this._grpnm = value;
			}
		}
		/// <summary>
		/// 項目「GOKEITANAJITYOBO_SU(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeitanajityobo_su
		{
			get
			{
				return this._gokeitanajityobo_su;
			}
			set
			{
				this._gokeitanajityobo_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEITANAJISEKISO_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeitanajisekiso_su
		{
			get
			{
				return this._gokeitanajisekiso_su;
			}
			set
			{
				this._gokeitanajisekiso_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIJITANA_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeijitana_su
		{
			get
			{
				return this._gokeijitana_su;
			}
			set
			{
				this._gokeijitana_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIIKOUKEBARAI_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeiikoukebarai_su
		{
			get
			{
				return this._gokeiikoukebarai_su;
			}
			set
			{
				this._gokeiikoukebarai_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIRIRONZAIKO_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeirironzaiko_su
		{
			get
			{
				return this._gokeirironzaiko_su;
			}
			set
			{
				this._gokeirironzaiko_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEIRIRONTANAOROSI_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeirirontanaorosi_su
		{
			get
			{
				return this._gokeirirontanaorosi_su;
			}
			set
			{
				this._gokeirirontanaorosi_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEILOSS_SU()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeiloss_su
		{
			get
			{
				return this._gokeiloss_su;
			}
			set
			{
				this._gokeiloss_su = value;
			}
		}
		/// <summary>
		/// 項目「GOKEILOSS_KIN()」の値を取得または設定する。
		/// </summary>
		public virtual string Gokeiloss_kin
		{
			get
			{
				return this._gokeiloss_kin;
			}
			set
			{
				this._gokeiloss_kin = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj170f02BaseForm() : base()
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
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Syohingun1_cd:").Append(this._syohingun1_cd).AppendLine();
			sb.Append("Syohingun1_ryaku_nm:").Append(this._syohingun1_ryaku_nm).AppendLine();
			sb.Append("Syohingun2_cd:").Append(this._syohingun2_cd).AppendLine();
			sb.Append("Grpnm:").Append(this._grpnm).AppendLine();
			sb.Append("Gokeitanajityobo_su:").Append(this._gokeitanajityobo_su).AppendLine();
			sb.Append("Gokeitanajisekiso_su:").Append(this._gokeitanajisekiso_su).AppendLine();
			sb.Append("Gokeijitana_su:").Append(this._gokeijitana_su).AppendLine();
			sb.Append("Gokeiikoukebarai_su:").Append(this._gokeiikoukebarai_su).AppendLine();
			sb.Append("Gokeirironzaiko_su:").Append(this._gokeirironzaiko_su).AppendLine();
			sb.Append("Gokeirirontanaorosi_su:").Append(this._gokeirirontanaorosi_su).AppendLine();
			sb.Append("Gokeiloss_su:").Append(this._gokeiloss_su).AppendLine();
			sb.Append("Gokeiloss_kin:").Append(this._gokeiloss_kin).AppendLine();
		
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
			return "Tj170f02";
		}
		#endregion

		#endregion
	}
}
