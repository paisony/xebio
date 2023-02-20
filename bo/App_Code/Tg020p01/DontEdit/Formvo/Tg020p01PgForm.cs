using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg020p01.Formvo
{
  /// <summary>
  /// Tg020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG020F01)のFormVO。
		/// </summary>
		private Tg020f01Form tg020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg020f01Form(割引シール発行)を取得または設定する。
		/// </summary>
		public Tg020f01Form Tg020f01Form
		{
			get
			{
				return this.tg020f01Form;
			}
			set
			{
				this.tg020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg020p01PgForm()
		{
			tg020f01Form = new Tg020f01Form();
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
			if (formId.Equals("Tg020f01"))
			{
				return this.tg020f01Form;
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
			if (formId.Equals("Tg020f01"))
			{
				this.tg020f01Form=(Tg020f01Form)formVO;
			}
		}

		#endregion

	}
}
