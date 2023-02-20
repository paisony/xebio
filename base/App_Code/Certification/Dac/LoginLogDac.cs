// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Certification.Dac
{
	/// <summary>
	/// BS_LOGIN_LOGテーブルにデータベースアクセスするクラスです。
	/// </summary>
	public class LoginLogDac : BaseDac
	{

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public LoginLogDac(OracleConnection connection)
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
		public DataTable Select(OracleCommand cmd, LoginLogKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_LOG " +
				"WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType) +
				" AND LOG_DATETIME = " + ProviderUtil.GetParameterName("LOG_DATETIME", null, providerType) +
				" AND LOG_TYPE = " + ProviderUtil.GetParameterName("LOG_TYPE", null, providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginID));
			//LOG_DATETIME
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, key.LogDatetime));
			//LOG_TYPE
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_TYPE", providerType, key.LogType));
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region find(Select)
		/// <summary>
		/// LOGIN_IDでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable findSelect(OracleCommand cmd, LoginLogVO key)
		{
			string query = "SELECT * FROM BS_LOGIN_LOG a WHERE "
				+ "     a.LOGIN_ID      = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType)
				+ " AND a.LOG_DATETIME = ( SELECT MAX(b.LOG_DATETIME) FROM BS_LOGIN_LOG b WHERE "
				+ "                              b.LOGIN_ID = a.LOGIN_ID "
				+ "                         AND (b.LOG_TYPE = '0' OR b.LOG_TYPE = '2' ) ) "
				+ " AND (a.LOG_TYPE = '0' OR a.LOG_TYPE = '2' ) ";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginID));
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			LoginLogVO vo = new LoginLogVO();
			vo.LoginID = Convert.ToString(res.Rows[0]["LOGIN_ID"]);
			vo.LogDatetime = DateTime.Now;
			vo.LogType = LoginLogType.FunctionExcute;
			vo.SolutionID = key.SolutionID;
			vo.FunctionID = key.FunctionID;
			vo.OfflineFlag = Convert.ToString(res.Rows[0]["OFFLINE_FLAG"]);
			vo.IPAddress = Convert.ToString(res.Rows[0]["IP_ADDRESS"]);
			vo.PCName = Convert.ToString(res.Rows[0]["PC_NAME"]);

			query = "SELECT * FROM BS_FUNCTION WHERE "
				+ "     SOLUTION_ID = " + ProviderUtil.GetParameterName("SOLUTION_ID", null, providerType)
				+ " AND FUNCTION_ID = " + ProviderUtil.GetParameterName("FUNCTION_ID", null, providerType);
			//adapter = this.GetDbDataAdapter();
			// TODO yusy ↑del ↓add
			adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, key.SolutionID));
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, key.FunctionID));
			//Fill
			res = new DataTable();
			adapter.Fill(res);

			vo.FunctionName = Convert.ToString(res.Rows[0]["FUNCTION_NAME"]);
			vo.FunctionUrl = Convert.ToString(res.Rows[0]["FUNCTION_URL"]);

			query = "";
			if (providerType == ProviderType.SqlClient)
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME) VALUES ("
							+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ ")";
			}
			else
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOG_ID,LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME,SOLUTION_ID,FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL) VALUES ("
							+ " BS_LOGIN_LOG_ID.nextval"
							+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_URL", providerType)
							+ ")";
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			string apServerName = "";
			try
			{
				apServerName = "_" + Environment.MachineName;
			}
			catch (System.Exception)
			{
			}
			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//LOG_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, vo.LogDatetime));
			//LOG_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_TYPE", providerType, vo.LogType));
			//OFFLINE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OFFLINE_FLAG", providerType, vo.OfflineFlag));
			//IP_ADDRESS
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("IP_ADDRESS", providerType, vo.IPAddress));
			//PC_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PC_NAME", providerType, vo.PCName));
			//SOLUTION_ID
			if (string.IsNullOrEmpty(apServerName))
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID));
			}
			else
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID + apServerName));
			}
			//FUNCTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, vo.FunctionID));
			//FUNCTION_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_NAME", providerType, vo.FunctionName));
			//FUNCTION_URL
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_URL", providerType, vo.FunctionUrl));

			//追加
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_LOGIN_LOG 排他エラーです。");
			}

			query = "SELECT * FROM BS_LOGIN_LOG a WHERE "
				+ "     a.LOGIN_ID      = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType)
				+ " AND a.LOG_DATETIME = ( SELECT MAX(b.LOG_DATETIME) FROM BS_LOGIN_LOG b WHERE "
				+ "                             b.LOGIN_ID = a.LOGIN_ID "
				+ "                         AND b.LOG_TYPE = '8' ) "
				+ " AND a.LOG_TYPE = '8' ";
						//adapter = this.GetDbDataAdapter();
			// TODO yusy ↑del ↓add
			adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginID));
			//Fill
			res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region find
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <returns>一致レコード(アクセス日の降順でソート済)</returns>
		public DataTable Find(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = "SELECT * FROM BS_LOGIN_LOG "
				+ "LEFT OUTER JOIN BS_LOGIN_USER ON BS_LOGIN_LOG.LOGIN_ID = BS_LOGIN_USER.LOGIN_ID WHERE ( OFFLINE_FLAG <> 9 )";
			if (!string.IsNullOrEmpty(where.Key))
				query += " AND " + where.Key;
			StringBuilder od = new StringBuilder();
			foreach (SortKey sortkey in queryObj.SortKeys)
			{
				string col = sortkey.ColumnName;
				od.Append(col + " ");
				if (sortkey.IsDesc)
				{
					od.Append("DESC ");
				}
			}
			if (od.Length > 0)
			{
				query += " ORDER BY " + od.ToString();
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			foreach (DbParameter para in where.Value)
			{
				adapter.SelectCommand.Parameters.Add(para);
			}

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(queryObj.StartRow, queryObj.MaxRowCount, res);

			return res;
		}
		#endregion

		#region findcount
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public int FindCount(DbCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			cmd.CommandText = " SELECT COUNT(*) FROM BS_LOGIN_LOG LEFT OUTER JOIN BS_LOGIN_USER "
									+ " ON BS_LOGIN_LOG.LOGIN_ID = BS_LOGIN_USER.LOGIN_ID WHERE LOG_TYPE <= 4 ";
			if (!string.IsNullOrEmpty(where.Key))
			{
				cmd.CommandText += " AND " + where.Key;
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			foreach (DbParameter para in where.Value)
			{
				cmd.Parameters.Add(para);
			}

			//Fill
			int res = Convert.ToInt32(cmd.ExecuteScalar());

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginLogVO</param>
		/// <exception cref="DBConcurrencyException">レコードが挿入されたかった時</exception>
		/// <returns>更新レコード数</returns>
		public int Insert(OracleCommand cmd, LoginLogVO vo)
		{
			string query = "SELECT * FROM BS_SOLUTION ORDER BY SOLUTION_ID DESC ";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);
			vo.SolutionID = Convert.ToString(res.Rows[0]["SOLUTION_ID"]);

			if (providerType == ProviderType.SqlClient)
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME,SOLUTION_ID,FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL) VALUES ("
							+ ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_URL", providerType)
							+ ")";
			}
			else
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOG_ID,LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME,SOLUTION_ID,FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL) VALUES ("
							+ " BS_LOGIN_LOG_ID.nextval "
							+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_URL", providerType)
							+ ")";
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			string apServerName = "";
			try
			{
				apServerName = "_" + Environment.MachineName;
			}
			catch (System.Exception)
			{
			}

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//LOG_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, vo.LogDatetime));
			//LOG_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_TYPE", providerType, vo.LogType));
			//OFFLINE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OFFLINE_FLAG", providerType, vo.OfflineFlag));
			//IP_ADDRESS
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("IP_ADDRESS", providerType, vo.IPAddress));
			//PC_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PC_NAME", providerType, vo.PCName));
			//SOLUTION_ID
			if (string.IsNullOrEmpty(apServerName))
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID));
			}
			else
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID + apServerName));
			}
			//FUNCTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, vo.FunctionID));
			//FUNCTION_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_NAME", providerType, vo.FunctionName));
			//FUNCTION_URL
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_URL", providerType, vo.FunctionUrl));

			//追加
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_LOGIN_LOG 排他エラーです。");
			}

			return count;
		}
		#endregion

		#region Insert2
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginLogVO</param>
		/// <exception cref="DBConcurrencyException">レコードが挿入されたかった時</exception>
		/// <returns>更新レコード数</returns>
		public int Insert2(OracleCommand cmd, LoginLogVO vo)
		{
			string query = "SELECT * FROM BS_SOLUTION ORDER BY SOLUTION_ID DESC ";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);
			vo.SolutionID = Convert.ToString(res.Rows[0]["SOLUTION_ID"]);

			if (providerType == ProviderType.SqlClient)
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOG_ID,LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME,SOLUTION_ID,FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL) VALUES ("
							+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_URL", providerType)
							+ ")";
			}
			else
			{
				cmd.CommandText = "INSERT INTO BS_LOGIN_LOG (LOG_ID,LOGIN_ID,LOG_DATETIME,LOG_TYPE,OFFLINE_FLAG,IP_ADDRESS,PC_NAME,SOLUTION_ID,FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL) VALUES ("
							+ " BS_LOGIN_LOG_ID.nextval"
							+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("OFFLINE_FLAG", providerType)
							+ "," + ProviderUtil.GetParameterName("IP_ADDRESS", providerType)
							+ "," + ProviderUtil.GetParameterName("PC_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("FUNCTION_URL", providerType)
							+ ")";
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			string apServerName = "";
			try
			{
				apServerName = "_" + Environment.MachineName;
			}
			catch (System.Exception)
			{
			}

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//LOG_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, vo.LogDatetime));
			//LOG_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_TYPE", providerType, vo.LogType));
			//OFFLINE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OFFLINE_FLAG", providerType, vo.OfflineFlag));
			//IP_ADDRESS
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("IP_ADDRESS", providerType, vo.IPAddress));
			//PC_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PC_NAME", providerType, vo.PCName));
			//SOLUTION_ID
			if (string.IsNullOrEmpty(apServerName))
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID));
			}
			else
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID + apServerName));
			}
			//FUNCTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_ID", providerType, vo.FunctionID));
			//FUNCTION_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_NAME", providerType, vo.FunctionName));
			//FUNCTION_URL
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FUNCTION_URL", providerType, vo.FunctionUrl));

			//追加
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_LOGIN_LOG 排他エラーです。");
			}

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったLoginLogKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(DbCommand cmd, LoginLogKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_LOG "
						+ " WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType)
						+ " AND LOG_DATETIME = " + ProviderUtil.GetParameterName("LOG_DATETIME", null, providerType)
						+ " AND LOG_TYPE = " + ProviderUtil.GetParameterName("LOG_TYPE", null, providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginID));
			//LOG_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, key.LogDatetime));
			//LOG_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_TYPE", providerType, key.LogType));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		/// <summary>
		/// DeleteByTime
		/// </summary>
		/// <param name="deleteTime"></param>
		/// <returns></returns>
		public int DeleteByTime(DbCommand cmd, string deleteTime)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_LOG " + "WHERE LOG_DATETIME < " + ProviderUtil.GetParameterName("LOG_DATETIME", null, providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOG_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, deleteTime));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
