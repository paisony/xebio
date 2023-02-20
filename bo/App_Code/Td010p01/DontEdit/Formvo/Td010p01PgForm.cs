using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td010p01.Formvo
{
  /// <summary>
  /// Td010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD010F01)のFormVO。
		/// </summary>
		private Td010f01Form td010f01Form;
		/// <summary>
		/// 画面(TD010F02)のFormVO。
		/// </summary>
		private Td010f02Form td010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td010f01Form(返品確定 一覧)を取得または設定する。
		/// </summary>
		public Td010f01Form Td010f01Form
		{
			get
			{
				return this.td010f01Form;
			}
			set
			{
				this.td010f01Form = value;
			}
		}

			
		/// <summary>
		/// Td010f02Form(返品確定 明細)を取得または設定する。
		/// </summary>
		public Td010f02Form Td010f02Form
		{
			get
			{
				return this.td010f02Form;
			}
			set
			{
				this.td010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td010p01PgForm()
		{
			td010f01Form = new Td010f01Form();
			td010f02Form = new Td010f02Form();
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
			if (formId.Equals("Td010f01"))
			{
				return this.td010f01Form;
			}
			if (formId.Equals("Td010f02"))
			{
				return this.td010f02Form;
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
			if (formId.Equals("Td010f01"))
			{
				this.td010f01Form=(Td010f01Form)formVO;
			}
			if (formId.Equals("Td010f02"))
			{
				this.td010f02Form=(Td010f02Form)formVO;
			}
		}

		#endregion

	}
}
