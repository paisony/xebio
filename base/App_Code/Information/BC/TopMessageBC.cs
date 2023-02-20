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
using Com.Fujitsu.SmartBase.Base.Systems.Dac;
using Com.Fujitsu.SmartBase.Base.Systems;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information.BC
{
	/// <summary>
	/// メッセージを管理するComponentです。
	/// </summary>
	/// <remarks>参照系(SELECT)メソッドはComponentに含みません。</remarks>
	public class TopMessageBC : BaseBC
	{
		#region コンストラクタ
		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public TopMessageBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region 新規登録／更新
		/// <summary>
		/// メッセージを追加／更新します。
		/// </summary>
		/// <param name="vo">メッセージVO</param>
		/// <returns>成功したらtrue，失敗したら例外<see cref="DBConcurrencyException"/>を返します。</returns>
		public bool InsertOrUpdateTopMessage(TopMessageVO vo)
		{
			// Dacごとにインスタンスを生成します。
			TopMessageDac dac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				if (string.IsNullOrEmpty(vo.MessageId))
				{
					//メッセージIDの自動採番
					IDGeneratorDac idGen = new IDGeneratorDac(connection);
					string newId = idGen.GetNextID(cmd, IDGenerateTables.TABLE_TOP_MESSAGE);
					vo.MessageId = newId;

					vo.CreateUserId = loginUserInfo.LoginId;
					vo.UpdateUserId = loginUserInfo.LoginId;
					//追加
					dac.Insert(cmd, vo);
				}
				else
				{
					vo.UpdateUserId = loginUserInfo.LoginId;

					//更新
					dac.Update(cmd, vo);
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

		#region 削除
		/// <summary>
		/// メッセージを削除します。
		/// </summary>
		/// <param name="key">主キーオブジェクト</param>
		/// <param name="rowUpdateId">排他チェックID</param>
		/// <returns>成功したらtrue，失敗したら例外<see cref="DBConcurrencyException"/>を返します。</returns>
		public bool DeleteTopMessage(TopMessageKey key, string rowUpdateId)
		{
			// Dacごとにインスタンスを生成します。
			TopMessageDac dac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//削除
				dac.Delete(cmd, key, rowUpdateId);

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
