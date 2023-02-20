using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tl030p01.Formvo
{
  /// <summary>
  /// Tl030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TL030F01)のFormVO。
		/// </summary>
		private Tl030f01Form tl030f01Form;
		/// <summary>
		/// 画面(TL030F02)のFormVO。
		/// </summary>
		private Tl030f02Form tl030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tl030f01Form(売変確定(X) 一覧)を取得または設定する。
		/// </summary>
		public Tl030f01Form Tl030f01Form
		{
			get
			{
				return this.tl030f01Form;
			}
			set
			{
				this.tl030f01Form = value;
			}
		}

			
		/// <summary>
		/// Tl030f02Form(売変確定(X) 明細)を取得または設定する。
		/// </summary>
		public Tl030f02Form Tl030f02Form
		{
			get
			{
				return this.tl030f02Form;
			}
			set
			{
				this.tl030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl030p01PgForm()
		{
			tl030f01Form = new Tl030f01Form();
			tl030f02Form = new Tl030f02Form();
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
			if (formId.Equals("Tl030f01"))
			{
				return this.tl030f01Form;
			}
			if (formId.Equals("Tl030f02"))
			{
				return this.tl030f02Form;
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
			if (formId.Equals("Tl030f01"))
			{
				this.tl030f01Form=(Tl030f01Form)formVO;
			}
			if (formId.Equals("Tl030f02"))
			{
				this.tl030f02Form=(Tl030f02Form)formVO;
			}
		}

		#endregion

	}
}
