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
	/// 見出しを管理するComponentです。
	/// </summary>
	/// <remarks>参照系(SELECT)メソッドはComponentに含みません。</remarks>
	public class TopTopicBC : BaseBC
	{
		#region コンストラクタ
		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public TopTopicBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region 新規登録／更新
		/// <summary>
		/// 見出しを追加／更新します。
		/// </summary>
		/// <param name="vo">見出しVO</param>
		/// <returns>成功したらtrue，失敗したら例外<see cref="DBConcurrencyException"/>を返します。</returns>
		public bool InsertOrUpdateTopTopic(TopTopicVO vo)
		{
			// Dacごとにインスタンスを生成します。
			TopTopicDac dac = new TopTopicDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				if (string.IsNullOrEmpty(vo.TopicId))
				{
					//メッセージIDの自動採番
					IDGeneratorDac idGen = new IDGeneratorDac(connection);
					string newId = idGen.GetNextID(cmd, IDGenerateTables.TABLE_TOP_TOPIC);
					vo.TopicId = newId;
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
		/// 見出しを削除します。
		/// </summary>
		/// <remarks>
		/// 削除前に下記の関連チェックを行います。
		/// 1.削除しようとする見出しがメッセージで使用されていない
		/// </remarks>
		/// <param name="vo">削除する見出しのVO。主キー，TOPIC_ID,ROWUPDATEIDを必ずセットしてください。</param>
		/// <returns>成功したらtrueを返す。(失敗したら例外<see cref="BusinessException"/>または<see cref="DBConcurrencyException"/>をthrowする。)</returns>
		/// <exception cref="BusinessException">見出しにメッセージが紐付いている時</exception>
		public bool DeleteTopTopic(TopTopicVO vo)
		{
			// Dacごとにインスタンスを生成します。
			TopTopicDac topicDac = new TopTopicDac(connection);
			TopMessageDac messageDac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				// 1.削除を試みるTOPIC_IDが見出しで使用されているかチェックする
				if (messageDac.CheckTopicIDUsedByMessage(cmd, vo.TopicId))
				{
					//使用されている
					BusinessError error = new BusinessError("見出しにはメッセージが存在するため削除できません。" + vo.TopicId + ")",
						InformationErrorCode.ERROR_CODE_MESSAGE_EXIST);
					throw new BusinessException(error);
				}
				else
				{
					//使用されていない
					//削除
					TopTopicKey key = new TopTopicKey(vo.TopicId);
					string rowUpdateId = vo.RowUpdateId;
					topicDac.Delete(cmd, key, rowUpdateId);
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

	}
}
