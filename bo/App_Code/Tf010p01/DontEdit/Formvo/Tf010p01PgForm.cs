using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf010p01.Formvo
{
  /// <summary>
  /// Tf010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF010F01)のFormVO。
		/// </summary>
		private Tf010f01Form tf010f01Form;
		/// <summary>
		/// 画面(TF010F02)のFormVO。
		/// </summary>
		private Tf010f02Form tf010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf010f01Form(商品経費振替確定 一覧)を取得または設定する。
		/// </summary>
		public Tf010f01Form Tf010f01Form
		{
			get
			{
				return this.tf010f01Form;
			}
			set
			{
				this.tf010f01Form = value;
			}
		}

			
		/// <summary>
		/// Tf010f02Form(商品経費振替確定 明細)を取得または設定する。
		/// </summary>
		public Tf010f02Form Tf010f02Form
		{
			get
			{
				return this.tf010f02Form;
			}
			set
			{
				this.tf010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf010p01PgForm()
		{
			tf010f01Form = new Tf010f01Form();
			tf010f02Form = new Tf010f02Form();
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
			if (formId.Equals("Tf010f01"))
			{
				return this.tf010f01Form;
			}
			if (formId.Equals("Tf010f02"))
			{
				return this.tf010f02Form;
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
			if (formId.Equals("Tf010f01"))
			{
				this.tf010f01Form=(Tf010f01Form)formVO;
			}
			if (formId.Equals("Tf010f02"))
			{
				this.tf010f02Form=(Tf010f02Form)formVO;
			}
		}

		#endregion

	}
}
