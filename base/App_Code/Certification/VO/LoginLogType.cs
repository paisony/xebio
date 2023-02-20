// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	/// <summary>
	/// ���O�C�����O�̃^�C�v��\���܂��B
	/// </summary>
	public enum LoginLogType
	{
		/// <summary>
		/// �ʏ탍�O�C��
		/// </summary>
		Login,
		/// <summary>
		/// �ʏ탍�O�A�E�g
		/// </summary>
		Logout,
		/// <summary>
		/// �������O�C��
		/// </summary>
		CompulsoryLogin,
		/// <summary>
		/// �������O�A�E�g
		/// </summary>
		CompulsoryLogout,
		/// <summary>
		/// �Z�V�����^�C���A�E�g
		/// </summary>
		SessionTimeOut,
		/// <summary>
		/// �p�X���[�h���̓~�X�ɂ�郍�O�C�����s
		/// </summary>
		LoginFailureByInvalidPassword,
		/// <summary>
		/// ���[�U���b�N�ɂ�郍�O�C�����s
		/// </summary>
		LoginFailureByUserLock,
		/// <summary>
		/// �^�p���ԊO�ɂ�郍�O�C�����s
		/// </summary>
		LoginFailureByOperationTime,
		/// <summary>
		/// �@�\�̎��s
		/// </summary>
		FunctionExcute
	}
}