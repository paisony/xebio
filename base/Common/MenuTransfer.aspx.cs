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
using Com.Fujitsu.SmartBase.Base.Web.Menu;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Web;

public partial class Common_MenuTransfer : System.Web.UI.Page
{
	protected string visibleSolutionId = string.Empty;

	protected void Page_Load(object sender, EventArgs e)
	{
		//メニューセットを取得
		LoginMst.SetLoginInfo(LoginUserContext.LoginId);
		string menu = MenuSetManager.GetMenuSetString();
		MenuHtmlLbl.Text = menu;

		Dictionary<string, string> ssoParams = (Dictionary<string, string>)SessionManager.GetObject("SSOParams", "SSO");
		if (ssoParams != null)
		{
			string solutionId = null;
			string functionId = null;
			string eventParams = string.Empty;
			if (ssoParams.ContainsKey("solutionId"))
				solutionId = ssoParams["solutionId"];
			if (ssoParams.ContainsKey("functionId"))
				functionId = ssoParams["functionId"];
			if (ssoParams.ContainsKey("eventParams"))
				eventParams = ssoParams["eventParams"];
			if (ssoParams.ContainsKey("uniqueness"))
			{
				if (ssoParams["uniqueness"] == "true")
				{
					visibleSolutionId = solutionId;
				}
				else
					SessionManager.SessionRemoveByPgID("SSO");
			}
			else
			{
				SessionManager.SessionRemoveByPgID("SSO");
			}

			string windowOpenFlag;
			string windowName;
			string windowStyle;

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
			if (windowOpenFlag == "0")
			{
				SSOScript.Text = string.Format(@"<script language=JavaScript>parent.ssoFunction('{0}','{1}','{2}');</script>", solutionId, functionId, eventParams);
			}
			else
			{
				SSOScript.Text = string.Format(@"<script language=JavaScript>openSSOFunction('{0}','{1}','{2}','{3}','{4}','0','0');</script>", solutionId, functionId, eventParams, solutionId + windowName, windowStyle);
			}

			if (!string.IsNullOrEmpty(visibleSolutionId) && windowOpenFlag == "1")
			{
				//そのソリューションでメインウィンドウに表示する機能を設定
				//メニューを取得する。
				bool isAdmin = LoginUserContext.UserType == WebConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER;
				bool dispMenuLink = true;
				DataTable dt1 = FunctionViewMst.GetFunctionView(solutionId, 1, isAdmin);
				if (dt1.Rows.Count > 0)
				{
					string functionViewId = Convert.ToString(dt1.Rows[0]["FUNCTION_VIEW_ID"]);
					DataTable dt2 = FunctionViewMst.GetChilds(solutionId, functionViewId);
					foreach (DataRow row2 in dt2.Rows)
					{
						string startFanctionId = Convert.ToString(row2["FUNCTION_ID"]);
						if (string.IsNullOrEmpty(startFanctionId))
						{
							//メニュー表示
							SSOScript.Text += string.Format(@"<script language=JavaScript>openBizMenu('{0}', '{1}', '0', null);</script>", solutionId, Convert.ToString(row2["FUNCTION_VIEW_ID"]));
							dispMenuLink = false;
							break;
						}
						else
						{
							DataRow startFuncRow = FunctionMst.GetFunction(solutionId, startFanctionId);
							if (Convert.ToString(startFuncRow["WINDOW_OPEN_FLAG"]) == "0")
							{
								//機能表示
								SSOScript.Text += string.Format(@"<script language=JavaScript>openFunction('{0}', '{1}', 'main', '', '0', null);</script>", solutionId, startFanctionId);
								dispMenuLink = false;
								break;
							}
						}
					}

					if (dispMenuLink)
					{
						//メニューリンク表示
						SSOScript.Text += string.Format(@"<script language=JavaScript>parent.loadMenuLink('{0}', '{1}');</script>", solutionId, functionViewId);
					}

				}
				else
					throw new ApplicationException("メニュー情報取得に失敗しました。");

			}

			this.DataBind();
		}

	}

}
