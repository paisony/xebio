// ログイン・メニュー画面変更

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
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Xml;
using System.IO;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Net;
using System.Reflection;
using System.Text;


public partial class Common_Login : System.Web.UI.Page
{

	protected void Page_Load(object sender, EventArgs e)
	{
		//エラーラベルの初期化
		ErrorLbl.Visible = false;

		//ログイン情報設定
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_WIDTH_SIZE].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_WIDTH_SIZE];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_HEIGHT_SIZE].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_HEIGHT_SIZE];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_POSITIONING].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_POSITIONING];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_TOP_POSITION_ASJUSTMENT].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_TOP_POSITION_ASJUSTMENT];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_POSITION_TOP].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_POSITION_TOP];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_POSITION_LEFT].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_POSITION_LEFT];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_SYSTEM_NAME].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_SYSTEM_NAME];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGOFF_WINDOW_CHECK].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_WINDOW_CHECK];
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGOFF_FORCE_QUIT].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_FORCE_QUIT];

		// --------------- 2016/10/17 FE)Y.Kawabuchi Add START ---------------
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGOFF_CLOSING_FUNCTION_IDS].Value
											= ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_CLOSING_FUNCTION_IDS];
		// --------------- 2016/10/17 FE)Y.Kawabuchi Add END ---------------
		
		
		if (!Page.IsPostBack)
		{
			//トップ画面情報をセット
			this.SetDisplayContent();
			//しばらくお待ち下さい画面を表示
			if ("XO999P01".Equals(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID]))
			{
				DataRow funcRow = FunctionMst.GetFunction("XO010P01");
				if (funcRow != null)
				{
					HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_SOLUTION_ID].Value = (string)funcRow[0];
					HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_FUNCTION_ID].Value
														= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID];
				}
			}
		}

		Page.SetFocus(LoginIDBox);
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
			#region 標題セット

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("Login");

			LoginIDLbl.Text = resource.GetString("LoginIDLbl");
			PasswordLbl.Text = resource.GetString("PasswordLbl");
			ErrorLbl.Text = resource.GetString("LoginValid");
			if (Request.Params["check"] != "ok")
			{
				if (HttpContext.Current.Session[WebConstantUtil.LOGIN_INITIAL_OFF_SESSION_KEY] == null)
				{
					Response.Redirect("login.html");
				}
				else
				{
					HttpContext.Current.Session.Remove(WebConstantUtil.LOGIN_INITIAL_OFF_SESSION_KEY);
				}
            }
			else
			{
				HttpContext.Current.Session.Remove(WebConstantUtil.LOGIN_INITIAL_OFF_SESSION_KEY);
			}
			#endregion
		}
	}

	/// <summary>
	/// ログインボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void LoginBtn_Click(object sender, EventArgs e)
	{
		//クライアント情報が格納されたvoを取得
		ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
		infoVo.LoginId = LoginIDBox.Text;

		//パスワードを大文字化
		bool pwdUpperType = false;
		string passwordUpper = PasswordBox.Text;
		try
		{
			pwdUpperType = Convert.ToBoolean(SystemSettings.SecuritySettings.Settings["PwdUpperType"].Value);
		}
		catch (Exception)
		{
			pwdUpperType = false;
		}
		if (pwdUpperType && !infoVo.LoginId.Equals("smartmgr"))
		{
			passwordUpper = PasswordBox.Text.ToUpper();
		}
		//ログインチェック
		if (!this.IsLoginValid(infoVo, passwordUpper)) return;

		#region ログイン

		//ログイン者情報をセット
		this.SetLoginUserContextInfo();

		//FUNCTIONからデータ取得
		HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_FUNCTION_ID].Value = null;
		if (LoginUserContext.MenuPtnCd != null)
		{
			if (LoginUserContext.MappingId == null || !"9".Equals(LoginUserContext.MappingId))
			{
				if (!"XO999P01".Equals(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID]))
				{
					DataRow funcRow = FunctionMst.GetFunction(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID]);
					try
					{
						LoginUserInfoVO loginInfo = new LoginUserInfoVO();
						RoleService rolesv = new RoleService(loginInfo);
						DataResult<DataTable> funcRes = rolesv.GetFunctionAuthorization2(LoginUserContext.MenuPtnCd
													, (string)funcRow[0], ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID]);
						if (funcRes.ResultData.Rows.Count > 0)
						{
							HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_SOLUTION_ID].Value = (string)funcRow[0];
							HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_FUNCTION_ID].Value
															= ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_FUNCTION_ID];
						}
					}
					catch (NullReferenceException)
					{
					}
				}
				// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update START ---------------
				try
				{
					if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_FUNCTION_ID]))
					{
						DataRow funcRowOff = FunctionMst.GetFunction(ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_FUNCTION_ID]);
						HttpContext.Current.Response.Cookies[WebConstantUtil.LOGIN_SOLUTION_ID].Value = Convert.ToString(funcRowOff["SOLUTION_ID"]);
						HttpContext.Current.Response.Cookies[WebConstantUtil.LOGOFF_FUNCTION_ID].Value
															= ConfigurationManager.AppSettings[WebConstantUtil.LOGOFF_FUNCTION_ID];
						HttpContext.Current.Response.Cookies["loginId"].Value = LoginUserContext.LoginId;
						HttpContext.Current.Response.Cookies["comId"].Value = LoginUserContext.CompanyId;
						HttpContext.Current.Response.Cookies["functionUrl"].Value = Convert.ToString(funcRowOff["FUNCTION_URL"]);
					}
				}
				catch (Exception)
				{
				}
				// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update  END  ---------------
			}
		}

		//ログイン情報登録
		CertificationService service = new CertificationService();
		DataResult<string> result = service.Login(infoVo, SystemSettings.DefaultLanguage, Request.Url.ToString());
		if (result.IsSuccess)
		{
			//ログイン失敗カウントをリセット
			this.ResetLoginFailureHistory(infoVo);
			//ログイン者情報にログイン情報ＩＤをセット
			LoginUserContext.LoginInfoId = result.ResultData;
			//画面遷移先チェック
			this.RedirectPage(LoginUserContext.LoginId);
			return;
		}
		else if (result.HasError)
		{
			//二重ログイン
			if (result.Errors[0].ErrorCode == CertificationErrorCode.DUPLICATION_LOGIN_ERROR)
			{
				//MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
				//string message = resource.GetString(result.Errors[0].ErrorCode);
				//CompulsoryLoginBtn
				string script = @"<script language=JavaScript>DuplicationLoginError();</script>";
				Page.ClientScript.RegisterStartupScript(typeof(string), "loginDupulication", script);
				return;
			}
			else
			{
				LoginUserContext.Clear();
				throw new ApplicationException("ログイン処理に失敗しました。");
			}
		}
		else
		{
			LoginUserContext.Clear();
			throw new ApplicationException("ログイン処理に失敗しました。");
		}

		#endregion
	}

	/// <summary>
	/// 確認メッセージダイアログのＯＫボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CompulsoryLoginBtn_Click(object sender, EventArgs e)
	{
		//クライアント情報が格納されたvoを取得
		ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
		infoVo.LoginId = LoginUserContext.LoginId;

		//ID/PWチェック
		if (!this.IsLoginValid(infoVo, LoginUserContext.Password)) return;

		#region 強制ログイン

		//ログイン者情報をセット
		this.SetLoginUserContextInfo();


		//ログイン情報登録
		CertificationService service = new CertificationService();
		DataResult<string> result = service.CompulsoryLogin(infoVo, SystemSettings.DefaultLanguage, Request.Url.ToString());

		if (result.IsSuccess)
		{
			//ログイン失敗カウントをリセット
			this.ResetLoginFailureHistory(infoVo);
			//ログイン者情報にログイン情報ＩＤをセット
			LoginUserContext.LoginInfoId = result.ResultData;
			//画面遷移先チェック
			this.RedirectPage(LoginUserContext.LoginId);
			return;
		}
		else
		{
			LoginUserContext.Clear();
			throw new ApplicationException("ログイン処理に失敗しました。");
		}

		#endregion
	}

	#region private

	/// <summary>
	/// LoginUserInfoVOに情報を詰めて返します。
	/// LoginInfoId以外を詰めて返します。
	/// </summary>
	/// <returns>LoginUserInfoVO</returns>
	private void SetLoginUserContextInfo()
	{
		LoginUserContext.Language = SystemSettings.DefaultLanguage;

		LoginMst.SetLoginInfo(LoginIDBox.Text);
	}

	/// <summary>
	/// トップ画面情報をセットします。
	/// </summary>
	/// <exception cref="ApplicationException">モデル層でエラーが発生した場合</exception>
	private void SetDisplayContent()
	{
		try
		{
			LoginUserInfoVO loginInfo = new LoginUserInfoVO();
			loginInfo.LoginId = LoginUserContext.LoginId;
			InformationService service = new InformationService(loginInfo);
			DataResult<DataTable> res = service.GetAllTopDisplay(true, LoginUserContext.LoginId);
			//データの取得に失敗した場合は終了する。
			if (!res.IsSuccess) return;
			//トップ画面情報が取得できない場合、または複数件取得した場合は何も表示しない。
			if (res.ResultData.Rows.Count != 1) return;

			DisplayContentLbl.Text = Convert.ToString(res.ResultData.Rows[0]["DISPLAY_CONTENT"]);
		}
		catch (ModelException e)
		{
			Console.WriteLine(e.Message);
			throw new ApplicationException("DB接続中にエラーが発生しました。");
		}
	}


	#endregion

	/// <summary>
	/// ログインID、パスワードチェック
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	/// <param name="loginId">ログインID</param>
	/// <param name="password">パスワード</param>
	/// <exception cref="ApplicationException">モデル層からのエラー</exception>
	protected bool IsLoginValid(ExLoginUserInfoVO infoVo, string password)
	{
		Result res;

		//画面で入力されたログインIDでログイン可能であるかチェック
		res = LoginMst.CheckLoginAvailable(infoVo, password, null);
		//エラー処理
		if (!res.IsSuccess)
		{
			if (res.HasError)
			{
				// 排他エラー.ビジネスロジックエラー
				MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
				ErrorLbl.Text = resource.GetString(res.Errors[0].ErrorCode);
				ErrorLbl.Visible = true;
			}
			else
			{
				throw new ApplicationException("ログイン認証中にエラーが発生しました。");
			}
		}

		LoginUserContext.Clear();

		if (res.IsSuccess)
		{
			LoginUserContext.LoginId = infoVo.LoginId;
			LoginUserContext.Password = password;

			//ＭＤシステムオンラインが動作中かチェック
			Boolean result = LoginMst.CheckLoginAvailableOnline(infoVo);
			//エラー処理
			if (!result)
			{
				ErrorLbl.Text = "オンラインが停止中です。";
				ErrorLbl.Visible = true;
				return false;
			}
		}

		return res.IsSuccess;
	}



	/// <summary>
	/// 強制ログインキャンセル
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CancelLoginBtn_Click(object sender, EventArgs e)
	{
		//Sessionクリア
		LoginUserContext.Clear();
	}

	#region privateメソッド

	private void ResetLoginFailureHistory(LoginUserInfoVO vo)
	{
		LoginUserService service = new LoginUserService(vo);
		service.ResetLoginFailureHistory(vo);
	}

	/// <summary>
	/// ログイン者のパスワード状態に応じて遷移先を変更します。
	/// </summary>
	/// <remarks>
	/// 遷移先変更条件
	/// 〔通常画面(Main.aspx)へ遷移〕
	/// ・本パスワードでパスワード有効期間内(パスワード変更警告期間を除く)
	/// 〔強制パスワード変更画面へ遷移〕
	/// ・仮パスワード
	/// ・本パスワードでパスワード変更警告期間
	/// ・本パスワードでパスワード有効期間切れ
	/// </remarks>
	/// <exception cref="ArgumentException">引数が未入力</exception>
	/// <exception cref="ApplicationException">利用者情報の取得に失敗</exception>
	/// <param name="loginId">ログインID</param>
	private void RedirectPage(string loginId)
	{
		//仮パスワードフラグ
		string tempPwdFlag;
		//パスワード変更日時
		DateTime pwdUpdateDT;

		if (string.IsNullOrEmpty(loginId)) throw new ArgumentException("ログインIDが取得できません");
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = loginId;
		LoginUserService service = new LoginUserService(infoVO);

		DataResult<DataTable> res = service.GetLoginUserData(new LoginUserKey(loginId));

		//利用者情報取得に失敗
		if (!res.IsSuccess)
		{
			throw new ApplicationException("利用者情報の取得に失敗しました。");
		}

		//利用者情報からパスワード関連情報を取得
		if (res.ResultData.Rows.Count > 0)
		{
			//パスワード更新日時
			pwdUpdateDT = Convert.ToDateTime(res.ResultData.Rows[0]["PASSWORD_UPDATE_DATETIME"]);
			//仮パスワードフラグ
			tempPwdFlag = Convert.ToString(res.ResultData.Rows[0]["TEMP_PASSWORD_FLAG"]);
		}
		else
		{
			throw new ApplicationException("利用者情報の取得に失敗しました。");
		}

		//仮パスワードフラグチェック
		if (tempPwdFlag == WebConstantUtil.TEMP_PASSWORD_FLAG_OFF)
		{
			//本パスワード
			if (PasswordCheckUtil.CheckPwdValid(pwdUpdateDT) == 1)
			{
				if (SessionManager.GetObject("SSOParams", "SSO") == null)
					// パスワード有効期間内(パスワード変更警告期間を除く)
					Response.Redirect("Main.aspx");
				else
					//機能遷移ページへ遷移
					Response.Redirect("Main.aspx");
			}
			else
			{
				Response.Redirect("PwdCompulsoryChange.html");
			}

		}
		else
		{
			bool needTemporaryPwdUpdate = Convert.ToBoolean(SystemSettings.SecuritySettings.Settings["NeedTemporaryPwdUpdate"].Value);

			if (needTemporaryPwdUpdate)
				Response.Redirect("PwdCompulsoryChange.html");
			else
				Response.Redirect("Main.aspx");
		}
	}

	#endregion
}
