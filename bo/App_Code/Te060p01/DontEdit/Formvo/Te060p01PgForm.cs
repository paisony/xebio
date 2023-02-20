using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te060p01.Formvo
{
  /// <summary>
  /// Te060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE060F01)のFormVO。
		/// </summary>
		private Te060f01Form te060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te060f01Form(再入荷防止検索)を取得または設定する。
		/// </summary>
		public Te060f01Form Te060f01Form
		{
			get
			{
				return this.te060f01Form;
			}
			set
			{
				this.te060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te060p01PgForm()
		{
			te060f01Form = new Te060f01Form();
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
			if (formId.Equals("Te060f01"))
			{
				return this.te060f01Form;
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
			if (formId.Equals("Te060f01"))
			{
				this.te060f01Form=(Te060f01Form)formVO;
			}
		}

		#endregion

	}
}
