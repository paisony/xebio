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

		#region �R���X�g���N�^
		public LoginFailureDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// ��L�[SELECT���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable Select(OracleCommand cmd, LoginFailureKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_FAILURE " + "WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region CheckLoginId
		/// <summary>
		/// �����̃��O�C��ID�̃��R�[�h�����݂��邩�`�F�b�N���܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>�����̃��O�C��ID�Ɉ�v����s�������true �Ȃ����fasle</returns>
		public bool CheckLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_LOGIN_FAILURE " + " WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
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
		/// INSERT���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���LoginFailureVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		/// <exception cref="DBConcurrencyException">�}�����ʂ�0���̎�</exception>
		public int Insert(DbCommand cmd, LoginFailureVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_LOGIN_FAILURE (LOGIN_ID,FAILURE_COUNT) VALUES ("
						+ ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("FAILURE_COUNT", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//FAILURE_COUNT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FAILURE_COUNT", providerType, vo.FailureCount));

			//�ǉ�
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_LOGIN_FAILURE �r���G���[�ł��B");
			}
			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ��L�[��UPDATE���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���LoginFailureVO</param>
		/// <exception cref="DBConcurrencyException">�X�V���ʂ�0���̎�</exception>
		/// <returns>�X�V���R�[�h��</returns>
		public int Update(DbCommand cmd, LoginFailureVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_FAILURE SET"
						+ " FAILURE_COUNT = " + ProviderUtil.GetParameterName("FAILURE_COUNT", providerType)
						+ " WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//FAILURE_COUNT
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("FAILURE_COUNT", providerType, vo.FailureCount));

			//�X�V
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("�e�[�u���FBS_LOGIN_FAILURE �r���G���[�ł��B");
			}
			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ��L�[�ŕ����폜���܂��B
		/// �r�������͂��܂���B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int PhysicalDelete(DbCommand cmd, LoginFailureKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_FAILURE WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
