// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.DataLog.VO
{
    #region 主キーオブジェクト

    /// <summary>
    /// エンティティBS_DATA_LOGの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class DataLogKey : IPrimaryKey
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public DataLogKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="updateuserid">列「SOLUTION_ID」の値</param> 
        /// <param name="operationtype">列「LOG_ID」の値</param>
        public DataLogKey(
            string solutionid, string logid)
        {
            this.solutionid = solutionid;
            this.logid = logid;
        }
        #endregion

        #region フィールド
        /// <summary>
        /// 列「SOLUTION_ID」の値
        /// </summary>

        protected string solutionid;

        /// <summary>
        /// 列「LOG_ID」の値
        /// </summary>

        protected string logid;

        #endregion

        #region プロパティ
        /// <summary>
        /// 列「SOLUTION_ID」の値を取得または設定する
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
        /// 列「LOG_ID」の値を取得または設定する
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

        #region IPrimaryKey メンバ

        /// <summary>
        /// Entityの主キー列の列名と値のペアを取得します。
        /// </summary>
        /// <returns>主キー列名/値の配列</returns>
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

    #region エンティティVO

    /// <summary>
    ///  エンティティBS_DATA_LOGに対応したValueObjectです。
    /// </summary>
    [Serializable]
    public class DataLogVO : DataLogKey
    {
        /// <summary>
        /// 列「PROGRAM_ID(PROGRAM_ID)」の値
        /// </summary>
        private string programid;

        /// <summary>
        /// 列「OPERATION_TYPE(OPERATION_TYPE)」の値
        /// </summary>
        private string operationtype;

        /// <summary>
        /// 列「LOG_DATETIME(LOG_DATETIME)」の値
        /// </summary>
        private DateTime logdatetime;

        /// <summary>
        /// 列「UPDATE_USER_ID(UPDATE_USER_ID)」の値
        /// </summary>
        private string updateuserid;

        /// <summary>
        /// 列「TABLE_NAME(TABLE_NAME)」の値
        /// </summary>
        private string tablename;

        /// <summary>
        /// 列「LOG_DATA(LOG_DATA)」の値
        /// </summary>
        private string logdata;

        #region プロパティ

        /// <summary>
        /// 列「PROGRAM_ID」の値を取得または設定する
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
        /// 列「OPERATION_TYPE」の値を取得または設定する
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
        /// 列「LOG_DATETIME」の値を取得または設定する
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
        /// 列「UPDATE_USER_ID」の値を取得または設定する
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
        /// 列「TABLE_NAME」の値を取得または設定する
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
        /// 列「LOG_DATA」の値を取得または設定する
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

        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public DataLogVO()
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 現在のDataLogVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のDataLogVOを表すSystem.String。</returns>
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
        /// VOのコピーを返します。
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
