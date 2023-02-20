using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf050p01.Formvo
{
  /// <summary>
  /// Tf050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF050F01)のFormVO。
		/// </summary>
		private Tf050f01Form tf050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf050f01Form(小口現金出納帳出力)を取得または設定する。
		/// </summary>
		public Tf050f01Form Tf050f01Form
		{
			get
			{
				return this.tf050f01Form;
			}
			set
			{
				this.tf050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf050p01PgForm()
		{
			tf050f01Form = new Tf050f01Form();
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
			if (formId.Equals("Tf050f01"))
			{
				return this.tf050f01Form;
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
			if (formId.Equals("Tf050f01"))
			{
				this.tf050f01Form=(Tf050f01Form)formVO;
			}
		}

		#endregion

	}
}
