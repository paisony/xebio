using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj040p01.Formvo
{
  /// <summary>
  /// Tj040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ040F01)のFormVO。
		/// </summary>
		private Tj040f01Form tj040f01Form;
		/// <summary>
		/// 画面(TJ040F02)のFormVO。
		/// </summary>
		private Tj040f02Form tj040f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj040f01Form(棚卸検索(X) 一覧)を取得または設定する。
		/// </summary>
		public Tj040f01Form Tj040f01Form
		{
			get
			{
				return this.tj040f01Form;
			}
			set
			{
				this.tj040f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj040f02Form(棚卸検索(X) 明細)を取得または設定する。
		/// </summary>
		public Tj040f02Form Tj040f02Form
		{
			get
			{
				return this.tj040f02Form;
			}
			set
			{
				this.tj040f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj040p01PgForm()
		{
			tj040f01Form = new Tj040f01Form();
			tj040f02Form = new Tj040f02Form();
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
			if (formId.Equals("Tj040f01"))
			{
				return this.tj040f01Form;
			}
			if (formId.Equals("Tj040f02"))
			{
				return this.tj040f02Form;
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
			if (formId.Equals("Tj040f01"))
			{
				this.tj040f01Form=(Tj040f01Form)formVO;
			}
			if (formId.Equals("Tj040f02"))
			{
				this.tj040f02Form=(Tj040f02Form)formVO;
			}
		}

		#endregion

	}
}
