using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tk020p01.Formvo
{
  /// <summary>
  /// Tk020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TK020F01)のFormVO。
		/// </summary>
		private Tk020f01Form tk020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tk020f01Form(評価損処理)を取得または設定する。
		/// </summary>
		public Tk020f01Form Tk020f01Form
		{
			get
			{
				return this.tk020f01Form;
			}
			set
			{
				this.tk020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk020p01PgForm()
		{
			tk020f01Form = new Tk020f01Form();
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
			if (formId.Equals("Tk020f01"))
			{
				return this.tk020f01Form;
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
			if (formId.Equals("Tk020f01"))
			{
				this.tk020f01Form=(Tk020f01Form)formVO;
			}
		}

		#endregion

	}
}
