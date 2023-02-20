using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Ta030p01.VO
{
  /// <summary>
  /// Ta030f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Ta030f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1HOJUIRAI_KBN_NM(区分)」の値
		/// </summary>
		private string _m1hojuirai_kbn_nm;

		/// <summary>
		/// 項目「M1SINSEI_JOTAINM(状態)」の値
		/// </summary>
		private string _m1sinsei_jotainm;


		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値
		/// </summary>
		private string _m1itemsu;

		/// <summary>
		/// 項目「M1KINGAKU(金額)」の値
		/// </summary>
		private string _m1kingaku;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX(選択フラグ(隠し))」の値
		/// </summary>
		private string _m1selectorcheckbox;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG(確定処理フラグ(隠し))」の値
		/// </summary>
		private string _m1entersyoriflg;

		/// <summary>
		/// 項目「M1DTLIROKBN(明細色区分(隠し))」の値
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
		/// 項目「M1HOJUIRAI_KBN_NM(区分)」の値を取得または設定する。
		/// </summary>
		public virtual string M1hojuirai_kbn_nm
		{
			get
			{
				return this._m1hojuirai_kbn_nm;
			}
			set
			{
				this._m1hojuirai_kbn_nm = value;
			}
		}

		/// <summary>
		/// 項目「M1SINSEI_JOTAINM(状態)」の値を取得または設定する。
		/// </summary>
		public virtual string M1sinsei_jotainm
		{
			get
			{
				return this._m1sinsei_jotainm;
			}
			set
			{
				this._m1sinsei_jotainm = value;
			}
		}


		/// <summary>
		/// 項目「M1ITEMSU(数量)」の値を取得または設定する。
		/// </summary>
		public virtual string M1itemsu
		{
			get
			{
				return this._m1itemsu;
			}
			set
			{
				this._m1itemsu = value;
			}
		}

		/// <summary>
		/// 項目「M1KINGAKU(金額)」の値を取得または設定する。
		/// </summary>
		public virtual string M1kingaku
		{
			get
			{
				return this._m1kingaku;
			}
			set
			{
				this._m1kingaku = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX(選択フラグ(隠し))」の値を取得または設定する。
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
		/// 項目「M1ENTERSYORIFLG(確定処理フラグ(隠し))」の値を取得または設定する。
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
		/// 項目「M1DTLIROKBN(明細色区分(隠し))」の値を取得または設定する。
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
		public Ta030f01M1ResultVO() : base()
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
			Ta030f01M1ResultVO compare = null;
			if (obj is Ta030f01M1ResultVO)
			{
				compare = (Ta030f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1hojuirai_kbn_nm != compare.M1hojuirai_kbn_nm)
			{
				return false;
			}
			if (_m1sinsei_jotainm != compare.M1sinsei_jotainm)
			{
				return false;
			}
			if (_m1itemsu != compare.M1itemsu)
			{
				return false;
			}
			if (_m1kingaku != compare.M1kingaku)
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
		/// <returns>現在のcom.xebio.bo.Ta030p01.Formvo.Ta030f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1hojuirai_kbn_nm:").Append(this._m1hojuirai_kbn_nm).AppendLine();
			str.Append("M1sinsei_jotainm:").Append(this._m1sinsei_jotainm).AppendLine();
			str.Append("M1itemsu:").Append(this._m1itemsu).AppendLine();
			str.Append("M1kingaku:").Append(this._m1kingaku).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
