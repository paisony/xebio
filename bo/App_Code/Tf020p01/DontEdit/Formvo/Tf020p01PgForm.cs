using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf020p01.Formvo
{
  /// <summary>
  /// Tf020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF020F01)のFormVO。
		/// </summary>
		private Tf020f01Form tf020f01Form;
		/// <summary>
		/// 画面(TF020F02)のFormVO。
		/// </summary>
		private Tf020f02Form tf020f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf020f01Form(商品経費振替申請（V） 一覧)を取得または設定する。
		/// </summary>
		public Tf020f01Form Tf020f01Form
		{
			get
			{
				return this.tf020f01Form;
			}
			set
			{
				this.tf020f01Form = value;
			}
		}

			
		/// <summary>
		/// Tf020f02Form(商品経費振替申請（V） 明細)を取得または設定する。
		/// </summary>
		public Tf020f02Form Tf020f02Form
		{
			get
			{
				return this.tf020f02Form;
			}
			set
			{
				this.tf020f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf020p01PgForm()
		{
			tf020f01Form = new Tf020f01Form();
			tf020f02Form = new Tf020f02Form();
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
			if (formId.Equals("Tf020f01"))
			{
				return this.tf020f01Form;
			}
			if (formId.Equals("Tf020f02"))
			{
				return this.tf020f02Form;
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
			if (formId.Equals("Tf020f01"))
			{
				this.tf020f01Form=(Tf020f01Form)formVO;
			}
			if (formId.Equals("Tf020f02"))
			{
				this.tf020f02Form=(Tf020f02Form)formVO;
			}
		}

		#endregion

	}
}
