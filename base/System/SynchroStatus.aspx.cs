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
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.Systems.Util;

public partial class System_SynchroStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SynchroInformationService service = new SynchroInformationService();
            DataResult<DataTable> batRes = service.GetBatInformation(new BatInformationKey(SystemsConstantUtil.BAT_ID_SYNCHRO));

            if (!batRes.IsSuccess)
                throw new ApplicationException("バッチ実行状態取得に失敗しました。");

            BatList.DataSource = batRes.ResultData;
            BatList.DataBind();

            DataResult<DataTable> synchroRes = service.GetAllSynchroInformation();
            if (!synchroRes.IsSuccess)
                throw new ApplicationException("連携状態取得に失敗しました。");
            SynchroList.DataSource = synchroRes.ResultData;
            SynchroList.DataBind();
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
            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("SynchroStatus");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle1.Text = resource.GetString("Formtitle1");
            Formtitle2.Text = resource.GetString("Formtitle2");
        }
    }

    protected void BatList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label statusLbl = (Label)e.Row.FindControl("LastBatExitCode");
            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("SynchroStatus");

            if (statusLbl.Text == "0")
            {
                statusLbl.Text = resource.GetString("Bat0");
            }
            else
            {
                statusLbl.Text = resource.GetString("Bat1");
            }
        }
    }
    protected void SynchroList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label dataLbl = (Label)e.Row.FindControl("DataType");
            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("SynchroStatus");

            dataLbl.Text = resource.GetString(dataLbl.Text);
        }
    }
}
