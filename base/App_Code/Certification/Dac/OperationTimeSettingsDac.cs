// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.OperationTimeSettings.Dac
{
	/// <summary>
	/// BS_OPERATION_TIMEテーブルにデータベースアクセスするクラスです。
	/// </summary>
	public class OperationTimeSettingsDac : BaseDac
	{

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public OperationTimeSettingsDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Find
		/// <summary>
		/// 主キーでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable Find(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = "SELECT * FROM BS_OPERATION_TIME";
			if (!string.IsNullOrEmpty(where.Key))
			{
				query += " WHERE " + where.Key;
			}
			if (queryObj.SortKeys.Count == 0)
			{
				SortKey sort = new SortKey();
				sort.ColumnName = "DAY_TYPE";
				queryObj.AddSortKey(sort);
			}
			query += " ORDER BY " + queryObj.GetOrderbyPhrase();
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
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Update
		/// <summary>
		/// 主キーでUPDATEします。
		/// </summary>
		/// <param name="vo">データが詰まったOperationTimeSettingsVO</param>
		/// <returns>更新レコード数</returns>
		public int Update(OracleCommand cmd, OperationTimeSettingsVO vo)
		{
			cmd.CommandText = "UPDATE BS_OPERATION_TIME SET"
						+ " START_TIME = " + ProviderUtil.GetParameterName("START_TIME", providerType)
						+ ",STOP_TIME = " + ProviderUtil.GetParameterName("STOP_TIME", providerType)
						+ " WHERE DAY_TYPE = " + ProviderUtil.GetParameterName("DAY_TYPE", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//DAY_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DAY_TYPE", providerType, vo.DayTYPE));
			//START_TIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("START_TIME", providerType, string.IsNullOrEmpty(vo.STARTTime) ? (object)DBNull.Value : (object)vo.STARTTime));
			//STOP_TIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("STOP_TIME", providerType, string.IsNullOrEmpty(vo.STOPTime) ? (object)DBNull.Value : (object)vo.STOPTime));

			//更新
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル：BS_OPERATION_TIME 排他エラーです。");
			}

			return count;
		}
		#endregion

	}
}
