// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using System.Data;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Dac
{
	public class RoleDac : BaseDac
	{
		#region �R���X�g���N�^

		public RoleDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region SelectCount
		/// <summary>
		/// ��L�[��SELECT���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public int SelectCount(DbCommand cmd, string roleId)
		{
			cmd.CommandText = @"SELECT COUNT(*) FROM BS_ROLE WHERE ROLE_ID = " + ProviderUtil.GetParameterName("ROLE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROLE_ID", providerType, roleId));

			int res = Convert.ToInt32(cmd.ExecuteScalar());

			return res;
		}
		#endregion
	}
}
