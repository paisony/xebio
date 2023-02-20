using System;

using Common.Standard.Attribute;
using Common.Standard.Message;
using System.Web;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using Common.Advanced.Model.Context;
using Common.Standard.Model.Data;
using Common.Advanced.Model.Data;
using System.Collections;
using Common.Standard.Constant;

namespace Common.Standard.Page
{
	/// <summary>
	/// �Ɩ��G���[��ʂ̃R�[�h�r�n�C���h�N���X�ł��B
	/// </summary>
	public partial class ApplicationError : System.Web.UI.Page
	{
		#region ���\�b�h
		/// <summary>
		/// ��O���擾���A�G���[�\�������܂��B
		/// ���̉�ʂ�Global.asax����Server.Transfer�ŃA�N�Z�X����܂��B
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Server.GetLastError() != null)
				{
					System.Exception ex;
					if (Server.GetLastError().InnerException != null)
					{
						ex = Server.GetLastError().InnerException;
					}
					else
					{
						ex = Server.GetLastError();
					}
					if (ex != null)
					{
						//ExceptionName.Text = ex.GetType().FullName;
						ExceptionMessage.Text = ex.Message;
					}
				}
			}
		}

		/// <summary>
		/// �y�[�W�G���[�������s���܂��B
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Error(object sender, EventArgs e)
		{
			Server.ClearError();
			StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
			Response.Write(Server.HtmlEncode(messageMgr.GetString("Y970")));
			Response.End();
		}

		#region �W���ݒ肵�܂��B
		/// <summary>
		/// �W���ݒ肵�܂��B
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected void RenderForm(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();
				//�E�B���h�E�^�C�g��(�Ɩ��G���[)
				this.Windowtitle.Text = Server.HtmlEncode(captionMgr.GetString("C994"));
				//�W��(���b�Z�[�W)
				this.Message.Text = Server.HtmlEncode(captionMgr.GetString("C997"));
				//�{�^���W��(����)
				this.CloseBtn.Value = captionMgr.GetString("C987");

				StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
				//���b�Z�[�W(�Ɩ��G���[���������܂����B)
				this.ErrorMessage.Text = Server.HtmlEncode(messageMgr.GetString("Y971"));
			}

			//�r���@�\���O�폜
			string programid = "";
			try
			{
				programid = (string)HttpContext.Current.Session[MdSystemConstant.MD_SYSTEM_ERROR_PGM_ID];
			}
			catch (System.Exception)
			{
			}
			if (!string.IsNullOrEmpty(programid))
			{
				Hashtable ht = (Hashtable)HttpContext.Current.Session[SessionKeyConstant.GetPgSessionKey(programid)];
				if (ht != null)
				{
					if (Convert.ToBoolean(ht[SessionKeyConstant.EXCLUSION_PROGRAM + programid.ToUpper()]))
					{
						//DB�R���e�L�X�g���擾���܂��B
						IDBContext dbcontext2 = StandardDBContextFactory.CreateDbContext();
						try
						{
							//�R�l�N�V�����J�n
							dbcontext2.OpenConnection();
							//�@�\�r�����O�o��
							if (HttpContext.Current.Session != null && HttpContext.Current.Session[MdSystemConstant.MD_SYSTEM_ERROR_PGM_ID] != null)
							{
								ExclusionUtil.DeleteExclusionLog(dbcontext2, programid, null);
							}
						}
						catch (DBException)
						{
						}
						finally
						{
							if (dbcontext2 != null)
							{
								//�R�l�N�V�����N���[�Y
								dbcontext2.CloseConnection();
							}
						}
					}
				}
			}
		}
		#endregion
		#endregion
	}
}