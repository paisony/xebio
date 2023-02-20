using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tl020p01.Formvo
{
  /// <summary>
  /// Tl020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TL020F01)のFormVO。
		/// </summary>
		private Tl020f01Form tl020f01Form;
		/// <summary>
		/// 画面(TL020F02)のFormVO。
		/// </summary>
		private Tl020f02Form tl020f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tl020f01Form(売変検索(X) 一覧)を取得または設定する。
		/// </summary>
		public Tl020f01Form Tl020f01Form
		{
			get
			{
				return this.tl020f01Form;
			}
			set
			{
				this.tl020f01Form = value;
			}
		}

			
		/// <summary>
		/// Tl020f02Form(売変検索(X) 明細)を取得または設定する。
		/// </summary>
		public Tl020f02Form Tl020f02Form
		{
			get
			{
				return this.tl020f02Form;
			}
			set
			{
				this.tl020f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl020p01PgForm()
		{
			tl020f01Form = new Tl020f01Form();
			tl020f02Form = new Tl020f02Form();
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
			if (formId.Equals("Tl020f01"))
			{
				return this.tl020f01Form;
			}
			if (formId.Equals("Tl020f02"))
			{
				return this.tl020f02Form;
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
			if (formId.Equals("Tl020f01"))
			{
				this.tl020f01Form=(Tl020f01Form)formVO;
			}
			if (formId.Equals("Tl020f02"))
			{
				this.tl020f02Form=(Tl020f02Form)formVO;
			}
		}

		#endregion

	}
}
