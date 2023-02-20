using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Common.Config;

/// <summary>
/// 機能情報情報を管理するクラスです。
/// </summary>
public class FunctionMst
{
	#region フィールド

	/// <summary>
	/// キャッシュのアクセスキー
	/// </summary>
	private static object accessKey = new object();

	/// <summary>
	/// キャッシュに格納するときのキー
	/// </summary>
	private static readonly string funccachekey = "CACHE_FUNCTION";

	#endregion

	#region コンストラクタ

	public FunctionMst()
	{
	}

	#endregion

	/// <summary>
	/// 機能情報のキャッシュ
	/// </summary>
	/// <returns>機能情報の詰まったデータテーブル</returns>
	public static DataTable GetAllFunction()
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
				DataResult<DataTable> res = service.GetAllFunction();

				if (res.IsSuccess)
					dt = res.ResultData.Copy();
				else
					throw new ApplicationException("機能情報の取得に失敗しました。");

				cache.Insert(funccachekey, dt, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
			}
		}
		return dt;
	}

	/// <summary>
	/// 機能情報の読込み
	/// <param name="solutionId"></param>
	/// <param name="functionId"></param>
	/// </summary>
	/// <returns>機能情報の詰まったデータテーブル</returns>
	public static DataRow GetFunction(string solutionId, string functionId)
	{
		SystemService service = new SystemService();
		DataResult<DataTable> res = service.GetFunction(solutionId, functionId);
		DataTable dt = null;
		if (res.IsSuccess)
		{
			dt = res.ResultData.Copy();
			DataRow rows = dt.Rows[0];
			return rows;
		}
		else
		{
			return null;
		}
	}

	/// <summary>
	/// 機能の読込み（機能ＩＤのみ）
	/// </summary>
	/// <param name="solutionId"></param>
	/// <param name="functionId"></param>
	/// <returns></returns>
	public static DataRow GetFunction(string functionId)
	{
		DataTable dt = GetAllFunction();
		DataRow[] rows = dt.Select("FUNCTION_ID = '" + functionId + "'");
		if (rows.Length == 0)
		{
			return null;
		}
		else
		{
			return rows[0];
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
			cache.Remove(funccachekey);
		}
	}

	/// <summary>
	/// 機能のシステム種別を取得します。
	/// </summary>
	/// <param name="solutionId">ソリューションID</param>
	/// <param name="functionId">機能ID</param>
	/// <returns>システム種別</returns>
	public static string GetFunctionSystemType(string solutionId, string functionId)
	{
		DataRow row = GetFunction(solutionId, functionId);
		if (row != null)
		{
			string subsystemId = Convert.ToString(row["SUBSYSTEM_ID"]);
			DataTable dt = SolutionMst.GetSolution(solutionId, subsystemId);
			if (dt.Rows.Count > 0)
			{
				return Convert.ToString(dt.Rows[0]["SUBSYSTEM_TYPE"]);
			}
			else
				throw new ApplicationException("ソリューション情報の取得に失敗しました。");

		}
		else
			throw new ApplicationException("機能情報の取得に失敗しました。");

	}

}
