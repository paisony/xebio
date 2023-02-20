using System;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.UI;

using Common.Standard.Attribute;
using Common.Standard.Batch;
using Common.Standard.Form;
using Common.Standard.Util;
using Common.Standard.Message;

namespace Common.Standard.Page
{
	/// <summary>
	/// バッチ起動時の待ち受け画面のコードビハインドクラスです。
	/// </summary>
	public partial class NowLoading : System.Web.UI.Page
	{
		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				ViewState[BatchManager.JOBID_KEY] = Request.Params[BatchManager.JOBID_KEY];
				string script = "<SCRIPT LANGUAGE='javascript'>" +
					"window.focus(); " +
					"document.all.ExecuteBtn.click();" +
					"</SCRIPT>";

				ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "open", script);
			}
		}

		/// <summary>
		/// 実行ボタンのイベントハンドラです。
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void ExecuteBtn_Click(object sender, EventArgs e)
		{
			String jobId = Request.QueryString.GetValues(BatchManager.JOBID_KEY)[0];

			String pgid = Request.QueryString.GetValues(BatchManager.PGID_KEY)[0];
			String formid = Request.QueryString.GetValues(BatchManager.FORMID_KEY)[0];
			String commode = Request.QueryString.GetValues(BatchManager.COMMODE_KEY)[0];
			String pgloadmode = Request.QueryString.GetValues(BatchManager.ISINIT_KEY)[0];

			//フォーカス制御用のキーを取得する
			String itemKey = FormFocusUtil.GetItemIdKey();
			String mCountKey = FormFocusUtil.GetMcountKey();

			String itemid = null;
			if (Request[itemKey] != null)
			{
				itemid = Request.QueryString.GetValues(itemKey)[0];
			}

			String mid = null;
			if (Request[mCountKey] != null)
			{
				mid = Request.QueryString.GetValues(mCountKey)[0];
			}

			StringBuilder url = new StringBuilder();
			url.Append(HttpContext.Current.Request.ApplicationPath);
			url.Append("/");
			url.Append(pgid);
			url.Append("/");
			url.Append(formid);
			url.Append(".aspx?");
			url.Append(Request.QueryString.ToString());

			ConnectionStringSettings setting = ContextUtil.GetDefaultQuiqConnectionStringSettings();
			BatchEndMonitor bem = new BatchEndMonitor(setting);

			String status = bem.StartMonitor(jobId);

			String script = String.Empty;

			//代替メソッドを呼んだ場合にエラーがあったらエラーをJSのAlertで表示させてもとの窓をおとす。
			if (status != "99")
			{
				script = "<SCRIPT LANGUAGE='javascript'>" +
					"window.focus(); " +
					"document.all.ResizeBtn.click();" +
					"</SCRIPT>";

				ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "resize", script);
			}
			else
			{
				//エラーダイアログを表示してウィンドウをクローズする。
				script = "<SCRIPT LANGUAGE='javascript'>" +
				   "window.alert('Error'); " +
				   "window.close();" +
				  "</SCRIPT>";

				ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "close", script);
			}
			url.Append("&");
			url.Append(BatchManager.STATUS_KEY);
			url.Append("=");
			url.Append(status);
			url.Append("&");
			url.Append(itemKey);
			url.Append("=");
			url.Append(itemid);
			url.Append("&");
			url.Append(mCountKey);
			url.Append("=");
			url.Append(mid);
			Response.Redirect(url.ToString());
		}

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
				StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();
				//標題(待ち受け画面)
				this.Programtitle.Text = Server.HtmlEncode(captionMgr.GetString("C988"));
				//標題(待ち受け画面)
				this.Pagetitle.Text = Server.HtmlEncode(captionMgr.GetString("C988"));
			}
		}
		#endregion
		#endregion
	}
}