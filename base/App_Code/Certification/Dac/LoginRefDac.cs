// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Certification.Dac
{
	public class LoginRefDac : BaseDac
	{
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public LoginRefDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region GetLoginInfoByCertId
		/// <summary>
		/// 認証IDからログイン情報を取得します。
		/// </summary>
		/// <param name="certId">認証ID</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable GetLoginInfoByCertId(OracleCommand cmd, string certId)
		{
			string query = @"SELECT A.LOGIN_INFO_ID, A.COMPANY_ID, A.LOGIN_ID, A.USER_LANGUAGE, A.MENU_PTN_CD, A.LOGIN_DATETIME, A.ACCESS_DATETIME "
							+ " FROM BS_LOGIN_INFO A LEFT OUTER JOIN BS_LOGIN_CERT B ON A.LOGIN_INFO_ID = B.LOGIN_INFO_ID "
							+ " WHERE B.LOGIN_CERT_ID = " + ProviderUtil.GetParameterName("LOGIN_CERT_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_CERT_ID", providerType, certId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region GetCertIdByLoginInfo
		/// <summary>
		/// ログイン情報から認証IDを取得します。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable GetCertIdByLoginInfo(OracleCommand cmd, string loginId)
		{
			string query = @"SELECT A.LOGIN_INFO_ID, A.COMPANY_ID, A.LOGIN_ID, A.USER_LANGUAGE, A.MENU_PTN_CD, A.LOGIN_DATETIME, A.ACCESS_DATETIME , B.LOGIN_CERT_ID "
							+ " FROM BS_LOGIN_INFO A , BS_LOGIN_CERT B "
							+ " WHERE A.LOGIN_INFO_ID = B.LOGIN_INFO_ID AND A.LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion

		#region GetCompanyId
		/// <summary>
		/// 主キーでSELECTします。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectCOMPANY(OracleCommand cmd, string LoginID)
		{
			string query = "SELECT COMPANY_ID , MENU_PTN_CD FROM BS_LOGIN_USER WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			OracleDataAdapter adapter = new OracleDataAdapter(cmd);
			cmd.CommandText = query;
			adapter.SelectCommand = cmd;
			adapter.SelectCommand.Parameters.Clear();

			//パラメータをセット
			adapter.SelectCommand.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, LoginID));
			//Fill
			DataTable res = new DataTable();
			adapter.Fill(res);

			return res;
		}
		#endregion
	}
}
