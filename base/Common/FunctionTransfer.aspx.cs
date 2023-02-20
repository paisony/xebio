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
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Certification;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Web;

public partial class Common_FunctionTransfer : System.Web.UI.Page
{
	protected string solutionId;
	protected string functionId;
	protected string eventParams;
	protected string windowOpenFlag;
	protected string windowName;
	protected string windowStyle;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			solutionId = Request.Params["solutionId"];
			functionId = Request.Params["functionId"];
			eventParams = HttpUtility.UrlEncode(Request.Params["eventParams"]);
			Dictionary<string, string> ssoParams = (Dictionary<string, string>)SessionManager.GetObject("SSOParams", "SSO");

			if (solutionId != null && functionId != null)
			{
				solutionId = Request.Params["solutionId"];
				functionId = Request.Params["functionId"];
				eventParams = HttpUtility.UrlEncode(Request.Params["eventParams"]);

				//セッションにパラメータを詰めておく
				Dictionary<string, string> dic = new Dictionary<string, string>();
				dic.Add("solutionId", solutionId);
				dic.Add("functionId", functionId);
				dic.Add("eventParams", eventParams);
				SessionManager.SetObject(dic, "SSOParams", "SSO");
			}
			else if (ssoParams != null)
			{
				solutionId = ssoParams["solutionId"];
				functionId = ssoParams["functionId"];
				eventParams = ssoParams["eventParams"];
			}
			else
				throw new ApplicationException("SSOするための情報が足りません。");

			//ログインチェック
			//ログインしているかチェックする。
			if (string.IsNullOrEmpty(LoginUserContext.LoginInfoId))
			{
				//ログインされていないのでログイン画面へリダイレクト
                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
				//Response.Redirect("Login.aspx");
				Response.Redirect("index.aspx");
                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
			}
			else
			{
				SessionManager.SessionRemoveByPgID("SSO");
				//FUNCTIONからデータ取得
				DataRow funcRow = FunctionMst.GetFunction(solutionId, functionId);
				if (funcRow != null)
				{
					windowOpenFlag = Convert.ToString(funcRow["WINDOW_OPEN_FLAG"]);
					windowName = Convert.ToString(funcRow["WINDOW_NAME"]);
					windowStyle = Convert.ToString(funcRow["WINDOW_STYLE"]);
				}
				else
				{
					//エラー
					throw new ApplicationException("機能情報取得に失敗しました。");
				}

				this.DataBind();
			}
		}

	}
}
