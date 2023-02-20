// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Transactions;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.BC;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.DataLog
{
	/// <summary>
	/// データログの記録をするサービスクラスです。
	/// </summary>
	public class DataLogService : BaseService
	{
		#region コンストラクタ

		public DataLogService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{

		}

		#endregion

		#region InsertDataLog

		public Result InsertDataLog(DataLogVO dataLogVO)
		{
			Result res;
			// 入力引数チェック
			if (dataLogVO.Operationtype == null)
			{
				throw new ArgumentNullException("DataLogService.InsertDataLog: オペレーションタイプがnullです。");
			}

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					DataLogBC dataLogBC = new DataLogBC(loginUserInfo, connection);
					res = new Result(dataLogBC.InsertDataLog(dataLogVO));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertDataLog", ex);
			}
		}
		#endregion

		#region SelectByLogDateTime
		/// <summary>
		/// SelectByLogDateTime
		/// </summary>
		/// <param name="dataLogVO"></param>
		/// <param name="startDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <returns></returns>
		public DataResult<DataTable> SelectByLogDateTime(DataLogVO dataLogVO, DateTime? startDateTime, DateTime endDateTime)
		{
			DataResult<DataTable> res;
			// 入力引数チェック
			if (dataLogVO.Tablename == null)
			{
				throw new ArgumentNullException("DataLogService.SelectByLogDateTime: 取得テーブル名がnullです。");
			}

			// データをテーブルから取得
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					DataLogBC dataLogBC = new DataLogBC(loginUserInfo, connection);
					DataTable dt = dataLogBC.SelectByLogDateTime(cmd, dataLogVO, startDateTime, endDateTime);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("SelectByLogDateTime", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="LoginId"></param>
		/// <param name="solutionId"></param>
		/// <param name="functionId"></param>
		public void InsertExecDataLog(string LoginId, string solutionId, string functionId)
		{
			if (!string.IsNullOrEmpty(LoginId) && !string.IsNullOrEmpty(solutionId) && !string.IsNullOrEmpty(functionId))
			{
				try
				{
					using (OracleConnection connection = GetConnection())
					{
						connection.Open();

						OracleCommand cmd = connection.CreateCommand() as OracleCommand;
						try
						{
							OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
							cmd.Transaction = transaction;

							LoginLogVO vo = new LoginLogVO();
							vo.LoginID = LoginId;
							vo.SolutionID = solutionId;
							vo.FunctionID = functionId;
							//プログラム起動情報
							LoginLogDac loginLogDac = new LoginLogDac(connection);
							DataLogDac dataLogDac = new DataLogDac(connection);
							DataTable loginTable = loginLogDac.findSelect(cmd, vo);
							loginTable.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;

							DataLogVO dataLogVO = new DataLogVO();
							dataLogVO.Solutionid = solutionId;
							dataLogVO.Logid = vo.LoginID;
							dataLogVO.Programid = functionId;
							dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_START;
							dataLogVO.Updateuserid = vo.LoginID;
							dataLogVO.Tablename = "";
							dataLogVO.LogData = XmlUtility.ConvertXML(loginTable);
							dataLogDac.Insert(cmd, dataLogVO);

						}
						catch (Exception)
						{
							cmd.Transaction.Rollback();
						}
						if (cmd.Transaction != null)
						{
							cmd.Transaction.Commit();
						}
					}
				}
				finally
				{
				}
			}
		}
	}
}
