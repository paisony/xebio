// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.DataLog.BC
{
	public class DataLogBC : BaseBC
	{
		#region コンストラクタ

		/// <summary>
		/// ログインユーザ情報とコネクションを設定するコンストラクタ
		/// </summary>
		/// <param name="loginUserInfo">ログインユーザ情報</param>
		/// <param name="connection">コネクション</param>
		/// <exception cref="ArgumentException">ログインユーザ情報引数が不正</exception>
		public DataLogBC(LoginUserInfoVO loginUserInfo, OracleConnection connection)
			: base(loginUserInfo, connection)
		{
		}

		#endregion

		#region 登録

		/// <summary>
		/// データログをテーブルに登録します
		/// </summary>
		/// <param name="dataLogVO">データログVO</param>
		/// <returns></returns>
		public bool InsertDataLog(DataLogVO dataLogVO)
		{
			// Dacごとにインスタンスを生成します。
			DataLogDac dataLogDac = new DataLogDac(connection);
			DataSet ds = new DataSet();

			OracleCommand cmd = connection.CreateCommand() as OracleCommand;
			try
			{
				OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
				cmd.Transaction = transaction;

				dataLogVO.Updateuserid = loginUserInfo.LoginId;
				dataLogVO.Logdatetime = DateTime.Now;

				// データ種別で挿入するデータを区別する
				if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN_USER)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_ROLE)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_ROLE_USER_MAP)
				{
				}
				else if (dataLogVO.Programid == DataLogUtil.DATA_TYPE_OF_LOGIN_LOCK)
				{
				}
				else
				{
				}

				dataLogDac.Insert(cmd, dataLogVO);
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


		#region 期間指定取得
		/// <summary>
		/// 指定した期間、テーブルのデータログをSELECTします。
		/// </summary>
		/// <param name="key">Tablenameが格納されたオブジェクト</param>
		/// <param name="startDateTime">取得対象の開始日時</param>
		///  <param name="endDateTime">取得対象の終了日時</param>
		/// <returns>データテーブルに格納したレコードデータ</returns>
		public DataTable SelectByLogDateTime(OracleCommand cmd, DataLogVO dataLogVO, DateTime? startDateTime, DateTime endDateTime)
		{
			// Dacごとにインスタンスを生成します。
			DataLogDac dataLogDac = new DataLogDac(connection);
			DataTable tbl = new DataTable();

			tbl = dataLogDac.SelectByLogDateTime(cmd, dataLogVO, startDateTime, endDateTime);

			return tbl;
		}

		#endregion
	}
}
