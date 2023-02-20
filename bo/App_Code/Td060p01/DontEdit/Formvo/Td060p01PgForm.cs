using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td060p01.Formvo
{
  /// <summary>
  /// Td060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD060F01)のFormVO。
		/// </summary>
		private Td060f01Form td060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td060f01Form(返品指示変更リスト出力)を取得または設定する。
		/// </summary>
		public Td060f01Form Td060f01Form
		{
			get
			{
				return this.td060f01Form;
			}
			set
			{
				this.td060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td060p01PgForm()
		{
			td060f01Form = new Td060f01Form();
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
			if (formId.Equals("Td060f01"))
			{
				return this.td060f01Form;
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
			if (formId.Equals("Td060f01"))
			{
				this.td060f01Form=(Td060f01Form)formVO;
			}
		}

		#endregion

	}
}
