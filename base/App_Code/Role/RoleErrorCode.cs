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
        /// ユーザが持っている権限を削除しようとしたときに使用するエラーコード
        /// </summary>
        public const string DeleteRoleAuthorityError = "B101";

        /// <summary>
        /// ユーザにロールを付与しようとしたときに使用するエラーコード
        /// </summary>
        public const string UserRoleMappingError = "B102";

        /// <summary>
        /// ユーザIDが重複している場合のエラーコード
        /// </summary>
        public const string DUPLICATION_ROLE_ID_ERROR = "B103";
    }
}
