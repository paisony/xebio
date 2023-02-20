using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te040p01.Formvo
{
  /// <summary>
  /// Te040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE040F01)のFormVO。
		/// </summary>
		private Te040f01Form te040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te040f01Form(移動出荷入力（再入荷防止）)を取得または設定する。
		/// </summary>
		public Te040f01Form Te040f01Form
		{
			get
			{
				return this.te040f01Form;
			}
			set
			{
				this.te040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te040p01PgForm()
		{
			te040f01Form = new Te040f01Form();
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
			if (formId.Equals("Te040f01"))
			{
				return this.te040f01Form;
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
			if (formId.Equals("Te040f01"))
			{
				this.te040f01Form=(Te040f01Form)formVO;
			}
		}

		#endregion

	}
}
