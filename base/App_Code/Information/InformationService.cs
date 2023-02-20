// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Transactions;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Information.BC;
using Com.Fujitsu.SmartBase.Base.Information.Dac;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.Information
{
	/// <summary>
	/// お知らせ情報の新規登録、編集、削除等の処理を管理するクラスです。
	/// </summary>
	public class InformationService : BaseService
	{
		#region コンストラクタ
		public InformationService()
			: base()
		{

		}

		public InformationService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{

		}
		#endregion

		#region トップ画面情報
		#region GetAllTopDisplay
		/// <summary>
		/// 全てのトップ画面情報を取得します。
		/// </summary>
		/// <returns>結果(IsSuccess true:成功 false:失敗)。成功した場合はResultDataプロパティに取得データが格納される。</returns>
		public DataResult<DataTable> GetAllTopDisplay(bool dsp, string loginId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopDisplayDac dac = new TopDisplayDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					if (res.ResultData.Rows.Count == 0 && !dsp)
					{
						LoginUserInfoVO loginUserInfo = new LoginUserInfoVO();
						loginUserInfo.LoginId = loginId;
						TopDisplayDac dac2 = new TopDisplayDac(loginUserInfo, connection);
						TopDisplayVO vo2 = new TopDisplayVO();
						vo2.DisplayId = "1";
						vo2.DisplayContent = "";
						vo2.CreateDateTime = DateTime.Now;
						vo2.CreateUserId = "";
						vo2.UpdateUserId = "";
						int count2 = dac2.Insert(cmd, vo2);
						if (count2 > 0)
						{
							//再読込み
							dt = dac.SelectAll(cmd);
							res = new DataResult<DataTable>(dt != null, dt);
						}
					}
					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopDisplay", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region UpdateTopDisplay
		/// <summary>
		/// トップ画面情報を更新します。
		/// </summary>
		/// <param name="vo">更新情報がセットされたVO</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)</returns>
		public Result UpdateTopDisplay(TopDisplayVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopDisplayBC bc = new TopDisplayBC(loginUserInfo, connection);
					res = new Result(bc.UpdateTopDisplayData(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateTopDisplay", ex);
			}
		}
		#endregion
		#endregion

		#region 見出し
		#region GetTopTopic
		/// <summary>
		/// 見出し情報を1件取得します。
		/// </summary>
		/// <param name="key">主キー</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)。
		/// 成功した場合はResultDataプロパティに取得データが格納される。</returns>
		public DataResult<DataTable> GetTopTopic(TopTopicKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopTopicDac dac = new TopTopicDac(connection);
					dt = dac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetTopTopic", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllTopTopic
		/// <summary>
		/// 見出し情報を全件取得します。
		/// </summary>
		/// <param name="checkDisplayFlag">表示フラグ
		/// true:DISPLAY_FLAGが1のレコードを全件取得 
		/// false:DISPLAY_FLAGの値に関わらず全件取得(完全な全件取得)</param>
		/// <returns>取得結果が格納されたDataTable</returns>
		/// <returns>結果(IsSuccess true:成功 false:失敗)。
		/// 成功した場合はResultDataプロパティに取得データが格納される。</returns>
		public DataResult<DataTable> GetAllTopTopic(bool checkDisplayFlag)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopTopicDac dac = new TopTopicDac(connection);
					dt = dac.SelectAll(cmd, checkDisplayFlag);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopTopic", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertOrUpdateTopTopic
		/// <summary>
		/// 見出しを追加または更新します。
		/// </summary>
		/// <param name="vo">追加／更新情報がセットされたVO</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)</returns>
		public Result InsertOrUpdateTopTopic(TopTopicVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopTopicBC bc = new TopTopicBC(loginUserInfo, connection);
					res = new Result(bc.InsertOrUpdateTopTopic(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateTopDisplay", ex);
			}
		}
		#endregion

		#region DeleteTopTopic
		/// <summary>
		/// 見出しを削除します。
		/// </summary>
		/// <param name="vo">削除情報がセットされたVO。主キー，TOPIC_ID,ROWUPDATEIDを必ずセットしてください。</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)</returns>
		public Result DeleteTopTopic(TopTopicVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopTopicBC bc = new TopTopicBC(loginUserInfo, connection);
					res = new Result(bc.DeleteTopTopic(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteTopTopic", ex);
			}
		}
		#endregion
		#endregion

		#region メッセージ
		#region FindTopMessage
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <param name="queryObj">検索条件が格納されたQueryObject</param>
		/// <returns>一致レコード数</returns>
		public DataResult<DataTable> FindTopMessage(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					// TODO yusy del DbCommand ⇒ OracleCommand
					//DbCommand cmd = connection.CreateCommand();
					// TODO yusy add DbCommand ⇒ OracleCommand
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.Find(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region FindCountTopMessage
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <param name="queryObj">検索条件が格納されたQueryObject</param>
		/// <returns>一致レコード数</returns>
		public DataResult<int> FindCountTopMessage(QueryObject queryObj)
		{
			DataResult<int> res;
			int count;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					count = dac.FindCount(cmd, queryObj);
					res = new DataResult<int>(count >= 0, count);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<int>)base.HandleException("FindCountTopMessage", ex, typeof(DataResult<int>));
			}
		}
		#endregion

		#region GetTopMessage
		/// <summary>
		/// メッセージ情報を1件取得します。
		/// </summary>
		/// <param name="key">主キー</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)。
		/// 成功した場合はResultDataプロパティに取得データが格納される。</returns>
		public DataResult<DataTable> GetTopMessage(TopMessageKey key)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.Select(cmd, key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region GetAllTopMessage
		/// <summary>
		/// メッセージ情報を全件取得します。
		/// </summary>
		/// <returns>結果(IsSuccess true:成功 false:失敗)。
		/// 成功した場合はResultDataプロパティに取得データが格納される。</returns>
		public DataResult<DataTable> GetAllTopMessage()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					TopMessageDac dac = new TopMessageDac(connection);
					dt = dac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);
					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllTopMessage", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertOrUpdateTopMessage
		/// <summary>
		/// メッセージを追加または更新します。
		/// </summary>
		/// <param name="vo">追加／更新情報がセットされたVO</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)</returns>
		public Result InsertOrUpdateTopMessage(TopMessageVO vo)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopMessageBC bc = new TopMessageBC(loginUserInfo, connection);
					res = new Result(bc.InsertOrUpdateTopMessage(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertOrUpdateTopMessage", ex);
			}
		}
		#endregion

		#region DeleteTopMessage
		/// <summary>
		/// メッセージを削除します。
		/// </summary>
		/// <param name="key">主キー</param>
		/// <param name="rowUpdateId">排他チェックID</param>
		/// <returns>結果(IsSuccess true:成功 false:失敗)</returns>
		public Result DeleteTopMessage(TopMessageKey key, string rowUpdateId)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					TopMessageBC bc = new TopMessageBC(loginUserInfo, connection);
					res = new Result(bc.DeleteTopMessage(key, rowUpdateId));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteTopMessage", ex);
			}
		}
		#endregion
		#endregion
	}
}
