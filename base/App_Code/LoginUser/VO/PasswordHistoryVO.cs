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
    /// エンティティBS_PASSWORD_HISTORYの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class PasswordHistoryKey : IPrimaryKey
    {
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public PasswordHistoryKey()
		{
		}

		/// <summary>
		/// すべての列を明示的に初期化します。
		/// </summary>
        /// <param name="loginId">列「LOGIN_ID」の値</param>
		/// <param name="updateDatetime">列「UPDATE_DATETIME」の値</param>
        public PasswordHistoryKey(
			string loginId,
            DateTime? updateDatetime)
		{
            this.loginId = loginId;
            this.updateDatetime = updateDatetime;
		}
		#endregion
		
		#region フィールド

		/// <summary>
        /// 列「LOGIN_ID」の値
		/// </summary>
		protected string loginId;

		/// <summary>
        /// 列「UPDATE_DATETIME」の値
		/// </summary>
		protected DateTime? updateDatetime;

		#endregion

		#region プロパティ

		/// <summary>
        /// 列「LOGIN_ID」の値を取得または設定する
		/// </summary>
		public string LoginID
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
		/// 列「LOG_DATETIME」の値を取得または設定する
		/// </summary>
		public DateTime? UpdateDatetime
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

		#endregion

		#region IPrimaryKey メンバ

		/// <summary>
		/// Entityの主キー列の列名と値のペアを取得します。
		/// </summary>
		/// <returns>主キー列名/値の配列</returns>
		public KeyValuePair<string, object>[] GetPrimayKeyValues()
		{
			return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("LOGIN_ID",loginId),
				new KeyValuePair<string, object>("UPDATE_DATETIME",updateDatetime),
			};
		}

		#endregion
    }

    #endregion


    #region エンティティVO

    /// <summary>
    ///  エンティティBS_PASSWORD_HISTORYに対応したValueObjectです。
    /// </summary>
    [Serializable]
    public class PasswordHistoryVO : PasswordHistoryKey
    {
        #region フィールド

        /// <summary>
        /// 列「PASSWORD」の値
        /// </summary>
        protected string password;

        #endregion

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

        #endregion

        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public PasswordHistoryVO()
        {
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 現在のPasswordHistoryVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のPasswordHistoryVOを表すSystem.String。</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LoginID:").Append(this.loginId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("Password:").Append(this.password).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
        /// </summary>
        /// <returns>プロパティ値がコピーされたPasswordHistoryVO</returns>
        public PasswordHistoryVO Copy()
        {
            PasswordHistoryVO vo = new PasswordHistoryVO();
            vo.LoginID = this.LoginID;
            vo.UpdateDatetime = this.UpdateDatetime;
            vo.Password = this.Password;

            return vo;
        }

        #endregion

    }

    #endregion
}
