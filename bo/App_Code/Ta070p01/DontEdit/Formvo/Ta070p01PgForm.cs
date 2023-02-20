using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta070p01.Formvo
{
  /// <summary>
  /// Ta070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA070F01)のFormVO。
		/// </summary>
		private Ta070f01Form ta070f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta070f01Form(自動定数変更)を取得または設定する。
		/// </summary>
		public Ta070f01Form Ta070f01Form
		{
			get
			{
				return this.ta070f01Form;
			}
			set
			{
				this.ta070f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta070p01PgForm()
		{
			ta070f01Form = new Ta070f01Form();
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
			if (formId.Equals("Ta070f01"))
			{
				return this.ta070f01Form;
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
			if (formId.Equals("Ta070f01"))
			{
				this.ta070f01Form=(Ta070f01Form)formVO;
			}
		}

		#endregion

	}
}
