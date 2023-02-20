using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj190p01.Formvo.Baseform
{
  /// <summary>
  /// Tj190f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj190f01BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「NYURYOKU_YMD_FROM(入力日FROM)」の値
		/// </summary>
		private string _nyuryoku_ymd_from;
		/// <summary>
		/// 項目「NYURYOKU_YMD_TO(入力日TO)」の値
		/// </summary>
		private string _nyuryoku_ymd_to;
		/// <summary>
		/// 項目「TENPO_CD_FROM(店舗FROM)」の値
		/// </summary>
		private string _tenpo_cd_from;
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値
		/// </summary>
		private string _tenpo_nm_from;
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗TO)」の値
		/// </summary>
		private string _tenpo_cd_to;
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値
		/// </summary>
		private string _tenpo_nm_to;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「BUMON_CD_FROM(部門FROM)」の値
		/// </summary>
		private string _bumon_cd_from;
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値
		/// </summary>
		private string _bumon_nm_from;
		/// <summary>
		/// 項目「HINSYU_CD_FROM(品種FROM)」の値
		/// </summary>
		private string _hinsyu_cd_from;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_FROM()」の値
		/// </summary>
		private string _hinsyu_ryaku_nm_from;
		/// <summary>
		/// 項目「BUMON_CD_TO(部門TO)」の値
		/// </summary>
		private string _bumon_cd_to;
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値
		/// </summary>
		private string _bumon_nm_to;
		/// <summary>
		/// 項目「HINSYU_CD_TO(品種TO)」の値
		/// </summary>
		private string _hinsyu_cd_to;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_TO()」の値
		/// </summary>
		private string _hinsyu_ryaku_nm_to;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「LOSS_KANRI_NO(ロス管理No)」の値
		/// </summary>
		private string _loss_kanri_no;
		/// <summary>
		/// 項目「MEISAI_SORT()」の値
		/// </summary>
		private string _meisai_sort;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
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
		/// 項目「NYURYOKU_YMD_FROM(入力日FROM)」の値を取得または設定する。
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
		/// 項目「NYURYOKU_YMD_TO(入力日TO)」の値を取得または設定する。
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
		/// 項目「TENPO_CD_FROM(店舗FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_from
		{
			get
			{
				return this._tenpo_cd_from;
			}
			set
			{
				this._tenpo_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_from
		{
			get
			{
				return this._tenpo_nm_from;
			}
			set
			{
				this._tenpo_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD_TO(店舗TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_to
		{
			get
			{
				return this._tenpo_cd_to;
			}
			set
			{
				this._tenpo_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm_to
		{
			get
			{
				return this._tenpo_nm_to;
			}
			set
			{
				this._tenpo_nm_to = value;
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
		/// 項目「BUMON_CD_FROM(部門FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_from
		{
			get
			{
				return this._bumon_cd_from;
			}
			set
			{
				this._bumon_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_from
		{
			get
			{
				return this._bumon_nm_from;
			}
			set
			{
				this._bumon_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD_FROM(品種FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd_from
		{
			get
			{
				return this._hinsyu_cd_from;
			}
			set
			{
				this._hinsyu_cd_from = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_FROM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_ryaku_nm_from
		{
			get
			{
				return this._hinsyu_ryaku_nm_from;
			}
			set
			{
				this._hinsyu_ryaku_nm_from = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_CD_TO(部門TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_to
		{
			get
			{
				return this._bumon_cd_to;
			}
			set
			{
				this._bumon_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「BUMON_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_nm_to
		{
			get
			{
				return this._bumon_nm_to;
			}
			set
			{
				this._bumon_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD_TO(品種TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd_to
		{
			get
			{
				return this._hinsyu_cd_to;
			}
			set
			{
				this._hinsyu_cd_to = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_ryaku_nm_to
		{
			get
			{
				return this._hinsyu_ryaku_nm_to;
			}
			set
			{
				this._hinsyu_ryaku_nm_to = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd
		{
			get
			{
				return this._burando_cd;
			}
			set
			{
				this._burando_cd = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm
		{
			get
			{
				return this._burando_nm;
			}
			set
			{
				this._burando_nm = value;
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
		/// 項目「LOSS_KANRI_NO(ロス管理No)」の値を取得または設定する。
		/// </summary>
		public virtual string Loss_kanri_no
		{
			get
			{
				return this._loss_kanri_no;
			}
			set
			{
				this._loss_kanri_no = value;
			}
		}
		/// <summary>
		/// 項目「MEISAI_SORT()」の値を取得または設定する。
		/// </summary>
		public virtual string Meisai_sort
		{
			get
			{
				return this._meisai_sort;
			}
			set
			{
				this._meisai_sort = value;
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
		public Tj190f01BaseForm() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Nyuryoku_ymd_from:").Append(this._nyuryoku_ymd_from).AppendLine();
			sb.Append("Nyuryoku_ymd_to:").Append(this._nyuryoku_ymd_to).AppendLine();
			sb.Append("Tenpo_cd_from:").Append(this._tenpo_cd_from).AppendLine();
			sb.Append("Tenpo_nm_from:").Append(this._tenpo_nm_from).AppendLine();
			sb.Append("Tenpo_cd_to:").Append(this._tenpo_cd_to).AppendLine();
			sb.Append("Tenpo_nm_to:").Append(this._tenpo_nm_to).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Bumon_cd_from:").Append(this._bumon_cd_from).AppendLine();
			sb.Append("Bumon_nm_from:").Append(this._bumon_nm_from).AppendLine();
			sb.Append("Hinsyu_cd_from:").Append(this._hinsyu_cd_from).AppendLine();
			sb.Append("Hinsyu_ryaku_nm_from:").Append(this._hinsyu_ryaku_nm_from).AppendLine();
			sb.Append("Bumon_cd_to:").Append(this._bumon_cd_to).AppendLine();
			sb.Append("Bumon_nm_to:").Append(this._bumon_nm_to).AppendLine();
			sb.Append("Hinsyu_cd_to:").Append(this._hinsyu_cd_to).AppendLine();
			sb.Append("Hinsyu_ryaku_nm_to:").Append(this._hinsyu_ryaku_nm_to).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Loss_kanri_no:").Append(this._loss_kanri_no).AppendLine();
			sb.Append("Meisai_sort:").Append(this._meisai_sort).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Gokeitanajityobo_su:").Append(this._gokeitanajityobo_su).AppendLine();
			sb.Append("Gokeitanajisekiso_su:").Append(this._gokeitanajisekiso_su).AppendLine();
			sb.Append("Gokeijitana_su:").Append(this._gokeijitana_su).AppendLine();
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
			return "Tj190f01";
		}
		#endregion

		#endregion
	}
}
