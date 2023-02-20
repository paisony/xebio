using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj130p01.Formvo
{
  /// <summary>
  /// Tj130p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj130p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ130F01)のFormVO。
		/// </summary>
		private Tj130f01Form tj130f01Form;
		/// <summary>
		/// 画面(TJ130F02)のFormVO。
		/// </summary>
		private Tj130f02Form tj130f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj130f01Form(棚卸重複検索(X) 一覧)を取得または設定する。
		/// </summary>
		public Tj130f01Form Tj130f01Form
		{
			get
			{
				return this.tj130f01Form;
			}
			set
			{
				this.tj130f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj130f02Form(棚卸重複検索(X) 明細)を取得または設定する。
		/// </summary>
		public Tj130f02Form Tj130f02Form
		{
			get
			{
				return this.tj130f02Form;
			}
			set
			{
				this.tj130f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj130p01PgForm()
		{
			tj130f01Form = new Tj130f01Form();
			tj130f02Form = new Tj130f02Form();
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
			if (formId.Equals("Tj130f01"))
			{
				return this.tj130f01Form;
			}
			if (formId.Equals("Tj130f02"))
			{
				return this.tj130f02Form;
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
			if (formId.Equals("Tj130f01"))
			{
				this.tj130f01Form=(Tj130f01Form)formVO;
			}
			if (formId.Equals("Tj130f02"))
			{
				this.tj130f02Form=(Tj130f02Form)formVO;
			}
		}

		#endregion

	}
}
