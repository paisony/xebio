using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Th020p01.Formvo
{
  /// <summary>
  /// Th020p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Th020p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TH020F01)のFormVO。
		/// </summary>
		private Th020f01Form th020f01Form;
		/// <summary>
		/// 画面(TH020F02)のFormVO。
		/// </summary>
		private Th020f02Form th020f02Form;
		/// <summary>
		/// 画面(TH020F03)のFormVO。
		/// </summary>
		private Th020f03Form th020f03Form;
		/// <summary>
		/// 画面(TH020F04)のFormVO。
		/// </summary>
		private Th020f04Form th020f04Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Th020f01Form(在庫検索 一覧)を取得または設定する。
		/// </summary>
		public Th020f01Form Th020f01Form
		{
			get
			{
				return this.th020f01Form;
			}
			set
			{
				this.th020f01Form = value;
			}
		}

			
		/// <summary>
		/// Th020f02Form(在庫検索 明細（店舗別）)を取得または設定する。
		/// </summary>
		public Th020f02Form Th020f02Form
		{
			get
			{
				return this.th020f02Form;
			}
			set
			{
				this.th020f02Form = value;
			}
		}

			
		/// <summary>
		/// Th020f03Form(在庫検索 明細（エリア別）)を取得または設定する。
		/// </summary>
		public Th020f03Form Th020f03Form
		{
			get
			{
				return this.th020f03Form;
			}
			set
			{
				this.th020f03Form = value;
			}
		}

			
		/// <summary>
		/// Th020f04Form(在庫検索 明細（消化率）)を取得または設定する。
		/// </summary>
		public Th020f04Form Th020f04Form
		{
			get
			{
				return this.th020f04Form;
			}
			set
			{
				this.th020f04Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020p01PgForm()
		{
			th020f01Form = new Th020f01Form();
			th020f02Form = new Th020f02Form();
			th020f03Form = new Th020f03Form();
			th020f04Form = new Th020f04Form();
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
			if (formId.Equals("Th020f01"))
			{
				return this.th020f01Form;
			}
			if (formId.Equals("Th020f02"))
			{
				return this.th020f02Form;
			}
			if (formId.Equals("Th020f03"))
			{
				return this.th020f03Form;
			}
			if (formId.Equals("Th020f04"))
			{
				return this.th020f04Form;
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
			if (formId.Equals("Th020f01"))
			{
				this.th020f01Form=(Th020f01Form)formVO;
			}
			if (formId.Equals("Th020f02"))
			{
				this.th020f02Form=(Th020f02Form)formVO;
			}
			if (formId.Equals("Th020f03"))
			{
				this.th020f03Form=(Th020f03Form)formVO;
			}
			if (formId.Equals("Th020f04"))
			{
				this.th020f04Form=(Th020f04Form)formVO;
			}
		}

		#endregion

	}
}
