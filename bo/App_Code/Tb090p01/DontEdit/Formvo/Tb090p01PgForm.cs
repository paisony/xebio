using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb090p01.Formvo
{
  /// <summary>
  /// Tb090p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb090p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB090F01)のFormVO。
		/// </summary>
		private Tb090f01Form tb090f01Form;
		/// <summary>
		/// 画面(TB090F02)のFormVO。
		/// </summary>
		private Tb090f02Form tb090f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb090f01Form(仕入伝票訂正 一覧)を取得または設定する。
		/// </summary>
		public Tb090f01Form Tb090f01Form
		{
			get
			{
				return this.tb090f01Form;
			}
			set
			{
				this.tb090f01Form = value;
			}
		}

			
		/// <summary>
		/// Tb090f02Form(仕入伝票訂正 明細)を取得または設定する。
		/// </summary>
		public Tb090f02Form Tb090f02Form
		{
			get
			{
				return this.tb090f02Form;
			}
			set
			{
				this.tb090f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb090p01PgForm()
		{
			tb090f01Form = new Tb090f01Form();
			tb090f02Form = new Tb090f02Form();
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
			if (formId.Equals("Tb090f01"))
			{
				return this.tb090f01Form;
			}
			if (formId.Equals("Tb090f02"))
			{
				return this.tb090f02Form;
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
			if (formId.Equals("Tb090f01"))
			{
				this.tb090f01Form=(Tb090f01Form)formVO;
			}
			if (formId.Equals("Tb090f02"))
			{
				this.tb090f02Form=(Tb090f02Form)formVO;
			}
		}

		#endregion

	}
}
