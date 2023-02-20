using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb050p01.Formvo
{
  /// <summary>
  /// Tb050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB050F01)のFormVO。
		/// </summary>
		private Tb050f01Form tb050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb050f01Form(マニュアル仕入)を取得または設定する。
		/// </summary>
		public Tb050f01Form Tb050f01Form
		{
			get
			{
				return this.tb050f01Form;
			}
			set
			{
				this.tb050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb050p01PgForm()
		{
			tb050f01Form = new Tb050f01Form();
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
			if (formId.Equals("Tb050f01"))
			{
				return this.tb050f01Form;
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
			if (formId.Equals("Tb050f01"))
			{
				this.tb050f01Form=(Tb050f01Form)formVO;
			}
		}

		#endregion

	}
}
