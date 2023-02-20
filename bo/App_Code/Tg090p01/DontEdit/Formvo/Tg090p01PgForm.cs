using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg090p01.Formvo
{
  /// <summary>
  /// Tg090p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg090p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG090F01)のFormVO。
		/// </summary>
		private Tg090f01Form tg090f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg090f01Form(不良品一覧出力)を取得または設定する。
		/// </summary>
		public Tg090f01Form Tg090f01Form
		{
			get
			{
				return this.tg090f01Form;
			}
			set
			{
				this.tg090f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg090p01PgForm()
		{
			tg090f01Form = new Tg090f01Form();
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
			if (formId.Equals("Tg090f01"))
			{
				return this.tg090f01Form;
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
			if (formId.Equals("Tg090f01"))
			{
				this.tg090f01Form=(Tg090f01Form)formVO;
			}
		}

		#endregion

	}
}
