using System;

using Common.Standard.Attribute;
using Common.Standard.Message;

namespace Common.Standard.Page
{
	/// <summary>
	/// 業務終了通知画面のコードビハインドクラスです。
	/// </summary>
	public partial class WindowClose : System.Web.UI.Page
	{
		#region メソッド
		#region 画面表示処理を行います。
		/// <summary>
		/// 画面表示処理を行います。
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		#endregion

		#region 標題を設定します。
		/// <summary>
		/// 標題を設定します。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected void RenderForm(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
			}
		}
		#endregion
		#endregion
	}
}