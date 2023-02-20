// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	#region 主キーオブジェクト

	/// <summary>
	/// エンティティBS_LOGIN_CERTの主キーを表すクラス
	/// </summary>
    [Serializable]
	public class LoginCertKey : IPrimaryKey
	{
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginCertKey()
		{
		}

		/// <summary>
		/// すべての列を明示的に初期化します。
		/// </summary>
		/// <param name="loginCertId">列「LOGIN_CERT_ID」の値</param>
		public LoginCertKey(
			string loginCertId		)
		{
			this.loginCertId = loginCertId;
		}
		#endregion
		
		#region フィールド
		/// <summary>
		/// 列「LOGIN_CERT_ID(LOGIN_CERT_ID)」の値
		/// </summary>
		protected string loginCertId;
		#endregion

		#region プロパティ
		/// <summary>
		/// 列「LOGIN_CERT_ID」の値を取得または設定する
		/// </summary>
		public string LoginCertID
		{
			get
			{
				return loginCertId;
			}
			set
			{
				loginCertId = value;
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
				new KeyValuePair<string, object>("LOGIN_CERT_ID",loginCertId)
			};
		}

		#endregion
	}

	#endregion

	#region エンティティVO

	/// <summary>
	///  エンティティBS_LOGIN_CERTに対応したValueObjectです。
	/// </summary>
    [Serializable]
	public class  LoginCertVO : LoginCertKey
	{
		#region フィールド

		/// <summary>
		/// 列「LOGIN_INFO_ID(LOGIN_INFO_ID)」の値
		/// </summary>
		private string loginInfoId;

		/// <summary>
		/// 列「SOLUTION_ID(SOLUTION_ID)」の値
		/// </summary>
		private string solutionId;

		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginCertVO()
		{
		}
		#endregion

        #region プロパティ

        /// <summary>
        /// 列「LOGIN_INFO_ID」の値を取得または設定する
        /// </summary>
        public string LoginInfoID
        {
            get
            {
                return loginInfoId;
            }
            set
            {
                loginInfoId = value;
            }
        }

        /// <summary>
        /// 列「SOLUTION_ID」の値を取得または設定する
        /// </summary>
        public string SolutionID
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

        #endregion
		
		#region メソッド
		/// <summary>
		/// 現在のLoginCertVOを表すSystem.Stringを返します。
		/// </summary>
		/// <returns>現在のLoginCertVOを表すSystem.String。</returns>
		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();

			sb.Append("Login_cert_id:").Append(this.loginCertId).AppendLine();
			sb.Append("Login_info_id:").Append(this.loginInfoId).AppendLine();
			sb.Append("Solution_id:").Append(this.solutionId).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VOのコピーを返します。
		/// </summary>
		/// <returns>LoginCertVO</returns>
		public LoginCertVO Copy()
		{
			LoginCertVO vo = new LoginCertVO();
            vo.LoginCertID = this.LoginCertID;
            vo.LoginInfoID = this.LoginCertID;
            vo.SolutionID = this.LoginCertID;
			return vo;
        }

		#endregion

	}

	#endregion
}

