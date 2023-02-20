// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.VO
{
    /// <summary>
    /// ���p�҃A�b�v���[�hAPI�ŗ��p����A�X�V�Ώۂ̗��p�ҏ����i�[����VO�ł��B
    /// </summary>
    public class LoginUserUploadVO
    {

        #region �t�B�[���h

        /// <summary>
        /// ��uLOGIN_ID(LOGIN_ID)�v�̒l
        /// </summary>
        protected string loginId;

        /// <summary>
        /// ��uPASSWORD(PASSWORD)�v�̒l
        /// </summary>
        private string password;

        /// <summary>
        /// ��uNAME(NAME)�v�̒l
        /// </summary>
        private string name;

        /// <summary>
        /// ��uNAME_KANA(NAME_KANA)�v�̒l
        /// </summary>
        private string nameKana;

        /// <summary>
        /// ��uCOMPANY_ID(COMPANY_ID)�v�̒l
        /// </summary>
        private string companyId;

        /// <summary>
        /// ��uMAPPING_ID(MAPPING_ID)�v�̒l
        /// </summary>
        private string mappingId;

        /// <summary>
        /// ��uROLE_MAPPING(ROLE_MAPPING)�v�̒l
        /// </summary>
        private string[] roleMapping;

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
        public string NameKana
        {
            get
            {
                return nameKana;
            }
            set
            {
                nameKana = value;
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
        /// ��uROLE_MAPPING�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string[] RoleMapping
        {
            get
            {
                return roleMapping;
            }
            set
            {
                roleMapping = value;
            }
        }

        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public LoginUserUploadVO()
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
            sb.Append("Password:").Append(this.password).AppendLine();
            sb.Append("Name:").Append(this.name).AppendLine();
            sb.Append("Kana:").Append(this.nameKana).AppendLine();
            sb.Append("MappingId:").Append(this.mappingId).AppendLine();
            sb.Append("RoleMapping:");
            for (int i = 0; i < this.roleMapping.Length; i++)
            {
                sb.Append(this.roleMapping[i]);
                if (i < this.roleMapping.Length - 1)
                {
                    sb.Append(" , ");
                }
            }

            return sb.ToString();
        }

        #endregion

    }
}
