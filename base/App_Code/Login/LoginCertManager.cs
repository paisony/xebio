// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Certification;
using System.Timers;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Library.Log;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Config;

/// <summary>
/// LoginCertManager の概要の説明です
/// </summary>
public class LoginCertManager
{
	/// <summary>
	/// ログ出力
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();


	public LoginCertManager()
	{
	}

	/// <summary>
	/// タイムアウト認証情報をチェックし、削除する
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public void CheckInvalidSession(object sender, ElapsedEventArgs e)
	{
		CertificationService service = new CertificationService();
		service.CheckTimeOut();
	}

	public static void CertBaseLoginInfo()
	{
		//認証の除外
		HttpRequest request = HttpContext.Current.Request;
		HttpResponse response = HttpContext.Current.Response;

		string debug = (string)request["debug"];
		string debug2 = (string)request["debug2"];
		if (!string.IsNullOrEmpty(debug))
		{
			//クライアント情報が格納されたvoを取得
			ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(request.ServerVariables);
			infoVo.LoginId = request["loginId"];
			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			LoginUserContext.LoginId = infoVo.LoginId;
			//ログイン者情報をセット
			LoginMst.SetLoginInfo(infoVo.LoginId);
			//ログイン情報登録
			CertificationService service = new CertificationService();
			DataResult<string> result = service.CompulsoryLogin(infoVo, SystemSettings.DefaultLanguage, null);
			LoginUserContext.LoginInfoId = result.ResultData;
		}
		if (!string.IsNullOrEmpty(debug2))
		{
			//クライアント情報が格納されたvoを取得
			ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(request.ServerVariables);
			infoVo.LoginId = request["loginId"];
			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			LoginUserContext.LoginId = infoVo.LoginId;
			LoginUserContext.LoginInfoId = request["LoginInfoId"];
			//ログイン者情報をセット
			LoginMst.SetLoginInfo(infoVo.LoginId);
		}

		//WebResource.axd,ログイン画面,エラー画面
        //2015/09/16 FSWeb)Y.Tamura ログイン画面デザイン変更対応（index.aspxを条件に追加）
		//string page = request.Url.Segments[request.Url.Segments.Length - 1].ToLower();
		string page = request.AppRelativeCurrentExecutionFilePath.ToLower();
		if ((page == "~/common/login.aspx") ||
			(page == "~/common/error/timeout.aspx") ||
			(page == "~/common/error/systemerror.aspx") ||
			(page == "~/common/error/initialerror.aspx") ||
			(page == "~/common/functiontransfer.aspx") ||
			(page == "~/common/functiontransferbyclientapp.aspx") ||
			(page == "~/common/pagetransfer.aspx") ||
			(page == "~/master/loginuser01.aspx") ||
			(page == "~/webresource.axd") ||
			(page == "~/ws/loginws.asmx") ||
			(page == "~/common/confirm.aspx") ||
			(page == "~/xo000p01/xo000p01init.aspx") ||
			(page == "~/xo999p01/xo999p01init.aspx") ||
            (page == "~/common/index.aspx")
			)
		{
			return;
		}

		if (!string.IsNullOrEmpty(LoginUserContext.LoginInfoId))
		{
			CertificationService service = new CertificationService();
			Result res = service.CertifyByLoginInfoID(LoginUserContext.LoginInfoId);
			if (!res.IsSuccess)
			{
				if (res.HasError && res.Errors[0].ErrorCode == CertificationErrorCode.BASE_CERT_ERROR)
				{
					logger.Warn(string.Format("セッションタイムアウト。認証に失敗しました。ログインID:{0} LoginInfoId：{1}", LoginUserContext.LoginId, LoginUserContext.LoginInfoId));
					//セッションタイムアウトページに遷移
					response.Redirect("../Common/Error/TimeOut.aspx");
				}
				else
				{
					throw new ApplicationException("認証時にエラーが発生しました。");
				}
			}
		}
		else
		{
			logger.Warn("セッションタイムアウト。セッションからログインIDが取得できません。");
			//セッションタイムアウトページに遷移
			response.Redirect("./Common/Error/TimeOut.aspx");
		}
	}

	public static void CheckUrlAccess()
	{
		HttpRequest Request = HttpContext.Current.Request;

		//特殊なページ
        //2015/09/16 FSWeb)Y.Tamura ログイン画面デザイン変更対応（index.aspxを条件に追加）
		if ((Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/login.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/main.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/header.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/menutransfer.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/pagetransfer.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/error/timeout.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/error/systemerror.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/error/initialerror.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/webresource.axd") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/bizmenu.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/menulink.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/messagepreview.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/functiontransfer.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/confirm.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/functiontransferbyclientapp.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/ws/loginws.asmx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/xo999p01/xo999p01init.aspx") ||
			(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/xo000p01/xo000p01init.aspx") ||
            (Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/index.aspx"))
		{
			if ((Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/pagetransfer.aspx") ||
				(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/login.aspx") ||
				(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/functiontransfer.aspx") ||
				(Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/functiontransferbyclientapp.aspx"))
			{
				//遷移先URLのホスト、アプリ、機能を更新
				PageUrlContext.Url = Request.AppRelativeCurrentExecutionFilePath.ToLower();
				PageUrlContext.Host = Request.Url.Host.ToLower();
				PageUrlContext.Application = Request.Url.Segments[Request.Url.Segments.Length - 3].ToLower();
				PageUrlContext.Function = Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower();
				PageUrlContext.PageName = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
			}
			return;
		}
		else
		{
			#region 不正アクセスチェック
			//PageTransfer.aspxから、または同機能内遷移する場合
			if (PageUrlContext.Url.EndsWith("/common/pagetransfer.aspx") ||
				PageUrlContext.Url.EndsWith("/common/functiontransfer.aspx") ||
				PageUrlContext.Url.EndsWith("/common/pwdcompulsorychange.html") ||
				PageUrlContext.Function == Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower())
			{
				if (PageUrlContext.Url.EndsWith("/master/passwordchange.aspx")
					&& Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower() == "master/"
					&& Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower() != "passwordchange.aspx")
				{
					throw new ApplicationException("不正アクセスを検出しました。");
				}
				//遷移先URLのホスト、アプリ、機能を更新
				PageUrlContext.Url = Request.AppRelativeCurrentExecutionFilePath.ToLower();
				PageUrlContext.Host = Request.Url.Host.ToLower();
				PageUrlContext.Application = Request.Url.Segments[Request.Url.Segments.Length - 3].ToLower();
				PageUrlContext.Function = Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower();
				PageUrlContext.PageName = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
				return;
			}
			else
			{
				//パスワード変更画面からMain画面に遷移する場合
				if ((PageUrlContext.Url.EndsWith("/master/passwordchange.aspx")) &&
					Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/common/main.aspx")
				{
					//遷移先URLのホスト、アプリ、機能を更新
					PageUrlContext.Url = Request.AppRelativeCurrentExecutionFilePath.ToLower();
					PageUrlContext.Host = Request.Url.Host.ToLower();
					PageUrlContext.Application = Request.Url.Segments[Request.Url.Segments.Length - 3].ToLower();
					PageUrlContext.Function = Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower();
					PageUrlContext.PageName = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
					return;
				}
				else
				{
					//ログイン画面からパスワード変更画面に遷移する場合
					if (PageUrlContext.Url.EndsWith("/common/login.aspx") &&
						Request.AppRelativeCurrentExecutionFilePath.ToLower() == "~/master/passwordchange.aspx")
					{
						//遷移先URLのホスト、アプリ、機能を更新
						PageUrlContext.Url = Request.AppRelativeCurrentExecutionFilePath.ToLower();
						PageUrlContext.Host = Request.Url.Host.ToLower();
						PageUrlContext.Application = Request.Url.Segments[Request.Url.Segments.Length - 3].ToLower();
						PageUrlContext.Function = Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower();
						PageUrlContext.PageName = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
						return;
					}
					else
					{
						if (Request.AppRelativeCurrentExecutionFilePath.ToLower() != "~/master/loginuser01.aspx")
						{
							logger.Error("PageUrlContext.Function:" + PageUrlContext.Function);
							logger.Error("Request.Url.Segments[] :" + Request.Url.Segments[Request.Url.Segments.Length - 2].ToLower());
							throw new ApplicationException("不正アクセスを検出しました。" + Request.AppRelativeCurrentExecutionFilePath);
						}
					}
				}
			}
			#endregion
		}
	}
}
