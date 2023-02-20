using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tk030p01.Formvo
{
  /// <summary>
  /// Tk030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TK030F01)のFormVO。
		/// </summary>
		private Tk030f01Form tk030f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tk030f01Form(評価損NB一括確定)を取得または設定する。
		/// </summary>
		public Tk030f01Form Tk030f01Form
		{
			get
			{
				return this.tk030f01Form;
			}
			set
			{
				this.tk030f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk030p01PgForm()
		{
			tk030f01Form = new Tk030f01Form();
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
			if (formId.Equals("Tk030f01"))
			{
				return this.tk030f01Form;
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
			if (formId.Equals("Tk030f01"))
			{
				this.tk030f01Form=(Tk030f01Form)formVO;
			}
		}

		#endregion

	}
}
