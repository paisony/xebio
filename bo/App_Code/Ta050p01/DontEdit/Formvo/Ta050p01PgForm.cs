using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Ta050p01.Formvo
{
  /// <summary>
  /// Ta050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TA050F01)のFormVO。
		/// </summary>
		private Ta050f01Form ta050f01Form;
		/// <summary>
		/// 画面(TA050F02)のFormVO。
		/// </summary>
		private Ta050f02Form ta050f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Ta050f01Form(単品レポート状況照会 一覧)を取得または設定する。
		/// </summary>
		public Ta050f01Form Ta050f01Form
		{
			get
			{
				return this.ta050f01Form;
			}
			set
			{
				this.ta050f01Form = value;
			}
		}

			
		/// <summary>
		/// Ta050f02Form(単品レポート状況照会 明細)を取得または設定する。
		/// </summary>
		public Ta050f02Form Ta050f02Form
		{
			get
			{
				return this.ta050f02Form;
			}
			set
			{
				this.ta050f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta050p01PgForm()
		{
			ta050f01Form = new Ta050f01Form();
			ta050f02Form = new Ta050f02Form();
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
			if (formId.Equals("Ta050f01"))
			{
				return this.ta050f01Form;
			}
			if (formId.Equals("Ta050f02"))
			{
				return this.ta050f02Form;
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
			if (formId.Equals("Ta050f01"))
			{
				this.ta050f01Form=(Ta050f01Form)formVO;
			}
			if (formId.Equals("Ta050f02"))
			{
				this.ta050f02Form=(Ta050f02Form)formVO;
			}
		}

		#endregion

	}
}
