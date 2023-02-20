using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg040p01.Formvo
{
  /// <summary>
  /// Tg040p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg040p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG040F01)のFormVO。
		/// </summary>
		private Tg040f01Form tg040f01Form;
		/// <summary>
		/// 画面(TG040F02)のFormVO。
		/// </summary>
		private Tg040f02Form tg040f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg040f01Form(商品ｽﾄｯｸ明細書発行 一覧)を取得または設定する。
		/// </summary>
		public Tg040f01Form Tg040f01Form
		{
			get
			{
				return this.tg040f01Form;
			}
			set
			{
				this.tg040f01Form = value;
			}
		}

			
		/// <summary>
		/// Tg040f02Form(商品ｽﾄｯｸ明細書発行 明細)を取得または設定する。
		/// </summary>
		public Tg040f02Form Tg040f02Form
		{
			get
			{
				return this.tg040f02Form;
			}
			set
			{
				this.tg040f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg040p01PgForm()
		{
			tg040f01Form = new Tg040f01Form();
			tg040f02Form = new Tg040f02Form();
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
			if (formId.Equals("Tg040f01"))
			{
				return this.tg040f01Form;
			}
			if (formId.Equals("Tg040f02"))
			{
				return this.tg040f02Form;
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
			if (formId.Equals("Tg040f01"))
			{
				this.tg040f01Form=(Tg040f01Form)formVO;
			}
			if (formId.Equals("Tg040f02"))
			{
				this.tg040f02Form=(Tg040f02Form)formVO;
			}
		}

		#endregion

	}
}
