using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tk040p01.Formvo
{
  /// <summary>
  /// Tk040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TK040F01)のFormVO。
		/// </summary>
		private Tk040f01Form tk040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tk040f01Form(ロケーション検索)を取得または設定する。
		/// </summary>
		public Tk040f01Form Tk040f01Form
		{
			get
			{
				return this.tk040f01Form;
			}
			set
			{
				this.tk040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk040p01PgForm()
		{
			tk040f01Form = new Tk040f01Form();
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
			if (formId.Equals("Tk040f01"))
			{
				return this.tk040f01Form;
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
			if (formId.Equals("Tk040f01"))
			{
				this.tk040f01Form=(Tk040f01Form)formVO;
			}
		}

		#endregion

	}
}
