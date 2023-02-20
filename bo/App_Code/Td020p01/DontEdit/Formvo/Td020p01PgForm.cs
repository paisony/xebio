using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td020p01.Formvo
{
  /// <summary>
  /// Td020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD020F01)のFormVO。
		/// </summary>
		private Td020f01Form td020f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td020f01Form(返品入力(ﾏﾆｭｱﾙ))を取得または設定する。
		/// </summary>
		public Td020f01Form Td020f01Form
		{
			get
			{
				return this.td020f01Form;
			}
			set
			{
				this.td020f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td020p01PgForm()
		{
			td020f01Form = new Td020f01Form();
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
			if (formId.Equals("Td020f01"))
			{
				return this.td020f01Form;
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
			if (formId.Equals("Td020f01"))
			{
				this.td020f01Form=(Td020f01Form)formVO;
			}
		}

		#endregion

	}
}
