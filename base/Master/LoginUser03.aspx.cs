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
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

public partial class UserMst_Confirm : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//他ページから移してきたときのみ実行する。
		if (!Page.IsPostBack)
		{
			LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");
			LoginIdLbl.Text = vo.LoginId;
			if (vo.OldPassword != vo.Password)
			{
				PasswordLbl1.Text = PasswordLbl1.Text.PadLeft(vo.Password.Length, '*');
				PasswordLbl2.Text = PasswordLbl2.Text.PadLeft((int)vo.Password.Length, '*');
			}
			else
			{
				FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUser03");
				PasswordLbl1.Text = resource.GetString("PasswordLbl1");
				PasswordLbl2.Text = resource.GetString("PasswordLbl1");
			}
			UserNameLbl.Text = vo.Name;
			KanaLbl.Text = vo.Kana;
			CompanyLbl.Text = CompanyMst.GetCompanyName(vo.CompanyID);
			EmployeeCodeLbl.Text = vo.MappingID;
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
		FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUser03");

		//標題をセットする
		Programtitle.Text = resource.GetString("Programtitle");
		Formtitle.Text = resource.GetString("Formtitle");
		LoginIdMenuLbl.Text = resource.GetString("LoginIdMenuLbl");
		UsernameMenuLbl.Text = resource.GetString("UsernameMenuLbl");
		PasswordMenuLbl1.Text = resource.GetString("PasswordMenuLbl1");
		PasswordMenuLbl2.Text = resource.GetString("PasswordMenuLbl2");
		KanaMenuLbl.Text = resource.GetString("KanaMenuLbl");
		CompanyMenuLbl.Text = resource.GetString("CompanyMenuLbl");
		ConfirmBtn.Text = resource.GetString("ConfirmBtn");
		CancelBtn.Text = resource.GetString("CancelBtn");
		EmployeeCodeMenuLbl.Text = resource.GetString("EmployeeCodeMenuLbl");

		#endregion
	}

	protected void ConfirmBtn_Click(object sender, EventArgs e)
	{
		DataTable dt = (DataTable)SessionManager.GetObject("SelectData", "LoginUserEdit");
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		LoginUserService service = new LoginUserService(infoVO);
		LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");
		if (vo == null)
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
			if (vo.RowUpdateId == null)
			{
				//登録
				Result res = service.InsertLoginUser(vo);

				//エラー処理
				if (!res.IsSuccess)
				{
					if (res.HasError)
					{
						// 排他エラー.ビジネスロジックエラー
						MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
						BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
						BusinessErrorMessage.Visible = true;
						ConfirmBtn.Enabled = false;
						return;
					}
					else
					{
						throw new ApplicationException("利用者情報登録に失敗しました。");
					}
				}
			}
			else
			{
				//更新
				Result res = service.UpdateLoginUser(vo);
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

						throw new ApplicationException("利用者情報更新に失敗しました。");
					}
				}

			}

			SessionManager.SessionRemoveByPgID("LoginUserEdit");

			Server.Transfer("LoginUser01.aspx");
		}
	}
	protected void ReBtn_Click(object sender, EventArgs e)
	{

		Server.Transfer("LoginUser02.aspx");
	}
}
