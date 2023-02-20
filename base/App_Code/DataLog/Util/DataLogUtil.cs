// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.DataLog.Util
{
	/// <summary>
	/// �v���O����ID�̋��ʒ萔�⃁�\�b�h���`�����N���X�ł��B
	/// </summary>
	public class DataLogUtil
	{
		/// <summary>
		/// �v���O����ID�F���p�ҏ�񗚗�
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN_USER = "LOGIN_USER";

		/// <summary>
		/// �v���O����ID�F���O�C����񗚗�
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN = "LOGIN";

		/// <summary>
		/// �v���O����ID�F���[�����
		/// </summary>
		public const string DATA_TYPE_OF_ROLE = "ROLE";

		/// <summary>
		/// �v���O����ID�F���p�҃��b�N��ԗ���
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN_LOCK = "USER_LOCK";

		/// <summary>
		/// �v���O����ID�F���[���t�^����
		/// </summary>
		public const string DATA_TYPE_OF_ROLE_USER_MAP = "ROLE_USER_MAP";

		/// <summary>
		/// �v���O����ID�F�Z�L�����e�B�|���V�[
		/// </summary>
		public const string DATA_TYPE_OF_SECURITY_POLICY = "SECURITY_POLICY";

		/// <summary>
		/// �f�[�^�x�[�X�����ʁF�o�^
		/// </summary>
		public const string OPERATION_TYPE_OF_INSERT = "0";

		/// <summary>
		/// �f�[�^�x�[�X�����ʁF�X�V
		/// </summary>
		public const string OPERATION_TYPE_OF_UPDATE = "1";

		/// <summary>
		/// �f�[�^�x�[�X�����ʁF�폜
		/// </summary>
		public const string OPERATION_TYPE_OF_DELETE = "2";

		/// <summary>
		/// ���O�C���E���O�A�E�g
		/// </summary>
		public const string OPERATION_TYPE_OF_LOGINLOGOUT = "7";

		/// <summary>
		/// �v���O����START
		/// </summary>
		public const string OPERATION_TYPE_START = "8";

		/// <summary>
		/// �v���O����END
		/// </summary>
		public const string OPERATION_TYPE_END = "9";

	}
}
