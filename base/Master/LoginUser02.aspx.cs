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
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Config;

public partial class UserMst_Input : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//他ページから移してきたときのみ実行する。
		if (!Page.IsPostBack)
		{
			SetInputValidation();

			#region 会社DDLにデータをバインド

			CompanyDrop.DataSource = CompanyMst.GetAllCompanyList();
			CompanyDrop.DataTextField = "COMPANY_NAME";
			CompanyDrop.DataValueField = "COMPANY_ID";
			CompanyDrop.DataBind();
			CompanyDrop.Items.Insert(0, new ListItem());
			#endregion

			//新規登録または修正の場合
			if (HttpContext.Current.Items["loginId"] == null)
			{
				LoginUserVO vo1 = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");

				if (vo1 != null)
				{
					//確認画面から修正
					LoginIdBox.Text = vo1.LoginId;
					UserNameBox.Text = vo1.Name;
					KanaBox.Text = vo1.Kana;
					CompanyDrop.SelectedValue = vo1.CompanyID;
					EmployeeCodeTextBox.Text = vo1.MappingID;

					//編集モード
					string mode = (string)SessionManager.GetObject("Mode", "LoginUserEdit");
					if (!string.IsNullOrEmpty(mode))
					{
						LoginIdBox.Enabled = false;
						PasswordReqValid.Enabled = false;
					}
				}
				else
				{
					//新規作成ボタン
					LoginUserVO vo = new LoginUserVO();
					SessionManager.SetObject(vo, "LoginUserVO", "LoginUserEdit");
				}
			}
			//編集の場合
			else
			{
				PasswordReqValid.Enabled = false;
				LoginUserInfoVO infoVO = new LoginUserInfoVO();
				infoVO.LoginId = LoginUserContext.LoginId;
				LoginUserService service = new LoginUserService(infoVO);
				string loginId = Convert.ToString(HttpContext.Current.Items["loginId"]);
				LoginUserKey key = new LoginUserKey(loginId);
				DataResult<DataTable> res = service.GetLoginUserData(key);

				//エラー処理
				if (!res.IsSuccess)
				{
					throw new ApplicationException("利用者情報取得に失敗しました。");
				}

				if (res.ResultData.Rows.Count > 0)
				{
					//VOにセット
					LoginUserVO vo1 = new LoginUserVO();
					vo1.LoginId = Convert.ToString(res.ResultData.Rows[0]["LOGIN_ID"]);
					vo1.Name = Convert.ToString(res.ResultData.Rows[0]["NAME"]);
					vo1.Kana = Convert.ToString(res.ResultData.Rows[0]["NAME_KANA"]);
					vo1.CompanyID = Convert.ToString(res.ResultData.Rows[0]["COMPANY_ID"]);
					vo1.RowUpdateId = Convert.ToString(res.ResultData.Rows[0]["ROW_UPDATE_ID"]);
					vo1.Password = Convert.ToString(res.ResultData.Rows[0]["PASSWORD"]);
					vo1.OldPassword = Convert.ToString(res.ResultData.Rows[0]["PASSWORD"]);
					vo1.MappingID = Convert.ToString(res.ResultData.Rows[0]["MAPPING_ID"]);
					vo1.TempPasswordFlag = Convert.ToString(res.ResultData.Rows[0]["TEMP_PASSWORD_FLAG"]);
					vo1.PasswordUpdateDateTime = Convert.ToDateTime(res.ResultData.Rows[0]["PASSWORD_UPDATE_DATETIME"]);
					vo1.DeleteFlag = Convert.ToString(res.ResultData.Rows[0]["DELETE_FLAG"]);
					vo1.LockFlag = Convert.ToString(res.ResultData.Rows[0]["LOCK_FLAG"]);
					vo1.MappingID = Convert.ToString(res.ResultData.Rows[0]["MAPPING_ID"]);
					SessionManager.SetObject(vo1, "LoginUserVO", "LoginUserEdit");

					//画面表示
					LoginIdBox.Text = Convert.ToString(res.ResultData.Rows[0]["LOGIN_ID"]);
					UserNameBox.Text = Convert.ToString(res.ResultData.Rows[0]["NAME"]);
					KanaBox.Text = Convert.ToString(res.ResultData.Rows[0]["NAME_KANA"]);
					EmployeeCodeTextBox.Text = Convert.ToString(res.ResultData.Rows[0]["MAPPING_ID"]);
					CompanyDrop.SelectedValue = Convert.ToString(res.ResultData.Rows[0]["COMPANY_ID"]);

					//編集モード
					SessionManager.SetObject("Edit", "Mode", "LoginUserEdit");
					LoginIdBox.Enabled = false;
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
					else
					{
						throw new ApplicationException("利用者情報取得できませんでした。");
					}
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
		string loginIdMaxLength = Convert.ToString(SystemSettings.InputValidationSettings.Settings["LoginIdMaxLength"].Value);
		string pwdMinLength = Convert.ToString(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		string pwdMaxLength = Convert.ToString(SystemSettings.InputValidationSettings.Settings["PwdMaxLength"].Value);

		#region 標題セット
		//リソース取得
		FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUser02");

		//標題をセットする
		Programtitle.Text = resource.GetString("Programtitle");
		Formtitle.Text = resource.GetString("Formtitle");
		LoginIDCutline.Text = resource.GetString("LoginIDCutline", loginIdMaxLength);
		PasswordLbl1.Text = resource.GetString("PasswordLbl1");
		PasswordCutline.Text = resource.GetString("PasswordCutline", pwdMinLength, pwdMaxLength);
		PasswordLbl2.Text = resource.GetString("PasswordLbl2");
		PasswordMatchCutline.Text = resource.GetString("PasswordMatchCutline");
		LoginIdLbl.Text = resource.GetString("LoginIdLbl");
		UsernameLbl.Text = resource.GetString("UsernameLbl");
		UserNameCutline.Text = resource.GetString("UserNameCutline");
		KanaLbl.Text = resource.GetString("KanaLbl");
		KanaCutline.Text = resource.GetString("KanaCutline");
		CompanyLbl.Text = resource.GetString("CompanyLbl");
		CompanyCutline.Text = resource.GetString("CompanyCutline");
		ConfirmBtn.Text = resource.GetString("ConfirmBtn");
		CancelBtn.Text = resource.GetString("CancelBtn");
		EmpLbl.Text = resource.GetString("EmpLbl");
		EmplCutline.Text = resource.GetString("EmpCutline");
		// エラーメッセージ
		UserNameReqValid.ErrorMessage = resource.GetString("UserNameReqValid");
		UserNameRegValid.ErrorMessage = resource.GetString("UserNameRegValid");
		//UserNameInvalidCharValid.Text = resource.GetString("UserNameInvalidCharValid");
		KanaRegValid.ErrorMessage = resource.GetString("KanaRegValid");
		CompanyReqValid.ErrorMessage = resource.GetString("CompanyReqValid");
		PasswordMatchValid.ErrorMessage = resource.GetString("PasswordMatchValid");
		PasswordRegValid.ErrorMessage = resource.GetString("PasswordRegValid");
		PasswordReqValid.ErrorMessage = resource.GetString("PasswordReqValid");
		LoginIdRegValid.ErrorMessage = resource.GetString("LoginIdRegValid");
		LoginIdReqValid.ErrorMessage = resource.GetString("LoginIdReqValid");
		LoginIdCustomValid.ErrorMessage = resource.GetString("LoginIdCustomValid");
		//PasswordInvalidCharValid.Text = resource.GetString("PasswordInvalidCharValid");
		PwdStrengthCusVal.ErrorMessage = resource.GetString("PwdStrengthCusVal", pwdMinLength, pwdMaxLength);
		EmpRegValid.ErrorMessage = resource.GetString("EmpRegValid");

		#endregion
	}

	protected void CancelBtn_Click(object sender, EventArgs e)
	{
		SessionManager.SessionRemoveByPgID("LoginUserEdit");

		Server.Transfer("LoginUser01.aspx");
	}

	protected void ConfirmBtn_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;
		LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");
		if (vo.OldPassword != vo.Password)
		{
			vo.Password = vo.OldPassword;
		}
		vo.LoginId = LoginIdBox.Text;
		vo.Name = UserNameBox.Text;
		vo.Kana = KanaBox.Text;
		vo.CompanyID = CompanyDrop.SelectedValue;
		vo.MappingID = EmployeeCodeTextBox.Text;

		if (Password1Box.Text.Trim().Length != 0)
		{
			vo.Password = Password1Box.Text;
		}
		Server.Transfer("LoginUser03.aspx");
	}



	protected void PasswordMatchValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if (Password1Box.Text != Password2Box.Text)
		{
			args.IsValid = false;
		}
		else
		{
			args.IsValid = true;
		}
	}

	protected void LoginIdCustomValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		DataTable dt = LoginMst.GetAllSystemManagerList();
		DataRow[] rows = dt.Select(string.Format("LOGIN_ID = '{0}'", args.Value));
		args.IsValid = rows.Length == 0;
	}

	private void SetInputValidation()
	{
		int loginIdMaxLength = Convert.ToInt32(SystemSettings.InputValidationSettings.Settings["LoginIdMaxLength"].Value);
		//ログインIDの最大桁数の変更
		LoginIdBox.MaxLength = loginIdMaxLength;

		string pwdRegexp = SystemSettings.InputValidationSettings.Settings["PwdRegExp"].Value;
		PasswordRegValid.ValidationExpression = pwdRegexp;

		//パスワード最大桁数セット
		int pwdMaxLength = Convert.ToInt32(SystemSettings.InputValidationSettings.Settings["PwdMaxLength"].Value);
		Password1Box.MaxLength = pwdMaxLength;

		//パスワード最小桁数
		int pwdMinLength = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		if (pwdMinLength == 0)
			PasswordReqValid.Enabled = false;
	}

	protected void PwdStrengthCusVal_ServerValidate(object source, ServerValidateEventArgs args)
	{
		string pwdStr = args.Value;

		//最小パスワード桁数
		int pwdMinLength = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		if (pwdStr.Length >= pwdMinLength)
			args.IsValid = true;
		else
		{
			args.IsValid = false;
		}
	}
}


