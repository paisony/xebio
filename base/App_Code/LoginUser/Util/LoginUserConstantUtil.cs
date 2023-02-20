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
        /// ユーザタイプ：一般ユーザ
        /// </summary>
        public const string USER_TYPE_GENERAL = "0";

        /// <summary>
        /// ユーザタイプ：システム管理ユーザ
        /// </summary>
        public const string USER_TYPE_MANAGER = "1";

        /// <summary>
        /// システム管理者のログインID
        /// </summary>
        static public string SYSTEM_MANAGER_LOGIN_ID = ConstantUtil.MAMAGER_ID;
     
        /// <summary>
        /// 利用者マスタのSmart SOA連携方向：インポート
        /// </summary>
        public const string LOGIN_USER_SYNCHRO_IN = "IN";

        /// <summary>
        /// 利用者マスタのSmart SOA連携方向：エクスポート
        /// </summary>
        public const string LOGIN_USER_SYNCHRO_OUT = "OUT";

    }

    #region ログイン認証時に使用

    /// <summary>
    /// ログイン検証結果を表します。
    /// </summary>
    public enum LoginValidateResult
    {
        /// <summary>
        /// ログイン可能
        /// </summary>
        LoginAllowed,
        /// <summary>
        /// ログインIDが存在しないためのログイン失敗
        /// </summary>
        FailureByIdNoExist,
        /// <summary>
        /// パスワード入力ミスによるログイン失敗
        /// </summary>
        FailureByInvalidPassword,
        /// <summary>
        /// ユーザロックによるログイン失敗
        /// </summary>
        FailureByUserLock,
        /// <summary>
        /// 運用時間外によるログイン失敗
        /// </summary>
        FailureByOperationTime

    }

    #endregion

}
