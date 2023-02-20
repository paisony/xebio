using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td050p01.Formvo
{
  /// <summary>
  /// Td050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Td050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TD050F01)のFormVO。
		/// </summary>
		private Td050f01Form td050f01Form;
		/// <summary>
		/// 画面(TD050F02)のFormVO。
		/// </summary>
		private Td050f02Form td050f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Td050f01Form(返品伝票訂正 一覧)を取得または設定する。
		/// </summary>
		public Td050f01Form Td050f01Form
		{
			get
			{
				return this.td050f01Form;
			}
			set
			{
				this.td050f01Form = value;
			}
		}

			
		/// <summary>
		/// Td050f02Form(返品伝票訂正 明細)を取得または設定する。
		/// </summary>
		public Td050f02Form Td050f02Form
		{
			get
			{
				return this.td050f02Form;
			}
			set
			{
				this.td050f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td050p01PgForm()
		{
			td050f01Form = new Td050f01Form();
			td050f02Form = new Td050f02Form();
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
			if (formId.Equals("Td050f01"))
			{
				return this.td050f01Form;
			}
			if (formId.Equals("Td050f02"))
			{
				return this.td050f02Form;
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
			if (formId.Equals("Td050f01"))
			{
				this.td050f01Form=(Td050f01Form)formVO;
			}
			if (formId.Equals("Td050f02"))
			{
				this.td050f02Form=(Td050f02Form)formVO;
			}
		}

		#endregion

	}
}
