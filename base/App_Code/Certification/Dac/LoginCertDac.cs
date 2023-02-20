// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Certification.Dac
{
	/// <summary>
	/// BS_LOGIN_CERTテーブルにデータベースアクセスするクラスです。
	/// </summary>
	public class LoginCertDac : BaseDac
	{

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public LoginCertDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// 主キーでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable Select(OracleCommand cmd, LoginCertKey key)
		{
			string query = "SELECT * FROM BS_LOGIN_CERT WHERE LOGIN_CERT_ID = " + ProviderUtil.GetParameterName("LOGIN_CERT_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_CERT_ID", providerType, key.LoginCertID));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region Insert
		/// <summary>
		/// INSERTします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginCertVO</param>
		/// <returns>更新レコード数</returns>
		public int Insert(OracleCommand cmd, LoginCertVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_LOGIN_CERT (LOGIN_CERT_ID,LOGIN_INFO_ID,SOLUTION_ID) VALUES ("
							  + ProviderUtil.GetParameterName("LOGIN_CERT_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_CERT_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_CERT_ID", providerType, vo.LoginCertID));
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, vo.LoginInfoID));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID));
			//追加
			int count = cmd.ExecuteNonQuery();
			return count;
		}
		#endregion

		#region Update
		/// <summary>
		/// 主キーでUPDATEします。
		/// </summary>
		/// <param name="vo">データが詰まったLoginCertVO</param>
		/// <returns>更新レコード数</returns>
		public int Update(DbCommand cmd, LoginCertVO vo)
		{
			cmd.CommandText = "UPDATE BS_LOGIN_CERT SET "
						+ " LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType)
						+ ",SOLUTION_ID = " + ProviderUtil.GetParameterName("SOLUTION_ID", providerType)
						+ " WHERE LOGIN_CERT_ID = " + ProviderUtil.GetParameterName("LOGIN_CERT_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_INFO_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_INFO_ID", providerType, vo.LoginInfoID));
			//SOLUTION_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("SOLUTION_ID", providerType, vo.SolutionID));
			//LOGIN_CERT_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_CERT_ID", providerType, vo.LoginCertID));

			//更新
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

		#region Delete
		/// <summary>
		/// 主キーでDELETEします。
		/// </summary>
		/// <param name="key">主キーが詰まったLoginCertKey</param>
		/// <returns>削除レコード数</returns>
		public int Delete(DbCommand cmd, LoginCertKey key)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_CERT WHERE LOGIN_CERT_ID = " + ProviderUtil.GetParameterName("LOGIN_CERT_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_CERT_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_CERT_ID", providerType, key.LoginCertID));
			//削除
			int count = cmd.ExecuteNonQuery();
			return count;
		}

		/// <summary>
		/// ログイン情報IDでDELETEします。
		/// </summary>
		/// <param name="loginInfoId">ログイン情報ID</param>
		/// <returns>削除レコード数</returns>
		public int DeleteByLoginInfoID(OracleCommand cmd, string loginInfoId)
		{
			cmd.CommandText = "DELETE FROM BS_LOGIN_CERT WHERE LOGIN_INFO_ID = " + ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_CERT_ID
			DbParameter loginInfoIdParam = cmd.CreateParameter();
			loginInfoIdParam.ParameterName = ProviderUtil.GetParameterName("LOGIN_INFO_ID", providerType);
			loginInfoIdParam.Value = loginInfoId;
			cmd.Parameters.Add(loginInfoIdParam);

			//削除
			int count = cmd.ExecuteNonQuery();

			return count;
		}
		#endregion

	}
}
