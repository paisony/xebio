// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Transactions;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Information.BC;
using Com.Fujitsu.SmartBase.Base.Information.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information
{
	/// <summary>
	/// ���m�点���̐V�K�o�^�A�ҏW�A�폜���̏������Ǘ�����N���X�ł��B
	/// </summary>
	public class InformationService : BaseService
	{
		#region �R���X�g���N�^
		public InformationService()
			: base()
		{

		}

		public InformationService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{

		}
		#endregion

		#region �g�b�v��ʏ��
		#region GetAllTopDisplay
		/// <summary>
		/// �S�Ẵg�b�v��ʏ����擾���܂��B
		/// </summary>
		/// <returns>����(IsSuccess true:���� false:���s)�B���������ꍇ��ResultData�v���p�e�B�Ɏ擾�f�[�^���i�[�����B</returns>
		public DataResult<DataTable> GetAllTopDisplay(bool dsp, string loginId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopDisplayDac dac = new TopDisplayDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					if (res.ResultData.Rows.Count == 0 && !dsp)
					{
						LoginUserInfoVO loginUserInfo = new LoginUserInfoVO();
						loginUserInfo.LoginId = loginId;
						TopDisplayDac dac2 = new TopDisplayDac(loginUserInfo, connection);
						TopDisplayVO vo2 = new TopDisplayVO();
						vo2.DisplayId = "1";
						vo2.DisplayContent = "";
						vo2.CreateDateTime = DateTime.Now;
						vo2.CreateUserId = "";
						vo2.UpdateUserId = "";
						int count2 = dac2.Insert(cmd, vo2);
						if (count2 > 0)
						{
							//�ēǍ���
							dt = dac.SelectAll(cmd);
							res = new DataResult<DataTable>(dt != null, dt);
						}
					}
					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopDisplay", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region UpdateTopDisplay
		/// <summary>
		/// �g�b�v��ʏ����X�V���܂��B
		/// </summary>
		/// <param name="vo">�X�V��񂪃Z�b�g���ꂽVO</param>
		/// <returns>����(IsSuccess true:���� false:���s)</returns>
		public Result UpdateTopDisplay(TopDisplayVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopDisplayBC bc = new TopDisplayBC(loginUserInfo, connection);
					res = new Result(bc.UpdateTopDisplayData(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateTopDisplay", ex);
			}
		}
		#endregion
		#endregion

		#region ���o��
		#region GetTopTopic
		/// <summary>
		/// ���o������1���擾���܂��B
		/// </summary>
		/// <param name="key">��L�[</param>
		/// <returns>����(IsSuccess true:���� false:���s)�B
		/// ���������ꍇ��ResultData�v���p�e�B�Ɏ擾�f�[�^���i�[�����B</returns>
		public DataResult<DataTable> GetTopTopic(TopTopicKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopTopicDac dac = new TopTopicDac(connection);
					dt = dac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetTopTopic", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllTopTopic
		/// <summary>
		/// ���o������S���擾���܂��B
		/// </summary>
		/// <param name="checkDisplayFlag">�\���t���O
		/// true:DISPLAY_FLAG��1�̃��R�[�h��S���擾 
		/// false:DISPLAY_FLAG�̒l�Ɋւ�炸�S���擾(���S�ȑS���擾)</param>
		/// <returns>�擾���ʂ��i�[���ꂽDataTable</returns>
		/// <returns>����(IsSuccess true:���� false:���s)�B
		/// ���������ꍇ��ResultData�v���p�e�B�Ɏ擾�f�[�^���i�[�����B</returns>
		public DataResult<DataTable> GetAllTopTopic(bool checkDisplayFlag)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopTopicDac dac = new TopTopicDac(connection);
					dt = dac.SelectAll(cmd, checkDisplayFlag);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopTopic", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertOrUpdateTopTopic
		/// <summary>
		/// ���o����ǉ��܂��͍X�V���܂��B
		/// </summary>
		/// <param name="vo">�ǉ��^�X�V��񂪃Z�b�g���ꂽVO</param>
		/// <returns>����(IsSuccess true:���� false:���s)</returns>
		public Result InsertOrUpdateTopTopic(TopTopicVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopTopicBC bc = new TopTopicBC(loginUserInfo, connection);
					res = new Result(bc.InsertOrUpdateTopTopic(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateTopDisplay", ex);
			}
		}
		#endregion

		#region DeleteTopTopic
		/// <summary>
		/// ���o�����폜���܂��B
		/// </summary>
		/// <param name="vo">�폜��񂪃Z�b�g���ꂽVO�B��L�[�CTOPIC_ID,ROWUPDATEID��K���Z�b�g���Ă��������B</param>
		/// <returns>����(IsSuccess true:���� false:���s)</returns>
		public Result DeleteTopTopic(TopTopicVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopTopicBC bc = new TopTopicBC(loginUserInfo, connection);
					res = new Result(bc.DeleteTopTopic(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteTopTopic", ex);
			}
		}
		#endregion
		#endregion

		#region ���b�Z�[�W
		#region FindTopMessage
		/// <summary>
		/// ���������ň�v�������R�[�h��Ԃ��܂��B
		/// </summary>
		/// <param name="queryObj">�����������i�[���ꂽQueryObject</param>
		/// <returns>��v���R�[�h��</returns>
		public DataResult<DataTable> FindTopMessage(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					// TODO yusy del DbCommand �� OracleCommand
					//DbCommand cmd = connection.CreateCommand();
					// TODO yusy add DbCommand �� OracleCommand
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.Find(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region FindCountTopMessage
		/// <summary>
		/// ���������ň�v�������R�[�h����Ԃ��܂��B
		/// </summary>
		/// <param name="queryObj">�����������i�[���ꂽQueryObject</param>
		/// <returns>��v���R�[�h��</returns>
		public DataResult<int> FindCountTopMessage(QueryObject queryObj)
		{
			DataResult<int> res;
			int count;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					count = dac.FindCount(cmd, queryObj);
					res = new DataResult<int>(count >= 0, count);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<int>)base.HandleException("FindCountTopMessage", ex, typeof(DataResult<int>));
			}
		}
		#endregion

		#region GetTopMessage
		/// <summary>
		/// ���b�Z�[�W����1���擾���܂��B
		/// </summary>
		/// <param name="key">��L�[</param>
		/// <returns>����(IsSuccess true:���� false:���s)�B
		/// ���������ꍇ��ResultData�v���p�e�B�Ɏ擾�f�[�^���i�[�����B</returns>
		public DataResult<DataTable> GetTopMessage(TopMessageKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllTopMessage
		/// <summary>
		/// ���b�Z�[�W����S���擾���܂��B
		/// </summary>
		/// <returns>����(IsSuccess true:���� false:���s)�B
		/// ���������ꍇ��ResultData�v���p�e�B�Ɏ擾�f�[�^���i�[�����B</returns>
		public DataResult<DataTable> GetAllTopMessage()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertOrUpdateTopMessage
		/// <summary>
		/// ���b�Z�[�W��ǉ��܂��͍X�V���܂��B
		/// </summary>
		/// <param name="vo">�ǉ��^�X�V��񂪃Z�b�g���ꂽVO</param>
		/// <returns>����(IsSuccess true:���� false:���s)</returns>
		public Result InsertOrUpdateTopMessage(TopMessageVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopMessageBC bc = new TopMessageBC(loginUserInfo, connection);
					res = new Result(bc.InsertOrUpdateTopMessage(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertOrUpdateTopMessage", ex);
			}
		}
		#endregion

		#region DeleteTopMessage
		/// <summary>
		/// ���b�Z�[�W���폜���܂��B
		/// </summary>
		/// <param name="key">��L�[</param>
		/// <param name="rowUpdateId">�r���`�F�b�NID</param>
		/// <returns>����(IsSuccess true:���� false:���s)</returns>
		public Result DeleteTopMessage(TopMessageKey key, string rowUpdateId)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopMessageBC bc = new TopMessageBC(loginUserInfo, connection);
					res = new Result(bc.DeleteTopMessage(key, rowUpdateId));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteTopMessage", ex);
			}
		}
		#endregion
		#endregion
	}
}
