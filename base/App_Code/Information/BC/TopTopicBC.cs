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
	/// ���o�����Ǘ�����Component�ł��B
	/// </summary>
	/// <remarks>�Q�ƌn(SELECT)���\�b�h��Component�Ɋ܂݂܂���B</remarks>
	public class TopTopicBC : BaseBC
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public TopTopicBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region �V�K�o�^�^�X�V
		/// <summary>
		/// ���o����ǉ��^�X�V���܂��B
		/// </summary>
		/// <param name="vo">���o��VO</param>
		/// <returns>����������true�C���s�������O<see cref="DBConcurrencyException"/>��Ԃ��܂��B</returns>
		public bool InsertOrUpdateTopTopic(TopTopicVO vo)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			TopTopicDac dac = new TopTopicDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				if (string.IsNullOrEmpty(vo.TopicId))
				{
					//���b�Z�[�WID�̎����̔�
					IDGeneratorDac idGen = new IDGeneratorDac(connection);
					string newId = idGen.GetNextID(cmd, IDGenerateTables.TABLE_TOP_TOPIC);
					vo.TopicId = newId;
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
		/// ���o�����폜���܂��B
		/// </summary>
		/// <remarks>
		/// �폜�O�ɉ��L�̊֘A�`�F�b�N���s���܂��B
		/// 1.�폜���悤�Ƃ��錩�o�������b�Z�[�W�Ŏg�p����Ă��Ȃ�
		/// </remarks>
		/// <param name="vo">�폜���錩�o����VO�B��L�[�CTOPIC_ID,ROWUPDATEID��K���Z�b�g���Ă��������B</param>
		/// <returns>����������true��Ԃ��B(���s�������O<see cref="BusinessException"/>�܂���<see cref="DBConcurrencyException"/>��throw����B)</returns>
		/// <exception cref="BusinessException">���o���Ƀ��b�Z�[�W���R�t���Ă��鎞</exception>
		public bool DeleteTopTopic(TopTopicVO vo)
		{
			// Dac���ƂɃC���X�^���X�𐶐����܂��B
			TopTopicDac topicDac = new TopTopicDac(connection);
			TopMessageDac messageDac = new TopMessageDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				// 1.�폜�����݂�TOPIC_ID�����o���Ŏg�p����Ă��邩�`�F�b�N����
				if (messageDac.CheckTopicIDUsedByMessage(cmd, vo.TopicId))
				{
					//�g�p����Ă���
					BusinessError error = new BusinessError("���o���ɂ̓��b�Z�[�W�����݂��邽�ߍ폜�ł��܂���B" + vo.TopicId + ")",
						InformationErrorCode.ERROR_CODE_MESSAGE_EXIST);
					throw new BusinessException(error);
				}
				else
				{
					//�g�p����Ă��Ȃ�
					//�폜
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
