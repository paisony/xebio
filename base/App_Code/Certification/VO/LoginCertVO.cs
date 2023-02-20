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
	/// �G���e�B�e�BBS_LOGIN_CERT�̎�L�[��\���N���X
	/// </summary>
    [Serializable]
	public class LoginCertKey : IPrimaryKey
	{
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginCertKey()
		{
		}

		/// <summary>
		/// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
		/// </summary>
		/// <param name="loginCertId">��uLOGIN_CERT_ID�v�̒l</param>
		public LoginCertKey(
			string loginCertId		)
		{
			this.loginCertId = loginCertId;
		}
		#endregion
		
		#region �t�B�[���h
		/// <summary>
		/// ��uLOGIN_CERT_ID(LOGIN_CERT_ID)�v�̒l
		/// </summary>
		protected string loginCertId;
		#endregion

		#region �v���p�e�B
		/// <summary>
		/// ��uLOGIN_CERT_ID�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string LoginCertID
		{
			get
			{
				return loginCertId;
			}
			set
			{
				loginCertId = value;
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
				new KeyValuePair<string, object>("LOGIN_CERT_ID",loginCertId)
			};
		}

		#endregion
	}

	#endregion

	#region �G���e�B�e�BVO

	/// <summary>
	///  �G���e�B�e�BBS_LOGIN_CERT�ɑΉ�����ValueObject�ł��B
	/// </summary>
    [Serializable]
	public class  LoginCertVO : LoginCertKey
	{
		#region �t�B�[���h

		/// <summary>
		/// ��uLOGIN_INFO_ID(LOGIN_INFO_ID)�v�̒l
		/// </summary>
		private string loginInfoId;

		/// <summary>
		/// ��uSOLUTION_ID(SOLUTION_ID)�v�̒l
		/// </summary>
		private string solutionId;

		#endregion
		
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public LoginCertVO()
		{
		}
		#endregion

        #region �v���p�e�B

        /// <summary>
        /// ��uLOGIN_INFO_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string LoginInfoID
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

        /// <summary>
        /// ��uSOLUTION_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string SolutionID
        {
            get
            {
                return solutionId;
            }
            set
            {
                solutionId = value;
            }
        }

        #endregion
		
		#region ���\�b�h
		/// <summary>
		/// ���݂�LoginCertVO��\��System.String��Ԃ��܂��B
		/// </summary>
		/// <returns>���݂�LoginCertVO��\��System.String�B</returns>
		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();

			sb.Append("Login_cert_id:").Append(this.loginCertId).AppendLine();
			sb.Append("Login_info_id:").Append(this.loginInfoId).AppendLine();
			sb.Append("Solution_id:").Append(this.solutionId).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VO�̃R�s�[��Ԃ��܂��B
		/// </summary>
		/// <returns>LoginCertVO</returns>
		public LoginCertVO Copy()
		{
			LoginCertVO vo = new LoginCertVO();
            vo.LoginCertID = this.LoginCertID;
            vo.LoginInfoID = this.LoginCertID;
            vo.SolutionID = this.LoginCertID;
			return vo;
        }

		#endregion

	}

	#endregion
}

