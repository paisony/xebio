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
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Text;

public partial class access_RoleMappingOutput : System.Web.UI.Page
{
    /// <summary>
    /// ページロード
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region 会社DDLにデータをバインド
            CompanyDrop.DataSource = CompanyMst.GetAllCompanyList();
            CompanyDrop.DataTextField = "COMPANY_NAME";
            CompanyDrop.DataValueField = "COMPANY_ID";
            CompanyDrop.DataBind();
            CompanyDrop.Items.Insert(0, new ListItem());
            #endregion
        }
    }

    /// <summary>
    /// リソースを取得し各々のaspxテキストにセットします。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        //他のページから遷移する場合
        if (!Page.IsPostBack)
        {
            #region 標題セット

            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleMappingOutput");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            CompanyLbl.Text = resource.GetString("CompanyLbl");
            OutputButton.Text = resource.GetString("OutputButton");
            BackBtn.Text = resource.GetString("BackBtn");

            #endregion
        }
    }

    /// <summary>
    /// 『出力』ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OutputButton_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            // 会社ＩＤからロール付与状況を取得
            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            RoleService rs = new RoleService(loginInfo);
            DataResult<DataTable> roleResult = rs.GetRoleMappingStatusByCompanyId(CompanyDrop.Text);
            //roleDt.IsSuccess
            if (roleResult.IsSuccess)
            {
                // ロール付与状況データをＣＳＶに変換
                string csvStr = CsvUtil.ConvertCSVwithHeader(roleResult.ResultData);
                string csvFileName = "RoleMappingStatus.csv";
                // ファイル出力
                Response.ClearHeaders();
                Response.ContentType = "APPLICATION/OCTET-STREAM";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
                Response.AppendHeader("Content-Disposition","attachment;filename="+ csvFileName);
                Response.Write(csvStr);
                Response.End();
            }
        }
    }

    /// <summary>
    /// 『戻る』ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("AccessMenu.aspx");
    }
}
