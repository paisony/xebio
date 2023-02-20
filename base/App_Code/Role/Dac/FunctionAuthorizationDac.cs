// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Role.Dac
{
	public class FunctionAuthorizationDac : BaseDac
	{
		#region コンストラクタ
		public FunctionAuthorizationDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// SelectByRoleId
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public DataTable SelectByRoleId(OracleCommand cmd, string roleId)
		{
			string query = @"SELECT * FROM BS_FUNCTION_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, roleId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// SelectAll
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = @"SELECT * FROM BS_FUNCTION_AUTHORIZATION";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Selectrole
		/// <summary>
		/// Selectrole
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="roleId"></param>
		/// <param name="solutionId"></param>
		/// <param name="functionId"></param>
		/// <returns></returns>
		public DataTable Selectrole(OracleCommand cmd, string roleId, string solutionId, string functionId)
		{
			string query = @"SELECT * FROM BS_FUNCTION_AUTHORIZATION  WHERE ROLE_ID = '" + roleId + "' AND SOLUTION_ID = '" + solutionId + "' AND FUNCTION_ID = '" + functionId + "'";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion
		#region Selectrole2
		/// <summary>
		/// Selectrole
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="roleId"></param>
		/// <param name="solutionId"></param>
		/// <param name="functionId"></param>
		/// <returns></returns>
		public DataTable Selectrole2(OracleCommand cmd, string roleId, string solutionId, string functionId)
		{
			string query = @"SELECT * FROM BS_FUNCTION_AUTHORIZATION a ,BS_ROLE_USER_MAP b WHERE a.ROLE_ID = b.ROLE_ID "
						+ " AND b.LOGIN_ID = '" + roleId + "' AND SUBSTR(a.FUNCTION_ID,1,8) = '" + functionId + "'";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったFunctionAuthorizationVO</param>
		/// <returns>更新レコード数</returns>
		public int Insert(DbCommand cmd, FunctionAuthorizationVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_FUNCTION_AUTHORIZATION (ROLE_ID,SOLUTION_ID,FUNCTION_ID) VALUES ( "
						+ ProviderUtil.GetParameterName("ROLE_ID", providerType) + ","
						+ ProviderUtil.GetParameterName("SOLUTION_ID", providerType) + ","
						+ ProviderUtil.GetParameterName("FUNCTION_ID", providerType) + ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, vo.RoleId));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionId));
			//FUNCTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, vo.FunctionId));

			//追加
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったFunctionAuthorizationKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(DbCommand cmd, FunctionAuthorizationKey key)
		{
			cmd.CommandText = @"DELETE FROM BS_FUNCTION_AUTHORIZATION WHERE ROLE_ID = "
						+ ProviderUtil.GetParameterName("ROLE_ID", providerType)
						+ " AND SOLUTION_ID = " + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
						+ " AND FUNCTION_ID = " + ProviderUtil.GetParameterName("FUNCTION_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, key.RoleId));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, key.SolutionId));
			//FUNCTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, key.FunctionId));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteByRoleId
		/// <summary>
		/// ロールIDをキーにしてDELETEします。
		/// </summary>
		/// <param name="roleId">ロールID</param>
		/// <returns>削除レコード数</returns>
		public int DeleteByRoleId(DbCommand cmd, string roleId)
		{
			cmd.CommandText = @"DELETE FROM BS_FUNCTION_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType);

			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, roleId));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
