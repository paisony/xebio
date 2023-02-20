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
using Com.Fujitsu.SmartBase.Base.Common.Web;

public partial class role_RoleList : System.Web.UI.Page
{
    #region ページロード

    /// <summary>
    /// ロールリストを表示します。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params.Get("IsInit")))
            {
                SessionManager.SessionRemoveByPgID("Role");
                SessionManager.SessionRemoveByPgID("RoleEdit");
                SessionManager.SessionRemoveByPgID("RoleDel");
                SessionManager.SessionRemoveByPgID("RoleUserMap");
                SessionManager.SessionRemoveByPgID("Menu");
            }

            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            RoleService rs = new RoleService(loginInfo);
            DataResult<DataTable> roleResult = rs.GetAllRole();
            //roleDt.IsSuccess
            if (roleResult.IsSuccess)
            {
                #region Grid表示
                //ページャー表示処理
                int pageindex = Convert.ToInt32(SessionManager.GetObject("PageIndex", "Role"));
                //検索結果件数取得
                int a = 0;
                if (roleResult.ResultData.Rows.Count % Pager.PageSize != 0)
                    a = 1;

                int b = roleResult.ResultData.Rows.Count / Pager.PageSize + a - 1;
                if (b < 0)
                    b = 0;

                if (pageindex > b)
                {
                    pageindex = b;
                }

                //データバインド、ページャー初期化
                Pager.VirtualItemCount = roleResult.ResultData.Rows.Count;
                Pager.PageSize = RoleList.PageSize;
                Pager.CurrentPageIndex = RoleList.PageIndex;

                SessionManager.SetObject(roleResult.ResultData, "RoleList", "Role");
                SessionManager.SetObject(pageindex, "PageIndex", "Role");
                #endregion
            }
            else
            {
                throw new ApplicationException("権限リストの取得に失敗しました。" + roleResult.ToString());
            }
        }
    }

    #endregion

    #region フォームのデータを表示
    /// <summary>
    /// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region 標題セット

            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleList");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            AddBtn.Text = resource.GetString("AddBtn");

            RoleList.Columns[0].HeaderText = resource.GetString("RoleId");
            RoleList.Columns[1].HeaderText = resource.GetString("RoleName");
            RoleList.Columns[2].HeaderText = resource.GetString("RoleNote");
            RoleList.Columns[3].HeaderText = resource.GetString("RoleEdit");
            RoleList.Columns[4].HeaderText = resource.GetString("MenuSet");
            RoleList.Columns[5].HeaderText = resource.GetString("RoleDel");
            RoleList.Columns[6].HeaderText = resource.GetString("UserMap");

            //ボタンフィールド中のボタンのテキスト表示
            ((ButtonField)RoleList.Columns[3]).Text = resource.GetString("RoleEditBtn");
            ((ButtonField)RoleList.Columns[4]).Text = resource.GetString("MenuBtn");
            ((ButtonField)RoleList.Columns[5]).Text = resource.GetString("RoleDelBtn");
            ((ButtonField)RoleList.Columns[6]).Text = resource.GetString("UserMapBtn");

            #endregion

            #region Grid表示
            //ページャー表示処理
            DataTable dt = (DataTable)SessionManager.GetObject("RoleList", "Role");
            int pageindex = Convert.ToInt32(SessionManager.GetObject("PageIndex", "Role"));
           
            //データバインド、ページャー初期化
            Pager.VirtualItemCount = dt.Rows.Count;
            Pager.PageSize = RoleList.PageSize;
            Pager.CurrentPageIndex = pageindex;

            RoleList.DataSource = dt;
            RoleList.PageIndex = pageindex;
            RoleList.DataBind();
            #endregion

        }
    }
    #endregion

    #region 新規登録ボタン押下時

    /// <summary>
    /// 新規登録ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddBtn_Click(object sender, EventArgs e)
    {
        //IDを付けずにロール編集画面遷移
        Server.Transfer("RoleEdit.aspx");

    }
    #endregion 

    #region ロール一覧のボタン（編集、削除）押下時

    /// <summary>
    /// ロール一覧のボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RoleList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        Label roleLbl = (Label)RoleList.Rows[index].FindControl("RoleId");
        //ItemsにロールIDをセット
        HttpContext.Current.Items.Add("RoleId", roleLbl.Text);

        if (e.CommandName == "EditRow")
        {
            //ロールの編集ボタン押下
            Server.Transfer("RoleEdit.aspx");
        }
        else if (e.CommandName == "MenuSetting")
        {
            //メニューの設定ボタン押下
            Server.Transfer("MenuSetting.aspx");
        }
        else if (e.CommandName == "DeleteRow")
        {
            //ロールの削除ボタン押下
            Server.Transfer("RoleDel.aspx");
        }
        else if (e.CommandName == "UserSetting")
        {
            //ロールのユーザ設定ボタン押下
            Server.Transfer("RoleUserMapping.aspx");
        }
        
    }

    #endregion 

    /// <summary>
    /// ページングイベント
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataTable dt = (DataTable)SessionManager.GetObject("RoleList", "Role");
        RoleList.DataSource = dt;
        RoleList.PageIndex = e.NewPageIndex;
        RoleList.DataBind();
        Pager.CurrentPageIndex = e.NewPageIndex;
        SessionManager.SetObject(e.NewPageIndex, "PageIndex", "Role");
    }

    /// <summary>
    /// ロール一括アップロード押下時のイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UploadBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("RoleUpload.aspx");
    }
}
