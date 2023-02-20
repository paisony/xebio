using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg070p01.Formvo
{
  /// <summary>
  /// Tg070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG070F01)のFormVO。
		/// </summary>
		private Tg070f01Form tg070f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg070f01Form(インストアコード振替リスト出力)を取得または設定する。
		/// </summary>
		public Tg070f01Form Tg070f01Form
		{
			get
			{
				return this.tg070f01Form;
			}
			set
			{
				this.tg070f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg070p01PgForm()
		{
			tg070f01Form = new Tg070f01Form();
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
			if (formId.Equals("Tg070f01"))
			{
				return this.tg070f01Form;
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
			if (formId.Equals("Tg070f01"))
			{
				this.tg070f01Form=(Tg070f01Form)formVO;
			}
		}

		#endregion

	}
}
