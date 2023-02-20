using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tf021p01.Formvo
{
  /// <summary>
  /// Tf021p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tf021p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TF021F01)のFormVO。
		/// </summary>
		private Tf021f01Form tf021f01Form;
		/// <summary>
		/// 画面(TF021F02)のFormVO。
		/// </summary>
		private Tf021f02Form tf021f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tf021f01Form(商品経費振替申請（X） 一覧)を取得または設定する。
		/// </summary>
		public Tf021f01Form Tf021f01Form
		{
			get
			{
				return this.tf021f01Form;
			}
			set
			{
				this.tf021f01Form = value;
			}
		}

			
		/// <summary>
		/// Tf021f02Form(商品経費振替申請（X） 明細)を取得または設定する。
		/// </summary>
		public Tf021f02Form Tf021f02Form
		{
			get
			{
				return this.tf021f02Form;
			}
			set
			{
				this.tf021f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf021p01PgForm()
		{
			tf021f01Form = new Tf021f01Form();
			tf021f02Form = new Tf021f02Form();
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
			if (formId.Equals("Tf021f01"))
			{
				return this.tf021f01Form;
			}
			if (formId.Equals("Tf021f02"))
			{
				return this.tf021f02Form;
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
			if (formId.Equals("Tf021f01"))
			{
				this.tf021f01Form=(Tf021f01Form)formVO;
			}
			if (formId.Equals("Tf021f02"))
			{
				this.tf021f02Form=(Tf021f02Form)formVO;
			}
		}

		#endregion

	}
}
