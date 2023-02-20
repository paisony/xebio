// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT1障害対応[QA-0664]

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
using System.Xml;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Net;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Role;
using System.Web.Caching;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Systems.Util;
using Com.Fujitsu.SmartBase.DataIntegration.WcfClient.DataMgrLib;

/// <summary>
/// LoginMst の概要の説明です
/// </summary>
public class LoginMst
{
	#region フィールド

	/// <summary>
	/// キャッシュのアクセスキー
	/// </summary>
	private static object accessKey = new object();

	/// <summary>
	/// キャッシュに格納するときのキー
	/// </summary>
	private static readonly string cachekey = "CACHE_INTEGRATEDDB_SYSTEM_MANAGER";

	#endregion

	#region コンストラクタ

	LoginMst()
	{
	}

	#endregion
	/// <summary>
	/// 従業員情報の詰まったDataSetを返す。
	/// </summary>
	/// <param name="companyCode"></param>
	/// <param name="loginId"></param>
	/// <returns>
	/// Dictionary
	/// COMPANY_ID:会社ID
	/// TYPE:ユーザ種別
	/// USER_NAME:名前
	/// </returns>
	public static void SetLoginInfo(string loginId)
	{
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;

		LoginUserService service = new LoginUserService(infoVO);
		QueryObject query = new QueryObject();
		query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, loginId));
		DataResult<DataTable> res = service.FindLoginUser(query);
		if (!res.IsSuccess)
			throw new ApplicationException("ログインユーザ情報取得に失敗しました。");

		if (res.ResultData.Rows.Count > 0)
		{
			LoginUserContext.UserType = Convert.ToString(res.ResultData.Rows[0]["USER_TYPE"]);
			LoginUserContext.CompanyId = Convert.ToString(res.ResultData.Rows[0]["COMPANY_ID"]);
			LoginUserContext.Name = Convert.ToString(res.ResultData.Rows[0]["NAME"]);
			LoginUserContext.MappingId = Convert.ToString(res.ResultData.Rows[0]["MAPPING_ID"]);
			LoginUserContext.MenuPtnCd = Convert.ToString(res.ResultData.Rows[0]["MENU_PTN_CD"]);
			LoginUserContext.MenuFlag = Convert.ToString(res.ResultData.Rows[0]["MENU_PTN_CD"]);

			if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
			{
				//ロール情報取得 
				{
					DataResult<DataTable> res2 = null;
					if (LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
					{
						res2 = service.GetRoleUserMapByLoginId(loginId);
					}
					else
					{
						res2 = service.GetRoleUserMapByMenuPtnCd(LoginUserContext.MenuPtnCd);
					}

					if (!res2.IsSuccess)
						throw new ApplicationException("ロール情報取得に失敗しました。");

					LoginUserContext.RoleIds.Clear();
					foreach (DataRow row in res2.ResultData.Rows)
					{
						string roleId = Convert.ToString(row["ROLE_ID"]);
						LoginUserContext.RoleIds.Add(roleId);
					}

				}
			}
		}
		else
		{
			throw new ApplicationException("ログインユーザ情報が存在しません。");
		}

	}



	/// <summary>
	/// ID/PASSWORD入力者がログイン可能であるかチェックします。
	/// </summary>
	/// <param name="infoVo">ログイン者情報が格納されたvo</param>
	/// <param name="password">パスワード</param>
	/// <param name="userType">ユーザ権限</param>
	/// <returns>有効ならtrue</returns>
	public static Result CheckLoginAvailable(ExLoginUserInfoVO infoVo, string password, string userType)
	{
		LoginUserService service = new LoginUserService((LoginUserInfoVO)infoVo);
		return service.CheckLoginAvailable(infoVo, password, userType);
	}

	/// <summary>
	/// 運用時間内かチェックします。
	/// </summary>
	/// <param name="infoVo">ログイン者情報が格納されたvo</param>
	/// <param name="loginId">ログインＩＤ</param>
	/// <param name="userType">ユーザ権限</param>
	/// <returns>有効ならtrue</returns>
	public static Boolean CheckLoginAvailableOperation(ExLoginUserInfoVO infoVo, string loginId, string userType)
	{
		LoginUserService service = new LoginUserService((LoginUserInfoVO)infoVo);
		return service.CheckLoginAvailableOperation(infoVo, loginId, userType);
	}

	// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
	/// <summary>
	/// オンライン中かチェックします。
	/// </summary>
	/// <param name="infoVo">ログイン者情報が格納されたvo</param>
	/// <returns>有効ならtrue</returns>
	public static Boolean CheckLoginAvailableOnline(ExLoginUserInfoVO infoVo)
	{
		LoginUserService service = new LoginUserService((LoginUserInfoVO)infoVo);
		return service.CheckLoginAvailableOnline(infoVo);
	}
	// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  END ---------------

	#region システム管理者系
	/// <summary>
	/// システム管理者データ一覧を返す。
	/// </summary>
	/// <returns>
	/// データテーブル
	/// </returns>
	public static DataTable GetAllSystemManagerList()
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
	/// システム管理者のログインIDを返します。
	/// </summary>
	/// <param name="solutionId">ソリューションID</param>
	/// <returns></returns>
	public static string GetSystemManagerLoginId(string solutionId)
	{
		DataTable dt = GetAllSystemManagerList();
		DataView dv = new DataView(dt);
		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "'";

		if (dv.Count > 0)
		{
			return Convert.ToString(dv[0]["LOGIN_ID"]);
		}
		else
			return null;
	}

	/// <summary>
	/// システム管理者のパスワードを返します。
	/// </summary>
	/// <param name="solutionId">ソリューションID</param>
	/// <returns></returns>
	public static string GetSystemManagerPassword(string solutionId)
	{
		DataTable dt = GetAllSystemManagerList();
		DataView dv = new DataView(dt);
		dv.RowFilter = "SOLUTION_ID = '" + solutionId + "'";

		if (dv.Count > 0)
		{
			return Convert.ToString(dv[0]["PASSWORD"]);
		}
		else
			return null;
	}
	#endregion

	#region private
	private static DataTable SetChache()
	{
		Cache cache = HttpContext.Current.Cache;

		DataTable res = new DataTable("LOGIN");
		res.Columns.Add(new DataColumn("SOLUTION_ID"));
		res.Columns.Add(new DataColumn("LOGIN_ID"));
		res.Columns.Add(new DataColumn("PASSWORD"));
		res.Columns.Add(new DataColumn("LOGIN_NAME"));
		res.Columns.Add(new DataColumn("LOGIN_NAME_KANA"));

		lock (accessKey)
		{
			try
			{
				if (SystemSettings.SynchroMode == SystemsConstantUtil.SYNCHRO_ON)
				{
					DataMgrClient clinet = new DataMgrClient();
					string xmlstr = clinet.GetData("SystemLogin", SystemSettings.AspCode, null, FormatUtil.GetFormatId("SystemLogin", true));

					if (!string.IsNullOrEmpty(xmlstr))
					{
						XmlDocument xdoc = new XmlDocument();
						xdoc.LoadXml(xmlstr);
						XmlNodeList nodes = xdoc.GetElementsByTagName("smart_data_list");
						DataSet ds = new DataSet();
						if (nodes.Count > 0)
						{
							using (StringReader strdr = new StringReader(nodes[0].OuterXml))
							{
								ds.ReadXml(strdr);
							}
						}

						//データを詰める
						if (ds.Tables.Contains("LOGIN"))
						{
							foreach (DataRow row in ds.Tables["LOGIN"].Rows)
							{
								DataRow resRow = res.NewRow();
								SetRowData(resRow, row, "SOLUTION_ID");
								SetRowData(resRow, row, "LOGIN_ID");
								SetRowData(resRow, row, "PASSWORD");
								SetRowData(resRow, row, "LOGIN_NAME");
								SetRowData(resRow, row, "LOGIN_NAME_KANA");
								res.Rows.Add(resRow);
							}
						}

					}
				}

				cache.Insert(cachekey, res, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);

			}
			catch (SoapException ex)
			{
				throw new WebServiceException("システム管理者情報取得に失敗しました。", ex);
			}

		}
		return res;
	}

	private static void SetRowData(DataRow row1, DataRow row2, string colName)
	{
		if (row2.Table.Columns.Contains(colName))
			row1[colName] = row2[colName];
	}

	#endregion
}
