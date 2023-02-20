using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb040p01.Formvo
{
  /// <summary>
  /// Tb040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB040F01)のFormVO。
		/// </summary>
		private Tb040f01Form tb040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb040f01Form(仕入一括確定)を取得または設定する。
		/// </summary>
		public Tb040f01Form Tb040f01Form
		{
			get
			{
				return this.tb040f01Form;
			}
			set
			{
				this.tb040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb040p01PgForm()
		{
			tb040f01Form = new Tb040f01Form();
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
			if (formId.Equals("Tb040f01"))
			{
				return this.tb040f01Form;
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
			if (formId.Equals("Tb040f01"))
			{
				this.tb040f01Form=(Tb040f01Form)formVO;
			}
		}

		#endregion

	}
}
