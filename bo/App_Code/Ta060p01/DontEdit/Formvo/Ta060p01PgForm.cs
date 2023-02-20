using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta060p01.Formvo
{
  /// <summary>
  /// Ta060p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta060p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA060F01)のFormVO。
		/// </summary>
		private Ta060f01Form ta060f01Form;
		/// <summary>
		/// 画面(TA060F02)のFormVO。
		/// </summary>
		private Ta060f02Form ta060f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta060f01Form(出荷要望状況照会 一覧)を取得または設定する。
		/// </summary>
		public Ta060f01Form Ta060f01Form
		{
			get
			{
				return this.ta060f01Form;
			}
			set
			{
				this.ta060f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta060f02Form(出荷要望状況照会 明細)を取得または設定する。
		/// </summary>
		public Ta060f02Form Ta060f02Form
		{
			get
			{
				return this.ta060f02Form;
			}
			set
			{
				this.ta060f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta060p01PgForm()
		{
			ta060f01Form = new Ta060f01Form();
			ta060f02Form = new Ta060f02Form();
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
			if (formId.Equals("Ta060f01"))
			{
				return this.ta060f01Form;
			}
			if (formId.Equals("Ta060f02"))
			{
				return this.ta060f02Form;
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
			if (formId.Equals("Ta060f01"))
			{
				this.ta060f01Form=(Ta060f01Form)formVO;
			}
			if (formId.Equals("Ta060f02"))
			{
				this.ta060f02Form=(Ta060f02Form)formVO;
			}
		}

		#endregion

	}
}
