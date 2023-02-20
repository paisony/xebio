using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta070p01.VO
{
  /// <summary>
  /// Ta070f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Ta070f01M1ResultVO : StandardBaseVO
	{

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
		/// 項目「M1BUMONKANA_NM()」の値
		/// </summary>
		private string _m1bumonkana_nm;

		/// <summary>
		/// 項目「M1HINSYU_RYAKU_NM(品種)」の値
		/// </summary>
		private string _m1hinsyu_ryaku_nm;

		/// <summary>
		/// 項目「M1BURANDO_NM_BO1(ブランド)」の値
		/// </summary>
		private string _m1burando_nm_bo1;

		/// <summary>
		/// 項目「M1MAKER_HBN(メーカー品番)」の値
		/// </summary>
		private string _m1maker_hbn;

		/// <summary>
		/// 項目「M1JISYA_HBN(自社品番)」の値
		/// </summary>
		private string _m1jisya_hbn;

		/// <summary>
		/// 項目「M1SYOHIN_ZOKUSEI(コア)」の値
		/// </summary>
		private string _m1syohin_zokusei;

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
		/// 項目「M1SYONMK(商品名)」の値
		/// </summary>
		private string _m1syonmk;

		/// <summary>
		/// 項目「M1KAISI_YMD(開始日)」の値
		/// </summary>
		private string _m1kaisi_ymd;

		/// <summary>
		/// 項目「M1SYURYO_YMD(終了日)」の値
		/// </summary>
		private string _m1syuryo_ymd;

		/// <summary>
		/// 項目「M1HATTYUPTN_KBN(発注ﾊﾟﾀｰﾝ)」の値
		/// </summary>
		private string _m1hattyuptn_kbn;

		/// <summary>
		/// 項目「M1JIDO_KBNNM(自動区分)」の値
		/// </summary>
		private string _m1jido_kbnnm;

		/// <summary>
		/// 項目「M1URIAGE_SU(売上数)」の値
		/// </summary>
		private string _m1uriage_su;

		/// <summary>
		/// 項目「M1GENZAISETTEI_SU(現在数)」の値
		/// </summary>
		private string _m1genzaisettei_su;

		/// <summary>
		/// 項目「M1LOT_SU(ロット)」の値
		/// </summary>
		private string _m1lot_su;

		/// <summary>
		/// 項目「M1IRAIRIYU_CD(依頼理由)」の値
		/// </summary>
		private string _m1irairiyu_cd;

		/// <summary>
		/// 項目「M1HENKO_IRAI_SU(変更依頼)」の値
		/// </summary>
		private string _m1henko_irai_su;

		/// <summary>
		/// 項目「M1HANBAIIN_NM(担当者)」の値
		/// </summary>
		private string _m1hanbaiin_nm;

		/// <summary>
		/// 項目「M1ADD_YMD(登録日)」の値
		/// </summary>
		private string _m1add_ymd;

		/// <summary>
		/// 項目「M1HONBUTENPOKBNNM(区分)」の値
		/// </summary>
		private string _m1honbutenpokbnnm;

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
		/// 項目「M1BURANDO_NM_BO1(ブランド)」の値を取得または設定する。
		/// </summary>
		public virtual string M1burando_nm_bo1
		{
			get
			{
				return this._m1burando_nm_bo1;
			}
			set
			{
				this._m1burando_nm_bo1 = value;
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
		/// 項目「M1KAISI_YMD(開始日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kaisi_ymd
		{
			get
			{
				return this._m1kaisi_ymd;
			}
			set
			{
				this._m1kaisi_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYURYO_YMD(終了日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syuryo_ymd
		{
			get
			{
				return this._m1syuryo_ymd;
			}
			set
			{
				this._m1syuryo_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HATTYUPTN_KBN(発注ﾊﾟﾀｰﾝ)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hattyuptn_kbn
		{
			get
			{
				return this._m1hattyuptn_kbn;
			}
			set
			{
				this._m1hattyuptn_kbn = value;
			}
		}

		/// <summary>
		/// 項目「M1JIDO_KBNNM(自動区分)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jido_kbnnm
		{
			get
			{
				return this._m1jido_kbnnm;
			}
			set
			{
				this._m1jido_kbnnm = value;
			}
		}

		/// <summary>
		/// 項目「M1URIAGE_SU(売上数)」の値を取得または設定する。
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
		/// 項目「M1GENZAISETTEI_SU(現在数)」の値を取得または設定する。
		/// </summary>
		public virtual string M1genzaisettei_su
		{
			get
			{
				return this._m1genzaisettei_su;
			}
			set
			{
				this._m1genzaisettei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1LOT_SU(ロット)」の値を取得または設定する。
		/// </summary>
		public virtual string M1lot_su
		{
			get
			{
				return this._m1lot_su;
			}
			set
			{
				this._m1lot_su = value;
			}
		}

		/// <summary>
		/// 項目「M1IRAIRIYU_CD(依頼理由)」の値を取得または設定する。
		/// </summary>
		public virtual string M1irairiyu_cd
		{
			get
			{
				return this._m1irairiyu_cd;
			}
			set
			{
				this._m1irairiyu_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1HENKO_IRAI_SU(変更依頼)」の値を取得または設定する。
		/// </summary>
		public virtual string M1henko_irai_su
		{
			get
			{
				return this._m1henko_irai_su;
			}
			set
			{
				this._m1henko_irai_su = value;
			}
		}

		/// <summary>
		/// 項目「M1HANBAIIN_NM(担当者)」の値を取得または設定する。
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
		/// 項目「M1ADD_YMD(登録日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1add_ymd
		{
			get
			{
				return this._m1add_ymd;
			}
			set
			{
				this._m1add_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1HONBUTENPOKBNNM(区分)」の値を取得または設定する。
		/// </summary>
		public virtual string M1honbutenpokbnnm
		{
			get
			{
				return this._m1honbutenpokbnnm;
			}
			set
			{
				this._m1honbutenpokbnnm = value;
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


		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta070f01M1ResultVO() : base()
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
			Ta070f01M1ResultVO compare = null;
			if (obj is Ta070f01M1ResultVO)
			{
				compare = (Ta070f01M1ResultVO)obj;
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
			if (_m1hinsyu_ryaku_nm != compare.M1hinsyu_ryaku_nm)
			{
				return false;
			}
			if (_m1burando_nm_bo1 != compare.M1burando_nm_bo1)
			{
				return false;
			}
			if (_m1maker_hbn != compare.M1maker_hbn)
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
			if (_m1syonmk != compare.M1syonmk)
			{
				return false;
			}
			if (_m1kaisi_ymd != compare.M1kaisi_ymd)
			{
				return false;
			}
			if (_m1syuryo_ymd != compare.M1syuryo_ymd)
			{
				return false;
			}
			if (_m1hattyuptn_kbn != compare.M1hattyuptn_kbn)
			{
				return false;
			}
			if (_m1jido_kbnnm != compare.M1jido_kbnnm)
			{
				return false;
			}
			if (_m1uriage_su != compare.M1uriage_su)
			{
				return false;
			}
			if (_m1genzaisettei_su != compare.M1genzaisettei_su)
			{
				return false;
			}
			if (_m1lot_su != compare.M1lot_su)
			{
				return false;
			}
			if (_m1irairiyu_cd != compare.M1irairiyu_cd)
			{
				return false;
			}
			if (_m1henko_irai_su != compare.M1henko_irai_su)
			{
				return false;
			}
			if (_m1hanbaiin_nm != compare.M1hanbaiin_nm)
			{
				return false;
			}
			if (_m1add_ymd != compare.M1add_ymd)
			{
				return false;
			}
			if (_m1honbutenpokbnnm != compare.M1honbutenpokbnnm)
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
		/// <returns>現在のcom.xebio.bo.Ta070p01.Formvo.Ta070f01M1Formのハッシュ コード。</returns>
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
			StringBuilder str = new StringBuilder();

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1bumon_cd:").Append(this._m1bumon_cd).AppendLine();
			str.Append("M1bumonkana_nm:").Append(this._m1bumonkana_nm).AppendLine();
			str.Append("M1hinsyu_ryaku_nm:").Append(this._m1hinsyu_ryaku_nm).AppendLine();
			str.Append("M1burando_nm_bo1:").Append(this._m1burando_nm_bo1).AppendLine();
			str.Append("M1maker_hbn:").Append(this._m1maker_hbn).AppendLine();
			str.Append("M1jisya_hbn:").Append(this._m1jisya_hbn).AppendLine();
			str.Append("M1syohin_zokusei:").Append(this._m1syohin_zokusei).AppendLine();
			str.Append("M1iro_nm:").Append(this._m1iro_nm).AppendLine();
			str.Append("M1size_nm:").Append(this._m1size_nm).AppendLine();
			str.Append("M1scan_cd:").Append(this._m1scan_cd).AppendLine();
			str.Append("M1syonmk:").Append(this._m1syonmk).AppendLine();
			str.Append("M1kaisi_ymd:").Append(this._m1kaisi_ymd).AppendLine();
			str.Append("M1syuryo_ymd:").Append(this._m1syuryo_ymd).AppendLine();
			str.Append("M1hattyuptn_kbn:").Append(this._m1hattyuptn_kbn).AppendLine();
			str.Append("M1jido_kbnnm:").Append(this._m1jido_kbnnm).AppendLine();
			str.Append("M1uriage_su:").Append(this._m1uriage_su).AppendLine();
			str.Append("M1genzaisettei_su:").Append(this._m1genzaisettei_su).AppendLine();
			str.Append("M1lot_su:").Append(this._m1lot_su).AppendLine();
			str.Append("M1irairiyu_cd:").Append(this._m1irairiyu_cd).AppendLine();
			str.Append("M1henko_irai_su:").Append(this._m1henko_irai_su).AppendLine();
			str.Append("M1hanbaiin_nm:").Append(this._m1hanbaiin_nm).AppendLine();
			str.Append("M1add_ymd:").Append(this._m1add_ymd).AppendLine();
			str.Append("M1honbutenpokbnnm:").Append(this._m1honbutenpokbnnm).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
