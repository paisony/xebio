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
    /// エンティティBS_ROLE_USER_MAPの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class RoleUserMapKey : IPrimaryKey
    {
        #region フィールド
        /// <summary>
        /// 列「USER_ID」の値
        /// </summary>
        protected string loginId;

        /// <summary>
        /// 列「ROLE_ID」の値
        /// </summary>
        protected string roleId;

        #endregion

        #region プロパティ

        /// <summary>
        /// 列「LOGIN_ID」の値を取得または設定します。
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
        /// 列「ROLE_ID」の値を取得または設定します。
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
        public RoleUserMapKey(){
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="loginId">列「LOGIN_ID」の値</param>[
        /// <param name="roleId">列「ROLE_ID」の値</param>
        public RoleUserMapKey(
            string loginId,
            string roleId)
        {
            this.loginId = loginId;
            this.roleId = roleId;
        }

        #endregion

        #region IPrimaryKeyメンバ

        /// <summary>
        /// Entityの主キー列の列名と値のペアを取得します。
        /// </summary>
        /// <returns>主キー列名/値の配列</returns>
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

    #region エンティティVO

    /// <summary>
    /// エンティティBS_ROLE_USER_MAPに対応した項目のデータを管理するクラスです。
    /// </summary>
    [Serializable]
    public class RoleUserMapVO : RoleUserMapKey
    {
        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public RoleUserMapVO()
        {
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 現在のRoleUserMapVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のRoleUserMapVOを表すSystem.String。</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("RoleId:").Append(this.roleId).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
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
