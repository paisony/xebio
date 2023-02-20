using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj190p01.Formvo.Baseform
{
  /// <summary>
  /// Tj190f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj190f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「TENPO_CD_HDN()」の値
		/// </summary>
		private string _tenpo_cd_hdn;
		/// <summary>
		/// 項目「NYURYOKU_YMD(入力日)」の値
		/// </summary>
		private string _nyuryoku_ymd;
		/// <summary>
		/// 項目「RINTANA_KANRI_NO(臨棚管理No)」の値
		/// </summary>
		private string _rintana_kanri_no;
		/// <summary>
		/// 項目「LOSS_KANRI_NO(ロス管理No)」の値
		/// </summary>
		private string _loss_kanri_no;
		/// <summary>
		/// 項目「BUMON_CD_BO(部門)」の値
		/// </summary>
		private string _bumon_cd_bo;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「NYURYOKUTAN_CD(入力担当者)」の値
		/// </summary>
		private string _nyuryokutan_cd;
		/// <summary>
		/// 項目「NYURYOKUTAN_NM()」の値
		/// </summary>
		private string _nyuryokutan_nm;
		/// <summary>
		/// 項目「LOSSKEISAN_YMD(ロス計算日)」の値
		/// </summary>
		private string _losskeisan_ymd;
		/// <summary>
		/// 項目「LOSSKEISAN_TM()」の値
		/// </summary>
		private string _losskeisan_tm;
		/// <summary>
		/// 項目「HINSYU_SITEI_FLG()」の値
		/// </summary>
		private string _hinsyu_sitei_flg;
		/// <summary>
		/// 項目「HINSYU_CD(品種)」の値
		/// </summary>
		private string _hinsyu_cd;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM()」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_SITEI_FLG()」の値
		/// </summary>
		private string _burando_sitei_flg;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド1)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「BURANDO_CD1(ブランド2)」の値
		/// </summary>
		private string _burando_cd1;
		/// <summary>
		/// 項目「BURANDO_NM1()」の値
		/// </summary>
		private string _burando_nm1;
		/// <summary>
		/// 項目「BURANDO_CD2(ブランド3)」の値
		/// </summary>
		private string _burando_cd2;
		/// <summary>
		/// 項目「BURANDO_NM2()」の値
		/// </summary>
		private string _burando_nm2;
		/// <summary>
		/// 項目「BURANDO_CD3(ブランド4)」の値
		/// </summary>
		private string _burando_cd3;
		/// <summary>
		/// 項目「BURANDO_NM3()」の値
		/// </summary>
		private string _burando_nm3;
		/// <summary>
		/// 項目「BURANDO_CD4(ブランド5)」の値
		/// </summary>
		private string _burando_cd4;
		/// <summary>
		/// 項目「BURANDO_NM4()」の値
		/// </summary>
		private string _burando_nm4;
		/// <summary>
		/// 項目「BURANDO_CD5(ブランド6)」の値
		/// </summary>
		private string _burando_cd5;
		/// <summary>
		/// 項目「BURANDO_NM5()」の値
		/// </summary>
		private string _burando_nm5;
		/// <summary>
		/// 項目「BURANDO_CD6(ブランド7)」の値
		/// </summary>
		private string _burando_cd6;
		/// <summary>
		/// 項目「BURANDO_NM6()」の値
		/// </summary>
		private string _burando_nm6;
		/// <summary>
		/// 項目「BURANDO_CD7(ブランド8)」の値
		/// </summary>
		private string _burando_cd7;
		/// <summary>
		/// 項目「BURANDO_NM7()」の値
		/// </summary>
		private string _burando_nm7;
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
		/// 項目「TENPO_CD_HDN()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd_hdn
		{
			get
			{
				return this._tenpo_cd_hdn;
			}
			set
			{
				this._tenpo_cd_hdn = value;
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
		/// 項目「RINTANA_KANRI_NO(臨棚管理No)」の値を取得または設定する。
		/// </summary>
		public virtual string Rintana_kanri_no
		{
			get
			{
				return this._rintana_kanri_no;
			}
			set
			{
				this._rintana_kanri_no = value;
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
		/// 項目「BUMON_CD_BO(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string Bumon_cd_bo
		{
			get
			{
				return this._bumon_cd_bo;
			}
			set
			{
				this._bumon_cd_bo = value;
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
		/// 項目「LOSSKEISAN_YMD(ロス計算日)」の値を取得または設定する。
		/// </summary>
		public virtual string Losskeisan_ymd
		{
			get
			{
				return this._losskeisan_ymd;
			}
			set
			{
				this._losskeisan_ymd = value;
			}
		}
		/// <summary>
		/// 項目「LOSSKEISAN_TM()」の値を取得または設定する。
		/// </summary>
		public virtual string Losskeisan_tm
		{
			get
			{
				return this._losskeisan_tm;
			}
			set
			{
				this._losskeisan_tm = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_SITEI_FLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_sitei_flg
		{
			get
			{
				return this._hinsyu_sitei_flg;
			}
			set
			{
				this._hinsyu_sitei_flg = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_CD(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_cd
		{
			get
			{
				return this._hinsyu_cd;
			}
			set
			{
				this._hinsyu_cd = value;
			}
		}
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Hinsyu_ryaku_nm
		{
			get
			{
				return this._hinsyu_ryaku_nm;
			}
			set
			{
				this._hinsyu_ryaku_nm = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_SITEI_FLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_sitei_flg
		{
			get
			{
				return this._burando_sitei_flg;
			}
			set
			{
				this._burando_sitei_flg = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD(ブランド1)」の値を取得または設定する。
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
		/// 項目「BURANDO_CD1(ブランド2)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd1
		{
			get
			{
				return this._burando_cd1;
			}
			set
			{
				this._burando_cd1 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM1()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm1
		{
			get
			{
				return this._burando_nm1;
			}
			set
			{
				this._burando_nm1 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD2(ブランド3)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd2
		{
			get
			{
				return this._burando_cd2;
			}
			set
			{
				this._burando_cd2 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM2()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm2
		{
			get
			{
				return this._burando_nm2;
			}
			set
			{
				this._burando_nm2 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD3(ブランド4)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd3
		{
			get
			{
				return this._burando_cd3;
			}
			set
			{
				this._burando_cd3 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM3()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm3
		{
			get
			{
				return this._burando_nm3;
			}
			set
			{
				this._burando_nm3 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD4(ブランド5)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd4
		{
			get
			{
				return this._burando_cd4;
			}
			set
			{
				this._burando_cd4 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM4()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm4
		{
			get
			{
				return this._burando_nm4;
			}
			set
			{
				this._burando_nm4 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD5(ブランド6)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd5
		{
			get
			{
				return this._burando_cd5;
			}
			set
			{
				this._burando_cd5 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM5()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm5
		{
			get
			{
				return this._burando_nm5;
			}
			set
			{
				this._burando_nm5 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD6(ブランド7)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd6
		{
			get
			{
				return this._burando_cd6;
			}
			set
			{
				this._burando_cd6 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM6()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm6
		{
			get
			{
				return this._burando_nm6;
			}
			set
			{
				this._burando_nm6 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_CD7(ブランド8)」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_cd7
		{
			get
			{
				return this._burando_cd7;
			}
			set
			{
				this._burando_cd7 = value;
			}
		}
		/// <summary>
		/// 項目「BURANDO_NM7()」の値を取得または設定する。
		/// </summary>
		public virtual string Burando_nm7
		{
			get
			{
				return this._burando_nm7;
			}
			set
			{
				this._burando_nm7 = value;
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
		public Tj190f02BaseForm() : base()
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
			sb.Append("Tenpo_cd_hdn:").Append(this._tenpo_cd_hdn).AppendLine();
			sb.Append("Nyuryoku_ymd:").Append(this._nyuryoku_ymd).AppendLine();
			sb.Append("Rintana_kanri_no:").Append(this._rintana_kanri_no).AppendLine();
			sb.Append("Loss_kanri_no:").Append(this._loss_kanri_no).AppendLine();
			sb.Append("Bumon_cd_bo:").Append(this._bumon_cd_bo).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Nyuryokutan_cd:").Append(this._nyuryokutan_cd).AppendLine();
			sb.Append("Nyuryokutan_nm:").Append(this._nyuryokutan_nm).AppendLine();
			sb.Append("Losskeisan_ymd:").Append(this._losskeisan_ymd).AppendLine();
			sb.Append("Losskeisan_tm:").Append(this._losskeisan_tm).AppendLine();
			sb.Append("Hinsyu_sitei_flg:").Append(this._hinsyu_sitei_flg).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Burando_sitei_flg:").Append(this._burando_sitei_flg).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Burando_cd1:").Append(this._burando_cd1).AppendLine();
			sb.Append("Burando_nm1:").Append(this._burando_nm1).AppendLine();
			sb.Append("Burando_cd2:").Append(this._burando_cd2).AppendLine();
			sb.Append("Burando_nm2:").Append(this._burando_nm2).AppendLine();
			sb.Append("Burando_cd3:").Append(this._burando_cd3).AppendLine();
			sb.Append("Burando_nm3:").Append(this._burando_nm3).AppendLine();
			sb.Append("Burando_cd4:").Append(this._burando_cd4).AppendLine();
			sb.Append("Burando_nm4:").Append(this._burando_nm4).AppendLine();
			sb.Append("Burando_cd5:").Append(this._burando_cd5).AppendLine();
			sb.Append("Burando_nm5:").Append(this._burando_nm5).AppendLine();
			sb.Append("Burando_cd6:").Append(this._burando_cd6).AppendLine();
			sb.Append("Burando_nm6:").Append(this._burando_nm6).AppendLine();
			sb.Append("Burando_cd7:").Append(this._burando_cd7).AppendLine();
			sb.Append("Burando_nm7:").Append(this._burando_nm7).AppendLine();
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
			return "Tj190f02";
		}
		#endregion

		#endregion
	}
}
