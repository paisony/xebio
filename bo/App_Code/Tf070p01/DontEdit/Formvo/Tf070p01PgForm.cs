using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf070p01.Formvo
{
  /// <summary>
  /// Tf070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF070F01)のFormVO。
		/// </summary>
		private Tf070f01Form tf070f01Form;
		/// <summary>
		/// 画面(TF070F02)のFormVO。
		/// </summary>
		private Tf070f02Form tf070f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf070f01Form(盗難品登録 一覧)を取得または設定する。
		/// </summary>
		public Tf070f01Form Tf070f01Form
		{
			get
			{
				return this.tf070f01Form;
			}
			set
			{
				this.tf070f01Form = value;
			}
		}

			
		/// <summary>
		/// Tf070f02Form(盗難品登録 明細)を取得または設定する。
		/// </summary>
		public Tf070f02Form Tf070f02Form
		{
			get
			{
				return this.tf070f02Form;
			}
			set
			{
				this.tf070f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf070p01PgForm()
		{
			tf070f01Form = new Tf070f01Form();
			tf070f02Form = new Tf070f02Form();
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
			if (formId.Equals("Tf070f01"))
			{
				return this.tf070f01Form;
			}
			if (formId.Equals("Tf070f02"))
			{
				return this.tf070f02Form;
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
			if (formId.Equals("Tf070f01"))
			{
				this.tf070f01Form=(Tf070f01Form)formVO;
			}
			if (formId.Equals("Tf070f02"))
			{
				this.tf070f02Form=(Tf070f02Form)formVO;
			}
		}

		#endregion

	}
}
