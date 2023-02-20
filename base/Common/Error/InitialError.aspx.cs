// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Library.Log;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Certification;
using System.Web.Services.Protocols;

public partial class InitialError : System.Web.UI.Page
{
	/// <summary>
	/// ログ出力
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();

	/// <summary>
	/// 例外を取得し、エラー表示をします。
	/// Global.asaxからResponse.Redirectでアクセスされます。
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			logger.Error("初期化エラー画面が表示されました。-------");
			HttpContext.Current.Items.Add("InitError", "初期化データセットアップに失敗しました。");
			ExceptionName.Text = "初期化エラー";
			ExceptionMessage.Text = Convert.ToString(HttpContext.Current.Items["InitError"]);
		}
	}

	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region リソースをセット
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("InitializationError");

			//標題をセットする
			ErrorTitleLbl.Text = resource.GetString("ErrorTitleLbl");
			ErrorLbl.Text = resource.GetString("ErrorLbl");
			MessageLbl.Text = resource.GetString("MessageLbl");
			CloseBtn.Text = resource.GetString("CloseBtn");
			#endregion
		}
	}

	protected void Page_Error(object sender, EventArgs e)
	{
		Server.ClearError();
		Response.Write("例外が発生しました。");
		Response.End();
	}

	protected void CloseBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("TimeOut.aspx");
	}

}
