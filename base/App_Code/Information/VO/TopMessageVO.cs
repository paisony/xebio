// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.Information.VO
{
    #region 主キーオブジェクト

    /// <summary>
    /// お知らせ情報を管理するテーブルの主キークラスです。
    /// </summary>
    [Serializable]
    public class TopMessageKey : IPrimaryKey
    {
        #region フィールド

        /// <summary>
        /// メッセージID
        /// </summary>
        protected string messageId;

        #endregion

        #region コンストラクタ

        public TopMessageKey()
        {
        }


        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="messageId">主キー「messageId」</param>
        public TopMessageKey(string messageId)
        {
            this.messageId = messageId;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// メッセージID
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

        #region IPrimaryKey メンバ

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("MESSAGE_ID", messageId)
            };
        }

        #endregion
    }
    #endregion

    #region エンティティVO

    /// <summary>
    /// お知らせ情報を管理するテーブルのVOクラスです。
    /// </summary>
    [Serializable]
    public class TopMessageVO : TopMessageKey
    {
        #region フィールド

        /// <summary>
        /// トピックID
        /// </summary>
        private string topicId;

        /// <summary>
        /// メッセージ
        /// </summary>
        private string message;

        /// <summary>
        /// URL
        /// </summary>
        private string url;

        /// <summary>
        /// 表示フラグ
        /// </summary>
        private bool displayFlag;

        /// <summary>
        /// 作成日時
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// 作成者ID
        /// </summary>
        private string createUserId;

        /// <summary>
        /// 更新日時
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// 更新者ID
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// 排他チェックID
        /// </summary>
        private string rowUpdateId;

        #endregion

        #region コンストラクタ

        public TopMessageVO()
        {
        }

        #endregion 

        #region プロパティ

        /// <summary>
        /// トピックID
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
        /// メッセージ
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
        /// 表示フラグ
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
        /// 作成日時
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
        /// 作成者ID
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
        /// 更新日時
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
        /// 更新者ID
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
        /// 排他チェックID
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

        #region メソッド

        /// <summary>
        /// 現在のTopDisplayVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のTopDisplayVOを表すSystem.String。</returns>
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
        /// VOのコピーを返します。
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
