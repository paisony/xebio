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
    /// エンティティBS_LOGIN_FAILUREの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class LoginFailureKey : IPrimaryKey
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public LoginFailureKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="login">列「LOGIN_ID」の値</param>
        public LoginFailureKey(
            string loginId)
        {
            this.loginId = loginId;
  
        }
        #endregion

        #region フィールド
        /// <summary>
        /// 列「LOGIN_ID」の値
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
                new KeyValuePair<string, object>("LOGIN_ID", loginId)
            };

        }

        #endregion
    }

    #endregion

    #region エンティティVO

    /// <summary>
    ///  エンティティBS_LOGIN_FAILUREに対応したValueObjectです。
    /// </summary>
    [Serializable]
    public class LoginFailureVO : LoginFailureKey
    {
        /// <summary>
        /// 列「FAILURE_COUNT(FAILURE_COUN)」の値
        /// </summary>
        private int failureCount;

        #region プロパティ

        /// <summary>
        /// 列「FAILURE_COUN」の値を取得または設定する
        /// </summary>
        public int FailureCount
        {
            get
            {
                return failureCount;
            }
            set
            {
                failureCount = value;
            }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public LoginFailureVO()
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 現在のLoginFailureVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のLoginFailureVOを表すSystem.String。</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginId:").Append(this.loginId).AppendLine();
            sb.Append("FailureCount:").Append(this.failureCount).AppendLine();
            
            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
        /// </summary>
        /// <returns>LoginFailureVO</returns>
        public LoginFailureVO Copy()
        {
            LoginFailureVO vo = new LoginFailureVO();

            vo.LoginId = this.LoginId;
            vo.FailureCount = this.FailureCount;
            return vo;
        }

        #endregion

    }

    #endregion
}
