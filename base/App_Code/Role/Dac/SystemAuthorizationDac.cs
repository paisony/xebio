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
	public class SystemAuthorizationDac : BaseDac
	{
		#region コンストラクタ

		public SystemAuthorizationDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// 主キーでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable Select(OracleCommand cmd, SystemAuthorizationKey key)
		{
			string query = @"SELECT * FROM BS_SYSTEM_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
						+ " AND SOLUTION_ID = " + ProviderUtil.GetParameterName("SOLUTION_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, key.RoleId));
			//SOLUTION_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, key.SolutionId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}

		/// <summary>
		/// 全件SELECTします。
		/// </summary>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = @"SELECT * FROM BS_SYSTEM_AUTHORIZATION";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}

		/// <summary>
		/// SelectByRoleId
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public DataTable SelectByRoleId(OracleCommand cmd, string roleId)
		{
			string query = @"SELECT * FROM BS_SYSTEM_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
							+ " ORDER BY SOLUTION_ID";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, roleId));

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
		/// <param name="vo">データが詰まったSystemAuthorizationVO</param>
		/// <returns>更新レコード数</returns>
		public int Insert(DbCommand cmd, SystemAuthorizationVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_SYSTEM_AUTHORIZATION (ROLE_ID,SOLUTION_ID,SORT_NO) VALUES ( "
							  + ProviderUtil.GetParameterName("ROLE_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("SORT_NO", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, vo.RoleId));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionId));
			//SORT_NO
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SORT_NO", providerType, vo.SortNo));

			//追加
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったSystemAuthorizationKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(DbCommand cmd, SystemAuthorizationKey key)
		{
			cmd.CommandText = @"DELETE FROM BS_SYSTEM_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
						+ " AND SOLUTION_ID = " + ProviderUtil.GetParameterName("SOLUTION_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, key.RoleId));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, key.SolutionId));
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
			cmd.CommandText = @"DELETE FROM BS_SYSTEM_AUTHORIZATION WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType);
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
