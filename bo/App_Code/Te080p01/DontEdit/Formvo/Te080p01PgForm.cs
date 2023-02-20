using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te080p01.Formvo
{
  /// <summary>
  /// Te080p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te080p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE080F01)のFormVO。
		/// </summary>
		private Te080f01Form te080f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te080f01Form(移動入荷一括確定)を取得または設定する。
		/// </summary>
		public Te080f01Form Te080f01Form
		{
			get
			{
				return this.te080f01Form;
			}
			set
			{
				this.te080f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te080p01PgForm()
		{
			te080f01Form = new Te080f01Form();
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
			if (formId.Equals("Te080f01"))
			{
				return this.te080f01Form;
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
			if (formId.Equals("Te080f01"))
			{
				this.te080f01Form=(Te080f01Form)formVO;
			}
		}

		#endregion

	}
}
