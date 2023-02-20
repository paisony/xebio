using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te030p01.Formvo
{
  /// <summary>
  /// Te030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE030F01)のFormVO。
		/// </summary>
		private Te030f01Form te030f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te030f01Form(出荷差異リスト出力)を取得または設定する。
		/// </summary>
		public Te030f01Form Te030f01Form
		{
			get
			{
				return this.te030f01Form;
			}
			set
			{
				this.te030f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te030p01PgForm()
		{
			te030f01Form = new Te030f01Form();
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
			if (formId.Equals("Te030f01"))
			{
				return this.te030f01Form;
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
			if (formId.Equals("Te030f01"))
			{
				this.te030f01Form=(Te030f01Form)formVO;
			}
		}

		#endregion

	}
}
