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
	public class AuthorizationRefDac : BaseDac
	{
		#region コンストラクタ
		public AuthorizationRefDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		/// <summary>
		/// ソリューション取得
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns></returns>
		public List<string> GetSystemAuthorizationByLoginUser(OracleCommand cmd, string userType)
		{
			string query = null;
			if (ConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER.Equals(userType))
			{
				query = @"SELECT SOLUTION_ID FROM BS_FUNCTION_VIEW GROUP BY SOLUTION_ID ";
			}
			else
			{
				query = @"SELECT SOLUTION_ID FROM BS_FUNCTION_AUTHORIZATION GROUP BY SOLUTION_ID ";
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			List<string> res = new List<string>();

			foreach (DataRow row in dt.Rows)
			{
				res.Add(Convert.ToString(row["SOLUTION_ID"]));
			}

			return res;
		}

	}
}
