using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj090p01.Formvo
{
  /// <summary>
  /// Tj090p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj090p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ090F01)のFormVO。
		/// </summary>
		private Tj090f01Form tj090f01Form;
		/// <summary>
		/// 画面(TJ090F02)のFormVO。
		/// </summary>
		private Tj090f02Form tj090f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj090f01Form(棚卸アンマッチ検索(X) 一覧)を取得または設定する。
		/// </summary>
		public Tj090f01Form Tj090f01Form
		{
			get
			{
				return this.tj090f01Form;
			}
			set
			{
				this.tj090f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj090f02Form(棚卸アンマッチ検索(X) 明細)を取得または設定する。
		/// </summary>
		public Tj090f02Form Tj090f02Form
		{
			get
			{
				return this.tj090f02Form;
			}
			set
			{
				this.tj090f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj090p01PgForm()
		{
			tj090f01Form = new Tj090f01Form();
			tj090f02Form = new Tj090f02Form();
		}
		#endregion

		#region IProgramVO メンバ
		
		/// <summary>
		/// プログラムFormVO内に保持されているFormVOを取得する。
		/// </summary>
		/// <param name="formId">フォームID</param>
		/// <returns>プログラムFormVO内に保持されているFormVO</returns>
		public IFormVO GetFormVO(string formId)
		{
			if (formId.Equals("Tj090f01"))
			{
				return this.tj090f01Form;
			}
			if (formId.Equals("Tj090f02"))
			{
				return this.tj090f02Form;
			}

			return null;
		}


		
		/// <summary>
		/// プログラムFormVO内に保持されているFormVOに設定する。
		/// </summary>
		/// <param name="formId">フォームID</param>
		/// <param name="formVO">プログラムFormVO内に保持されているFormVO</param>
		public void SetFormVO(string formId, object formVO)
		{
			if (formId.Equals("Tj090f01"))
			{
				this.tj090f01Form=(Tj090f01Form)formVO;
			}
			if (formId.Equals("Tj090f02"))
			{
				this.tj090f02Form=(Tj090f02Form)formVO;
			}
		}

		#endregion

	}
}
