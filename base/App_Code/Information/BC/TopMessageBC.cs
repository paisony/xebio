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
	/// ���b�Z�[�W���Ǘ�����Component�ł��B
	/// </summary>
	/// <remarks>�Q�ƌn(SELECT)���\�b�h��Component�Ɋ܂݂܂���B</remarks>
	public class TopMessageBC : BaseBC
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public TopMessageBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region �V�K�o�^�^�X�V
		/// <summary>
		/// ���b�Z�[�W��ǉ��^�X�V���܂��B
		/// </summary>
		/// <param name="vo">���b�Z�[�WVO</param>
		/// <returns>����������true�C���s�������O<see cref="DBConcurrencyException"/>��Ԃ��܂��B</returns>
		public bool InsertOrUpdateTopMessage(TopMessageVO vo)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			TopMessageDac dac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				if (string.IsNullOrEmpty(vo.MessageId))
				{
					//���b�Z�[�WID�̎����̔�
					IDGeneratorDac idGen = new IDGeneratorDac(connection);
					string newId = idGen.GetNextID(cmd, IDGenerateTables.TABLE_TOP_MESSAGE);
					vo.MessageId = newId;

					vo.CreateUserId = loginUserInfo.LoginId;
					vo.UpdateUserId = loginUserInfo.LoginId;
					//�ǉ�
					dac.Insert(cmd, vo);
				}
				else
				{
					vo.UpdateUserId = loginUserInfo.LoginId;

					//�X�V
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

		#region �폜
		/// <summary>
		/// ���b�Z�[�W���폜���܂��B
		/// </summary>
		/// <param name="key">��L�[�I�u�W�F�N�g</param>
		/// <param name="rowUpdateId">�r���`�F�b�NID</param>
		/// <returns>����������true�C���s�������O<see cref="DBConcurrencyException"/>��Ԃ��܂��B</returns>
		public bool DeleteTopMessage(TopMessageKey key, string rowUpdateId)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			TopMessageDac dac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//�폜
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
