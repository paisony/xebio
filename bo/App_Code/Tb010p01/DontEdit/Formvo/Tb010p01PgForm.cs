using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb010p01.Formvo
{
  /// <summary>
  /// Tb010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB010F01)のFormVO。
		/// </summary>
		private Tb010f01Form tb010f01Form;
		/// <summary>
		/// 画面(TB010F02)のFormVO。
		/// </summary>
		private Tb010f02Form tb010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb010f01Form(仕入入荷検索 一覧)を取得または設定する。
		/// </summary>
		public Tb010f01Form Tb010f01Form
		{
			get
			{
				return this.tb010f01Form;
			}
			set
			{
				this.tb010f01Form = value;
			}
		}

			
		/// <summary>
		/// Tb010f02Form(仕入入荷検索 明細)を取得または設定する。
		/// </summary>
		public Tb010f02Form Tb010f02Form
		{
			get
			{
				return this.tb010f02Form;
			}
			set
			{
				this.tb010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb010p01PgForm()
		{
			tb010f01Form = new Tb010f01Form();
			tb010f02Form = new Tb010f02Form();
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
			if (formId.Equals("Tb010f01"))
			{
				return this.tb010f01Form;
			}
			if (formId.Equals("Tb010f02"))
			{
				return this.tb010f02Form;
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
			if (formId.Equals("Tb010f01"))
			{
				this.tb010f01Form=(Tb010f01Form)formVO;
			}
			if (formId.Equals("Tb010f02"))
			{
				this.tb010f02Form=(Tb010f02Form)formVO;
			}
		}

		#endregion

	}
}
