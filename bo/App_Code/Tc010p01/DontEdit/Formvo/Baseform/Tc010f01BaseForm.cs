﻿using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tc010p01.Formvo.Baseform
{
  /// <summary>
  /// Tc010f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tc010f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値
		/// </summary>
		private string _denpyo_jyotai;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_FROM(入荷予定日)」の値
		/// </summary>
		private string _nyukayotei_ymd_from;
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_TO()」の値
		/// </summary>
		private string _nyukayotei_ymd_to;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_FROM(仕入確定日)」の値
		/// </summary>
		private string _siire_kakutei_ymd_from;
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_TO()」の値
		/// </summary>
		private string _siire_kakutei_ymd_to;

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
		/// 項目「DENPYO_JYOTAI(伝票状態)」の値を取得または設定する。
		/// </summary>
		public virtual string Denpyo_jyotai
		{
			get
			{
				return this._denpyo_jyotai;
			}
			set
			{
				this._denpyo_jyotai = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_FROM(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd_from
		{
			get
			{
				return this._nyukayotei_ymd_from;
			}
			set
			{
				this._nyukayotei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAYOTEI_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukayotei_ymd_to
		{
			get
			{
				return this._nyukayotei_ymd_to;
			}
			set
			{
				this._nyukayotei_ymd_to = value;
			}
		}
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_FROM(仕入確定日)」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd_from
		{
			get
			{
				return this._siire_kakutei_ymd_from;
			}
			set
			{
				this._siire_kakutei_ymd_from = value;
			}
		}
		/// <summary>
		/// 項目「SIIRE_KAKUTEI_YMD_TO()」の値を取得または設定する。
		/// </summary>
		public virtual string Siire_kakutei_ymd_to
		{
			get
			{
				return this._siire_kakutei_ymd_to;
			}
			set
			{
				this._siire_kakutei_ymd_to = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tc010f01BaseForm() : base()
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
		}

		/// <summary>
		/// 明細の現在のページの画面表示分のリストを取得します。
		/// </summary>
		/// <param name="listId">明細ID</param>
		/// <returns>明細の現在のページの画面表示分のリスト</returns>
		public virtual IList GetPageViewList(string listId)
		{
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
			sb.Append("Denpyo_jyotai:").Append(this._denpyo_jyotai).AppendLine();
			sb.Append("Nyukayotei_ymd_from:").Append(this._nyukayotei_ymd_from).AppendLine();
			sb.Append("Nyukayotei_ymd_to:").Append(this._nyukayotei_ymd_to).AppendLine();
			sb.Append("Siire_kakutei_ymd_from:").Append(this._siire_kakutei_ymd_from).AppendLine();
			sb.Append("Siire_kakutei_ymd_to:").Append(this._siire_kakutei_ymd_to).AppendLine();
		
			sb.AppendLine();

			return sb.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Tc010f01";
		}
		#endregion

		#endregion
	}
}
