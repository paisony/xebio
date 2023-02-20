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
    /// ���o���Ǘ�����ێ�����N���X
    /// ��L�[�I�u�W�F�N�g
    /// </summary>
    [Serializable]
    public class TopTopicKey : IPrimaryKey
    {
        #region �t�B�[���h�ϐ�

        /// <summary>
        /// ���o���Ǘ�ID
        /// </summary>
        protected string topicId;

        #endregion 

        #region �v���p�e�B

        /// <summary>
        /// ���o���Ǘ�ID
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

        #endregion

        #region �R���X�g���N�^

        public TopTopicKey()
        {
        }

        public TopTopicKey(string tId)
        {
            topicId = tId;
        }

        #endregion

        #region IPrimaryKey �����o

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("TOPIC_ID", topicId)
            };
        }

        #endregion

    }
    #endregion

    #region �G���e�B�e�B�u�n

    [Serializable]
    public class TopTopicVO : TopTopicKey
    {
        #region �t�B�[���h�ϐ�

        /// <summary>
        /// ���o����
        /// </summary>
        private string topic;

        /// <summary>
        /// NEW�̕\������
        /// </summary>
        private string newDisplayPeriod;

        /// <summary>
        /// ���t�\���t���O
        /// </summary>
        private string dateDisplayFlag;

        /// <summary>
        /// ���t�t�H�[�}�b�g
        /// </summary>
        private string dateFormat;

        /// <summary>
        /// �\������
        /// </summary>
        private string displayNumber;

        /// <summary>
        /// �\������
        /// </summary>
        private string displayPeriod;

        /// <summary>
        /// �\���t���O
        /// </summary>
        private string displayFlag;

        /// <summary>
        /// �\����
        /// </summary>
        private string sortNo;

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

        #region �v���p�e�B

        /// <summary>
        /// ���o����
        /// </summary>
        public string Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
            }
        }

        /// <summary>
        /// NEW�̕\������
        /// </summary>
        public string NewDisplayPriod
        {
            get
            {
                return newDisplayPeriod;
            }
            set
            {
                newDisplayPeriod = value;
            }
        }

        /// <summary>
        /// ���t�\���t���O
        /// </summary>
        public string DateDisplayFlag
        {
            get
            {
                return dateDisplayFlag;
            }
            set
            {
                dateDisplayFlag = value;
            }
        }

        /// <summary>
        /// ���t�t�H�[�}�b�g
        /// </summary>
        public string DateFormat
        {
            get
            {
                return dateFormat;
            }
            set
            {
                dateFormat = value;
            }
        }

        /// <summary>
        /// �\������
        /// </summary>
        public string DisplayNumber
        {
            get
            {
                return displayNumber;
            }
            set
            {
                displayNumber = value;
            }
        }

        /// <summary>
        /// �\������
        /// </summary>
        public string DisplayPeriod
        {
            get
            {
                return displayPeriod;
            }
            set
            {
                displayPeriod = value;
            }
        }

        /// <summary>
        /// �\���t���O
        /// </summary>
        public string DisplayFlag
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
        /// �\����
        /// </summary>
        public string SortNo
        {
            get
            {
                return sortNo;
            }
            set
            {
                sortNo = value;
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

        #region �R���X�g���N�^

        public TopTopicVO()
        {
        }

        #endregion

        #region ���\�b�h

        /// <summary>
        /// ���݂�TopTopicVO��\��System.String��Ԃ��܂��B
        /// </summary>
        /// <returns>���݂�TopTopicVO��\��System.String�B</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TopicId:").Append(this.topicId).AppendLine();
            sb.Append("Topic:").Append(this.topic).AppendLine();
            sb.Append("NewDisplayPeriod:").Append(this.newDisplayPeriod).AppendLine();
            sb.Append("DateDisplayFlag:").Append(this.dateDisplayFlag).AppendLine();
            sb.Append("DateFormat:").Append(this.dateFormat).AppendLine();
            sb.Append("DisplayNumber:").Append(this.displayNumber).AppendLine();
            sb.Append("DisplayPeriod:").Append(this.displayPeriod).AppendLine();
            sb.Append("DisplayFlag:").Append(this.displayFlag).AppendLine();
            sb.Append("SortNo:").Append(this.sortNo).AppendLine();
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
        /// <returns>TopTopicVO</returns>
        public TopTopicVO Copy()
        {
            TopTopicVO vo = new TopTopicVO();

            vo.TopicId = this.TopicId;
            vo.Topic = this.Topic;
            vo.NewDisplayPriod = this.NewDisplayPriod;
            vo.DateDisplayFlag = this.DateDisplayFlag;
            vo.DateFormat = this.DateFormat;
            vo.DisplayNumber = this.DisplayNumber;
            vo.DisplayPeriod = this.DisplayPeriod;
            vo.DisplayFlag = this.DisplayFlag;
            vo.SortNo = this.SortNo;
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
