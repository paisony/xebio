using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj060p01.Formvo
{
  /// <summary>
  /// Tj060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ060F01)のFormVO。
		/// </summary>
		private Tj060f01Form tj060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj060f01Form(棚卸報告書再出力(X))を取得または設定する。
		/// </summary>
		public Tj060f01Form Tj060f01Form
		{
			get
			{
				return this.tj060f01Form;
			}
			set
			{
				this.tj060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj060p01PgForm()
		{
			tj060f01Form = new Tj060f01Form();
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
			if (formId.Equals("Tj060f01"))
			{
				return this.tj060f01Form;
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
			if (formId.Equals("Tj060f01"))
			{
				this.tj060f01Form=(Tj060f01Form)formVO;
			}
		}

		#endregion

	}
}
