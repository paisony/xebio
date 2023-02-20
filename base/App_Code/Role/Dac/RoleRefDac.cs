// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Role.Dac
{
	public class RoleRefDac : BaseDac
	{
		#region コンストラクタ

		public RoleRefDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion
		
		/// <summary>
		/// GetRoleUserByRoleId
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public DataTable GetRoleUserByRoleId(OracleCommand cmd, string roleId)
		{
			string query = @"SELECT B.* FROM BS_ROLE_USER_MAP A INNER JOIN BS_LOGIN_USER B ON A.LOGIN_ID = B.LOGIN_ID WHERE B.DELETE_FLAG = "
												  + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
							+ " AND A.ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
							+ " ORDER BY B.LOGIN_ID";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//DELETE_FLAG
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_OFF));
			//ROLE_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, roleId));

			//Fill
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			return dt;
		}

		/// <summary>
		/// 会社ＩＤを元にロール付与状況を取得します。
		/// </summary>
		/// <param name="companyId"></param>
		/// <returns></returns>
		public DataTable GetRoleMappingStatusByCompanyId(OracleCommand cmd, string companyId)
		{
			StringBuilder query = new StringBuilder();
			if (providerType == ProviderType.SqlClient)
			{
				query.Append(@"SELECT USR.[LOGIN_ID] ""利用者ID""
						,USR.[NAME] ""利用者名""
						,MAP.[ROLE_ID] ""ロールID""
						,SOL.[SOLUTION_ID] ""ソリューションID""
						,SOL.[SOLUTION_NAME] ""ソリューション名""
						,FUNC.[FUNCTION_ID] ""メニューID""
						,FUNC.[FUNCTION_NAME] ""メニュー名""
						 FROM BS_LOGIN_USER USR
						 JOIN BS_ROLE_USER_MAP MAP ON USR.LOGIN_ID = MAP.LOGIN_ID 
						 JOIN BS_FUNCTION_AUTHORIZATION FUNC_AUTH ON MAP.ROLE_ID = FUNC_AUTH.ROLE_ID 
						 JOIN BS_SOLUTION SOL ON SOL.SOLUTION_ID = FUNC_AUTH.SOLUTION_ID
						 JOIN BS_FUNCTION FUNC ON FUNC.SOLUTION_ID = FUNC_AUTH.SOLUTION_ID AND FUNC.FUNCTION_ID = FUNC_AUTH.FUNCTION_ID ");
				if (!string.IsNullOrEmpty(companyId))
				{
					query.Append(@"WHERE USR.[COMPANY_ID] = " + ProviderUtil.GetParameterName("COMPANY_ID", providerType));
				}
				query.Append(@" ORDER BY 利用者ID");
			}
			else
			{
				query.Append(@"SELECT
								 USR.LOGIN_ID       AS 利用者ID
								,USR.NAME           AS 利用者名
								,MAP.ROLE_ID        AS ロールID
								,SOL.SOLUTION_ID    AS ソリューションID
								,SOL.SOLUTION_NAME  AS ソリューション名
								,FUNC.FUNCTION_ID   AS メニューID
								,FUNC.FUNCTION_NAME AS メニュー名
				FROM BS_LOGIN_USER USR
					JOIN BS_ROLE_USER_MAP MAP 		ON USR.LOGIN_ID = MAP.LOGIN_ID 
					JOIN BS_FUNCTION_AUTHORIZATION FUNC_AUTH 		ON MAP.ROLE_ID = FUNC_AUTH.ROLE_ID 
					JOIN BS_SOLUTION SOL 		ON SOL.SOLUTION_ID = FUNC_AUTH.SOLUTION_ID
					JOIN BS_FUNCTION FUNC		ON FUNC.SOLUTION_ID = FUNC_AUTH.SOLUTION_ID AND FUNC.FUNCTION_ID = FUNC_AUTH.FUNCTION_ID ");

				if (!string.IsNullOrEmpty(companyId))
				{
					query.Append(@" WHERE USR.COMPANY_ID = " + ProviderUtil.GetParameterName("COMPANY_ID", providerType));
				}
				query.Append(@" ORDER BY 利用者ID ");
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query.ToString();
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			if (!string.IsNullOrEmpty(companyId))
			{
				//パラメータをセット
				//COMPANY_ID
				adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, companyId));
			}

			//Fill
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			return dt;
		}
	}
}
