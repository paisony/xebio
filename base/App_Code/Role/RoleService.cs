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
	/// 権限の新規登録、編集、削除等の処理を管理するクラスです。
	/// </summary>
	public class RoleService : BaseService
	{
		#region コンストラクタ
		public RoleService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{
		}
		#endregion

		#region ロール
		#region GetRole
		/// <summary>
		/// ロールの主キーから情報を取得します。
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
		/// 「権限・メニュー管理」ボタンを押したときに呼び出されるサービスメソッドです。
		/// 権限リストをすべて取得します。
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
		/// 権限を新規登録します。
		/// 「登録」ボタンを押したときに動作します。
		/// </summary>
		/// <param name="roleVO">ロールデータ</param>
		/// <param name="authRoleMapVO">ロール権限設定データ</param>
		/// <returns></returns>
		public Result InsertRole(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			Result res;
			// 入力引数チェック
			if (roleVO == null)
			{
				throw new ArgumentNullException("RoleService.CreateRole: RoleVOがnullです。");
			}
			// データをテーブルに追加
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
		/// 権限を更新します。
		/// 「更新」ボタンを押したときに動作します。
		/// </summary>
		/// <param name="roleVO">ロールデータ</param>
		/// <param name="authRoleMapVO">ロール権限設定データ</param>
		/// <returns></returns>
		public Result UpdateRole(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			Result res;
			// 入力引数チェック
			if (roleVO == null)
			{
				throw new ArgumentNullException("RoleService.CreateRole: RoleVOがnullです。");
			}
			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					RoleBC bc = new RoleBC(loginUserInfo, connection);
					// roleVOとauthRoleMapVOを新規登録します。
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
		/// ロールテーブルの主キーを元にロールデータを物理削除します。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Result DeleteRole(RoleKey key, string rowUpdateId)
		{
			Result res;
			// 入力引数チェック
			if (key == null)
			{
				throw new ArgumentNullException("RoleService.DeleteRole: RoleVOがnullです。");
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

		#region ユーザ設定
		#region GetRoleUserMap
		/// <summary>
		/// 主キーから情報を取得します。
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
		/// 全件取得します。
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
		/// 会社ID,ロールIDからユーザIDデータを取得します。
		/// </summary>
		/// <param name="roleId">ロールID</param>
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
		/// 主キーからシステム使用権限情報を取得します。
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
		/// 主キーからシステム使用権限情報を取得します。
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
		/// ログインIDから使用許可ソリューションIDを返します。
		/// 複数のロールで設定されている場合は表示順が小さい方が優先される。
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
		/// ロールIDから使用許可ソリューションIDを返します。
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
		/// すべての機能使用許可情報を返します。
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
		/// 機能使用許可情報を返します。
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
		/// 機能使用許可情報を返します。
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
		/// ロールIDから機能使用許可情報を返します。
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
		/// 会社ＩＤを元に利用者のロール付与状況を取得するサービスメソッドです。
		/// </summary>
		/// <param name="companyId">会社ＩＤ</param>
		/// <returns>ロール付与状況データと取得の成功/失敗状況オブジェクト</returns>
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
