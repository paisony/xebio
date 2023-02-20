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
	/// ���O�o��
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();
	/// <summary>
	/// ��O���擾���A�G���[�\�������܂��B
	/// ���̉�ʂ�Global.asax����Server.Transfer�ŃA�N�Z�X����܂��B
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			logger.Error("�V�X�e���G���[��ʂ��\������܂����B---------------");
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
					logger.Error("��O�F", ex);
					ExceptionName.Text = ex.GetType().FullName;
					ExceptionMessage.Text = ex.Message;
				}
			}
			try
			{
				if (!string.IsNullOrEmpty(LoginUserContext.LoginInfoId))
				{
					logger.Info("�������O�A�E�g�����F" + LoginUserContext.LoginInfoId);
					//���O�A�E�g����
					CertificationService service = new CertificationService();

					//�N���C�A���gPC���̃Z�b�g(���O�C��ID�̓��f���w�ŃZ�b�g)
					ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
					service.Logout(LoginUserContext.LoginInfoId, LoginLogType.CompulsoryLogout, infoVo);
				}
			}
			catch (Exception ex)
			{
				logger.Error("�������O�A�E�g�������ɃG���[���������܂����B", ex);
			}
			//�Z�b�V�������S�폜
			SessionManager.SessionRemoveAll();
		}
	}
	/// <summary>
	/// �t�H�[���̃f�[�^��\������B
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region ���\�[�X���Z�b�g
			//���\�[�X�擾
			FormResource resource = ResourceManager.GetInstance().GetFormResource("SystemError");
			//�W����Z�b�g����
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
		Response.Write("��O���������܂����B");
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

