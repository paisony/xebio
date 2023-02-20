// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.LoginUser.VO
{
    #region 主キーオブジェクト

    /// <summary>
    /// エンティティBS_COMPANYの主キーを表すクラス
    /// </summary>
    [Serializable]
    public class CompanyKey : IPrimaryKey
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public CompanyKey()
        {
        }

        /// <summary>
        /// すべての列を明示的に初期化します。
        /// </summary>
        /// <param name="company">列「COMPANY_ID」の値</param>
        public CompanyKey(
            string companyId)
        {
            this.companyId = companyId;
  
        }
        #endregion

        #region フィールド
        /// <summary>
        /// 列「COMPANY_ID」の値
        /// </summary>
 
        protected string companyId;
        #endregion

        #region プロパティ
        /// <summary>
        /// 列「COMPANY_ID」の値を取得または設定する
        /// </summary>
        
        public string CompanyId
        {
            get
            {
                return companyId;
            }
            set
            {
                companyId = value;
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
                new KeyValuePair<string, object>("COMPANY_ID", companyId)
			};

        }

        #endregion
    }

    #endregion

    #region エンティティVO

    /// <summary>
    ///  エンティティBS_COMPANYに対応したValueObjectです。
    /// </summary>
    [Serializable]
    public class CompanyVO : CompanyKey, IRecordInfoKey
    {
        /// <summary>
        /// 列「COMPANY_NAME(COMPANY_NAME)」の値
        /// </summary>
        private string companyName;

        /// <summary>
        /// 列「CREATE_DATETIME(CREATE_DATETIME)」の値
        /// </summary>
        private DateTime createDatetime;

        /// <summary>
        /// 列「CREATE_USER_ID(CREATE_USER_ID)」の値
        /// </summary>
        private string createUserId;

        /// <summary>
        /// 列「UPDATE_DATETIME(UPDATE_DATETIME)」の値
        /// </summary>
        private DateTime updateDatetime;

        /// <summary>
        /// 列「UPDATE_USER_ID(UPDATE_USER_ID)」の値
        /// </summary>
        private string updateUserId;

        /// <summary>
        /// 列「DELETE_FLAG(DELETE_FLAG)」の値
        /// </summary>
        private string deleteFlag;




        #region プロパティ

        /// <summary>
        /// 列「COMPANY_NAME」の値を取得または設定する
        /// </summary>
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
            }
        }

        /// <summary>
        /// 列「CREATE_DATETIME」の値を取得または設定する
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
        /// 列「CREATE_USER_ID」の値を取得または設定する
        /// </summary>
        public string CreateUserID
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
        /// 列「UPDATE_DATETIME」の値を取得または設定する
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
        /// 列「UPDATE_USER_ID」の値を取得または設定する
        /// </summary>
        public string UpdateUserID
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
        /// 列「DELETE_FLAG」の値を取得または設定する
        /// </summary>
        public string DeleteFlag
        {
            get
            {
                return deleteFlag;
            }
            set
            {
                deleteFlag = value;
            }
        }


        #endregion

        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します
        /// </summary>
        public CompanyVO()
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 現在のCompanyVOを表すSystem.Stringを返します。
        /// </summary>
        /// <returns>現在のCompanyVOを表すSystem.String。</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

          
            sb.Append("CompanyId:").Append(this.companyId).AppendLine();
            sb.Append("CompanyName:").Append(this.companyName).AppendLine();
            sb.Append("CreateDatetime:").Append(this.createDatetime).AppendLine();
            sb.Append("CreateUserId:").Append(this.createUserId).AppendLine();
            sb.Append("UpdateDatetime:").Append(this.updateDatetime).AppendLine();
            sb.Append("UpdateUserId:").Append(this.updateUserId).AppendLine();
            sb.Append("DeleteFlag:").Append(this.deleteFlag).AppendLine();


            return sb.ToString();
        }

        /// <summary>
        /// VOのコピーを返します。
        /// </summary>
        /// <returns>CompanyVO</returns>
        public CompanyVO Copy()
        {
            CompanyVO vo = new CompanyVO();

            vo.CompanyId = this.CompanyId;
            vo.CompanyName = this.CompanyName;
            vo.CreateDateTime = this.CreateDateTime;
            vo.CreateUserID = this.CreateUserID;
            vo.UpdateDateTime = this.UpdateDateTime;
            vo.UpdateUserID = this.UpdateUserID;
            vo.DeleteFlag = this.DeleteFlag;

            return vo;
        }

        #endregion

    }

    #endregion
}
