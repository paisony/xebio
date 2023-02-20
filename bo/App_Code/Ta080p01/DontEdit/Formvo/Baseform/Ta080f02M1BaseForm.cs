using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta080p01.Formvo.Baseform
{
  /// <summary>
  /// Ta080f02 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f02M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1APPLY_YMD(申請日)」の値
		/// </summary>
		private string _m1apply_ymd;

		/// <summary>
		/// 項目「M1SINSEI_SB(申請種別)」の値
		/// </summary>
		private string _m1sinsei_sb;

		/// <summary>
		/// 項目「M1HANBAIIN_CD(登録担当者)」の値
		/// </summary>
		private string _m1hanbaiin_cd;

		/// <summary>
		/// 項目「M1HANBAIIN_NM()」の値
		/// </summary>
		private string _m1hanbaiin_nm;

		/// <summary>
		/// 項目「M1IRAI_RIYU(依頼理由)」の値
		/// </summary>
		private string _m1irai_riyu;

		/// <summary>
		/// 項目「M1BUMON_CD(部門)」の値
		/// </summary>
		private string _m1bumon_cd;

		/// <summary>
		/// 項目「M1BUMONKANA_NM()」の値
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
		/// 項目「M1SYOHIN_ZOKUSEI(コア)」の値
		/// </summary>
		private string _m1syohin_zokusei;

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
		/// 項目「M1SCAN_CD(スキャンコード)」の値
		/// </summary>
		private string _m1scan_cd;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値
		/// </summary>
		private string _m1nyukayotei_ymd;

		/// <summary>
		/// 項目「M1SEASON_NM(シーズン)」の値
		/// </summary>
		private string _m1season_nm;

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販完日)」の値
		/// </summary>
		private string _m1hanbaikanryo_ymd;

		/// <summary>
		/// 項目「M1APPLY_SU(申請数)」の値
		/// </summary>
		private string _m1apply_su;

		/// <summary>
		/// 項目「M1APPLY_KIN(申請金額)」の値
		/// </summary>
		private string _m1apply_kin;

		/// <summary>
		/// 項目「M1JISSEKI_SU(実績数)」の値
		/// </summary>
		private string _m1jisseki_su;

		/// <summary>
		/// 項目「M1JISSEKI_KIN(実績金額)」の値
		/// </summary>
		private string _m1jisseki_kin;

		/// <summary>
		/// 項目「M1JOTAI_KBN_NM(状態)」の値
		/// </summary>
		private string _m1jotai_kbn_nm;

		/// <summary>
		/// 項目「M1COMMENT_NM(コメント)」の値
		/// </summary>
		private string _m1comment_nm;

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
		/// 項目「M1APPLY_YMD(申請日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1apply_ymd
		{
			get
			{
				return this._m1apply_ymd;
			}
			set
			{
				this._m1apply_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEI_SB(申請種別)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_sb
		{
			get
			{
				return this._m1sinsei_sb;
			}
			set
			{
				this._m1sinsei_sb = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIIN_CD(登録担当者)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaiin_cd
		{
			get
			{
				return this._m1hanbaiin_cd;
			}
			set
			{
				this._m1hanbaiin_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIIN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1hanbaiin_nm
		{
			get
			{
				return this._m1hanbaiin_nm;
			}
			set
			{
				this._m1hanbaiin_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAI_RIYU(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1irai_riyu
		{
			get
			{
				return this._m1irai_riyu;
			}
			set
			{
				this._m1irai_riyu = value;
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
		/// 項目「M1BUMONKANA_NM()」の値を取得または設定する。
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
		/// 項目「M1SYOHIN_ZOKUSEI(コア)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syohin_zokusei
		{
			get
			{
				return this._m1syohin_zokusei;
			}
			set
			{
				this._m1syohin_zokusei = value;
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
		/// 項目「M1NYUKAYOTEI_YMD(入荷予定日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukayotei_ymd
		{
			get
			{
				return this._m1nyukayotei_ymd;
			}
			set
			{
				this._m1nyukayotei_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SEASON_NM(シーズン)」の値を取得または設定する。
		/// </summary>
		public virtual string M1season_nm
		{
			get
			{
				return this._m1season_nm;
			}
			set
			{
				this._m1season_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIKANRYO_YMD(販完日)」の値を取得または設定する。
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
		/// 項目「M1APPLY_SU(申請数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1apply_su
		{
			get
			{
				return this._m1apply_su;
			}
			set
			{
				this._m1apply_su = value;
			}
		}

		/// <summary>
		/// 項目「M1APPLY_KIN(申請金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1apply_kin
		{
			get
			{
				return this._m1apply_kin;
			}
			set
			{
				this._m1apply_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1JISSEKI_SU(実績数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jisseki_su
		{
			get
			{
				return this._m1jisseki_su;
			}
			set
			{
				this._m1jisseki_su = value;
			}
		}

		/// <summary>
		/// 項目「M1JISSEKI_KIN(実績金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jisseki_kin
		{
			get
			{
				return this._m1jisseki_kin;
			}
			set
			{
				this._m1jisseki_kin = value;
			}
		}

		/// <summary>
		/// 項目「M1JOTAI_KBN_NM(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jotai_kbn_nm
		{
			get
			{
				return this._m1jotai_kbn_nm;
			}
			set
			{
				this._m1jotai_kbn_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1COMMENT_NM(コメント)」の値を取得または設定する。
		/// </summary>
		public virtual string M1comment_nm
		{
			get
			{
				return this._m1comment_nm;
			}
			set
			{
				this._m1comment_nm = value;
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
		public Ta080f02M1BaseForm()
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
			Ta080f02M1BaseForm compare = null;
			if (obj is Ta080f02M1BaseForm)
			{
				compare = (Ta080f02M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1apply_ymd != compare.M1apply_ymd)
			{
				return false;
			}
			if (_m1sinsei_sb != compare.M1sinsei_sb)
			{
				return false;
			}
			if (_m1hanbaiin_cd != compare.M1hanbaiin_cd)
			{
				return false;
			}
			if (_m1hanbaiin_nm != compare.M1hanbaiin_nm)
			{
				return false;
			}
			if (_m1irai_riyu != compare.M1irai_riyu)
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
			if (_m1syohin_zokusei != compare.M1syohin_zokusei)
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
			if (_m1scan_cd != compare.M1scan_cd)
			{
				return false;
			}
			if (_m1nyukayotei_ymd != compare.M1nyukayotei_ymd)
			{
				return false;
			}
			if (_m1season_nm != compare.M1season_nm)
			{
				return false;
			}
			if (_m1hanbaikanryo_ymd != compare.M1hanbaikanryo_ymd)
			{
				return false;
			}
			if (_m1apply_su != compare.M1apply_su)
			{
				return false;
			}
			if (_m1apply_kin != compare.M1apply_kin)
			{
				return false;
			}
			if (_m1jisseki_su != compare.M1jisseki_su)
			{
				return false;
			}
			if (_m1jisseki_kin != compare.M1jisseki_kin)
			{
				return false;
			}
			if (_m1jotai_kbn_nm != compare.M1jotai_kbn_nm)
			{
				return false;
			}
			if (_m1comment_nm != compare.M1comment_nm)
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
		/// <returns>現在のcom.xebio.bo.Ta080p01.Formvo.Ta080f02M1Formのハッシュ コード。</returns>
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
			str.Append("M1apply_ymd:").Append(this._m1apply_ymd).AppendLine();
			str.Append("M1sinsei_sb:").Append(this._m1sinsei_sb).AppendLine();
			str.Append("M1hanbaiin_cd:").Append(this._m1hanbaiin_cd).AppendLine();
			str.Append("M1hanbaiin_nm:").Append(this._m1hanbaiin_nm).AppendLine();
			str.Append("M1irai_riyu:").Append(this._m1irai_riyu).AppendLine();
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1hinsyu_cd:").Append(this._m1hinsyu_cd).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm:").Append(this._m1burando_nm).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1syohin_zokusei:").Append(this._m1syohin_zokusei).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1nyukayotei_ymd:").Append(this._m1nyukayotei_ymd).AppendLine();
			str.Append("M1season_nm:").Append(this._m1season_nm).AppendLine();
			str.Append("M1hanbaikanryo_ymd:").Append(this._m1hanbaikanryo_ymd).AppendLine();
			str.Append("M1apply_su:").Append(this._m1apply_su).AppendLine();
			str.Append("M1apply_kin:").Append(this._m1apply_kin).AppendLine();
			str.Append("M1jisseki_su:").Append(this._m1jisseki_su).AppendLine();
			str.Append("M1jisseki_kin:").Append(this._m1jisseki_kin).AppendLine();
			str.Append("M1jotai_kbn_nm:").Append(this._m1jotai_kbn_nm).AppendLine();
			str.Append("M1comment_nm:").Append(this._m1comment_nm).AppendLine();
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
			return "Ta080f02";
		}
		#endregion
		#endregion

	}
}
