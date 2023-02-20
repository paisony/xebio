using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj110p01.Formvo
{
  /// <summary>
  /// Tj110p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj110p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ110F01)のFormVO。
		/// </summary>
		private Tj110f01Form tj110f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj110f01Form(棚卸取漏れ欠番検索(X))を取得または設定する。
		/// </summary>
		public Tj110f01Form Tj110f01Form
		{
			get
			{
				return this.tj110f01Form;
			}
			set
			{
				this.tj110f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj110p01PgForm()
		{
			tj110f01Form = new Tj110f01Form();
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
			if (formId.Equals("Tj110f01"))
			{
				return this.tj110f01Form;
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
			if (formId.Equals("Tj110f01"))
			{
				this.tj110f01Form=(Tj110f01Form)formVO;
			}
		}

		#endregion

	}
}
