// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// WebService中で発生したSOAPExceptionの置換例外クラスです。
/// </summary>
public class WebServiceException : SystemException
{
    public WebServiceException(string message) : base(message)
    {
    }

    public WebServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
