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
public class PageUrlContext
{
	#region プロパティ

	/// <summary>
	/// 遷移先URL
	/// </summary>
	public static string Url
	{
		get
		{
			return Convert.ToString(GetSessionData("Url"));
		}
		set
		{
			SetSessionData("Url", value);
		}
	}

	/// <summary>
	/// 遷移先ホスト
	/// </summary>
	public static string Host
	{
		get
		{
			return Convert.ToString(GetSessionData("Host"));
		}
		set
		{
			SetSessionData("Host", value);
		}
	}

	/// <summary>
	/// 遷移先アプリ
	/// </summary>
	public static string Application
	{
		get
		{
			return Convert.ToString(GetSessionData("Application"));
		}
		set
		{
			SetSessionData("Application", value);
		}
	}

	/// <summary>
	/// 遷移先機能フォルダ
	/// </summary>
	public static string Function
	{
		get
		{
			return Convert.ToString(GetSessionData("Function"));
		}
		set
		{
			SetSessionData("Function", value);
		}
	}

	/// <summary>
	/// 遷移先ページ名
	/// </summary>
	public static string PageName
	{
		get
		{
			return Convert.ToString(GetSessionData("PageName"));
		}
		set
		{
			SetSessionData("PageName", value);
		}
	}

	#endregion

	#region プライベート

	private static void SetSessionData(string key, object value)
	{
		Dictionary<string, object> dic = (Dictionary<string, object>)SessionManager.GetObject(WebConstantUtil.PAGE_URL_SESSION_KEY);
		if (dic == null)
		{
			dic = new Dictionary<string, object>();
			dic.Add(key, value);
			SessionManager.SetObject(dic, WebConstantUtil.PAGE_URL_SESSION_KEY);
		}
		else
		{
			dic[key] = value;
		}
	}

	private static object GetSessionData(string key)
	{
		Dictionary<string, object> dic = (Dictionary<string, object>)SessionManager.GetObject(WebConstantUtil.PAGE_URL_SESSION_KEY);
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
