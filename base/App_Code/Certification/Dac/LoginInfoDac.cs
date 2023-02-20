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
	/// BS_LOGIN_INFOテーブルにデータベースアクセスするクラスです。
	/// </summary>
	public class LoginInfoDac : BaseDac
	{

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public LoginInfoDac(OracleConnection connection)
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
		public DataTable Select(OracleCommand cmd, LoginInfoKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_INFO WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, key.LoginInfoId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}

		/// <summary>
		/// 主キーでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectWithLock(OracleCommand cmd, LoginInfoKey key)
		{
			string query;
			if (providerType == ProviderType.SqlClient)
			{
				query = "SELECT * FROM BS_LOGIN_INFO WITH(ROWLOCK,UPDLOCK) WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			}
			else
			{
				query = "SELECT * FROM BS_LOGIN_INFO WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType) + " FOR UPDATE";
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, key.LoginInfoId));

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
		/// <param name="vo">データが詰まったLoginInfoVO</param>
		/// <returns>更新レコード数</returns>
		public int Insert(DbCommand cmd, LoginInfoVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_LOGIN_INFO (LOGIN_INFO_ID,COMPANY_ID,LOGIN_ID,USER_LANGUAGE,MENU_PTN_CD,LOGIN_DATETIME,ACCESS_DATETIME) VALUES ("
						+ ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("COMPANY_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("USER_LANGUAGE", providerType)
						+ "," + ProviderUtil.GetParameterName("MENU_PTN_CD", providerType)
						+ "," + ProviderUtil.GetParameterName("LOGIN_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("ACCESS_DATETIME", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, vo.LoginInfoId));
			//COMPANY_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyID));
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//USER_LANGUAGE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("USER_LANGUAGE", providerType, vo.UserLanguage));
			//MENU_PTN_CD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MENU_PTN_CD", providerType, vo.MenuPtnCd));
			//LOGIN_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_DATETIME", providerType, vo.LoginDatetime));
			//ACCESS_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ACCESS_DATETIME", providerType, vo.AccessDatetime));

			//追加
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// 主キーでUPDATEします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginInfoVO</param>
		/// <returns>更新レコード数</returns>
		public int Update(DbCommand cmd, LoginInfoVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_INFO SET "
						+ " LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ ",USER_LANGUAGE = " + ProviderUtil.GetParameterName("USER_LANGUAGE", providerType)
						+ ",LOGIN_DATETIME = " + ProviderUtil.GetParameterName("LOGIN_DATETIME", providerType)
						+ ",ACCESS_DATETIME = " + ProviderUtil.GetParameterName("ACCESS_DATETIME", providerType)
						+ " WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//USER_LANGUAGE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("USER_LANGUAGE", providerType, vo.UserLanguage));
			//LOGIN_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_DATETIME", providerType, vo.LoginDatetime));
			//ACCESS_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ACCESS_DATETIME", providerType, vo.AccessDatetime));
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, vo.LoginInfoId));

			//更新
			int count = cmd.ExecuteNonQuery();

			return count;
		}

		/// <summary>
		/// 主キーでアクセス日時を更新します。アクセス日時はDateTime.Nowです。
		/// </summary>
		/// <param name="key">主キーが詰まったLoginInfoKey</param>
		/// <returns>更新レコード数</returns>
		public int UpdateAccessDateTime(OracleCommand cmd, LoginInfoKey key)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_INFO SET ACCESS_DATETIME = "
												+ ProviderUtil.GetParameterName("ACCESS_DATETIME", providerType) +
						" WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//ACCESS_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ACCESS_DATETIME", providerType, DateTime.Now));
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, key.LoginInfoId));
			//更新
			int count = cmd.ExecuteNonQuery();
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったLoginInfoKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(OracleCommand cmd, LoginInfoKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_INFO WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, key.LoginInfoId));

			//削除
			int count = cmd.ExecuteNonQuery();
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 機能排他機能をDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったLoginInfoKey</param>
		/// <returns>削除レコード数</returns>
		public int ExclusionDelete(DbCommand cmd,string loginID)
		{
			cmd.CommandText = "DELETE SC_EXCLUSION_LOG WHERE LOGINID = " + ProviderUtil.GetParameterName("LOGINID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGINID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGINID", providerType, loginID));

			//削除
			int count = 0;
			try
			{
				count = cmd.ExecuteNonQuery();
			}
			catch (System.Exception)
			{
			}
			return count;
		}
		#endregion

		#region Count
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public int Count(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			cmd.CommandText = "SELECT COUNT(*) FROM BS_LOGIN_INFO WHERE " + where.Key;
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			foreach (DbParameter para in where.Value)
			{
				cmd.Parameters.Add(para);
			}

			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		#endregion

		#region Find
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataTable Find(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = "SELECT * FROM BS_LOGIN_INFO " +
				"WHERE " + where.Key;
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

		#region FindUser
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <returns>一致レコード</returns>
		public DataTable FindUser(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = " SELECT * FROM BS_LOGIN_INFO LEFT OUTER JOIN BS_LOGIN_USER "
									+ " ON BS_LOGIN_INFO.LOGIN_ID = BS_LOGIN_USER.LOGIN_ID ";
			if (queryObj.SortKeys.Count == 0)
			{
				SortKey sort = new SortKey();
				sort.TableName = "BS_LOGIN_INFO";
				sort.ColumnName = "LOGIN_DATETIME";
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
			adapter.Fill(queryObj.StartRow, queryObj.MaxRowCount, res);

			return res;
		}
		#endregion

		#region FindcountUser
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public int FindCount(DbCommand cmd, QueryObject queryObj)
		{
			cmd.CommandText = " SELECT COUNT(*) FROM BS_LOGIN_INFO LEFT OUTER JOIN BS_LOGIN_USER "
							+ " ON BS_LOGIN_INFO.LOGIN_ID = BS_LOGIN_USER.LOGIN_ID ";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//Fill
			int res = Convert.ToInt32(cmd.ExecuteScalar());

			return res;
		}
		#endregion
	}
}
