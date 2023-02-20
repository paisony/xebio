// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Transactions;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Certification.BC;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.Dac;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.BC;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Certification
{
	public class CertificationService : BaseService
	{
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		/// <remarks>
		/// ログイン前の処理に利用する。
		/// 通常はログインユーザ情報を設定するコンストラクタを利用する。
		/// </remarks>
		public CertificationService()
			: base()
		{
		}
		#endregion

		#region ログイン
		/// <summary>
		/// ログイン処理を実行する。
		/// </summary>
		/// <param name="infoVo">ユーザ情報が格納されたVO</param>
		/// <returns>ログイン情報IDを持ったResult</returns>
		public DataResult<string> Login(ExLoginUserInfoVO infoVo, string userLanguage, string requestUrl)
		{
			DataResult<string> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					string infoId = bc.Login(infoVo, userLanguage, requestUrl);
					res = new DataResult<string>(!string.IsNullOrEmpty(infoId), infoId);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<string>)base.HandleException("Login", ex, typeof(DataResult<string>));
			}
		}

		/// <summary>
		/// 強制ログイン処理を実行する。
		/// </summary>
		/// <param name="infoVo">ユーザ情報が格納されたVO</param>
		/// <returns>ログイン情報IDを持ったResult</returns>
		public DataResult<string> CompulsoryLogin(ExLoginUserInfoVO infoVo, string userLanguage, string requestUrl)
		{
			DataResult<string> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					string infoId = bc.CompulsoryLogin(infoVo, userLanguage, requestUrl);
					res = new DataResult<string>(!string.IsNullOrEmpty(infoId), infoId);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<string>)base.HandleException("CompulsoryLogin", ex, typeof(DataResult<string>));
			}
		}
		#endregion

		#region ログアウト
		/// <summary>
		/// ログアウト処理を実行する。
		/// </summary>
		/// <param name="loginInfoId"></param>
		/// <param name="loginLogType">ログインログのタイプ(通常ログアウトか強制ログアウト)</param>
		public void Logout(string loginInfoId, LoginLogType loginLogType, ExLoginUserInfoVO infoVo)
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					bc.Logout(loginInfoId, loginLogType, infoVo);
				}
			}
			catch (Exception ex)
			{
				base.HandleException("Logout", ex);
			}
		}
		#endregion

		#region 認証
		/// <summary>
		/// 認証処理を実行する。
		/// </summary>
		/// <returns>認証IDを持ったResult</returns>
		public DataResult<string> Certify(string loginId, string certId, string solutionId)
		{
			DataResult<string> res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					string newCertId = bc.Certify(loginId, certId, solutionId);
					res = new DataResult<string>(!string.IsNullOrEmpty(newCertId), newCertId);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<string>)base.HandleException("Certify", ex, typeof(DataResult<string>));
			}
		}

		/// <summary>
		/// 認証処理を実行する。
		/// </summary>
		/// <returns>Result</returns>
		public Result CertifyByLoginInfoID(string loginInfoId)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					res = new Result(bc.CertifyByLoginInfoID(loginInfoId));
				}
				return res;
			}
			catch (Exception ex)
			{
				return base.HandleException("CertifyByLoginInfoID", ex);
			}
		}

		/// <summary>
		/// 認証処理を実行する。
		/// </summary>
		/// <param name="loginInfoId">ログイン情報ID</param>
		/// <returns>認証IDを持ったResult</returns>
		public DataResult<string> NewCertID(string loginInfoId, string solutionId)
		{
			DataResult<string> res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					string certId = bc.NewCertID(loginInfoId, solutionId);
					res = new DataResult<string>(!string.IsNullOrEmpty(certId), certId);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<string>)base.HandleException("NewCertID", ex, typeof(DataResult<string>));
			}
		}
		#endregion

		#region タイムアウト
		/// <summary>
		/// タイムアウトチェックし処理を行なう。
		/// </summary>
		public void CheckTimeOut()
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					bc.CheckTimeOut();
				}

			}
			catch (Exception ex)
			{
				base.HandleException("CheckTimeOut", ex);
			}
		}
		#endregion

		#region ログイン情報
		/// <summary>
		/// ログイン情報を取得する
		/// </summary>
		/// <returns>ログイン情報を含んだResult</returns>
		public DataResult<DataTable> GetLoginInfoByCertId(string certId)
		{
			DataResult<DataTable> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginRefDac dac = new LoginRefDac(connection);
					DataTable dt = dac.GetLoginInfoByCertId(cmd, certId);
					res = new DataResult<DataTable>(dt != null, dt);
				}

				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetLoginInfoByCertId", ex, typeof(DataResult<DataTable>));
			}
		}

		/// <summary>
		/// ログイン情報を取得する
		/// </summary>
		/// <returns>ログイン情報を含んだResult</returns>
		public DataResult<DataTable> GetLoginInfoByLoginId(string loginId)
		{
			DataResult<DataTable> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginInfoDac dac = new LoginInfoDac(connection);

					QueryObject query = new QueryObject();
					query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, loginId));
					DataTable dt = dac.Find(cmd, query);
					res = new DataResult<DataTable>(dt != null, dt);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetLoginInfoByLoginId", ex, typeof(DataResult<DataTable>));
			}
		}

		/// <summary>
		/// ログイン情報を取得する
		/// </summary>
		/// <returns>ログイン情報を含んだResult</returns>
		public DataResult<DataTable> GetCertIdByLoginInfo(string loginId)
		{
			DataResult<DataTable> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginRefDac dac = new LoginRefDac(connection);
					DataTable dt = dac.GetCertIdByLoginInfo(cmd, loginId);
					res = new DataResult<DataTable>(dt != null, dt);
				}
				return res;
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetCertIdByLoginInfo", ex, typeof(DataResult<DataTable>));
			}
		}

		/// <summary>
		/// ソリューション情報の更新
		/// </summary>
		/// <param name="infoId">ログイン情報ID</param>
		/// <param name="certID">認証ＩＤID</param>
		/// <param name="solutionId">ソリューションID</param>
		/// <returns>件数</returns>
		public int UpdateCertIDSolutionId(string infoId, string certID, string solutionId)
		{
			int res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC dac = new CertificationBC(connection);
					res = dac.UpdateCertIDSolutionId(infoId, certID, solutionId);
				}
				return res;
			}
			catch (Exception)
			{
				return 0;
			}
		}
		#endregion

		#region Findログイン履歴

		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <param name="queryObj">検索条件が格納されたQueryObject</param>
		/// <returns>一致レコード数</returns>
		public DataResult<DataTable> FindLoginLog(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginLogDac dac = new LoginLogDac(connection);
					dt = dac.Find(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindLoginLog", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region FindCountログイン履歴
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataResult<int> FindCountLoginLog(QueryObject queryObj)
		{
			DataResult<int> res;
			int count;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginLogDac loginlogDac = new LoginLogDac(connection);
					count = loginlogDac.FindCount(cmd, queryObj);
					res = new DataResult<int>(count >= 0, count);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<int>)base.HandleException("FindCountLoginLog", ex, typeof(DataResult<int>));
			}
		}
		#endregion

		#region Findログイン中利用者
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <param name="queryObj">検索条件が格納されたQueryObject</param>
		/// <returns>一致レコード数</returns>
		public DataResult<DataTable> FindUser(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginInfoDac dac = new LoginInfoDac(connection);
					dt = dac.FindUser(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindUser", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region FindCountログイン中利用者
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataResult<int> FindCountUser(QueryObject queryObj)
		{
			DataResult<int> res;
			int count;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginInfoDac LoginInfoDac = new LoginInfoDac(connection);
					count = LoginInfoDac.FindCount(cmd, queryObj);
					res = new DataResult<int>(count >= 0, count);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<int>)base.HandleException("FindCountUser", ex, typeof(DataResult<int>));
			}
		}
		#endregion

		#region Findシステム運用時間
		/// <summary>
		/// Findシステム運用時間
		/// </summary>
		/// <param name="queryObj"></param>
		/// <returns></returns>
		public DataResult<DataTable> FindOperationTime(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					OperationTimeSettingsDac dac = new OperationTimeSettingsDac(connection);
					dt = dac.Find(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindOperationTime", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region Updateシステム運用時間
		/// <summary>
		/// 編集確認後更新ボタンが押されたとき、
		/// 対応する情報を更新します。
		/// </summary>
		public Result UpdateOperationTime(params OperationTimeSettingsVO[] vos)
		{
			Result res;
			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();

					OperationTimeSettingsBC bc = new OperationTimeSettingsBC(connection);
					res = new Result(bc.UpdateOperationTime(vos));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateOperationTime", ex);
			}
		}
		#endregion

		#region ログインログ削除
		/// <summary>
		/// ログイン履歴のデータをデータベースのテーブルから削除します。
		/// </summary>
		/// <returns></returns>
		public Result DeleteLoginLog(string deleteTime)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					res = new Result(bc.DeleteLoginLog(deleteTime));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteLoginLog", ex);
			}
		}
		#endregion

		#region ログインログ追加
		/// <summary>
		/// ログイン履歴のデータをデータベースのテーブルへ追加します。
		/// </summary>
		/// <returns></returns>
		public Result InsertLoginLog2(LoginLogVO vo)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					res = new Result(bc.InsertLoginLog2(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteLoginLog", ex);
			}
		}
		#endregion

		#region クライアントのアクセスログアップロード
		/// <summary>
		/// クライアントのオフライン時のアクセスログをアップロード
		/// </summary>
		/// <param name="vos">オフライン時のアクセスログ</param>
		/// <returns>Result</returns>
		public Result UploadClientAccessLog(LoginLogVO[] vos)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CertificationBC bc = new CertificationBC(connection);
					res = new Result(bc.UploadClientAccessLog(vos));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UploadClientAccessLog", ex);
			}
		}
		#endregion
	}
}
