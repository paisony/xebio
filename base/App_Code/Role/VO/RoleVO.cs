// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Role.VO
{
    #region 主キーオブジェクト

    /// <summary>
    /// エンティティBS_ROLEの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class RoleKey : IPrimaryKey
    {
        #region フィールド

        /// <summary>
        /// 列「ROLE_ID」の値
        /// </summary>
        protected string roleId;

        #endregion 

        #region プロパティ

        /// <summary>
        /// 列「ROLE_ID」の値を取得または設定する。
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

        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public RoleKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="roleId">列「ROLE_ID」の値</param>
        public RoleKey(string roleId)
        {
            this.roleId = roleId;
        }
        #endregion

        #region IPrimaryKey メンバ

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("ROLE_ID", roleId)
            };
        }

        #endregion
    }

    #endregion

    #region エンティティVO

    /// <summary>
    /// エンティティBS_ROLEに対応した項目のデータを管理するクラスです。
    /// </summary>
    [Serializable]
    public class RoleVO : RoleKey, IRecordInfoKey
    {
        #region フィールド

        /// <summary>
        /// 列「ROLE_NAME」の値
        /// </summary>
        private string roleName;

        /// <summary>
        /// 列「ROLE_NOTE」の値
        /// </summary>
        private string roleNote;

        /// <summary>
        /// 列「CREATE_DATETIME」の値
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// 列「CREATE_USER_ID」の値
        /// </summary>
        private string createUserId;

        /// <summary>
        /// 列「UPDATE_DATETIME」の値
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// 列「UPDATE_USER_ID」の値
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// 列「ROW_UPDATE_ID」の値
        /// </summary>
        private string rowUpdateId;

        #endregion

        #region プロパティ

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

        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public RoleVO()
        {
        }

        #endregion 

        #region メソッド

        /// <summary>
        /// 現在のRoleVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のRoleVOを表すSystem.String。</returns>
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
        /// VOのコピーを返します。
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
