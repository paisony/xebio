// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Common.Util;

/// <summary>
/// 機能表示階層情報を管理するクラスです。
/// </summary>
public class FunctionViewMst
{
	#region フィールド

	/// <summary>
	/// キャッシュのアクセスキー
	/// </summary>
	private static object accessKey = new object();

	/// <summary>
	/// キャッシュに格納するときのキー
	/// </summary>
	private static readonly string funccachekey = "CACHE_FUNCTION_VIEW";

	#endregion

	#region コンストラクタ

	public FunctionViewMst()
	{
	}

	#endregion

	/// <summary>
	/// 機能表示階層情報のキャッシュ
	/// </summary>
	/// <returns>機能表示階層情報の詰まったデータテーブル</returns>
	public static DataTable GetAllFunctionView()
	{
		bool CacheFlag = false;
		if (ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION] == null
					|| Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION]) == true)
		{
			CacheFlag = true;
		}

		Cache cache = HttpContext.Current.Cache;
		DataTable dt = (DataTable)cache.Get(funccachekey);
		if (dt == null || CacheFlag == false)
		{
			lock (accessKey)
			{
				SystemService service = new SystemService();
				DataResult<DataTable> res = service.GetAllFunctionView();

				if (res.IsSuccess)
				{
					dt = res.ResultData.Copy();
				}
				else
					throw new ApplicationException("機能表示階層情報の取得に失敗しました。");

				cache.Insert(funccachekey, dt, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
			}
		}
		return dt;
	}

	public static DataTable GetFunctionView(string solutionId, string functionViewId)
	{
		DataTable dt = GetAllFunctionView();
		DataView dv = new DataView(dt);
		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "' AND FUNCTION_VIEW_ID = '" + functionViewId + "'";
		dv.Sort = "SORT_NO";

		return dv.ToTable();
	}

	public static DataTable GetFunctionView(string solutionId, int level, bool isAdmin)
	{
		DataTable dt = GetAllFunctionView();
		DataView dv = new DataView(dt);
		string adminflg;
		if (isAdmin)
			adminflg = WebConstantUtil.FUNCTION_VIEW_ADMIN;
		else
			adminflg = WebConstantUtil.FUNCTION_VIEW_GENERAL;

		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "' AND LEVEL_NO = " + level + " AND ADMIN_FLAG = '" + adminflg + "'";
		dv.Sort = "SORT_NO";

		return dv.ToTable();
	}

	public static DataTable GetChilds(string solutionId, string functionViewId)
	{
		DataTable dt = GetAllFunctionView();
		DataView dv = new DataView(dt);
		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "' AND PARENT_VIEW_ID = '" + functionViewId + "'";
		dv.Sort = "SORT_NO";

		return dv.ToTable();
	}

	/// <summary>
	/// キャッシュを削除します。
	/// </summary>
	public static void ClearCache()
	{
		lock (accessKey)
		{
			Cache cache = HttpContext.Current.Cache;
			cache.Remove(funccachekey);
		}
	}

}
