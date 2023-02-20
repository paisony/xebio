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
    /// �G���e�B�e�BBS_ROLE_USER_MAP�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class RoleUserMapKey : IPrimaryKey
    {
        #region �t�B�[���h
        /// <summary>
        /// ��uUSER_ID�v�̒l
        /// </summary>
        protected string loginId;

        /// <summary>
        /// ��uROLE_ID�v�̒l
        /// </summary>
        protected string roleId;

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// ��uLOGIN_ID�v�̒l���擾�܂��͐ݒ肵�܂��B
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
        /// ��uROLE_ID�v�̒l���擾�܂��͐ݒ肵�܂��B
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
        public RoleUserMapKey(){
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="loginId">��uLOGIN_ID�v�̒l</param>[
        /// <param name="roleId">��uROLE_ID�v�̒l</param>
        public RoleUserMapKey(
            string loginId,
            string roleId)
        {
            this.loginId = loginId;
            this.roleId = roleId;
        }

        #endregion

        #region IPrimaryKey�����o

        /// <summary>
        /// Entity�̎�L�[��̗񖼂ƒl�̃y�A���擾���܂��B
        /// </summary>
        /// <returns>��L�[��/�l�̔z��</returns>
        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string, object>("LOGIN_ID", loginId),
                new KeyValuePair<string, object>("ROLE_ID", roleId)
			};
        }

        #endregion
    }
    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    /// �G���e�B�e�BBS_ROLE_USER_MAP�ɑΉ��������ڂ̃f�[�^���Ǘ�����N���X�ł��B
    /// </summary>
    [Serializable]
    public class RoleUserMapVO : RoleUserMapKey
    {
        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂��B
        /// </summary>
        public RoleUserMapVO()
        {
        }

        #endregion

        #region ���\�b�h

        /// <summary>
        /// ���݂�RoleUserMapVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�RoleUserMapVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("RoleId:").Append(this.roleId).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>RoleUserMapVO</returns>
        public RoleUserMapVO Copy()
        {
            RoleUserMapVO vo = new RoleUserMapVO();
            vo.LoginId = this.LoginId;
            vo.RoleId = this.RoleId;

            return vo;
        }

        #endregion

    }

    #endregion
}
