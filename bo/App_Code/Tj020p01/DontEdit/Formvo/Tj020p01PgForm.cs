using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj020p01.Formvo
{
  /// <summary>
  /// Tj020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ020F01)のFormVO。
		/// </summary>
		private Tj020f01Form tj020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj020f01Form(棚卸送信処理(X))を取得または設定する。
		/// </summary>
		public Tj020f01Form Tj020f01Form
		{
			get
			{
				return this.tj020f01Form;
			}
			set
			{
				this.tj020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj020p01PgForm()
		{
			tj020f01Form = new Tj020f01Form();
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
			if (formId.Equals("Tj020f01"))
			{
				return this.tj020f01Form;
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
			if (formId.Equals("Tj020f01"))
			{
				this.tj020f01Form=(Tj020f01Form)formVO;
			}
		}

		#endregion

	}
}
