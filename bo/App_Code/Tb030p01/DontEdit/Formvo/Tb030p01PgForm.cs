using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb030p01.Formvo
{
  /// <summary>
  /// Tb030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB030F01)のFormVO。
		/// </summary>
		private Tb030f01Form tb030f01Form;
		/// <summary>
		/// 画面(TB030F02)のFormVO。
		/// </summary>
		private Tb030f02Form tb030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb030f01Form(仕入入荷確定 一覧)を取得または設定する。
		/// </summary>
		public Tb030f01Form Tb030f01Form
		{
			get
			{
				return this.tb030f01Form;
			}
			set
			{
				this.tb030f01Form = value;
			}
		}

			
		/// <summary>
		/// Tb030f02Form(仕入入荷確定 明細)を取得または設定する。
		/// </summary>
		public Tb030f02Form Tb030f02Form
		{
			get
			{
				return this.tb030f02Form;
			}
			set
			{
				this.tb030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb030p01PgForm()
		{
			tb030f01Form = new Tb030f01Form();
			tb030f02Form = new Tb030f02Form();
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
			if (formId.Equals("Tb030f01"))
			{
				return this.tb030f01Form;
			}
			if (formId.Equals("Tb030f02"))
			{
				return this.tb030f02Form;
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
			if (formId.Equals("Tb030f01"))
			{
				this.tb030f01Form=(Tb030f01Form)formVO;
			}
			if (formId.Equals("Tb030f02"))
			{
				this.tb030f02Form=(Tb030f02Form)formVO;
			}
		}

		#endregion

	}
}
