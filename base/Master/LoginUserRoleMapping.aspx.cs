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
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;

public partial class Master_LoginUserRoleMapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string loginId = Convert.ToString(HttpContext.Current.Items["loginId"]);
            ViewState["LoginId"] = loginId;

            LoginUserInfoVO infoVO = new LoginUserInfoVO();
            infoVO.LoginId = LoginUserContext.LoginId;

            //ユーザ情報取得
            LoginUserService userService = new LoginUserService(infoVO);
            DataResult<DataTable> userRes = userService.GetLoginUserData(new LoginUserKey(loginId));
            if (!userRes.IsSuccess)
                throw new ApplicationException("利用者情報取得に失敗しました。");
            //排他エラー
            else if (userRes.ResultData.Rows.Count == 0)
            {
                //throw new ApplicationException("利用者情報が存在しません。");
                MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                BusinessErrorMessage.Visible = true;

                UpdateBtn.Enabled = false;
                return;
            }
            else
            {
                #region 利用者情報をVOに格納
                LoginUserVO userVO = new LoginUserVO();
                userVO.LoginId = Convert.ToString(userRes.ResultData.Rows[0]["LOGIN_ID"]);
                userVO.CompanyID = Convert.ToString(userRes.ResultData.Rows[0]["COMPANY_ID"]);
                userVO.Password = Convert.ToString(userRes.ResultData.Rows[0]["PASSWORD"]);
                userVO.OldPassword = Convert.ToString(userRes.ResultData.Rows[0]["PASSWORD"]);
                userVO.PasswordUpdateDateTime = Convert.ToDateTime(userRes.ResultData.Rows[0]["PASSWORD_UPDATE_DATETIME"]);
                userVO.Name = Convert.ToString(userRes.ResultData.Rows[0]["NAME"]);
                userVO.Kana = Convert.ToString(userRes.ResultData.Rows[0]["NAME_KANA"]);
                userVO.MappingID = Convert.ToString(userRes.ResultData.Rows[0]["MAPPING_ID"]);
                userVO.UserType = Convert.ToString(userRes.ResultData.Rows[0]["USER_TYPE"]);
                userVO.TempPasswordFlag = Convert.ToString(userRes.ResultData.Rows[0]["TEMP_PASSWORD_FLAG"]);
                userVO.RowUpdateId = Convert.ToString(userRes.ResultData.Rows[0]["ROW_UPDATE_ID"]);
                userVO.DeleteFlag = Convert.ToString(userRes.ResultData.Rows[0]["DELETE_FLAG"]);
                #endregion

                //セッションに詰める
                SessionManager.SetObject(userVO, "RoleUserVO", "LoginUserRole");
                //情報表示
                CompanyNameLbl.Text = CompanyMst.GetCompanyName(userVO.CompanyID);
                LoginNameLbl.Text = userVO.Name;
            }
            
            

            //ロールマッピング情報取得
            DataResult<DataTable> mapRes = userService.GetRoleUserMapByLoginId(loginId);
            if (!mapRes.IsSuccess)
                throw new ApplicationException("ロール付与情報取得に失敗しました。");
            
            SessionManager.SetObject(mapRes.ResultData, "RoleUserMap", "LoginUserRole");

            //ロール情報取得
            RoleService roleService = new RoleService(infoVO);
            DataResult<DataTable> roleRes = roleService.GetAllRole();
            if (!roleRes.IsSuccess)
                throw new ApplicationException("ロール一覧情報取得に失敗しました。");

            //セッションに詰めておく
            SessionManager.SetObject(roleRes.ResultData, "RoleList", "LoginUserRole");

            //グリッドにバインド
            RoleList.DataSource = roleRes.ResultData;
            RoleList.DataBind();

        }

        //初期化
        BusinessErrorMessage.Visible = false;
    }

    /// <summary>
    /// フォームのデータを表示する。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUserRoleMapping");

            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            UpdateBtn.Text = resource.GetString("UpdateBtn");
            CancelBtn.Text = resource.GetString("CancelBtn");
            CompanyLbl.Text = resource.GetString("CompanyLbl");
            LoginLbl.Text = resource.GetString("LoginLbl");
        }
    }

    #region クリックイベント

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        LoginUserVO userVO = (LoginUserVO)SessionManager.GetObject("RoleUserVO", "LoginUserRole");
        List<RoleUserMapVO> list = new List<RoleUserMapVO>();
        foreach (GridViewRow row in RoleList.Rows)
        {
            CheckBox roleCheck = (CheckBox)row.FindControl("RoleCheckBox");
            if (roleCheck.Checked)
            {
                RoleUserMapVO vo = new RoleUserMapVO();
                vo.LoginId = userVO.LoginId;
                Label roleLbl = (Label)row.FindControl("RoleIdLbl");
                vo.RoleId = roleLbl.Text;
                list.Add(vo);
            }
        }

        LoginUserInfoVO infoVO = new LoginUserInfoVO();
        infoVO.LoginId = LoginUserContext.LoginId;
        LoginUserService service = new LoginUserService(infoVO);
        Result res = service.UpdateUserRoleMap(userVO, list.ToArray());

        if (!res.IsSuccess)
        {
            if (res.HasError && res.Errors[0] is DBConcurrencyError)
            {
                //排他エラー
                MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                BusinessErrorMessage.Visible = true;
                return;
            }
            else
            {
                throw new ApplicationException("ユーザロールマッピング更新に失敗しました。");
            }
        }

        FunctionAuthorizationMst.ClearCache();

        LoginMst.SetLoginInfo(LoginUserContext.LoginId);

        SessionManager.SessionRemoveByPgID("LoginUserRole");
        Server.Transfer("LoginUser01.aspx");
    }

    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        SessionManager.SessionRemoveByPgID("LoginUserRole");
        Server.Transfer("LoginUser01.aspx");
    }

    #endregion

    protected void RoleList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)SessionManager.GetObject("RoleUserMap", "LoginUserRole");
            string roleId = ((Label)e.Row.FindControl("RoleIdLbl")).Text;
            DataRow[] rows = dt.Select("ROLE_ID = '" + roleId + "'");
    
            CheckBox roleCheck = (CheckBox)e.Row.FindControl("RoleCheckBox");
            if (rows.Length > 0)
                roleCheck.Checked = true;
            else
                roleCheck.Checked = false;
        }
    }
}
