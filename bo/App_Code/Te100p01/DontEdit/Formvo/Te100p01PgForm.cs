using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Te100p01.Formvo
{
  /// <summary>
  /// Te100p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Te100p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TE100F01)のFormVO。
		/// </summary>
		private Te100f01Form te100f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Te100f01Form(移動入荷予定未存在リスト出力)を取得または設定する。
		/// </summary>
		public Te100f01Form Te100f01Form
		{
			get
			{
				return this.te100f01Form;
			}
			set
			{
				this.te100f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te100p01PgForm()
		{
			te100f01Form = new Te100f01Form();
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
			if (formId.Equals("Te100f01"))
			{
				return this.te100f01Form;
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
			if (formId.Equals("Te100f01"))
			{
				this.te100f01Form=(Te100f01Form)formVO;
			}
		}

		#endregion

	}
}
