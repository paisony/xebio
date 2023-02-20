<%@ Application Language="C#" %>
<%@ Import Namespace="Common.Advanced.Web.Module" %>
<%@ Import Namespace="Common.IntegrationMD.Util" %>
<%@ Import Namespace="Common.IntegrationMD.Constant" %>
<%@ Import Namespace="Common.Authentication" %>
<%@ Import Namespace="Common.Standard.Exception" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script RunAt="server">

	void Application_Start(Object sender, EventArgs e)
	{

		// Code that runs on application startup
		try
		{
			SystemInitializer.DoProcess(this.Context);
		}
		catch (Exception)
		{
			System.Web.Hosting.HostingEnvironment.InitiateShutdown();
			// throw;
		}

		//DBアクセス部品をアプリケーション起動時に生成したい場合は以下のコメントを外してください
		try
		{
			Common.Standard.Model.Data.SqlRepository.CretateInstance();
		}
		catch (Exception)
		{
		}
	}

	void Application_End(Object sender, EventArgs e)
	{
		//  Code that runs on application shutdown

	}

	void Application_Error(Object sender, EventArgs e)
	{
        
        // Code that runs when an unhandled error occurs
        Exception ex = Server.GetLastError();
        if (GetInnerException<MDMultiWindowCheckException>(ex) != null)
        {
            Server.Transfer("~/pjcommon/error/MultiWindow.aspx");
        }
        else if (GetInnerException<ApplicationErrorException>(ex) != null)
        {
            Server.Transfer("~/pjcommon/error/ApplicationError.aspx");
        }
        else if (GetInnerException<SessionTimeoutException>(ex) != null)
        {
            Server.Transfer("~/pjcommon/aspx/SessionTimeout.aspx");
        }
        else if (GetInnerException<AuthenticationException>(ex) != null)
        {
            Server.Transfer("~/pjcommon/aspx/SessionTimeout.aspx");
        }
        else if (GetSystemErrorExceptionId(ex).IndexOf("Y979") >= 0)
        {
            Server.Transfer("~/pjcommon/aspx/SessionTimeout.aspx");
        }
        else
        {
            Server.Transfer("~/pjcommon/error/SystemError.aspx");
        }
	}

	void Session_Start(Object sender, EventArgs e)
	{
		// Code that runs when a new session is started
	}

	void Session_End(Object sender, EventArgs e)
	{
		// Code that runs when a session ends. 
		// Note: The Session_End event is raised only when the sessionstate mode
		// is set to InProc in the Web.config file. If session mode is set to StateServer 
		// or SQLServer, the event is not raised.
	}

	private TException GetInnerException<TException>(Exception ex) where TException : Exception
	{
		Exception _ex = ex;
		while (_ex != null)
		{
			if (_ex is TException)
			{
				return (TException)_ex;
			}
			_ex = _ex.InnerException;
		}
		return null;
	}

	private List<String> GetSystemErrorExceptionId(Exception e)
	{
		List<String> result = new List<String>();
		SystemErrorException se = GetInnerException<SystemErrorException>(e);
		while (se != null)
		{
			result.Add(se.Messageid);
			se = GetInnerException<SystemErrorException>(se.InnerException);
		}
		return result;
	}

	protected void Application_AcquireRequestState(object sender, EventArgs e)
	{
		if ((((System.Web.HttpApplication)sender).Context.Handler is IRequiresSessionState))
		{
			if (Common.Advanced.SelfCustomize.Runtime.PJCommon.UserContext.Current == null)
			{
				Common.Advanced.SelfCustomize.Runtime.PJCommon.UserContext context = new Common.Advanced.SelfCustomize.Runtime.PJCommon.UserContext();
				Common.Advanced.SelfCustomize.Runtime.PJCommon.UserContext.Current = context;
			}
		}
	    if (HttpContext.Current.Session != null)
		{
			ISessionLoad loader =
				SessionLoadFactory.GetLoader(HttpContext.Current.Session);
			loader.LoadHttpSession();
		}
        if (HttpContext.Current.Session != null && !Request.Url.AbsolutePath.EndsWith("Init.aspx"))
        {
            //開発中はダミーログイン回避
            if (!Request.Url.AbsolutePath.EndsWith("Default.aspx") && !Request.Url.AbsolutePath.EndsWith("default.aspx"))
            {
                Common.Standard.Login.LoginInfoUtil.GetLoginInfo(); //nullの場合Y979エラー
            }
        }
	}

	protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
	{
        
		if (HttpContext.Current.Session != null)
		{
			ISessionLoad loader =
				SessionLoadFactory.GetLoader(HttpContext.Current.Session);
			loader.ReleaseHttpSession();
		}
	}
    
</script>

