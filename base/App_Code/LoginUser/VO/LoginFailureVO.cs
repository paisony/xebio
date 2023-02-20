// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.VO
{
    #region ��L�[�I�u�W�F�N�g

    /// <summary>
    /// �G���e�B�e�BBS_LOGIN_FAILURE�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class LoginFailureKey : IPrimaryKey
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public LoginFailureKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="login">��uLOGIN_ID�v�̒l</param>
        public LoginFailureKey(
            string loginId)
        {
            this.loginId = loginId;
  
        }
        #endregion

        #region �t�B�[���h
        /// <summary>
        /// ��uLOGIN_ID�v�̒l
        /// </summary>
 
        protected string loginId;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// ��uLOGIN_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>

        public string LoginId
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


        #endregion

        #region IPrimaryKey �����o

        /// <summary>
        /// Entity�̎�L�[��̗񖼂ƒl�̃y�A���擾���܂��B
        /// </summary>
        /// <returns>��L�[��/�l�̔z��</returns>
        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string, object>("LOGIN_ID", loginId)
            };

        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    ///  �G���e�B�e�BBS_LOGIN_FAILURE�ɑΉ�����ValueObject�ł��B
    /// </summary>
    [Serializable]
    public class LoginFailureVO : LoginFailureKey
    {
        /// <summary>
        /// ��uFAILURE_COUNT(FAILURE_COUN)�v�̒l
        /// </summary>
        private int failureCount;

        #region �v���p�e�B

        /// <summary>
        /// ��uFAILURE_COUN�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public int FailureCount
        {
            get
            {
                return failureCount;
            }
            set
            {
                failureCount = value;
            }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public LoginFailureVO()
        {
        }

        #endregion

        #region ���\�b�h
        /// <summary>
        /// ���݂�LoginFailureVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�LoginFailureVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("FailureCount:").Append(this.failureCount).AppendLine();
            
            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>LoginFailureVO</returns>
        public LoginFailureVO Copy()
        {
            LoginFailureVO vo = new LoginFailureVO();

            vo.LoginId = this.LoginId;
            vo.FailureCount = this.FailureCount;
            return vo;
        }

        #endregion

    }

    #endregion
}
