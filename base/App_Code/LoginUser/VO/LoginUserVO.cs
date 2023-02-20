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
    /// �G���e�B�e�BBS_LOGIN_USER�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class LoginUserKey : IPrimaryKey
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public LoginUserKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="loginId">��uLOGIN_USER_ID�v�̒l</param>
        public LoginUserKey(
            string loginId)
        {
            this.loginId = loginId;
        }
        #endregion

        #region �t�B�[���h
        /// <summary>
        /// ��uLOGIN_ID(LOGIN_ID)�v�̒l
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
				new KeyValuePair<string, object>("LOGIN_ID",loginId)
			};
            
        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    ///  �G���e�B�e�BBS_LOGIN_USER�ɑΉ�����ValueObject�ł��B
    /// </summary>
    [Serializable]
    public class LoginUserVO : LoginUserKey, IRecordInfoKey
    {
       
        /// <summary>
        /// ��uPASSWORD(PASSWORD)�v�̒l
        /// </summary>
        private string password;

        /// <summary>
        /// ��uPASSWORD2(PASSWORD2)�v�̒l
        /// </summary>
        private string oldPassword;

        /// <summary>
        /// ��uCOMPANY_ID(COMPANY_ID)�v�̒l
        /// </summary>
        private string companyId;

        /// <summary>
        /// ��uCOMPANY_NAME(COMPANY_NAME)�v�̒l
        /// </summary>
        private string companyName;

        /// <summary>
        /// ��uNAME(NAME)�v�̒l
        /// </summary>
        private string name;

        /// <summary>
        /// ��uNAME_KANA(NAME_KANA)�v�̒l
        /// </summary>
        private string kana;

        /// <summary>
        /// ��uCREATE_DATETIME(CREATE_DATETIME)�v�̒l
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// ��uCREATE_USER_ID(CREATE_USER_ID)�v�̒l
        /// </summary>
        private string createUserId;

        /// <summary>
        /// ��uUPDATE_DATETIME(UPDATE_DATETIME)�v�̒l
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// ��uUPDATE_USER_ID(UPDATE_USER_ID)�v�̒l
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// ��uROW_UPDATE_ID(ROW_UPDATE_ID)�v�̒l
        /// </summary>
        private string rowUpdateId;

        /// <summary>
        /// ��uDELETE_FLAG(DELETE_FLAG)�v�̒l
        /// </summary>
        private string deleteFlag;

        /// <summary>
        /// ��uUSER_TYPE(USER_TYPE)�v�̒l
        /// </summary>
        private string userType;

        /// <summary>
        /// ��uMAPPING_ID(MAPPING_ID)�v�̒l
        /// </summary>
        private string mappingId;

        /// <summary>
        /// ��uLOCK_FLAG(LOCK_FLAG)�v�̒l
        /// </summary>
        private string lockFlag;

        /// <summary>
        /// ��uPASSWORD_UPDATE_DATETIME(PASSWORD_UPDATE_DATETIME)�v�̒l
        /// </summary>
        private DateTime passwordUpdateDatetime;

        /// <summary>
        /// ��uTEMP_PASSWORD_FLAG(TEMP_PASSWORD_FLAG)�v�̒l
        /// </summary>
        private string tempPasswordFlag;

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

        /// <summary>
        /// ��uPASSWORD�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                oldPassword = value;
            }
        }

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
        /// ��uCOMPANY_NAME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
            }
        }

        /// <summary>
        /// ��uNAME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// ��uNAME_KANA�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Kana
        {
            get
            {
                return kana;
            }
            set
            {
                kana = value;
            }
        }

        /// <summary>
        /// ��uCREATE_DATETIME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public DateTime CreateDateTime
        {
            get
            {
                return createDatetime;
            }
            set
            {
                createDatetime = value;
            }
        }

        /// <summary>
        /// ��uCREATE_USER_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string CreateUserID
        {
            get
            {
                return createUserId;
            }
            set
            {
                createUserId = value;
            }
        }

        /// <summary>
        /// ��uUPDATE_DATETIME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public DateTime UpdateDateTime
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

        /// <summary>
        /// ��uUPDATE_USER_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string UpdateUserID
        {
            get
            {
                return updateUserId;
            }
            set
            {
                updateUserId = value;
            }
        }

        /// <summary>
        /// ��uROW_UPDATE_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string RowUpdateId
        {
            get
            {
                return rowUpdateId;
            }
            set
            {
                rowUpdateId = value;
            }
        }

        /// <summary>
        /// ��uDELETE_FLAG�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string DeleteFlag
        {
            get
            {
                return deleteFlag;
            }
            set
            {
                deleteFlag = value;
            }
        }

        /// <summary>
        /// ��uUSER_TYPE�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        /// <summary>
        /// ��uMAPPING_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string MappingID
        {
            get
            {
                return mappingId;
            }
            set
            {
                mappingId = value;
            }
        }

        /// <summary>
        /// ��uLOCK_FLAG�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string LockFlag
        {
            get
            {
                return lockFlag;
            }
            set
            {
                lockFlag = value;
            }
        }

        /// <summary>
        /// ��uPASSWORD_UPDATE_DATETIME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public DateTime PasswordUpdateDateTime
        {
            get
            {
                return passwordUpdateDatetime;
            }
            set
            {
                passwordUpdateDatetime = value;
            }
        }

        /// <summary>
        /// ��uTEMP_PASSWORD_FLAG�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string TempPasswordFlag
        {
            get
            {
                return tempPasswordFlag;
            }
            set
            {
                tempPasswordFlag = value;
            }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public LoginUserVO()
        {
        }

        #endregion

        #region ���\�b�h
        /// <summary>
        /// ���݂�LoginUserVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�LoginUserVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("CompanyId:").Append(this.companyId).AppendLine();
            sb.Append("CompanyName:").Append(this.companyName).AppendLine();
            sb.Append("Password:").Append(this.password).AppendLine();
            sb.Append("OldPassword:").Append(this.oldPassword).AppendLine();
            sb.Append("Name:").Append(this.name).AppendLine();
            sb.Append("Kana:").Append(this.kana).AppendLine();
            sb.Append("CreateDatetime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("RowUpdateId:").Append(this.rowUpdateId).AppendLine();
            sb.Append("DeleteFlag:").Append(this.deleteFlag).AppendLine();
            sb.Append("UserType:").Append(this.userType).AppendLine();
            sb.Append("MappingId:").Append(this.mappingId).AppendLine();
            sb.Append("LockFlag:").Append(this.lockFlag).AppendLine();
            sb.Append("PasswordUpdateDatetime:").Append(this.passwordUpdateDatetime).AppendLine();
            sb.Append("TempPasswordFlag:").Append(this.tempPasswordFlag).AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>LoginInfoVO</returns>
        public LoginUserVO Copy()
        {
            LoginUserVO vo = new LoginUserVO();
            vo.LoginId = this.LoginId;
            vo.CompanyID = this.CompanyID;
            vo.CompanyName = this.CompanyName;
            vo.Password = this.Password;
            vo.OldPassword = this.OldPassword;
            vo.Name = this.Name;
            vo.Kana = this.Kana;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserID = this.CreateUserID;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserID = this.UpdateUserID;
            vo.RowUpdateId = this.RowUpdateId;
            vo.DeleteFlag = this.DeleteFlag;
            vo.UserType = this.UserType;
            vo.MappingID = this.MappingID;
            vo.LockFlag = this.LockFlag;
            vo.PasswordUpdateDateTime = this.PasswordUpdateDateTime;
            vo.TempPasswordFlag = this.TempPasswordFlag;
            return vo;
        }

        #endregion

    }

    #endregion
}

