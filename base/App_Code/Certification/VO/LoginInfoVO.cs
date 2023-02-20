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
	/// エンティティBS_LOGIN_INFOの主キーを表すクラス
	/// </summary>
	[Serializable]
	public class LoginInfoKey : IPrimaryKey
	{
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginInfoKey()
		{
		}

		/// <summary>
		/// すべての列を明示的に初期化します。
		/// </summary>
		/// <param name="loginInfoId">列「LOGIN_INFO_ID」の値</param>
		public LoginInfoKey(
			string loginInfoId)
		{
			this.loginInfoId = loginInfoId;
		}
		#endregion

		#region フィールド
		/// <summary>
		/// 列「LOGIN_INFO_ID(LOGIN_INFO_ID)」の値
		/// </summary>
		protected string loginInfoId;
		#endregion

		#region プロパティ
		/// <summary>
		/// 列「LOGIN_INFO_ID」の値を取得または設定する
		/// </summary>
		public string LoginInfoId
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

		#endregion

		#region IPrimaryKey メンバ

		/// <summary>
		/// Entityの主キー列の列名と値のペアを取得します。
		/// </summary>
		/// <returns>主キー列名/値の配列</returns>
		public KeyValuePair<string, object>[] GetPrimayKeyValues()
		{
			return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("LOGIN_INFO_ID",loginInfoId)
			};
		}

		#endregion
	}

	#endregion

	#region エンティティVO

	/// <summary>
	///  エンティティBS_LOGIN_INFOに対応したValueObjectです。
	/// </summary>
	[Serializable]
	public class LoginInfoVO : LoginInfoKey
	{
		#region フィールド

		/// <summary>
		/// 列「COMPANY_ID(COMPANY_ID)」の値
		/// </summary>
		private string companyId;

		/// <summary>
		/// 列「LOGIN_ID(LOGIN_ID)」の値
		/// </summary>
		private string loginId;

		/// <summary>
		/// 列「USER_LANGUAGE(USER_LANGUAGE)」の値
		/// </summary>
		private string userLanguage;

		/// <summary>
		/// 列「MENU_PTN_CD(MENU_PTN_CD)」の値
		/// </summary>
		private string menuPtnCd;

		/// <summary>
		/// 列「LOGIN_DATETIME(LOGIN_DATETIME)」の値
		/// </summary>
		private DateTime? loginDatetime;

		/// <summary>
		/// 列「ACCESS_DATETIME(ACCESS_DATETIME)」の値
		/// </summary>
		private DateTime? accessDatetime;

		#region プロパティ

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
		/// 列「USER_LANGUAGE」の値を取得または設定する
		/// </summary>
		public string UserLanguage
		{
			get
			{
				return userLanguage;
			}
			set
			{
				userLanguage = value;
			}
		}

		/// <summary>
		/// 列「MENU_PTN_CD」の値を取得または設定する
		/// </summary>
		public string MenuPtnCd
		{
			get
			{
				return menuPtnCd;
			}
			set
			{
				menuPtnCd = value;
			}
		}

		/// <summary>
		/// 列「LOGIN_DATETIME」の値を取得または設定する
		/// </summary>
		public DateTime? LoginDatetime
		{
			get
			{
				return loginDatetime;
			}
			set
			{
				loginDatetime = value;
			}
		}

		/// <summary>
		/// 列「ACCESS_DATETIME」の値を取得または設定する
		/// </summary>
		public DateTime? AccessDatetime
		{
			get
			{
				return accessDatetime;
			}
			set
			{
				accessDatetime = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginInfoVO()
		{
		}

		#endregion

		#region メソッド
		/// <summary>
		/// 現在のLoginInfoVOを表すSystem.Stringを返します。
		/// </summary>
		/// <returns>現在のLoginInfoVOを表すSystem.String。</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("LoginInfoId:").Append(this.loginInfoId).AppendLine();
			sb.Append("CompanyId:").Append(this.companyId).AppendLine();
			sb.Append("UserId:").Append(this.loginId).AppendLine();
			sb.Append("User_language:").Append(this.userLanguage).AppendLine();
			sb.Append("Menu_Ptn_Cd:").Append(this.menuPtnCd).AppendLine();
			sb.Append("Login_datetime:").Append(this.loginDatetime).AppendLine();
			sb.Append("Access_datetime:").Append(this.accessDatetime).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VOのコピーを返します。
		/// </summary>
		/// <returns>LoginInfoVO</returns>
		public LoginInfoVO Copy()
		{
			LoginInfoVO vo = new LoginInfoVO();
			vo.LoginInfoId = this.LoginInfoId;
			vo.CompanyID = this.CompanyID;
			vo.LoginID = this.LoginID;
			vo.UserLanguage = this.UserLanguage;
			vo.MenuPtnCd = this.MenuPtnCd;
			vo.LoginDatetime = this.LoginDatetime;
			vo.AccessDatetime = this.AccessDatetime;

			return vo;
		}

		#endregion

		#endregion

	}

	#endregion
}

