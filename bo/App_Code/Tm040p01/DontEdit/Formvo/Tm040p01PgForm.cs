using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm040p01.Formvo
{
  /// <summary>
  /// Tm040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM040F01)のFormVO。
		/// </summary>
		private Tm040f01Form tm040f01Form;
		/// <summary>
		/// 画面(TM040F02)のFormVO。
		/// </summary>
		private Tm040f02Form tm040f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm040f01Form(サイズ検索 色選択)を取得または設定する。
		/// </summary>
		public Tm040f01Form Tm040f01Form
		{
			get
			{
				return this.tm040f01Form;
			}
			set
			{
				this.tm040f01Form = value;
			}
		}

			
		/// <summary>
		/// Tm040f02Form(サイズ検索 サイズ入力)を取得または設定する。
		/// </summary>
		public Tm040f02Form Tm040f02Form
		{
			get
			{
				return this.tm040f02Form;
			}
			set
			{
				this.tm040f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm040p01PgForm()
		{
			tm040f01Form = new Tm040f01Form();
			tm040f02Form = new Tm040f02Form();
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
			if (formId.Equals("Tm040f01"))
			{
				return this.tm040f01Form;
			}
			if (formId.Equals("Tm040f02"))
			{
				return this.tm040f02Form;
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
			if (formId.Equals("Tm040f01"))
			{
				this.tm040f01Form=(Tm040f01Form)formVO;
			}
			if (formId.Equals("Tm040f02"))
			{
				this.tm040f02Form=(Tm040f02Form)formVO;
			}
		}

		#endregion

	}
}
