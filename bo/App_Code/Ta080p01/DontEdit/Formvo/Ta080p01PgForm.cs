using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta080p01.Formvo
{
  /// <summary>
  /// Ta080p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA080F01)のFormVO。
		/// </summary>
		private Ta080f01Form ta080f01Form;
		/// <summary>
		/// 画面(TA080F02)のFormVO。
		/// </summary>
		private Ta080f02Form ta080f02Form;
		/// <summary>
		/// 画面(TA080F03)のFormVO。
		/// </summary>
		private Ta080f03Form ta080f03Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta080f01Form(補充・仕入稟議検索 一覧)を取得または設定する。
		/// </summary>
		public Ta080f01Form Ta080f01Form
		{
			get
			{
				return this.ta080f01Form;
			}
			set
			{
				this.ta080f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta080f02Form(補充・仕入稟議検索 実績明細)を取得または設定する。
		/// </summary>
		public Ta080f02Form Ta080f02Form
		{
			get
			{
				return this.ta080f02Form;
			}
			set
			{
				this.ta080f02Form = value;
			}
		}

			
		/// <summary>
		/// Ta080f03Form(補充・仕入稟議検索 明細)を取得または設定する。
		/// </summary>
		public Ta080f03Form Ta080f03Form
		{
			get
			{
				return this.ta080f03Form;
			}
			set
			{
				this.ta080f03Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080p01PgForm()
		{
			ta080f01Form = new Ta080f01Form();
			ta080f02Form = new Ta080f02Form();
			ta080f03Form = new Ta080f03Form();
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
			if (formId.Equals("Ta080f01"))
			{
				return this.ta080f01Form;
			}
			if (formId.Equals("Ta080f02"))
			{
				return this.ta080f02Form;
			}
			if (formId.Equals("Ta080f03"))
			{
				return this.ta080f03Form;
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
			if (formId.Equals("Ta080f01"))
			{
				this.ta080f01Form=(Ta080f01Form)formVO;
			}
			if (formId.Equals("Ta080f02"))
			{
				this.ta080f02Form=(Ta080f02Form)formVO;
			}
			if (formId.Equals("Ta080f03"))
			{
				this.ta080f03Form=(Ta080f03Form)formVO;
			}
		}

		#endregion

	}
}
