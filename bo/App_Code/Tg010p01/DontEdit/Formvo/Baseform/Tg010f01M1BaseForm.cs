using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tg010p01.Formvo.Baseform
{
  /// <summary>
  /// Tg010f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg010f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM(部門)」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1HINSYU_CD(品種)」の値
		/// </summary>
		private string _m1hinsyu_cd;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM()」の値
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
		/// 項目「M1SIZE_NM(サイズ)」の値
		/// </summary>
		private string _m1size_nm;

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販売完了日)」の値
		/// </summary>
		private string _m1hanbaikanryo_ymd;

		/// <summary>
		/// 項目「M1SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _m1scan_cd;

		/// <summary>
		/// 項目「M1BAIHENKAISI_YMD(売変開始日)」の値
		/// </summary>
		private string _m1baihenkaisi_ymd;

		/// <summary>
		/// 項目「M1SIJIBAIKA_TNK(指示売価)」の値
		/// </summary>
		private string _m1sijibaika_tnk;

		/// <summary>
		/// 項目「M1SAISINBAIKA_TNK(最新売価)」の値
		/// </summary>
		private string _m1saisinbaika_tnk;

		/// <summary>
		/// 項目「M1MAISU(枚数)」の値
		/// </summary>
		private string _m1maisu;

		/// <summary>
		/// 項目「M1ITEMKBN()」の値
		/// </summary>
		private string _m1itemkbn;

		/// <summary>
		/// 項目「M1SIIRE_KB()」の値
		/// </summary>
		private string _m1siire_kb;

		/// <summary>
		/// 項目「M1TYOTATSU_KB()」の値
		/// </summary>
		private string _m1tyotatsu_kb;

		/// <summary>
		/// 項目「M1MAKERKAKAKU_TNK()」の値
		/// </summary>
		private string _m1makerkakaku_tnk;

		/// <summary>
		/// 項目「M1BAIKA_ZEI()」の値
		/// </summary>
		private string _m1baika_zei;

		/// <summary>
		/// 項目「M1BURANDO_CD()」の値
		/// </summary>
		private string _m1burando_cd;

		/// <summary>
		/// 項目「M1BUMON_NM()」の値
		/// </summary>
		private string _m1bumon_nm;

		/// <summary>
		/// 項目「M1SIIRESAKI_CD_BO1()」の値
		/// </summary>
		private string _m1siiresaki_cd_bo1;

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
		/// 項目「M1BUMON_CD(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_cd
		{
			get
			{
				return this._m1bumon_cd;
			}
			set
			{
				this._m1bumon_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMONKANA_NM(部門)」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumonkana_nm
		{
			get
			{
				return this._m1bumonkana_nm;
			}
			set
			{
				this._m1bumonkana_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HINSYU_CD(品種)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hinsyu_cd
		{
			get
			{
				return this._m1hinsyu_cd;
			}
			set
			{
				this._m1hinsyu_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM()」の値を取得または設定する。
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
		/// 項目「M1SIZE_NM(サイズ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1size_nm
		{
			get
			{
				return this._m1size_nm;
			}
			set
			{
				this._m1size_nm = value;
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
		/// 項目「M1SCAN_CD(スキャンコード)」の値を取得または設定する。
		/// </summary>
		public virtual string M1scan_cd
		{
			get
			{
				return this._m1scan_cd;
			}
			set
			{
				this._m1scan_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIHENKAISI_YMD(売変開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1baihenkaisi_ymd
		{
			get
			{
				return this._m1baihenkaisi_ymd;
			}
			set
			{
				this._m1baihenkaisi_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SIJIBAIKA_TNK(指示売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sijibaika_tnk
		{
			get
			{
				return this._m1sijibaika_tnk;
			}
			set
			{
				this._m1sijibaika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1SAISINBAIKA_TNK(最新売価)」の値を取得または設定する。
		/// </summary>
		public virtual string M1saisinbaika_tnk
		{
			get
			{
				return this._m1saisinbaika_tnk;
			}
			set
			{
				this._m1saisinbaika_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1MAISU(枚数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1maisu
		{
			get
			{
				return this._m1maisu;
			}
			set
			{
				this._m1maisu = value;
			}
		}

		/// <summary>
		/// 項目「M1ITEMKBN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1itemkbn
		{
			get
			{
				return this._m1itemkbn;
			}
			set
			{
				this._m1itemkbn = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRE_KB()」の値を取得または設定する。
		/// </summary>
		public virtual string M1siire_kb
		{
			get
			{
				return this._m1siire_kb;
			}
			set
			{
				this._m1siire_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1TYOTATSU_KB()」の値を取得または設定する。
		/// </summary>
		public virtual string M1tyotatsu_kb
		{
			get
			{
				return this._m1tyotatsu_kb;
			}
			set
			{
				this._m1tyotatsu_kb = value;
			}
		}

		/// <summary>
		/// 項目「M1MAKERKAKAKU_TNK()」の値を取得または設定する。
		/// </summary>
		public virtual string M1makerkakaku_tnk
		{
			get
			{
				return this._m1makerkakaku_tnk;
			}
			set
			{
				this._m1makerkakaku_tnk = value;
			}
		}

		/// <summary>
		/// 項目「M1BAIKA_ZEI()」の値を取得または設定する。
		/// </summary>
		public virtual string M1baika_zei
		{
			get
			{
				return this._m1baika_zei;
			}
			set
			{
				this._m1baika_zei = value;
			}
		}

		/// <summary>
		/// 項目「M1BURANDO_CD()」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_cd
		{
			get
			{
				return this._m1burando_cd;
			}
			set
			{
				this._m1burando_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1BUMON_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1bumon_nm
		{
			get
			{
				return this._m1bumon_nm;
			}
			set
			{
				this._m1bumon_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SIIRESAKI_CD_BO1()」の値を取得または設定する。
		/// </summary>
		public virtual string M1siiresaki_cd_bo1
		{
			get
			{
				return this._m1siiresaki_cd_bo1;
			}
			set
			{
				this._m1siiresaki_cd_bo1 = value;
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
		public Tg010f01M1BaseForm()
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
			Tg010f01M1BaseForm compare = null;
			if (obj is Tg010f01M1BaseForm)
			{
				compare = (Tg010f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1bumon_cd != compare.M1bumon_cd)
			{
				return false;
			}
			if (_m1bumonkana_nm != compare.M1bumonkana_nm)
			{
				return false;
			}
			if (_m1hinsyu_cd != compare.M1hinsyu_cd)
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
			if (_m1size_nm != compare.M1size_nm)
			{
				return false;
			}
			if (_m1hanbaikanryo_ymd != compare.M1hanbaikanryo_ymd)
			{
				return false;
			}
			if (_m1scan_cd != compare.M1scan_cd)
			{
				return false;
			}
			if (_m1baihenkaisi_ymd != compare.M1baihenkaisi_ymd)
			{
				return false;
			}
			if (_m1sijibaika_tnk != compare.M1sijibaika_tnk)
			{
				return false;
			}
			if (_m1saisinbaika_tnk != compare.M1saisinbaika_tnk)
			{
				return false;
			}
			if (_m1maisu != compare.M1maisu)
			{
				return false;
			}
			if (_m1itemkbn != compare.M1itemkbn)
			{
				return false;
			}
			if (_m1siire_kb != compare.M1siire_kb)
			{
				return false;
			}
			if (_m1tyotatsu_kb != compare.M1tyotatsu_kb)
			{
				return false;
			}
			if (_m1makerkakaku_tnk != compare.M1makerkakaku_tnk)
			{
				return false;
			}
			if (_m1baika_zei != compare.M1baika_zei)
			{
				return false;
			}
			if (_m1burando_cd != compare.M1burando_cd)
			{
				return false;
			}
			if (_m1bumon_nm != compare.M1bumon_nm)
			{
				return false;
			}
			if (_m1siiresaki_cd_bo1 != compare.M1siiresaki_cd_bo1)
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
		/// <returns>現在のcom.xebio.bo.Tg010p01.Formvo.Tg010f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1hinsyu_cd:").Append(this._m1hinsyu_cd).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1hanbaikanryo_ymd:").Append(this._m1hanbaikanryo_ymd).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1baihenkaisi_ymd:").Append(this._m1baihenkaisi_ymd).AppendLine();
			str.Append("M1sijibaika_tnk:").Append(this._m1sijibaika_tnk).AppendLine();
			str.Append("M1saisinbaika_tnk:").Append(this._m1saisinbaika_tnk).AppendLine();
			str.Append("M1maisu:").Append(this._m1maisu).AppendLine();
			str.Append("M1itemkbn:").Append(this._m1itemkbn).AppendLine();
			str.Append("M1siire_kb:").Append(this._m1siire_kb).AppendLine();
			str.Append("M1tyotatsu_kb:").Append(this._m1tyotatsu_kb).AppendLine();
			str.Append("M1makerkakaku_tnk:").Append(this._m1makerkakaku_tnk).AppendLine();
			str.Append("M1baika_zei:").Append(this._m1baika_zei).AppendLine();
			str.Append("M1burando_cd:").Append(this._m1burando_cd).AppendLine();
			str.Append("M1bumon_nm:").Append(this._m1bumon_nm).AppendLine();
			str.Append("M1siiresaki_cd_bo1:").Append(this._m1siiresaki_cd_bo1).AppendLine();
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
			return "Tg010f01";
		}
		#endregion
		#endregion

	}
}
