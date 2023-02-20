using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te070p01.Formvo
{
  /// <summary>
  /// Te070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE070F01)のFormVO。
		/// </summary>
		private Te070f01Form te070f01Form;
		/// <summary>
		/// 画面(TE070F02)のFormVO。
		/// </summary>
		private Te070f02Form te070f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te070f01Form(移動入荷検索 一覧)を取得または設定する。
		/// </summary>
		public Te070f01Form Te070f01Form
		{
			get
			{
				return this.te070f01Form;
			}
			set
			{
				this.te070f01Form = value;
			}
		}

			
		/// <summary>
		/// Te070f02Form(移動入荷検索 明細)を取得または設定する。
		/// </summary>
		public Te070f02Form Te070f02Form
		{
			get
			{
				return this.te070f02Form;
			}
			set
			{
				this.te070f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te070p01PgForm()
		{
			te070f01Form = new Te070f01Form();
			te070f02Form = new Te070f02Form();
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
			if (formId.Equals("Te070f01"))
			{
				return this.te070f01Form;
			}
			if (formId.Equals("Te070f02"))
			{
				return this.te070f02Form;
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
			if (formId.Equals("Te070f01"))
			{
				this.te070f01Form=(Te070f01Form)formVO;
			}
			if (formId.Equals("Te070f02"))
			{
				this.te070f02Form=(Te070f02Form)formVO;
			}
		}

		#endregion

	}
}
