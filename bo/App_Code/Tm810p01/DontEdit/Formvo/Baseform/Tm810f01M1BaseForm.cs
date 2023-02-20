using Common.Advanced.Util;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tm810p01.Formvo.Baseform
{
  /// <summary>
  /// Tm810f01 明細M1のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm810f01M1BaseForm : StandardBaseM1Form
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「M1DOWNLOAD_FILE_NAME(ダウンロードファイル名)」の値
		/// </summary>
		private string _m1download_file_name;

		/// <summary>
		/// 処理モード
		/// </summary>
		private DbuModeCode _commode;
		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「M1DOWNLOAD_FILE_NAME(ダウンロードファイル名)」の値を取得または設定する。
		/// </summary>
		public virtual string M1download_file_name
		{
			get
			{
				return this._m1download_file_name;
			}
			set
			{
				this._m1download_file_name = value;
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
		public Tm810f01M1BaseForm()
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
			Tm810f01M1BaseForm compare = null;
			if (obj is Tm810f01M1BaseForm)
			{
				compare = (Tm810f01M1BaseForm)obj;
			}
			else
			{
				return false;
			}

			if (_m1download_file_name != compare.M1download_file_name)
			{
				return false;
			}

			return true;
		}
		/// <summary>
		/// 特定の型のハッシュ関数として機能します。
		/// ハッシュ アルゴリズムや、ハッシュ テーブルのようなデータ構造での使用に適しています。
		/// </summary>
		/// <returns>現在のcom.xebio.bo.Tm810p01.Formvo.Tm810f01M1Formのハッシュ コード。</returns>
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

			str.Append("M1download_file_name:").Append(this._m1download_file_name).AppendLine();

			return str.ToString();
		}

		#region FormId取得
		/// <summary>
		/// セルフカスタマイズ用フォームIDを取得します。
		/// </summary>
		/// <returns>フォームID</returns>
		protected override string SCGetFormId()
		{
			return "Tm810f01";
		}
		#endregion
		#endregion

	}
}
