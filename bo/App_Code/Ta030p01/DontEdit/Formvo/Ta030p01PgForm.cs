using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta030p01.Formvo
{
  /// <summary>
  /// Ta030p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta030p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA030F01)のFormVO。
		/// </summary>
		private Ta030f01Form ta030f01Form;
		/// <summary>
		/// 画面(TA030F02)のFormVO。
		/// </summary>
		private Ta030f02Form ta030f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta030f01Form(依頼検索 一覧)を取得または設定する。
		/// </summary>
		public Ta030f01Form Ta030f01Form
		{
			get
			{
				return this.ta030f01Form;
			}
			set
			{
				this.ta030f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta030f02Form(依頼検索 明細)を取得または設定する。
		/// </summary>
		public Ta030f02Form Ta030f02Form
		{
			get
			{
				return this.ta030f02Form;
			}
			set
			{
				this.ta030f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta030p01PgForm()
		{
			ta030f01Form = new Ta030f01Form();
			ta030f02Form = new Ta030f02Form();
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
			if (formId.Equals("Ta030f01"))
			{
				return this.ta030f01Form;
			}
			if (formId.Equals("Ta030f02"))
			{
				return this.ta030f02Form;
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
			if (formId.Equals("Ta030f01"))
			{
				this.ta030f01Form=(Ta030f01Form)formVO;
			}
			if (formId.Equals("Ta030f02"))
			{
				this.ta030f02Form=(Ta030f02Form)formVO;
			}
		}

		#endregion

	}
}
