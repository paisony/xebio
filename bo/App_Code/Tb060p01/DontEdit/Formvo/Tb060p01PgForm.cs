using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb060p01.Formvo
{
  /// <summary>
  /// Tb060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB060F01)のFormVO。
		/// </summary>
		private Tb060f01Form tb060f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb060f01Form(SCM検品督促リスト出力)を取得または設定する。
		/// </summary>
		public Tb060f01Form Tb060f01Form
		{
			get
			{
				return this.tb060f01Form;
			}
			set
			{
				this.tb060f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb060p01PgForm()
		{
			tb060f01Form = new Tb060f01Form();
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
			if (formId.Equals("Tb060f01"))
			{
				return this.tb060f01Form;
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
			if (formId.Equals("Tb060f01"))
			{
				this.tb060f01Form=(Tb060f01Form)formVO;
			}
		}

		#endregion

	}
}
