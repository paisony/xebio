using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj070p01.Formvo
{
  /// <summary>
  /// Tj070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ070F01)のFormVO。
		/// </summary>
		private Tj070f01Form tj070f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj070f01Form(棚卸状況確認(V))を取得または設定する。
		/// </summary>
		public Tj070f01Form Tj070f01Form
		{
			get
			{
				return this.tj070f01Form;
			}
			set
			{
				this.tj070f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj070p01PgForm()
		{
			tj070f01Form = new Tj070f01Form();
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
			if (formId.Equals("Tj070f01"))
			{
				return this.tj070f01Form;
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
			if (formId.Equals("Tj070f01"))
			{
				this.tj070f01Form=(Tj070f01Form)formVO;
			}
		}

		#endregion

	}
}
