using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ti030p01.Formvo
{
  /// <summary>
  /// Ti030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ti030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TI030F01)のFormVO。
		/// </summary>
		private Ti030f01Form ti030f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ti030f01Form(運用管理マスタメンテナンス)を取得または設定する。
		/// </summary>
		public Ti030f01Form Ti030f01Form
		{
			get
			{
				return this.ti030f01Form;
			}
			set
			{
				this.ti030f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti030p01PgForm()
		{
			ti030f01Form = new Ti030f01Form();
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
			if (formId.Equals("Ti030f01"))
			{
				return this.ti030f01Form;
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
			if (formId.Equals("Ti030f01"))
			{
				this.ti030f01Form=(Ti030f01Form)formVO;
			}
		}

		#endregion

	}
}
