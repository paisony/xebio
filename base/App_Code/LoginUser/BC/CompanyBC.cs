// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.LoginUser.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.BC
{
	public class CompanyBC : BaseBC
	{
		public CompanyBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}

		/// <summary>
		/// �V�K�o�^,�X�V
		/// </summary>
		/// <param name="vos"></param>
		/// <returns></returns>
		public bool InsertCompany(params CompanyVO[] vos)
		{
			CompanyDac dac = new CompanyDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				foreach (CompanyVO vo in vos)
				{
					DataTable dt = dac.Select(cmd, (CompanyKey)vo);

					if (dt.Rows.Count == 0)
					{
						vo.CreateUserID = loginUserInfo.LoginId;
						vo.UpdateUserID = loginUserInfo.LoginId;
						//�f�[�^��o�^����B
						dac.Insert(cmd, vo);
					}
					else
					{
						vo.UpdateUserID = loginUserInfo.LoginId;
						//�f�[�^��o�^����B
						dac.Update(cmd, vo);
					}
				}
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

		/// <summary>
		/// �폜
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		public bool DeleteCompany(params CompanyKey[] keys)
		{
			CompanyDac dac = new CompanyDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				foreach (CompanyKey key in keys)
				{
					CompanyVO vo = (CompanyVO)key;
					vo.UpdateUserID = loginUserInfo.LoginId;
					//�f�[�^��o�^����B
					dac.Delete(cmd,vo);
				}
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


		/// <summary>
		/// ���ׂĂ̗��p�ҍ폜
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool DeleteAllCompany()
		{
			CompanyDac dac = new CompanyDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//�f�[�^���폜����B
				dac.DeleteAll(cmd, loginUserInfo.LoginId);
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

		/// <summary>
		/// ���p�҂̃C���|�[�g Delete-Insert
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool ImportCompany(params CompanyVO[] vos)
		{
			CompanyDac dac = new CompanyDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//�f�[�^���폜����B
				dac.DeleteAll(cmd, loginUserInfo.LoginId);
				DataTable dt = dac.SelectAll(cmd);

				foreach (CompanyVO vo in vos)
				{
					DataRow[] rows = dt.Select("COMPANY_ID = '" + vo.CompanyId + "'");
					//�啶������������ʂ���B
					bool isExists = false;
					foreach (DataRow row in rows)
					{
						if (vo.CompanyId == Convert.ToString(row["COMPANY_ID"]))
						{
							isExists = true;
							break;
						}
					}
					if (isExists)
					{
						//�X�V
						vo.UpdateUserID = loginUserInfo.LoginId;
						vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;
						dac.Update(cmd, vo);
					}
					else
					{
						//�o�^
						vo.CreateUserID = loginUserInfo.LoginId;
						vo.UpdateUserID = loginUserInfo.LoginId;
						vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;
						dac.Insert(cmd, vo);
					}
				}
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
	}
}
