using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm060p01.Formvo
{
  /// <summary>
  /// Tm060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM060F01)のFormVO。
		/// </summary>
		private Tm060f01Form tm060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm060f01Form(担当者マスタメンテナンス画面)を取得または設定する。
		/// </summary>
		public Tm060f01Form Tm060f01Form
		{
			get
			{
				return this.tm060f01Form;
			}
			set
			{
				this.tm060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm060p01PgForm()
		{
			tm060f01Form = new Tm060f01Form();
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
			if (formId.Equals("Tm060f01"))
			{
				return this.tm060f01Form;
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
			if (formId.Equals("Tm060f01"))
			{
				this.tm060f01Form=(Tm060f01Form)formVO;
			}
		}

		#endregion

	}
}
