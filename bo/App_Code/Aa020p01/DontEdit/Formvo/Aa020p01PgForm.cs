using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Aa020p01.Formvo
{
  /// <summary>
  /// Aa020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Aa020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(AA020F01)のFormVO。
		/// </summary>
		private Aa020f01Form aa020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Aa020f01Form(■シール発行テスト)を取得または設定する。
		/// </summary>
		public Aa020f01Form Aa020f01Form
		{
			get
			{
				return this.aa020f01Form;
			}
			set
			{
				this.aa020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Aa020p01PgForm()
		{
			aa020f01Form = new Aa020f01Form();
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
			if (formId.Equals("Aa020f01"))
			{
				return this.aa020f01Form;
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
			if (formId.Equals("Aa020f01"))
			{
				this.aa020f01Form=(Aa020f01Form)formVO;
			}
		}

		#endregion

	}
}
