// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO
{
	#region ��L�[�I�u�W�F�N�g

	/// <summary>
	/// �G���e�B�e�BBS_OPERATION_TIME�̎�L�[��\���N���X
	/// </summary>
    [Serializable]
	public class OperationTimeSettingsKey : IPrimaryKey
	{
		#region �R���X�g���N�^
		/// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
		public OperationTimeSettingsKey()
		{
		}

		/// <summary>
		/// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
		/// </summary>
        /// <param name="day_type">��uDAY_TYPE�v�̒l</param>
        public OperationTimeSettingsKey(
			string dayType
			)
		{
            this.dayType = dayType;
		}
		#endregion
		
		#region �t�B�[���h

		/// <summary>
        /// ��uDAY_TYPE(DAY_TYPE)�v�̒l
		/// </summary>
        protected string dayType;

		#endregion

		#region �v���p�e�B

		/// <summary>
        /// ��uDAY_TYPE�v�̒l���擾�܂��͐ݒ肷��
		/// </summary>
		public string DayTYPE
		{
			get
			{
                return dayType;
			}
			set
			{
                dayType = value;
			}
		}
		#endregion

		#region IPrimaryKey �����o

		/// <summary>
		/// Entity�̎�L�[��̗񖼂ƒl�̃y�A���擾���܂��B
		/// </summary>
		/// <returns>��L�[��/�l�̔z��</returns>
		public KeyValuePair<string, object>[] GetPrimayKeyValues()
		{
			return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("DAY_TYPE",dayType),
			};
		}

		#endregion
	}

	#endregion

	#region �G���e�B�e�BVO

	/// <summary>
    ///  �G���e�B�e�BBS_OPERATION_TIME�ɑΉ�����ValueObject�ł��B
	/// </summary>
    [Serializable]
    public class OperationTimeSettingsVO : OperationTimeSettingsKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ��uSTART_TIME(START_TIME)�v�̒l
        /// </summary>
        private string starttime;

        /// <summary>
        /// ��uSTOP_TIME�v�̒l
        /// </summary>
        private string stoptime;

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// ��uSTART_TIME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string STARTTime 
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }

        /// <summary>
        /// ��uPC_NAME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string STOPTime
        {
            get
            {
                return stoptime;
            }
            set
            {
                stoptime = value;
            }
        }

        #endregion

        #region �R���X�g���N�^
        /// <summary>
		/// �C���X�^���X�𐶐����܂�
		/// </summary>
        public OperationTimeSettingsVO()
		{
		}

		#endregion
		
		#region ���\�b�h
		/// <summary>
        /// ���݂�OperationTimeSettingsVO��\��System.String��Ԃ��܂��B
		/// </summary>
        /// <returns>���݂�OperationTimeSettingsVO��\��System.String�B</returns>
		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();

            sb.Append("day_type:").Append(this.dayType).AppendLine();
            sb.Append("START_Time:").Append(this.starttime.ToString()).AppendLine();
            sb.Append("STOP_Time:").Append(this.stoptime.ToString()).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VO�̃R�s�[��Ԃ��܂��B
		/// </summary>
        /// <returns>OperationTimeSettingsVO</returns>
        public OperationTimeSettingsVO Copy()
		{
            OperationTimeSettingsVO vo = new OperationTimeSettingsVO();
            vo.DayTYPE = this.DayTYPE;
            vo.STARTTime = this.STARTTime;
            vo.STOPTime = this.STOPTime;

			return vo;
        }

		#endregion

	}

	#endregion
}

