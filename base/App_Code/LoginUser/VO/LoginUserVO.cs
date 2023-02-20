// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.VO
{
    #region 主キーオブジェクト

    /// <summary>
    /// エンティティBS_LOGIN_USERの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class LoginUserKey : IPrimaryKey
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public LoginUserKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="loginId">列「LOGIN_USER_ID」の値</param>
        public LoginUserKey(
            string loginId)
        {
            this.loginId = loginId;
        }
        #endregion

        #region フィールド
        /// <summary>
        /// 列「LOGIN_ID(LOGIN_ID)」の値
        /// </summary>
        protected string loginId;
        #endregion

        #region プロパティ
        /// <summary>
        /// 列「LOGIN_ID」の値を取得または設定する
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
       
        #endregion

        #region IPrimaryKey メンバ

        /// <summary>
        /// Entityの主キー列の列名と値のペアを取得します。
        /// </summary>
        /// <returns>主キー列名/値の配列</returns>
        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("LOGIN_ID",loginId)
			};
            
        }

        #endregion
    }

    #endregion

    #region エンティティVO

    /// <summary>
    ///  エンティティBS_LOGIN_USERに対応したValueObjectです。
    /// </summary>
    [Serializable]
    public class LoginUserVO : LoginUserKey, IRecordInfoKey
    {
       
        /// <summary>
        /// 列「PASSWORD(PASSWORD)」の値
        /// </summary>
        private string password;

        /// <summary>
        /// 列「PASSWORD2(PASSWORD2)」の値
        /// </summary>
        private string oldPassword;

        /// <summary>
        /// 列「COMPANY_ID(COMPANY_ID)」の値
        /// </summary>
        private string companyId;

        /// <summary>
        /// 列「COMPANY_NAME(COMPANY_NAME)」の値
        /// </summary>
        private string companyName;

        /// <summary>
        /// 列「NAME(NAME)」の値
        /// </summary>
        private string name;

        /// <summary>
        /// 列「NAME_KANA(NAME_KANA)」の値
        /// </summary>
        private string kana;

        /// <summary>
        /// 列「CREATE_DATETIME(CREATE_DATETIME)」の値
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// 列「CREATE_USER_ID(CREATE_USER_ID)」の値
        /// </summary>
        private string createUserId;

        /// <summary>
        /// 列「UPDATE_DATETIME(UPDATE_DATETIME)」の値
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// 列「UPDATE_USER_ID(UPDATE_USER_ID)」の値
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// 列「ROW_UPDATE_ID(ROW_UPDATE_ID)」の値
        /// </summary>
        private string rowUpdateId;

        /// <summary>
        /// 列「DELETE_FLAG(DELETE_FLAG)」の値
        /// </summary>
        private string deleteFlag;

        /// <summary>
        /// 列「USER_TYPE(USER_TYPE)」の値
        /// </summary>
        private string userType;

        /// <summary>
        /// 列「MAPPING_ID(MAPPING_ID)」の値
        /// </summary>
        private string mappingId;

        /// <summary>
        /// 列「LOCK_FLAG(LOCK_FLAG)」の値
        /// </summary>
        private string lockFlag;

        /// <summary>
        /// 列「PASSWORD_UPDATE_DATETIME(PASSWORD_UPDATE_DATETIME)」の値
        /// </summary>
        private DateTime passwordUpdateDatetime;

        /// <summary>
        /// 列「TEMP_PASSWORD_FLAG(TEMP_PASSWORD_FLAG)」の値
        /// </summary>
        private string tempPasswordFlag;

        #region プロパティ


        /// <summary>
        /// 列「PASSWORD」の値を取得または設定する
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
        /// 列「PASSWORD」の値を取得または設定する
        /// </summary>
        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                oldPassword = value;
            }
        }

        /// <summary>
        /// 列「COMPANY_ID」の値を取得または設定する
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
        /// 列「COMPANY_NAME」の値を取得または設定する
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
        /// 列「NAME」の値を取得または設定する
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
        /// 列「NAME_KANA」の値を取得または設定する
        /// </summary>
        public string Kana
        {
            get
            {
                return kana;
            }
            set
            {
                kana = value;
            }
        }

        /// <summary>
        /// 列「CREATE_DATETIME」の値を取得または設定する
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
        /// 列「CREATE_USER_ID」の値を取得または設定する
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
        /// 列「UPDATE_DATETIME」の値を取得または設定する
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
        /// 列「UPDATE_USER_ID」の値を取得または設定する
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
        /// 列「ROW_UPDATE_ID」の値を取得または設定する
        /// </summary>
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

        /// <summary>
        /// 列「DELETE_FLAG」の値を取得または設定する
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

        /// <summary>
        /// 列「USER_TYPE」の値を取得または設定する
        /// </summary>
        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        /// <summary>
        /// 列「MAPPING_ID」の値を取得または設定する
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
        /// 列「LOCK_FLAG」の値を取得または設定する
        /// </summary>
        public string LockFlag
        {
            get
            {
                return lockFlag;
            }
            set
            {
                lockFlag = value;
            }
        }

        /// <summary>
        /// 列「PASSWORD_UPDATE_DATETIME」の値を取得または設定する
        /// </summary>
        public DateTime PasswordUpdateDateTime
        {
            get
            {
                return passwordUpdateDatetime;
            }
            set
            {
                passwordUpdateDatetime = value;
            }
        }

        /// <summary>
        /// 列「TEMP_PASSWORD_FLAG」の値を取得または設定する
        /// </summary>
        public string TempPasswordFlag
        {
            get
            {
                return tempPasswordFlag;
            }
            set
            {
                tempPasswordFlag = value;
            }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public LoginUserVO()
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 現在のLoginUserVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のLoginUserVOを表すSystem.String。</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("CompanyId:").Append(this.companyId).AppendLine();
            sb.Append("CompanyName:").Append(this.companyName).AppendLine();
            sb.Append("Password:").Append(this.password).AppendLine();
            sb.Append("OldPassword:").Append(this.oldPassword).AppendLine();
            sb.Append("Name:").Append(this.name).AppendLine();
            sb.Append("Kana:").Append(this.kana).AppendLine();
            sb.Append("CreateDatetime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("RowUpdateId:").Append(this.rowUpdateId).AppendLine();
            sb.Append("DeleteFlag:").Append(this.deleteFlag).AppendLine();
            sb.Append("UserType:").Append(this.userType).AppendLine();
            sb.Append("MappingId:").Append(this.mappingId).AppendLine();
            sb.Append("LockFlag:").Append(this.lockFlag).AppendLine();
            sb.Append("PasswordUpdateDatetime:").Append(this.passwordUpdateDatetime).AppendLine();
            sb.Append("TempPasswordFlag:").Append(this.tempPasswordFlag).AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
        /// </summary>
        /// <returns>LoginInfoVO</returns>
        public LoginUserVO Copy()
        {
            LoginUserVO vo = new LoginUserVO();
            vo.LoginId = this.LoginId;
            vo.CompanyID = this.CompanyID;
            vo.CompanyName = this.CompanyName;
            vo.Password = this.Password;
            vo.OldPassword = this.OldPassword;
            vo.Name = this.Name;
            vo.Kana = this.Kana;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserID = this.CreateUserID;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserID = this.UpdateUserID;
            vo.RowUpdateId = this.RowUpdateId;
            vo.DeleteFlag = this.DeleteFlag;
            vo.UserType = this.UserType;
            vo.MappingID = this.MappingID;
            vo.LockFlag = this.LockFlag;
            vo.PasswordUpdateDateTime = this.PasswordUpdateDateTime;
            vo.TempPasswordFlag = this.TempPasswordFlag;
            return vo;
        }

        #endregion

    }

    #endregion
}

