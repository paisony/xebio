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
using IntegratedDb;
using Com.Fujitsu.SmartBase.Base.Common.Config;

/// <summary>
/// WebServiceUtil の概要の説明です
/// </summary>
public class WebServiceUtil
{
    private WebServiceUtil()
    {
      
    }

    /// <summary>
    /// WebSERVE smart SOA IntegratedDbWsのインスタンスを作成します。
    /// </summary>
    /// <returns></returns>
    public static IntegratedDbWs CreateIntegratedDbInstance()
    {
        IntegratedDbWs ws = new IntegratedDbWs();
        ws.Url = SystemSettings.ReferenceWebService;
        return ws;
    }
}
