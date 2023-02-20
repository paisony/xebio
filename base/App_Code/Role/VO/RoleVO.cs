// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Role.VO
{
    #region ��L�[�I�u�W�F�N�g

    /// <summary>
    /// �G���e�B�e�BBS_ROLE�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class RoleKey : IPrimaryKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ��uROLE_ID�v�̒l
        /// </summary>
        protected string roleId;

        #endregion 

        #region �v���p�e�B

        /// <summary>
        /// ��uROLE_ID�v�̒l���擾�܂��͐ݒ肷��B
        /// </summary>
        public string RoleId
        {
            get
            {
                return roleId;
            }
            set
            {
                roleId = value;
            }
        }

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂��B
        /// </summary>
        public RoleKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="roleId">��uROLE_ID�v�̒l</param>
        public RoleKey(string roleId)
        {
            this.roleId = roleId;
        }
        #endregion

        #region IPrimaryKey �����o

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("ROLE_ID", roleId)
            };
        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    /// �G���e�B�e�BBS_ROLE�ɑΉ��������ڂ̃f�[�^���Ǘ�����N���X�ł��B
    /// </summary>
    [Serializable]
    public class RoleVO : RoleKey, IRecordInfoKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ��uROLE_NAME�v�̒l
        /// </summary>
        private string roleName;

        /// <summary>
        /// ��uROLE_NOTE�v�̒l
        /// </summary>
        private string roleNote;

        /// <summary>
        /// ��uCREATE_DATETIME�v�̒l
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// ��uCREATE_USER_ID�v�̒l
        /// </summary>
        private string createUserId;

        /// <summary>
        /// ��uUPDATE_DATETIME�v�̒l
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// ��uUPDATE_USER_ID�v�̒l
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// ��uROW_UPDATE_ID�v�̒l
        /// </summary>
        private string rowUpdateId;

        #endregion

        #region �v���p�e�B

        public string RoleName
        {
            get
            {
                return roleName;
            }
            set
            {
                roleName = value;
            }
        }

        public string RoleNote
        {
            get
            {
                return roleNote;
            }
            set
            {
                roleNote = value;
            }
        }


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

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂��B
        /// </summary>
        public RoleVO()
        {
        }

        #endregion 

        #region ���\�b�h

        /// <summary>
        /// ���݂�RoleVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�RoleVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("RoleId:").Append(this.roleId).AppendLine();
            sb.Append("RoleName:").Append(this.roleName).AppendLine();
            sb.Append("RoleNote:").Append(this.roleNote).AppendLine();
            sb.Append("CreateDatetime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDateTime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("RowUpdateId:").Append(this.rowUpdateId).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>RoleVO</returns>
        public RoleVO Copy()
        {
            RoleVO vo = new RoleVO();
            vo.RoleId = this.RoleId;
            vo.RoleName = this.RoleName;
            vo.RoleNote = this.RoleNote;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserID = this.CreateUserID;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserID = this.UpdateUserID;
            vo.RowUpdateId = this.RowUpdateId;

            return vo;
        }

        #endregion


    }
    #endregion 
}
