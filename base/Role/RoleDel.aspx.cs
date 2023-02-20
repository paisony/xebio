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
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Systems;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Reflection;
using Com.Fujitsu.SmartBase.Base.DataLog;
using Com.Fujitsu.SmartBase.Base.Common.Util;

public partial class Role_RoleDel : System.Web.UI.Page
{
    /// <summary>
    /// 削除確認ページをロードします。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region 初期データをセット
            string roleId = Convert.ToString(HttpContext.Current.Items["RoleId"]);
            RoleVO roleVO = (RoleVO)SessionManager.GetObject("RoleVO", "RoleDel");

            if (!string.IsNullOrEmpty(roleId))
            {
                //ＤＢから初期データ取得
                LoginUserInfoVO loginInfo = new LoginUserInfoVO();
                loginInfo.LoginId = LoginUserContext.LoginId;

                RoleService rolesv = new RoleService(loginInfo);

                #region ロール情報

                RoleKey key = new RoleKey(roleId);
                DataResult<DataTable> roleRes = rolesv.GetRole(key);

                //ロール情報
                if (roleRes.IsSuccess)
                {
                    if (roleRes.ResultData.Rows.Count > 0)
                    {
                        roleVO = new RoleVO();

                        roleVO.RoleId = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_ID"]);
                        roleVO.RoleName = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NAME"]);
                        roleVO.RoleNote = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NOTE"]);
                        roleVO.RowUpdateId = Convert.ToString(roleRes.ResultData.Rows[0]["ROW_UPDATE_ID"]);

                        RoleId.Text = roleVO.RoleId;
                        RoleName.Text = roleVO.RoleName;
                        RoleNote.Text = roleVO.RoleNote;

                        SessionManager.SetObject(roleVO, "RoleVO", "RoleDel");

                    }
                    else
                    {
                        //排他エラー
                        MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                        BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                        BusinessErrorMessage.Visible = true;

                        DeleteBtn.Enabled = false;
                        return;
                    }
                }
                else
                {
                    throw new ApplicationException("ロール情報取得に失敗しました。");
                }

                #endregion

                #region システム使用許可取得

                Dictionary<string, string> systemAuthorization = new Dictionary<string, string>();
                //システム使用許可取得
                DataResult<DataTable> authRes = rolesv.GetSystemAuthorizationByRoleId(roleId);
                if (!authRes.IsSuccess)
                    throw new ApplicationException("システム使用許可情報取得に失敗しました。");
                foreach (DataRow row in authRes.ResultData.Rows)
                {
                    string solutionId = Convert.ToString(row["SOLUTION_ID"]);
                    string sortNo = Convert.ToString(row["SORT_NO"]);
                    systemAuthorization.Add(solutionId, sortNo);
                }

                SessionManager.SetObject(systemAuthorization, "SystemAuthorization", "RoleDel");

                #endregion

                #region 機能使用許可情報

                DataResult<DataTable> funcRes = rolesv.GetFunctionAuthorizationByRoleId(roleId);

                //機能使用許可情報
                if (funcRes.IsSuccess)
                {
                    SessionManager.SetObject(funcRes.ResultData, "FunctionAuthorization", "RoleDel");
                }
                else
                {
                    throw new ApplicationException("機能使用許可情報取得に失敗しました。");
                }

                #endregion

            }
            else if (roleVO != null)
            {
                RoleName.Text = roleVO.RoleName;
                RoleNote.Text = roleVO.RoleNote;
            }
            else
            {
                //エラー
                throw new ApplicationException("ロール情報取得に失敗しました。");
            }

            //ソリューション情報取得
            SystemService syssv = new SystemService();
            DataResult<DataTable> solRes = syssv.GetAllSolution();

            if (solRes.IsSuccess)
            {
                AuthorizationList.DataSource = solRes.ResultData;
                AuthorizationList.DataBind();
            }
            else
            {
                throw new ApplicationException("ソリューション情報取得に失敗しました。");
            }

            #endregion
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
            FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleDel");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            RoleNameLbl.Text = resource.GetString("RoleNameLbl");
            NoteLbl.Text = resource.GetString("NoteLbl");
            DeleteBtn.Text = resource.GetString("DeleteBtn");
            CancelBtn.Text = resource.GetString("CancelBtn");

        }
    }

    /// <summary>
    /// 使用許可一覧のバインドイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AuthorizationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string solutionId = ((Label)e.Row.FindControl("SolutionId")).Text;

            //使用許可を取得する。
            Dictionary<string, string> systemAuthorization = (Dictionary<string, string>)SessionManager.GetObject("SystemAuthorization", "RoleDel");

            if (systemAuthorization != null && systemAuthorization.ContainsKey(solutionId))
            {
                CheckBox allow = (CheckBox)e.Row.FindControl("AllowCheckBox");
                allow.Checked = true;
                TextBox sort = (TextBox)e.Row.FindControl("SortBox");
                sort.Text = systemAuthorization[solutionId];
            }
        }
    }

    /// <summary>
    /// 削除ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        RoleService rs = new RoleService(loginInfo);
        
        RoleVO roleVO = (RoleVO)SessionManager.GetObject("RoleVO", "RoleDel");
        //削除
        Result res = rs.DeleteRole((RoleKey)roleVO, roleVO.RowUpdateId);
        
        if (!res.IsSuccess && res.HasError && res.Errors[0] is DBConcurrencyError)
        {
            // 排他エラー
            MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
            BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
            BusinessErrorMessage.Visible = true;
            return;
        }
        else if (!res.IsSuccess && res.HasError && res.Errors[0] is BusinessError)
        {
            //業務ロジックエラー
            MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
            BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
            BusinessErrorMessage.Visible = true;
            return;

        }
        else if (!res.IsSuccess)
        {
            throw new ApplicationException("ロール情報の登録に失敗しました。" + res.ToString());
        }

        SessionManager.SessionRemoveByPgID("RoleDel");
        Server.Transfer("RoleList.aspx");
    }

    /// <summary>
    /// 取消ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        SessionManager.SessionRemoveByPgID("RoleDel");
        Server.Transfer("RoleList.aspx");
    }
}
