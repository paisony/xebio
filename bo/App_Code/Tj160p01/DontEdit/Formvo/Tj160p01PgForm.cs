using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj160p01.Formvo
{
  /// <summary>
  /// Tj160p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj160p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ160F01)のFormVO。
		/// </summary>
		private Tj160f01Form tj160f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj160f01Form(棚卸チェックリスト出力(V))を取得または設定する。
		/// </summary>
		public Tj160f01Form Tj160f01Form
		{
			get
			{
				return this.tj160f01Form;
			}
			set
			{
				this.tj160f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj160p01PgForm()
		{
			tj160f01Form = new Tj160f01Form();
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
			if (formId.Equals("Tj160f01"))
			{
				return this.tj160f01Form;
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
			if (formId.Equals("Tj160f01"))
			{
				this.tj160f01Form=(Tj160f01Form)formVO;
			}
		}

		#endregion

	}
}
