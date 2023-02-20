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

public partial class Information_MessagePreview : System.Web.UI.Page
{
    /// <summary>
    /// トップメッセージプレビューのコードビハインド
    /// </summary>
    /// <remarks>画面遷移元:MessageEdit.aspx</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 閉じるボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CloseBtn_Click(object sender, EventArgs e)
    {
        string script = "<SCRIPT LANGUAGE='javascript'>" +
    "window.close();" +
    "</SCRIPT>";
        Response.Write(script);
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
            FormResource resource = ResourceManager.GetInstance().GetFormResource("MessagePreview");

            PreviewLbl.Text = resource.GetString("PreviewLbl");
            CloseBtn.Text = resource.GetString("CloseBtn");

            #endregion
        }
    }
}
