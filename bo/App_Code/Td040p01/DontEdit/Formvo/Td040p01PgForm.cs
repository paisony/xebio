using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td040p01.Formvo
{
  /// <summary>
  /// Td040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD040F01)のFormVO。
		/// </summary>
		private Td040f01Form td040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td040f01Form(返品実績確認 一覧)を取得または設定する。
		/// </summary>
		public Td040f01Form Td040f01Form
		{
			get
			{
				return this.td040f01Form;
			}
			set
			{
				this.td040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td040p01PgForm()
		{
			td040f01Form = new Td040f01Form();
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
			if (formId.Equals("Td040f01"))
			{
				return this.td040f01Form;
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
			if (formId.Equals("Td040f01"))
			{
				this.td040f01Form=(Td040f01Form)formVO;
			}
		}

		#endregion

	}
}
