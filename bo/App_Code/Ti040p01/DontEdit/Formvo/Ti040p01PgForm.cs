using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ti040p01.Formvo
{
  /// <summary>
  /// Ti040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TI040F01)のFormVO。
		/// </summary>
		private Ti040f01Form ti040f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ti040f01Form(ラベルプリンタ管理画面)を取得または設定する。
		/// </summary>
		public Ti040f01Form Ti040f01Form
		{
			get
			{
				return this.ti040f01Form;
			}
			set
			{
				this.ti040f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti040p01PgForm()
		{
			ti040f01Form = new Ti040f01Form();
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
			if (formId.Equals("Ti040f01"))
			{
				return this.ti040f01Form;
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
			if (formId.Equals("Ti040f01"))
			{
				this.ti040f01Form=(Ti040f01Form)formVO;
			}
		}

		#endregion

	}
}
