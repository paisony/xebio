// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// ���ŗ���
// 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664]
// 2012/11/19 WT)Banno OM��Q�Ή�[OM-813]

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
		/// ���O�o��
		/// </summary>
		private static ILogger logger = LogManager.GetLogger();

		public LoginUserBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}

		#region ��ʎg�p
		#region �Ɖ�
		/// <summary>
		/// �Ɖ�
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public DataTable GetLoginUserData(LoginUserKey key)
		{
			// TODO yusy DbCommand��OracleCommand
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;

			LoginUserDac loginuserDac = new LoginUserDac(connection);
			DataTable dt = loginuserDac.Select(cmd, key);

			//�p�X���[�h����
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

		#region ���p�Ҍ���
		/// <summary>
		/// ����
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

		#region ���p�ғo�^
		/// <summary>
		/// �V�K�o�^
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

				//���O�C��ID�̏d�����`�F�b�N����B
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));

				DataTable dt = userDac.Find(cmd, query);
				if (dt.Rows.Count != 0)
				{
					//���ɓo�^����Ă���B�d���G���[

					BusinessError error = new BusinessError("���O�C��ID���d�����Ă���A�܂��͎g�p�ł��Ȃ�ID�ł��B", LoginUserErrorCode.DUPLICATION_LOGIN_ID_ERROR);
					throw new BusinessException(error);
				}

				vo.CreateUserID = loginUserInfo.LoginId;
				vo.UpdateUserID = loginUserInfo.LoginId;

				vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
				vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

				//�f�[�^�����폜
				LoginFailureVO vo1 = new LoginFailureVO();
				vo1.LoginId = vo.LoginId;
				failureDac.PhysicalDelete(cmd, (LoginFailureKey)vo1);
				passwordhistoryDao.DeleteByLoginId(cmd, vo.LoginId);
				roleusermapDao.DeleteByLoginId(cmd, vo.LoginId);
				userDac.PhysicalDelete(cmd, (LoginUserKey)vo);

				//�p�X���[�h�Í���
				AESCryptUtility aes = new AESCryptUtility();
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

				//�f�[�^��o�^����B
				userDac.Insert(cmd, vo);
				failureDac.Insert(cmd, vo1);

				//BS_DATA_LOG�ɋL�^
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

		#region ���p�҈ꊇ�A�b�v���[�h
		/// <summary>
		/// ���p�҈ꊇ�A�b�v���[�h
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
						//���O�C��ID�̏d�����`�F�b�N����B
						QueryObject query = new QueryObject();
						query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));

						DataTable dt = userDac.Find(cmd, query);
						if (dt.Rows.Count != 0)
						{
							//���ɓo�^����Ă���B�d���G���[
							BusinessError error = new BusinessError(i + "�s�ځF���O�C��ID���d�����Ă���A�܂��͎g�p�ł��Ȃ�ID�ł��B", LoginUserErrorCode.DUPLICATION_LOGIN_ID_ERROR);
							errors.Add(error);
						}
						i++;
					}

					if (errors.Count > 0)
						throw new BusinessException(errors);

					//�ǉ�
					foreach (LoginUserVO vo in vos)
					{
						vo.CreateUserID = loginUserInfo.LoginId;
						vo.UpdateUserID = loginUserInfo.LoginId;

						vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
						vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

						//�f�[�^�����폜
						LoginFailureVO vo1 = new LoginFailureVO();
						vo1.LoginId = vo.LoginId;
						failureDac.PhysicalDelete(cmd, (LoginFailureKey)vo1);

						passwordhistoryDao.DeleteByLoginId(cmd, vo.LoginId);

						roleusermapDao.DeleteByLoginId(cmd, vo.LoginId);

						userDac.PhysicalDelete(cmd, (LoginUserKey)vo);

						//�p�X���[�h�Í���
						AESCryptUtility aes = new AESCryptUtility();
						vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

						//�f�[�^��o�^����B
						userDac.Insert(cmd, vo);
						failureDac.Insert(cmd, vo1);

						//BS_DATA_LOG�ɋL�^
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
					//�X�V
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

				//���j���[�L���b�V���S�폜
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
					//�}�b�s���O��S�폜
					mapDac.DeleteByLoginId(cmd, vo.LoginId);
					DataRow[] mapRows = mapDt.Select(string.Format("LOGIN_ID = '{0}'", vo.LoginId));
					foreach (DataRow mapRow in mapRows)
					{
						int roleCount = roleDac.SelectCount(cmd, Convert.ToString(mapRow["ROLE_ID"]));
						if (roleCount == 0)
						{
							//���ɓo�^����Ă���B�d���G���[
							BusinessError error = new BusinessError(string.Format("{0}�s�ځF�w�肵�����[���͑��݂��Ȃ�ID�ł��B{1}", i, Convert.ToString(mapRow["ROLE_ID"])), CommonErrorCode.DB_NOT_FIND_RECORD_ERROR);
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
					//BS_DATA_LOG�ɋL�^
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

		#region ���p�҈ꊇINSERT/UPDATE�i���p�҃A�b�v���[�hAPI�p�j
		/// <summary>
		/// �X�V�`�o�h
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

				//�ǉ�
				for (int i = 0; i < vos.Length; i++)
				{
					LoginUserVO vo = vos[i];

					//���O�C��ID�̏d�����`�F�b�N����B
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

						//�p�X���[�h�Í���
						AESCryptUtility aes = new AESCryptUtility();
						vo.OldPassword = string.IsNullOrEmpty(vo.OldPassword) ? null : aes.ExecuteDecode(vo.OldPassword);

						//�f�[�^���X�V����B
						userDac.Update(cmd, vo);

						//BS_DATA_LOG�ɋL�^
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

		#region ���p�ҏ��ҏW
		/// <summary>
		/// �ҏW
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
					//���O�C�����s�񐔂��N���A����
					LoginFailureDac failureDac = new LoginFailureDac(connection);
					LoginFailureVO vo1 = new LoginFailureVO();
					vo1.LoginId = vo.LoginId;
					vo1.FailureCount = 0;
					failureDac.Update(cmd, vo1);
				}
				//�p�X���[�h�Í���
				AESCryptUtility aes = new AESCryptUtility();
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);
				//�f�[�^���X�V����B
				userDac.Update(cmd, vo);

				//BS_DATA_LOG�ɋL�^
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

		#region ���p�ҍ폜
		/// <summary>
		/// ���p�҂�_���폜���܂��B
		/// </summary>
		/// <remarks>
		/// �����T�v
		/// 1.���p�҂̍폜
		/// 2.�폜�������p�҂̃��O�C�����̍폜
		/// </remarks>
		/// <param name="vo">���p��VO</param>
		/// <returns>�폜�Ɏ��s���ꍇ��true</returns>
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

				//1.���p�҂̍폜
				vo.UpdateUserID = loginUserInfo.LoginId;
				//�f�[�^���폜����
				userDac.Delete(cmd, vo);

				// ���[�����[�U�}�b�s���O���擾�B
				DataTable mapTbl = mapDac.SelectByLoginId(cmd, vo.LoginId);

				// ���[�����[�U�}�b�s���O���폜
				if (mapTbl.Rows.Count > 0)
				{
					// ���[�����[�U�}�b�s���O��DB����폜
					mapDac.DeleteByLoginId(cmd, vo.LoginId);

					// ���O�e�[�u���ɋL�^
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

				//���j���[���폜
				menuDac.DeleteByLoginId(cmd, vo.LoginId);
				//BS_DATA_LOG�ɋL�^
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

				//2.�폜�������p�҂̃��O�C�����̍폜
				//�폜�������O�C���ҏ�������
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, vo.LoginId));
				DataTable dt = infoDac.Find(cmd, query);

				foreach (DataRow row in dt.Rows)
				{
					string infoId = Convert.ToString(row["LOGIN_INFO_ID"]);
					string loginId = Convert.ToString(row["LOGIN_ID"]);

					//LoginCert�e�[�u���폜
					certDac.DeleteByLoginInfoID(cmd, infoId);

					//LoginInfo�e�[�u���폜
					LoginInfoKey infoKey = new LoginInfoKey();
					infoKey.LoginInfoId = infoId;
					infoDac.Delete(cmd, infoKey);

					//LoginLog�o�^
					ExLoginUserInfoVO infoVo = certbc.GetServerInfoVO();
					//�폜���ꂽ���p��ID���Z�b�g
					infoVo.LoginId = loginId;
					//���O�C�����O�̓o�^
					LoginLogVO loginLogVo = new LoginLogVO();
					//���O�C����ID
					loginLogVo.LoginID = loginId;
					//���O�C�����O�o�^
					loginLogVo.LogDatetime = DateTime.Now;
					//���O�C�����O�̃^�C�v
					loginLogVo.LogType = LoginLogType.CompulsoryLogout;
					//�A�v���T�[�o��IP�A�h���X
					loginLogVo.IPAddress = infoVo.IPAddress;
					//�A�v���T�[�o�̃z�X�g��
					loginLogVo.PCName = infoVo.PCName;
					loginLogDac.Insert(cmd, loginLogVo);

					//�f�[�^���O�o�^
					//BS_DATA_LOG�ɋL�^
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

		#region ���b�N�t���O�ύX
		/// <summary>
		/// ���b�N�t���O�ύX
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

				//���b�N�t���O�`�F�b�N
				bool isLock = false;
				if (vo.LockFlag == ConstantUtil.LOCK_FLAG_ON)
				{
					//���O�C�����s�񐔂��N���A����
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
				//���b�N��Ԃ�ύX����
				userDac.UpdateLockFlag(cmd, vo, isLock, loginUserInfo.LoginId);

				//BS_DATA_LOG�ɋL�^
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
		/// ���p�҂����b�N���܂��B(���O�C�����Ɏg�p)
		/// </summary>
		/// <remarks>
		/// ���p�҂����񐔈ȏネ�O�C���Ɏ��s�������ɗ��p�҃��b�N��
		/// �����邽�߂̃��\�b�h�ł��B
		/// </remarks>
		/// <param name="key">���p�ҏ��̎�L�[</param>
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

				//���p�҂����b�N����
				userDac.UpdateLockFlag(cmd, key, false, loginUserInfo.LoginId);

				//BS_DATA_LOG�ɋL�^
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
		/// ���p�҂����b�N���܂��B(���O�C�����Ɏg�p)
		/// </summary>
		/// <remarks>
		/// ���p�҂����񐔈ȏネ�O�C���Ɏ��s�������ɗ��p�҃��b�N��
		/// �����邽�߂̃��\�b�h�ł��B
		/// </remarks>
		/// <param name="key">���p�ҏ��̎�L�[</param>
		/// <returns></returns>
		public bool UpdateLockFlagByLoginFailure2(OracleCommand cmd, LoginUserKey key)
		{
			LoginUserDac userDac = new LoginUserDac(connection);
			DataLogDac datalogDac = new DataLogDac(connection);

			//���p�҂����b�N����
			userDac.UpdateLockFlag(cmd, key, false, loginUserInfo.LoginId);

			//BS_DATA_LOG�ɋL�^
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

		#region �p�X���[�h�ύX
		/// <summary>
		/// �p�X���[�h���X�V����
		/// </summary>
		/// <remarks>
		/// �������e�F
		/// 1.(�G���[�`�F�b�N)��ʂœ��͂��ꂽ�Â��p�X���[�h��DB�̌Â��p�X���[�h����v���邩
		/// 2.(�G���[�`�F�b�N)��ʂœ��͂��ꂽ�V�����p�X���[�h���p�X���[�h�����ɓo�^����Ă��邩
		/// 3.�p�X���[�h�X�V
		/// 4.�p�X���[�h�X�V���O���o��
		/// 5.�p�X���[�h�����̍폜
		/// </remarks>
		/// <param name="vo">�X�V���e�̗��p�ҏ�񂪊i�[���ꂽLoginUserVO</param>
		/// <param name="oldPassword">��ʂ�����͂��ꂽ�Â��p�X���[�h</param>
		/// <param name="pwdLogNum">�p�X���[�h�����̕ۑ���(0�ȏ�̐���)</param>
		/// <exception cref="BusinessException">
		/// 1.DB�̌Â��p�X���[�h�Ɖ�ʂ�����͂��ꂽ�Â��p�X���[�h����v���Ȃ�
		/// 2.�V�����p�X���[�h���p�X���[�h�����Ɋi�[����Ă���
		/// </exception>
		/// <exception cref="ArgumentException">
		/// �p�X���[�h�����̕ۑ�����0�����������l
		/// </exception>
		/// <returns>�X�V�ɐ��������ꍇ��true</returns>
		public bool UpdatePasswordLoginUser(LoginUserVO vo, string oldPassword, int pwdLogNum)
		{
			if (pwdLogNum < 0)
			{
				throw new ArgumentException("�p�X���[�h�����̕ۑ��������s���ł��B0�ȏ�̐����l��ݒ肵�Ă��������B");
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

				//1.�Â��p�X���[�h����������
				DataTable loginUserDT = loginUserDac.Select(cmd, vo);
				if (loginUserDT.Rows.Count > 0)
				{
					//�p�X���[�h�Í���
					if (!string.IsNullOrEmpty(oldPassword))
					{
						// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update START ---------------
						if (!oldPassword.ToUpper().Equals(aes.ExecuteDecode(loginUserDT.Rows[0]["PASSWORD"].ToString()).ToUpper()))
						// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update  END ---------------
						{
							BusinessError error = new BusinessError("�Â��p�X���[�h����v���܂���B", LoginUserErrorCode.PASSWORD_ERROR);
							throw new BusinessException(error);
						}
					}
				}

				//2.�p�X���[�h����
				//�p�X���[�h�����̕ۑ�����0���̎��̓p�X���[�h�������`�F�b�N���Ȃ�
				if (pwdLogNum != 0)
				{
					DataTable pwdHisDT = pwdHisDac.SelectByLoginId(cmd, vo.LoginId);
					if (pwdHisDT.Rows.Count > 0)
					{
						//�p�X���[�h�̓��̓`�F�b�N
						//if (string.IsNullOrEmpty(vo.Password))
						//    throw new ArgumentException("�V�����p�X���[�h���擾�ł��܂���B");

						DataRow[] rows = pwdHisDT.Select("", "UPDATE_DATETIME DESC");
						for (int i = 0; i < pwdLogNum && i < rows.Length; ++i)
						{
							// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update START ---------------
							if (vo.Password.ToUpper().Equals(aes.ExecuteDecode(rows[i]["PASSWORD"].ToString()).ToUpper()))
							// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update  END ---------------
							{
								BusinessError error = new BusinessError("�ݒ肵���V�����p�X���[�h�͉ߋ��Ɏg�p����Ă��܂��B�ʂ̃p�X���[�h��ݒ肵�Ă��������B",
								LoginUserErrorCode.PASSWORD_HISTORY_DUPLICATION_ERROR);
								throw new BusinessException(error);
							}
						}
					}
				}
				// 3.�p�X���[�h�̍X�V
				//�X�V��ID�̃Z�b�g
				vo.UpdateUserID = loginUserInfo.LoginId;
				//�X�V�������Z�b�g
				vo.UpdateDateTime = DateTime.Now;
				vo.PasswordUpdateDateTime = DateTime.Now;
				//�p�X���[�h�Í���
				string anAesPassword = vo.Password;
				vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);
				//�p�X���[�h���X�V
				loginUserDac.UpdatePassword(cmd, vo, anAesPassword);

				// 4.�p�X���[�h�X�V���O�̏o��
				//���O�C���҂̗��p�ҏ��̎擾
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

				// 5.�p�X���[�h�����̑}���^�폜
				if (pwdLogNum == 0)
				{
					//�p�X���[�h�����̕ۑ�����0�̏ꍇ�̓��O�C���҂̃p�X���[�h������S�폜
					pwdHisDac.DeleteByLoginId(cmd, vo.LoginId);
				}
				else
				{
					//�p�X���[�h����VO�̐���
					PasswordHistoryVO pwdHisVO = new PasswordHistoryVO();
					pwdHisVO.LoginID = vo.LoginId;
					pwdHisVO.UpdateDatetime = vo.PasswordUpdateDateTime;
					pwdHisVO.Password = vo.Password;
					//�V�����p�X���[�h���𗚗��ɑ}��
					pwdHisDac.Insert(cmd, pwdHisVO);

					int pwdHisCount = pwdHisDac.Count(cmd, vo.LoginId);

					//�p�X���[�h���𐔂��ݒ�l�����傫����
					if (pwdLogNum < pwdHisCount)
					{
						//�p�X���[�h�����̎擾(�X�V�����̍~��)
						DataTable tmpPwdHisDT = pwdHisDac.SelectByLoginId(cmd, vo.LoginId);
						DataRow[] tmpPwdHisDR = tmpPwdHisDT.Select("", "UPDATE_DATETIME DESC");
						//�p�X���[�h������S�폜
						pwdHisDac.DeleteByLoginId(cmd, vo.LoginId);

						//�p�X���[�h����VO�̐���
						PasswordHistoryVO tmpVO = new PasswordHistoryVO();
						//�p�X���[�h�����e�[�u���Ɂu�p�X���[�h�����̕ۑ����v����������}������
						for (int i = 0; i < pwdLogNum; i++)
						{
							tmpVO.LoginID = Convert.ToString(tmpPwdHisDR[i]["LOGIN_ID"]);
							tmpVO.UpdateDatetime = Convert.ToDateTime(tmpPwdHisDR[i]["UPDATE_DATETIME"]);
							tmpVO.Password = Convert.ToString(tmpPwdHisDR[i]["PASSWORD"]);
							//�p�X���[�h�����ɑ}��
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

		#region ���O�C�����s���
		#region InsertLoginFailure
		/// <summary>
		/// ���O�C�����s����ǉ����܂��B
		/// </summary>
		/// <param name="vo">���O�C�����s���VO</param>
		/// <exception cref="ArgumentException">��L�[�ɒl���ݒ肳��Ă��Ȃ�</exception>
		/// <returns>����������true��Ԃ��܂��B���s������<see cref="DBConcurrencyException"/>�𓊂��܂��B</returns>
		public bool InsertLoginFailure(DbCommand cmd, LoginFailureVO vo)
		{
			//�����`�F�b�N
			if (string.IsNullOrEmpty(vo.LoginId)) throw new ArgumentException("LoginFailureBC.InsertLoginFailure:�������s���ł�");

			try
			{
				LoginFailureDac dac = new LoginFailureDac(connection);
				//�ǉ�
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
		/// ���O�C�����s�����X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V�Ώۂ�vo</param>
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

		#region ���O�C������
		/// <summary>
		/// ���O�C������ID/PW�`�F�b�N���s���܂��B
		/// </summary>
		/// <param name="infoVo">���[�U��񂪊i�[���ꂽvo</param>
		/// <param name="password">���O�C���҂̃p�X���[�h</param>
		/// <param name="userType">���[�U����</param>
		/// <returns></returns>
		public Result CheckLoginAvailable(ExLoginUserInfoVO infoVo, string password, string userType)
		{
			//���؎��s
			LoginValidateResult validRes = this.LoginValidate(infoVo, password, userType);
			//���،��ʂ̕��򏈗�
			return this.ValidateResultCheck(validRes);
		}

		/// <summary>
		/// ���O�C������
		/// </summary>
		/// <param name="infoVo"></param>
		/// <param name="password"></param>
		/// <param name="userType">���[�U����</param>
		/// <returns></returns>
		private LoginValidateResult LoginValidate(ExLoginUserInfoVO infoVo, string password, string userType)
		{
			string loginId = infoVo.LoginId;
			LoginUserDac loginUserdac = new LoginUserDac(connection);
			string logPassword = password;

			// TODO yusy add DbCommand �� OracleCommand
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

				#region BC/DAC�C���X�^���X�̐���
				LoginFailureDac loginFailureDac = new LoginFailureDac(connection);
				LoginUserBC loginUserBC = new LoginUserBC(loginUserInfo, connection);
				CertificationBC certBC = new CertificationBC(connection);
				#endregion

				//���݂��郍�O�C��ID�ł��邩�H
				if (!loginUserdac.CheckId(cmd, loginId))
				{
					//���݂��Ȃ�
					logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByIdNoExist;
				}
				if (Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_OPERATION_CHECK]))
				{
					bool oprResult = LoginValidateOperation(cmd, loginId, userType);
					if (!oprResult)
					{
						//�^�p���ԊO�ɂ�郍�O�C�����s�B���O�C�����O�C�f�[�^���O�̒ǉ��B
						certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByOperationTime, infoVo, null);
						logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
						return LoginValidateResult.FailureByOperationTime;
					}
				}

				DataTable loginUserDT = loginUserdac.Select(cmd, new LoginUserKey(loginId));

				// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update START ---------------
				AESCryptUtility aes = new AESCryptUtility();
				String pw = loginUserdac.CheckIdPassword(cmd, loginId);
				if (pw != null && password.ToUpper().Equals(aes.ExecuteDecode(pw).ToUpper()))
				{
				// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update  END ---------------
					//ID/PASSWORD��������
					if (Convert.ToString(loginUserDT.Rows[0]["LOCK_FLAG"]) == ConstantUtil.LOCK_FLAG_OFF)
					{
						//���O�C������
						return LoginValidateResult.LoginAllowed;
					}
					else
					{
						//���[�U���b�N����Ă���
						// ���O�C�����O�C�f�[�^���O�̒ǉ�
						certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByUserLock, infoVo, null);
						logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
						return LoginValidateResult.FailureByUserLock;
					}
				}

				//ID/PASSWORD���Ⴄ�ꍇ
				//���O�C���҂̃��[�U��ʃ`�F�b�N
				if (Convert.ToString(loginUserDT.Rows[0]["USER_TYPE"]) != ConstantUtil.LOGIN_USER_TYPE_GENERAL)
				{
					//��ʃ��[�U�ȊO�i�Ǘ��ҁC�\��ꃍ�O�C��ID�j�̏ꍇ�̓G���[�Ƃ���

					// ���O�C�����O�C�f�[�^���O�̒ǉ�
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByInvalidPassword;
				}

				//���O�C�����s���̒ǉ�
				DataTable loginFailureDT = loginFailureDac.Select(cmd, new LoginFailureKey(loginId));
				LoginFailureVO failureVO = new LoginFailureVO();

				//���s��
				int failureCount;
				if (loginFailureDT.Rows.Count == 0)
				{
					//���O�C�����s���R�[�h�����݂��Ȃ�
					failureVO.LoginId = loginId;
					failureCount = 1;
					failureVO.FailureCount = failureCount;
					loginUserBC.InsertLoginFailure(cmd, failureVO);
				}
				else
				{
					//���݂���
					failureVO.LoginId = loginId;
					failureCount = Convert.ToInt32(loginFailureDT.Rows[0]["FAILURE_COUNT"]) + 1;
					failureVO.FailureCount = failureCount;
					loginUserBC.UpdateLoginFailure(cmd, failureVO);
				}

				//���O�C�����s�J�E���g�̃`�F�b�N

				//���O�C�����s�̋��e�񐔁i��j�̎擾
				int allowCount = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["LoginFailureAllowCount"].Value);
				if (allowCount == 0)
				{
					// ���O�C�����s�̋��e�񐔂�0��������p�X���[�h�~�X�̃��O�̂ݏo��

					// ���O�C�����O�C�f�[�^���O�̒ǉ�
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					//�p�X���[�h���̓~�X
					logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByInvalidPassword;
				}
				else if (failureCount > allowCount)
				{
					//���O�C�����s�������e�͈͊O�Ȃ̂ŗ��p�҂����b�N
					loginUserBC.UpdateLockFlagByLoginFailure2(cmd, new LoginUserKey(loginId));

					// ���O�C�����O�C�f�[�^���O�̒ǉ�
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByUserLock, infoVo, null);
					//���[�U���b�N
					logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
					return LoginValidateResult.FailureByUserLock;
				}
				else
				{
					// ���O�C�����s�������e�͈͓��Ȃ̂Ńp�X���[�h���̓~�X�̎|����ʂɕ\��

					// ���O�C�����O�C�f�[�^���O�̒ǉ�
					certBC.InsertLoginLog(cmd, LoginLogType.LoginFailureByInvalidPassword, infoVo, null);
					logger.Error("�G���[���O�C���h�c�F" + infoVo.LoginId + "(" + logPassword + ")");
					//�p�X���[�h���̓~�X
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
		/// �^�p���ԃ`�F�b�N���s���܂��B
		/// </summary>
		/// <param name="infoVo">���[�U��񂪊i�[���ꂽvo</param>
		/// <param name="loginId">���O�C���h�c</param>
		/// <param name="userType">���[�U����</param>
		/// <returns></returns>
		public Boolean CheckLoginAvailableOperation(ExLoginUserInfoVO infoVo, string loginId, string userType)
		{
			Boolean Res = false;
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;
				//���؎��s
				Res = this.LoginValidateOperation(cmd, loginId, userType);
				//���،��ʂ̕��򏈗�
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

		// --------------- 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664] Add Start ---------------
		/// <summary>
		/// �I�����C�������`�F�b�N���܂��B
		/// </summary>
		/// <param name="loginId">���O�C���h�c</param>
		/// <param name="userType">���[�U����</param>
		/// <returns></returns>
		public Boolean CheckLoginAvailableOnline(string loginId, string userType)
		{
			Boolean Res = false;
			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;
				//���؎��s
				Res = this.LoginValidateOnline(cmd, loginId, userType);
				//���،��ʂ̕��򏈗�
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
		/// �I�����C�������`�F�b�N���܂��B
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
				//�V�X�e���Ǘ��҂ł��邩�H 
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
		// --------------- 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664] Add  END ---------------

		#region LoginValidateOpration
		/// <summary>
		/// �^�p���ԓ����`�F�b�N���܂��B
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
			//�V�X�e���Ǘ��҂ł��邩�H 
			if (!ConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER.Equals(userType))
			{
				//�Ǘ��҂ł͂Ȃ�
				#region �ݒ���e���擾
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

				#region ���ԑу`�F�b�N
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
		/// ���p�҂ƃ��[���}�b�s���O���X�V���܂��B
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

				//�p�X���[�h�Í���
				AESCryptUtility aes = new AESCryptUtility();
				userVO.Password = string.IsNullOrEmpty(userVO.Password) ? null : aes.ExecuteEncode(userVO.Password);

				userDac.Update(cmd, userVO);

				//���j���[�L���b�V���S�폜
				cacheDac.DeleteByLoginId(cmd, userVO.LoginId);

				//�}�b�s���O��S�폜
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
				//BS_DATA_LOG�ɋL�^
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
		/// ���[��ID�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="keyValues">RoleUserMapVO�̔z��</param>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
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

		#region Smart SOA�A�g
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="queryObj"></param>
		/// <returns></returns>
		public DataTable FindSyncLoginUser(OracleCommand cmd, QueryObject queryObj)
		{
			LoginUserDac loginuserDac = new LoginUserDac(connection);
			DataTable dt = loginuserDac.FindSyncLoginUser(cmd, queryObj);

			//�p�X���[�h����
			AESCryptUtility aes = new AESCryptUtility();

			foreach (DataRow row in dt.Rows)
			{
				row["PASSWORD"] = aes.ExecuteDecode(Convert.ToString(row["PASSWORD"]));
			}

			return dt;
		}

		/// <summary>
		/// ���ׂĂ̗��p�ҍ폜
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

				//�f�[�^���폜����B
				dac.DeleteAll(cmd, loginUserInfo.LoginId);

				//���[�����[�U�}�b�s���O���폜
				mapDac.DeleteAll(cmd);

				//���j���[�̍폜
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
		/// ���p�҂̃C���|�[�g Delete-Insert
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

				//�X�V�O�ɑS���擾
				DataTable beforeDt = dac.FindSyncLoginUser(cmd, new QueryObject());
				//�f�[�^���폜����B
				dac.DeleteAll(cmd, loginUserInfo.LoginId);

				foreach (LoginUserVO vo in vos)
				{
					DataRow[] rows = beforeDt.Select(string.Format("LOGIN_ID = '{0}' AND DELETE_FLAG = '{1}'", vo.LoginId, ConstantUtil.DELETE_FLAG_OFF));

					//�p�X���[�h�Í���
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
						//�X�V
						dac.Update(cmd, vo);
					}
					else
					{
						operation = DataLogUtil.OPERATION_TYPE_OF_INSERT;
						//�ǉ�
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

					//BS_DATA_LOG�ɋL�^
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

				//�폜�ς̗��p�҂��擾
				QueryObject query = new QueryObject();
				query.AddFinder(Criteria.Equal("DELETE_FLAG", null, null, ConstantUtil.DELETE_FLAG_ON));

				DataTable delDt = dac.FindSyncLoginUser(cmd, query);
				foreach (DataRow row in delDt.Rows)
				{
					DataRow[] delRows = beforeDt.Select(string.Format("DELETE_FLAG = '{0}' AND LOGIN_ID = '{1}'", ConstantUtil.DELETE_FLAG_OFF, Convert.ToString(row["LOGIN_ID"])));
					if (delRows.Length == 0)
						continue;

					string loginId = Convert.ToString(row["LOGIN_ID"]);
					//���[�����[�U�}�b�s���O���擾
					DataTable mapTbl = mapDac.SelectByLoginId(cmd, loginId);

					//���j���[���폜
					menuDac.DeleteByLoginId(cmd, loginId);

					// ���[�����[�U�}�b�s���O���폜
					if (mapTbl.Rows.Count > 0)
					{
						//���[�����[�U�}�b�s���O���폜�B
						mapDac.DeleteByLoginId(cmd, loginId);

						// ���O�e�[�u���ɋL�^
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

						//BS_DATA_LOG�ɋL�^
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

					//�폜�������O�C���ҏ�������
					QueryObject query1 = new QueryObject();
					query1.AddFinder(Criteria.Equal("LOGIN_ID", null, null, loginId));
					DataTable dt = infoDac.Find(cmd, query1);
					foreach (DataRow row1 in dt.Rows)
					{
						string infoId = Convert.ToString(row1["LOGIN_INFO_ID"]);
						//LoginCert�e�[�u���폜
						certDac.DeleteByLoginInfoID(cmd, infoId);
						//LoginInfo�e�[�u���폜
						LoginInfoKey infoKey = new LoginInfoKey();
						infoKey.LoginInfoId = infoId;
						infoDac.Delete(cmd, infoKey);

						//LoginLog�o�^
						ExLoginUserInfoVO infoVo = certbc.GetServerInfoVO();
						//�폜���ꂽ���p��ID���Z�b�g
						infoVo.LoginId = loginId;
						//���O�C�����O�̓o�^
						LoginLogVO loginLogVo = new LoginLogVO();
						//���O�C����ID
						loginLogVo.LoginID = loginId;
						//���O�C�����O�o�^
						loginLogVo.LogDatetime = DateTime.Now;
						//���O�C�����O�̃^�C�v
						loginLogVo.LogType = LoginLogType.CompulsoryLogout;
						//�A�v���T�[�o��IP�A�h���X
						loginLogVo.IPAddress = infoVo.IPAddress;
						//�A�v���T�[�o�̃z�X�g��
						loginLogVo.PCName = infoVo.PCName;
						loginLogDac.Insert(cmd, loginLogVo);

						//�f�[�^���O�o�^
						//BS_DATA_LOG�ɋL�^
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
		/// ���p�҂̍����C���|�[�g
		/// </summary>
		/// <param name="updVos">�ǉ��E�X�V����VO�̔z��</param>
		/// <param name="delKeys">�폜�������Key�̔z��</param>
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

					//�p�X���[�h�Í���
					AESCryptUtility aes = new AESCryptUtility();
					vo.Password = string.IsNullOrEmpty(vo.Password) ? null : aes.ExecuteEncode(vo.Password);

					vo.UserType = LoginUserConstantUtil.USER_TYPE_GENERAL;
					vo.UpdateUserID = loginUserInfo.LoginId;
					vo.DeleteFlag = ConstantUtil.DELETE_FLAG_OFF;

					if (dt.Rows.Count != 0)
					{
						vo.RowUpdateId = Convert.ToString(dt.Rows[0]["ROW_UPDATE_ID"]);
						//�X�V
						dac.Update(cmd, vo);
					}
					else
					{
						//�ǉ�
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
						//�폜
						dac.Delete(cmd, vo);
						//���[�����[�U�}�b�s���O���폜�B
						mapDac.DeleteByLoginId(cmd, vo.LoginId);
						//���j���[���폜
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
		/// ���،��ʂ��`�F�b�N���܂��B
		/// </summary>
		/// <param name="validResult">���،���</param>
		/// <exception cref="BusinessException">
		/// ���،��ʂŉ��L�̃P�[�X�����������ꍇ
		/// �E���O�C��ID�����݂��Ȃ��B
		/// �E���͂������O�C��ID�ɑΉ�����p�X���[�h���قȂ�B
		/// �E���[�U�����b�N����Ă���B
		/// </exception>
		/// <returns>
		/// ���،��ʂ��������ꍇ��Result.IsSuccess��true���Z�b�g���ԋp���܂��B
		/// </returns>
		private Result ValidateResultCheck(LoginValidateResult validResult)
		{
			BusinessError error;

			switch (validResult)
			{
				case (LoginValidateResult.LoginAllowed):
					return new Result(true);

				case (LoginValidateResult.FailureByOperationTime):
					error = new BusinessError("�V�X�e���^�p���ԊO�ł��B", LoginUserErrorCode.LOGIN_TIME_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByIdNoExist):
					error = new BusinessError("���O�C���Ɏ��s���܂����B", LoginUserErrorCode.LOGIN_PASSWORD_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByInvalidPassword):
					error = new BusinessError("�p�X���[�h���Ⴂ�܂��B", LoginUserErrorCode.LOGIN_PASSWORD_ERROR);
					throw new BusinessException(error);

				case (LoginValidateResult.FailureByUserLock):
					error = new BusinessError("���O�C��ID�̓��b�N����Ă��܂��B�V�X�e���Ǘ��҂ɂ��⍇�����������B", LoginUserErrorCode.LOGIN_ID_LOCK_ERROR);
					throw new BusinessException(error);

				default:
					break;
			}

			return new Result(true);

		}
	}
}
