using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf040p01.Formvo
{
  /// <summary>
  /// Tf040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF040F01)のFormVO。
		/// </summary>
		private Tf040f01Form tf040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf040f01Form(小口現金登録)を取得または設定する。
		/// </summary>
		public Tf040f01Form Tf040f01Form
		{
			get
			{
				return this.tf040f01Form;
			}
			set
			{
				this.tf040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf040p01PgForm()
		{
			tf040f01Form = new Tf040f01Form();
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
			if (formId.Equals("Tf040f01"))
			{
				return this.tf040f01Form;
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
			if (formId.Equals("Tf040f01"))
			{
				this.tf040f01Form=(Tf040f01Form)formVO;
			}
		}

		#endregion

	}
}
