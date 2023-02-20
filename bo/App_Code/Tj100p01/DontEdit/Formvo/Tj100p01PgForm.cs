using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj100p01.Formvo
{
  /// <summary>
  /// Tj100p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj100p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ100F01)のFormVO。
		/// </summary>
		private Tj100f01Form tj100f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj100f01Form(棚卸取漏れ欠番検索(V))を取得または設定する。
		/// </summary>
		public Tj100f01Form Tj100f01Form
		{
			get
			{
				return this.tj100f01Form;
			}
			set
			{
				this.tj100f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj100p01PgForm()
		{
			tj100f01Form = new Tj100f01Form();
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
			if (formId.Equals("Tj100f01"))
			{
				return this.tj100f01Form;
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
			if (formId.Equals("Tj100f01"))
			{
				this.tj100f01Form=(Tj100f01Form)formVO;
			}
		}

		#endregion

	}
}
