using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta040p01.Formvo
{
  /// <summary>
  /// Ta040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA040F01)のFormVO。
		/// </summary>
		private Ta040f01Form ta040f01Form;
		/// <summary>
		/// 画面(TA040F02)のFormVO。
		/// </summary>
		private Ta040f02Form ta040f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta040f01Form(補充依頼状況照会 一覧)を取得または設定する。
		/// </summary>
		public Ta040f01Form Ta040f01Form
		{
			get
			{
				return this.ta040f01Form;
			}
			set
			{
				this.ta040f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta040f02Form(補充依頼状況照会 明細)を取得または設定する。
		/// </summary>
		public Ta040f02Form Ta040f02Form
		{
			get
			{
				return this.ta040f02Form;
			}
			set
			{
				this.ta040f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta040p01PgForm()
		{
			ta040f01Form = new Ta040f01Form();
			ta040f02Form = new Ta040f02Form();
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
			if (formId.Equals("Ta040f01"))
			{
				return this.ta040f01Form;
			}
			if (formId.Equals("Ta040f02"))
			{
				return this.ta040f02Form;
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
			if (formId.Equals("Ta040f01"))
			{
				this.ta040f01Form=(Ta040f01Form)formVO;
			}
			if (formId.Equals("Ta040f02"))
			{
				this.ta040f02Form=(Ta040f02Form)formVO;
			}
		}

		#endregion

	}
}
