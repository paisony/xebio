using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ti010p01.Formvo
{
  /// <summary>
  /// Ti010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TI010F01)のFormVO。
		/// </summary>
		private Ti010f01Form ti010f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ti010f01Form(部門別管理表出力)を取得または設定する。
		/// </summary>
		public Ti010f01Form Ti010f01Form
		{
			get
			{
				return this.ti010f01Form;
			}
			set
			{
				this.ti010f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti010p01PgForm()
		{
			ti010f01Form = new Ti010f01Form();
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
			if (formId.Equals("Ti010f01"))
			{
				return this.ti010f01Form;
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
			if (formId.Equals("Ti010f01"))
			{
				this.ti010f01Form=(Ti010f01Form)formVO;
			}
		}

		#endregion

	}
}
