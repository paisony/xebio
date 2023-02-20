using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj170p01.VO
{
  /// <summary>
  /// Tj170f01のResultVOクラスです。
  /// </summary>
  [Serializable]
	public class Tj170f01ResultVO : StandardBaseVO
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
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD()」の値
		/// </summary>
		private string _tanaorosikijun_ymd;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(棚卸実施日)」の値
		/// </summary>
		private string _tanaorosijissi_ymd1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(棚卸期間FROM)」の値
		/// </summary>
		private string _tanaorosikikan_from1;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1(棚卸期間TO)」の値
		/// </summary>
		private string _tanaorosikikan_to1;
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1()」の値
		/// </summary>
		private string _tanaorosikijun_ymd1;
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD11(棚卸実施日)」の値
		/// </summary>
		private string _tanaorosijissi_ymd11;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM11(棚卸期間FROM)」の値
		/// </summary>
		private string _tanaorosikikan_from11;
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO11(棚卸期間TO)」の値
		/// </summary>
		private string _tanaorosikikan_to11;
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
		/// 項目「LOSS_TENSU(ロス点数)」の値
		/// </summary>
		private string _loss_tensu;
		/// <summary>
		/// 項目「LOSS_ARI_FLG(ロス有のみ)」の値
		/// </summary>
		private string _loss_ari_flg;
		/// <summary>
		/// 項目「SHUTURYOKU_TANI(出力単位)」の値
		/// </summary>
		private string _shuturyoku_tani;
		/// <summary>
		/// 項目「SORT_JUN(ソート順)」の値
		/// </summary>
		private string _sort_jun;
		/// <summary>
		/// 項目「SEARCHCNT()」の値
		/// </summary>
		private string _searchcnt;
		/// <summary>
		/// 項目「SHUTURYOKU_PRINT(出力帳票)」の値
		/// </summary>
		private string _shuturyoku_print;

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
		/// 項目「TANAOROSIKIJUN_YMD()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikijun_ymd
		{
			get
			{
				return this._tanaorosikijun_ymd;
			}
			set
			{
				this._tanaorosikijun_ymd = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD1(棚卸実施日)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosijissi_ymd1
		{
			get
			{
				return this._tanaorosijissi_ymd1;
			}
			set
			{
				this._tanaorosijissi_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM1(棚卸期間FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_from1
		{
			get
			{
				return this._tanaorosikikan_from1;
			}
			set
			{
				this._tanaorosikikan_from1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO1(棚卸期間TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_to1
		{
			get
			{
				return this._tanaorosikikan_to1;
			}
			set
			{
				this._tanaorosikikan_to1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIJUN_YMD1()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikijun_ymd1
		{
			get
			{
				return this._tanaorosikijun_ymd1;
			}
			set
			{
				this._tanaorosikijun_ymd1 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIJISSI_YMD11(棚卸実施日)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosijissi_ymd11
		{
			get
			{
				return this._tanaorosijissi_ymd11;
			}
			set
			{
				this._tanaorosijissi_ymd11 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_FROM11(棚卸期間FROM)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_from11
		{
			get
			{
				return this._tanaorosikikan_from11;
			}
			set
			{
				this._tanaorosikikan_from11 = value;
			}
		}
		/// <summary>
		/// 項目「TANAOROSIKIKAN_TO11(棚卸期間TO)」の値を取得または設定する。
		/// </summary>
		public virtual string Tanaorosikikan_to11
		{
			get
			{
				return this._tanaorosikikan_to11;
			}
			set
			{
				this._tanaorosikikan_to11 = value;
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
		/// 項目「LOSS_TENSU(ロス点数)」の値を取得または設定する。
		/// </summary>
		public virtual string Loss_tensu
		{
			get
			{
				return this._loss_tensu;
			}
			set
			{
				this._loss_tensu = value;
			}
		}
		/// <summary>
		/// 項目「LOSS_ARI_FLG(ロス有のみ)」の値を取得または設定する。
		/// </summary>
		public virtual string Loss_ari_flg
		{
			get
			{
				return this._loss_ari_flg;
			}
			set
			{
				this._loss_ari_flg = value;
			}
		}
		/// <summary>
		/// 項目「SHUTURYOKU_TANI(出力単位)」の値を取得または設定する。
		/// </summary>
		public virtual string Shuturyoku_tani
		{
			get
			{
				return this._shuturyoku_tani;
			}
			set
			{
				this._shuturyoku_tani = value;
			}
		}
		/// <summary>
		/// 項目「SORT_JUN(ソート順)」の値を取得または設定する。
		/// </summary>
		public virtual string Sort_jun
		{
			get
			{
				return this._sort_jun;
			}
			set
			{
				this._sort_jun = value;
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
		/// 項目「SHUTURYOKU_PRINT(出力帳票)」の値を取得または設定する。
		/// </summary>
		public virtual string Shuturyoku_print
		{
			get
			{
				return this._shuturyoku_print;
			}
			set
			{
				this._shuturyoku_print = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj170f01ResultVO() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Tanaorosikijun_ymd:").Append(this._tanaorosikijun_ymd).AppendLine();
			sb.Append("Tanaorosijissi_ymd1:").Append(this._tanaorosijissi_ymd1).AppendLine();
			sb.Append("Tanaorosikikan_from1:").Append(this._tanaorosikikan_from1).AppendLine();
			sb.Append("Tanaorosikikan_to1:").Append(this._tanaorosikikan_to1).AppendLine();
			sb.Append("Tanaorosikijun_ymd1:").Append(this._tanaorosikijun_ymd1).AppendLine();
			sb.Append("Tanaorosijissi_ymd11:").Append(this._tanaorosijissi_ymd11).AppendLine();
			sb.Append("Tanaorosikikan_from11:").Append(this._tanaorosikikan_from11).AppendLine();
			sb.Append("Tanaorosikikan_to11:").Append(this._tanaorosikikan_to11).AppendLine();
			sb.Append("Syohingun1_cd:").Append(this._syohingun1_cd).AppendLine();
			sb.Append("Syohingun1_ryaku_nm:").Append(this._syohingun1_ryaku_nm).AppendLine();
			sb.Append("Syohingun2_cd:").Append(this._syohingun2_cd).AppendLine();
			sb.Append("Grpnm:").Append(this._grpnm).AppendLine();
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
			sb.Append("Loss_tensu:").Append(this._loss_tensu).AppendLine();
			sb.Append("Loss_ari_flg:").Append(this._loss_ari_flg).AppendLine();
			sb.Append("Shuturyoku_tani:").Append(this._shuturyoku_tani).AppendLine();
			sb.Append("Sort_jun:").Append(this._sort_jun).AppendLine();
			sb.Append("Searchcnt:").Append(this._searchcnt).AppendLine();
			sb.Append("Shuturyoku_print:").Append(this._shuturyoku_print).AppendLine();
		
			sb.AppendLine();
			sb.AppendLine("M1明細部：");
			sb.Append(this.GetList("M1")).AppendLine();

			return sb.ToString();
		}
		#endregion
	}
}
