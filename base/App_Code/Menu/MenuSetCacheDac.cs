// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Web.Menu
{
	public class MenuSetCacheDac : BaseDac
	{
		#region �R���X�g���N�^
		public MenuSetCacheDac(OracleConnection connection)
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
		public DataTable Select(OracleCommand cmd,MenuSetCacheKey key)
		{
			string query = "SELECT * FROM BS_MENU_SET_CACHE " +
				"WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType) +
				" AND MENU_LANGUAGE = " + ProviderUtil.GetParameterName("MENU_LANGUAGE", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//�p�����[�^���Z�b�g
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("MENU_LANGUAGE", providerType, key.MenuLanguage));

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
		/// <param name="vo">�f�[�^���l�܂���MenuSetCacheVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Insert(DbCommand cmd,MenuSetCacheVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_MENU_SET_CACHE (" +
						"LOGIN_ID," +
						"MENU_LANGUAGE," +
						"CACHE" +
						") VALUES (" +
						ProviderUtil.GetParameterName("LOGIN_ID", providerType) + "," +
						ProviderUtil.GetParameterName("MENU_LANGUAGE", providerType) + "," +
						ProviderUtil.GetParameterName("CACHE", providerType) +
						")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//MENU_LANGUAGE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MENU_LANGUAGE", providerType, vo.MenuLanguage));
			//CACHE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CACHE", providerType, vo.Cache));

			//�ǉ�
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// ��L�[��UPDATE���܂��B
		/// </summary>
		/// <param name="vo">�f�[�^���l�܂���MenuSetCacheVO</param>
		/// <returns>�X�V���R�[�h��</returns>
		public int Update(DbCommand cmd,MenuSetCacheVO vo)
		{
			cmd.CommandText = "UPDATE BS_MENU_SET_CACHE SET" +
						"  LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType) +
						" ,MENU_LANGUAGE = " + ProviderUtil.GetParameterName("MENU_LANGUAGE", providerType) +
						" ,CACHE = " + ProviderUtil.GetParameterName("CACHE", providerType) +
						" WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType) +
						" AND MENU_LANGUAGE = " + ProviderUtil.GetParameterName("MENU_LANGUAGE", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginId));
			//MENU_LANGUAGE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MENU_LANGUAGE", providerType, vo.MenuLanguage));
			//CACHE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("CACHE", providerType, vo.Cache));

			//�X�V
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// ��L�[��DELETE���܂��B
		/// </summary>
		/// <param name="key">��L�[���l�܂���MenuKey</param>
		/// <returns>�폜���R�[�h��</returns>
		public int Delete(DbCommand cmd,MenuSetCacheKey key)
		{
			cmd.CommandText = "DELETE FROM BS_MENU_SET_CACHE " +
						" WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType) +
						" AND MENU_LANGUAGE = " + ProviderUtil.GetParameterName("MENU_LANGUAGE", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, key.LoginId));
			//MENU_LANGUAGE
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("MENU_LANGUAGE", providerType, key.MenuLanguage));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteAll
		/// <summary>
		/// ���ׂ�DELETE���܂��B
		/// </summary>
		/// <returns>�폜���R�[�h��</returns>
		public int DeleteAll(DbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM BS_MENU_SET_CACHE";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region DeleteByLoginId
		/// <summary>
		/// ���O�C��ID��DELETE���܂��B
		/// </summary>
		/// <param name="loginId"></param>
		/// <returns>�폜���R�[�h��</returns>
		public int DeleteByLoginId(DbCommand cmd,string loginId)
		{
			cmd.CommandText = "DELETE FROM BS_MENU_SET_CACHE " +
						" WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//�p�����[�^���Z�b�g
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//�폜
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion
	}
}
