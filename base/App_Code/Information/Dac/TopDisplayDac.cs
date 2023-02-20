// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information.Dac
{
	public class TopDisplayDac : BaseDac
	{
		#region コンストラクタ
		public TopDisplayDac(OracleConnection connection)
			: base(connection)
		{
		}
		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public TopDisplayDac(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// トップ画面情報を検索します。
		/// </summary>
		/// <param name="key">トップ画面情報の主キー</param>
		/// <returns>検索結果が格納されたDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopDisplayKey key)
		{
			string query = @"SELECT * FROM BS_TOP_DISPLAY WHERE DISPLAY_ID = " + ProviderUtil.GetParameterName("DISPLAY_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, key.DisplayId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// トップ画面情報を全件検索します。
		/// </summary>
		/// <returns>検索結果が格納されたDataTable</returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = "SELECT * FROM BS_TOP_DISPLAY";
			// TODO yusy add
			cmd.CommandText=query;
			OracleDataAdapter myDa = new OracleDataAdapter(cmd);

            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            cmd.CommandText = query;
            adapter.SelectCommand = cmd;
            adapter.SelectCommand.Parameters.Clear();

            // Fill
            DataTable res = new DataTable();
			myDa.Fill(res);

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// トップ画面情報を追加します。
		/// </summary>
		/// <param name="vo">追加対象のトップ画面情報VO</param>
		/// <exception cref="DBConcurrencyException">追加に失敗した場合</exception>
		/// <returns>追加された件数</returns>
		public int Insert(DbCommand cmd, TopDisplayVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_TOP_DISPLAY (DISPLAY_ID,DISPLAY_CONTENT,CREATE_DATETIME,CREATE_USER_ID,UPDATE_DATETIME,UPDATE_USER_ID,ROW_UPDATE_ID) VALUES ("
								  + ProviderUtil.GetParameterName("DISPLAY_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("DISPLAY_CONTENT", providerType)
							+ "," + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
							+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
							+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//作成・更新情報をセット
			vo.CreateDateTime = DateTime.Now;
			vo.CreateUserId = loginUserInfo.LoginId;
			vo.UpdateDateTime = DateTime.Now;
			vo.UpdateUserId = loginUserInfo.LoginId;

			// パラメータをセット
			//DISPLAY_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, vo.DisplayId));
			//DISPLAY_CONTENT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_CONTENT", providerType, vo.DisplayContent));
			//CREATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			//CREATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserId));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserId));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));

			//追加
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_TOP_DISPLAY 排他エラーです。");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// トップ画面情報を更新します。
		/// </summary>
		/// <param name="vo">更新対象のトップ画面情報VO</param>
		/// <exception cref="DBConcurrencyException">更新に失敗した場合</exception>
		/// <returns>更新された件数</returns>
		public int Update(OracleCommand cmd, TopDisplayVO vo)
		{
			cmd.CommandText = "UPDATE BS_TOP_DISPLAY SET "
						+ "DISPLAY_CONTENT = " + ProviderUtil.GetParameterName("DISPLAY_CONTENT", providerType)
						+ "," + "CREATE_DATETIME = " + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
						+ "," + "CREATE_USER_ID = " + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
						+ "," + "UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + "UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ "," + "ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ " WHERE DISPLAY_ID = " + ProviderUtil.GetParameterName("DISPLAY_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//更新情報をセット
			vo.UpdateDateTime = DateTime.Now;

			//パラメータをセット
			//DISPLAY_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, vo.DisplayId));
			//DISPLAY_CONTENT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_CONTENT", providerType, vo.DisplayContent));
			//CREATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			//CREATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserId));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserId));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//ROW_UPDATE_ID(オリジナル)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));

			//更新
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル: BS_TOP_DISPLAY 排他エラーです。");
			}
			return count;
		}

		/// <summary>
		/// トップ画面情報を削除します。
		/// </summary>
		/// <param name="vo">削除対象のトップ画面情報VO</param>
		/// <exception cref="DBConcurrencyException">削除に失敗した場合</exception>
		/// <returns>削除された件数</returns>
		public int Delete(DbCommand cmd, TopDisplayKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_DISPLAY WHERE DISPLAY_ID = " + ProviderUtil.GetParameterName("DISPLAY_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, key.DisplayId));

			// 削除
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_TOP_DISPLAY 排他エラーです。");
			}

			return count;
		}
		#endregion

	}
}
