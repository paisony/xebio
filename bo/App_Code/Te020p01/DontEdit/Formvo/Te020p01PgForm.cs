using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te020p01.Formvo
{
  /// <summary>
  /// Te020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE020F01)のFormVO。
		/// </summary>
		private Te020f01Form te020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te020f01Form(移動出荷入力（ﾏﾆｭｱﾙ）)を取得または設定する。
		/// </summary>
		public Te020f01Form Te020f01Form
		{
			get
			{
				return this.te020f01Form;
			}
			set
			{
				this.te020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te020p01PgForm()
		{
			te020f01Form = new Te020f01Form();
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
			if (formId.Equals("Te020f01"))
			{
				return this.te020f01Form;
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
			if (formId.Equals("Te020f01"))
			{
				this.te020f01Form=(Te020f01Form)formVO;
			}
		}

		#endregion

	}
}
