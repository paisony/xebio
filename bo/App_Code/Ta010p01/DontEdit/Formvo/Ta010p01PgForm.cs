using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta010p01.Formvo
{
  /// <summary>
  /// Ta010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA010F01)のFormVO。
		/// </summary>
		private Ta010f01Form ta010f01Form;
		/// <summary>
		/// 画面(TA010F02)のFormVO。
		/// </summary>
		private Ta010f02Form ta010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta010f01Form(補充依頼入力 一覧)を取得または設定する。
		/// </summary>
		public Ta010f01Form Ta010f01Form
		{
			get
			{
				return this.ta010f01Form;
			}
			set
			{
				this.ta010f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta010f02Form(補充依頼入力 明細)を取得または設定する。
		/// </summary>
		public Ta010f02Form Ta010f02Form
		{
			get
			{
				return this.ta010f02Form;
			}
			set
			{
				this.ta010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta010p01PgForm()
		{
			ta010f01Form = new Ta010f01Form();
			ta010f02Form = new Ta010f02Form();
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
			if (formId.Equals("Ta010f01"))
			{
				return this.ta010f01Form;
			}
			if (formId.Equals("Ta010f02"))
			{
				return this.ta010f02Form;
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
			if (formId.Equals("Ta010f01"))
			{
				this.ta010f01Form=(Ta010f01Form)formVO;
			}
			if (formId.Equals("Ta010f02"))
			{
				this.ta010f02Form=(Ta010f02Form)formVO;
			}
		}

		#endregion

	}
}
