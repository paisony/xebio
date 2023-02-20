using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj010p01.Formvo
{
  /// <summary>
  /// Tj010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ010F01)のFormVO。
		/// </summary>
		private Tj010f01Form tj010f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj010f01Form(棚卸送信処理(V))を取得または設定する。
		/// </summary>
		public Tj010f01Form Tj010f01Form
		{
			get
			{
				return this.tj010f01Form;
			}
			set
			{
				this.tj010f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj010p01PgForm()
		{
			tj010f01Form = new Tj010f01Form();
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
			if (formId.Equals("Tj010f01"))
			{
				return this.tj010f01Form;
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
			if (formId.Equals("Tj010f01"))
			{
				this.tj010f01Form=(Tj010f01Form)formVO;
			}
		}

		#endregion

	}
}
