// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT1障害対応[QA-0664]
// 2012/11/19 WT)Banno OM障害対応[OM-813]

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model;

using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.LoginUser.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Certification.BC;
using System.Transactions;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using System.Web.UI.WebControls;
using System.Web;
using System.Configuration;
using Com.Fujitsu.SmartBase.Base.Web.Menu;
using Com.Fujitsu.SmartBase.Library.Log;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.BC
{
	public class LoginUserBC : BaseBC
	{
		/// <summary>
		/// ログ出力
		/// </summary>
		private static ILogger logger = LogManager.GetLogger();

		public LoginUserBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}

		#region 画面使用
		#region 照会
		/// <summary>
		/// 照会
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public DataTable GetLoginUserData(LoginUserKey key)
		{
			// TODO yusy DbCommand⇒OracleCommand
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;

			LoginUserDac loginuserDac = new LoginUserDac(connection);
			DataTable dt = loginuserDac.Select(cmd, key);

			//パスワード復号
			AESCryptUtility aes = new AESCryptUtility();

			foreach (DataRow row in dt.Rows)
			{
				string pass = Convert.ToString(row["PASSWORD"]);
				if (!string.IsNullOrEmpty(pass))
				{
					row["PASSWORD"] = aes.ExecuteDecode(pass);
				}
			}
			return dt;
		}
		#endregion

		#region 利用者検索
		/// <summary>
		/// 検索
		/// </summary>
		/// <param name="queryObj"></param>
		/// <returns></returns>
		public DataTable FindLoginUser(QueryObject queryObj)
		{

			LoginUserDac loginuserDac = new LoginUserDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;

			DataTable dt = loginuserDac.Find(cmd, queryObj);

			return dt;
		}
		#endregion

		#region 利用者登録
		/// <summary>
		/// 新規登録
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool InsertLoginUser(LoginUserVO vo)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			LoginFailureDac failureDac = new LoginFailureDac(connection);
			PasswordHistoryDac passwordhistoryDao = new PasswordHistoryDac(connection);
			RoleUserMapDac roleusermapDao = new RoleUserMapDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//ログインIDの重複をチェックする。
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));

				DataTable dt = userDac.Find(cmd, query);
				if (dt.Rows.Count != 0)
				{
					//既に登録されている。重複エラー

					BusinessError error = new BusinessError("ログインIDが重複している、または使用できないIDです。", LoginUserErrorCode.DUPLICATION_LOGIN_ID_ERROR);
					throw new BusinessException(error);
				}

				vo.CreateUserID = loginUserInfo.LoginId;
				vo.UpdateUserID = loginUserInfo.LoginId;

				vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
				vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

				//データ物理削除
				LoginFailureVO vo1 = new LoginFailureVO();
				vo1.LoginId = vo.LoginId;
				failureDac.PhysicalDelete(cmd, (LoginFailureKey)vo1);
				passwordhistoryDao.DeleteByLoginId(cmd, vo.LoginId);
				roleusermapDao.DeleteByLoginId(cmd, vo.LoginId);
				userDac.PhysicalDelete(cmd, (LoginUserKey)vo);

				//パスワード暗号化
				AESCryptUtility aes = new AESCryptUtility();
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

				//データを登録する。
				userDac.Insert(cmd, vo);
				failureDac.Insert(cmd, vo1);

				//BS_DATA_LOGに記録
				DataTable logdt = userDac.Select(cmd, (LoginUserKey)vo);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_INSERT;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);
				datalogDac.Insert(cmd, logVo);
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

		#region 利用者一括アップロード
		/// <summary>
		/// 利用者一括アップロード
		/// </summary>
		/// <param name="vos"></param>
		/// <param name="isUpdate"></param>
		/// <returns></returns>
		public bool InsertLoginUser(LoginUserVO[] vos, bool isUpdate)
		{

			LoginUserDac userDac = new LoginUserDac(connection);
			LoginFailureDac failureDac = new LoginFailureDac(connection);
			PasswordHistoryDac passwordhistoryDao = new PasswordHistoryDac(connection);
			RoleUserMapDac roleusermapDao = new RoleUserMapDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			List<BusinessError> errors = new List<BusinessError>();

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				if (!isUpdate)
				{
					int i = 1;
					foreach (LoginUserVO vo in vos)
					{
						//ログインIDの重複をチェックする。
						QueryObject query = new QueryObject();
						query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));

						DataTable dt = userDac.Find(cmd, query);
						if (dt.Rows.Count != 0)
						{
							//既に登録されている。重複エラー
							BusinessError error = new BusinessError(i + "行目：ログインIDが重複している、または使用できないIDです。", LoginUserErrorCode.DUPLICATION_LOGIN_ID_ERROR);
							errors.Add(error);
						}
						i++;
					}

					if (errors.Count > 0)
						throw new BusinessException(errors);

					//追加
					foreach (LoginUserVO vo in vos)
					{
						vo.CreateUserID = loginUserInfo.LoginId;
						vo.UpdateUserID = loginUserInfo.LoginId;

						vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
						vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

						//データ物理削除
						LoginFailureVO vo1 = new LoginFailureVO();
						vo1.LoginId = vo.LoginId;
						failureDac.PhysicalDelete(cmd, (LoginFailureKey)vo1);

						passwordhistoryDao.DeleteByLoginId(cmd, vo.LoginId);

						roleusermapDao.DeleteByLoginId(cmd, vo.LoginId);

						userDac.PhysicalDelete(cmd, (LoginUserKey)vo);

						//パスワード暗号化
						AESCryptUtility aes = new AESCryptUtility();
						vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

						//データを登録する。
						userDac.Insert(cmd, vo);
						failureDac.Insert(cmd, vo1);

						//BS_DATA_LOGに記録
						DataTable logdt = userDac.Select(cmd, (LoginUserKey)vo);
						logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
						DataLogVO logVo = new DataLogVO();
						logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
						logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
						logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_INSERT;
						logVo.Updateuserid = loginUserInfo.LoginId;
						logVo.Tablename = "";
						logVo.LogData = XmlUtility.ConvertXML(logdt);

						datalogDac.Insert(cmd, logVo);
					}
				}
				else
				{
					//更新
					this.ImportLoginUser(vos);
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
		/// InsertLoginUser
		/// </summary>
		/// <param name="vos"></param>
		/// <param name="maps"></param>
		/// <param name="isUpdate"></param>
		/// <returns></returns>
		public bool InsertLoginUser(LoginUserVO[] vos, RoleUserMapVO[] maps, bool isUpdate)
		{
			InsertLoginUser(vos, isUpdate);

			LoginUserDac userDac = new LoginUserDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac cacheDac = new MenuSetCacheDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			RoleDac roleDac = new RoleDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				List<BusinessError> errors = new List<BusinessError>();

				//メニューキャッシュ全削除
				cacheDac.DeleteAll(cmd);

				DataTable mapDt = new DataTable();
				mapDt.Columns.Add(new DataColumn("LOGIN_ID"));
				mapDt.Columns.Add(new DataColumn("ROLE_ID"));

				foreach (RoleUserMapVO map in maps)
				{
					DataRow mapRow = mapDt.NewRow();
					mapRow["LOGIN_ID"] = map.LoginId;
					mapRow["ROLE_ID"] = map.RoleId;
					mapDt.Rows.Add(mapRow);
				}

				int i = 1;
				foreach (LoginUserVO vo in vos)
				{
					//マッピングを全削除
					mapDac.DeleteByLoginId(cmd, vo.LoginId);
					DataRow[] mapRows = mapDt.Select(string.Format("LOGIN_ID = '{0}'", vo.LoginId));
					foreach (DataRow mapRow in mapRows)
					{
						int roleCount = roleDac.SelectCount(cmd, Convert.ToString(mapRow["ROLE_ID"]));
						if (roleCount == 0)
						{
							//既に登録されている。重複エラー
							BusinessError error = new BusinessError(string.Format("{0}行目：指定したロールは存在しないIDです。{1}", i, Convert.ToString(mapRow["ROLE_ID"])), CommonErrorCode.DB_NOT_FIND_RECORD_ERROR);
							errors.Add(error);
						}
					}
					i++;
				}
				if (errors.Count > 0)
				{
					throw new BusinessException(errors);
				}
				foreach (RoleUserMapVO vo in maps)
				{
					mapDac.Insert(cmd, vo);
				}

				foreach (LoginUserVO vo in vos)
				{
					//BS_DATA_LOGに記録
					DataTable logdt = mapDac.SelectByLoginId(cmd, vo.LoginId);
					logdt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP;
					DataLogVO logVo = new DataLogVO();
					logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					logVo.Programid = DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP;
					logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
					logVo.Updateuserid = loginUserInfo.LoginId;
					logVo.Tablename = "";
					logVo.LogData = XmlUtility.ConvertXML(logdt);
					datalogDac.Insert(cmd, logVo);
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

		#region 利用者一括INSERT/UPDATE（利用者アップロードAPI用）
		/// <summary>
		/// 更新ＡＰＩ
		/// </summary>
		/// <param name="vos"></param>
		/// <param name="maps"></param>
		/// <returns></returns>
		public bool InsertUpdateLoginUser(LoginUserVO[] vos, RoleUserMapVO[] maps)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			LoginFailureDac failureDac = new LoginFailureDac(connection);
			RoleUserMapDac roleusermapDao = new RoleUserMapDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			List<BusinessError> errors = new List<BusinessError>();

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//追加
				for (int i = 0; i < vos.Length; i++)
				{
					LoginUserVO vo = vos[i];

					//ログインIDの重複をチェックする。
					QueryObject query = new QueryObject();
					query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));

					DataTable dt = userDac.Find(cmd, query);

					if (dt.Rows.Count != 0)
					{
						vo.Password = Convert.ToString(dt.Rows[0]["PASSWORD"]);
						vo.OldPassword = Convert.ToString(dt.Rows[0]["PASSWORD"]);
						vo.CompanyID = Convert.ToString(dt.Rows[0]["COMPANY_ID"]);
						vo.UpdateUserID = loginUserInfo.LoginId;
						vo.TempPasswordFlag = Convert.ToString(dt.Rows[0]["TEMP_PASSWORD_FLAG"]);
						vo.PasswordUpdateDateTime = Convert.ToDateTime(dt.Rows[0]["PASSWORD_UPDATE_DATETIME"]);
						vo.RowUpdateId = Convert.ToString(dt.Rows[0]["ROW_UPDATE_ID"]);
						vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;
						vo.LoginId = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);

						//パスワード暗号化
						AESCryptUtility aes = new AESCryptUtility();
						vo.OldPassword = string.IsNullOrEmpty(vo.OldPassword) ? null : aes.ExecuteDecode(vo.OldPassword);

						//データを更新する。
						userDac.Update(cmd, vo);

						//BS_DATA_LOGに記録
						DataTable logdt = userDac.Select(cmd, (LoginUserKey)vo);
						logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
						DataLogVO logVo = new DataLogVO();
						logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
						logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
						logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
						logVo.Updateuserid = loginUserInfo.LoginId;
						logVo.Tablename = "";
						logVo.LogData = XmlUtility.ConvertXML(logdt);
						datalogDac.Insert(cmd, logVo);
					}
					else
					{
						LoginUserVO[] insertVos = new LoginUserVO[1];
						insertVos[0] = vo;

						List<RoleUserMapVO> insertMaps = new List<RoleUserMapVO>();
						foreach (RoleUserMapVO map in maps)
						{
							if (vo.LoginId == map.LoginId)
							{
								insertMaps.Add(map);
							}
						}
						InsertLoginUser(insertVos, insertMaps.ToArray(), false);
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
		#endregion

		#region 利用者情報編集
		/// <summary>
		/// 編集
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool UpdateLoginUser(LoginUserVO vo)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				vo.UpdateUserID = loginUserInfo.LoginId;
				if (vo.OldPassword != vo.Password)
				{
					//ログイン失敗回数をクリアする
					LoginFailureDac failureDac = new LoginFailureDac(connection);
					LoginFailureVO vo1 = new LoginFailureVO();
					vo1.LoginId = vo.LoginId;
					vo1.FailureCount = 0;
					failureDac.Update(cmd, vo1);
				}
				//パスワード暗号化
				AESCryptUtility aes = new AESCryptUtility();
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);
				//データを更新する。
				userDac.Update(cmd, vo);

				//BS_DATA_LOGに記録
				DataTable logdt = userDac.Select(cmd, (LoginUserKey)vo);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);

				datalogDac.Insert(cmd, logVo);

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

		#region 利用者削除
		/// <summary>
		/// 利用者を論理削除します。
		/// </summary>
		/// <remarks>
		/// 処理概要
		/// 1.利用者の削除
		/// 2.削除した利用者のログイン情報の削除
		/// </remarks>
		/// <param name="vo">利用者VO</param>
		/// <returns>削除に失敗他場合はtrue</returns>
		public bool DeleteLoginUser(LoginUserVO vo)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac dataLogDac = new DataLogDac(connection);
			LoginInfoDac infoDac = new LoginInfoDac(connection);
			LoginCertDac certDac = new LoginCertDac(connection);
			LoginLogDac loginLogDac = new LoginLogDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac menuDac = new MenuSetCacheDac(connection);
			CertificationBC certbc = new CertificationBC(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//1.利用者の削除
				vo.UpdateUserID = loginUserInfo.LoginId;
				//データを削除する
				userDac.Delete(cmd, vo);

				// ロールユーザマッピングを取得。
				DataTable mapTbl = mapDac.SelectByLoginId(cmd, vo.LoginId);

				// ロールユーザマッピングを削除
				if (mapTbl.Rows.Count > 0)
				{
					// ロールユーザマッピングをDBから削除
					mapDac.DeleteByLoginId(cmd, vo.LoginId);

					// ログテーブルに記録
					DataTable logDt = new DataTable(ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP);
					DataColumn column = new DataColumn("LOGIN_ID", System.Type.GetType("System.String"));
					logDt.Columns.Add(column);
					column = new DataColumn("ROLE_ID", System.Type.GetType("System.String"));
					logDt.Columns.Add(column);

					foreach (DataRow row in mapTbl.Rows)
					{
						DataRow newRow = logDt.NewRow();
						newRow["LOGIN_ID"] = vo.LoginId;
						newRow["ROLE_ID"] = Convert.ToString(row["ROLE_ID"]);

						logDt.Rows.Add(newRow);
					}

					DataLogVO datalogVo = new DataLogVO();
					datalogVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					datalogVo.Programid = DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP;
					datalogVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_DELETE;
					datalogVo.Updateuserid = loginUserInfo.LoginId;
					datalogVo.Tablename = "";
					datalogVo.LogData = XmlUtility.ConvertXML(logDt);

					dataLogDac.Insert(cmd, datalogVo);
				}

				//メニューを削除
				menuDac.DeleteByLoginId(cmd, vo.LoginId);
				//BS_DATA_LOGに記録
				DataTable logdt = userDac.SelectAll(cmd, (LoginUserKey)vo);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_DELETE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);
				dataLogDac.Insert(cmd, logVo);

				//2.削除した利用者のログイン情報の削除
				//削除したログイン者情報を検索
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));
				DataTable dt = infoDac.Find(cmd, query);

				foreach (DataRow row in dt.Rows)
				{
					string infoId = Convert.ToString(row["LOGIN_INFO_ID"]);
					string loginId = Convert.ToString(row["LOGIN_ID"]);

					//LoginCertテーブル削除
					certDac.DeleteByLoginInfoID(cmd, infoId);

					//LoginInfoテーブル削除
					LoginInfoKey infoKey = new LoginInfoKey();
					infoKey.LoginInfoId = infoId;
					infoDac.Delete(cmd, infoKey);

					//LoginLog登録
					ExLoginUserInfoVO infoVo = certbc.GetServerInfoVO();
					//削除された利用者IDをセット
					infoVo.LoginId = loginId;
					//ログインログの登録
					LoginLogVO loginLogVo = new LoginLogVO();
					//ログイン者ID
					loginLogVo.LoginID = loginId;
					//ログインログ登録
					loginLogVo.LogDatetime = DateTime.Now;
					//ログインログのタイプ
					loginLogVo.LogType = LoginLogType.CompulsoryLogout;
					//アプリサーバのIPアドレス
					loginLogVo.IPAddress = infoVo.IPAddress;
					//アプリサーバのホスト名
					loginLogVo.PCName = infoVo.PCName;
					loginLogDac.Insert(cmd, loginLogVo);

					//データログ登録
					//BS_DATA_LOGに記録
					DataTable loginLogDT = loginLogDac.Select(cmd, loginLogVo);
					loginLogDT.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;
					DataLogVO dataLogVO = new DataLogVO();
					dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
					dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_LOGINLOGOUT;
					dataLogVO.Updateuserid = loginUserInfo.LoginId;
					dataLogVO.Tablename = "";
					dataLogVO.LogData = XmlUtility.ConvertXML(loginLogDT);
					dataLogDac.Insert(cmd, dataLogVO);
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

		#region ロックフラグ変更
		/// <summary>
		/// ロックフラグ変更
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool UpdateLockFlag(LoginUserVO vo)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			LoginUserVO userVo = new LoginUserVO();

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//ロックフラグチェック
				bool isLock = false;
				if (vo.LockFlag == ConstantUtil.LOCK_FLAG_ON)
				{
					//ログイン失敗回数をクリアする
					LoginFailureDac failureDac = new LoginFailureDac(connection);
					LoginFailureVO failureVo = new LoginFailureVO();
					failureVo.LoginId = vo.LoginId;
					failureVo.FailureCount = 0;

					if (failureDac.Select(cmd, (LoginFailureKey)failureVo).Rows.Count > 0)
						failureDac.Update(cmd, failureVo);
					else
						failureDac.Insert(cmd, failureVo);

					isLock = true;
				}
				//ロック状態を変更する
				userDac.UpdateLockFlag(cmd, vo, isLock, loginUserInfo.LoginId);

				//BS_DATA_LOGに記録
				DataTable logdt = userDac.Select(cmd, vo);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_LOCK;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);

				datalogDac.Insert(cmd, logVo);
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
		/// 利用者をロックします。(ログイン時に使用)
		/// </summary>
		/// <remarks>
		/// 利用者が一定回数以上ログインに失敗した時に利用者ロックを
		/// かけるためのメソッドです。
		/// </remarks>
		/// <param name="key">利用者情報の主キー</param>
		/// <returns></returns>
		public bool UpdateLockFlagByLoginFailure(LoginUserKey key)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//利用者をロックする
				userDac.UpdateLockFlag(cmd, key, false, loginUserInfo.LoginId);

				//BS_DATA_LOGに記録
				DataTable logdt = userDac.Select(cmd, key);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);
				datalogDac.Insert(cmd, logVo);
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

		/// <summary>
		/// 利用者をロックします。(ログイン時に使用)
		/// </summary>
		/// <remarks>
		/// 利用者が一定回数以上ログインに失敗した時に利用者ロックを
		/// かけるためのメソッドです。
		/// </remarks>
		/// <param name="key">利用者情報の主キー</param>
		/// <returns></returns>
		public bool UpdateLockFlagByLoginFailure2(OracleCommand cmd, LoginUserKey key)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);

			//利用者をロックする
			userDac.UpdateLockFlag(cmd, key, false, loginUserInfo.LoginId);

			//BS_DATA_LOGに記録
			DataTable logdt = userDac.Select(cmd, key);
			logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
			DataLogVO logVo = new DataLogVO();
			logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
			logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
			logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
			logVo.Updateuserid = loginUserInfo.LoginId;
			logVo.Tablename = "";
			logVo.LogData = XmlUtility.ConvertXML(logdt);
			datalogDac.Insert(cmd, logVo);

			return true;
		}
		#endregion

		#region パスワード変更
		/// <summary>
		/// パスワードを更新する
		/// </summary>
		/// <remarks>
		/// 処理内容：
		/// 1.(エラーチェック)画面で入力された古いパスワードとDBの古いパスワードが一致するか
		/// 2.(エラーチェック)画面で入力された新しいパスワードがパスワード履歴に登録されているか
		/// 3.パスワード更新
		/// 4.パスワード更新ログを出力
		/// 5.パスワード履歴の削除
		/// </remarks>
		/// <param name="vo">更新内容の利用者情報が格納されたLoginUserVO</param>
		/// <param name="oldPassword">画面から入力された古いパスワード</param>
		/// <param name="pwdLogNum">パスワード履歴の保存数(0以上の整数)</param>
		/// <exception cref="BusinessException">
		/// 1.DBの古いパスワードと画面から入力された古いパスワードが一致しない
		/// 2.新しいパスワードがパスワード履歴に格納されている
		/// </exception>
		/// <exception cref="ArgumentException">
		/// パスワード履歴の保存数が0よりも小さい値
		/// </exception>
		/// <returns>更新に成功した場合はtrue</returns>
		public bool UpdatePasswordLoginUser(LoginUserVO vo, string oldPassword, int pwdLogNum)
		{
			if (pwdLogNum < 0)
			{
				throw new ArgumentException("パスワード履歴の保存件数が不正です。0以上の整数値を設定してください。");
			}

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				LoginUserDac loginUserDac = new LoginUserDac(connection);
				PasswordHistoryDac pwdHisDac = new PasswordHistoryDac(connection);
				DataLogDac datalogDac = new DataLogDac(connection);
				AESCryptUtility aes = new AESCryptUtility();

				//1.古いパスワードが正しいか
				DataTable loginUserDT = loginUserDac.Select(cmd, vo);
				if (loginUserDT.Rows.Count > 0)
				{
					//パスワード暗号化
					if (!string.IsNullOrEmpty(oldPassword))
					{
						// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update START ---------------
						if (!oldPassword.ToUpper().Equals(aes.ExecuteDecode(loginUserDT.Rows[0]["PASSWORD"].ToString()).ToUpper()))
						// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update  END ---------------
						{
							BusinessError error = new BusinessError("古いパスワードが一致しません。", LoginUserErrorCode.PASSWORD_ERROR);
							throw new BusinessException(error);
						}
					}
				}

				//2.パスワード履歴
				//パスワード履歴の保存数が0件の時はパスワード履歴をチェックしない
				if (pwdLogNum != 0)
				{
					DataTable pwdHisDT = pwdHisDac.SelectByLoginId(cmd, vo.LoginId);
					if (pwdHisDT.Rows.Count > 0)
					{
						//パスワードの入力チェック
						//if (string.IsNullOrEmpty(vo.Password))
						//    throw new ArgumentException("新しいパスワードが取得できません。");

						DataRow[] rows = pwdHisDT.Select("", "UPDATE_DATETIME DESC");
						for (int i = 0; i < pwdLogNum && i < rows.Length; ++i)
						{
							// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update START ---------------
							if (vo.Password.ToUpper().Equals(aes.ExecuteDecode(rows[i]["PASSWORD"].ToString()).ToUpper()))
							// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update  END ---------------
							{
								BusinessError error = new BusinessError("設定した新しいパスワードは過去に使用されています。別のパスワードを設定してください。",
								LoginUserErrorCode.PASSWORD_HISTORY_DUPLICATION_ERROR);
								throw new BusinessException(error);
							}
						}
					}
				}
				// 3.パスワードの更新
				//更新者IDのセット
				vo.UpdateUserID = loginUserInfo.LoginId;
				//更新日時をセット
				vo.UpdateDateTime = DateTime.Now;
				vo.PasswordUpdateDateTime = DateTime.Now;
				//パスワード暗号化
				string anAesPassword = vo.Password;
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);
				//パスワードを更新
				loginUserDac.UpdatePassword(cmd, vo, anAesPassword);

				// 4.パスワード更新ログの出力
				//ログイン者の利用者情報の取得
				DataTable logDT = loginUserDac.Select(cmd, (LoginUserKey)vo);
				logDT.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logDT);
				datalogDac.Insert(cmd, logVo);

				// 5.パスワード履歴の挿入／削除
				if (pwdLogNum == 0)
				{
					//パスワード履歴の保存数が0の場合はログイン者のパスワード履歴を全削除
					pwdHisDac.DeleteByLoginId(cmd, vo.LoginId);
				}
				else
				{
					//パスワード履歴VOの生成
					PasswordHistoryVO pwdHisVO = new PasswordHistoryVO();
					pwdHisVO.LoginID = vo.LoginId;
					pwdHisVO.UpdateDatetime = vo.PasswordUpdateDateTime;
					pwdHisVO.Password = vo.Password;
					//新しいパスワード情報を履歴に挿入
					pwdHisDac.Insert(cmd, pwdHisVO);

					int pwdHisCount = pwdHisDac.Count(cmd, vo.LoginId);

					//パスワード履歴数が設定値よりも大きい時
					if (pwdLogNum < pwdHisCount)
					{
						//パスワード履歴の取得(更新日時の降順)
						DataTable tmpPwdHisDT = pwdHisDac.SelectByLoginId(cmd, vo.LoginId);
						DataRow[] tmpPwdHisDR = tmpPwdHisDT.Select("", "UPDATE_DATETIME DESC");
						//パスワード履歴を全削除
						pwdHisDac.DeleteByLoginId(cmd, vo.LoginId);

						//パスワード履歴VOの生成
						PasswordHistoryVO tmpVO = new PasswordHistoryVO();
						//パスワード履歴テーブルに「パスワード履歴の保存数」だけ履歴を挿入する
						for (int i = 0; i < pwdLogNum; i++)
						{
							tmpVO.LoginID = Convert.ToString(tmpPwdHisDR[i]["LOGIN_ID"]);
							tmpVO.UpdateDatetime = Convert.ToDateTime(tmpPwdHisDR[i]["UPDATE_DATETIME"]);
							tmpVO.Password = Convert.ToString(tmpPwdHisDR[i]["PASSWORD"]);
							//パスワード履歴に挿入
							pwdHisDac.Insert(cmd, tmpVO);
						}
					}
				}
			}
			catch (Exception)
			{
				cmd.Transaction.Rollback();
				throw;
			}
			if (cmd.Transaction != null)
			{
				cmd.Transaction.Commit();
			}

			return true;
		}
		#endregion

		#region ログイン失敗情報
		#region InsertLoginFailure
		/// <summary>
		/// ログイン失敗情報を追加します。
		/// </summary>
		/// <param name="vo">ログイン失敗情報VO</param>
		/// <exception cref="ArgumentException">主キーに値が設定されていない</exception>
		/// <returns>成功したらtrueを返します。失敗したら<see cref="DBConcurrencyException"/>を投げます。</returns>
		public bool InsertLoginFailure(DbCommand cmd, LoginFailureVO vo)
		{
			//引数チェック
			if (string.IsNullOrEmpty(vo.LoginId)) throw new ArgumentException("LoginFailureBC.InsertLoginFailure:引数が不正です");

			try
			{
				LoginFailureDac dac = new LoginFailureDac(connection);
				//追加
				dac.Insert(cmd, vo);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
		#endregion

		#region UpdateLoginFailure
		/// <summary>
		/// ログイン失敗情報を更新します。
		/// </summary>
		/// <param name="vo">更新対象のvo</param>
		/// <returns></returns>
		public bool UpdateLoginFailure(DbCommand cmd, LoginFailureVO vo)
		{
			try
			{
				LoginFailureDac failureDac = new LoginFailureDac(connection);
				failureDac.Update(cmd, vo);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return true;
		}
		#endregion
		#endregion

		#region ログイン検証
		/// <summary>
		/// ログイン時のID/PWチェックを行います。
		/// </summary>
		/// <param name="infoVo">ユーザ情報が格納されたvo</param>
		/// <param name="password">ログイン者のパスワード</param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns></returns>
		public Result CheckLoginAvailable(ExLoginUserInfoVO infoVo, string password, string userType)
		{
			//検証実行
			LoginValidateResult validRes = this.LoginValidate(infoVo, password, userType);
			//検証結果の分岐処理
			return this.ValidateResultCheck(validRes);
		}

		/// <summary>
		/// ログイン検証
		/// </summary>
		/// <param name="infoVo"></param>
		/// <param name="password"></param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns></returns>
		private LoginValidateResult LoginValidate(ExLoginUserInfoVO infoVo, string password, string userType)
		{
			string loginId = infoVo.LoginId;
			LoginUserDac loginUserdac = new LoginUserDac(connection);
			string logPassword = password;

			// TODO yusy add DbCommand ⇒ OracleCommand
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;

            // TODO yusy test
            cmd.CommandText = "select * from BS_LOGIN_USER where LOGIN_ID = :loginid";
			DbParameter dp = new OracleParameter("loginid", 2212059);
            cmd.Parameters.Add(dp);
            DbDataReader reader = cmd.ExecuteReader();

            try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				#region BC/DACインスタンスの生成
				LoginFailureDac loginFailureDac = new LoginFailureDac(connection);
				LoginUserBC loginUserBC = new LoginUserBC(loginUserInfo, connection);
				CertificationBC certBC = new CertificationBC(connection);
				#endregion

				//実在するログインIDであるか？
				if (!loginUserdac.CheckId(cmd, loginId))
				{
					//実在しない
					logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByIdNoExist;
				}
				if (Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_OPERATION_CHECK]))
				{
					bool oprResult = LoginValidateOperation(cmd, loginId, userType);
					if (!oprResult)
					{
						//運用時間外によるログイン失敗。ログインログ，データログの追加。
						certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByOperationTime, infoVo, null);
						logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
						return LoginValidateResult.FailureByOperationTime;
					}
				}

				DataTable loginUserDT = loginUserdac.Select(cmd, new LoginUserKey(loginId));

				// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update START ---------------
				AESCryptUtility aes = new AESCryptUtility();
				String pw = loginUserdac.CheckIdPassword(cmd, loginId);
				if (pw != null && password.ToUpper().Equals(aes.ExecuteDecode(pw).ToUpper()))
				{
				// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update  END ---------------
					//ID/PASSWORDが正しい
					if (Convert.ToString(loginUserDT.Rows[0]["LOCK_FLAG"]) == ConstantUtil.LOCK_FLAG_OFF)
					{
						//ログイン成功
						return LoginValidateResult.LoginAllowed;
					}
					else
					{
						//ユーザロックされている
						// ログインログ，データログの追加
						certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByUserLock, infoVo, null);
						logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
						return LoginValidateResult.FailureByUserLock;
					}
				}

				//ID/PASSWORDが違う場合
				//ログイン者のユーザ種別チェック
				if (Convert.ToString(loginUserDT.Rows[0]["USER_TYPE"]) != ConstantUtil.LOGIN_USER_TYPE_GENERAL)
				{
					//一般ユーザ以外（管理者，予約語ログインID）の場合はエラーとする

					// ログインログ，データログの追加
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByInvalidPassword;
				}

				//ログイン失敗情報の追加
				DataTable loginFailureDT = loginFailureDac.Select(cmd, new LoginFailureKey(loginId));
				LoginFailureVO failureVO = new LoginFailureVO();

				//失敗回数
				int failureCount;
				if (loginFailureDT.Rows.Count == 0)
				{
					//ログイン失敗レコードが存在しない
					failureVO.LoginId = loginId;
					failureCount = 1;
					failureVO.FailureCount = failureCount;
					loginUserBC.InsertLoginFailure(cmd, failureVO);
				}
				else
				{
					//存在する
					failureVO.LoginId = loginId;
					failureCount = Convert.ToInt32(loginFailureDT.Rows[0]["FAILURE_COUNT"]) + 1;
					failureVO.FailureCount = failureCount;
					loginUserBC.UpdateLoginFailure(cmd, failureVO);
				}

				//ログイン失敗カウントのチェック

				//ログイン失敗の許容回数（回）の取得
				int allowCount = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["LoginFailureAllowCount"].Value);
				if (allowCount == 0)
				{
					// ログイン失敗の許容回数が0だったらパスワードミスのログのみ出力

					// ログインログ，データログの追加
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					//パスワード入力ミス
					logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByInvalidPassword;
				}
				else if (failureCount > allowCount)
				{
					//ログイン失敗数が許容範囲外なので利用者をロック
					loginUserBC.UpdateLockFlagByLoginFailure2(cmd, new LoginUserKey(loginId));

					// ログインログ，データログの追加
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByUserLock, infoVo, null);
					//ユーザロック
					logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByUserLock;
				}
				else
				{
					// ログイン失敗数が許容範囲内なのでパスワード入力ミスの旨を画面に表示

					// ログインログ，データログの追加
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					logger.Error("エラーログインＩＤ：" + infoVo.LoginId + "(" + logPassword + ")");
					//パスワード入力ミス
					return LoginValidateResult.FailureByInvalidPassword;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				cmd.Transaction.Rollback();
				return LoginValidateResult.FailureByOperationTime;
			}
			finally
			{
				if (cmd.Transaction != null)
				{
					cmd.Transaction.Commit();
				}
			}
		}
		#endregion

		/// <summary>
		/// 運用時間チェックを行います。
		/// </summary>
		/// <param name="infoVo">ユーザ情報が格納されたvo</param>
		/// <param name="loginId">ログインＩＤ</param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns></returns>
		public Boolean CheckLoginAvailableOperation(ExLoginUserInfoVO infoVo, string loginId, string userType)
		{
			Boolean Res = false;
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;
				//検証実行
				Res = this.LoginValidateOperation(cmd, loginId, userType);
				//検証結果の分岐処理
			}
			catch (Exception)
			{
				cmd.Transaction.Rollback();
			}
			finally
			{
				if (cmd.Transaction != null)
				{
					cmd.Transaction.Commit();
				}
			}

			return Res;
		}

		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
		/// <summary>
		/// オンライン中かチェックします。
		/// </summary>
		/// <param name="loginId">ログインＩＤ</param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns></returns>
		public Boolean CheckLoginAvailableOnline(string loginId, string userType)
		{
			Boolean Res = false;
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;
				//検証実行
				Res = this.LoginValidateOnline(cmd, loginId, userType);
				//検証結果の分岐処理
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				cmd.Transaction.Rollback();
			}
			finally
			{
				if (cmd.Transaction != null)
				{
					cmd.Transaction.Commit();
				}
			}
			return Res;
		}
		#region LoginValidateOpration
		/// <summary>
		/// オンライン中かチェックします。
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="password"></param>
		/// <param name="userType"></param>
		/// <returns></returns>
		private Boolean LoginValidateOnline(OracleCommand cmd, string loginId, string userType)
		{
			LoginUserDac loginUserdac = new LoginUserDac(connection);
			if (loginId != null)
			{
				if (userType == null)
				{
					userType = "0";
					if (loginUserdac.CheckUser(cmd, loginId))
					{
						userType = "1";
					}
				}
				//システム管理者であるか？ 
				if (!ConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER.Equals(userType))
				{
                    return true;
                }
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}

			return false;
		}
		#endregion
		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  END ---------------

		#region LoginValidateOpration
		/// <summary>
		/// 運用時間内かチェックします。
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="password"></param>
		/// <param name="userType"></param>
		/// <returns></returns>
		private Boolean LoginValidateOperation(OracleCommand cmd, string loginId, string userType)
		{
			LoginUserDac loginUserdac = new LoginUserDac(connection);
			if (userType == null)
			{
				userType = "0";
				if (loginUserdac.CheckUser(cmd, loginId))
				{
					userType = "1";
				}
			}
			//システム管理者であるか？ 
			if (!ConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER.Equals(userType))
			{
				//管理者ではない
				#region 設定内容を取得
				DataTable dt = null;
				string startTime = "";
				string stopTime = "";
				if (HttpContext.Current.Application[WebConstantUtil.OPERATION_START + "0"] == null
					|| HttpContext.Current.Cache.Get(WebConstantUtil.OPERATION_TIME_INIT) == null
					|| ((String)HttpContext.Current.Cache.Get(WebConstantUtil.OPERATION_TIME_INIT)).Equals("init"))
				{
					for (int i = 0; i < 7; i++)
					{
						dt = loginUserdac.SelectTime(cmd, Convert.ToString(i));
						if (dt.Rows.Count > 0)
						{
							startTime = dt.Rows[0]["START_TIME"].ToString();
							stopTime = dt.Rows[0]["STOP_TIME"].ToString();
							HttpContext.Current.Application.Lock();
							HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_START + Convert.ToString(i));
							HttpContext.Current.Application.Add(WebConstantUtil.OPERATION_START + Convert.ToString(i), startTime);
							HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_STOP + Convert.ToString(i));
							HttpContext.Current.Application.Add(WebConstantUtil.OPERATION_STOP + Convert.ToString(i), stopTime);
							HttpContext.Current.Application.UnLock();
						}
					}
					for (int i = 0; i < 7; i++)
					{
						if (HttpContext.Current.Application[WebConstantUtil.OPERATION_START + Convert.ToString(i)] == null)
						{
							HttpContext.Current.Application.Lock();
							HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_START + Convert.ToString(i));
							HttpContext.Current.Application.Add(WebConstantUtil.OPERATION_START + Convert.ToString(i), "0000");
							HttpContext.Current.Application.UnLock();
						}
						if (HttpContext.Current.Application[WebConstantUtil.OPERATION_STOP + Convert.ToString(i)] == null)
						{
							HttpContext.Current.Application.Lock();
							HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_STOP + Convert.ToString(i));
							HttpContext.Current.Application.Add(WebConstantUtil.OPERATION_STOP + Convert.ToString(i), "4759");
							HttpContext.Current.Application.UnLock();
						}
					}
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_TIME_INIT);
					HttpContext.Current.Cache.Insert(WebConstantUtil.OPERATION_TIME_INIT, "set", null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
					HttpContext.Current.Application.UnLock();

				}
				#endregion

				#region 時間帯チェック
				DateTime time = DateTime.Now;
				string hh = time.TimeOfDay.Hours.ToString();
				string mm = time.TimeOfDay.Minutes.ToString();
				if (mm.Length == 1)
				{
					mm = "0" + mm;
				}

				string type = time.DayOfWeek.ToString("d");
				string todayStartTime = (string)HttpContext.Current.Application[WebConstantUtil.OPERATION_START + type];
				string todayStopTime = (string)HttpContext.Current.Application[WebConstantUtil.OPERATION_STOP + type];
				int yesterday = System.Convert.ToInt16(type);
				if (yesterday == 0)
				{
					yesterday = 6;
				}
				else
				{
					yesterday = yesterday - 1;
				}
				string yesterdayStartTime = (string)HttpContext.Current.Application[WebConstantUtil.OPERATION_START + Convert.ToString(yesterday)];
				string yesterdayStopTime = (string)HttpContext.Current.Application[WebConstantUtil.OPERATION_STOP + Convert.ToString(yesterday)];

				if (Convert.ToInt32(hh + mm) < Convert.ToInt32(todayStartTime))
				{
					if (Convert.ToInt32(hh + mm) + 2400 > Convert.ToInt32(yesterdayStopTime))
					{
						return false;
					}
				}
				else
				{
					if (Convert.ToInt32(hh + mm) > Convert.ToInt32(todayStopTime))
					{
						return false;
					}
				}
				#endregion

			}

			return true;
		}
		#endregion

		#region UpdateUserRoleMap
		/// <summary>
		/// 利用者とロールマッピングを更新します。
		/// </summary>
		/// <param name="keyValues"></param>
		/// <returns></returns>
		public bool UpdateUserRoleMap(LoginUserVO userVO, RoleUserMapVO[] mapVOs)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac cacheDac = new MenuSetCacheDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			RoleDac roleDac = new RoleDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

				cmd.Transaction = transaction;

				userVO.UpdateUserID = loginUserInfo.LoginId;
				//userVO.UpdateDateTime = DateTime.Now;

				//パスワード暗号化
				AESCryptUtility aes = new AESCryptUtility();
				userVO.Password = string.IsNullOrEmpty(userVO.Password) ? null : aes.ExecuteEncode(userVO.Password);

				userDac.Update(cmd, userVO);

				//メニューキャッシュ全削除
				cacheDac.DeleteByLoginId(cmd, userVO.LoginId);

				//マッピングを全削除
				mapDac.DeleteByLoginId(cmd, userVO.LoginId);
				int roleCount;
				foreach (RoleUserMapVO vo in mapVOs)
				{
					roleCount = roleDac.SelectCount(cmd, vo.RoleId);
					if (roleCount > 0)
					{
						mapDac.Insert(cmd, vo);
					}
				}
				//BS_DATA_LOGに記録
				DataTable logdt = mapDac.SelectByLoginId(cmd, userVO.LoginId);
				logdt.TableName = ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP;
				DataLogVO logVo = new DataLogVO();
				logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
				logVo.Programid = DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP;
				logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_UPDATE;
				logVo.Updateuserid = loginUserInfo.LoginId;
				logVo.Tablename = "";
				logVo.LogData = XmlUtility.ConvertXML(logdt);
				datalogDac.Insert(cmd, logVo);
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

		#region IsExistRoleId
		/// <summary>
		/// ロールIDが存在するかどうかをチェックします。
		/// </summary>
		/// <param name="keyValues">RoleUserMapVOの配列</param>
		/// <returns>true:存在する false:存在しない</returns>
		public bool IsExistRoleId(DbCommand cmd, RoleUserMapVO[] mapVOs)
		{
			RoleDac roleDac = new RoleDac(connection);

			foreach (RoleUserMapVO vo in mapVOs)
			{
				if (roleDac.SelectCount(cmd, vo.RoleId) != 1)
				{
					return true;
				}
			}

			return false;
		}
		#endregion

		#region Smart SOA連携
		/// <summary>
		/// 検索
		/// </summary>
		/// <param name="queryObj"></param>
		/// <returns></returns>
		public DataTable FindSyncLoginUser(OracleCommand cmd, QueryObject queryObj)
		{
			LoginUserDac loginuserDac = new LoginUserDac(connection);
			DataTable dt = loginuserDac.FindSyncLoginUser(cmd, queryObj);

			//パスワード復号
			AESCryptUtility aes = new AESCryptUtility();

			foreach (DataRow row in dt.Rows)
			{
				row["PASSWORD"] = aes.ExecuteDecode(Convert.ToString(row["PASSWORD"]));
			}

			return dt;
		}

		/// <summary>
		/// すべての利用者削除
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool DeleteAllLoginUser()
		{
			LoginUserDac dac = new LoginUserDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac menuDac = new MenuSetCacheDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//データを削除する。
				dac.DeleteAll(cmd, loginUserInfo.LoginId);

				//ロールユーザマッピングを削除
				mapDac.DeleteAll(cmd);

				//メニューの削除
				menuDac.DeleteAll(cmd);

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
		/// 利用者のインポート Delete-Insert
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
		public bool ImportLoginUser(params LoginUserVO[] vos)
		{
			LoginUserDac dac = new LoginUserDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac menuDac = new MenuSetCacheDac(connection);
			LoginFailureDac failureDac = new LoginFailureDac(connection);
			PasswordHistoryDac passwordhistoryDac = new PasswordHistoryDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);
			LoginInfoDac infoDac = new LoginInfoDac(connection);
			LoginLogDac loginLogDac = new LoginLogDac(connection);
			LoginCertDac certDac = new LoginCertDac(connection);
			CertificationBC certbc = new CertificationBC(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//更新前に全件取得
				DataTable beforeDt = dac.FindSyncLoginUser(cmd, new QueryObject());
				//データを削除する。
				dac.DeleteAll(cmd, loginUserInfo.LoginId);

				foreach (LoginUserVO vo in vos)
				{
					DataRow[] rows = beforeDt.Select(string.Format("LOGIN_ID = '{0}' AND DELETE_FLAG = '{1}'", vo.LoginId, ConstantUtil.DELETE_FLAG_OFF));

					//パスワード暗号化
					AESCryptUtility aes = new AESCryptUtility();
					vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

					vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
					vo.UpdateUserID = loginUserInfo.LoginId;
					vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

					string operation = null;
					if (rows.Length != 0)
					{
						operation = DataLogUtil.OPERATION_TYPE_OF_UPDATE;

						QueryObject qo = new QueryObject();
						qo.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));
						DataTable dt = dac.FindSyncLoginUser(cmd, qo);
						vo.RowUpdateId = Convert.ToString(dt.Rows[0]["ROW_UPDATE_ID"]);
						//更新
						dac.Update(cmd, vo);
					}
					else
					{
						operation = DataLogUtil.OPERATION_TYPE_OF_INSERT;
						//追加
						vo.CreateUserID = loginUserInfo.LoginId;

						LoginFailureVO failVo = new LoginFailureVO();
						failVo.LoginId = vo.LoginId;
						failureDac.PhysicalDelete(cmd, (LoginFailureKey)failVo);
						passwordhistoryDac.DeleteByLoginId(cmd, vo.LoginId);
						mapDac.DeleteByLoginId(cmd, vo.LoginId);
						dac.PhysicalDelete(cmd, (LoginUserKey)vo);
						dac.Insert(cmd, vo);
						failureDac.Insert(cmd, failVo);
					}

					//BS_DATA_LOGに記録
					DataTable logdt = dac.Select(cmd, (LoginUserKey)vo);
					logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
					DataLogVO logVo = new DataLogVO();
					logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
					logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
					logVo.Operationtype = operation;
					logVo.Updateuserid = loginUserInfo.LoginId;
					logVo.Tablename = "";
					logVo.LogData = XmlUtility.ConvertXML(logdt);
					datalogDac.Insert(cmd, logVo);
				}

				//削除済の利用者を取得
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("DELETE_FLAG", null, null, ConstantUtil.DELETE_FLAG_ON));

				DataTable delDt = dac.FindSyncLoginUser(cmd, query);
				foreach (DataRow row in delDt.Rows)
				{
					DataRow[] delRows = beforeDt.Select(string.Format("DELETE_FLAG = '{0}' AND LOGIN_ID = '{1}'", ConstantUtil.DELETE_FLAG_OFF, Convert.ToString(row["LOGIN_ID"])));
					if (delRows.Length == 0)
						continue;

					string loginId = Convert.ToString(row["LOGIN_ID"]);
					//ロールユーザマッピングを取得
					DataTable mapTbl = mapDac.SelectByLoginId(cmd, loginId);

					//メニューを削除
					menuDac.DeleteByLoginId(cmd, loginId);

					// ロールユーザマッピングを削除
					if (mapTbl.Rows.Count > 0)
					{
						//ロールユーザマッピングを削除。
						mapDac.DeleteByLoginId(cmd, loginId);

						// ログテーブルに記録
						DataTable logDt = new DataTable(ConstantUtil.TABLE_NAME_BS_ROLE_USER_MAP);
						DataColumn column = new DataColumn("LOGIN_ID", System.Type.GetType("System.String"));
						logDt.Columns.Add(column);
						column = new DataColumn("ROLE_ID", System.Type.GetType("System.String"));
						logDt.Columns.Add(column);

						foreach (DataRow mapRow in mapTbl.Rows)
						{
							DataRow newRow = logDt.NewRow();
							newRow["LOGIN_ID"] = loginId;
							newRow["ROLE_ID"] = Convert.ToString(mapRow["ROLE_ID"]);

							logDt.Rows.Add(newRow);
						}

						DataLogVO datalogVo = new DataLogVO();
						datalogVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
						datalogVo.Programid = DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP;
						datalogVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_DELETE;
						datalogVo.Updateuserid = loginUserInfo.LoginId;
						datalogVo.Tablename = "";
						datalogVo.LogData = XmlUtility.ConvertXML(logDt);
						datalogDac.Insert(cmd, datalogVo);

						//BS_DATA_LOGに記録
						LoginUserKey loginKey = new LoginUserKey();
						loginKey.LoginId = loginId;
						DataTable logdt = dac.Select(cmd, loginKey);
						logdt.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_USER;
						DataLogVO logVo = new DataLogVO();
						logVo.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
						logVo.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
						logVo.Operationtype = DataLogUtil.OPERATION_TYPE_OF_DELETE;
						logVo.Updateuserid = loginUserInfo.LoginId;
						logVo.Tablename = "";
						logVo.LogData = XmlUtility.ConvertXML(logdt);
						datalogDac.Insert(cmd, logVo);
					}

					//削除したログイン者情報を検索
					QueryObject query1 = new QueryObject();
					query1.AddFinder(Criteria.Equal("LOGIN_ID", null, null, loginId));
					DataTable dt = infoDac.Find(cmd, query1);
					foreach (DataRow row1 in dt.Rows)
					{
						string infoId = Convert.ToString(row1["LOGIN_INFO_ID"]);
						//LoginCertテーブル削除
						certDac.DeleteByLoginInfoID(cmd, infoId);
						//LoginInfoテーブル削除
						LoginInfoKey infoKey = new LoginInfoKey();
						infoKey.LoginInfoId = infoId;
						infoDac.Delete(cmd, infoKey);

						//LoginLog登録
						ExLoginUserInfoVO infoVo = certbc.GetServerInfoVO();
						//削除された利用者IDをセット
						infoVo.LoginId = loginId;
						//ログインログの登録
						LoginLogVO loginLogVo = new LoginLogVO();
						//ログイン者ID
						loginLogVo.LoginID = loginId;
						//ログインログ登録
						loginLogVo.LogDatetime = DateTime.Now;
						//ログインログのタイプ
						loginLogVo.LogType = LoginLogType.CompulsoryLogout;
						//アプリサーバのIPアドレス
						loginLogVo.IPAddress = infoVo.IPAddress;
						//アプリサーバのホスト名
						loginLogVo.PCName = infoVo.PCName;
						loginLogDac.Insert(cmd, loginLogVo);

						//データログ登録
						//BS_DATA_LOGに記録
						DataTable loginLogDT = loginLogDac.Select(cmd, loginLogVo);
						loginLogDT.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;
						DataLogVO dataLogVO = new DataLogVO();
						dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
						dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN_USER;
						dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_LOGINLOGOUT;
						dataLogVO.Updateuserid = loginUserInfo.LoginId;
						dataLogVO.Tablename = "";
						dataLogVO.LogData = XmlUtility.ConvertXML(loginLogDT);
						datalogDac.Insert(cmd, dataLogVO);
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
		/// 利用者の差分インポート
		/// </summary>
		/// <param name="updVos">追加・更新情報のVOの配列</param>
		/// <param name="delKeys">削除する情報のKeyの配列</param>
		public bool ImportDiffLoginUser(LoginUserVO[] updVos, LoginUserKey[] delKeys)
		{
			LoginUserDac dac = new LoginUserDac(connection);
			RoleUserMapDac mapDac = new RoleUserMapDac(connection);
			MenuSetCacheDac menuDac = new MenuSetCacheDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				foreach (LoginUserVO vo in updVos)
				{
					DataTable dt = dac.Select(cmd, (LoginUserKey)vo);

					//パスワード暗号化
					AESCryptUtility aes = new AESCryptUtility();
					vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

					vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
					vo.UpdateUserID = loginUserInfo.LoginId;
					vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

					if (dt.Rows.Count != 0)
					{
						vo.RowUpdateId = Convert.ToString(dt.Rows[0]["ROW_UPDATE_ID"]);
						//更新
						dac.Update(cmd, vo);
					}
					else
					{
						//追加
						vo.CreateUserID = loginUserInfo.LoginId;
						dac.PhysicalDelete(cmd, (LoginUserKey)vo);
						dac.Insert(cmd, vo);
					}
				}

				foreach (LoginUserKey key in delKeys)
				{
					DataTable dt = dac.Select(cmd, key);
					if (dt.Rows.Count != 0)
					{
						LoginUserVO vo = new LoginUserVO();
						vo.LoginId = key.LoginId;
						vo.UpdateUserID = loginUserInfo.LoginId;
						vo.RowUpdateId = Convert.ToString(dt.Rows[0]["ROW_UPDATE_ID"]);
						//削除
						dac.Delete(cmd, vo);
						//ロールユーザマッピングを削除。
						mapDac.DeleteByLoginId(cmd, vo.LoginId);
						//メニューを削除
						menuDac.DeleteByLoginId(cmd, vo.LoginId);
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
		#endregion

		/// <summary>
		/// 検証結果をチェックします。
		/// </summary>
		/// <param name="validResult">検証結果</param>
		/// <exception cref="BusinessException">
		/// 検証結果で下記のケースが発生した場合
		/// ・ログインIDが存在しない。
		/// ・入力したログインIDに対応するパスワードが異なる。
		/// ・ユーザがロックされている。
		/// </exception>
		/// <returns>
		/// 検証結果が正しい場合はResult.IsSuccessにtrueをセットし返却します。
		/// </returns>
		private Result ValidateResultCheck(LoginValidateResult validResult)
		{
			BusinessError error;

			switch (validResult)
			{
				case (LoginValidateResult.LoginAllowed):
					return new Result(true);

				case (LoginValidateResult.FailureByOperationTime):
					error = new BusinessError("システム運用時間外です。", LoginUserErrorCode.LOGIN_TIME_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByIdNoExist):
					error = new BusinessError("ログインに失敗しました。", LoginUserErrorCode.LOGIN_PASSWORD_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByInvalidPassword):
					error = new BusinessError("パスワードが違います。", LoginUserErrorCode.LOGIN_PASSWORD_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByUserLock):
					error = new BusinessError("ログインIDはロックされています。システム管理者にお問合せください。", LoginUserErrorCode.LOGIN_ID_LOCK_ERROR);
					throw new BusinessException(error);

				default:
					break;
			}

			return new Result(true);

		}
	}
}
