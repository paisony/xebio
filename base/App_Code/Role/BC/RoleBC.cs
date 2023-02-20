// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Policy;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Role.Dac;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Systems.Dac;
using System.Reflection;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Role.BC
{
	public class RoleBC : BaseBC
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public RoleBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region �V�K�o�^
		/// <summary>
		/// ������V���ɒǉ������܂��B
		/// </summary>
		/// <param name="roleVO">���[��VO</param>
		/// <param name="authRoleMapVO">���[�������ݒ�VO</param>
		/// <returns>����������true�A���s�������O��Ԃ��܂��B</returns>
		public bool InsertRoleData(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			RoleDac roleDac = new RoleDac(connection);
			SystemAuthorizationDac authDac = new SystemAuthorizationDac(connection);
			FunctionAuthorizationDac funcDac = new FunctionAuthorizationDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				DataTable dt = roleDac.Select(cmd, (RoleKey)roleVO);
				if (dt.Rows.Count == 0)
				{
					if (string.IsNullOrEmpty(roleVO.RoleId))
					{
						IDGeneratorDac idGen = new IDGeneratorDac(connection);
						//�e�[�u���̎����̔Ԃ����܂�
						string newId = idGen.GetNextID(IDGenerateTables.TABLE_ROLE);
						roleVO.RoleId = newId;
					}

					// ���[���e�[�u���ɋl�߂�f�[�^���������܂��B
					roleVO.CreateDateTime = DateTime.Now;
					roleVO.CreateUserID = loginUserInfo.LoginId;
					roleVO.UpdateDateTime = DateTime.Now;
					roleVO.UpdateUserID = loginUserInfo.LoginId;

					// ���[���e�[�u���Ƀf�[�^��}�����܂�
					roleDac.Insert(cmd, roleVO);
					foreach (SystemAuthorizationVO vo in authVOs)
					{
						vo.RoleId = roleVO.RoleId;
						authDac.Insert(cmd, vo);
					}
					foreach (FunctionAuthorizationVO vo in funcVOs)
					{
						vo.RoleId = roleVO.RoleId;
						funcDac.Insert(cmd, vo);
					}

					DataLogVO dataLogVO = new DataLogVO();
					RoleDac rd = new RoleDac(connection);
					DataTable logdt = rd.Select(cmd, (RoleKey)roleVO);
					dataLogVO.Updateuserid = loginUserInfo.LoginId;
					dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_INSERT;
					dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					DataLogDac dataLogDac = new DataLogDac(connection);

					//�V�K�o�^
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					dataLogVO.Logdatetime = DateTime.Now;
					logdt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_ROLE;
					dataLogVO.LogData = XmlUtility.ConvertXML(logdt);
					dataLogDac.Insert(cmd, dataLogVO);

					logdt = authDac.SelectByRoleId(cmd, roleVO.RoleId);
					dataLogVO.Logdatetime = DateTime.Now;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					logdt.TableName = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
					dataLogVO.LogData = XmlUtility.ConvertXML(logdt);
					dataLogDac.Insert(cmd, dataLogVO);

					logdt = funcDac.SelectByRoleId(cmd, roleVO.RoleId);
					dataLogVO.Logdatetime = DateTime.Now;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					logdt.TableName = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
					dataLogVO.LogData = XmlUtility.ConvertXML(logdt);
					dataLogDac.Insert(cmd, dataLogVO);
				}
				else
				{
					BusinessError error = new BusinessError("���[��ID���d�����Ă��܂��B",
							   RoleErrorCode.DUPLICATION_ROLE_ID_ERROR);
					throw new BusinessException(error);
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
		#endregion

		#region �X�V
		/// <summary>
		/// �������X�V���܂��B
		/// </summary>
		/// <param name="roleVO">���[��VO</param>
		/// <param name="authRoleMapVO">���[�������ݒ�VO</param>
		/// <returns>����������true�A���s�������O��Ԃ��܂��B</returns>
		public bool UpdateRoleData(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			RoleDac roleDac = new RoleDac(connection);
			SystemAuthorizationDac authDac = new SystemAuthorizationDac(connection);
			FunctionAuthorizationDac funcDac = new FunctionAuthorizationDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				DataTable dt = roleDac.Select(cmd, (RoleKey)roleVO);
				if (dt.Rows.Count == 0)
				{
					throw new ApplicationException("���[����񂪑��݂��܂���B");
				}

				// ���j���[HTML�̍폜
				MenuSetCacheDac cacheDac = new MenuSetCacheDac(connection);
				cacheDac.DeleteAll();

				// ���[���e�[�u���ɋl�߂�f�[�^���������܂��B
				roleVO.UpdateDateTime = DateTime.Now;
				roleVO.UpdateUserID = loginUserInfo.LoginId;

				roleDac.Update(cmd, roleVO);

				//���̃��[���̎g�p����S�폜����B
				funcDac.DeleteByRoleId(cmd,roleVO.RoleId);
				//���̃��[���̎g�p����S�폜����B
				authDac.DeleteByRoleId(cmd, roleVO.RoleId);

				foreach (SystemAuthorizationVO vo in authVOs)
				{
					vo.RoleId = roleVO.RoleId;
					authDac.Insert(cmd, vo);
				}

				foreach (FunctionAuthorizationVO vo in funcVOs)
				{
					vo.RoleId = roleVO.RoleId;
					funcDac.Insert(cmd,vo);
				}

				DataLogVO dataLogVO = new DataLogVO();
				DataTable logDt = new DataTable();
				RoleDac rd = new RoleDac(connection);
				dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				dataLogVO.Updateuserid = loginUserInfo.LoginId;
				dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				DataLogDac dataLogDac = new DataLogDac(connection);

				//�X�V
				logDt = rd.Select(cmd, (RoleKey)roleVO);
				dataLogVO.Logdatetime = DateTime.Now;
				dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
				logDt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE;
				dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_ROLE;
				dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
				dataLogDac.Insert(cmd, dataLogVO);

				logDt = authDac.SelectByRoleId(cmd, roleVO.RoleId);
				dataLogVO.Logdatetime = DateTime.Now;
				dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
				logDt.TableName = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
				dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
				dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
				dataLogDac.Insert(cmd, dataLogVO);

				logDt = funcDac.SelectByRoleId(cmd,roleVO.RoleId);
				dataLogVO.Logdatetime = DateTime.Now;
				dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
				logDt.TableName = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
				dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
				dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
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

		#region �폜
		/// <summary>
		/// ���[���e�[�u���̎�L�[�����ɍ폜���܂��B
		/// ��l�ł����[�U���폜���錠���������Ă����ꍇ��
		/// �폜�����ɃG���[�R�[�h��Ԃ��܂��B
		/// </summary>
		/// <param name="key">���[���e�[�u���̎�L�[</param>
		/// <returns>����������true�A���s�������O�I�u�W�F�N�g��Ԃ��܂��B</returns>
		public bool DeleteRoleData(RoleKey key, string rowUpdateId)
		{
			RoleDac roleDac = new RoleDac(connection);
			RoleUserMapDac userDac = new RoleUserMapDac(connection);
			SystemAuthorizationDac systemDac = new SystemAuthorizationDac(connection);
			FunctionAuthorizationDac funcDac = new FunctionAuthorizationDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("ROLE_ID", null, null, key.RoleId));
				int count = userDac.Count(cmd, query);

				// �폜�����L�[��BS_ROLE_USER_MAP�Ɋi�[����Ă��邩�`�F�b�N
				if (count == 0)
				{
					// BS_FUNCTION_AUTHORIZATION���폜
					funcDac.DeleteByRoleId(cmd, key.RoleId);

					// BS_SYSTEM_AUTHORIZATION���폜
					systemDac.DeleteByRoleId(cmd, key.RoleId);

					// BS_ROLE���폜
					roleDac.Delete(cmd, key, rowUpdateId);

					DataLogVO dataLogVO = new DataLogVO();
					DataTable logDt = new DataTable();
					DataColumn column = new DataColumn("ROLE_ID", System.Type.GetType("System.String"));
					logDt.Columns.Add(column);
					DataRow row = logDt.NewRow();
					row["ROLE_ID"] = key.RoleId;
					RoleVO roleVO = new RoleVO();
					roleVO.RoleId = key.RoleId;
					logDt.Rows.Add(row);

					dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					dataLogVO.Updateuserid = loginUserInfo.LoginId;
					dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_DELETE;
					DataLogDac dataLogDac = new DataLogDac(connection);

					dataLogVO.Logdatetime = DateTime.Now;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					logDt.TableName = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_FUNCTION_AUTHORIZATION;
					dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
					dataLogDac.Insert(cmd, dataLogVO);

					dataLogVO.Logdatetime = DateTime.Now;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					logDt.TableName = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_SYSTEM_AUTHORIZATION;
					dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
					dataLogDac.Insert(cmd, dataLogVO);
					dataLogVO.Logdatetime = DateTime.Now;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE;
					logDt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE;
					dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_ROLE;
					dataLogVO.LogData = XmlUtility.ConvertXML(logDt);
					dataLogDac.Insert(cmd, dataLogVO);
				}
				else
				{
					BusinessError error = new BusinessError("���[���̍폜�Ɏ��s���܂����B(" + key.RoleId + ")", RoleErrorCode.DeleteRoleAuthorityError);
					throw new BusinessException(error);
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
		#endregion

		#region UpdateRoleUserMap
		/// <summary>
		/// UpdateRoleUserMap
		/// </summary>
		/// <param name="keyValues"></param>
		/// <returns></returns>
		public bool UpdateRoleUserMap(RoleVO roleVO, RoleUserMapVO[] mapVOs)
		{
			RoleDac roleDac = new RoleDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac cacheDac = new MenuSetCacheDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				roleVO.UpdateUserID = loginUserInfo.LoginId;
				roleVO.UpdateDateTime = DateTime.Now;

				Com.Fujitsu.SmartBase.Base.LoginUser.Dac.LoginUserDac loginUserDac = new Com.Fujitsu.SmartBase.Base.LoginUser.Dac.LoginUserDac(connection);
				foreach (RoleUserMapVO vo in mapVOs)
				{
					DataTable dt = loginUserDac.SelectByLoginId(cmd, vo.LoginId);
					if (dt.Rows.Count == 0)
					{
						BusinessError error = new BusinessError("���[���̃}�b�s���O�Ɏ��s���܂����B(" + vo.LoginId + ")", RoleErrorCode.UserRoleMappingError);
						throw new BusinessException(error);
					}
				}
				roleDac.Update(cmd, roleVO);

				//���j���[�L���b�V���S�폜
				cacheDac.DeleteAll();
				//�}�b�s���O��S�폜
				mapDac.DeleteByRoleId(cmd, roleVO.RoleId);
				//�}�b�s���O�̑S�ǉ�
				foreach (RoleUserMapVO vo in mapVOs)
				{
					mapDac.Insert(cmd, vo);
				}

				DataLogVO dataLogVO = new DataLogVO();
				dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				dataLogVO.Updateuserid = loginUserInfo.LoginId;
				dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP;

				DataTable logDt = mapDac.SelectByRoleId(cmd, roleVO.RoleId);
				logDt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP;
				dataLogVO.Tablename = ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP;
				dataLogVO.LogData = XmlUtility.ConvertXML(logDt);

				DataLogDac dataLogDac = new DataLogDac(connection);
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
	}
}
