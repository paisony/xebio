// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;
using Com.Fujitsu.SmartBase.Base.Common.Util;

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	#region 主キーオブジェクト

	/// <summary>
	/// エンティティBS_LOGIN_LOGの主キーを表すクラス
	/// </summary>
	[Serializable]
	public class LoginLogKey : IPrimaryKey
	{
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginLogKey()
		{
		}

		/// <summary>
		/// すべての列を明示的に初期化します。
		/// </summary>
		/// <param name="login_id">列「LOGIN_ID」の値</param>
		/// <param name="login_datetime">列「LOGIN_DATETIME」の値</param>
		/// <param name="logType">LOG_TYPE</param>
		public LoginLogKey(
			string loginId,
			DateTime? loginDatetime,
			LoginLogType logType)
		{
			this.loginId = loginId;
			this.logDatetime = loginDatetime;
			this.logType = logType;
		}
		#endregion

		#region フィールド

		/// <summary>
		/// 列「LOGIN_ID(LOGIN_ID)」の値
		/// </summary>
		protected string loginId;
		/// <summary>
		/// 列「LOG_DATETIME(LOG_DATETIME)」の値
		/// </summary>
		protected DateTime? logDatetime;
		/// <summary>
		/// 列「LOG_TYPE(LOG_TYPE)」の値
		/// </summary>
		protected LoginLogType logType;

		#endregion

		#region プロパティ

		/// <summary>
		/// 列「LOGIN_ID」の値を取得または設定する
		/// </summary>
		public string LoginID
		{
			get
			{
				return loginId;
			}
			set
			{
				loginId = value;
			}
		}

		/// <summary>
		/// 列「LOG_DATETIME」の値を取得または設定する
		/// </summary>
		public DateTime? LogDatetime
		{
			get
			{
				return logDatetime;
			}
			set
			{
				logDatetime = value;
			}
		}

		/// <summary>
		/// 列「LOG_TYPE」の値を取得または設定する
		/// </summary>
		public LoginLogType LogType
		{
			get
			{
				return logType;
			}
			set
			{
				logType = value;
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
				new KeyValuePair<string, object>("LOGIN_ID",loginId),
				new KeyValuePair<string, object>("LOGIN_DATETIME",logDatetime),
                new KeyValuePair<string, object>("LOG_TYPE",logType)
			};
		}

		#endregion
	}

	#endregion

	#region エンティティVO

	/// <summary>
	///  エンティティBS_LOGIN_LOGに対応したValueObjectです。
	/// </summary>
	[Serializable]
	public class LoginLogVO : LoginLogKey
	{
		#region フィールド

		/// <summary>
		/// 列「OFFLINE_FLAG」の値
		/// 既定値：オンライン
		/// </summary>
		private string offlineFlagg = ConstantUtil.ACCESS_ONLINE;

		/// <summary>
		/// 列「IP_ADDRESS(IP_ADDRESS)」の値
		/// </summary>
		private string ipaddress;

		/// <summary>
		/// 列「PC_NAME」の値
		/// </summary>
		private string pcname;

		/// <summary>
		/// 列「SOLUTION_ID」の値
		/// </summary>
		private string solutionid;

		/// <summary>
		/// 列「FUNCTION_ID」の値
		/// </summary>
		private string functionid;

		/// <summary>
		/// 列「FUNCTION_NAME」の値
		/// </summary>
		private string functionname;

		/// <summary>
		/// 列「FUNCTION_URL」の値
		/// </summary>
		private string functionurl;

		#endregion

		#region プロパティ

		/// <summary>
		/// 列「OFFLINE_FLAG」の値を取得または設定する
		/// </summary>
		public string OfflineFlag
		{
			get
			{
				return offlineFlagg;
			}
			set
			{
				offlineFlagg = value;
			}
		}

		/// <summary>
		/// 列「IP_ADDRESS」の値を取得または設定する
		/// </summary>
		public string IPAddress
		{
			get
			{
				return ipaddress;
			}
			set
			{
				ipaddress = value;
			}
		}

		/// <summary>
		/// 列「PC_NAME」の値を取得または設定する
		/// </summary>
		public string PCName
		{
			get
			{
				return pcname;
			}
			set
			{
				pcname = value;
			}
		}

		/// <summary>
		/// 列「SOLUTION_ID」の値を取得または設定する
		/// </summary>
		public string SolutionID
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
		/// 列「FUNCTION_ID」の値を取得または設定する
		/// </summary>
		public string FunctionID
		{
			get
			{
				return functionid;
			}
			set
			{
				functionid = value;
			}
		}

		/// <summary>
		/// 列「FUNCTION_NAME」の値を取得または設定する
		/// </summary>
		public string FunctionName
		{
			get
			{
				return functionname;
			}
			set
			{
				functionname = value;
			}
		}

		/// <summary>
		/// 列「FUNCTION_URL」の値を取得または設定する
		/// </summary>
		public string FunctionUrl
		{
			get
			{
				return functionurl;
			}
			set
			{
				functionurl = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public LoginLogVO()
		{
		}

		#endregion

		#region メソッド
		/// <summary>
		/// 現在のLoginLogVOを表すSystem.Stringを返します。
		/// </summary>
		/// <returns>現在のLoginLogVOを表すSystem.String。</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("login_id:").Append(this.loginId).AppendLine();
			sb.Append("Log_datetime:").Append(this.logDatetime).AppendLine();
			sb.Append("Log_type:").Append(this.logType.ToString()).AppendLine();
			sb.Append("Offline_flag:").Append(this.offlineFlagg.ToString()).AppendLine();
			sb.Append("IP_address:").Append(this.ipaddress.ToString()).AppendLine();
			sb.Append("PC_name:").Append(this.pcname.ToString()).AppendLine();
			sb.Append("Solution_ID:").Append(this.solutionid.ToString()).AppendLine();
			sb.Append("Function_ID:").Append(this.functionid.ToString()).AppendLine();
			sb.Append("Function_Name:").Append(this.functionname.ToString()).AppendLine();
			sb.Append("Function_Url:").Append(this.functionurl.ToString()).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VOのコピーを返します。
		/// </summary>
		/// <returns>LoginLogVO</returns>
		public LoginLogVO Copy()
		{
			LoginLogVO vo = new LoginLogVO();
			vo.LoginID = this.LoginID;
			vo.LogDatetime = this.LogDatetime;
			vo.LogType = this.LogType;
			vo.OfflineFlag = this.OfflineFlag;
			vo.IPAddress = this.IPAddress;
			vo.PCName = this.PCName;
			vo.SolutionID = this.SolutionID;
			vo.FunctionID = this.FunctionID;
			vo.FunctionName = this.FunctionName;
			vo.FunctionUrl = this.FunctionUrl;

			return vo;
		}

		#endregion

	}

	#endregion
}

