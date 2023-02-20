﻿using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tl020p01.Formvo.Baseform
{
  /// <summary>
  /// Tl020f02 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl020f02M1BaseForm : StandardBaseM1Form
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値
		/// </summary>
		private string _m1burando_nm;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _m1maker_hbn;

		/// <summary>
		/// 項目「M1SYONMK(商品名)」の値
		/// </summary>
		private string _m1syonmk;

		/// <summary>
		/// 項目「M1IRO_NM(色)」の値
		/// </summary>
		private string _m1iro_nm;

		/// <summary>
		/// 項目「M1SEASON_KB(シーズン)」の値
		/// </summary>
		private string _m1season_kb;

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値
		/// </summary>
		private string _m1hanbaikanryo_ymd;

		/// <summary>
		/// 項目「M1MTOBAIKA_TNK(元売価)」の値
		/// </summary>
		private string _m1mtobaika_tnk;

		/// <summary>
		/// 項目「M1GEN_TNK(原単価)」の値
		/// </summary>
		private string _m1gen_tnk;

		/// <summary>
		/// 項目「M1SHINBAIKA_TNK(新売価)」の値
		/// </summary>
		private string _m1shinbaika_tnk;

		/// <summary>
		/// 項目「M1NEIRE_RTU_GENKO(値入率現行)」の値
		/// </summary>
		private string _m1neire_rtu_genko;

		/// <summary>
		/// 項目「M1NEIRE_RTU_BAIHENGO(値入率売変後)」の値
		/// </summary>
		private string _m1neire_rtu_baihengo;

		/// <summary>
		/// 項目「M1ZAIKO_SU(在庫点数)」の値
		/// </summary>
		private string _m1zaiko_su;

		/// <summary>
		/// 項目「M1URIAGE_SU(売上点数)」の値
		/// </summary>
		private string _m1uriage_su;

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認状態名称)」の値
		/// </summary>
		private string _m1syonin_flg_nm;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値
		/// </summary>
		private string _m1selectorcheckbox;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値
		/// </summary>
		private string _m1entersyoriflg;

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値
		/// </summary>
		private string _m1dtlirokbn;

		/// <summary>
		/// 処理モード
		/// </summary>
		private DbuModeCode _commode;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno
		{
			get
			{
				return this._m1rowno;
			}
			set
			{
				this._m1rowno = value;
			}
		}

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinsyu_ryaku_nm
		{
			get
			{
				return this._m1hinsyu_ryaku_nm;
			}
			set
			{
				this._m1hinsyu_ryaku_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_NM(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm
		{
			get
			{
				return this._m1burando_nm;
			}
			set
			{
				this._m1burando_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jisya_hbn
		{
			get
			{
				return this._m1jisya_hbn;
			}
			set
			{
				this._m1jisya_hbn = value;
			}
		}

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値を取得または設定する。
		/// </summary>
		public virtual string M1maker_hbn
		{
			get
			{
				return this._m1maker_hbn;
			}
			set
			{
				this._m1maker_hbn = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONMK(商品名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonmk
		{
			get
			{
				return this._m1syonmk;
			}
			set
			{
				this._m1syonmk = value;
			}
		}

		/// <summary>
		/// 項目「M1IRO_NM(色)」の値を取得または設定する。
		/// </summary>
		public virtual string M1iro_nm
		{
			get
			{
				return this._m1iro_nm;
			}
			set
			{
				this._m1iro_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SEASON_KB(シーズン)」の値を取得または設定する。
		/// </summary>
		public virtual string M1season_kb
		{
			get
			{
				return this._m1season_kb;
			}
			set
			{
				this._m1season_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaikanryo_ymd
		{
			get
			{
				return this._m1hanbaikanryo_ymd;
			}
			set
			{
				this._m1hanbaikanryo_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1MTOBAIKA_TNK(元売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1mtobaika_tnk
		{
			get
			{
				return this._m1mtobaika_tnk;
			}
			set
			{
				this._m1mtobaika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1GEN_TNK(原単価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1gen_tnk
		{
			get
			{
				return this._m1gen_tnk;
			}
			set
			{
				this._m1gen_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1SHINBAIKA_TNK(新売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1shinbaika_tnk
		{
			get
			{
				return this._m1shinbaika_tnk;
			}
			set
			{
				this._m1shinbaika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1NEIRE_RTU_GENKO(値入率現行)」の値を取得または設定する。
		/// </summary>
		public virtual string M1neire_rtu_genko
		{
			get
			{
				return this._m1neire_rtu_genko;
			}
			set
			{
				this._m1neire_rtu_genko = value;
			}
		}

		/// <summary>
		/// 項目「M1NEIRE_RTU_BAIHENGO(値入率売変後)」の値を取得または設定する。
		/// </summary>
		public virtual string M1neire_rtu_baihengo
		{
			get
			{
				return this._m1neire_rtu_baihengo;
			}
			set
			{
				this._m1neire_rtu_baihengo = value;
			}
		}

		/// <summary>
		/// 項目「M1ZAIKO_SU(在庫点数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1zaiko_su
		{
			get
			{
				return this._m1zaiko_su;
			}
			set
			{
				this._m1zaiko_su = value;
			}
		}

		/// <summary>
		/// 項目「M1URIAGE_SU(売上点数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1uriage_su
		{
			get
			{
				return this._m1uriage_su;
			}
			set
			{
				this._m1uriage_su = value;
			}
		}

		/// <summary>
		/// 項目「M1SYONIN_FLG_NM(承認状態名称)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syonin_flg_nm
		{
			get
			{
				return this._m1syonin_flg_nm;
			}
			set
			{
				this._m1syonin_flg_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox
		{
			get
			{
				return this._m1selectorcheckbox;
			}
			set
			{
				this._m1selectorcheckbox = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg
		{
			get
			{
				return this._m1entersyoriflg;
			}
			set
			{
				this._m1entersyoriflg = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn
		{
			get
			{
				return this._m1dtlirokbn;
			}
			set
			{
				this._m1dtlirokbn = value;
			}
		}


		/// <summary>
		/// 処理モード
		/// </summary>
		public virtual DbuModeCode Commode
		{
			get
			{
				return this._commode;
			}
			set
			{
				this._commode=value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl020f02M1BaseForm()
		{
		}
		#endregion

		#region メソッド
		
		/// <summary>
		/// 引数のオブジェクトと比較する。
		/// </summary>
		/// <param name="obj">比較するオブジェクト</param>
		/// <returns>結果</returns>
		public override bool Equals(object obj)
		{
			Tl020f02M1BaseForm compare = null;
			if (obj is Tl020f02M1BaseForm)
			{
				compare = (Tl020f02M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1burando_nm != compare.M1burando_nm)
			{
				return false;
			}
			if (_m1jisya_hbn != compare.M1jisya_hbn)
			{
				return false;
			}
			if (_m1maker_hbn != compare.M1maker_hbn)
			{
				return false;
			}
			if (_m1syonmk != compare.M1syonmk)
			{
				return false;
			}
			if (_m1iro_nm != compare.M1iro_nm)
			{
				return false;
			}
			if (_m1season_kb != compare.M1season_kb)
			{
				return false;
			}
			if (_m1hanbaikanryo_ymd != compare.M1hanbaikanryo_ymd)
			{
				return false;
			}
			if (_m1mtobaika_tnk != compare.M1mtobaika_tnk)
			{
				return false;
			}
			if (_m1gen_tnk != compare.M1gen_tnk)
			{
				return false;
			}
			if (_m1shinbaika_tnk != compare.M1shinbaika_tnk)
			{
				return false;
			}
			if (_m1neire_rtu_genko != compare.M1neire_rtu_genko)
			{
				return false;
			}
			if (_m1neire_rtu_baihengo != compare.M1neire_rtu_baihengo)
			{
				return false;
			}
			if (_m1zaiko_su != compare.M1zaiko_su)
			{
				return false;
			}
			if (_m1uriage_su != compare.M1uriage_su)
			{
				return false;
			}
			if (_m1syonin_flg_nm != compare.M1syonin_flg_nm)
			{
				return false;
			}
			if (_m1selectorcheckbox != compare.M1selectorcheckbox)
			{
				return false;
			}
			if (_m1entersyoriflg != compare.M1entersyoriflg)
			{
				return false;
			}
			if (_m1dtlirokbn != compare.M1dtlirokbn)
			{
				return false;
			}

			return true;
		}
		/// <summary>
		/// 特定の型のハッシュ関数として機能します。
		/// ハッシュ アルゴリズムや、ハッシュ テーブルのようなデータ構造での使用に適しています。
		/// </summary>
		/// <returns>現在のcom.xebio.bo.Tl020p01.Formvo.Tl020f02M1Formのハッシュ コード。</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}
		/// <summary>
		/// このオブジェクトの内容を文字列で取得する。
		/// </summary>
		/// <returns>オブジェクトの内容</returns>
		public override string ToString()
		{
			StringBuilder str=new StringBuilder();

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1season_kb:").Append(this._m1season_kb).AppendLine();
			str.Append("M1hanbaikanryo_ymd:").Append(this._m1hanbaikanryo_ymd).AppendLine();
			str.Append("M1mtobaika_tnk:").Append(this._m1mtobaika_tnk).AppendLine();
			str.Append("M1gen_tnk:").Append(this._m1gen_tnk).AppendLine();
			str.Append("M1shinbaika_tnk:").Append(this._m1shinbaika_tnk).AppendLine();
			str.Append("M1neire_rtu_genko:").Append(this._m1neire_rtu_genko).AppendLine();
			str.Append("M1neire_rtu_baihengo:").Append(this._m1neire_rtu_baihengo).AppendLine();
			str.Append("M1zaiko_su:").Append(this._m1zaiko_su).AppendLine();
			str.Append("M1uriage_su:").Append(this._m1uriage_su).AppendLine();
			str.Append("M1syonin_flg_nm:").Append(this._m1syonin_flg_nm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Tl020f02";
		}
		#endregion
		#endregion

	}
}
