using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj080p01.Formvo
{
  /// <summary>
  /// Tj080p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj080p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ080F01)のFormVO。
		/// </summary>
		private Tj080f01Form tj080f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj080f01Form(棚卸状況確認(X))を取得または設定する。
		/// </summary>
		public Tj080f01Form Tj080f01Form
		{
			get
			{
				return this.tj080f01Form;
			}
			set
			{
				this.tj080f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj080p01PgForm()
		{
			tj080f01Form = new Tj080f01Form();
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
			if (formId.Equals("Tj080f01"))
			{
				return this.tj080f01Form;
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
			if (formId.Equals("Tj080f01"))
			{
				this.tj080f01Form=(Tj080f01Form)formVO;
			}
		}

		#endregion

	}
}
