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
		#region �R���X�g���N�^
		public TopMessageDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// ���b�Z�[�W���������܂��B
		/// </summary>
		/// <param name="key">���b�Z�[�W�̎�L�[</param>
		/// <returns>�������ʂ��i�[���ꂽDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopMessageKey key)
		{
			string query = @"SELECT * FROM BS_TOP_MESSAGE WHERE MESSAGE_ID = " + ProviderUtil.GetParameterName("MESSAGE_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			// �p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, key.MessageId));

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// ���b�Z�[�W��S���������܂��B
		/// </summary>
		/// <returns>�������ʂ��i�[���ꂽDataTable</returns>
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
		/// ���������ň�v�������R�[�h��Ԃ��܂��B
		/// </summary>
		/// <returns>��v���R�[�h(�쐬���̍~���Ń\�[�g��)</returns>
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

			// TODO yusy del DbDataAdapter �� OracleDataAdapter
			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			//cmd.CommandText = query;
			//adapter.SelectCommand = cmd;
			//adapter.SelectCommand.Parameters.Clear();
			// TODO yusy add DbDataAdapter �� OracleDataAdapter
			cmd.CommandText = query;
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);

			//�p�����[�^���Z�b�g
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
		/// ���������ň�v�������R�[�h����Ԃ��܂��B
		/// </summary>
		/// <returns>��v���R�[�h��</returns>
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

			//�p�����[�^���Z�b�g
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
		/// ���b�Z�[�W��ǉ����܂��B
		/// </summary>
		/// <param name="vo">�ǉ��Ώۂ̃��b�Z�[�WVO</param>
		/// <exception cref="DBConcurrencyException">�}���Ɏ��s�����ꍇ</exception>
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

			//�쐬�E�X�V�����Z�b�g
			vo.CreateDateTime = DateTime.Now;
			vo.UpdateDateTime = DateTime.Now;

			// �p�����[�^���Z�b�g
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

			//�ǉ�
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// �r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_MESSAGE �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ���b�Z�[�W���X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V�Ώۂ̃��b�Z�[�WVO</param>
		/// <exception cref="DBConcurrencyException">�X�V�Ɏ��s�����ꍇ</exception>
		/// <returns>�X�V���ꂽ����</returns>
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

			//�X�V�����Z�b�g
			vo.UpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
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

			//�X�V
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u��: BS_TOP_MESSAGE �r���G���[�ł��B");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ���b�Z�[�W���폜���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <param name="rowUpdateId">�r���`�F�b�NID</param>
		/// <returns>�폜���ꂽ����</returns>
		/// <exception cref="DBConcurrencyException">�폜�Ɏ��s�����ꍇ</exception>
		public int Delete(OracleCommand cmd, TopMessageKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_MESSAGE WHERE MESSAGE_ID = "
												  + ProviderUtil.GetParameterName("MESSAGE_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MESSAGE_ID", providerType, key.MessageId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, rowUpdateId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_MESSAGE �r���G���[�ł��B");
			}
			return count;
		}
		#endregion

		#region ���o���폜���̑��݃`�F�b�N
		/// <summary>
		/// �����̌��o��ID�������b�Z�[�W�����݂��邩�`�F�b�N���܂��B
		/// </summary>
		/// <param name="topicID">���o��ID</param>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool CheckTopicIDUsedByMessage(OracleCommand cmd, string topicID)
		{
			cmd.CommandText = @"SELECT COUNT(*) FROM BS_TOP_MESSAGE WHERE TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType);

			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, topicID));

			//���s
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
