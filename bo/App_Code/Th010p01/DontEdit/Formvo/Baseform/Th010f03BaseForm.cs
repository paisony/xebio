using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Th010p01.Formvo.Baseform
{
  /// <summary>
  /// Th010f03のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Th010f03BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「SIIRESAKI_CD(仕入先)」の値
		/// </summary>
		private string _siiresaki_cd;
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値
		/// </summary>
		private string _siiresaki_ryaku_nm;
		/// <summary>
		/// 項目「BUMON_CD(部門)」の値
		/// </summary>
		private string _bumon_cd;
		/// <summary>
		/// 項目「BUMON_NM()」の値
		/// </summary>
		private string _bumon_nm;
		/// <summary>
		/// 項目「HINSYU_CD(品種)」の値
		/// </summary>
		private string _hinsyu_cd;
		/// <summary>
		/// 項目「HINSYU_RYAKU_NM()」の値
		/// </summary>
		private string _hinsyu_ryaku_nm;
		/// <summary>
		/// 項目「BURANDO_CD(ブランド)」の値
		/// </summary>
		private string _burando_cd;
		/// <summary>
		/// 項目「BURANDO_NM()」の値
		/// </summary>
		private string _burando_nm;
		/// <summary>
		/// 項目「JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _jisya_hbn;
		/// <summary>
		/// 項目「OLD_JISYA_HBN()」の値
		/// </summary>
		private string _old_jisya_hbn;
		/// <summary>
		/// 項目「MAKER_HBN()」の値
		/// </summary>
		private string _maker_hbn;
		/// <summary>
		/// 項目「SYONMK(商品名)」の値
		/// </summary>
		private string _syonmk;
		/// <summary>
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値
		/// </summary>
		private string _syohin_zokusei;
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD(販売完了日)」の値
		/// </summary>
		private string _hanbaikanryo_ymd;
		/// <summary>
		/// 項目「SAISINBAIKA_TNK(最新売価)」の値
		/// </summary>
		private string _saisinbaika_tnk;
		/// <summary>
		/// 項目「GENKA(原価)」の値
		/// </summary>
		private string _genka;
		/// <summary>
		/// 項目「GENBAIKA_TNK(現売価)」の値
		/// </summary>
		private string _genbaika_tnk;
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK(ﾒｰｶｰ価格)」の値
		/// </summary>
		private string _makerkakaku_tnk;
		/// <summary>
		/// 項目「SYUTSURYOKU_SEAL(出力シール)」の値
		/// </summary>
		private string _syutsuryoku_seal;
		/// <summary>
		/// 項目「LAYOUT(レイアウト)」の値
		/// </summary>
		private string _layout;
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
		/// 項目「SIIRESAKI_CD(仕入先)」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_cd
		{
			get
			{
				return this._siiresaki_cd;
			}
			set
			{
				this._siiresaki_cd = value;
			}
		}
		/// <summary>
		/// 項目「SIIRESAKI_RYAKU_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string Siiresaki_ryaku_nm
		{
			get
			{
				return this._siiresaki_ryaku_nm;
			}
			set
			{
				this._siiresaki_ryaku_nm = value;
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
		/// 項目「JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string Jisya_hbn
		{
			get
			{
				return this._jisya_hbn;
			}
			set
			{
				this._jisya_hbn = value;
			}
		}
		/// <summary>
		/// 項目「OLD_JISYA_HBN()」の値を取得または設定する。
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
		/// 項目「MAKER_HBN()」の値を取得または設定する。
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
		/// 項目「SYOHIN_ZOKUSEI(コア属性)」の値を取得または設定する。
		/// </summary>
		public virtual string Syohin_zokusei
		{
			get
			{
				return this._syohin_zokusei;
			}
			set
			{
				this._syohin_zokusei = value;
			}
		}
		/// <summary>
		/// 項目「HANBAIKANRYO_YMD(販売完了日)」の値を取得または設定する。
		/// </summary>
		public virtual string Hanbaikanryo_ymd
		{
			get
			{
				return this._hanbaikanryo_ymd;
			}
			set
			{
				this._hanbaikanryo_ymd = value;
			}
		}
		/// <summary>
		/// 項目「SAISINBAIKA_TNK(最新売価)」の値を取得または設定する。
		/// </summary>
		public virtual string Saisinbaika_tnk
		{
			get
			{
				return this._saisinbaika_tnk;
			}
			set
			{
				this._saisinbaika_tnk = value;
			}
		}
		/// <summary>
		/// 項目「GENKA(原価)」の値を取得または設定する。
		/// </summary>
		public virtual string Genka
		{
			get
			{
				return this._genka;
			}
			set
			{
				this._genka = value;
			}
		}
		/// <summary>
		/// 項目「GENBAIKA_TNK(現売価)」の値を取得または設定する。
		/// </summary>
		public virtual string Genbaika_tnk
		{
			get
			{
				return this._genbaika_tnk;
			}
			set
			{
				this._genbaika_tnk = value;
			}
		}
		/// <summary>
		/// 項目「MAKERKAKAKU_TNK(ﾒｰｶｰ価格)」の値を取得または設定する。
		/// </summary>
		public virtual string Makerkakaku_tnk
		{
			get
			{
				return this._makerkakaku_tnk;
			}
			set
			{
				this._makerkakaku_tnk = value;
			}
		}
		/// <summary>
		/// 項目「SYUTSURYOKU_SEAL(出力シール)」の値を取得または設定する。
		/// </summary>
		public virtual string Syutsuryoku_seal
		{
			get
			{
				return this._syutsuryoku_seal;
			}
			set
			{
				this._syutsuryoku_seal = value;
			}
		}
		/// <summary>
		/// 項目「LAYOUT(レイアウト)」の値を取得または設定する。
		/// </summary>
		public virtual string Layout
		{
			get
			{
				return this._layout;
			}
			set
			{
				this._layout = value;
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
		public Th010f03BaseForm() : base()
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
			sb.Append("Siiresaki_cd:").Append(this._siiresaki_cd).AppendLine();
			sb.Append("Siiresaki_ryaku_nm:").Append(this._siiresaki_ryaku_nm).AppendLine();
			sb.Append("Bumon_cd:").Append(this._bumon_cd).AppendLine();
			sb.Append("Bumon_nm:").Append(this._bumon_nm).AppendLine();
			sb.Append("Hinsyu_cd:").Append(this._hinsyu_cd).AppendLine();
			sb.Append("Hinsyu_ryaku_nm:").Append(this._hinsyu_ryaku_nm).AppendLine();
			sb.Append("Burando_cd:").Append(this._burando_cd).AppendLine();
			sb.Append("Burando_nm:").Append(this._burando_nm).AppendLine();
			sb.Append("Jisya_hbn:").Append(this._jisya_hbn).AppendLine();
			sb.Append("Old_jisya_hbn:").Append(this._old_jisya_hbn).AppendLine();
			sb.Append("Maker_hbn:").Append(this._maker_hbn).AppendLine();
			sb.Append("Syonmk:").Append(this._syonmk).AppendLine();
			sb.Append("Syohin_zokusei:").Append(this._syohin_zokusei).AppendLine();
			sb.Append("Hanbaikanryo_ymd:").Append(this._hanbaikanryo_ymd).AppendLine();
			sb.Append("Saisinbaika_tnk:").Append(this._saisinbaika_tnk).AppendLine();
			sb.Append("Genka:").Append(this._genka).AppendLine();
			sb.Append("Genbaika_tnk:").Append(this._genbaika_tnk).AppendLine();
			sb.Append("Makerkakaku_tnk:").Append(this._makerkakaku_tnk).AppendLine();
			sb.Append("Syutsuryoku_seal:").Append(this._syutsuryoku_seal).AppendLine();
			sb.Append("Layout:").Append(this._layout).AppendLine();
			sb.Append("Label_cd:").Append(this._label_cd).AppendLine();
			sb.Append("Label_ip:").Append(this._label_ip).AppendLine();
			sb.Append("Label_nm:").Append(this._label_nm).AppendLine();
		
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
			return "Th010f03";
		}
		#endregion

		#endregion
	}
}
