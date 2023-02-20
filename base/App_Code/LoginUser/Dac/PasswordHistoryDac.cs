// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using System.Data.Common;
using System.Data;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.Dac
{
	/// <summary>
	/// BS_PASSWORD_HISTORYテーブルにデータベースアクセスするクラスです。
	/// </summary>
	public class PasswordHistoryDac : BaseDac
	{
		#region コンストラクタ

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public PasswordHistoryDac(OracleConnection connection)
			: base(connection)
		{
		}
		#endregion

		#region Select
		/// <summary>
		/// パスワード履歴テーブル(BS_PASSWORD_HISTORY)から引数のログインIDを持つレコードを取得します。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns>検索結果が格納された<see cref="DataTable"/></returns>
		public DataTable SelectByLoginId(OracleCommand cmd, string loginId)
		{
			string query = "SELECT * FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
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

		#region Count
		/// <summary>
		/// 引数のログインIDに一致したレコード数を返します。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns>一致したレコード数</returns>
		public int Count(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "SELECT COUNT(*) FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			DbParameter para = ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId);

			//パラメータをセット
			cmd.Parameters.Add(para);

			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insertします
		/// </summary>
		/// <param name="vo">登録情報が格納されたPasswordHistoryVO</param>
		/// <returns>SQL文の実行によって処理されたレコード件数</returns>
		public int Insert(DbCommand cmd, PasswordHistoryVO vo)
		{
			cmd.CommandText = "INSERT INTO BS_PASSWORD_HISTORY (LOGIN_ID,UPDATE_DATETIME,PASSWORD) VALUES ("
							  + ProviderUtil.GetParameterName("LOGIN_ID", providerType)
						+ "," + ProviderUtil.GetParameterName("UPDATE_DATETIME", providerType)
						+ "," + ProviderUtil.GetParameterName("PASSWORD", providerType)
						+ ")";
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, vo.LoginID));
			//UPDATE_DATETIME
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("UPDATE_DATETIME", providerType, vo.UpdateDatetime));
			//PASSWORD
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("PASSWORD", providerType, vo.Password));

			//追加
			return cmd.ExecuteNonQuery();
		}
		#endregion

		#region DeleteByLoginId
		/// <summary>
		/// 引数のログインIDを持ったレコードを削除します。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns>SQL文の実行によって処理されたレコード件数</returns>
		public int DeleteByLoginId(DbCommand cmd, string loginId)
		{
			cmd.CommandText = "DELETE FROM BS_PASSWORD_HISTORY WHERE LOGIN_ID = " + ProviderUtil.GetParameterName("LOGIN_ID", null, providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			//LOGIN_ID
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("LOGIN_ID", providerType, loginId));

			//削除
			return cmd.ExecuteNonQuery();
		}
		#endregion
	}
}
