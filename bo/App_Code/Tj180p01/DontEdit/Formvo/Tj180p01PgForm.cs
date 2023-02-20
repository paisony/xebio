using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj180p01.Formvo
{
  /// <summary>
  /// Tj180p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj180p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ180F01)のFormVO。
		/// </summary>
		private Tj180f01Form tj180f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj180f01Form(棚卸進捗確認)を取得または設定する。
		/// </summary>
		public Tj180f01Form Tj180f01Form
		{
			get
			{
				return this.tj180f01Form;
			}
			set
			{
				this.tj180f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj180p01PgForm()
		{
			tj180f01Form = new Tj180f01Form();
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
			if (formId.Equals("Tj180f01"))
			{
				return this.tj180f01Form;
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
			if (formId.Equals("Tj180f01"))
			{
				this.tj180f01Form=(Tj180f01Form)formVO;
			}
		}

		#endregion

	}
}
