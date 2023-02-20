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
    /// 見出し管理情報を保持するクラス
    /// 主キーオブジェクト
    /// </summary>
    [Serializable]
    public class TopTopicKey : IPrimaryKey
    {
        #region フィールド変数

        /// <summary>
        /// 見出し管理ID
        /// </summary>
        protected string topicId;

        #endregion 

        #region プロパティ

        /// <summary>
        /// 見出し管理ID
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

        #region コンストラクタ

        public TopTopicKey()
        {
        }

        public TopTopicKey(string tId)
        {
            topicId = tId;
        }

        #endregion

        #region IPrimaryKey メンバ

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("TOPIC_ID", topicId)
            };
        }

        #endregion

    }
    #endregion

    #region エンティティＶＯ

    [Serializable]
    public class TopTopicVO : TopTopicKey
    {
        #region フィールド変数

        /// <summary>
        /// 見出し名
        /// </summary>
        private string topic;

        /// <summary>
        /// NEWの表示期間
        /// </summary>
        private string newDisplayPeriod;

        /// <summary>
        /// 日付表示フラグ
        /// </summary>
        private string dateDisplayFlag;

        /// <summary>
        /// 日付フォーマット
        /// </summary>
        private string dateFormat;

        /// <summary>
        /// 表示件数
        /// </summary>
        private string displayNumber;

        /// <summary>
        /// 表示期間
        /// </summary>
        private string displayPeriod;

        /// <summary>
        /// 表示フラグ
        /// </summary>
        private string displayFlag;

        /// <summary>
        /// 表示順
        /// </summary>
        private string sortNo;

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

        #region プロパティ

        /// <summary>
        /// 見出し名
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
        /// NEWの表示期間
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
        /// 日付表示フラグ
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
        /// 日付フォーマット
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
        /// 表示件数
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
        /// 表示期間
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
        /// 表示フラグ
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
        /// 表示順
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

        #region コンストラクタ

        public TopTopicVO()
        {
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 現在のTopTopicVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のTopTopicVOを表すSystem.String。</returns>
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
        /// VOのコピーを返します。
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
