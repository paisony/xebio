using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Te130p01.Formvo.Baseform
{
  /// <summary>
  /// Te130f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te130f01M1BaseForm : StandardBaseM1Form
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
		/// 項目「M1SYUKKAKAISYA_CD(会社)」の値
		/// </summary>
		private string _m1syukkakaisya_cd;

		/// <summary>
		/// 項目「M1SYUKKATEN_CD(出荷店)」の値
		/// </summary>
		private string _m1syukkaten_cd;

		/// <summary>
		/// 項目「M1SYUKKATENPO_NM()」の値
		/// </summary>
		private string _m1syukkatenpo_nm;

		/// <summary>
		/// 項目「M1JYURYOKAISYA_CD(会社)」の値
		/// </summary>
		private string _m1jyuryokaisya_cd;

		/// <summary>
		/// 項目「M1JYURYOTEN_CD(入荷店)」の値
		/// </summary>
		private string _m1jyuryoten_cd;

		/// <summary>
		/// 項目「M1JURYOTEN_NM()」の値
		/// </summary>
		private string _m1juryoten_nm;


		/// <summary>
		/// 項目「M1IDODENPYO_BANGO(移動伝票)」の値
		/// </summary>
		private string _m1idodenpyo_bango;

		/// <summary>
		/// 項目「M1SIJI_BANGO(指示番号)」の値
		/// </summary>
		private string _m1siji_bango;

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値
		/// </summary>
		private string _m1syukka_ymd;

		/// <summary>
		/// 項目「M1JYURYO_YMD(入荷日)」の値
		/// </summary>
		private string _m1jyuryo_ymd;

		/// <summary>
		/// 項目「M1NYUKAYOTEI_SU(予定数量)」の値
		/// </summary>
		private string _m1nyukayotei_su;

		/// <summary>
		/// 項目「M1NYUKAJISSEKI_SU(確定数量)」の値
		/// </summary>
		private string _m1nyukajisseki_su;

		/// <summary>
		/// 項目「M1KYAKUCYU(客注)」の値
		/// </summary>
		private string _m1kyakucyu;

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値
		/// </summary>
		private string _m1syorinm;

		/// <summary>
		/// 項目「M1SYORI_YMD(処理日)」の値
		/// </summary>
		private string _m1syori_ymd;

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値
		/// </summary>
		private string _m1syori_tm;

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
		/// 項目「M1SYUKKAKAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkakaisya_cd
		{
			get
			{
				return this._m1syukkakaisya_cd;
			}
			set
			{
				this._m1syukkakaisya_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKATEN_CD(出荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkaten_cd
		{
			get
			{
				return this._m1syukkaten_cd;
			}
			set
			{
				this._m1syukkaten_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKATENPO_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukkatenpo_nm
		{
			get
			{
				return this._m1syukkatenpo_nm;
			}
			set
			{
				this._m1syukkatenpo_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURYOKAISYA_CD(会社)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuryokaisya_cd
		{
			get
			{
				return this._m1jyuryokaisya_cd;
			}
			set
			{
				this._m1jyuryokaisya_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURYOTEN_CD(入荷店)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuryoten_cd
		{
			get
			{
				return this._m1jyuryoten_cd;
			}
			set
			{
				this._m1jyuryoten_cd = value;
			}
		}

		/// <summary>
		/// 項目「M1JURYOTEN_NM()」の値を取得または設定する。
		/// </summary>
		public virtual string M1juryoten_nm
		{
			get
			{
				return this._m1juryoten_nm;
			}
			set
			{
				this._m1juryoten_nm = value;
			}
		}


		/// <summary>
		/// 項目「M1IDODENPYO_BANGO(移動伝票)」の値を取得または設定する。
		/// </summary>
		public virtual string M1idodenpyo_bango
		{
			get
			{
				return this._m1idodenpyo_bango;
			}
			set
			{
				this._m1idodenpyo_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1SIJI_BANGO(指示番号)」の値を取得または設定する。
		/// </summary>
		public virtual string M1siji_bango
		{
			get
			{
				return this._m1siji_bango;
			}
			set
			{
				this._m1siji_bango = value;
			}
		}

		/// <summary>
		/// 項目「M1SYUKKA_YMD(出荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syukka_ymd
		{
			get
			{
				return this._m1syukka_ymd;
			}
			set
			{
				this._m1syukka_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1JYURYO_YMD(入荷日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1jyuryo_ymd
		{
			get
			{
				return this._m1jyuryo_ymd;
			}
			set
			{
				this._m1jyuryo_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKAYOTEI_SU(予定数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukayotei_su
		{
			get
			{
				return this._m1nyukayotei_su;
			}
			set
			{
				this._m1nyukayotei_su = value;
			}
		}

		/// <summary>
		/// 項目「M1NYUKAJISSEKI_SU(確定数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1nyukajisseki_su
		{
			get
			{
				return this._m1nyukajisseki_su;
			}
			set
			{
				this._m1nyukajisseki_su = value;
			}
		}

		/// <summary>
		/// 項目「M1KYAKUCYU(客注)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kyakucyu
		{
			get
			{
				return this._m1kyakucyu;
			}
			set
			{
				this._m1kyakucyu = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORINM(処理)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syorinm
		{
			get
			{
				return this._m1syorinm;
			}
			set
			{
				this._m1syorinm = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORI_YMD(処理日)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syori_ymd
		{
			get
			{
				return this._m1syori_ymd;
			}
			set
			{
				this._m1syori_ymd = value;
			}
		}

		/// <summary>
		/// 項目「M1SYORI_TM(処理時間)」の値を取得または設定する。
		/// </summary>
		public virtual string M1syori_tm
		{
			get
			{
				return this._m1syori_tm;
			}
			set
			{
				this._m1syori_tm = value;
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
		public Te130f01M1BaseForm()
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
			Te130f01M1BaseForm compare = null;
			if (obj is Te130f01M1BaseForm)
			{
				compare = (Te130f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1syukkakaisya_cd != compare.M1syukkakaisya_cd)
			{
				return false;
			}
			if (_m1syukkaten_cd != compare.M1syukkaten_cd)
			{
				return false;
			}
			if (_m1syukkatenpo_nm != compare.M1syukkatenpo_nm)
			{
				return false;
			}
			if (_m1jyuryokaisya_cd != compare.M1jyuryokaisya_cd)
			{
				return false;
			}
			if (_m1jyuryoten_cd != compare.M1jyuryoten_cd)
			{
				return false;
			}
			if (_m1juryoten_nm != compare.M1juryoten_nm)
			{
				return false;
			}
			if (_m1idodenpyo_bango != compare.M1idodenpyo_bango)
			{
				return false;
			}
			if (_m1siji_bango != compare.M1siji_bango)
			{
				return false;
			}
			if (_m1syukka_ymd != compare.M1syukka_ymd)
			{
				return false;
			}
			if (_m1jyuryo_ymd != compare.M1jyuryo_ymd)
			{
				return false;
			}
			if (_m1nyukayotei_su != compare.M1nyukayotei_su)
			{
				return false;
			}
			if (_m1nyukajisseki_su != compare.M1nyukajisseki_su)
			{
				return false;
			}
			if (_m1kyakucyu != compare.M1kyakucyu)
			{
				return false;
			}
			if (_m1syorinm != compare.M1syorinm)
			{
				return false;
			}
			if (_m1syori_ymd != compare.M1syori_ymd)
			{
				return false;
			}
			if (_m1syori_tm != compare.M1syori_tm)
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
		/// <returns>現在のcom.xebio.bo.Te130p01.Formvo.Te130f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1syukkakaisya_cd:").Append(this._m1syukkakaisya_cd).AppendLine();
			str.Append("M1syukkaten_cd:").Append(this._m1syukkaten_cd).AppendLine();
			str.Append("M1syukkatenpo_nm:").Append(this._m1syukkatenpo_nm).AppendLine();
			str.Append("M1jyuryokaisya_cd:").Append(this._m1jyuryokaisya_cd).AppendLine();
			str.Append("M1jyuryoten_cd:").Append(this._m1jyuryoten_cd).AppendLine();
			str.Append("M1juryoten_nm:").Append(this._m1juryoten_nm).AppendLine();
			str.Append("M1idodenpyo_bango:").Append(this._m1idodenpyo_bango).AppendLine();
			str.Append("M1siji_bango:").Append(this._m1siji_bango).AppendLine();
			str.Append("M1syukka_ymd:").Append(this._m1syukka_ymd).AppendLine();
			str.Append("M1jyuryo_ymd:").Append(this._m1jyuryo_ymd).AppendLine();
			str.Append("M1nyukayotei_su:").Append(this._m1nyukayotei_su).AppendLine();
			str.Append("M1nyukajisseki_su:").Append(this._m1nyukajisseki_su).AppendLine();
			str.Append("M1kyakucyu:").Append(this._m1kyakucyu).AppendLine();
			str.Append("M1syorinm:").Append(this._m1syorinm).AppendLine();
			str.Append("M1syori_ymd:").Append(this._m1syori_ymd).AppendLine();
			str.Append("M1syori_tm:").Append(this._m1syori_tm).AppendLine();
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
			return "Te130f01";
		}
		#endregion
		#endregion

	}
}
