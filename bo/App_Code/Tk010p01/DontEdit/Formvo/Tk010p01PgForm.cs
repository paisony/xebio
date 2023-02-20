using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tk010p01.Formvo
{
  /// <summary>
  /// Tk010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tk010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TK010F01)のFormVO。
		/// </summary>
		private Tk010f01Form tk010f01Form;
		/// <summary>
		/// 画面(TK010F02)のFormVO。
		/// </summary>
		private Tk010f02Form tk010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tk010f01Form(評価損確定 一覧)を取得または設定する。
		/// </summary>
		public Tk010f01Form Tk010f01Form
		{
			get
			{
				return this.tk010f01Form;
			}
			set
			{
				this.tk010f01Form = value;
			}
		}

			
		/// <summary>
		/// Tk010f02Form(評価損確定 明細)を取得または設定する。
		/// </summary>
		public Tk010f02Form Tk010f02Form
		{
			get
			{
				return this.tk010f02Form;
			}
			set
			{
				this.tk010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk010p01PgForm()
		{
			tk010f01Form = new Tk010f01Form();
			tk010f02Form = new Tk010f02Form();
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
			if (formId.Equals("Tk010f01"))
			{
				return this.tk010f01Form;
			}
			if (formId.Equals("Tk010f02"))
			{
				return this.tk010f02Form;
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
			if (formId.Equals("Tk010f01"))
			{
				this.tk010f01Form=(Tk010f01Form)formVO;
			}
			if (formId.Equals("Tk010f02"))
			{
				this.tk010f02Form=(Tk010f02Form)formVO;
			}
		}

		#endregion

	}
}
