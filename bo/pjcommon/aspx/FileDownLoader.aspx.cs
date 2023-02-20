using System;

using Common.Advanced.Resource;

using Common.Standard.Attribute;
using Common.Standard.Constant;
using Common.Standard.FileLoad;
using Common.Standard.Session;
using Common.Standard.Exception;

namespace Common.Standard.Page
{
	/// <summary>
	/// �t�@�C���_�E�����[�h���i�ł��B
	/// </summary>
	public partial class FileDownLoader : System.Web.UI.Page
	{
		#region �t�B�[���h
		/// <summary>
		/// ���N�G�X�g�v���O����ID�L�[�l
		/// </summary>
		private const String PGID_KEY = "pgid";
		/// <summary>
		/// ���N�G�X�g�t�H�[��ID�L�[�l
		/// </summary>
		private const String FORMID_KEY = "formid";
		/// <summary>
		/// ���\�[�X�^�C�g���o�[�L�[�l
		/// </summary>
		private const String TITLEBAR_KEY = "_Titlebar";
		#endregion

		#region ���\�b�h
		/// <summary>
		/// �y�[�W���[�h
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			//�N�G���p�����[�^���擾����B
			String pgid = Request.QueryString[PGID_KEY];
			String formid = Request.QueryString[FORMID_KEY];

			if (SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session) != null)
			{
				try
				{
					FormResource resource = ResourceFactory.GetFormResource(formid);
					String caption = resource.GetString(formid + TITLEBAR_KEY);

					//�Z�b�V��������t�@�C�������擾
					String downLoadFile = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session);
					//SessionInfoUtil.RemovePgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session);

					//�Z�b�V��������t�@�C���p�X���擾
					String downLoadFolder = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FOLDER, Session);
					String dialog = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_DIALOG, Session);
					//�Z�b�V�����̒l��������
					SessionInfoUtil.SetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FOLDER, null, Session);
					SessionInfoUtil.SetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_DIALOG, null, Session);

					//�_�E�����[�h���������s����B
					if (string.IsNullOrEmpty(downLoadFolder))
					{
						FileManager.Download(downLoadFile, caption);
					}
					else if (string.IsNullOrEmpty(dialog))
					{
						FileManager.Download(downLoadFile, downLoadFolder, caption);
					}
					else
					{
						FileManager.Download(downLoadFile, downLoadFolder, caption, dialog);
					}

				}
				catch (ApplicationErrorException ex)
				{
					//�p���\�ȃG���[�������̉�ʂւ͖߂�Ȃ����ߌp���s�G���[�Ƃ���B
					throw new SystemErrorException(ex.Message, ex);
				}
			}
			else
			{
				//�t�@�C�������݂��Ȃ��ꍇ�A�_�E�����[�h��ʂ��I�����܂��B
				Server.Transfer("../html/windowClose.html");
			}
		}
		#endregion
	}
}