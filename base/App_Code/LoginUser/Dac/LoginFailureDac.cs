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
	public class LoginFailureDac : BaseDac
	{

		#region コンストラクタ
		public LoginFailureDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// 主キーSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable Select(OracleCommand cmd, LoginFailureKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_FAILURE " + "WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region CheckLoginId
		/// <summary>
		/// 引数のログインIDのレコードが存在するかチェックします。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns>引数のログインIDに一致する行があればtrue なければfasle</returns>
		public bool CheckLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_LOGIN_FAILURE " + " WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));
			bool res;
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				res = reader.HasRows;
			}
			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginFailureVO</param>
		/// <returns>更新レコード数</returns>
		/// <exception cref="DBConcurrencyException">挿入結果が0件の時</exception>
		public int Insert(DbCommand cmd, LoginFailureVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_LOGIN_FAILURE (LOGIN_ID,FAILURE_COUNT) VALUES ("
						+ ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("FAILURE_COUNT", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//FAILURE_COUNT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FAILURE_COUNT", providerType, vo.FailureCount));

			//追加
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル：BS_LOGIN_FAILURE 排他エラーです。");
			}
			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// 主キーでUPDATEします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginFailureVO</param>
		/// <exception cref="DBConcurrencyException">更新結果が0件の時</exception>
		/// <returns>更新レコード数</returns>
		public int Update(DbCommand cmd, LoginFailureVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_FAILURE SET"
						+ " FAILURE_COUNT = " + ProviderUtil.GetParameterName("FAILURE_COUNT", providerType)
						+ " WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//FAILURE_COUNT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FAILURE_COUNT", providerType, vo.FailureCount));

			//更新
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル：BS_LOGIN_FAILURE 排他エラーです。");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーで物理削除します。
		/// 排他処理はしません。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int PhysicalDelete(DbCommand cmd, LoginFailureKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_FAILURE WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
