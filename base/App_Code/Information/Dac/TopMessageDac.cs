// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information.Dac
{
	public class TopMessageDac : BaseDac
	{
		#region コンストラクタ
		public TopMessageDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// メッセージを検索します。
		/// </summary>
		/// <param name="key">メッセージの主キー</param>
		/// <returns>検索結果が格納されたDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopMessageKey key)
		{
			string query = @"SELECT * FROM BS_TOP_MESSAGE WHERE MESSAGE_ID = " + ProviderUtil.GetParameterName("MESSAGE_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			// パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, key.MessageId));

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// メッセージを全件検索します。
		/// </summary>
		/// <returns>検索結果が格納されたDataTable</returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = @"SELECT * FROM BS_TOP_MESSAGE ORDER BY CREATE_DATETIME DESC";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region find
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <returns>一致レコード(作成日の降順でソート済)</returns>
		public DataTable Find(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = "SELECT * FROM BS_TOP_MESSAGE";
			if (!string.IsNullOrEmpty(where.Key))
			{
				query += " WHERE " + where.Key;
			}
			StringBuilder od = new StringBuilder();
			foreach (SortKey sortkey in queryObj.SortKeys)
			{
				string col = sortkey.ColumnName;
				od.Append(col + " ");
				if (sortkey.IsDesc)
					od.Append("DESC ");
			}
			if (od.Length > 0)
			{
				query += " ORDER BY " + od.ToString();
			}

			// TODO yusy del DbDataAdapter ⇒ OracleDataAdapter
			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			//cmd.CommandText = query;
			//adapter.SelectCommand = cmd;
			//adapter.SelectCommand.Parameters.Clear();
			// TODO yusy add DbDataAdapter ⇒ OracleDataAdapter
			cmd.CommandText = query;
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);

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
		public int FindCount(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			cmd.CommandText = "SELECT COUNT(*) FROM BS_TOP_MESSAGE";
			if (!string.IsNullOrEmpty(where.Key))
			{
				cmd.CommandText += " WHERE " + where.Key;
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
		/// メッセージを追加します。
		/// </summary>
		/// <param name="vo">追加対象のメッセージVO</param>
		/// <exception cref="DBConcurrencyException">挿入に失敗した場合</exception>
		public int Insert(OracleCommand cmd, TopMessageVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_TOP_MESSAGE (MESSAGE_ID,TOPIC_ID,MESSAGE,URL,DISPLAY_FLAG,CREATE_DATETIME,CREATE_USER_ID,UPDATE_DATETIME,UPDATE_USER_ID,ROW_UPDATE_ID) VALUES ("
							+ ProviderUtil.GetParameterName("MESSAGE_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("TOPIC_ID", providerType)
							+ "," + ProviderUtil.GetParameterName("MESSAGE", providerType)
							+ "," + ProviderUtil.GetParameterName("URL", providerType)
							+ "," + ProviderUtil.GetParameterName("DISPLAY_FLAG", providerType)
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
			vo.UpdateDateTime = DateTime.Now;

			// パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, vo.MessageId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, vo.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE", providerType, vo.Message));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("URL", providerType, vo.Url));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_FLAG", providerType, vo.DisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));

			//追加
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// 排他エラー
				throw new DBConcurrencyException("テーブル：BS_TOP_MESSAGE 排他エラーです。");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// メッセージを更新します。
		/// </summary>
		/// <param name="vo">更新対象のメッセージVO</param>
		/// <exception cref="DBConcurrencyException">更新に失敗した場合</exception>
		/// <returns>更新された件数</returns>
		public int Update(OracleCommand cmd, TopMessageVO vo)
		{
			cmd.CommandText = "UPDATE BS_TOP_MESSAGE SET "
					+ "TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType)
					+ "," + "MESSAGE = " + ProviderUtil.GetParameterName("MESSAGE", providerType)
					+ "," + "URL = " + ProviderUtil.GetParameterName("URL", providerType)
					+ "," + "DISPLAY_FLAG = " + ProviderUtil.GetParameterName("DISPLAY_FLAG", providerType)
					+ "," + "CREATE_DATETIME = " + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
					+ "," + "CREATE_USER_ID = " + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
					+ "," + "UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
					+ "," + "UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
					+ "," + "ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
					+ " WHERE MESSAGE_ID = " + ProviderUtil.GetParameterName("MESSAGE_ID", providerType)
					+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//更新情報をセット
			vo.UpdateDateTime = DateTime.Now;

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE", providerType, vo.Message));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("URL", providerType, vo.Url));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_FLAG", providerType, vo.DisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, vo.MessageId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, vo.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));

			//更新
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル: BS_TOP_MESSAGE 排他エラーです。");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// メッセージを削除します。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <param name="rowUpdateId">排他チェックID</param>
		/// <returns>削除された件数</returns>
		/// <exception cref="DBConcurrencyException">削除に失敗した場合</exception>
		public int Delete(OracleCommand cmd, TopMessageKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_MESSAGE WHERE MESSAGE_ID = "
												  + ProviderUtil.GetParameterName("MESSAGE_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, key.MessageId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, rowUpdateId));

			//削除
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル：BS_TOP_MESSAGE 排他エラーです。");
			}
			return count;
		}
		#endregion

		#region 見出し削除時の存在チェック
		/// <summary>
		/// 引数の見出しIDを持つメッセージが存在するかチェックします。
		/// </summary>
		/// <param name="topicID">見出しID</param>
		/// <returns>true:存在する false:存在しない</returns>
		public bool CheckTopicIDUsedByMessage(OracleCommand cmd, string topicID)
		{
			cmd.CommandText = @"SELECT COUNT(*) FROM BS_TOP_MESSAGE WHERE TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType);

			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, topicID));

			//実行
			if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion
	}
}
