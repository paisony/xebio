// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.DataLog.BC
{
	public class DataLogBC : BaseBC
	{
		#region �R���X�g���N�^

		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public DataLogBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}

		#endregion

		#region �o�^

		/// <summary>
		/// �f�[�^���O���e�[�u���ɓo�^���܂�
		/// </summary>
		/// <param name="dataLogVO">�f�[�^���OVO</param>
		/// <returns></returns>
		public bool InsertDataLog(DataLogVO dataLogVO)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			DataLogDac dataLogDac = new DataLogDac(connection);
			DataSet ds = new DataSet();

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				dataLogVO.Updateuserid = loginUserInfo.LoginId;
				dataLogVO.Logdatetime = DateTime.Now;

				// �f�[�^��ʂő}������f�[�^����ʂ���
				if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN_USER)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_ROLE)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN_LOCK)
				{
				}
				else
				{
				}

				dataLogDac.Insert(cmd, dataLogVO);
			}
			catch (Exception)
			{
				cmd.Transaction.Rollback();
			}
			if (cmd.Transaction != null)
			{
				cmd.Transaction.Commit();
			}

			return true;
		}
		#endregion


		#region ���Ԏw��擾
		/// <summary>
		/// �w�肵�����ԁA�e�[�u���̃f�[�^���O��SELECT���܂��B
		/// </summary>
		/// <param name="key">Tablename���i�[���ꂽ�I�u�W�F�N�g</param>
		/// <param name="startDateTime">�擾�Ώۂ̊J�n����</param>
		///  <param name="endDateTime">�擾�Ώۂ̏I������</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable SelectByLogDateTime(OracleCommand cmd, DataLogVO dataLogVO, DateTime? startDateTime, DateTime endDateTime)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			DataLogDac dataLogDac = new DataLogDac(connection);
			DataTable tbl = new DataTable();

			tbl = dataLogDac.SelectByLogDateTime(cmd, dataLogVO, startDateTime, endDateTime);

			return tbl;
		}

		#endregion
	}
}
