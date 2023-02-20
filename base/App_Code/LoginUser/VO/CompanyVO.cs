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
    /// �G���e�B�e�BBS_COMPANY�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class CompanyKey : IPrimaryKey
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public CompanyKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="company">��uCOMPANY_ID�v�̒l</param>
        public CompanyKey(
            string companyId)
        {
            this.companyId = companyId;
  
        }
        #endregion

        #region �t�B�[���h
        /// <summary>
        /// ��uCOMPANY_ID�v�̒l
        /// </summary>
 
        protected string companyId;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// ��uCOMPANY_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        
        public string CompanyId
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


        #endregion

        #region IPrimaryKey �����o

        /// <summary>
        /// Entity�̎�L�[��̗񖼂ƒl�̃y�A���擾���܂��B
        /// </summary>
        /// <returns>��L�[��/�l�̔z��</returns>
        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string, object>("COMPANY_ID", companyId)
			};

        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    ///  �G���e�B�e�BBS_COMPANY�ɑΉ�����ValueObject�ł��B
    /// </summary>
    [Serializable]
    public class CompanyVO : CompanyKey, IRecordInfoKey
    {
        /// <summary>
        /// ��uCOMPANY_NAME(COMPANY_NAME)�v�̒l
        /// </summary>
        private string companyName;

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
        /// ��uDELETE_FLAG(DELETE_FLAG)�v�̒l
        /// </summary>
        private string deleteFlag;




        #region �v���p�e�B

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


        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public CompanyVO()
        {
        }

        #endregion

        #region ���\�b�h
        /// <summary>
        /// ���݂�CompanyVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�CompanyVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

          
            sb.Append("CompanyId:").Append(this.companyId).AppendLine();
            sb.Append("CompanyName:").Append(this.companyName).AppendLine();
            sb.Append("CreateDatetime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("DeleteFlag:").Append(this.deleteFlag).AppendLine();


            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>CompanyVO</returns>
        public CompanyVO Copy()
        {
            CompanyVO vo = new CompanyVO();

            vo.CompanyId = this.CompanyId;
            vo.CompanyName = this.CompanyName;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserID = this.CreateUserID;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserID = this.UpdateUserID;
            vo.DeleteFlag = this.DeleteFlag;

            return vo;
        }

        #endregion

    }

    #endregion
}
