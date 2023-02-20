// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	#region ��L�[�I�u�W�F�N�g

	/// <summary>
	/// �G���e�B�e�BBS_LOGIN_INFO�̎�L�[��\���N���X
	/// </summary>
	[Serializable]
	public class LoginInfoKey : IPrimaryKey
	{
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginInfoKey()
		{
		}

		/// <summary>
		/// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
		/// </summary>
		/// <param name="loginInfoId">��uLOGIN_INFO_ID�v�̒l</param>
		public LoginInfoKey(
			string loginInfoId)
		{
			this.loginInfoId = loginInfoId;
		}
		#endregion

		#region �t�B�[���h
		/// <summary>
		/// ��uLOGIN_INFO_ID(LOGIN_INFO_ID)�v�̒l
		/// </summary>
		protected string loginInfoId;
		#endregion

		#region �v���p�e�B
		/// <summary>
		/// ��uLOGIN_INFO_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string LoginInfoId
		{
			get
			{
				return loginInfoId;
			}
			set
			{
				loginInfoId = value;
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
				new KeyValuePair<string, object>("LOGIN_INFO_ID",loginInfoId)
			};
		}

		#endregion
	}

	#endregion

	#region �G���e�B�e�BVO

	/// <summary>
	///  �G���e�B�e�BBS_LOGIN_INFO�ɑΉ�����ValueObject�ł��B
	/// </summary>
	[Serializable]
	public class LoginInfoVO : LoginInfoKey
	{
		#region �t�B�[���h

		/// <summary>
		/// ��uCOMPANY_ID(COMPANY_ID)�v�̒l
		/// </summary>
		private string companyId;

		/// <summary>
		/// ��uLOGIN_ID(LOGIN_ID)�v�̒l
		/// </summary>
		private string loginId;

		/// <summary>
		/// ��uUSER_LANGUAGE(USER_LANGUAGE)�v�̒l
		/// </summary>
		private string userLanguage;

		/// <summary>
		/// ��uMENU_PTN_CD(MENU_PTN_CD)�v�̒l
		/// </summary>
		private string menuPtnCd;

		/// <summary>
		/// ��uLOGIN_DATETIME(LOGIN_DATETIME)�v�̒l
		/// </summary>
		private DateTime? loginDatetime;

		/// <summary>
		/// ��uACCESS_DATETIME(ACCESS_DATETIME)�v�̒l
		/// </summary>
		private DateTime? accessDatetime;

		#region �v���p�e�B

		/// <summary>
		/// ��uCOMPANY_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string CompanyID
		{
			get
			{
				return companyId;
			}
			set
			{
				companyId = value;
			}
		}

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
		/// ��uUSER_LANGUAGE�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string UserLanguage
		{
			get
			{
				return userLanguage;
			}
			set
			{
				userLanguage = value;
			}
		}

		/// <summary>
		/// ��uMENU_PTN_CD�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string MenuPtnCd
		{
			get
			{
				return menuPtnCd;
			}
			set
			{
				menuPtnCd = value;
			}
		}

		/// <summary>
		/// ��uLOGIN_DATETIME�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public DateTime? LoginDatetime
		{
			get
			{
				return loginDatetime;
			}
			set
			{
				loginDatetime = value;
			}
		}

		/// <summary>
		/// ��uACCESS_DATETIME�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public DateTime? AccessDatetime
		{
			get
			{
				return accessDatetime;
			}
			set
			{
				accessDatetime = value;
			}
		}

		#endregion

		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginInfoVO()
		{
		}

		#endregion

		#region ���\�b�h
		/// <summary>
		/// ���݂�LoginInfoVO��\��System.String��Ԃ��܂��B
		/// </summary>
		/// <returns>���݂�LoginInfoVO��\��System.String�B</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("LoginInfoId:").Append(this.loginInfoId).AppendLine();
			sb.Append("CompanyId:").Append(this.companyId).AppendLine();
			sb.Append("UserId:").Append(this.loginId).AppendLine();
			sb.Append("User_language:").Append(this.userLanguage).AppendLine();
			sb.Append("Menu_Ptn_Cd:").Append(this.menuPtnCd).AppendLine();
			sb.Append("Login_datetime:").Append(this.loginDatetime).AppendLine();
			sb.Append("Access_datetime:").Append(this.accessDatetime).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VO�̃R�s�[��Ԃ��܂��B
		/// </summary>
		/// <returns>LoginInfoVO</returns>
		public LoginInfoVO Copy()
		{
			LoginInfoVO vo = new LoginInfoVO();
			vo.LoginInfoId = this.LoginInfoId;
			vo.CompanyID = this.CompanyID;
			vo.LoginID = this.LoginID;
			vo.UserLanguage = this.UserLanguage;
			vo.MenuPtnCd = this.MenuPtnCd;
			vo.LoginDatetime = this.LoginDatetime;
			vo.AccessDatetime = this.AccessDatetime;

			return vo;
		}

		#endregion

		#endregion

	}

	#endregion
}

