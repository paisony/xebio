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
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Library.WebControls;

public partial class UserMst_DelConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            string loginId = Convert.ToString(HttpContext.Current.Items["loginId"]);

            LoginUserInfoVO infoVO = new LoginUserInfoVO();
            infoVO.LoginId = LoginUserContext.LoginId;

            LoginUserService service = new LoginUserService(infoVO);
            LoginUserKey key = new LoginUserKey(loginId);
            DataResult<DataTable> res = service.GetLoginUserData(key);

            //エラー処理
            if (!res.IsSuccess)
            {
                throw new ApplicationException("利用者情報取得に失敗しました。");
            }

            if (res.ResultData.Rows.Count > 0)
            {

                LoginIdLbl.Text = Convert.ToString(res.ResultData.Rows[0]["LOGIN_ID"]);
                UsernameLbl.Text = Convert.ToString(res.ResultData.Rows[0]["NAME"]);
                KanaLbl.Text = Convert.ToString(res.ResultData.Rows[0]["NAME_KANA"]);
                CompanyLbl.Text = CompanyMst.GetCompanyName(Convert.ToString(res.ResultData.Rows[0]["COMPANY_ID"]));
                EmployeeCodeLbl.Text = Convert.ToString(res.ResultData.Rows[0]["MAPPING_ID"]);
                
                LoginUserVO vo1 = new LoginUserVO();
                vo1.LoginId = LoginIdLbl.Text;
                vo1.CompanyID = CompanyLbl.Text;
                vo1.RowUpdateId = Convert.ToString(res.ResultData.Rows[0]["ROW_UPDATE_ID"]);
                vo1.MappingID = EmployeeCodeLbl.Text;
                SessionManager.SetObject(vo1, "DeleteData", "LoginUserEdit");
            }
            else
            {
                //排他エラー
                if (res.ResultData.Rows.Count == 0)
                {
                    MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                    BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                    BusinessErrorMessage.Visible = true;
                    ConfirmBtn.Enabled = false;
                    return;
                }
            }
        }  
    }
    /// <summary>
    /// フォームのデータを表示する。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        #region 標題セット
        //リソース取得
        FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUser04");

        //標題をセットする
        Programtitle.Text = resource.GetString("Programtitle");
        Formtitle.Text = resource.GetString("Formtitle");
        LoginIdMenuLbl.Text = resource.GetString("LoginIdMenuLbl");
        UsernameMenuLbl.Text = resource.GetString("UsernameMenuLbl");
        KanaMenuLbl.Text = resource.GetString("KanaMenuLbl");
        CompanyMenuLbl.Text = resource.GetString("CompanyMenuLbl");
        ConfirmBtn.Text = resource.GetString("ConfirmBtn");
        CancelBtn.Text = resource.GetString("CancelBtn");
        EmployeeCodeMenuLbl.Text = resource.GetString("EmployeeCodeMenuLbl");

        #endregion
    }
    /// <summary>
    /// 削除を実行する。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        LoginUserInfoVO infoVO = new LoginUserInfoVO();
        infoVO.LoginId = LoginUserContext.LoginId;

        LoginUserService service = new LoginUserService(infoVO);
        LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("DeleteData", "LoginUserEdit");

        Result res = service.DeleteLoginUser(vo);
        //エラー処理
        if (!res.IsSuccess)
        {
            if (res.HasError && res.Errors[0] is DBConcurrencyError)
            {
                // 排他エラー
                MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                BusinessErrorMessage.Visible = true;
                ConfirmBtn.Enabled = false;
                return;
            }
            else
            {
                throw new ApplicationException("利用者情報削除に失敗しました。");
            }
        }
      
        Server.Transfer("LoginUser01.aspx");
    }

    
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("LoginUser01.aspx");
    }

    
}
