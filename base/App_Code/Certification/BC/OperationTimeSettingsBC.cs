// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.Systems.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Net;
using System.Net.Sockets;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.Dac;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.OperationTimeSettings.BC
{
	public class OperationTimeSettingsBC : BaseBC
	{
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public OperationTimeSettingsBC(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region 運用時間検索
		/// <summary>
		/// 運用時間検索
		/// </summary>
		/// <param name="queryObj"></param>
		/// <returns></returns>
		public DataTable FindOperationTime(QueryObject queryObj)
		{

			OperationTimeSettingsDac FindDac = new OperationTimeSettingsDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;

			DataTable dt = FindDac.Find(cmd,queryObj);

			return dt;
		}
		#endregion

		#region 運用時間設定
		/// <summary>
		///  運用時間設定
		/// </summary>
		/// <param name="vos"></param>
		/// <returns></returns>
		public bool UpdateOperationTime(params OperationTimeSettingsVO[] vos)
		{
			OperationTimeSettingsDac dac = new OperationTimeSettingsDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				foreach (OperationTimeSettingsVO vo in vos)
				{
					//データを更新する。
					dac.Update(cmd, vo);
				}
			}
			catch (Exception)
			{
				cmd.Transaction.Rollback();
			}
			if (cmd.Transaction != null)
			{
				cmd.Transaction.Commit();
			}

			return true;
		}
		#endregion
	}
}
