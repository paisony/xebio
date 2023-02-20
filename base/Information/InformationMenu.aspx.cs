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
using System.Web.SessionState;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.DataLog;

public partial class Information_InformationMenu : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{

		}
	}

	/// <summary>
	/// 標題セット
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 標題セット

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("InformationMenu");

			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			TopicLink.Text = resource.GetString("TopicLink");
			MessageLink.Text = resource.GetString("MessageLink");
			DisplayLink.Text = resource.GetString("DisplayLink");
			TopicCommentLbl.Text = resource.GetString("TopicCommentLbl");
			MessageCommentLbl.Text = resource.GetString("MessageCommentLbl");
			DisplayCommentLbl.Text = resource.GetString("DisplayCommentLbl");

			//起動情報のログ出力
			string solutionId = Request.Params["solutionId"];
			string functionId = Request.Params["functionId"];
			LoginUserInfoVO loginUserInfo = new LoginUserInfoVO();
			DataLogService dataLogService = new DataLogService(loginUserInfo);
			dataLogService.InsertExecDataLog(LoginUserContext.LoginId, solutionId, functionId);

			#endregion
		}
	}
}
