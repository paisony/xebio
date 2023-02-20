// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.Systems.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Net;
using System.Net.Sockets;
using Com.Fujitsu.SmartBase.Library.Log;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Certification.BC
{
    public class CertificationBC : BaseBC
    {
        /// <summary>
        /// ログ出力
        /// </summary>
        private static ILogger logger = LogManager.GetLogger();

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CertificationBC(OracleConnection connection)
            : base(connection)
        {
        }
        #endregion

        #region ログイン
        /// <summary>
        /// ログイン処理を実行する。
        /// </summary>
        /// <returns>成功したらLoginInfoID</returns>
        public string Login(ExLoginUserInfoVO infoVo, string userLanguage, string requestUrl)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginRefDac refDac = new LoginRefDac(connection);
            LoginInfoVO infoVO = new LoginInfoVO();

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {

                //LoginInfoテーブルを検索。既にログインユーザがいないか？
                QueryObject query = new QueryObject();
                query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, infoVo.LoginId));

                if (SystemSettings.MutexLogin)
                {
                    //多重ログイン禁止
                    //既にログインされているかチェック
                    int count = infoDac.Count(cmd, query);
                    if (count > 0)
                    {
                        //既にログインされている。
                        BusinessError error = new BusinessError("既にこのユーザはログインされています。(" + infoVo.LoginId + ")", CertificationErrorCode.DUPLICATION_LOGIN_ERROR);
                        throw new BusinessException(error);
                    }
                }

                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;
                try
                {
                    //LoginLog登録
                    this.InsertLoginLog(cmd, LoginLogType.Login, infoVo, requestUrl);
                }
                catch (Exception)
                {
                }
                //LoginInfoテーブルに登録
                Guid infoGuId = Guid.NewGuid();
                infoVO.LoginInfoId = infoGuId.ToString();
                DataTable dt = refDac.SelectCOMPANY(cmd, infoVo.LoginId);
                infoVO.CompanyID = Convert.ToString(dt.Rows[0]["COMPANY_ID"]);
                infoVO.LoginID = infoVo.LoginId;
                infoVO.UserLanguage = userLanguage;
                infoVO.MenuPtnCd = Convert.ToString(dt.Rows[0]["MENU_PTN_CD"]);
                infoVO.LoginDatetime = DateTime.Now;
                infoVO.AccessDatetime = DateTime.Now;
                infoDac.Insert(cmd, infoVO);

            }
            catch (DbException)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return infoVO.LoginInfoId;
        }

        /// <summary>
        /// 強制ログイン処理を実行する。
        /// </summary>
        /// <returns>成功したらLoginInfoID</returns>
        public string CompulsoryLogin(ExLoginUserInfoVO infoVo, string userLanguage, string requestUrl)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginRefDac refDac = new LoginRefDac(connection);
            LoginInfoVO infoVO = new LoginInfoVO();

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;

                //LoginInfoテーブルを検索。いなかったら通常ログイン、いたら以下の処理を続行
                QueryObject query = new QueryObject();
                query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, infoVo.LoginId));
                DataTable dt = infoDac.Find(cmd, query);

                if (dt.Rows.Count == 0)
                {
                    //通常ログイン
                    //LoginInfoテーブルに登録
                    Guid infoGuId = Guid.NewGuid();
                    infoVO.LoginInfoId = infoGuId.ToString();
                    DataTable dt1 = refDac.SelectCOMPANY(cmd, infoVo.LoginId);
                    infoVO.CompanyID = Convert.ToString(dt1.Rows[0]["COMPANY_ID"]);
                    infoVO.LoginID = infoVo.LoginId;
                    infoVO.UserLanguage = userLanguage;
                    infoVO.MenuPtnCd = Convert.ToString(dt1.Rows[0]["MENU_PTN_CD"]);
                    infoVO.LoginDatetime = DateTime.Now;
                    infoVO.AccessDatetime = DateTime.Now;
                    infoDac.Insert(cmd, infoVO);
                    //LoginLog登録
                    this.InsertLoginLog(cmd, LoginLogType.Login, infoVo, requestUrl);
                }
                else
                {
                    //同一ユーザのLoginCertテーブルを削除
                    string oldLoginInfoId = Convert.ToString(dt.Rows[0]["LOGIN_INFO_ID"]);
                    certDac.DeleteByLoginInfoID(cmd, oldLoginInfoId);

                    //同一ユーザのLoginInfoテーブル削除
                    LoginInfoKey infoKey = new LoginInfoKey();
                    infoKey.LoginInfoId = oldLoginInfoId;
                    infoDac.Delete(cmd, infoKey);
                    //強制ログアウト時刻
                    DateTime compLogoutDT = DateTime.Now;

                    //新たにLoginInfoテーブルにログイン情報登録
                    Guid infoGuId = Guid.NewGuid();
                    infoVO.LoginInfoId = infoGuId.ToString();
                    DataTable dt1 = refDac.SelectCOMPANY(cmd, infoVo.LoginId);
                    infoVO.CompanyID = Convert.ToString(dt1.Rows[0]["COMPANY_ID"]);
                    infoVO.LoginID = infoVo.LoginId;
                    infoVO.UserLanguage = userLanguage;
                    infoVO.MenuPtnCd = Convert.ToString(dt1.Rows[0]["MENU_PTN_CD"]);
                    infoVO.LoginDatetime = DateTime.Now;
                    infoVO.AccessDatetime = DateTime.Now;
                    infoDac.Insert(cmd, infoVO);
                    //強制ログイン時刻
                    DateTime compLoginDT = DateTime.Now;

                    //LoginLogログインログ登録
                    this.InsertCompulsoryLoginLog(cmd, compLogoutDT, compLoginDT, infoVo, requestUrl);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return infoVO.LoginInfoId;
        }

        /// <summary>
        /// ログイン時のログインログを挿入する
        /// </summary>
        /// <remarks>
        /// ログインログ，データログを挿入します。
        /// </remarks>
        /// <param name="logType">ログインログのタイプ</param>
        /// <param name="infoVo">ログイン者情報(必須:ログインID,IPアドレス,PC名)</param>
        /// <exception cref="ArgumentException">引数が不正</exception>
        /// <returns>ログの出力に成功した場合</returns>
        public bool InsertLoginLog(OracleCommand cmd, LoginLogType logType, ExLoginUserInfoVO infoVo, string requestUrl)
        {
            if (string.IsNullOrEmpty(infoVo.LoginId)
                || string.IsNullOrEmpty(infoVo.IPAddress)
                || string.IsNullOrEmpty(infoVo.PCName))
            {
                throw new ArgumentException("CertificationBC.InsertLoginLog:ログイン者情報が入力されていません。");
            }

            LoginLogDac loginLogDac = new LoginLogDac(connection);
            DataLogDac dataLogDac = new DataLogDac(connection);

            LoginLogVO vo = new LoginLogVO();
            //ログイン者ID
            vo.LoginID = infoVo.LoginId;
            //ログインログ登録
            vo.LogDatetime = DateTime.Now;
            //ログインログのタイプ
            vo.LogType = logType;
            vo.IPAddress = infoVo.IPAddress;
            vo.PCName = infoVo.PCName;
            vo.FunctionUrl = requestUrl;
            loginLogDac.Insert(cmd, vo);

            //データログ登録
            //BS_DATA_LOGに記録
            DataTable loginLogDT = loginLogDac.Select(cmd, vo);
            loginLogDT.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;
            DataLogVO dataLogVO = new DataLogVO();

            dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
            dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN;
            dataLogVO.Tablename = "";
            dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_LOGINLOGOUT;
            dataLogVO.Updateuserid = infoVo.LoginId;
            dataLogVO.LogData = XmlUtility.ConvertXML(loginLogDT);
            dataLogDac.Insert(cmd, dataLogVO);

            return true;
        }

        /// <summary>
        /// 強制ログイン時のログインログを挿入する
        /// </summary>
        /// <remarks>
        /// 強制ログイン時のログインログ，データログを挿入します。
        /// 強制ログインが発生すると以前のログイン情報を削除するため、
        /// 強制ログインの前に強制ログアウトが行われます。
        /// </remarks>
        /// <param name="logoutDT">強制ログアウト日時</param>
        /// <param name="loginDT">強制ログイン日時</param>
        /// <param name="infoVo">ログイン者情報(必須:ログインID,IPアドレス,PC名)</param>
        /// <exception cref="ArgumentException">引数が不正</exception>
        /// <returns>ログの出力に成功した場合</returns>
        private bool InsertCompulsoryLoginLog(OracleCommand cmd, DateTime logoutDT, DateTime loginDT, ExLoginUserInfoVO infoVo, string requestUrl)
        {
            if (string.IsNullOrEmpty(infoVo.LoginId)
                || string.IsNullOrEmpty(infoVo.IPAddress)
                || string.IsNullOrEmpty(infoVo.PCName))
            {
                throw new ArgumentException("CertificationBC.InsertCompulsoryLoginLog:ログイン者情報が入力されていません。");
            }

            LoginLogDac loginLogDac = new LoginLogDac(connection);
            DataLogDac dataLogDac = new DataLogDac(connection);

            //強制ログアウト
            LoginLogVO logoutVO = new LoginLogVO();
            //ログイン者ID
            logoutVO.LoginID = infoVo.LoginId;
            //ログインログ登録
            logoutVO.LogDatetime = logoutDT;
            //ログインログのタイプ
            logoutVO.LogType = LoginLogType.CompulsoryLogout;
            logoutVO.IPAddress = infoVo.IPAddress;
            logoutVO.PCName = infoVo.PCName;
            //loginLogDac.Insert(cmd, logoutVO);


            //強制ログイン
            LoginLogVO loginVO = new LoginLogVO();
            //ログイン者ID
            loginVO.LoginID = infoVo.LoginId;
            //ログインログ登録
            loginVO.LogDatetime = loginDT;
            //ログインログのタイプ
            loginVO.LogType = LoginLogType.CompulsoryLogin;
            loginVO.IPAddress = infoVo.IPAddress;
            loginVO.PCName = infoVo.PCName;
            loginVO.FunctionUrl = requestUrl;
            loginLogDac.Insert(cmd, loginVO);

            //ログインログ ログアウト情報
            DataTable logoutTable = loginLogDac.Select(cmd, logoutVO);
            //ログインログ ログイン情報
            DataTable loginTable = loginLogDac.Select(cmd, loginVO);
            //ログイン情報をログアウト情報テーブルに追加
            logoutTable.ImportRow(loginTable.Rows[0]);
            logoutTable.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;

            DataLogVO dataLogVO = new DataLogVO();
            dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
            dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN;
            dataLogVO.Tablename = "";
            dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_LOGINLOGOUT;
            dataLogVO.Updateuserid = infoVo.LoginId;
            dataLogVO.LogData = XmlUtility.ConvertXML(logoutTable);
            dataLogDac.Insert(cmd, dataLogVO);

            return true;
        }
        #endregion

        #region ログアウト
        /// <summary>
        /// ログアウト処理を実行する。
        /// </summary>
        /// <param name="loginInfoId"></param>
        /// <param name="loginLogType">ログインログのタイプ(通常ログアウトか強制ログアウト)</param>
        /// <param name="infoVo">ログイン者のアクセス元情報が格納されているVO(必須:IPアドレス，PC名)</param>
        public void Logout(string loginInfoId, LoginLogType loginLogType, ExLoginUserInfoVO infoVo)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginLogDac logDac = new LoginLogDac(connection);
            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;

                //LoginCertテーブルを削除
                certDac.DeleteByLoginInfoID(cmd, loginInfoId);
                LoginInfoKey infoKey = new LoginInfoKey(loginInfoId);
                DataTable dt = infoDac.Select(cmd, infoKey);
                if (dt.Rows.Count != 0)
                {
                    string loginId = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);
                    //LoginInfoテーブルを削除
                    infoDac.Delete(cmd, new LoginInfoKey(loginInfoId));

                    //LoginLog登録
                    infoVo.LoginId = loginId;
                    this.InsertLoginLog(cmd, loginLogType, infoVo, null);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

        }
        #endregion

        #region 認証

        /// <summary>
        /// 認証処理を実行する。（基盤用）
        /// </summary>
        /// <returns>bool</returns>
        public bool CertifyByLoginInfoID(string loginInfoId)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
                cmd.Transaction = transaction;

                LoginInfoKey infoKey = new LoginInfoKey();
                infoKey.LoginInfoId = loginInfoId;
                //アクセス日時を更新
                int count = infoDac.UpdateAccessDateTime(cmd, infoKey);
                if (count == 0)
                {
                    //認証失敗
                    BusinessError error = new BusinessError("認証（基盤）に失敗しました。(" + loginInfoId + ")", CertificationErrorCode.BASE_CERT_ERROR);
                    throw new BusinessException(error);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return true;
        }

        /// <summary>
        /// 認証処理を実行する。（連携ソリューション用）
        /// 認証部品で使用。
        /// </summary>
        /// <returns>新しい認証ID</returns>
        public string Certify(string loginId, string certId, string solutionId)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginCertVO certVO = new LoginCertVO();

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
                cmd.Transaction = transaction;

                //LoginCertテーブルを検索。あれば成功で以下の処理を続行、なければエラー
                LoginCertKey key = new LoginCertKey();
                key.LoginCertID = certId;
                DataTable dt = certDac.Select(cmd, key);

                if (dt.Rows.Count == 0)
                {
                    //認証失敗
                    BusinessError error = new BusinessError("認証に失敗しました。(LOGINID:" + loginId + " SOLUTION:" + solutionId + ")", CertificationErrorCode.SOLUTION_CERT_ERROR);
                    throw new BusinessException(error);
                }
                else
                {
                    string infoId = Convert.ToString(dt.Rows[0]["LOGIN_INFO_ID"]);
                    LoginInfoKey infoKey = new LoginInfoKey();
                    infoKey.LoginInfoId = infoId;
                    //LoginInfoから情報を取得
                    DataTable infoDt = infoDac.Select(cmd, infoKey);
                    if (infoDt.Rows.Count == 0)
                    {
                        //認証失敗
                        BusinessError error = new BusinessError("認証に失敗しました。(LOGINID:" + loginId + " SOLUTION:" + solutionId + ")", CertificationErrorCode.SOLUTION_CERT_ERROR);
                        throw new BusinessException(error);
                    }
                    //LoginInfoテーブルのアクセス日時を更新
                    infoDac.UpdateAccessDateTime(cmd, infoKey);
                    //LoginCertのレコード削除
                    certDac.Delete(cmd, key);
                    //新レコード挿入
                    Guid certGuId = Guid.NewGuid();
                    certVO.LoginCertID = certGuId.ToString();
                    certVO.LoginInfoID = infoId;
                    certVO.SolutionID = solutionId;
                    certDac.Insert(cmd, certVO);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return certVO.LoginCertID;
        }

        /// <summary>
        /// 新しい認証IDを発行する。
        /// </summary>
        /// <param name="loginInfoId">ログイン情報ID</param>
        /// <returns>新しい認証ID</returns>
        public string NewCertID(string infoId, string solutionId)
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginCertVO certVO = new LoginCertVO();

            LoginInfoKey key = new LoginInfoKey();
            key.LoginInfoId = infoId;

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
                cmd.Transaction = transaction;

                //LoginInfoテーブルのアクセス日時を更新
                infoDac.UpdateAccessDateTime(cmd, key);
                //LoginCertテーブルにレコード追加。
                Guid certGuId = Guid.NewGuid();
                certVO.LoginCertID = certGuId.ToString();
                certVO.LoginInfoID = infoId;
                if (solutionId != null)
                {
                    certVO.SolutionID = solutionId;
                }
                else
                {
                    certVO.SolutionID = ConstantUtil.BASE_SOLUTION_ID;
                }
                certDac.Insert(cmd, certVO);
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return certVO.LoginCertID;
        }

        /// <summary>
        /// CertIDのSolutionIdを更新行する。
        /// </summary>
        /// <param name="infoId">ログイン情報ID</param>
        /// <param name="certID">認証ＩＤID</param>
        /// <param name="solutionId">ソリューションID</param>
        /// <returns>件数</returns>
        public int UpdateCertIDSolutionId(string infoId, string certID, string solutionId)
        {
            int res = 0;
            LoginCertDac certDac = new LoginCertDac(connection);

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;

            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;
                LoginCertVO certVO = new LoginCertVO();
                certVO.LoginCertID = certID;
                certVO.LoginInfoID = infoId;
                if (solutionId != null)
                {
                    certVO.SolutionID = solutionId;
                }
                else
                {
                    certVO.SolutionID = ConstantUtil.BASE_SOLUTION_ID;
                }
                res = certDac.Update(cmd, certVO);
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return res;
        }

        #endregion

        #region タイムアウト
        /// <summary>
        /// タイムアウト処理を行なう。
        /// </summary>
        /// <remarks>
        /// タイマー等で定期的に実施する。
        /// ログインログには以下の項目がセットされる
        /// ・ログインID:LoginInfoテーブルに記録されているログインID
        /// </remarks>
        public void CheckTimeOut()
        {
            LoginInfoDac infoDac = new LoginInfoDac(connection);
            LoginCertDac certDac = new LoginCertDac(connection);
            LoginLogDac logDac = new LoginLogDac(connection);

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;

                int min = SystemSettings.CertValidDuration;
                DateTime timeoutDateTime = DateTime.Now.AddMinutes(-min);

                //タイムアウトしたログイン情報を検索
                QueryObject query = new QueryObject();
                query.AddFinder(Criteria.LessThan("ACCESS_DATETIME", null, null, timeoutDateTime));
                DataTable dt = infoDac.Find(cmd, query);

                foreach (DataRow row in dt.Rows)
                {
                    string infoId = Convert.ToString(row["LOGIN_INFO_ID"]);
                    string loginId = Convert.ToString(row["LOGIN_ID"]);

                    //LoginCertテーブル削除
                    certDac.DeleteByLoginInfoID(cmd, infoId);

                    //LoginInfoテーブル削除
                    LoginInfoKey infoKey = new LoginInfoKey();
                    infoKey.LoginInfoId = infoId;
                    infoDac.Delete(cmd, infoKey);

                    //LoginLog登録
                    //アプリサーバのIP，PC名が格納されたVOを取得
                    ExLoginUserInfoVO infoVo = this.GetServerInfoVO();
                    infoVo.LoginId = loginId;

                    //セッションエラーは発生しないのでコメントにする
                    //this.InsertLoginLog(cmd, LoginLogType.SessionTimeOut, infoVo, null);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                //logger.Error("Error Message:" + ex.Message);
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }
        }
        #endregion

        #region privateメソッド
        /// <summary>
        /// アプリサーバのIPアドレスとPC名が格納されたユーザ情報voを取得します。
        /// </summary>
        /// <exception cref="SocketException">名前解決に失敗</exception>
        /// <returns>アプリサーバのIPアドレスとPC名が格納されたExLoginUserInfoVO</returns>
        public ExLoginUserInfoVO GetServerInfoVO()
        {
            ExLoginUserInfoVO vo = new ExLoginUserInfoVO();

            vo.IPAddress = ConstantUtil.LOCAL_IP_ADDRESS;
            vo.PCName = ConstantUtil.LOCAL_HOST;

            return vo;
        }
        #endregion

        #region ログイン履歴の削除
        /// <summary>
        /// ログイン履歴情報をデータベースから削除します。
        /// </summary>
        /// <param name="deleteTime"></param>
        /// <returns></returns>
        public bool DeleteLoginLog(string deletePeriod)
        {
            LoginLogDac loginLogDac = new LoginLogDac(connection);
            DateTime now = DateTime.Now;
            DateTime period = now.AddDays(-Convert.ToDouble(deletePeriod));

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;

                cmd.Transaction = transaction;

                loginLogDac.DeleteByTime(cmd, Convert.ToString(period));
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return true;
        }
        #endregion

        #region ログイン履歴の追加
        /// <summary>
        /// ログイン履歴情報をデータベースへ追加します。
        /// </summary>
        /// <param name="vo">データが詰まったLoginLogVO</param>
        /// <returns></returns>
        public bool InsertLoginLog2(LoginLogVO vo)
        {
            LoginLogDac loginLogDac = new LoginLogDac(connection);

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
                cmd.Transaction = transaction;

                loginLogDac.Insert2(cmd, vo);
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return true;
        }
        #endregion

        #region クライアントのアクセスログアップロード
        /// <summary>
        /// クライアントのオフライン時のアクセスログをアップロード
        /// </summary>
        /// <param name="vos">オフライン時のアクセスログ</param>
        /// <returns>成功時にtrue</returns>
        public bool UploadClientAccessLog(LoginLogVO[] vos)
        {
            LoginLogDac loginLogDac = new LoginLogDac(connection);
            DataLogDac dataLogDac = new DataLogDac(connection);

            OracleCommand cmd = connection.CreateCommand() as OracleCommand;
            try
            {
                OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
                cmd.Transaction = transaction;

                foreach (LoginLogVO vo in vos)
                {
                    if (vo.OfflineFlag != ConstantUtil.ACCESS_OFFLINE)
                    {
                        throw new ArgumentException("オフラインフラグ：1のアクセスログしかアップロードできません。");
                    }

                    loginLogDac.Insert(cmd, vo);

                    //データログ登録
                    //BS_DATA_LOGに記録
                    DataTable loginLogDT = loginLogDac.Select(cmd, vo);
                    loginLogDT.TableName = ConstantUtil.TABLE_NAME_BS_LOGIN_LOG;
                    DataLogVO dataLogVO = new DataLogVO();

                    dataLogVO.Solutionid = ConstantUtil.BASE_SOLUTION_ID;
                    dataLogVO.Programid = DataLogUtil.DATA_TYPE_OF_LOGIN;
                    dataLogVO.Tablename = "";
                    dataLogVO.Operationtype = DataLogUtil.OPERATION_TYPE_OF_LOGINLOGOUT;
                    dataLogVO.Updateuserid = vo.LoginID;
                    dataLogVO.LogData = XmlUtility.ConvertXML(loginLogDT);
                    dataLogDac.Insert(cmd, dataLogVO);
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            if (cmd.Transaction != null)
            {
                cmd.Transaction.Commit();
            }

            return true;
        }

        #endregion

    }
}
