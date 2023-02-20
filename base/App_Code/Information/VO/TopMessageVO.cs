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
    /// ���m�点�����Ǘ�����e�[�u���̎�L�[�N���X�ł��B
    /// </summary>
    [Serializable]
    public class TopMessageKey : IPrimaryKey
    {
        #region �t�B�[���h

        /// <summary>
        /// ���b�Z�[�WID
        /// </summary>
        protected string messageId;

        #endregion

        #region �R���X�g���N�^

        public TopMessageKey()
        {
        }


        /// <summary>
        /// ���ׂĂ̗�𖾎��I�ɏ��������܂��B
        /// </summary>
        /// <param name="messageId">��L�[�umessageId�v</param>
        public TopMessageKey(string messageId)
        {
            this.messageId = messageId;
        }

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// ���b�Z�[�WID
        /// </summary>
        public string MessageId
        {
            get
            {
                return messageId;
            }
            set
            {
                messageId = value;
            }
        }

        #endregion

        #region IPrimaryKey �����o

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("MESSAGE_ID", messageId)
            };
        }

        #endregion
    }
    #endregion

    #region �G���e�B�e�BVO

    /// <summary>
    /// ���m�点�����Ǘ�����e�[�u����VO�N���X�ł��B
    /// </summary>
    [Serializable]
    public class TopMessageVO : TopMessageKey
    {
        #region �t�B�[���h

        /// <summary>
        /// �g�s�b�NID
        /// </summary>
        private string topicId;

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        private string message;

        /// <summary>
        /// URL
        /// </summary>
        private string url;

        /// <summary>
        /// �\���t���O
        /// </summary>
        private bool displayFlag;

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

        public TopMessageVO()
        {
        }

        #endregion 

        #region �v���p�e�B

        /// <summary>
        /// �g�s�b�NID
        /// </summary>
        public string TopicId
        {
            get
            {
                return topicId;
            }
            set
            {
                topicId = value;
            }
        }

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        /// <summary>
        /// URL
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        /// <summary>
        /// �\���t���O
        /// </summary>
        public bool DisplayFlag
        {
            get
            {
                return displayFlag;
            }
            set
            {
                displayFlag = value;
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

            sb.Append("MessageId:").Append(this.messageId).AppendLine();
            sb.Append("TopicId:").Append(this.topicId).AppendLine();
            sb.Append("Message:").Append(this.message).AppendLine();
            sb.Append("Url:").Append(this.url).AppendLine();
            sb.Append("DisplayFlag:").Append(this.displayFlag).AppendLine();
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
        /// <returns>TopMessageVO</returns>
        public TopMessageVO Copy()
        {
            TopMessageVO vo = new TopMessageVO();

            vo.MessageId = this.MessageId;
            vo.TopicId = this.TopicId;
            vo.Message = this.Message;
            vo.Url = this.Url;
            vo.DisplayFlag = this.DisplayFlag;
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
