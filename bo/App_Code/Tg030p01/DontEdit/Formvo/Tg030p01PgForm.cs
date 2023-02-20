using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg030p01.Formvo
{
  /// <summary>
  /// Tg030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG030F01)のFormVO。
		/// </summary>
		private Tg030f01Form tg030f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg030f01Form(社員バーコード発行)を取得または設定する。
		/// </summary>
		public Tg030f01Form Tg030f01Form
		{
			get
			{
				return this.tg030f01Form;
			}
			set
			{
				this.tg030f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg030p01PgForm()
		{
			tg030f01Form = new Tg030f01Form();
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
			if (formId.Equals("Tg030f01"))
			{
				return this.tg030f01Form;
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
			if (formId.Equals("Tg030f01"))
			{
				this.tg030f01Form=(Tg030f01Form)formVO;
			}
		}

		#endregion

	}
}
