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
using Com.Fujitsu.SmartBase.Library.Log;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Certification;
using System.Web.Services.Protocols;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Net;
using System.Text;

public partial class SystemError : System.Web.UI.Page
{
	/// <summary>
	/// ログ出力
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();
	/// <summary>
	/// 例外を取得し、エラー表示をします。
	/// この画面はGlobal.asaxからServer.Transferでアクセスされます。
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			logger.Error("システムエラー画面が表示されました。---------------");
			if (Server.GetLastError() != null)
			{
				Exception ex;
				if (Server.GetLastError().InnerException != null && !(Server.GetLastError().InnerException is SoapException))
				{
					ex = Server.GetLastError().InnerException;
				}
				else
				{
					ex = Server.GetLastError();
				}
				if (ex != null)
				{
					logger.Error("例外：", ex);
					ExceptionName.Text = ex.GetType().FullName;
					ExceptionMessage.Text = ex.Message;
				}
			}
			try
			{
				if (!string.IsNullOrEmpty(LoginUserContext.LoginInfoId))
				{
					logger.Info("強制ログアウト処理：" + LoginUserContext.LoginInfoId);
					//ログアウト処理
					CertificationService service = new CertificationService();

					//クライアントPC情報のセット(ログインIDはモデル層でセット)
					ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
					service.Logout(LoginUserContext.LoginInfoId, LoginLogType.CompulsoryLogout, infoVo);
				}
			}
			catch (Exception ex)
			{
				logger.Error("強制ログアウト処理中にエラーが発生しました。", ex);
			}
			//セッション情報全削除
			SessionManager.SessionRemoveAll();
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
			#region リソースをセット
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("SystemError");
			//標題をセットする
			ErrorTitleLbl.Text = resource.GetString("ErrorTitleLbl");
			ErrorLbl.Text = resource.GetString("ErrorLbl");
			MessageLbl.Text = resource.GetString("MessageLbl");
			CloseBtn.Text = resource.GetString("CloseBtn");
			#endregion
		}
	}
	protected void Page_Error(object sender, EventArgs e)
	{
		Server.ClearError();
		Response.Write("例外が発生しました。");
		Response.End();
	}
	protected void CloseBtn_Click(object sender, EventArgs e)
	{
		StringBuilder script = new StringBuilder();
		script.Append("<script language=JavaScript>");
		script.Append(" window.close();");
		script.Append("</script>");
		Page.ClientScript.RegisterStartupScript(typeof(string), "winodwclose", script.ToString());
	}
}

