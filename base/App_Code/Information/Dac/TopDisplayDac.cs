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
		#region �R���X�g���N�^
		public TopDisplayDac(OracleConnection connection)
			: base(connection)
		{
		}
		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public TopDisplayDac(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// �g�b�v��ʏ����������܂��B
		/// </summary>
		/// <param name="key">�g�b�v��ʏ��̎�L�[</param>
		/// <returns>�������ʂ��i�[���ꂽDataTable</returns>
		public DataTable Select(OracleCommand cmd, TopDisplayKey key)
		{
			string query = @"SELECT * FROM BS_TOP_DISPLAY WHERE DISPLAY_ID = " + ProviderUtil.GetParameterName("DISPLAY_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, key.DisplayId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// �g�b�v��ʏ���S���������܂��B
		/// </summary>
		/// <returns>�������ʂ��i�[���ꂽDataTable</returns>
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
		/// �g�b�v��ʏ���ǉ����܂��B
		/// </summary>
		/// <param name="vo">�ǉ��Ώۂ̃g�b�v��ʏ��VO</param>
		/// <exception cref="DBConcurrencyException">�ǉ��Ɏ��s�����ꍇ</exception>
		/// <returns>�ǉ����ꂽ����</returns>
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

			//�쐬�E�X�V�����Z�b�g
			vo.CreateDateTime = DateTime.Now;
			vo.CreateUserId = loginUserInfo.LoginId;
			vo.UpdateDateTime = DateTime.Now;
			vo.UpdateUserId = loginUserInfo.LoginId;

			// �p�����[�^���Z�b�g
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

			//�ǉ�
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// �r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_DISPLAY �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// �g�b�v��ʏ����X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V�Ώۂ̃g�b�v��ʏ��VO</param>
		/// <exception cref="DBConcurrencyException">�X�V�Ɏ��s�����ꍇ</exception>
		/// <returns>�X�V���ꂽ����</returns>
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

			//�X�V�����Z�b�g
			vo.UpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
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
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));

			//�X�V
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u��: BS_TOP_DISPLAY �r���G���[�ł��B");
			}
			return count;
		}

		/// <summary>
		/// �g�b�v��ʏ����폜���܂��B
		/// </summary>
		/// <param name="vo">�폜�Ώۂ̃g�b�v��ʏ��VO</param>
		/// <exception cref="DBConcurrencyException">�폜�Ɏ��s�����ꍇ</exception>
		/// <returns>�폜���ꂽ����</returns>
		public int Delete(DbCommand cmd, TopDisplayKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_TOP_DISPLAY WHERE DISPLAY_ID = " + ProviderUtil.GetParameterName("DISPLAY_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DISPLAY_ID", providerType, key.DisplayId));

			// �폜
			int count = cmd.ExecuteNonQuery();

			if (count == 0)
			{
				// �r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_TOP_DISPLAY �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

	}
}
