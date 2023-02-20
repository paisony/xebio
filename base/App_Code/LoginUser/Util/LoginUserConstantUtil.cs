// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Common.Util;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Util
{
    public class LoginUserConstantUtil
    {
        /// <summary>
        /// ���[�U�^�C�v�F��ʃ��[�U
        /// </summary>
        public const string USER_TYPE_GENERAL = "0";

        /// <summary>
        /// ���[�U�^�C�v�F�V�X�e���Ǘ����[�U
        /// </summary>
        public const string USER_TYPE_MANAGER = "1";

        /// <summary>
        /// �V�X�e���Ǘ��҂̃��O�C��ID
        /// </summary>
        static public string SYSTEM_MANAGER_LOGIN_ID = ConstantUtil.MAMAGER_ID;
     
        /// <summary>
        /// ���p�҃}�X�^��Smart SOA�A�g�����F�C���|�[�g
        /// </summary>
        public const string LOGIN_USER_SYNCHRO_IN = "IN";

        /// <summary>
        /// ���p�҃}�X�^��Smart SOA�A�g�����F�G�N�X�|�[�g
        /// </summary>
        public const string LOGIN_USER_SYNCHRO_OUT = "OUT";

    }

    #region ���O�C���F�؎��Ɏg�p

    /// <summary>
    /// ���O�C�����،��ʂ�\���܂��B
    /// </summary>
    public enum LoginValidateResult
    {
        /// <summary>
        /// ���O�C���\
        /// </summary>
        LoginAllowed,
        /// <summary>
        /// ���O�C��ID�����݂��Ȃ����߂̃��O�C�����s
        /// </summary>
        FailureByIdNoExist,
        /// <summary>
        /// �p�X���[�h���̓~�X�ɂ�郍�O�C�����s
        /// </summary>
        FailureByInvalidPassword,
        /// <summary>
        /// ���[�U���b�N�ɂ�郍�O�C�����s
        /// </summary>
        FailureByUserLock,
        /// <summary>
        /// �^�p���ԊO�ɂ�郍�O�C�����s
        /// </summary>
        FailureByOperationTime

    }

    #endregion

}
