using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tb070p01.Formvo
{
  /// <summary>
  /// Tb070p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tb070p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TB070F01)のFormVO。
		/// </summary>
		private Tb070f01Form tb070f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tb070f01Form(仕入予定未存在リスト出力)を取得または設定する。
		/// </summary>
		public Tb070f01Form Tb070f01Form
		{
			get
			{
				return this.tb070f01Form;
			}
			set
			{
				this.tb070f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb070p01PgForm()
		{
			tb070f01Form = new Tb070f01Form();
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
			if (formId.Equals("Tb070f01"))
			{
				return this.tb070f01Form;
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
			if (formId.Equals("Tb070f01"))
			{
				this.tb070f01Form=(Tb070f01Form)formVO;
			}
		}

		#endregion

	}
}
