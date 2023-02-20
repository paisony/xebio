// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.DataLog.Util
{
	/// <summary>
	/// プログラムIDの共通定数やメソッドを定義したクラスです。
	/// </summary>
	public class DataLogUtil
	{
		/// <summary>
		/// プログラムID：利用者情報履歴
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN_USER = "LOGIN_USER";

		/// <summary>
		/// プログラムID：ログイン情報履歴
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN = "LOGIN";

		/// <summary>
		/// プログラムID：ロール情報
		/// </summary>
		public const string DATA_TYPE_OF_ROLE = "ROLE";

		/// <summary>
		/// プログラムID：利用者ロック状態履歴
		/// </summary>
		public const string DATA_TYPE_OF_LOGIN_LOCK = "USER_LOCK";

		/// <summary>
		/// プログラムID：ロール付与履歴
		/// </summary>
		public const string DATA_TYPE_OF_ROLE_USER_MAP = "ROLE_USER_MAP";

		/// <summary>
		/// プログラムID：セキュリティポリシー
		/// </summary>
		public const string DATA_TYPE_OF_SECURITY_POLICY = "SECURITY_POLICY";

		/// <summary>
		/// データベース操作種別：登録
		/// </summary>
		public const string OPERATION_TYPE_OF_INSERT = "0";

		/// <summary>
		/// データベース操作種別：更新
		/// </summary>
		public const string OPERATION_TYPE_OF_UPDATE = "1";

		/// <summary>
		/// データベース操作種別：削除
		/// </summary>
		public const string OPERATION_TYPE_OF_DELETE = "2";

		/// <summary>
		/// ログイン・ログアウト
		/// </summary>
		public const string OPERATION_TYPE_OF_LOGINLOGOUT = "7";

		/// <summary>
		/// プログラムSTART
		/// </summary>
		public const string OPERATION_TYPE_START = "8";

		/// <summary>
		/// プログラムEND
		/// </summary>
		public const string OPERATION_TYPE_END = "9";

	}
}
