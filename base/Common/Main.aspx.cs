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
using Com.Fujitsu.SmartBase.Base.Common.Util;

public partial class Common_Main : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			DataBind();
		}
	}

	/// <summary>
	/// タイトルを取得します。
	/// </summary>
	/// <returns></returns>
	public string GetTitle()
	{
		/* --------------- 2016/07/14 FE)Y.Kawabuchi ST-0xx Update Start ---------------
		return "統合ＭＤシステム";
		*/
		return "ＢＯシステム";
		/* --------------- 2016/07/14 FE)Y.Kawabuchi ST-0xx Update End --------------- */
	}
}
