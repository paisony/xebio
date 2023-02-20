using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tl010p01.Formvo
{
  /// <summary>
  /// Tl010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tl010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TL010F01)のFormVO。
		/// </summary>
		private Tl010f01Form tl010f01Form;
		/// <summary>
		/// 画面(TL010F02)のFormVO。
		/// </summary>
		private Tl010f02Form tl010f02Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tl010f01Form(売変検索(V) 一覧)を取得または設定する。
		/// </summary>
		public Tl010f01Form Tl010f01Form
		{
			get
			{
				return this.tl010f01Form;
			}
			set
			{
				this.tl010f01Form = value;
			}
		}

			
		/// <summary>
		/// Tl010f02Form(売変検索(V) 明細)を取得または設定する。
		/// </summary>
		public Tl010f02Form Tl010f02Form
		{
			get
			{
				return this.tl010f02Form;
			}
			set
			{
				this.tl010f02Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl010p01PgForm()
		{
			tl010f01Form = new Tl010f01Form();
			tl010f02Form = new Tl010f02Form();
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
			if (formId.Equals("Tl010f01"))
			{
				return this.tl010f01Form;
			}
			if (formId.Equals("Tl010f02"))
			{
				return this.tl010f02Form;
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
			if (formId.Equals("Tl010f01"))
			{
				this.tl010f01Form=(Tl010f01Form)formVO;
			}
			if (formId.Equals("Tl010f02"))
			{
				this.tl010f02Form=(Tl010f02Form)formVO;
			}
		}

		#endregion

	}
}
