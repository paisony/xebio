// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT1障害対応[QA-0664]
// 2012/03/24 WT)Banno OT1障害対応[QA-0641]
// 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更

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
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Web.Services.Protocols;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using System.Net;
using System.Collections.Generic;

public partial class Common_Header : System.Web.UI.Page
{

	protected void Page_Load(object sender, EventArgs e)
	{
		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
		LogOutBtn.Visible = true;
		//リソース取得
		FormResource resource = ResourceManager.GetInstance().GetFormResource("Header");
		DateTime date = DateTime.Now;
		DateLbl.Text = date.ToString(resource.GetString("DateString"));
		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  END ---------------
		// --------------- 2012/03/24 WT)Banno OT1障害対応[QA-0641] Add Start ---------------
		HttpContext.Current.Session["SessionErrorCheckDummy"] = "false";
		// --------------- 2012/03/24 WT)Banno OT1障害対応[QA-0641] Add  END ---------------
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
			//クライアントからのＳＳＯはログアウトボタン非表示
			Dictionary<string, string> ssoParams = (Dictionary<string, string>)SessionManager.GetObject("SSOParams", "SSO");
			if (ssoParams != null)
			{
				if (ssoParams.ContainsKey("uniqueness"))
				{
					if (ssoParams["uniqueness"] == "true")
					{
						LogOutBtn.Visible = false;
					}
				}
			}

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("Header");

			#region 挨拶をセット
			DateTime date = DateTime.Now;

			//標題をセットする
			string name = LoginUserContext.Name;

			DateLbl.Text = date.ToString(resource.GetString("DateString"));
			string greeting;
			string title = resource.GetString("Title");

			//あいさつ
			if (date.Hour > 5 && date.Hour < 12)
			{
				greeting = resource.GetString("Morning");
			}
			else if (date.Hour >= 12 && date.Hour < 19)
			{
				greeting = resource.GetString("Afternoon");
			}
			else if (date.Hour >= 19 && date.Hour < 22)
			{
				greeting = resource.GetString("Evening");
			}
			else
			{
				greeting = resource.GetString("Night");
			}

            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            //// イメージ
            //if (date.Hour > 5 && date.Hour < 10)
            //{
            //    HeadImg.ImageUrl = "Images/Header/sunrise.gif";
            //}
            //else if (date.Hour >= 10 && date.Hour < 17)
            //{
            //    HeadImg.ImageUrl = "Images/Header/sun.gif";
            //}
            //else if (date.Hour >= 17 && date.Hour < 19)
            //{
            //    HeadImg.ImageUrl = "Images/Header/sunset.gif";
            //}
            //else
            //{
            //    HeadImg.ImageUrl = "Images/Header/moon.gif";
            //}
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

			UserNameLbl.Text = greeting + name + title;
			#endregion

			#region ポータルマイレージを表示
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
			// マイレージポイントの表示
            //string portalWsMode = ConfigurationManager.AppSettings["PortalWsMode"];
            //string comId = LoginUserContext.CompanyId;
            //string loginId = LoginUserContext.LoginId;

            //if (portalWsMode.ToLower() == "true"
            //    && !string.IsNullOrEmpty(comId)
            //    && !string.IsNullOrEmpty(loginId))
            //{
            //    Portal.PortalWS ws = new Portal.PortalWS();
            //    long point = 0;
            //    try
            //    {
            //        point = ws.GetMilegiPoint(LoginUserContext.CompanyId, LoginUserContext.LoginId);
            //        if (point >= 0)
            //        {
            //            string mileageStr = resource.GetString("Mileage");
            //            string pointStr = resource.GetString("Point");
            //            MileageLbl.Text = mileageStr + point + pointStr;
            //        }
            //        else
            //            MileageLbl.Visible = false;
            //    }
            //    catch (SoapException)
            //    {
            //        MileageLbl.Visible = false;
            //    }
            //}
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

			#endregion

			#region ロゴのリンク制御

			//仮パスワード、本パスワードでパスワード期限切れの
			//ログイン者はロゴのリンクを押下不可にする

			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			LoginUserService loginUserService = new LoginUserService(infoVO);

			LoginUserKey key = new LoginUserKey(LoginUserContext.LoginId);
			DataResult<DataTable> res = loginUserService.GetLoginUserData(key);

			DateTime pwdUpdateDT = Convert.ToDateTime(res.ResultData.Rows[0]["PASSWORD_UPDATE_DATETIME"]);

			bool needTemporaryPwdUpdate = Convert.ToBoolean(SystemSettings.SecuritySettings.Settings["NeedTemporaryPwdUpdate"].Value);
			//仮パスワードで初回パスワード変更が必要な場合はリンクを無効
			if (needTemporaryPwdUpdate && Convert.ToString(res.ResultData.Rows[0]["TEMP_PASSWORD_FLAG"]) == "1")
			{
				//ReloadLink.Enabled = false;
				return;
			}

			//パスワード有効期間を過ぎている場合はリンクを無効
			if (PasswordCheckUtil.CheckPwdValid(pwdUpdateDT) == 3)
			{
				//ReloadLink.Enabled = false;
			}

			DataBind();
			#endregion
		}
	}

	protected void LogOutBtn_Click(object sender, ImageClickEventArgs e)
	{
		if ("1".Equals(this.CANCEL.Text)) return;
		//ログアウト処理
		CertificationService service = new CertificationService();

		//ユーザ情報の取得
		//ログインIDはモデル層でセット
		ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);

		service.Logout(LoginUserContext.LoginInfoId, LoginLogType.Logout, infoVo);

		SessionManager.SessionRemoveAll();

		if (!"9".Equals(this.END.Text))
		{
			//ログイン画面制御用情報の書込み
			HttpContext.Current.Session[WebConstantUtil.LOGIN_INITIAL_OFF_SESSION_KEY] = "true";
			Response.Redirect("Login.aspx");
		}
	}

}
