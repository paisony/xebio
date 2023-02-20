using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tm040p01.Formvo.Baseform
{
  /// <summary>
  /// Tm040f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm040f01BaseForm : StandardBaseForm, IFormVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「MODENO()」の値
		/// </summary>
		private string _modeno;
		/// <summary>
		/// 項目「STKMODENO()」の値
		/// </summary>
		private string _stkmodeno;
		/// <summary>
		/// 項目「OLD_JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「SCAN_CD(ｽｷｬﾝｺｰﾄﾞ)」の値
		/// </summary>
		private string _scan_cd;
		/// <summary>
		/// 項目「BUMON_NM(部門)」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SYONMK(商品名)」の値
		/// </summary>
		private string _syonmk;
		/// <summary>
		/// 項目「TENPO_CD()」の値
		/// </summary>
		private string _tenpo_cd;
		/// <summary>
		/// 項目「PLUFLG()」の値
		/// </summary>
		private string _pluflg;
		/// <summary>
		/// 項目「PRICEFLG()」の値
		/// </summary>
		private string _priceflg;
		/// <summary>
		/// 項目「ZAIKOFLG()」の値
		/// </summary>
		private string _zaikoflg;
		/// <summary>
		/// 項目「NYUKAFLG()」の値
		/// </summary>
		private string _nyukaflg;
		/// <summary>
		/// 項目「URIFLG()」の値
		/// </summary>
		private string _uriflg;
		/// <summary>
		/// 項目「HOJUFLG()」の値
		/// </summary>
		private string _hojuflg;
		/// <summary>
		/// 項目「TANPINFLG()」の値
		/// </summary>
		private string _tanpinflg;
		/// <summary>
		/// 項目「SIJIFLG()」の値
		/// </summary>
		private string _sijiflg;
		/// <summary>
		/// 項目「SIJI_BANGO()」の値
		/// </summary>
		private string _siji_bango;
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD()」の値
		/// </summary>
		private string _syukkakaisya_cd;
		/// <summary>
		/// 項目「JYURYOKAISYA_CD()」の値
		/// </summary>
		private string _jyuryokaisya_cd;
		/// <summary>
		/// 項目「SYUKKATEN_CD()」の値
		/// </summary>
		private string _syukkaten_cd;

		/// <summary>
		/// M1明細リスト
		/// </summary>
		protected IDataList m1List;
		#endregion

		#region プロパティ
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
		/// 項目「BUMON_NM(部門)」の値を取得または設定する。
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
		/// 項目「HINSYU_RYAKU_NM(品種)」の値を取得または設定する。
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
		/// 項目「BURANDO_NM(ブランド)」の値を取得または設定する。
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
		/// 項目「MAKER_HBN(メーカー品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Maker_hbn
		{
			get
			{
				return this._maker_hbn;
			}
			set
			{
				this._maker_hbn = value;
			}
		}
		/// <summary>
		/// 項目「SYONMK(商品名)」の値を取得または設定する。
		/// </summary>
		public virtual string Syonmk
		{
			get
			{
				return this._syonmk;
			}
			set
			{
				this._syonmk = value;
			}
		}
		/// <summary>
		/// 項目「TENPO_CD()」の値を取得または設定する。
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
		/// 項目「PLUFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Pluflg
		{
			get
			{
				return this._pluflg;
			}
			set
			{
				this._pluflg = value;
			}
		}
		/// <summary>
		/// 項目「PRICEFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Priceflg
		{
			get
			{
				return this._priceflg;
			}
			set
			{
				this._priceflg = value;
			}
		}
		/// <summary>
		/// 項目「ZAIKOFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Zaikoflg
		{
			get
			{
				return this._zaikoflg;
			}
			set
			{
				this._zaikoflg = value;
			}
		}
		/// <summary>
		/// 項目「NYUKAFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Nyukaflg
		{
			get
			{
				return this._nyukaflg;
			}
			set
			{
				this._nyukaflg = value;
			}
		}
		/// <summary>
		/// 項目「URIFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Uriflg
		{
			get
			{
				return this._uriflg;
			}
			set
			{
				this._uriflg = value;
			}
		}
		/// <summary>
		/// 項目「HOJUFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Hojuflg
		{
			get
			{
				return this._hojuflg;
			}
			set
			{
				this._hojuflg = value;
			}
		}
		/// <summary>
		/// 項目「TANPINFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Tanpinflg
		{
			get
			{
				return this._tanpinflg;
			}
			set
			{
				this._tanpinflg = value;
			}
		}
		/// <summary>
		/// 項目「SIJIFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string Sijiflg
		{
			get
			{
				return this._sijiflg;
			}
			set
			{
				this._sijiflg = value;
			}
		}
		/// <summary>
		/// 項目「SIJI_BANGO()」の値を取得または設定する。
		/// </summary>
		public virtual string Siji_bango
		{
			get
			{
				return this._siji_bango;
			}
			set
			{
				this._siji_bango = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKAKAISYA_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkakaisya_cd
		{
			get
			{
				return this._syukkakaisya_cd;
			}
			set
			{
				this._syukkakaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「JYURYOKAISYA_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Jyuryokaisya_cd
		{
			get
			{
				return this._jyuryokaisya_cd;
			}
			set
			{
				this._jyuryokaisya_cd = value;
			}
		}
		/// <summary>
		/// 項目「SYUKKATEN_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string Syukkaten_cd
		{
			get
			{
				return this._syukkaten_cd;
			}
			set
			{
				this._syukkaten_cd = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm040f01BaseForm() : base()
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
			sb.Append("Modeno:").Append(this._modeno).AppendLine();
			sb.Append("Stkmodeno:").Append(this._stkmodeno).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Scan_cd:").Append(this._scan_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Syonmk:").Append(this._syonmk).AppendLine();
			sb.Append("Tenpo_cd:").Append(this._tenpo_cd).AppendLine();
			sb.Append("Pluflg:").Append(this._pluflg).AppendLine();
			sb.Append("Priceflg:").Append(this._priceflg).AppendLine();
			sb.Append("Zaikoflg:").Append(this._zaikoflg).AppendLine();
			sb.Append("Nyukaflg:").Append(this._nyukaflg).AppendLine();
			sb.Append("Uriflg:").Append(this._uriflg).AppendLine();
			sb.Append("Hojuflg:").Append(this._hojuflg).AppendLine();
			sb.Append("Tanpinflg:").Append(this._tanpinflg).AppendLine();
			sb.Append("Sijiflg:").Append(this._sijiflg).AppendLine();
			sb.Append("Siji_bango:").Append(this._siji_bango).AppendLine();
			sb.Append("Syukkakaisya_cd:").Append(this._syukkakaisya_cd).AppendLine();
			sb.Append("Jyuryokaisya_cd:").Append(this._jyuryokaisya_cd).AppendLine();
			sb.Append("Syukkaten_cd:").Append(this._syukkaten_cd).AppendLine();
		
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
			return "Tm040f01";
		}
		#endregion

		#endregion
	}
}
