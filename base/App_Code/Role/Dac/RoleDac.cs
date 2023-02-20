// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using System.Data;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Role.Dac
{
	public class RoleDac : BaseDac
	{
		#region �R���X�g���N�^
		public RoleDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// ��L�[��SELECT���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable Select(OracleCommand cmd, RoleKey key)
		{
			string query = @"SELECT * FROM BS_ROLE WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, key.RoleId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll
		/// <summary>
		/// ������Ȃ��ł��ׂẴf�[�^��SELECT���܂��B
		/// </summary>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable SelectAll(OracleCommand cmd)
		{
			string query = "SELECT * FROM BS_ROLE ORDER BY ROLE_ID";
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

		#region Insert
		/// <summary>
		/// INSERT���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���RoleVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Insert(DbCommand cmd, RoleVO vo)
		{
			cmd.CommandText = @"INSERT INTO BS_ROLE (ROLE_ID,ROLE_NAME,ROLE_NOTE,CREATE_DATETIME,CREATE_USER_ID,UPDATE_DATETIME,UPDATE_USER_ID,ROW_UPDATE_ID) VALUES ( "
						 + ProviderUtil.GetParameterName("ROLE_ID", providerType)
					+ "," + ProviderUtil.GetParameterName("ROLE_NAME", providerType)
					+ "," + ProviderUtil.GetParameterName("ROLE_NOTE", providerType)
					+ "," + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
					+ "," + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
					+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
					+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
					+ "," + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
					+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.CreateDateTime = DateTime.Now;
			vo.UpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, vo.RoleId));
			//ROLE_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_NAME", providerType, vo.RoleName));
			//ROLE_NOTE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_NOTE", providerType, vo.RoleNote));
			//CREATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			//CREATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));

			//�ǉ�
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_ROLE �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ��L�[��UPDATE���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���RoleVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Update(DbCommand cmd, RoleVO vo)
		{
			cmd.CommandText = "UPDATE BS_ROLE SET "
					+ " ROLE_NAME = " + ProviderUtil.GetParameterName("ROLE_NAME", providerType)
					+ ",ROLE_NOTE = " + ProviderUtil.GetParameterName("ROLE_NOTE", providerType)
					+ ",UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
					+ ",UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
					+ ",ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
					+ "  WHERE ROLE_ID       = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
					+ "    AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.UpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, vo.RoleId));
			//ROLE_NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_NAME", providerType, vo.RoleName));
			//ROLE_NOTE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_NOTE", providerType, vo.RoleNote));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));

			//�X�V
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_ROLE �r���G���[�ł��B");
			}

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ��L�[��DELETE���܂��B
		/// </summary>
		/// <param name="key">��L�[���l�܂���RoleKey</param>
		/// <returns>�폜���R�[�h��</returns>
		public int Delete(DbCommand cmd, RoleKey key, string rowUpdateId)
		{
			cmd.CommandText = @"DELETE FROM BS_ROLE WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType)
							+ " AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, key.RoleId));
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, rowUpdateId));

			//�폜
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_ROLE �r���G���[�ł��B");
			}
			return count;
		}
		#endregion
	}
}
