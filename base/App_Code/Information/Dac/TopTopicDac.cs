// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information.Dac
{
	public class TopTopicDac : BaseDac
	{
		#region コンストラクタ
		public TopTopicDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// 見出しを取得します。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>取得結果が格納されたDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopTopicKey key)
		{
			string query = @"SELECT * FROM BS_TOP_TOPIC WHERE TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			// パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, key.TopicId));

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// 見出しを全件取得します。
		/// </summary>
		/// <param name="checkDisplayFlag">表示フラグ
		/// true:DISPLAY_FLAGが1のレコードを全件取得 
		/// false:DISPLAY_FLAGの値に関わらず全件取得(完全な全件取得)</param>
		/// <returns>取得結果が格納されたDataTable</returns>
		public DataTable SelectAll(OracleCommand cmd, bool checkDisplayFlag)
		{
			StringBuilder query = new StringBuilder();
			query.Append(@"SELECT * FROM BS_TOP_TOPIC ");
			if (checkDisplayFlag)
			{
				query.Append(@"WHERE DISPLAY_FLAG = '1' ");
			}
			query.Append(@"ORDER BY SORT_NO , TOPIC_ID");

			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query.ToString();
			//adapter.SelectCommand = cmd;
			//adapter.SelectCommand.Parameters.Clear();
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// 見出しを追加します。
		/// </summary>
		/// <param name="vo">追加対象のVO</param>
		/// <exception cref="DBConcurrencyException">追加に失敗した場合</exception>
		public int Insert(OracleCommand cmd, TopTopicVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_TOP_TOPIC (TOPIC_ID,TOPIC,NEW_DISPLAY_PERIOD,DATE_DISPLAY_FLAG,DATE_FORMAT,DISPLAY_NUMBER,DISPLAY_PERIOD,DISPLAY_FLAG,SORT_NO,CREATE_DATETIME,CREATE_USER_ID,UPDATE_DATETIME,UPDATE_USER_ID,ROW_UPDATE_ID) VALUES ("
					+ ProviderUtil.GetParameterName("TOPIC_ID", providerType)
					+ "," + ProviderUtil.GetParameterName("TOPIC", providerType)
					+ "," + ProviderUtil.GetParameterName("NEW_DISPLAY_PERIOD", providerType)
					+ "," + ProviderUtil.GetParameterName("DATE_DISPLAY_FLAG", providerType)
					+ "," + ProviderUtil.GetParameterName("DATE_FORMAT", providerType)
					+ "," + ProviderUtil.GetParameterName("DISPLAY_NUMBER", providerType)
					+ "," + ProviderUtil.GetParameterName("DISPLAY_PERIOD", providerType)
					+ "," + ProviderUtil.GetParameterName("DISPLAY_FLAG", providerType)
					+ "," + ProviderUtil.GetParameterName("SORT_NO", providerType)
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
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, vo.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC", providerType, vo.Topic));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NEW_DISPLAY_PERIOD", providerType, vo.NewDisplayPriod));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DATE_DISPLAY_FLAG", providerType, vo.DateDisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DATE_FORMAT", providerType, vo.DateFormat));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_NUMBER", providerType, vo.DisplayNumber));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_PERIOD", providerType, vo.DisplayPeriod));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_FLAG", providerType, vo.DisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SORT_NO", providerType, vo.SortNo));
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
				throw new DBConcurrencyException("テーブル：BS_TOP_TOPIC 排他エラーです。");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// 見出しを更新します。
		/// </summary>
		/// <param name="vo">更新対象のVO</param>
		/// <exception cref="DBConcurrencyException">更新に失敗した場合</exception>
		/// <returns>更新された件数</returns>
		public int Update(OracleCommand cmd, TopTopicVO vo)
		{
			cmd.CommandText = "UPDATE BS_TOP_TOPIC SET "
						+ "TOPIC = " + ProviderUtil.GetParameterName("TOPIC", providerType)
						+ "," + "NEW_DISPLAY_PERIOD = " + ProviderUtil.GetParameterName("NEW_DISPLAY_PERIOD", providerType)
						+ "," + "DATE_DISPLAY_FLAG = " + ProviderUtil.GetParameterName("DATE_DISPLAY_FLAG", providerType)
						+ "," + "DATE_FORMAT = " + ProviderUtil.GetParameterName("DATE_FORMAT", providerType)
						+ "," + "DISPLAY_NUMBER = " + ProviderUtil.GetParameterName("DISPLAY_NUMBER", providerType)
						+ "," + "DISPLAY_PERIOD = " + ProviderUtil.GetParameterName("DISPLAY_PERIOD", providerType)
						+ "," + "DISPLAY_FLAG = " + ProviderUtil.GetParameterName("DISPLAY_FLAG", providerType)
						+ "," + "SORT_NO = " + ProviderUtil.GetParameterName("SORT_NO", providerType)
						+ "," + "CREATE_DATETIME = " + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
						+ "," + "CREATE_USER_ID = " + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
						+ "," + "UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + "UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ "," + "ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ " WHERE TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//更新情報をセット
			vo.UpdateDateTime = DateTime.Now;

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, vo.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC", providerType, vo.Topic));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NEW_DISPLAY_PERIOD", providerType, vo.NewDisplayPriod));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DATE_DISPLAY_FLAG", providerType, vo.DateDisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DATE_FORMAT", providerType, vo.DateFormat));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_NUMBER", providerType, vo.DisplayNumber));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_PERIOD", providerType, vo.DisplayPeriod));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_FLAG", providerType, vo.DisplayFlag));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SORT_NO", providerType, vo.SortNo));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));

			//更新
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル: BS_TOP_TOPIC 排他エラーです。");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 見出しを削除します。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <param name="rowUpdateId">排他チェックID</param>
		/// <returns>削除された件数</returns>
		/// <exception cref="DBConcurrencyException">排他エラー，または見出しが既に削除されていた場合</exception>
		public int Delete(OracleCommand cmd, TopTopicKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_TOPIC WHERE "
						+ "TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, key.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, rowUpdateId));

			//削除
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//排他エラー
				throw new DBConcurrencyException("テーブル：BS_TOP_TOPIC 排他エラーです。");
			}
			return count;
		}
		#endregion
	}
}
