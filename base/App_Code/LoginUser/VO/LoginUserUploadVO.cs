// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.VO
{
    /// <summary>
    /// 利用者アップロードAPIで利用する、更新対象の利用者情報を格納するVOです。
    /// </summary>
    public class LoginUserUploadVO
    {

        #region フィールド

        /// <summary>
        /// 列「LOGIN_ID(LOGIN_ID)」の値
        /// </summary>
        protected string loginId;

        /// <summary>
        /// 列「PASSWORD(PASSWORD)」の値
        /// </summary>
        private string password;

        /// <summary>
        /// 列「NAME(NAME)」の値
        /// </summary>
        private string name;

        /// <summary>
        /// 列「NAME_KANA(NAME_KANA)」の値
        /// </summary>
        private string nameKana;

        /// <summary>
        /// 列「COMPANY_ID(COMPANY_ID)」の値
        /// </summary>
        private string companyId;

        /// <summary>
        /// 列「MAPPING_ID(MAPPING_ID)」の値
        /// </summary>
        private string mappingId;

        /// <summary>
        /// 列「ROLE_MAPPING(ROLE_MAPPING)」の値
        /// </summary>
        private string[] roleMapping;

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
        public string NameKana
        {
            get
            {
                return nameKana;
            }
            set
            {
                nameKana = value;
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
        /// 列「ROLE_MAPPING」の値を取得または設定する
        /// </summary>
        public string[] RoleMapping
        {
            get
            {
                return roleMapping;
            }
            set
            {
                roleMapping = value;
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public LoginUserUploadVO()
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
            sb.Append("Password:").Append(this.password).AppendLine();
            sb.Append("Name:").Append(this.name).AppendLine();
            sb.Append("Kana:").Append(this.nameKana).AppendLine();
            sb.Append("MappingId:").Append(this.mappingId).AppendLine();
            sb.Append("RoleMapping:");
            for (int i = 0; i < this.roleMapping.Length; i++)
            {
                sb.Append(this.roleMapping[i]);
                if (i < this.roleMapping.Length - 1)
                {
                    sb.Append(" , ");
                }
            }

            return sb.ToString();
        }

        #endregion

    }
}
