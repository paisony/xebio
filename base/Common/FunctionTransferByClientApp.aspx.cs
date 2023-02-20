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
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;

public partial class Common_FunctionTransferByClientApp : System.Web.UI.Page
{
	protected string mainWindowName;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string solutionId = Request.Params["solutionId"];
			string functionId = Request.Params["functionId"];
			string certId = Request.Params["certId"];
			mainWindowName = Request.Params["win"];

			#region 認証

			CertificationService service = new CertificationService();
			//ログイン情報取得
			DataResult<DataTable> infoRes = service.GetLoginInfoByCertId(certId);
			if (!infoRes.IsSuccess)
				throw new ApplicationException("ログイン情報取得に失敗しました。");
			if (infoRes.ResultData.Rows.Count == 0)
				throw new ApplicationException("ログイン情報が存在しません。");

			string loginInfoId = Convert.ToString(infoRes.ResultData.Rows[0]["LOGIN_INFO_ID"]);
			string loginId = Convert.ToString(infoRes.ResultData.Rows[0]["LOGIN_ID"]);


			//認証(CERT_ID)
			DataResult<string> certRes = service.Certify(loginId, certId, ConstantUtil.BASE_SOLUTION_ID);
			if (!certRes.IsSuccess)
				throw new ApplicationException("認証に失敗しました。");

			//セッションがあるかチェックする。
			if (!string.IsNullOrEmpty(LoginUserContext.LoginInfoId))
			{
				//CERT_IDのLOGIN_INFO_IDと同一か異なる場合は削除し作成し直す。
				if (loginInfoId != LoginUserContext.LoginInfoId)
				{
					//削除
					LoginUserContext.Clear();
					//作成し直す。
					SetLoginUserContextInfo(loginInfoId, loginId);
				}
			}
			else
			{
				//セッションにログイン情報がないので作成する。
				SetLoginUserContextInfo(loginInfoId, loginId);
			}

			#endregion

			//Sessionに格納
			Dictionary<string, string> ssoParams = new Dictionary<string, string>();
			ssoParams.Add("solutionId", solutionId);
			ssoParams.Add("functionId", functionId);
			ssoParams.Add("uniqueness", "true");
			SessionManager.SetObject(ssoParams, "SSOParams", "SSO");

			this.DataBind();
		}
	}

	/// <summary>
	/// セッションにログイン情報を格納します。
	/// </summary>
	private void SetLoginUserContextInfo(string loginInfoId, string loginId)
	{
		LoginUserInfoVO info = new LoginUserInfoVO();
		info.LoginId = loginId;
		LoginUserService service = new LoginUserService(info);
		LoginUserKey key = new LoginUserKey(loginId);
		DataResult<DataTable> res = service.GetLoginUserData(key);
		if (res.IsSuccess && res.ResultData.Rows.Count > 0)
		{
			LoginUserContext.Password = Convert.ToString(res.ResultData.Rows[0]["PASSWORD"]);
			LoginUserContext.LoginInfoId = loginInfoId;
			LoginUserContext.LoginId = loginId;
			LoginUserContext.Language = SystemSettings.DefaultLanguage;
			LoginMst.SetLoginInfo(loginId);
		}
		else
			throw new ApplicationException("利用者情報取得に失敗しました。");
	}
}
