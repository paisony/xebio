using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf060p01.Formvo
{
  /// <summary>
  /// Tf060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF060F01)のFormVO。
		/// </summary>
		private Tf060f01Form tf060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf060f01Form(予算登録)を取得または設定する。
		/// </summary>
		public Tf060f01Form Tf060f01Form
		{
			get
			{
				return this.tf060f01Form;
			}
			set
			{
				this.tf060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf060p01PgForm()
		{
			tf060f01Form = new Tf060f01Form();
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
			if (formId.Equals("Tf060f01"))
			{
				return this.tf060f01Form;
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
			if (formId.Equals("Tf060f01"))
			{
				this.tf060f01Form=(Tf060f01Form)formVO;
			}
		}

		#endregion

	}
}
