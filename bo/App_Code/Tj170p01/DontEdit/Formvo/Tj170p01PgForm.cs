using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj170p01.Formvo
{
  /// <summary>
  /// Tj170p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj170p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ170F01)のFormVO。
		/// </summary>
		private Tj170f01Form tj170f01Form;
		/// <summary>
		/// 画面(TJ170F02)のFormVO。
		/// </summary>
		private Tj170f02Form tj170f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj170f01Form(棚卸ロスリスト出力 一覧)を取得または設定する。
		/// </summary>
		public Tj170f01Form Tj170f01Form
		{
			get
			{
				return this.tj170f01Form;
			}
			set
			{
				this.tj170f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj170f02Form(棚卸ロスリスト出力 明細)を取得または設定する。
		/// </summary>
		public Tj170f02Form Tj170f02Form
		{
			get
			{
				return this.tj170f02Form;
			}
			set
			{
				this.tj170f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj170p01PgForm()
		{
			tj170f01Form = new Tj170f01Form();
			tj170f02Form = new Tj170f02Form();
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
			if (formId.Equals("Tj170f01"))
			{
				return this.tj170f01Form;
			}
			if (formId.Equals("Tj170f02"))
			{
				return this.tj170f02Form;
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
			if (formId.Equals("Tj170f01"))
			{
				this.tj170f01Form=(Tj170f01Form)formVO;
			}
			if (formId.Equals("Tj170f02"))
			{
				this.tj170f02Form=(Tj170f02Form)formVO;
			}
		}

		#endregion

	}
}
