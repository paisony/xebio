using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te130p01.Formvo
{
  /// <summary>
  /// Te130p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te130p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE130F01)のFormVO。
		/// </summary>
		private Te130f01Form te130f01Form;
		/// <summary>
		/// 画面(TE130F02)のFormVO。
		/// </summary>
		private Te130f02Form te130f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te130f01Form(企業間仕入照会 一覧)を取得または設定する。
		/// </summary>
		public Te130f01Form Te130f01Form
		{
			get
			{
				return this.te130f01Form;
			}
			set
			{
				this.te130f01Form = value;
			}
		}

			
		/// <summary>
		/// Te130f02Form(企業間仕入照会 明細)を取得または設定する。
		/// </summary>
		public Te130f02Form Te130f02Form
		{
			get
			{
				return this.te130f02Form;
			}
			set
			{
				this.te130f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te130p01PgForm()
		{
			te130f01Form = new Te130f01Form();
			te130f02Form = new Te130f02Form();
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
			if (formId.Equals("Te130f01"))
			{
				return this.te130f01Form;
			}
			if (formId.Equals("Te130f02"))
			{
				return this.te130f02Form;
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
			if (formId.Equals("Te130f01"))
			{
				this.te130f01Form=(Te130f01Form)formVO;
			}
			if (formId.Equals("Te130f02"))
			{
				this.te130f02Form=(Te130f02Form)formVO;
			}
		}

		#endregion

	}
}
