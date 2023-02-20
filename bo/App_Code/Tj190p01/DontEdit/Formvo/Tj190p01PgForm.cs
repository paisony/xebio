using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj190p01.Formvo
{
  /// <summary>
  /// Tj190p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj190p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TJ190F01)のFormVO。
		/// </summary>
		private Tj190f01Form tj190f01Form;
		/// <summary>
		/// 画面(TJ190F02)のFormVO。
		/// </summary>
		private Tj190f02Form tj190f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tj190f01Form(臨時棚卸検索 一覧)を取得または設定する。
		/// </summary>
		public Tj190f01Form Tj190f01Form
		{
			get
			{
				return this.tj190f01Form;
			}
			set
			{
				this.tj190f01Form = value;
			}
		}

			
		/// <summary>
		/// Tj190f02Form(臨時棚卸検索 明細)を取得または設定する。
		/// </summary>
		public Tj190f02Form Tj190f02Form
		{
			get
			{
				return this.tj190f02Form;
			}
			set
			{
				this.tj190f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj190p01PgForm()
		{
			tj190f01Form = new Tj190f01Form();
			tj190f02Form = new Tj190f02Form();
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
			if (formId.Equals("Tj190f01"))
			{
				return this.tj190f01Form;
			}
			if (formId.Equals("Tj190f02"))
			{
				return this.tj190f02Form;
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
			if (formId.Equals("Tj190f01"))
			{
				this.tj190f01Form=(Tj190f01Form)formVO;
			}
			if (formId.Equals("Tj190f02"))
			{
				this.tj190f02Form=(Tj190f02Form)formVO;
			}
		}

		#endregion

	}
}
