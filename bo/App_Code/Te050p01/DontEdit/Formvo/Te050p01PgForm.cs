using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te050p01.Formvo
{
  /// <summary>
  /// Te050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE050F01)のFormVO。
		/// </summary>
		private Te050f01Form te050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te050f01Form(再入荷防止登録)を取得または設定する。
		/// </summary>
		public Te050f01Form Te050f01Form
		{
			get
			{
				return this.te050f01Form;
			}
			set
			{
				this.te050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te050p01PgForm()
		{
			te050f01Form = new Te050f01Form();
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
			if (formId.Equals("Te050f01"))
			{
				return this.te050f01Form;
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
			if (formId.Equals("Te050f01"))
			{
				this.te050f01Form=(Te050f01Form)formVO;
			}
		}

		#endregion

	}
}
