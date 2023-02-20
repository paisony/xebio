using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj140p01.Formvo
{
  /// <summary>
  /// Tj140p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj140p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ140F01)のFormVO。
		/// </summary>
		private Tj140f01Form tj140f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj140f01Form(棚卸終了処理(V))を取得または設定する。
		/// </summary>
		public Tj140f01Form Tj140f01Form
		{
			get
			{
				return this.tj140f01Form;
			}
			set
			{
				this.tj140f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj140p01PgForm()
		{
			tj140f01Form = new Tj140f01Form();
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
			if (formId.Equals("Tj140f01"))
			{
				return this.tj140f01Form;
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
			if (formId.Equals("Tj140f01"))
			{
				this.tj140f01Form=(Tj140f01Form)formVO;
			}
		}

		#endregion

	}
}
