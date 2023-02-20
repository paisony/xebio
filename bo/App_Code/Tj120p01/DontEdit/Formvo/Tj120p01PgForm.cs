using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj120p01.Formvo
{
  /// <summary>
  /// Tj120p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj120p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ120F01)のFormVO。
		/// </summary>
		private Tj120f01Form tj120f01Form;
		/// <summary>
		/// 画面(TJ120F02)のFormVO。
		/// </summary>
		private Tj120f02Form tj120f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj120f01Form(棚卸重複検索(V) 一覧)を取得または設定する。
		/// </summary>
		public Tj120f01Form Tj120f01Form
		{
			get
			{
				return this.tj120f01Form;
			}
			set
			{
				this.tj120f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj120f02Form(棚卸重複検索(V) 明細)を取得または設定する。
		/// </summary>
		public Tj120f02Form Tj120f02Form
		{
			get
			{
				return this.tj120f02Form;
			}
			set
			{
				this.tj120f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj120p01PgForm()
		{
			tj120f01Form = new Tj120f01Form();
			tj120f02Form = new Tj120f02Form();
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
			if (formId.Equals("Tj120f01"))
			{
				return this.tj120f01Form;
			}
			if (formId.Equals("Tj120f02"))
			{
				return this.tj120f02Form;
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
			if (formId.Equals("Tj120f01"))
			{
				this.tj120f01Form=(Tj120f01Form)formVO;
			}
			if (formId.Equals("Tj120f02"))
			{
				this.tj120f02Form=(Tj120f02Form)formVO;
			}
		}

		#endregion

	}
}
