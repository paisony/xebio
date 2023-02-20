using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Tj180p01.Formvo.Baseform
{
  /// <summary>
  /// Tj180f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj180f01BaseForm : StandardBaseForm, IFormVO
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
		/// 項目「KIJUNBI_ZEN_TYOBOZAIKO_SU(基準日前日帳簿在庫数)」の値
		/// </summary>
		private string _kijunbi_zen_tyobozaiko_su;
		/// <summary>
		/// 項目「TOJITSUURI_SU(当日売上数)」の値
		/// </summary>
		private string _tojitsuuri_su;
		/// <summary>
		/// 項目「TOJITSUNYUSYUKKA_SU(当日入出荷数)」の値
		/// </summary>
		private string _tojitsunyusyukka_su;
		/// <summary>
		/// 項目「TOJITSUYOSOKUZAI_SU(当日予測在庫数)」の値
		/// </summary>
		private string _tojitsuyosokuzai_su;
		/// <summary>
		/// 項目「TENPOTANAOROSI_SU(店舗棚卸数)」の値
		/// </summary>
		private string _tenpotanaorosi_su;
		/// <summary>
		/// 項目「GYOSYATANAOROSI_SU(業者棚卸数)」の値
		/// </summary>
		private string _gyosyatanaorosi_su;
		/// <summary>
		/// 項目「SAI_SU(差異数)」の値
		/// </summary>
		private string _sai_su;

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
		/// 項目「KIJUNBI_ZEN_TYOBOZAIKO_SU(基準日前日帳簿在庫数)」の値を取得または設定する。
		/// </summary>
		public virtual string Kijunbi_zen_tyobozaiko_su
		{
			get
			{
				return this._kijunbi_zen_tyobozaiko_su;
			}
			set
			{
				this._kijunbi_zen_tyobozaiko_su = value;
			}
		}
		/// <summary>
		/// 項目「TOJITSUURI_SU(当日売上数)」の値を取得または設定する。
		/// </summary>
		public virtual string Tojitsuuri_su
		{
			get
			{
				return this._tojitsuuri_su;
			}
			set
			{
				this._tojitsuuri_su = value;
			}
		}
		/// <summary>
		/// 項目「TOJITSUNYUSYUKKA_SU(当日入出荷数)」の値を取得または設定する。
		/// </summary>
		public virtual string Tojitsunyusyukka_su
		{
			get
			{
				return this._tojitsunyusyukka_su;
			}
			set
			{
				this._tojitsunyusyukka_su = value;
			}
		}
		/// <summary>
		/// 項目「TOJITSUYOSOKUZAI_SU(当日予測在庫数)」の値を取得または設定する。
		/// </summary>
		public virtual string Tojitsuyosokuzai_su
		{
			get
			{
				return this._tojitsuyosokuzai_su;
			}
			set
			{
				this._tojitsuyosokuzai_su = value;
			}
		}
		/// <summary>
		/// 項目「TENPOTANAOROSI_SU(店舗棚卸数)」の値を取得または設定する。
		/// </summary>
		public virtual string Tenpotanaorosi_su
		{
			get
			{
				return this._tenpotanaorosi_su;
			}
			set
			{
				this._tenpotanaorosi_su = value;
			}
		}
		/// <summary>
		/// 項目「GYOSYATANAOROSI_SU(業者棚卸数)」の値を取得または設定する。
		/// </summary>
		public virtual string Gyosyatanaorosi_su
		{
			get
			{
				return this._gyosyatanaorosi_su;
			}
			set
			{
				this._gyosyatanaorosi_su = value;
			}
		}
		/// <summary>
		/// 項目「SAI_SU(差異数)」の値を取得または設定する。
		/// </summary>
		public virtual string Sai_su
		{
			get
			{
				return this._sai_su;
			}
			set
			{
				this._sai_su = value;
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj180f01BaseForm() : base()
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
			sb.Append("Kijunbi_zen_tyobozaiko_su:").Append(this._kijunbi_zen_tyobozaiko_su).AppendLine();
			sb.Append("Tojitsuuri_su:").Append(this._tojitsuuri_su).AppendLine();
			sb.Append("Tojitsunyusyukka_su:").Append(this._tojitsunyusyukka_su).AppendLine();
			sb.Append("Tojitsuyosokuzai_su:").Append(this._tojitsuyosokuzai_su).AppendLine();
			sb.Append("Tenpotanaorosi_su:").Append(this._tenpotanaorosi_su).AppendLine();
			sb.Append("Gyosyatanaorosi_su:").Append(this._gyosyatanaorosi_su).AppendLine();
			sb.Append("Sai_su:").Append(this._sai_su).AppendLine();
		
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
			return "Tj180f01";
		}
		#endregion

		#endregion
	}
}
