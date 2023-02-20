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
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using Com.Fujitsu.SmartBase.Base.Certification;

public partial class Access_LoginStatusReference : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            #region 検索
            LoginUserInfoVO infoVO = new LoginUserInfoVO();
            infoVO.LoginId = LoginUserContext.LoginId;
            CertificationService service = new CertificationService();
            QueryObject query = new QueryObject();

            //ページャの初期化
            query.StartRow = 0;
            query.MaxRowCount = Pager.PageSize;

            //検索結果件数取得
            DataResult<int> res = service.FindCountUser(query);

            //ログイン人数表示
            string str = res.ResultData.ToString();
            CountLbl.Text = str;

            //データ取得
            DataResult<DataTable> res2 = service.FindUser(query);

            //GridViewにバインド
            LoginStatusList.DataSource = res2.ResultData;
            LoginStatusList.DataBind();

            //検索結果全件数
            Pager.VirtualItemCount = res.ResultData;

            //現在のページ番号をセッションに保存
            Pager.CurrentPageIndex = 0;
            SessionManager.SetObject(0, "PageIndex", "LoginStatus");

            //検索条件セッション保存
            SessionManager.SetObject(query, "ResearchCondition", "LoginStatus");
            #endregion
        }
    }

    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            #region 標題セット

            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginStatusReference");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            UserCountLbl.Text = resource.GetString("UserCountLbl");
            ReloadButton.Text = resource.GetString("ReloadButton");
            BackBtn.Text = resource.GetString("BackBtn");
            
            //列ヘッダー名
            LoginStatusList.Columns[0].HeaderText = resource.GetString("LoginStatusList_COMPANY");
            LoginStatusList.Columns[1].HeaderText = resource.GetString("LoginStatusList_LOGINID");
            LoginStatusList.Columns[2].HeaderText = resource.GetString("LoginStatusList_NAME");
            LoginStatusList.Columns[3].HeaderText = resource.GetString("LoginStatusList_TIME");
           
            #endregion
        }

    }

    #region リロード
    /// <summary>
    /// リロードボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ReloadButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        LoginUserInfoVO infoVO = new LoginUserInfoVO();
        infoVO.LoginId = LoginUserContext.LoginId;
        CertificationService service = new CertificationService();
        QueryObject query = new QueryObject();

        //ページャの初期化
        query.StartRow = 0;
        query.MaxRowCount = Pager.PageSize;


        //検索結果件数取得
        DataResult<int> res = service.FindCountUser(query);

        //ログイン人数表示
        string str = res.ResultData.ToString();
        CountLbl.Text = str;
        
        //データ取得
        DataResult<DataTable> res2 = service.FindUser(query);

        //GridViewにバインド
        LoginStatusList.DataSource = res2.ResultData;
        LoginStatusList.DataBind();

        //検索結果全件数
        Pager.VirtualItemCount = res.ResultData;

        //現在のページ番号をセッションに保存
        Pager.CurrentPageIndex = 0;
        SessionManager.SetObject(0, "PageIndex", "LoginStatus");

        //検索条件セッション保存
        SessionManager.SetObject(query, "ResearchCondition", "LoginStatus");

    }
    #endregion

    #region 戻る
    /// <summary>
    /// 戻るボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("AccessMenu.aspx");
    }
    #endregion

    #region ページ遷移
    /// <summary>
    /// ページングイベント
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

        //セッションから検索条件取得
        QueryObject query = (QueryObject)SessionManager.GetObject("ResearchCondition", "LoginStatus");
        LoginUserInfoVO infoVO = new LoginUserInfoVO();
        infoVO.LoginId = LoginUserContext.LoginId;
        CertificationService service = new CertificationService();

        //検索結果件数取得
        DataResult<int> res = service.FindCountUser(query);

        //ログイン人数表示
        string str = res.ResultData.ToString();
        CountLbl.Text = str;

        //ページデータ取得
        query.StartRow = Pager.PageSize * e.NewPageIndex;
        query.MaxRowCount = Pager.PageSize;

        //データ取得
        DataResult<DataTable> res1 = service.FindUser(query);

        //GridViewにバインド
        LoginStatusList.DataSource = res1.ResultData;
        LoginStatusList.DataBind();

        //検索結果全件数
        Pager.VirtualItemCount = res.ResultData;

        //現在のページ設定
        Pager.CurrentPageIndex = e.NewPageIndex;
        SessionManager.SetObject(e.NewPageIndex, "PageIndex", "LoginStatus");
        //検索条件セッション保存
        SessionManager.SetObject(query, "ResearchCondition", "LoginStatus");
    }
    #endregion

    #region 会社名表示
    protected void LoginStatusList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));
            Label companyLbl = (Label)e.Row.FindControl("CompanyNAME");
            companyLbl.Text = CompanyMst.GetCompanyName(companyId);
        }
    }
    #endregion

}
