// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// ���ŗ���
// 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664]
// 2012/11/19 WT)Banno OM��Q�Ή�[OM-813]

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Dac
{
	public class LoginUserDac : BaseDac
	{
		#region �R���X�g���N�^
		public LoginUserDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// ��L�[��SELECT���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable Select(OracleCommand cmd, LoginUserKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_USER "
						+ " WHERE LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "   AND DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}

		/// <summary>
		/// ���O�C���h�c��SELECT���܂��B
		/// ��L�[�N���X�ł͂Ȃ�������������Ƃ��܂��B
		/// </summary>
		/// <param name="loginId">���O�C���h�c</param>
		/// <returns></returns>
		public DataTable SelectByLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_LOGIN_USER "
					+ " WHERE LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
					+ "   AND DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
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

		#region SelectAll
		/// <summary>
		/// ��L�[��SELECT���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable SelectAll(OracleCommand cmd, LoginUserKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_USER WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERT���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���LoginUserVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Insert(DbCommand cmd, LoginUserVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_LOGIN_USER (COMPANY_ID,LOGIN_ID,PASSWORD,NAME,NAME_KANA,USER_TYPE,MAPPING_ID,CREATE_DATETIME,CREATE_USER_ID"
						+ ",UPDATE_DATETIME,UPDATE_USER_ID,ROW_UPDATE_ID,TEMP_PASSWORD_FLAG,PASSWORD_UPDATE_DATETIME,LOCK_FLAG,DELETE_FLAG) VALUES ("
						+ ProviderUtil.GetParameterName("COMPANY_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("PASSWORD", providerType)
						+ "," + ProviderUtil.GetParameterName("NAME", providerType)
						+ "," + ProviderUtil.GetParameterName("NAME_KANA", providerType)
						+ "," + ProviderUtil.GetParameterName("USER_TYPE", providerType)
						+ "," + ProviderUtil.GetParameterName("MAPPING_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("CREATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("CREATE_USER_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("TEMP_PASSWORD_FLAG", providerType)
						+ "," + ProviderUtil.GetParameterName("PASSWORD_UPDATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("LOCK_FLAG", providerType)
						+ "," + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.CreateDateTime = DateTime.Now;
			vo.UpdateDateTime = DateTime.Now;
			vo.PasswordUpdateDateTime = DateTime.Now;

			//�p�����[�^���Z�b�g
			//COMPANY
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyID));
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//PASSWORD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD", providerType, vo.Password));
			//NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NAME", providerType, vo.Name));
			//NAME_KANA
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NAME_KANA", providerType, vo.Kana));
			//USER_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("USER_TYPE", providerType, vo.UserType));
			//MAPPING_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MAPPING_ID", providerType, vo.MappingID));
			//CREATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_DATETIME", providerType, vo.CreateDateTime));
			//CREATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CREATE_USER_ID", providerType, vo.CreateUserID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, vo.DeleteFlag));
			//TEMP_PASSWORD_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TEMP_PASSWORD_FLAG", providerType, ConstantUtil.TEMP_PASSWORD_FLAG_ON));
			//PASSWORD_UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD_UPDATE_DATETIME", providerType, vo.PasswordUpdateDateTime));
			//LOCK_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOCK_FLAG", providerType, ConstantUtil.LOCK_FLAG_OFF));
			//�ǉ�
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("���ōX�V����܂����B");
			}
			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ��L�[��UPDATE���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���LoginUserVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Update(DbCommand cmd, LoginUserVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ "  PASSWORD = " + ProviderUtil.GetParameterName("PASSWORD", providerType)
						+ ", COMPANY_ID =" + ProviderUtil.GetParameterName("COMPANY_ID", providerType)
						+ ", NAME = " + ProviderUtil.GetParameterName("NAME", providerType)
						+ ", NAME_KANA = " + ProviderUtil.GetParameterName("NAME_KANA", providerType)
						+ ", MAPPING_ID = " + ProviderUtil.GetParameterName("MAPPING_ID", providerType)
						+ ", UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", TEMP_PASSWORD_FLAG = " + ProviderUtil.GetParameterName("TEMP_PASSWORD_FLAG", providerType)
						+ ", PASSWORD_UPDATE_DATETIME =" + ProviderUtil.GetParameterName("PASSWORD_UPDATE_DATETIME", providerType)
						+ ", ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ ", DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ "   WHERE LOGIN_ID     = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "    AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�Â��p�X���[�h�Í���
			AESCryptUtility aes = new AESCryptUtility();
			vo.OldPassword = aes.ExecuteEncode(vo.OldPassword);
			//�V�X�e�����Ԃ��擾
			vo.UpdateDateTime = DateTime.Now;
			if (vo.OldPassword != vo.Password)
			{
				vo.PasswordUpdateDateTime = DateTime.Now;
			}
			//�p�����[�^���Z�b�g
			//COMPANY
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COMPANY_ID", providerType, vo.CompanyID));
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//PASSWORD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD", providerType, vo.Password));
			//NAME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NAME", providerType, vo.Name));
			//NAME_KANA
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("NAME_KANA", providerType, vo.Kana));
			//MAPPING_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MAPPING_ID", providerType, vo.MappingID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, vo.DeleteFlag));
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));
			//TEMP_PASSWORD_FLAG
			//�p�X���[�h�ύX�����ꍇ
			if (vo.OldPassword != vo.Password)
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TEMP_PASSWORD_FLAG", providerType, ConstantUtil.TEMP_PASSWORD_FLAG_ON));
			}
			//�p�X���[�h�ύX�Ȃ�
			else
			{
				cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TEMP_PASSWORD_FLAG", providerType, vo.TempPasswordFlag));
			}
			//PASSWORD_UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD_UPDATE_DATETIME", providerType, vo.PasswordUpdateDateTime));
			//�X�V
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("���ōX�V����܂����B");
			}

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ��L�[��DELETE���܂��B�i�_���폜�j
		/// </summary>
		/// <param name="key">��L�[���l�܂���LoginUserVo</param>
		/// <returns>�폜���R�[�h��</returns>
		public int Delete(DbCommand cmd, LoginUserVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ " UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ",UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ",DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ ",ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ "   WHERE LOGIN_ID      = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "     AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.UpdateDateTime = DateTime.Now;
			//�p�����[�^���Z�b�g      
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_ON));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));
			//�폜
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("���ōX�V����܂����B");
			}
			return count;
		}
		#endregion

		#region DeleteAll
		/// <summary>
		/// ���ׂ�DELETE���܂��B�i�_���폜�j
		/// �V�X�e���Ǘ��҂�����
		/// </summary>
		/// <returns>�폜���R�[�h��</returns>
		public int DeleteAll(DbCommand cmd, string updateUserId)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ " UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ",UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ",DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
						+ ",ROW_UPDATE_ID = LOGIN_ID"
						+ "   WHERE USER_TYPE = " + ProviderUtil.GetParameterName("USER_TYPE", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g      
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, DateTime.Now));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, updateUserId));
			//DELETE_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_ON));
			//USER_TYPE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("USER_TYPE", providerType, LoginUserConstantUtil.USER_TYPE_GENERAL));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region PhysicalDelete
		/// <summary>
		/// ��L�[�ŕ����폜���܂��B
		/// �r�������͂��܂���B
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int PhysicalDelete(DbCommand cmd, LoginUserKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_USER WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Find
		/// <summary>
		/// ���������ň�v�������R�[�h��Ԃ��܂��B���폜���[�U�̂�
		/// </summary>
		/// <returns>��v���R�[�h</returns>
		public DataTable Find(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = "SELECT * FROM BS_LOGIN_USER WHERE DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
			if (!string.IsNullOrEmpty(where.Key))
			{
				query += " AND " + where.Key;
			}

			if (queryObj.SortKeys.Count == 0)
			{
				SortKey sort = new SortKey();
				sort.ColumnName = "LOGIN_ID";
				queryObj.AddSortKey(sort);
			}
			query += " ORDER BY " + queryObj.GetOrderbyPhrase();
			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			foreach (DbParameter para in where.Value)
			{
				adapter.SelectCommand.Parameters.Add(para);
			}

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(queryObj.StartRow, queryObj.MaxRowCount, res);

			return res;
		}

		/// <summary>
		/// ���������ň�v�������R�[�h����Ԃ��܂��B
		/// </summary>
		/// <returns>��v���R�[�h��</returns>
		public int FindCount(DbCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			cmd.CommandText = "SELECT COUNT(*) FROM BS_LOGIN_USER WHERE DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
			if (!string.IsNullOrEmpty(where.Key))
			{
				cmd.CommandText += " AND " + where.Key;
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			foreach (DbParameter para in where.Value)
			{
				cmd.Parameters.Add(para);
			}

			//Fill
			int res = Convert.ToInt32(cmd.ExecuteScalar());

			return res;
		}
		#endregion

		#region FindSyncLoginUser
		/// <summary>
		/// Smart SOA �A�g�o�b�`�Ŏg�p
		/// ���������ň�v�������R�[�h��Ԃ��܂��B�폜�σ��[�U���Ώ�
		/// </summary>
		/// <returns>��v���R�[�h</returns>
		public DataTable FindSyncLoginUser(OracleCommand cmd, QueryObject queryObj)
		{
			KeyValuePair<string, List<DbParameter>> where = queryObj.GetWherePhraseFromDataColumnList(providerType);
			string query = @"SELECT * FROM BS_LOGIN_USER ";
			if (!string.IsNullOrEmpty(where.Key))
			{
				query += " WHERE " + where.Key;
			}
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			foreach (DbParameter para in where.Value)
			{
				adapter.SelectCommand.Parameters.Add(para);
			}

			//Fill
			DataTable res = new DataTable("LOGIN");
			adapter.Fill(queryObj.StartRow, queryObj.MaxRowCount, res);

			return res;
		}
		#endregion

		#region UpdatePassword
		/// <summary>
		/// ��L�[�Ńp�X���[�h��UPDATE���܂��B
		/// </summary>
		/// <param name="cmd">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="vo">�f�[�^���l�܂���LoginUserVO</param>
		/// <param name="anAesPassword">�p�X���[�h�i��Í��������j</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int UpdatePassword(DbCommand cmd, LoginUserVO vo, string anAesPassword)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ "  PASSWORD = " + ProviderUtil.GetParameterName("PASSWORD", providerType)
						+ ", UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", TEMP_PASSWORD_FLAG = " + ProviderUtil.GetParameterName("TEMP_PASSWORD_FLAG", providerType)
						+ ", PASSWORD_UPDATE_DATETIME =" + ProviderUtil.GetParameterName("PASSWORD_UPDATE_DATETIME", providerType)
						+ ", ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ " WHERE LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "   AND DELETE_FLAG = '" + ConstantUtil.DELETE_FLAG_OFF + "'";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//PASSWORD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD", providerType, vo.Password));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//PASSWORD_UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD_UPDATE_DATETIME", providerType, vo.PasswordUpdateDateTime));
			//TEMP_PASSWORD_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TEMP_PASSWORD_FLAG", providerType, ConstantUtil.TEMP_PASSWORD_FLAG_OFF));
			//�X�V
			int count = cmd.ExecuteNonQuery();
			if (count == 0)
			{
				//�r���G���[
				throw new DBConcurrencyException("���ōX�V����܂����B");
			}
			// BO���� 2016-02-09 M_TANTO�ւ�UPDATE���~ START
			// cmd.CommandText = "UPDATE M_TANTO SET"
			// 			+ "  PW = " + ProviderUtil.GetParameterName("PW", providerType)
			// 			+ ", KSNNCJ = " + ProviderUtil.GetParameterName("KSNNCJ", providerType)
			// 			+ ", KSNUSEID = " + ProviderUtil.GetParameterName("KSNUSEID", providerType)
			// 			+ ", KSNPRGID = " + ProviderUtil.GetParameterName("KSNPRGID", providerType)
			// 			+ " WHERE COPCD    = " + ProviderUtil.GetParameterName("COPCD", providerType)
			// 			+ "    AND TTSCD    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			// cmd.CommandType = CommandType.Text;
			// cmd.Parameters.Clear();

			// //�p�����[�^���Z�b�g
			// //PASSWORD
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PW", providerType, anAesPassword));
			// //KSNNCJ
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("KSNNCJ", providerType, vo.UpdateDateTime));
			// //KSNUSEID
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("KSNUSEID", providerType, vo.UpdateUserID));
			// //KSNPRGID
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("KSNPRGID", providerType, "SMART"));
			// //COPCD
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("COPCD", providerType, vo.CompanyID));
			// //LOGIN_ID
			// cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId.Substring(1)));
			// //�X�V
			// int countmd = cmd.ExecuteNonQuery();
			// if (countmd == 0)
			// {
			// 	throw new DBConcurrencyException("�S���҃}�X�^�iM_TANTO�j ���o�^�G���[�ł��B");
			// }
			// BO���� 2016-02-09 M_TANTO�ւ�UPDATE���~ END
			return count;
		}
		#endregion

		#region CheckIdPassword
		/// <summary>
		/// ���O�C��ID�ƃp�X���[�h�Ō��������݂����true��Ԃ��B
		/// </summary>
		/// <returns>ID/PW�Ɉ�v����s�������true</returns>
		public String CheckIdPassword(DbCommand cmd, string loginId)
		{
			// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update START ---------------
			cmd.Parameters.Clear();
			cmd.CommandText = "SELECT * FROM BS_LOGIN_USER "
					+ " WHERE DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
					+ "   AND LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_OFF));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			String res = null;
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					res = Convert.ToString(reader["PASSWORD"]);
				}
			}
			// --------------- 2012/11/19 WT)Banno OM��Q�Ή�[OM-813] Update  END ---------------

			return res;
		}
		#endregion

		#region CheckId
		/// <summary>
		/// ���O�C��ID���������܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID</param>
		/// <returns>�����̃��O�C��ID�Ɉ�v����s�������true �Ȃ����fasle</returns>
		public bool CheckId(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "SELECT * FROM BS_LOGIN_USER "
					+ " WHERE DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
					+ "   AND LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_OFF));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));
			bool res;
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				res = reader.HasRows;
			}
			return res;
		}
		#endregion

		#region Check�Ǘ���
		/// <summary>
		/// ���O�C��ID�A���p�Ҏ�ʃt���O���������܂��B
		/// </summary>
		/// <param name="loginId">���O�C��ID�A���p�Ҏ�ʃt���O</param>
		/// <returns>�����̃��O�C��ID�Ɉ�v����Ǘ��҂������true �Ȃ����fasle</returns>
		public bool CheckUser(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_LOGIN_USER "
					+ " WHERE DELETE_FLAG = " + ProviderUtil.GetParameterName("DELETE_FLAG", providerType)
					+ "   AND USER_TYPE   = " + ProviderUtil.GetParameterName("USER_TYPE", providerType)
					+ "   AND LOGIN_ID    = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			//OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("DELETE_FLAG", providerType, ConstantUtil.DELETE_FLAG_OFF));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("USER_TYPE", providerType, ConstantUtil.LOGIN_USER_TYPE_SYSTEMMANAGER));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));
			bool res;
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				res = reader.HasRows;
			}
			return res;
		}
		#endregion

		// --------------- 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664] Add Start ---------------
		#region Select�I�����C��
		/// <summary>
		/// �I�����C�������`�F�b�N���܂��B
		/// </summary>
		/// <returns>��v���R�[�h</returns>
		public DataTable SelectOnline(OracleCommand cmd, string copcd)
		{
			string query = "SELECT * FROM M_ONL_CTL WHERE COPCD = " + ProviderUtil.GetParameterName("COPCD", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("COPCD", providerType, copcd));
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);
			return res;
		}
		#endregion
		// --------------- 2012/03/16 WT)Banno OT1��Q�Ή�[QA-0664] Add  END ---------------

		#region Select�^�p����
		/// <summary>
		/// ���������ň�v�������R�[�h��Ԃ��܂��B���폜���[�U�̂�
		/// </summary>
		/// <returns>��v���R�[�h</returns>
		public DataTable SelectTime(OracleCommand cmd, string daytype)
		{
			string query = "SELECT * FROM BS_OPERATION_TIME WHERE DAY_TYPE = " + ProviderUtil.GetParameterName("DAY_TYPE", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("DAY_TYPE", providerType, daytype));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region SelectAll�^�p����
		/// <summary>
		/// �S��SELECT���܂��B
		/// </summary>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable SelectAllTime(OracleCommand cmd)
		{
			string query = "SELECT * FROM BS_OPERATION_TIME ORDER BY DAY_TYPE";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Find�^�p����
		/// <summary>
		/// �S��SELECT���܂��B
		/// </summary>
		/// <returns>�f�[�^�e�[�u���Ɋi�[�������R�[�h�f�[�^</returns>
		public DataTable FindTime(OracleCommand cmd)
		{
			string query = "SELECT * FROM BS_OPERATION_TIME WHERE START_TIME IS NOT NULL OR STOP_TIME IS NOT NULL ORDER BY DAY_TYPE";
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region CancellationLockFlag
		/// <summary>
		/// ��L�[�Ń��b�N�t���O���������܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���LoginUserVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int CancellationLockFlag(DbCommand cmd, LoginUserVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ "  LOCK_FLAG = " + ProviderUtil.GetParameterName("LOCK_FLAG", providerType)
						+ ", UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ", UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ ", ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("ROW_UPDATE_ID", providerType)
						+ " WHERE LOGIN_ID      = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "   AND ROW_UPDATE_ID = " + ProviderUtil.GetParameterName("OLD_ROW_UPDATE_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			vo.UpdateDateTime = DateTime.Now;
			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//LOCK_FLAG
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOCK_FLAG", providerType, ConstantUtil.LOCK_FLAG_OFF));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDateTime));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, vo.UpdateUserID));
			//ROW_UPDATE_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ROW_UPDATE_ID", providerType, Guid.NewGuid().ToString()));
			//ROW_UPDATE_ID(�I���W�i��)
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("OLD_ROW_UPDATE_ID", providerType, vo.RowUpdateId));
			//�X�V
			int count = cmd.ExecuteNonQuery();
			return count;
		}
		#endregion

		#region SetLockFlag
		/// <summary>
		/// ��L�[�Ń��b�N�t���O�����b�N���܂��B
		/// </summary>
		/// <returns>�X�V���R�[�h��</returns>
		public int UpdateLockFlag(DbCommand cmd, LoginUserKey key, bool isLock, string updateUserId)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_USER SET"
						+ " LOCK_FLAG = " + ProviderUtil.GetParameterName("LOCK_FLAG", providerType)
						+ ",UPDATE_DATETIME = " + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ ",UPDATE_USER_ID = " + ProviderUtil.GetParameterName("UPDATE_USER_ID", providerType)
						+ "  WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));
			//LOCK_FLAG
			string lockFlag;
			if (isLock)
			{
				lockFlag = ConstantUtil.LOCK_FLAG_OFF;
			}
			else
			{
				lockFlag = ConstantUtil.LOCK_FLAG_ON;
			}
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOCK_FLAG", providerType, lockFlag));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, DateTime.Now));
			//UPDATE_USER_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_USER_ID", providerType, updateUserId));

			//�X�V
			int count = cmd.ExecuteNonQuery();
			return count;
		}
		#endregion
	}
}
