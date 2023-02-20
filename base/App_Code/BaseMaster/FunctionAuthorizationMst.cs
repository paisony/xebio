// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Role;

/// <summary>
/// 機能の使用許可情報を管理するクラスです。
/// </summary>
public class FunctionAuthorizationMst
{
	#region フィールド

	/// <summary>
	/// キャッシュのアクセスキー
	/// </summary>
	private static object accessKey = new object();

	/// <summary>
	/// キャッシュに格納するときのキー
	/// </summary>
	private static readonly string funccachekey = "CACHE_FUNCTION_AUTHORIZATION";

	#endregion

	#region コンストラクタ

	public FunctionAuthorizationMst()
	{
	}

	#endregion

	/// <summary>
	/// 機能使用許可情報のキャッシュ
	/// </summary>
	/// <returns>機能使用許可情報の詰まったデータテーブル</returns>
	public static DataTable GetAllFunctionAuthorization()
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
				LoginUserInfoVO infoVO = new LoginUserInfoVO();
				infoVO.LoginId = LoginUserContext.LoginId;
				RoleService service = new RoleService(infoVO);
				DataResult<DataTable> res = service.GetAllFunctionAuthorization();

				if (res.IsSuccess)
					dt = res.ResultData.Copy();
				else
					throw new ApplicationException("機能使用許可情報の取得に失敗しました。");

				cache.Insert(funccachekey, dt, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
			}
		}
		return dt;
	}

	/// <summary>
	/// 機能使用許可情報を返します。
	/// <param name="roleId"></param>
	/// <param name="solutionId"></param>
	/// <param name="functionId"></param>
	/// </summary>
	/// <returns></returns>
	public static bool CheckFunctionAuthorization(string roleId, string solutionId, string functionId)
	{
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		RoleService service = new RoleService(infoVO);
		DataResult<DataTable> res = service.GetFunctionAuthorization(roleId, solutionId, functionId);
		if (res.ResultData.Rows.Count > 0)
		{
			return true;
		}
		else
		{
			return false;
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

}
