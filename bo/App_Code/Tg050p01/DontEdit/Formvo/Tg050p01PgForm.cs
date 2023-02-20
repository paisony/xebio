using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg050p01.Formvo
{
  /// <summary>
  /// Tg050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG050F01)のFormVO。
		/// </summary>
		private Tg050f01Form tg050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg050f01Form(エラー品番リスト出力)を取得または設定する。
		/// </summary>
		public Tg050f01Form Tg050f01Form
		{
			get
			{
				return this.tg050f01Form;
			}
			set
			{
				this.tg050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg050p01PgForm()
		{
			tg050f01Form = new Tg050f01Form();
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
			if (formId.Equals("Tg050f01"))
			{
				return this.tg050f01Form;
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
			if (formId.Equals("Tg050f01"))
			{
				this.tg050f01Form=(Tg050f01Form)formVO;
			}
		}

		#endregion

	}
}
