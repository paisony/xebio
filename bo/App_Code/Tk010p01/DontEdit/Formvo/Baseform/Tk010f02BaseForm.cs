﻿using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tk010p01.Formvo.Baseform
{
  /// <summary>
  /// Tk010f02のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk010f02BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SYORI_YM(処理月)」の値
		/// </summary>
		private string _syori_ym;
		/// <summary>
		/// 項目「TENPO_CD(店舗)」の値
		/// </summary>
		private string _tenpo_cd;
		/// <summary>
		/// 項目「TENPO_NM()」の値
		/// </summary>
		private string _tenpo_nm;
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値
		/// </summary>
		private string _syonin_flg_nm;
		/// <summary>
		/// 項目「KESSAI_FLG_NM(決裁状態)」の値
		/// </summary>
		private string _kessai_flg_nm;
		/// <summary>
		/// 項目「APPLY_YMD(申請日)」の値
		/// </summary>
		private string _apply_ymd;
		/// <summary>
		/// 項目「IKKATSUKYAKKA_KYAKKARIYU_KB(一括却下用却下理由)」の値
		/// </summary>
		private string _ikkatsukyakka_kyakkariyu_kb;
		/// <summary>
		/// 項目「IKKATSUKYAKKA_KYAKKARIYU()」の値
		/// </summary>
		private string _ikkatsukyakka_kyakkariyu;
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値
		/// </summary>
		private string _gokei_suryo;
		/// <summary>
		/// 項目「HAIBUN_KIN_GOKEI()」の値
		/// </summary>
		private string _haibun_kin_gokei;

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
		/// 項目「SYORI_YM(処理月)」の値を取得または設定する。
		/// </summary>
		public virtual string Syori_ym
		{
			get
			{
				return this._syori_ym;
			}
			set
			{
				this._syori_ym = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD(店舗)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_cd
		{
			get
			{
				return this._tenpo_cd;
			}
			set
			{
				this._tenpo_cd = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpo_nm
		{
			get
			{
				return this._tenpo_nm;
			}
			set
			{
				this._tenpo_nm = value;
			}
		}
		/// <summary>
		/// 項目「SYONIN_FLG_NM(承認状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonin_flg_nm
		{
			get
			{
				return this._syonin_flg_nm;
			}
			set
			{
				this._syonin_flg_nm = value;
			}
		}
		/// <summary>
		/// 項目「KESSAI_FLG_NM(決裁状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Kessai_flg_nm
		{
			get
			{
				return this._kessai_flg_nm;
			}
			set
			{
				this._kessai_flg_nm = value;
			}
		}
		/// <summary>
		/// 項目「APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string Apply_ymd
		{
			get
			{
				return this._apply_ymd;
			}
			set
			{
				this._apply_ymd = value;
			}
		}
		/// <summary>
		/// 項目「IKKATSUKYAKKA_KYAKKARIYU_KB(一括却下用却下理由)」の値を取得または設定する。
		/// </summary>
		public virtual string Ikkatsukyakka_kyakkariyu_kb
		{
			get
			{
				return this._ikkatsukyakka_kyakkariyu_kb;
			}
			set
			{
				this._ikkatsukyakka_kyakkariyu_kb = value;
			}
		}
		/// <summary>
		/// 項目「IKKATSUKYAKKA_KYAKKARIYU()」の値を取得または設定する。
		/// </summary>
		public virtual string Ikkatsukyakka_kyakkariyu
		{
			get
			{
				return this._ikkatsukyakka_kyakkariyu;
			}
			set
			{
				this._ikkatsukyakka_kyakkariyu = value;
			}
		}
		/// <summary>
		/// 項目「GOKEI_SURYO(合計)」の値を取得または設定する。
		/// </summary>
		public virtual string Gokei_suryo
		{
			get
			{
				return this._gokei_suryo;
			}
			set
			{
				this._gokei_suryo = value;
			}
		}
		/// <summary>
		/// 項目「HAIBUN_KIN_GOKEI()」の値を取得または設定する。
		/// </summary>
		public virtual string Haibun_kin_gokei
		{
			get
			{
				return this._haibun_kin_gokei;
			}
			set
			{
				this._haibun_kin_gokei = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk010f02BaseForm() : base()
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
			sb.Append("Syori_ym:").Append(this._syori_ym).AppendLine();
			sb.Append("Tenpo_cd:").Append(this._tenpo_cd).AppendLine();
			sb.Append("Tenpo_nm:").Append(this._tenpo_nm).AppendLine();
			sb.Append("Syonin_flg_nm:").Append(this._syonin_flg_nm).AppendLine();
			sb.Append("Kessai_flg_nm:").Append(this._kessai_flg_nm).AppendLine();
			sb.Append("Apply_ymd:").Append(this._apply_ymd).AppendLine();
			sb.Append("Ikkatsukyakka_kyakkariyu_kb:").Append(this._ikkatsukyakka_kyakkariyu_kb).AppendLine();
			sb.Append("Ikkatsukyakka_kyakkariyu:").Append(this._ikkatsukyakka_kyakkariyu).AppendLine();
			sb.Append("Gokei_suryo:").Append(this._gokei_suryo).AppendLine();
			sb.Append("Haibun_kin_gokei:").Append(this._haibun_kin_gokei).AppendLine();
		
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
			return "Tk010f02";
		}
		#endregion

		#endregion
	}
}
