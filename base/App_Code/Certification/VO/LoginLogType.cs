// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

namespace Com.Fujitsu.SmartBase.Base.Certification.VO
{
	/// <summary>
	/// ログインログのタイプを表します。
	/// </summary>
	public enum LoginLogType
	{
		/// <summary>
		/// 通常ログイン
		/// </summary>
		Login,
		/// <summary>
		/// 通常ログアウト
		/// </summary>
		Logout,
		/// <summary>
		/// 強制ログイン
		/// </summary>
		CompulsoryLogin,
		/// <summary>
		/// 強制ログアウト
		/// </summary>
		CompulsoryLogout,
		/// <summary>
		/// セションタイムアウト
		/// </summary>
		SessionTimeOut,
		/// <summary>
		/// パスワード入力ミスによるログイン失敗
		/// </summary>
		LoginFailureByInvalidPassword,
		/// <summary>
		/// ユーザロックによるログイン失敗
		/// </summary>
		LoginFailureByUserLock,
		/// <summary>
		/// 運用時間外によるログイン失敗
		/// </summary>
		LoginFailureByOperationTime,
		/// <summary>
		/// 機能の実行
		/// </summary>
		FunctionExcute
	}
}