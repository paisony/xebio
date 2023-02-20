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
		#region コンストラクタ
		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public RoleBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region 新規登録
		/// <summary>
		/// 権限を新たに追加もします。
		/// </summary>
		/// <param name="roleVO">ロールVO</param>
		/// <param name="authRoleMapVO">ロール権限設定VO</param>
		/// <returns>成功したらtrue、失敗したら例外を返します。</returns>
		public bool InsertRoleData(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			// Dacごとにインスタンスを生成します。
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
						//テーブルの自動採番をします
						string newId = idGen.GetNextID(IDGenerateTables.TABLE_ROLE);
						roleVO.RoleId = newId;
					}

					// ロールテーブルに詰めるデータを準備します。
					roleVO.CreateDateTime = DateTime.Now;
					roleVO.CreateUserID = loginUserInfo.LoginId;
					roleVO.UpdateDateTime = DateTime.Now;
					roleVO.UpdateUserID = loginUserInfo.LoginId;

					// ロールテーブルにデータを挿入します
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

					//新規登録
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
					BusinessError error = new BusinessError("ロールIDが重複しています。",
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

		#region 更新
		/// <summary>
		/// 権限を更新します。
		/// </summary>
		/// <param name="roleVO">ロールVO</param>
		/// <param name="authRoleMapVO">ロール権限設定VO</param>
		/// <returns>成功したらtrue、失敗したら例外を返します。</returns>
		public bool UpdateRoleData(RoleVO roleVO, SystemAuthorizationVO[] authVOs, FunctionAuthorizationVO[] funcVOs)
		{
			// Dacごとにインスタンスを生成します。
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
					throw new ApplicationException("ロール情報が存在しません。");
				}

				// メニューHTMLの削除
				MenuSetCacheDac cacheDac = new MenuSetCacheDac(connection);
				cacheDac.DeleteAll();

				// ロールテーブルに詰めるデータを準備します。
				roleVO.UpdateDateTime = DateTime.Now;
				roleVO.UpdateUserID = loginUserInfo.LoginId;

				roleDac.Update(cmd, roleVO);

				//このロールの使用許可を全削除する。
				funcDac.DeleteByRoleId(cmd,roleVO.RoleId);
				//このロールの使用許可を全削除する。
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

				//更新
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

		#region 削除
		/// <summary>
		/// ロールテーブルの主キーを元に削除します。
		/// 一人でもユーザが削除する権限を持っていた場合は
		/// 削除せずにエラーコードを返します。
		/// </summary>
		/// <param name="key">ロールテーブルの主キー</param>
		/// <returns>成功したらtrue、失敗したら例外オブジェクトを返します。</returns>
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

				// 削除する主キーがBS_ROLE_USER_MAPに格納されているかチェック
				if (count == 0)
				{
					// BS_FUNCTION_AUTHORIZATIONを削除
					funcDac.DeleteByRoleId(cmd, key.RoleId);

					// BS_SYSTEM_AUTHORIZATIONを削除
					systemDac.DeleteByRoleId(cmd, key.RoleId);

					// BS_ROLEを削除
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
					BusinessError error = new BusinessError("ロールの削除に失敗しました。(" + key.RoleId + ")", RoleErrorCode.DeleteRoleAuthorityError);
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
						BusinessError error = new BusinessError("ロールのマッピングに失敗しました。(" + vo.LoginId + ")", RoleErrorCode.UserRoleMappingError);
						throw new BusinessException(error);
					}
				}
				roleDac.Update(cmd, roleVO);

				//メニューキャッシュ全削除
				cacheDac.DeleteAll();
				//マッピングを全削除
				mapDac.DeleteByRoleId(cmd, roleVO.RoleId);
				//マッピングの全追加
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
