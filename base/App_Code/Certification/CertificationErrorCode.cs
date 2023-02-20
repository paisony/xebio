// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.Certification
{
    public class CertificationErrorCode
    {
        /// <summary>
        /// 二重ログイン。既に同一ユーザがログインしていた場合。
        /// </summary>
        public const string DUPLICATION_LOGIN_ERROR = "B001";

        /// <summary>
        /// 認証に失敗した場合（基盤の認証）。
        /// </summary>
        public const string BASE_CERT_ERROR = "B002";

        /// <summary>
        /// 認証に失敗した場合（連携ソリューションの認証）。
        /// </summary>
        public const string SOLUTION_CERT_ERROR = "B003";

        /// <summary>
        /// システムの使用権がない。（ログインユーザにロールがない）
        /// </summary>
        public const string ROLE_NOTHING = "B004";
    }
}
