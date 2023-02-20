// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.DataLog.Dac
{
	public class DataLogDac : BaseDac
	{

		#region コンストラクタ

		public DataLogDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったDataLogVO</param>
		/// <exception cref="DBConcurrencyException">レコードが挿入されたかった時</exception>
		/// <returns>更新レコード数</returns>
		public int Insert(OracleCommand cmd, DataLogVO vo)
		{
			int count = 1;
			if (Convert.ToBoolean(SystemSettings.InputValidationSettings.Settings["DataLogOutput"]))
			{
				if (providerType == ProviderType.SqlClient)
				{
					cmd.CommandText = "INSERT INTO BS_DATA_LOG (SOLUTION_ID,PROGRAM_ID,OPERATION_TYPE,LOG_DATETIME,UPDATE_USER_ID,TABLE_NAME,LOG_DATA) VALUES ("
							+ ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("PROGRAM_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("OPERATION_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("TABLE_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATA", providerType)
							+ ")";
				}
				else
				{
					cmd.CommandText = "INSERT INTO BS_DATA_LOG (SOLUTION_ID,LOG_ID,PROGRAM_ID,OPERATION_TYPE,LOG_DATETIME,UPDATE_USER_ID,TABLE_NAME,LOG_DATA) VALUES ("
							+ ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
							+ "," + " BS_DATA_LOG_ID.nextval, "
							+ ProviderUtil.GetParameterName("PROGRAM_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("OPERATION_TYPE", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("TABLE_NAME", providerType)
							+ "," + ProviderUtil.GetParameterName("LOG_DATA", providerType)
							+ ")";
				}
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Clear();

				vo.Logdatetime = DateTime.Now;
				//パラメータをセット
				//SOLUTION_ID
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.Solutionid));
				//PROGRAM_ID
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PROGRAM_ID", providerType, vo.Programid));
				//OPERATION_TYPE
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OPERATION_TYPE", providerType, vo.Operationtype));
				//LOG_DATETIME
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATETIME", providerType, vo.Logdatetime));
				//UPDATE_USER_ID
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.Updateuserid));
				//TABLE_NAME
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TABLE_NAME", providerType, vo.Tablename));
				//LOG_DATA
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOG_DATA", providerType, vo.LogData));

				//追加
				count = cmd.ExecuteNonQuery();
				if (count == 0)
				{
					// 排他エラー
					throw new DBConcurrencyException("テーブル：BS_DATA_LOG 排他エラーです。");
				}
			}
			return count;
		}
		#endregion

		#region SelectByLogDateTime
		/// <summary>
		/// 指定した期間、テーブルのデータログをSELECTします。
		/// </summary>
		/// <param name="key">Tablenameが格納されたオブジェクト</param>
		/// <param name="startDateTime">取得対象の開始日時</param>
		///  <param name="endDateTime">取得対象の終了日時</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectByLogDateTime(OracleCommand cmd, DataLogVO key, DateTime? startDateTime, DateTime endDateTime)
		{
			string query = @"SELECT * FROM BS_DATA_LOG WHERE TABLE_NAME = " + ProviderUtil.GetParameterName("TABLE_NAME", providerType);
			if (endDateTime != DateTime.MinValue)
			{
				if (startDateTime != null)
				{
					query = query + " AND LOG_DATETIME> " + ProviderUtil.GetParameterName("START_DATETIME", providerType);
				}
				query = query + " AND LOG_DATETIME<= " + ProviderUtil.GetParameterName("END_DATETIME", providerType);
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("TABLE_NAME", providerType, key.Tablename));

			if (endDateTime != DateTime.MinValue)
			{
				if (startDateTime != null)
				{
					adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("START_DATETIME", providerType, startDateTime));
				}

				adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("END_DATETIME", providerType, endDateTime));
			}

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

	}
}
