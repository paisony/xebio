// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.Role
{
    public class RoleErrorCode
    {
        /// <summary>
        /// ���[�U�������Ă��錠�����폜���悤�Ƃ����Ƃ��Ɏg�p����G���[�R�[�h
        /// </summary>
        public const string DeleteRoleAuthorityError = "B101";

        /// <summary>
        /// ���[�U�Ƀ��[����t�^���悤�Ƃ����Ƃ��Ɏg�p����G���[�R�[�h
        /// </summary>
        public const string UserRoleMappingError = "B102";

        /// <summary>
        /// ���[�UID���d�����Ă���ꍇ�̃G���[�R�[�h
        /// </summary>
        public const string DUPLICATION_ROLE_ID_ERROR = "B103";
    }
}
