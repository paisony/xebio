using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te090p01.Formvo
{
  /// <summary>
  /// Te090p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te090p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE090F01)のFormVO。
		/// </summary>
		private Te090f01Form te090f01Form;
		/// <summary>
		/// 画面(TE090F02)のFormVO。
		/// </summary>
		private Te090f02Form te090f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te090f01Form(移動入荷確定 一覧)を取得または設定する。
		/// </summary>
		public Te090f01Form Te090f01Form
		{
			get
			{
				return this.te090f01Form;
			}
			set
			{
				this.te090f01Form = value;
			}
		}

			
		/// <summary>
		/// Te090f02Form(移動入荷確定 明細)を取得または設定する。
		/// </summary>
		public Te090f02Form Te090f02Form
		{
			get
			{
				return this.te090f02Form;
			}
			set
			{
				this.te090f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te090p01PgForm()
		{
			te090f01Form = new Te090f01Form();
			te090f02Form = new Te090f02Form();
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
			if (formId.Equals("Te090f01"))
			{
				return this.te090f01Form;
			}
			if (formId.Equals("Te090f02"))
			{
				return this.te090f02Form;
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
			if (formId.Equals("Te090f01"))
			{
				this.te090f01Form=(Te090f01Form)formVO;
			}
			if (formId.Equals("Te090f02"))
			{
				this.te090f02Form=(Te090f02Form)formVO;
			}
		}

		#endregion

	}
}
