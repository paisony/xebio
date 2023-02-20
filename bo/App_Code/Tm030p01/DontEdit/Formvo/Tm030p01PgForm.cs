using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm030p01.Formvo
{
  /// <summary>
  /// Tm030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM030F01)のFormVO。
		/// </summary>
		private Tm030f01Form tm030f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm030f01Form(お知らせ機能)を取得または設定する。
		/// </summary>
		public Tm030f01Form Tm030f01Form
		{
			get
			{
				return this.tm030f01Form;
			}
			set
			{
				this.tm030f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm030p01PgForm()
		{
			tm030f01Form = new Tm030f01Form();
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
			if (formId.Equals("Tm030f01"))
			{
				return this.tm030f01Form;
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
			if (formId.Equals("Tm030f01"))
			{
				this.tm030f01Form=(Tm030f01Form)formVO;
			}
		}

		#endregion

	}
}
