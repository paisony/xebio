// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Dac
{
	public class CompanyDac : BaseDac
	{

		#region コンストラクタ
		public CompanyDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// 全ての項目SELECTします。
		/// </summary>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = "SELECT * FROM BS_COMPANY ORDER BY COMPANY_ID";
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

		#region Select
		/// <summary>
		/// 主キーSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable Select(OracleCommand cmd, CompanyKey key)
		{
			string query = "SELECT * FROM BS_COMPANY WHERE COMPANY_ID = " + ProviderUtil.GetParameterName("COMPANY_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, key.CompanyId));

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
		/// <param name="vo">データが詰まったCompanyVO</param>
		/// <returns>更新レコード数</returns>
		public int Insert(DbCommand cmd, CompanyVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_COMPANY (COMPANY_ID,COMPANY_NAME,CREATE_DATETIME,CREATE_USER_ID,UPDATE_DATETIME,UPDATE_USER_ID,DELETE_FLAG) VALUES ("
						+ ProviderUtil.GetParameterName("COMPANY_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("COMPANY_NAME", providerType)
						+ "," + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.CreateDateTime = DateTime.Now;
			vo.UpdateDateTime = DateTime.Now;
			//パラメータをセット
			//COMPANY
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyId));
			//COMPANY_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_NAME", providerType, vo.CompanyName));
			//CREATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			//CREATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_OFF));

			//追加
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// 主キーでUPDATEします。
		/// </summary>
		/// <param name="vo">データが詰まったCompanyVO</param>
		/// <returns>更新レコード数</returns>
		public int Update(DbCommand cmd, CompanyVO vo)
		{
			cmd.CommandText = "UPDATE BS_COMPANY SET"
						+ "  COMPANY_NAME = " + ProviderUtil.GetParameterName("COMPANY_NAME", providerType)
						+ ", UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ "  WHERE COMPANY_ID = " + ProviderUtil.GetParameterName("COMPANY_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.UpdateDateTime = DateTime.Now;
			//パラメータをセット
			//COMPANY
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyId));
			//COMPANY_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_NAME", providerType, vo.CompanyName));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, vo.DeleteFlag));

			//更新
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったCompanyKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(OracleCommand cmd, CompanyVO vo)
		{
			cmd.CommandText = "UPDATE BS_COMPANY SET"
						+ "  UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ "  WHERE COMPANY_ID = " + ProviderUtil.GetParameterName("COMPANY_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.UpdateDateTime = DateTime.Now;
			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_ON));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteAll
		/// <summary>
		/// すべてDELETEします。（論理削除）
		/// </summary>
		/// <returns>削除レコード数</returns>
		public int DeleteAll(OracleCommand cmd, string updateUserId)
		{
			cmd.CommandText = "UPDATE BS_COMPANY SET"
						+ "  UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット      
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, DateTime.Now));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, updateUserId));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_ON));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
