// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.Common.Config;


/// <summary>
/// �p�X���[�h�`�F�b�N�N���X
/// </summary>
/// <remarks>
/// �p�X���[�h���x��p�X���[�h�L�����Ԃ��`�F�b�N����N���X�ł��B
/// </remarks>
public class PasswordCheckUtil
{
    #region �R���X�g���N�^

    private PasswordCheckUtil()
    {
    }

    #endregion

    #region ���\�b�h

    ///// <summary>
    ///// �p�X���[�h�̋��x�`�F�b�N���s���܂��B
    ///// </summary>
    ///// <param name="pwd">�p�X���[�h���x�`�F�b�N���s���p�X���[�h</param>
    ///// <returns>
    ///// 0 �p�X���[�h�̕�������0�̎� 
    ///// 1 �p�X���[�h�Ƀp�X���[�h�p������ȊO�̕������g�p����Ă���
    ///// 2 (���x ��)�p�X���[�h�̌�����8�`10���ȊO�̎��܂��́A�����Ɋ֌W�Ȃ�1��ނ̕����킪�g�p����Ă��鎞
    ///// 3 (���x ��)�p�X���[�h������8�`10���A����2��ނ̕����킪�g�p����Ă���
    ///// 4 (���x ��)�p�X���[�h������8�`10���A����3��ނ̕����킪�g�p����Ă���
    ///// </returns>
    //public static int PwdStrengthCheck(string pwd)
    //{
    //    //���������͂���Ă��邩
    //    if (pwd.Length == 0) return 0;

    //    //�s���ȕ����̃`�F�b�N
    //    Regex invalidCharRegEx = new Regex("[^0-9a-zA-Z]");
    //    if (invalidCharRegEx.IsMatch(pwd)) return 1;

    //    //�p�X���[�h�������̃`�F�b�N(8���`10���ȊO�͕s���Ƃ���)
    //    //��(�p�X���[�h�������s��)
    //    if (pwd.Length <= 7 || pwd.Length >= 11) return 2;

    //    //�p�X���[�h�Ɋ܂܂�镶����̃J�E���g
    //    int charMatchCount = 0;

    //    Regex numberRegEx = new Regex("[0-9]");
    //    if (numberRegEx.IsMatch(pwd)) ++charMatchCount;

    //    Regex smallLetterRegEx = new Regex("[a-z]");
    //    if (smallLetterRegEx.IsMatch(pwd)) ++charMatchCount;

    //    Regex bigLetterRegEx = new Regex("[A-Z]");
    //    if (bigLetterRegEx.IsMatch(pwd)) ++charMatchCount;

    //    //�p�X���[�h���x�u��v�̕Ԃ�l��2����n�܂�̂ŕ�����J�E���g��1�����Z����
    //    return ++charMatchCount;
    //}

    /// <summary>
    /// �p�X���[�h�̗L���������`�F�b�N���܂��B
    /// </summary>
    /// <remarks>
    /// �ݒ�t�@�C������p�X���[�h�L�����Ԃƃp�X���[�h�ύX���O�ʒm�����擾�A
    /// �p�X���[�h�X�V�����Ɣ�r���Č��݂̃p�X���[�h���L���ł��邩���`�F�b�N���܂��B
    /// </remarks>
    /// <param name="pwdUpdateDT">�p�X���[�h�X�V����</param>
    /// <exception cref="ApplicationException">
    /// �E�ݒ�t�@�C������擾�����p�X���[�h�L�����Ԃ��p�X���[�h�ύX���O�ʒm���Ɠ��l����������
    /// �E���p�҂̃p�X���[�h�X�V�������s��(�X�V���������ݎ������������̏ꍇ�Ȃǎ��Ԃ̕s����)
    /// </exception>
    /// <returns>
    /// �߂�l
    /// 1:�p�X���[�h�L�����ԓ�(�p�X���[�h�ύX�x�����Ԃ�����)
    /// 2:�p�X���[�h�ύX�x������
    /// 3:�p�X���[�h��������
    /// </returns>
    public static int CheckPwdValid(DateTime pwdUpdateDT)
    {
        //�p�X���[�h�L�����ԁi���j�̎擾
        int validDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdValidDuration"].Value);
        //�p�X���[�h�ύX���O�ʒm���i���j�̎擾
        int promoteDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdChangePromoteDuration"].Value);
        //if (promoteDays >= validDays) throw new ApplicationException("�ݒ�t�@�C���̐ݒ�l���s���ł��B�g�p�X���[�h�L�����ԁh�́g�p�X���[�h�L�������ʒm���h�����傫���l��ݒ肵�Ă��������B");

        //�L������
        TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
        //�x�����ԁi�L������������t�Z���邽�߁A�}�C�i�X���ԁj
        TimeSpan promoteSpan = new TimeSpan(-promoteDays, 0, 0, 0);

        //�L��������
        DateTime expiresDT = pwdUpdateDT.Add(validSpan);
        //�x���J�n��
        DateTime promoteStartDT = expiresDT.Add(promoteSpan);
        //���ݎ������擾
        DateTime nowDT = DateTime.Now;

        if (nowDT >= expiresDT)
        {
            //�p�X���[�h��������
            return 3;
        }
        else if (nowDT >= promoteStartDT)
        {
            //�p�X���[�h�x�����ԓ�
            return 2;
        }
        else
        {
            //�p�X���[�h�L�����ԓ�(�p�X���[�h�ύX�x�����Ԃ�����)
            return 1;
        }
    }

    /// <summary>
    /// �p�X���[�h�̗L�������������擾���܂��B
    /// </summary>
    /// <param name="pwdUpdateDT">�p�X���[�h�X�V����</param>
    /// <returns>�p�X���[�h�̗L����������</returns>
    public static DateTime GetPasswordExpires(DateTime pwdUpdateDT)
    {
        //�p�X���[�h�L�����ԁi���j�̎擾
        int validDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdValidDuration"].Value);
        //�L������
        TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
        //�L��������
        return pwdUpdateDT.Add(validSpan);
    }


    #endregion
}
