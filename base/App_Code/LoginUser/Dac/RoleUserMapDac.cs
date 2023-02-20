// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Dac
{
	public class RoleUserMapDac : BaseDac
	{
		#region �R���X�g���N�^
		public RoleUserMapDac(OracleConnection connection)
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
		public DataTable Select(OracleCommand cmd, RoleUserMapKey key)
		{
			string query = "SELECT * FROM BS_ROLE_USER_MAP  WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
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

		#region SelectByLoginId
		/// <summary>
		/// ���O�C��ID���烍�[��ID�f�[�^���擾���܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns></returns>
		public DataTable SelectByLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_ROLE_USER_MAP WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectCount
		/// <summary>
		/// �����Ɉ�v�����s����Ԃ��܂��B
		/// </summary>
		/// <returns></returns>
		public int Count(DbCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			cmd.CommandText = "SELECT COUNT(*) FROM BS_ROLE_USER_MAP WHERE " + where.Key;
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			foreach (DbParameter para in where.Value)
			{
				cmd.Parameters.Add(para);
			}

			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERT���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���RoleUserMapVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Insert(DbCommand cmd, RoleUserMapVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_ROLE_USER_MAP (LOGIN_ID,ROLE_ID) VALUES ("
						+ ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("ROLE_ID", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//ROLE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, vo.RoleId));

			//�ǉ�
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteByLoginId
		/// <summary>
		/// loginId��DELETE���܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>�폜���R�[�h��</returns>
		public int DeleteByLoginId(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "DELETE FROM BS_ROLE_USER_MAP WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteByLoginId
		/// <summary>
		/// ���ׂ�DELETE���܂��B
		/// </summary>
		/// <returns>�폜���R�[�h��</returns>
		public int DeleteAll(DbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM BS_ROLE_USER_MAP";

			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
