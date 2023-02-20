using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta020p01.Formvo
{
  /// <summary>
  /// Ta020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA020F01)のFormVO。
		/// </summary>
		private Ta020f01Form ta020f01Form;
		/// <summary>
		/// 画面(TA020F02)のFormVO。
		/// </summary>
		private Ta020f02Form ta020f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta020f01Form(出荷要望入力 一覧)を取得または設定する。
		/// </summary>
		public Ta020f01Form Ta020f01Form
		{
			get
			{
				return this.ta020f01Form;
			}
			set
			{
				this.ta020f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta020f02Form(出荷要望入力 明細)を取得または設定する。
		/// </summary>
		public Ta020f02Form Ta020f02Form
		{
			get
			{
				return this.ta020f02Form;
			}
			set
			{
				this.ta020f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta020p01PgForm()
		{
			ta020f01Form = new Ta020f01Form();
			ta020f02Form = new Ta020f02Form();
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
			if (formId.Equals("Ta020f01"))
			{
				return this.ta020f01Form;
			}
			if (formId.Equals("Ta020f02"))
			{
				return this.ta020f02Form;
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
			if (formId.Equals("Ta020f01"))
			{
				this.ta020f01Form=(Ta020f01Form)formVO;
			}
			if (formId.Equals("Ta020f02"))
			{
				this.ta020f02Form=(Ta020f02Form)formVO;
			}
		}

		#endregion

	}
}
