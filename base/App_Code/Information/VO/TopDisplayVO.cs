// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Information.VO
{
    #region ��L�[�I�u�W�F�N�g

    /// <summary>
    /// �G���e�B�e�BBS_TOP_DISPLAY�̎�L�[��\���N���X
    /// </summary>
    [Serializable]
    public class TopDisplayKey : IPrimaryKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ��uDISPLAY_ID�v�̒l
        /// </summary>
        protected string displayId;

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂��B
        /// </summary>
        public TopDisplayKey()
        {
        }

        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="companyId">��uDISPLAY_ID]�v�̒l</param>
        public TopDisplayKey(string displayId)
        {
            this.displayId = displayId;
        }

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// ��uDISPLAY_ID�v�̒l���擾�܂��͐ݒ肷��B
        /// </summary>
        public string DisplayId
        {
            get
            {
                return displayId;
            }
            set
            {
                displayId = value;
            }
        }

        #endregion

        #region IPrimaryKey �����o

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("DISPLAY_ID", displayId)
            };
        }

        #endregion
    }

    #endregion

    #region �G���e�B�e�B�u�n

    /// <summary>
    /// �G���e�B�e�BBS_TOP_DISPLAY�ɑΉ��������ڂ̃f�[�^���Ǘ�����N���X�ł��B
    /// </summary>
    [Serializable]
    public class TopDisplayVO : TopDisplayKey
    {
        #region �t�B�[���h

        /// <summary>
        /// �\�����e
        /// </summary>
        private string displayContent;

        /// <summary>
        /// �쐬����
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// �쐬��ID
        /// </summary>
        private string createUserId;

        /// <summary>
        /// �X�V����
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// �X�V��ID
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// �r���`�F�b�NID
        /// </summary>
        private string rowUpdateId;

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �C���X�^���X�𐶐����܂��B
        /// </summary>
        public TopDisplayVO()
        {
        }

        #endregion 

        #region �v���p�e�B

        /// <summary>
        /// �\�����e
        /// </summary>
        public string DisplayContent
        {
            get
            {
                return displayContent;
            }
            set
            {
                displayContent = value;
            }
        }


        /// <summary>
        /// �쐬����
        /// </summary>
        public DateTime CreateDateTime
        {
            get
            {
                return createDatetime;
            }
            set
            {
                createDatetime = value;
            }
        }

        /// <summary>
        /// �쐬��ID
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return createUserId;
            }
            set
            {
                createUserId = value;
            }
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        public DateTime UpdateDateTime
        {
            get
            {
                return updateDatetime;
            }
            set
            {
                updateDatetime = value;
            }
        }

        /// <summary>
        /// �X�V��ID
        /// </summary>
        public string UpdateUserId
        {
            get
            {
                return updateUserId;
            }
            set
            {
                updateUserId = value;
            }
        }

        /// <summary>
        /// �r���`�F�b�NID
        /// </summary>
        public string RowUpdateId
        {
            get
            {
                return rowUpdateId;
            }
            set
            {
                rowUpdateId = value;
            }
        }

        #endregion

        #region ���\�b�h

        /// <summary>
        /// ���݂�TopDisplayVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�TopDisplayVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DisplayId:").Append(this.displayId).AppendLine();
            sb.Append("DisplayContent:").Append(this.displayContent).AppendLine();
            sb.Append("CreateDateTime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDateTime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("RowUpdateId:").Append(this.rowUpdateId).AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// VO�̃R�s�[��Ԃ��܂��B
        /// </summary>
        /// <returns>TopDisplayVO</returns>
        public TopDisplayVO Copy()
        {
            TopDisplayVO vo = new TopDisplayVO();

            vo.DisplayId = this.DisplayId;
            vo.DisplayContent = this.DisplayContent;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserId = this.CreateUserId;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserId = this.UpdateUserId;
            vo.RowUpdateId = this.RowUpdateId;

            return vo;
        }

        #endregion

    }

    #endregion 
}
