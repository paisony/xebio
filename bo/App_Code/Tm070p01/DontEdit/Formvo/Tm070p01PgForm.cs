using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm070p01.Formvo
{
  /// <summary>
  /// Tm070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM070F01)のFormVO。
		/// </summary>
		private Tm070f01Form tm070f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm070f01Form(緊急担当者所属店変更)を取得または設定する。
		/// </summary>
		public Tm070f01Form Tm070f01Form
		{
			get
			{
				return this.tm070f01Form;
			}
			set
			{
				this.tm070f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm070p01PgForm()
		{
			tm070f01Form = new Tm070f01Form();
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
			if (formId.Equals("Tm070f01"))
			{
				return this.tm070f01Form;
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
			if (formId.Equals("Tm070f01"))
			{
				this.tm070f01Form=(Tm070f01Form)formVO;
			}
		}

		#endregion

	}
}
