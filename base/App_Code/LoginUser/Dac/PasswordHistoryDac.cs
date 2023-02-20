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
	/// <summary>
	/// BS_PASSWORD_HISTORY�e�[�u���Ƀf�[�^�x�[�X�A�N�Z�X����N���X�ł��B
	/// </summary>
	public class PasswordHistoryDac : BaseDac
	{
		#region �R���X�g���N�^

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PasswordHistoryDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// �p�X���[�h�����e�[�u��(BS_PASSWORD_HISTORY)��������̃��O�C��ID�������R�[�h���擾���܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>�������ʂ��i�[���ꂽ<see cref="DataTable"/></returns>
		public DataTable SelectByLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
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

		#region Count
		/// <summary>
		/// �����̃��O�C��ID�Ɉ�v�������R�[�h����Ԃ��܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>��v�������R�[�h��</returns>
		public int Count(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "SELECT COUNT(*) FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			DbParameter para = ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId);

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(para);

			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insert���܂�
		/// </summary>
		/// <param name="vo">�o�^��񂪊i�[���ꂽPasswordHistoryVO</param>
		/// <returns>SQL���̎��s�ɂ���ď������ꂽ���R�[�h����</returns>
		public int Insert(DbCommand cmd, PasswordHistoryVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_PASSWORD_HISTORY (LOGIN_ID,UPDATE_DATETIME,PASSWORD) VALUES ("
							  + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("PASSWORD", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDatetime));
			//PASSWORD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD", providerType, vo.Password));

			//�ǉ�
			return cmd.ExecuteNonQuery();
		}
		#endregion

		#region DeleteByLoginId
		/// <summary>
		/// �����̃��O�C��ID�����������R�[�h���폜���܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>SQL���̎��s�ɂ���ď������ꂽ���R�[�h����</returns>
		public int DeleteByLoginId(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "DELETE FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//�폜
			return cmd.ExecuteNonQuery();
		}
		#endregion
	}
}
