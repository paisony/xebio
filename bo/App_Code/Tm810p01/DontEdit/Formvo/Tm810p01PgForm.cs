using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm810p01.Formvo
{
  /// <summary>
  /// Tm810p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm810p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM810F01)のFormVO。
		/// </summary>
		private Tm810f01Form tm810f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm810f01Form(複数帳票出力画面)を取得または設定する。
		/// </summary>
		public Tm810f01Form Tm810f01Form
		{
			get
			{
				return this.tm810f01Form;
			}
			set
			{
				this.tm810f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm810p01PgForm()
		{
			tm810f01Form = new Tm810f01Form();
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
			if (formId.Equals("Tm810f01"))
			{
				return this.tm810f01Form;
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
			if (formId.Equals("Tm810f01"))
			{
				this.tm810f01Form=(Tm810f01Form)formVO;
			}
		}

		#endregion

	}
}
