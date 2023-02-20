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
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Collections.Generic;

public partial class Common_Error_TimeOut : System.Web.UI.Page
{
	protected string message;
	protected string closeWindow = "false";

	protected void Page_Load(object sender, EventArgs e)
	{
		//クライアントからのＳＳＯはログアウトボタン非表示
		Dictionary<string, string> ssoParams = (Dictionary<string, string>)SessionManager.GetObject("SSOParams", "SSO");
		if (ssoParams != null)
		{
			if (ssoParams.ContainsKey("uniqueness"))
			{
				if (ssoParams["uniqueness"] == "true")
				{
					closeWindow = "true";
				}
			}
		}

		this.DataBind();

		//セッション情報全削除
		SessionManager.SessionRemoveAll();
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
			FormResource resource = ResourceManager.GetInstance().GetFormResource("TimeOut");

			//標題をセットする
			message = resource.GetString("Message");
			#endregion

			this.DataBind();
		}
	}
}
