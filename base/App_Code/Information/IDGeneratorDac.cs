// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.Dac;
using System.Data.Common;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information
{
	public class IDGeneratorDac : BaseDac
	{
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		/// <remarks>
		/// ログイン前の処理に利用する。
		/// 通常はログインユーザ情報とコネクションを設定するコンストラクタを利用する。

		/// </remarks>
		public IDGeneratorDac(OracleConnection connection)
			: base(connection)
		{
			this.connection = connection;
		}
		#endregion

		#region IDを採番
		/// <summary>
		/// 指定したテーブルの新規IDを１つ取得する
		/// </summary>
		/// <param name="tableName">テーブル名</param>
		/// <returns>新規ID</returns>
		/// <exception cref="IDGeneratorException">IDの採番に失敗した場合にthrowされる</exception>
		public string GetNextID(OracleCommand cmd, string tableName)
		{
			string newID = null;

			DbCommand selectcmd = this.GetSelectCommand(cmd, tableName);

			using (DbDataReader reader = selectcmd.ExecuteReader())
			{
				while (reader.Read())
				{
					string oldID = Convert.ToString(reader["ID"]);
					int num = Convert.ToInt32(reader["DIGITNUMBER"]);
					newID = this.MakeNewIdString(oldID, num);
					break;
				}
			}
			// DBを更新する
			DbCommand updatecmd = this.GetUpdateCommand(cmd, newID, tableName);
			updatecmd.ExecuteNonQuery();
			if (string.IsNullOrEmpty(newID))
			{
				throw new IDGeneratorException(tableName + "に対応するID取得に失敗しました。");
			}

			return newID;
		}
		#endregion

		#region 新ID文字列の作成
		/// <summary>
		/// ID文字列から、次に採番すべきID文字列を作成して返します。
		/// </summary>
		/// <param name="oldId">古いID文字列</param>
		/// <param name="length">ID文字列の桁数</param>
		/// <returns>新しいID</returns>
		private string MakeNewIdString(string oldId, int length)
		{
			// IDの桁数を合わせる

			decimal id_int = decimal.Parse(oldId) + 1;
			string newId = id_int.ToString().PadLeft(length, '0');

			return newId;
		}
		#endregion

		#region コマンド
		/// <summary>
		/// GetSelectCommand
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		private DbCommand GetSelectCommand(DbCommand cmd, string table)
		{
			if (providerType == ProviderType.SqlClient)
			{
				cmd.CommandText = "SELECT * FROM BS_ID_GENERATOR  WITH(ROWLOCK,UPDLOCK) WHERE TABLE_NAME = "
										+ ProviderUtil.GetParameterName("TABLE_NAME", providerType);
			}
			else
			{
				cmd.CommandText = "SELECT * FROM BS_ID_GENERATOR WHERE TABLE_NAME = "
										+ ProviderUtil.GetParameterName("TABLE_NAME", providerType) + " FOR UPDATE ";
			}
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TABLE_NAME", base.providerType, table));

			return cmd;
		}
		/// <summary>
		/// GetUpdateCommand
		/// </summary>
		/// <param name="newid"></param>
		/// <param name="table"></param>
		/// <returns></returns>
		private DbCommand GetUpdateCommand(DbCommand cmd, string newid, string table)
		{
			cmd.CommandText = "UPDATE BS_ID_GENERATOR SET ID = "
						+ ProviderUtil.GetParameterName("ID", providerType)
						+ " WHERE TABLE_NAME = " + ProviderUtil.GetParameterName("TABLE_NAME", providerType);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			//パラメータをセット
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("ID", base.providerType, newid));
			cmd.Parameters.Add(ProviderUtil.CreateDbParameter("TABLE_NAME", base.providerType, table));

			return cmd;
		}
		#endregion
	}
}
