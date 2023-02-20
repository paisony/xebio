// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Information.Dac;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information.BC
{
	/// <summary>
	/// トップ画面情報を管理するComponentです。
	/// </summary>
	/// <remarks>参照系(SELECT)メソッドはComponentに含みません。</remarks>
	public class TopDisplayBC : BaseBC
	{
		#region コンストラクタ
		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public TopDisplayBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region 更新
		/// <summary>
		/// トップ画面情報を更新します。
		/// </summary>
		/// <param name="vo">更新情報が格納されたVO</param>
		/// <returns>成功したらtrue，失敗したら例外を返します。</returns>
		public bool UpdateTopDisplayData(TopDisplayVO vo)
		{
			// Dacインスタンスの生成
			TopDisplayDac dac = new TopDisplayDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//更新者IDをセット
				vo.UpdateUserId = loginUserInfo.LoginId;

				//更新
				dac.Update(cmd, vo);
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
