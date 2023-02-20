using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb020p01.Formvo
{
  /// <summary>
  /// Tb020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB020F01)のFormVO。
		/// </summary>
		private Tb020f01Form tb020f01Form;
		/// <summary>
		/// 画面(TB020F02)のFormVO。
		/// </summary>
		private Tb020f02Form tb020f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb020f01Form(SCM仕入入荷検索 一覧)を取得または設定する。
		/// </summary>
		public Tb020f01Form Tb020f01Form
		{
			get
			{
				return this.tb020f01Form;
			}
			set
			{
				this.tb020f01Form = value;
			}
		}

			
		/// <summary>
		/// Tb020f02Form(SCM仕入入荷検索 明細)を取得または設定する。
		/// </summary>
		public Tb020f02Form Tb020f02Form
		{
			get
			{
				return this.tb020f02Form;
			}
			set
			{
				this.tb020f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb020p01PgForm()
		{
			tb020f01Form = new Tb020f01Form();
			tb020f02Form = new Tb020f02Form();
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
			if (formId.Equals("Tb020f01"))
			{
				return this.tb020f01Form;
			}
			if (formId.Equals("Tb020f02"))
			{
				return this.tb020f02Form;
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
			if (formId.Equals("Tb020f01"))
			{
				this.tb020f01Form=(Tb020f01Form)formVO;
			}
			if (formId.Equals("Tb020f02"))
			{
				this.tb020f02Form=(Tb020f02Form)formVO;
			}
		}

		#endregion

	}
}
