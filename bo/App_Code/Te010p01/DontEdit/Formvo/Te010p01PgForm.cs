using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te010p01.Formvo
{
  /// <summary>
  /// Te010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE010F01)のFormVO。
		/// </summary>
		private Te010f01Form te010f01Form;
		/// <summary>
		/// 画面(TE010F02)のFormVO。
		/// </summary>
		private Te010f02Form te010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te010f01Form(移動出荷検索 一覧)を取得または設定する。
		/// </summary>
		public Te010f01Form Te010f01Form
		{
			get
			{
				return this.te010f01Form;
			}
			set
			{
				this.te010f01Form = value;
			}
		}

			
		/// <summary>
		/// Te010f02Form(移動出荷検索 明細)を取得または設定する。
		/// </summary>
		public Te010f02Form Te010f02Form
		{
			get
			{
				return this.te010f02Form;
			}
			set
			{
				this.te010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te010p01PgForm()
		{
			te010f01Form = new Te010f01Form();
			te010f02Form = new Te010f02Form();
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
			if (formId.Equals("Te010f01"))
			{
				return this.te010f01Form;
			}
			if (formId.Equals("Te010f02"))
			{
				return this.te010f02Form;
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
			if (formId.Equals("Te010f01"))
			{
				this.te010f01Form=(Te010f01Form)formVO;
			}
			if (formId.Equals("Te010f02"))
			{
				this.te010f02Form=(Te010f02Form)formVO;
			}
		}

		#endregion

	}
}
