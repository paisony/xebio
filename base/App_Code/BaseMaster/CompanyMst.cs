// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.IO;
using System.Web.Services.Protocols;
using System.Web.Caching;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;

/// <summary>
/// 会社マスタテーブルからデータを取得するためのクラスです。
/// </summary>
public class CompanyMst
{
    #region フィールド

    /// <summary>
    /// キャッシュのアクセスキー
    /// </summary>
    private static object accessKey = new object();

    /// <summary>
    /// キャッシュに格納するときのキー
    /// </summary>
    private static readonly string cachekey = "CACHE_INTEGRATEDDB_COMPANY";

    #endregion

    #region コンストラクタ

    public CompanyMst()
    {
    }

    #endregion

    /// <summary>
    /// 会社の一覧を返す。
    /// </summary>
    /// <returns>
    /// データテーブル
    /// テーブル名：COMPANY
    /// カラム
    /// ・COMPANY_ID：会社ID
    /// ・COMPANY_NAME：会社名
    /// </returns>
    private static DataTable GetAllCompanyAndDeletedList()
    {
        Cache cache = HttpContext.Current.Cache;

        DataTable dt = (DataTable)cache.Get(cachekey);

        if (dt == null)
        {
            dt = SetChache();
        }
        return dt.Copy();
    }

    /// <summary>
    /// 会社の一覧を返す。
    /// </summary>
    /// <returns>
    /// データテーブル
    /// テーブル名：COMPANY
    /// カラム
    /// ・COMPANY_ID：会社ID
    /// ・COMPANY_NAME：会社名
    /// </returns>
    public static DataTable GetAllCompanyList()
    {
        DataTable dt = GetAllCompanyAndDeletedList();
        DataView dv = new DataView(dt);
        dv.RowFilter = "DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
        return dv.ToTable();
    }

    public static DataTable GetCompany(string companyId)
    {
        DataTable dt = GetAllCompanyAndDeletedList();
        DataView dv = new DataView(dt);
        dv.RowFilter = "COMPANY_ID = '" + companyId + "'";
        return dv.ToTable();
    }

    /// <summary>
    /// 指定の会社名を返す。
    /// </summary>
    /// <param name="companyId">会社ID</param>
    /// <returns>会社名
    /// </returns>
    public static string GetCompanyName(string companyId)
    {
        DataTable dt = GetCompany(companyId);
        if (dt.Rows.Count > 0)
            return Convert.ToString(dt.Rows[0]["COMPANY_NAME"]);
        else
            return null;
    }

    #region private
    private static DataTable SetChache()
    {
        Cache cache = HttpContext.Current.Cache;

        DataTable dt;
        lock (accessKey)
        {
            LoginUserInfoVO infoVO = new LoginUserInfoVO();
            infoVO.LoginId = LoginUserContext.LoginId;
            LoginUserService service = new LoginUserService(infoVO);

            DataResult<DataTable> res = service.GetAllCompany();

            if (!res.IsSuccess)
            {
                throw new ApplicationException("会社情報取得に失敗しました。");
            }
            dt = res.ResultData;

            cache.Insert(cachekey, dt, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
        }
        return dt;
    }
    #endregion
}
