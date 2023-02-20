// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;
using Com.Fujitsu.SmartBase.Base.Common.Util;

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	#region ��L�[�I�u�W�F�N�g

	/// <summary>
	/// �G���e�B�e�BBS_LOGIN_LOG�̎�L�[��\���N���X
	/// </summary>
	[Serializable]
	public class LoginLogKey : IPrimaryKey
	{
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginLogKey()
		{
		}

		/// <summary>
		/// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
		/// </summary>
		/// <param name="login_id">��uLOGIN_ID�v�̒l</param>
		/// <param name="login_datetime">��uLOGIN_DATETIME�v�̒l</param>
		/// <param name="logType">LOG_TYPE</param>
		public LoginLogKey(
			string loginId,
			DateTime? loginDatetime,
			LoginLogType logType)
		{
			this.loginId = loginId;
			this.logDatetime = loginDatetime;
			this.logType = logType;
		}
		#endregion

		#region �t�B�[���h

		/// <summary>
		/// ��uLOGIN_ID(LOGIN_ID)�v�̒l
		/// </summary>
		protected string loginId;
		/// <summary>
		/// ��uLOG_DATETIME(LOG_DATETIME)�v�̒l
		/// </summary>
		protected DateTime? logDatetime;
		/// <summary>
		/// ��uLOG_TYPE(LOG_TYPE)�v�̒l
		/// </summary>
		protected LoginLogType logType;

		#endregion

		#region �v���p�e�B

		/// <summary>
		/// ��uLOGIN_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string LoginID
		{
			get
			{
				return loginId;
			}
			set
			{
				loginId = value;
			}
		}

		/// <summary>
		/// ��uLOG_DATETIME�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public DateTime? LogDatetime
		{
			get
			{
				return logDatetime;
			}
			set
			{
				logDatetime = value;
			}
		}

		/// <summary>
		/// ��uLOG_TYPE�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public LoginLogType LogType
		{
			get
			{
				return logType;
			}
			set
			{
				logType = value;
			}
		}
		#endregion

		#region IPrimaryKey �����o

		/// <summary>
		/// Entity�̎�L�[��̗񖼂ƒl�̃y�A���擾���܂��B
		/// </summary>
		/// <returns>��L�[��/�l�̔z��</returns>
		public KeyValuePair<string, object>[] GetPrimayKeyValues()
		{
			return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("LOGIN_ID",loginId),
				new KeyValuePair<string, object>("LOGIN_DATETIME",logDatetime),
                new KeyValuePair<string, object>("LOG_TYPE",logType)
			};
		}

		#endregion
	}

	#endregion

	#region �G���e�B�e�BVO

	/// <summary>
	///  �G���e�B�e�BBS_LOGIN_LOG�ɑΉ�����ValueObject�ł��B
	/// </summary>
	[Serializable]
	public class LoginLogVO : LoginLogKey
	{
		#region �t�B�[���h

		/// <summary>
		/// ��uOFFLINE_FLAG�v�̒l
		/// ����l�F�I�����C��
		/// </summary>
		private string offlineFlagg = ConstantUtil.ACCESS_ONLINE;

		/// <summary>
		/// ��uIP_ADDRESS(IP_ADDRESS)�v�̒l
		/// </summary>
		private string ipaddress;

		/// <summary>
		/// ��uPC_NAME�v�̒l
		/// </summary>
		private string pcname;

		/// <summary>
		/// ��uSOLUTION_ID�v�̒l
		/// </summary>
		private string solutionid;

		/// <summary>
		/// ��uFUNCTION_ID�v�̒l
		/// </summary>
		private string functionid;

		/// <summary>
		/// ��uFUNCTION_NAME�v�̒l
		/// </summary>
		private string functionname;

		/// <summary>
		/// ��uFUNCTION_URL�v�̒l
		/// </summary>
		private string functionurl;

		#endregion

		#region �v���p�e�B

		/// <summary>
		/// ��uOFFLINE_FLAG�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string OfflineFlag
		{
			get
			{
				return offlineFlagg;
			}
			set
			{
				offlineFlagg = value;
			}
		}

		/// <summary>
		/// ��uIP_ADDRESS�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string IPAddress
		{
			get
			{
				return ipaddress;
			}
			set
			{
				ipaddress = value;
			}
		}

		/// <summary>
		/// ��uPC_NAME�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string PCName
		{
			get
			{
				return pcname;
			}
			set
			{
				pcname = value;
			}
		}

		/// <summary>
		/// ��uSOLUTION_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string SolutionID
		{
			get
			{
				return solutionid;
			}
			set
			{
				solutionid = value;
			}
		}

		/// <summary>
		/// ��uFUNCTION_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string FunctionID
		{
			get
			{
				return functionid;
			}
			set
			{
				functionid = value;
			}
		}

		/// <summary>
		/// ��uFUNCTION_NAME�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string FunctionName
		{
			get
			{
				return functionname;
			}
			set
			{
				functionname = value;
			}
		}

		/// <summary>
		/// ��uFUNCTION_URL�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string FunctionUrl
		{
			get
			{
				return functionurl;
			}
			set
			{
				functionurl = value;
			}
		}

		#endregion

		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginLogVO()
		{
		}

		#endregion

		#region ���\�b�h
		/// <summary>
		/// ���݂�LoginLogVO��\��System.String��Ԃ��܂��B
		/// </summary>
		/// <returns>���݂�LoginLogVO��\��System.String�B</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("login_id:").Append(this.loginId).AppendLine();
			sb.Append("Log_datetime:").Append(this.logDatetime).AppendLine();
			sb.Append("Log_type:").Append(this.logType.ToString()).AppendLine();
			sb.Append("Offline_flag:").Append(this.offlineFlagg.ToString()).AppendLine();
			sb.Append("IP_address:").Append(this.ipaddress.ToString()).AppendLine();
			sb.Append("PC_name:").Append(this.pcname.ToString()).AppendLine();
			sb.Append("Solution_ID:").Append(this.solutionid.ToString()).AppendLine();
			sb.Append("Function_ID:").Append(this.functionid.ToString()).AppendLine();
			sb.Append("Function_Name:").Append(this.functionname.ToString()).AppendLine();
			sb.Append("Function_Url:").Append(this.functionurl.ToString()).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VO�̃R�s�[��Ԃ��܂��B
		/// </summary>
		/// <returns>LoginLogVO</returns>
		public LoginLogVO Copy()
		{
			LoginLogVO vo = new LoginLogVO();
			vo.LoginID = this.LoginID;
			vo.LogDatetime = this.LogDatetime;
			vo.LogType = this.LogType;
			vo.OfflineFlag = this.OfflineFlag;
			vo.IPAddress = this.IPAddress;
			vo.PCName = this.PCName;
			vo.SolutionID = this.SolutionID;
			vo.FunctionID = this.FunctionID;
			vo.FunctionName = this.FunctionName;
			vo.FunctionUrl = this.FunctionUrl;

			return vo;
		}

		#endregion

	}

	#endregion
}

