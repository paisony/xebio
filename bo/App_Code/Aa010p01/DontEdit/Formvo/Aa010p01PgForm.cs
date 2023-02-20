using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Aa010p01.Formvo
{
  /// <summary>
  /// Aa010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Aa010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(AA010F01)のFormVO。
		/// </summary>
		private Aa010f01Form aa010f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Aa010f01Form(■印刷テスト)を取得または設定する。
		/// </summary>
		public Aa010f01Form Aa010f01Form
		{
			get
			{
				return this.aa010f01Form;
			}
			set
			{
				this.aa010f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Aa010p01PgForm()
		{
			aa010f01Form = new Aa010f01Form();
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
			if (formId.Equals("Aa010f01"))
			{
				return this.aa010f01Form;
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
			if (formId.Equals("Aa010f01"))
			{
				this.aa010f01Form=(Aa010f01Form)formVO;
			}
		}

		#endregion

	}
}
