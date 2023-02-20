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
    /// �G���e�B�e�BBS_PASSWORD_HISTORY�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class PasswordHistoryKey : IPrimaryKey
    {
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public PasswordHistoryKey()
		{
		}

		/// <summary>
		/// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
		/// </summary>
        /// <param name="loginId">��uLOGIN_ID�v�̒l</param>
		/// <param name="updateDatetime">��uUPDATE_DATETIME�v�̒l</param>
        public PasswordHistoryKey(
			string loginId,
            DateTime? updateDatetime)
		{
            this.loginId = loginId;
            this.updateDatetime = updateDatetime;
		}
		#endregion
		
		#region �t�B�[���h

		/// <summary>
        /// ��uLOGIN_ID�v�̒l
		/// </summary>
		protected string loginId;

		/// <summary>
        /// ��uUPDATE_DATETIME�v�̒l
		/// </summary>
		protected DateTime? updateDatetime;

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
		public DateTime? UpdateDatetime
		{
			get
			{
                return updateDatetime;
			}
			set
			{
                updateDatetime = value;
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
				new KeyValuePair<string, object>("UPDATE_DATETIME",updateDatetime),
			};
		}

		#endregion
    }

    #endregion


    #region �G���e�B�e�BVO

    /// <summary>
    ///  �G���e�B�e�BBS_PASSWORD_HISTORY�ɑΉ�����ValueObject�ł��B
    /// </summary>
    [Serializable]
    public class PasswordHistoryVO : PasswordHistoryKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ��uPASSWORD�v�̒l
        /// </summary>
        protected string password;

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// ��uPASSWORD�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public PasswordHistoryVO()
        {
        }

        #endregion

        #region ���\�b�h

        /// <summary>
        /// ���݂�PasswordHistoryVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�PasswordHistoryVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginID:").Append(this.loginId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("Password:").Append(this.password).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>�v���p�e�B�l���R�s�[���ꂽPasswordHistoryVO</returns>
        public PasswordHistoryVO Copy()
        {
            PasswordHistoryVO vo = new PasswordHistoryVO();
            vo.LoginID = this.LoginID;
            vo.UpdateDatetime = this.UpdateDatetime;
            vo.Password = this.Password;

            return vo;
        }

        #endregion

    }

    #endregion
}
