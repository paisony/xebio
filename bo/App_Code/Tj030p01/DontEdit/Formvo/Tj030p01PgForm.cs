using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj030p01.Formvo
{
  /// <summary>
  /// Tj030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ030F01)のFormVO。
		/// </summary>
		private Tj030f01Form tj030f01Form;
		/// <summary>
		/// 画面(TJ030F02)のFormVO。
		/// </summary>
		private Tj030f02Form tj030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj030f01Form(棚卸検索(V) 一覧)を取得または設定する。
		/// </summary>
		public Tj030f01Form Tj030f01Form
		{
			get
			{
				return this.tj030f01Form;
			}
			set
			{
				this.tj030f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj030f02Form(棚卸検索(V) 明細)を取得または設定する。
		/// </summary>
		public Tj030f02Form Tj030f02Form
		{
			get
			{
				return this.tj030f02Form;
			}
			set
			{
				this.tj030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj030p01PgForm()
		{
			tj030f01Form = new Tj030f01Form();
			tj030f02Form = new Tj030f02Form();
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
			if (formId.Equals("Tj030f01"))
			{
				return this.tj030f01Form;
			}
			if (formId.Equals("Tj030f02"))
			{
				return this.tj030f02Form;
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
			if (formId.Equals("Tj030f01"))
			{
				this.tj030f01Form=(Tj030f01Form)formVO;
			}
			if (formId.Equals("Tj030f02"))
			{
				this.tj030f02Form=(Tj030f02Form)formVO;
			}
		}

		#endregion

	}
}
