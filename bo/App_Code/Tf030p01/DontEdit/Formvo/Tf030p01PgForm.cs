using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf030p01.Formvo
{
  /// <summary>
  /// Tf030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF030F01)のFormVO。
		/// </summary>
		private Tf030f01Form tf030f01Form;
		/// <summary>
		/// 画面(TF030F02)のFormVO。
		/// </summary>
		private Tf030f02Form tf030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf030f01Form(経費未払登録 一覧)を取得または設定する。
		/// </summary>
		public Tf030f01Form Tf030f01Form
		{
			get
			{
				return this.tf030f01Form;
			}
			set
			{
				this.tf030f01Form = value;
			}
		}

			
		/// <summary>
		/// Tf030f02Form(経費未払登録 明細)を取得または設定する。
		/// </summary>
		public Tf030f02Form Tf030f02Form
		{
			get
			{
				return this.tf030f02Form;
			}
			set
			{
				this.tf030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf030p01PgForm()
		{
			tf030f01Form = new Tf030f01Form();
			tf030f02Form = new Tf030f02Form();
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
			if (formId.Equals("Tf030f01"))
			{
				return this.tf030f01Form;
			}
			if (formId.Equals("Tf030f02"))
			{
				return this.tf030f02Form;
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
			if (formId.Equals("Tf030f01"))
			{
				this.tf030f01Form=(Tf030f01Form)formVO;
			}
			if (formId.Equals("Tf030f02"))
			{
				this.tf030f02Form=(Tf030f02Form)formVO;
			}
		}

		#endregion

	}
}
