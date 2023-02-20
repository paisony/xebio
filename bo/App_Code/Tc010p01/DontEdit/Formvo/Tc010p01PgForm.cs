using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tc010p01.Formvo
{
  /// <summary>
  /// Tc010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tc010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TC010F01)のFormVO。
		/// </summary>
		private Tc010f01Form tc010f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tc010f01Form(客注入荷リスト出力)を取得または設定する。
		/// </summary>
		public Tc010f01Form Tc010f01Form
		{
			get
			{
				return this.tc010f01Form;
			}
			set
			{
				this.tc010f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tc010p01PgForm()
		{
			tc010f01Form = new Tc010f01Form();
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
			if (formId.Equals("Tc010f01"))
			{
				return this.tc010f01Form;
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
			if (formId.Equals("Tc010f01"))
			{
				this.tc010f01Form=(Tc010f01Form)formVO;
			}
		}

		#endregion

	}
}
