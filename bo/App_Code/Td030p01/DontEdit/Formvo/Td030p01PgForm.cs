using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td030p01.Formvo
{
  /// <summary>
  /// Td030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD030F01)のFormVO。
		/// </summary>
		private Td030f01Form td030f01Form;
		/// <summary>
		/// 画面(TD030F02)のFormVO。
		/// </summary>
		private Td030f02Form td030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td030f01Form(返品検索 一覧)を取得または設定する。
		/// </summary>
		public Td030f01Form Td030f01Form
		{
			get
			{
				return this.td030f01Form;
			}
			set
			{
				this.td030f01Form = value;
			}
		}

			
		/// <summary>
		/// Td030f02Form(返品検索 明細)を取得または設定する。
		/// </summary>
		public Td030f02Form Td030f02Form
		{
			get
			{
				return this.td030f02Form;
			}
			set
			{
				this.td030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td030p01PgForm()
		{
			td030f01Form = new Td030f01Form();
			td030f02Form = new Td030f02Form();
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
			if (formId.Equals("Td030f01"))
			{
				return this.td030f01Form;
			}
			if (formId.Equals("Td030f02"))
			{
				return this.td030f02Form;
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
			if (formId.Equals("Td030f01"))
			{
				this.td030f01Form=(Td030f01Form)formVO;
			}
			if (formId.Equals("Td030f02"))
			{
				this.td030f02Form=(Td030f02Form)formVO;
			}
		}

		#endregion

	}
}
