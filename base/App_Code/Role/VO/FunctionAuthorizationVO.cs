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
    /// エンティティBS_FUNCTION_AUTHORIZATIONの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class FunctionAuthorizationKey : IPrimaryKey
    {
        #region フィールド

        /// <summary>
        /// 列「ROLE_ID」の値
        /// </summary>
        protected string roleId;

        /// <summary>
        /// 列「SOLUTION_ID」の値
        /// </summary>
        protected string solutionId;

        /// <summary>
        /// 列「FUNCTION_ID」の値
        /// </summary>
        protected string functionId;

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

        /// <summary>
        /// 列「SOLUTION_ID」の値を取得または設定する。
        /// </summary>
        public string SolutionId
        {
            get
            {
                return solutionId;
            }
            set
            {
                solutionId = value;
            }
        }

        /// <summary>
        /// 列「FUNCTION_ID」の値を取得または設定する。
        /// </summary>
        public string FunctionId
        {
            get
            {
                return functionId;
            }
            set
            {
                functionId = value;
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public FunctionAuthorizationKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        public FunctionAuthorizationKey(
            string roleId,
            string solutionId,
            string functionId)
        {
            this.roleId = roleId;
            this.solutionId = solutionId;
            this.functionId = functionId;
        }
        #endregion

        #region IPrimaryKey メンバ

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("ROLE_ID", roleId),
                new KeyValuePair<string,object>("SOLUTION_ID", solutionId)
            };
        }

        #endregion
    }

    #endregion

    #region エンティティVO

    /// <summary>
    /// エンティティBS_FUNCTION_AUTHORIZATIONに対応した項目のデータを管理するクラスです。
    /// </summary>
    [Serializable]
    public class FunctionAuthorizationVO : FunctionAuthorizationKey
    {
        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public FunctionAuthorizationVO()
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
            sb.Append("SolutionId:").Append(this.solutionId).AppendLine();
            sb.Append("FunctionId:").Append(this.functionId).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
        /// </summary>
        /// <returns>SystemAuthorizationVO</returns>
        public FunctionAuthorizationVO Copy()
        {
            FunctionAuthorizationVO vo = new FunctionAuthorizationVO();
            vo.RoleId = this.RoleId;
            vo.SolutionId = this.SolutionId;
            vo.FunctionId = this.FunctionId;

            return vo;
        }

        #endregion


    }
    #endregion 
}
