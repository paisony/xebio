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
		#region �R���X�g���N�^
		public TopTopicDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// ���o�����擾���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�擾���ʂ��i�[���ꂽDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopTopicKey key)
		{
			string query = @"SELECT * FROM BS_TOP_TOPIC WHERE TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			// �p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, key.TopicId));

			// Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// ���o����S���擾���܂��B
		/// </summary>
		/// <param name="checkDisplayFlag">�\���t���O
		/// true:DISPLAY_FLAG��1�̃��R�[�h��S���擾 
		/// false:DISPLAY_FLAG�̒l�Ɋւ�炸�S���擾(���S�ȑS���擾)</param>
		/// <returns>�擾���ʂ��i�[���ꂽDataTable</returns>
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
		/// ���o����ǉ����܂��B
		/// </summary>
		/// <param name="vo">�ǉ��Ώۂ�VO</param>
		/// <exception cref="DBConcurrencyException">�ǉ��Ɏ��s�����ꍇ</exception>
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

			//�쐬�E�X�V�����Z�b�g
			vo.CreateDateTime = DateTime.Now;
			vo.UpdateDateTime = DateTime.Now;

			// �p�����[�^���Z�b�g
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


			//�ǉ�
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				// �r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_TOPIC �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ���o�����X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V�Ώۂ�VO</param>
		/// <exception cref="DBConcurrencyException">�X�V�Ɏ��s�����ꍇ</exception>
		/// <returns>�X�V���ꂽ����</returns>
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

			//�X�V�����Z�b�g
			vo.UpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
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

			//�X�V
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u��: BS_TOP_TOPIC �r���G���[�ł��B");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ���o�����폜���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <param name="rowUpdateId">�r���`�F�b�NID</param>
		/// <returns>�폜���ꂽ����</returns>
		/// <exception cref="DBConcurrencyException">�r���G���[�C�܂��͌��o�������ɍ폜����Ă����ꍇ</exception>
		public int Delete(OracleCommand cmd, TopTopicKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_TOPIC WHERE "
						+ "TOPIC_ID = " + ProviderUtil.GetParameterName("TOPIC_ID", providerType)
						+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TOPIC_ID", providerType, key.TopicId));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, rowUpdateId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_TOPIC �r���G���[�ł��B");
			}
			return count;
		}
		#endregion
	}
}
