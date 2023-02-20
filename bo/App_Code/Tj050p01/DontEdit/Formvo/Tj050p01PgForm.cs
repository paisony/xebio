using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj050p01.Formvo
{
  /// <summary>
  /// Tj050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ050F01)のFormVO。
		/// </summary>
		private Tj050f01Form tj050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj050f01Form(棚卸報告書再出力(V))を取得または設定する。
		/// </summary>
		public Tj050f01Form Tj050f01Form
		{
			get
			{
				return this.tj050f01Form;
			}
			set
			{
				this.tj050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj050p01PgForm()
		{
			tj050f01Form = new Tj050f01Form();
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
			if (formId.Equals("Tj050f01"))
			{
				return this.tj050f01Form;
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
			if (formId.Equals("Tj050f01"))
			{
				this.tj050f01Form=(Tj050f01Form)formVO;
			}
		}

		#endregion

	}
}
