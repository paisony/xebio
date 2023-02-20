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
    /// エンティティBS_TOP_DISPLAYの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class TopDisplayKey : IPrimaryKey
    {
        #region フィールド

        /// <summary>
        /// 列「DISPLAY_ID」の値
        /// </summary>
        protected string displayId;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public TopDisplayKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="companyId">列「DISPLAY_ID]」の値</param>
        public TopDisplayKey(string displayId)
        {
            this.displayId = displayId;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 列「DISPLAY_ID」の値を取得または設定する。
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

        #region IPrimaryKey メンバ

        public KeyValuePair<string, object>[] GetPrimayKeyValues()
        {
            return new KeyValuePair<string, object>[]{
                new KeyValuePair<string,object>("DISPLAY_ID", displayId)
            };
        }

        #endregion
    }

    #endregion

    #region エンティティＶＯ

    /// <summary>
    /// エンティティBS_TOP_DISPLAYに対応した項目のデータを管理するクラスです。
    /// </summary>
    [Serializable]
    public class TopDisplayVO : TopDisplayKey
    {
        #region フィールド

        /// <summary>
        /// 表示内容
        /// </summary>
        private string displayContent;

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

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public TopDisplayVO()
        {
        }

        #endregion 

        #region プロパティ

        /// <summary>
        /// 表示内容
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
        /// VOのコピーを返します。
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
