using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj150p01.Formvo
{
  /// <summary>
  /// Tj150p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj150p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ150F01)のFormVO。
		/// </summary>
		private Tj150f01Form tj150f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj150f01Form(棚卸終了処理(X))を取得または設定する。
		/// </summary>
		public Tj150f01Form Tj150f01Form
		{
			get
			{
				return this.tj150f01Form;
			}
			set
			{
				this.tj150f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj150p01PgForm()
		{
			tj150f01Form = new Tj150f01Form();
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
			if (formId.Equals("Tj150f01"))
			{
				return this.tj150f01Form;
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
			if (formId.Equals("Tj150f01"))
			{
				this.tj150f01Form=(Tj150f01Form)formVO;
			}
		}

		#endregion

	}
}
