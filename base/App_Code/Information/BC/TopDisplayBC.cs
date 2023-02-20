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
	/// �g�b�v��ʏ����Ǘ�����Component�ł��B
	/// </summary>
	/// <remarks>�Q�ƌn(SELECT)���\�b�h��Component�Ɋ܂݂܂���B</remarks>
	public class TopDisplayBC : BaseBC
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���O�C�����[�U���ƃR�l�N�V������ݒ肷��R���X�g���N�^
		/// </summary>
		/// <param name="loginUserInfo">���O�C�����[�U���</param>
		/// <param name="connection">�R�l�N�V����</param>
		/// <exception cref="ArgumentException">���O�C�����[�U���������s��</exception>
		public TopDisplayBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}
		#endregion

		#region �X�V
		/// <summary>
		/// �g�b�v��ʏ����X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V��񂪊i�[���ꂽVO</param>
		/// <returns>����������true�C���s�������O��Ԃ��܂��B</returns>
		public bool UpdateTopDisplayData(TopDisplayVO vo)
		{
			// Dac�C���X�^���X�̐���
			TopDisplayDac dac = new TopDisplayDac(connection);

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				//�X�V��ID���Z�b�g
				vo.UpdateUserId = loginUserInfo.LoginId;

				//�X�V
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
