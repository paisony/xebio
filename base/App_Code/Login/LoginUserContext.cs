// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Web;

/// <summary>
/// ログイン者の情報格納クラスです。
/// </summary>
[Serializable]
public class LoginUserContext
{
	#region プロパティ

	/// <summary>
	/// ログイン情報ID（基盤の認証に使用される）
	/// </summary>
	public static string LoginInfoId
	{
		get
		{
			return Convert.ToString(GetSessionData("LoginInfoId"));
		}
		set
		{
			SetSessionData("LoginInfoId", value);
		}
	}

	/// <summary>
	/// ユーザ種別
	/// 0:従業員
	/// 1:システム管理者
	/// </summary>
	public static string UserType
	{
		get
		{
			return Convert.ToString(GetSessionData("UserType"));
		}
		set
		{
			SetSessionData("UserType", value);
		}
	}

	/// <summary>
	/// 企業ID
	/// </summary>
	public static string CompanyId
	{
		get
		{
			return Convert.ToString(GetSessionData("CompanyId"));
		}
		set
		{
			SetSessionData("CompanyId", value);
		}
	}

	/// <summary>
	/// ログインID（SSO認証用）
	/// </summary>
	public static string LoginId
	{
		get
		{
			return Convert.ToString(GetSessionData("LoginId"));
		}
		set
		{
			SetSessionData("LoginId", value);
		}
	}

	/// <summary>
	/// パスワード（SSO認証用）
	/// </summary>
	public static string Password
	{
		get
		{
			return Convert.ToString(GetSessionData("Password"));
		}
		set
		{
			SetSessionData("Password", value);
		}
	}

	/// <summary>
	/// 名前
	/// </summary>
	public static string Name
	{
		get
		{
			return Convert.ToString(GetSessionData("Name"));
		}
		set
		{
			SetSessionData("Name", value);
		}
	}

	/// <summary>
	/// メニューフラグ
	/// </summary>
	public static string MenuFlag
	{
		get
		{
			return Convert.ToString(GetSessionData("MenuFlag"));
		}
		set
		{
			SetSessionData("MenuFlag", value);
		}
	}

	/// <summary>
	/// マッピングＩＤ
	/// </summary>
	public static string MappingId
	{
		get
		{
			return Convert.ToString(GetSessionData("MappingId"));
		}
		set
		{
			SetSessionData("MappingId", value);
		}
	}

	/// <summary>
	/// メニューパターンＣＤ
	/// </summary>
	public static string MenuPtnCd
	{
		get
		{
			return Convert.ToString(GetSessionData("MenuPtnCd"));
		}
		set
		{
			SetSessionData("MenuPtnCd", value);
		}
	}

	/// <summary>
	/// 言語
	/// </summary>
	public static string Language
	{
		get
		{
			return Convert.ToString(GetSessionData("Language"));
		}
		set
		{
			SetSessionData("Language", value);
		}
	}

	public static List<string> RoleIds
	{
		get
		{
			object obj = GetSessionData("RoleIds");
			if (obj != null)
				return (List<string>)obj;
			else
			{
				obj = new List<string>();
				SetSessionData("RoleIds", obj);
				return (List<string>)obj;
			}
		}
		set
		{
			SetSessionData("RoleIds", value);
		}
	}

	#endregion

	#region メソッド

	public static void Clear()
	{
		SessionManager.SessionRemove(WebConstantUtil.LOGIN_INFO_SESSION_KEY);
	}

	#endregion

	#region プライベート

	private static void SetSessionData(string key, object value)
	{
		Dictionary<string, object> dic = (Dictionary<string, object>)SessionManager.GetObject(WebConstantUtil.LOGIN_INFO_SESSION_KEY);
		if (dic == null)
		{
			dic = new Dictionary<string, object>();
			dic.Add(key, value);
			SessionManager.SetObject(dic, WebConstantUtil.LOGIN_INFO_SESSION_KEY);
		}
		else
		{
			dic[key] = value;
		}
	}

	private static object GetSessionData(string key)
	{
		Dictionary<string, object> dic = (Dictionary<string, object>)SessionManager.GetObject(WebConstantUtil.LOGIN_INFO_SESSION_KEY);
		if (dic == null)
		{
			dic = new Dictionary<string, object>();
			return null;
		}
		else
		{
			if (dic.ContainsKey(key))
				return dic[key];
			else
				return null;
		}
	}

	#endregion
}
