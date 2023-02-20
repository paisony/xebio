// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.LoginUser
{
    public class LoginUserErrorCode
    {
        /// <summary>
        /// ログインIDが重複した時のエラー
        /// </summary>
        public const string DUPLICATION_LOGIN_ID_ERROR = "B901";
        
        /// <summary>
        /// 古いパスワードが不一致時のエラー
        /// </summary>
        public const string PASSWORD_ERROR = "B902";

        /// <summary>
        /// パスワード履歴に更新しようとするパスワードが含まれていた時のエラー
        /// </summary>
        public const string PASSWORD_HISTORY_DUPLICATION_ERROR = "B903";

        /// <summary>
        /// ログイン時にログインIDがロックされていた時のエラー
        /// </summary>
        public const string LOGIN_ID_LOCK_ERROR = "B904";

        /// <summary>
        /// ログイン時にパスワードが違う場合のエラー
        /// </summary>
        public const string LOGIN_PASSWORD_ERROR = "B905";

        /// <summary>
        /// ログイン時にシステム運用時間外場合のエラー
        /// </summary>
        public const string LOGIN_TIME_ERROR = "B906";

    }
}
