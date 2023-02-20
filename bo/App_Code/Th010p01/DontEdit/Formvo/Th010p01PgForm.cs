using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Th010p01.Formvo
{
  /// <summary>
  /// Th010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Th010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TH010F01)のFormVO。
		/// </summary>
		private Th010f01Form th010f01Form;
		/// <summary>
		/// 画面(TH010F02)のFormVO。
		/// </summary>
		private Th010f02Form th010f02Form;
		/// <summary>
		/// 画面(TH010F03)のFormVO。
		/// </summary>
		private Th010f03Form th010f03Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Th010f01Form(商品マスタ検索 一覧)を取得または設定する。
		/// </summary>
		public Th010f01Form Th010f01Form
		{
			get
			{
				return this.th010f01Form;
			}
			set
			{
				this.th010f01Form = value;
			}
		}

			
		/// <summary>
		/// Th010f02Form(商品マスタ検索（メーカー品番）)を取得または設定する。
		/// </summary>
		public Th010f02Form Th010f02Form
		{
			get
			{
				return this.th010f02Form;
			}
			set
			{
				this.th010f02Form = value;
			}
		}

			
		/// <summary>
		/// Th010f03Form(商品マスタ検索（サイズ別／プライス）)を取得または設定する。
		/// </summary>
		public Th010f03Form Th010f03Form
		{
			get
			{
				return this.th010f03Form;
			}
			set
			{
				this.th010f03Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th010p01PgForm()
		{
			th010f01Form = new Th010f01Form();
			th010f02Form = new Th010f02Form();
			th010f03Form = new Th010f03Form();
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
			if (formId.Equals("Th010f01"))
			{
				return this.th010f01Form;
			}
			if (formId.Equals("Th010f02"))
			{
				return this.th010f02Form;
			}
			if (formId.Equals("Th010f03"))
			{
				return this.th010f03Form;
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
			if (formId.Equals("Th010f01"))
			{
				this.th010f01Form=(Th010f01Form)formVO;
			}
			if (formId.Equals("Th010f02"))
			{
				this.th010f02Form=(Th010f02Form)formVO;
			}
			if (formId.Equals("Th010f03"))
			{
				this.th010f03Form=(Th010f03Form)formVO;
			}
		}

		#endregion

	}
}
