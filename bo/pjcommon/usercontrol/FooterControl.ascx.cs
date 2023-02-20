using System;

using Common.Standard.Attribute;
using Common.Standard.Base;

namespace Common.Standard.Page
{
	/// <summary>
	/// フッター部表示用のユーザコントロールのコードビハインドクラスです。
	/// </summary>
	public partial class FooterControl : StandardBaseUserControl
	{
		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		/// <summary>
		/// メッセージを初期化します。
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		public override void InitMessage(String pgId)
		{
			this.message1.InitMessage(pgId);
		}

		/// <summary>
		/// メッセージを設定します。
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		public override void SetMessage(String pgId)
		{
			this.message1.SetMessage(pgId);
		}
		#endregion
	}
}