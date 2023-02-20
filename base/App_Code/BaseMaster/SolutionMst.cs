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

/// <summary>
/// ソリューション,サブシステム情報を管理するクラスです。
/// </summary>
public static class SolutionMst
{
	#region フィールド

	/// <summary>
	/// キャッシュのアクセスキー
	/// </summary>
	private static object accessKey = new object();

	/// <summary>
	/// キャッシュに格納するときのキー
	/// </summary>
	private static readonly string cachekey = "CACHE_SOLUTION";

	#endregion

	/// <summary>
	/// ソリューション、サブシステム情報のキャッシュ
	/// </summary>
	/// <returns>ソリューション、サブシステム情報の詰まったデータテーブル</returns>
	public static DataTable GetAllSolution()
	{
		bool CacheFlag = false;
		if (ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION] == null
					|| Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION]) == true)
		{
			CacheFlag = true;
		}

		Cache cache = HttpContext.Current.Cache;
		DataTable dt = (DataTable)cache.Get(cachekey);
		if (dt == null || CacheFlag == false)
		{
			lock (accessKey)
			{
				SystemService service = new SystemService();
				DataResult<DataTable> res = service.GetAllSolutionAndSubSystem();

				if (res.IsSuccess)
					dt = res.ResultData.Copy();
				else
					throw new ApplicationException("ソリューション情報の取得に失敗しました。");

				cache.Insert(cachekey, dt, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
			}
		}
		return dt;
	}

	/// <summary>
	/// ソリューション、サブシステム情報のキャッシュ
	/// </summary>
	/// <param name="solutionId">ソリューションID</param>
	/// <param name="subsystemId">サブシステムID</param>
	/// <returns>ソリューション、サブシステム情報の詰まったデータテーブル</returns>
	public static DataTable GetSolution(string solutionId, string subsystemId)
	{
		DataTable dt = GetAllSolution();
		DataView dv = new DataView(dt);
		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "' AND SUBSYSTEM_ID = '" + subsystemId + "'";

		return dv.ToTable();
	}


	public static string GetServerUrl(string solutionId, string subSystemId)
	{
		DataTable dt = GetAllSolution();
		DataRow[] rows = dt.Select("SOLUTION_ID = '" + solutionId + "' AND SUBSYSTEM_ID = '" + subSystemId + "'");
		if (rows.Length == 0)
		{
			return null;
		}
		else
		{
			return Convert.ToString(rows[0]["SERVER_URL"]);
		}
	}

	/// <summary>
	/// キャッシュを削除します。
	/// </summary>
	public static void ClearCache()
	{
		lock (accessKey)
		{
			Cache cache = HttpContext.Current.Cache;
			cache.Remove(cachekey);
		}
	}

}
