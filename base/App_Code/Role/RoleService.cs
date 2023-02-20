// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Transactions;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Role.BC;
using Com.Fujitsu.SmartBase.Base.Role.Dac;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Role
{
	/// <summary>
	/// �����̐V�K�o�^�A�ҏW�A�폜���̏������Ǘ�����N���X�ł��B
	/// </summary>
	public class RoleService : BaseService
	{
		#region �R���X�g���N�^
		public RoleService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{
		}
		#endregion

		#region ���[��
		#region GetRole
		/// <summary>
		/// ���[���̎�L�[��������擾���܂��B
		/// </summary>
		/// <param name="roleKey"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetRole(RoleKey roleKey)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleDac roleDac = new RoleDac(connection);
					dt = roleDac.Select(cmd, roleKey);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRole", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllRole
		/// <summary>
		/// �u�����E���j���[�Ǘ��v�{�^�����������Ƃ��ɌĂяo�����T�[�r�X���\�b�h�ł��B
		/// �������X�g�����ׂĎ擾���܂��B
		/// </summary>
		/// <returns></returns>
		public DataResult<DataTable> GetAllRole()
		{
			DataResult<DataTable> res;
			DataTable dt;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleDac roleDac = new RoleDac(connection);
					dt = roleDac.SelectAll(cmd);

					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllRole", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertRole
		/// <summary>
		/// ������V�K�o�^���܂��B
		/// �u�o�^�v�{�^�����������Ƃ��ɓ��삵�܂��B
		/// </summary>
		/// <param name="roleVO">���[���f�[�^</param>
		/// <param name="authRoleMapVO">���[�������ݒ�f�[�^</param>
		/// <returns></returns>
		public Result InsertRole(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			Result res;
			// ���͈����`�F�b�N
			if (roleVO == null)
			{
				throw new ArgumentNullException("RoleService.CreateRole: RoleVO��null�ł��B");
			}
			// �f�[�^���e�[�u���ɒǉ�
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					RoleBC bc = new RoleBC(loginUserInfo, connection);
					res = new Result(bc.InsertRoleData(roleVO, authVOs, funcVOs));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("CreateRole", ex);
			}
		}
		#endregion

		#region UpdateRole
		/// <summary>
		/// �������X�V���܂��B
		/// �u�X�V�v�{�^�����������Ƃ��ɓ��삵�܂��B
		/// </summary>
		/// <param name="roleVO">���[���f�[�^</param>
		/// <param name="authRoleMapVO">���[�������ݒ�f�[�^</param>
		/// <returns></returns>
		public Result UpdateRole(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			Result res;
			// ���͈����`�F�b�N
			if (roleVO == null)
			{
				throw new ArgumentNullException("RoleService.CreateRole: RoleVO��null�ł��B");
			}
			// �f�[�^���e�[�u���ɒǉ�
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					RoleBC bc = new RoleBC(loginUserInfo, connection);
					// roleVO��authRoleMapVO��V�K�o�^���܂��B
					res = new Result(bc.UpdateRoleData(roleVO, authVOs, funcVOs));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("CreateRole", ex);
			}
		}
		#endregion

		#region DeleteRole
		/// <summary>
		/// ���[���e�[�u���̎�L�[�����Ƀ��[���f�[�^�𕨗��폜���܂��B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Result DeleteRole(RoleKey key, string rowUpdateId)
		{
			Result res;
			// ���͈����`�F�b�N
			if (key == null)
			{
				throw new ArgumentNullException("RoleService.DeleteRole: RoleVO��null�ł��B");
			}
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					RoleBC bc = new RoleBC(loginUserInfo, connection);
					res = new Result(bc.DeleteRoleData(key, rowUpdateId));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("CreateRole", ex);
			}
		}
		#endregion
		#endregion

		#region ���[�U�ݒ�
		#region GetRoleUserMap
		/// <summary>
		/// ��L�[��������擾���܂��B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetRoleUserMap(RoleUserMapKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleUserMapDac roleDac = new RoleUserMapDac(connection);
					dt = roleDac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleUserMap", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllRoleUserMap
		/// <summary>
		/// �S���擾���܂��B
		/// </summary>
		/// <returns></returns>
		public DataResult<DataTable> GetAllRoleUserMap()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleUserMapDac roleDac = new RoleUserMapDac(connection);
					dt = roleDac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleUserMap", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetRoleUserMapByRoleId
		/// <summary>
		/// ���ID,���[��ID���烆�[�UID�f�[�^���擾���܂��B
		/// </summary>
		/// <param name="roleId">���[��ID</param>
		/// <returns></returns>
		public DataResult<DataTable> GetRoleUserByRoleId(string roleId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleRefDac roleDac = new RoleRefDac(connection);
					dt = roleDac.GetRoleUserByRoleId(cmd, roleId);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleUserMapByRoleId", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region UpdateRoleUserMap
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keyValues"></param>
		/// <returns></returns>
		public Result UpdateRoleUserMap(RoleVO roleVO, RoleUserMapVO[] mapVOs)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					RoleBC bc = new RoleBC(loginUserInfo, connection);
					res = new Result(bc.UpdateRoleUserMap(roleVO, mapVOs));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateRoleUserMap", ex);
			}
		}
		#endregion
		#endregion

		#region GetSystemAuthorization
		/// <summary>
		/// ��L�[����V�X�e���g�p���������擾���܂��B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetSystemAuthorization(SystemAuthorizationKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					SystemAuthorizationDac dac = new SystemAuthorizationDac(connection);
					dt = dac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetSystemAuthorization", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllSystemAuthorization
		/// <summary>
		/// ��L�[����V�X�e���g�p���������擾���܂��B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetAllSystemAuthorization()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					SystemAuthorizationDac dac = new SystemAuthorizationDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetSystemAuthorization", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetSystemAuthorizationByLoginUser
		/// <summary>
		/// ���O�C��ID����g�p���\�����[�V����ID��Ԃ��܂��B
		/// �����̃��[���Őݒ肳��Ă���ꍇ�͕\�����������������D�悳���B
		/// </summary>
		/// <param name="UserType"></param>
		/// <returns></returns>
		public DataResult<List<string>> GetSystemAuthorizationByLoginUser(string userType)
		{
			DataResult<List<string>> res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					AuthorizationRefDac dac = new AuthorizationRefDac(connection);
					List<string> list = dac.GetSystemAuthorizationByLoginUser(cmd, userType);
					List<string> resList = new List<string>();

					foreach (string solId in list)
					{
						if (!resList.Contains(solId))
							resList.Add(solId);
					}

					res = new DataResult<List<string>>(resList != null, resList);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<List<string>>)base.HandleException("GetSystemAuthorizationByLoginUser", ex, typeof(DataResult<List<string>>));
			}
		}
		#endregion

		#region GetSystemAuthorizationByRoleId
		/// <summary>
		/// ���[��ID����g�p���\�����[�V����ID��Ԃ��܂��B
		/// </summary>
		/// <param name="loginId"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetSystemAuthorizationByRoleId(string roleId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					SystemAuthorizationDac dac = new SystemAuthorizationDac(connection);
					dt = dac.SelectByRoleId(cmd, roleId);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetSystemAuthorizationByRoleId", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllFunctionAuthorization
		/// <summary>
		/// ���ׂĂ̋@�\�g�p������Ԃ��܂��B
		/// </summary>
		/// <returns></returns>
		public DataResult<DataTable> GetAllFunctionAuthorization()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					FunctionAuthorizationDac dac = new FunctionAuthorizationDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllFunctionAuthorization", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetFunctionAuthorization
		/// <summary>
		/// �@�\�g�p������Ԃ��܂��B
		/// <param name="roleId"></param>
		/// <param name="solutionId"></param>
		/// <param name="functionId"></param>
		/// </summary>
		/// <returns></returns>
		public DataResult<DataTable> GetFunctionAuthorization(string roleId, string solutionId, string functionId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					FunctionAuthorizationDac dac = new FunctionAuthorizationDac(connection);
					dt = dac.Selectrole(cmd, roleId, solutionId, functionId);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllFunctionAuthorization", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetFunctionAuthorization2
		/// <summary>
		/// �@�\�g�p������Ԃ��܂��B
		/// <param name="roleId"></param>
		/// <param name="solutionId"></param>
		/// <param name="functionId"></param>
		/// </summary>
		/// <returns></returns>
		public DataResult<DataTable> GetFunctionAuthorization2(string roleId, string solutionId, string functionId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					FunctionAuthorizationDac dac = new FunctionAuthorizationDac(connection);
					dt = dac.Selectrole2(cmd, roleId, solutionId, functionId);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllFunctionAuthorization2", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetFunctionAuthorizationByRoleId
		/// <summary>
		/// ���[��ID����@�\�g�p������Ԃ��܂��B
		/// </summary>
		/// <param name="loginId"></param>
		/// <returns></returns>
		public DataResult<DataTable> GetFunctionAuthorizationByRoleId(string roleId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					FunctionAuthorizationDac dac = new FunctionAuthorizationDac(connection);
					dt = dac.SelectByRoleId(cmd, roleId);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetFunctionAuthorizationByRoleId", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetRoleMappingStatusByCompanyId
		/// <summary>
		/// ��Ђh�c�����ɗ��p�҂̃��[���t�^�󋵂��擾����T�[�r�X���\�b�h�ł��B
		/// </summary>
		/// <param name="companyId">��Ђh�c</param>
		/// <returns>���[���t�^�󋵃f�[�^�Ǝ擾�̐���/���s�󋵃I�u�W�F�N�g</returns>
		public DataResult<DataTable> GetRoleMappingStatusByCompanyId(string companyId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleRefDac roleRefDac = new RoleRefDac(connection);
					dt = roleRefDac.GetRoleMappingStatusByCompanyId(cmd, companyId);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleMappingStatusByCompanyId", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion
	}
}
