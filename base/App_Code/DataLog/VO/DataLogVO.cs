// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.DataLog.VO
{
    #region ��L�[�I�u�W�F�N�g

    /// <summary>
    /// �G���e�B�e�BBS_DATA_LOG�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class DataLogKey : IPrimaryKey
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public DataLogKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="updateuserid">��uSOLUTION_ID�v�̒l</param> 
        /// <param name="operationtype">��uLOG_ID�v�̒l</param>
        public DataLogKey(
            string solutionid, string logid)
        {
            this.solutionid = solutionid;
            this.logid = logid;
        }
        #endregion

        #region �t�B�[���h
        /// <summary>
        /// ��uSOLUTION_ID�v�̒l
        /// </summary>

        protected string solutionid;

        /// <summary>
        /// ��uLOG_ID�v�̒l
        /// </summary>

        protected string logid;

        #endregion

        #region �v���p�e�B
        /// <summary>
        /// ��uSOLUTION_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>

        public string Solutionid
        {
            get
            {
                return solutionid;
            }
            set
            {
                solutionid = value;
            }
        }

        /// <summary>
        /// ��uLOG_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>

        public string Logid
        {
            get
            {
                return logid;
            }
            set
            {
                logid = value;
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
                new KeyValuePair<string, object>("SOLUTION_ID", solutionid),
                new KeyValuePair<string, object>("LOG_ID", logid),
			};

        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    ///  �G���e�B�e�BBS_DATA_LOG�ɑΉ�����ValueObject�ł��B
    /// </summary>
    [Serializable]
    public class DataLogVO : DataLogKey
    {
        /// <summary>
        /// ��uPROGRAM_ID(PROGRAM_ID)�v�̒l
        /// </summary>
        private string programid;

        /// <summary>
        /// ��uOPERATION_TYPE(OPERATION_TYPE)�v�̒l
        /// </summary>
        private string operationtype;

        /// <summary>
        /// ��uLOG_DATETIME(LOG_DATETIME)�v�̒l
        /// </summary>
        private DateTime logdatetime;

        /// <summary>
        /// ��uUPDATE_USER_ID(UPDATE_USER_ID)�v�̒l
        /// </summary>
        private string updateuserid;

        /// <summary>
        /// ��uTABLE_NAME(TABLE_NAME)�v�̒l
        /// </summary>
        private string tablename;

        /// <summary>
        /// ��uLOG_DATA(LOG_DATA)�v�̒l
        /// </summary>
        private string logdata;

        #region �v���p�e�B

        /// <summary>
        /// ��uPROGRAM_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Programid
        {
            get
            {
                return programid;
            }
            set
            {
                programid = value;
            }
        }

        /// <summary>
        /// ��uOPERATION_TYPE�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Operationtype
        {
            get
            {
                return operationtype;
            }
            set
            {
                operationtype = value;
            }
        }

        /// <summary>
        /// ��uLOG_DATETIME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public DateTime Logdatetime
        {
            get
            {
                return logdatetime;
            }
            set
            {
                logdatetime = value;
            }
        }

        /// <summary>
        /// ��uUPDATE_USER_ID�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Updateuserid
        {
            get
            {
                return updateuserid;
            }
            set
            {
                updateuserid = value;
            }
        }

        /// <summary>
        /// ��uTABLE_NAME�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string Tablename
        {
            get
            {
                return tablename;
            }
            set
            {
                tablename = value;
            }
        }

        /// <summary>
        /// ��uLOG_DATA�v�̒l���擾�܂��͐ݒ肷��
        /// </summary>
        public string LogData
        {
            get
            {
                return logdata;
            }
            set
            {
                logdata = value;
            }
        }

        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �C���X�^���X�𐶐����܂�
        /// </summary>
        public DataLogVO()
        {
        }

        #endregion

        #region ���\�b�h
        /// <summary>
        /// ���݂�DataLogVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�DataLogVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Solutionid:").Append(this.solutionid).AppendLine();
            sb.Append("Logid:").Append(this.logid).AppendLine();
            sb.Append("Programid:").Append(this.programid).AppendLine();
            sb.Append("Operationtype:").Append(this.operationtype).AppendLine();
            sb.Append("Logdatetime:").Append(this.logdatetime).AppendLine();
            sb.Append("Updateuserid:").Append(this.updateuserid).AppendLine();
            sb.Append("Tablename:").Append(this.tablename).AppendLine();
            sb.Append("Logdata:").Append(this.logdata).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>DataLogVO</returns>
        public DataLogVO Copy()
        {
            DataLogVO vo = new DataLogVO();

            vo.Solutionid = this.Solutionid;
            vo.Logid = this.Logid;
            vo.Programid = this.Programid;
            vo.Operationtype = this.Operationtype;
            vo.Logdatetime = this.Logdatetime;
            vo.Updateuserid = this.Updateuserid;
            vo.Tablename = this.Tablename;
            vo.LogData = this.LogData;

            return vo;
        }

        #endregion

    }

    #endregion
}
