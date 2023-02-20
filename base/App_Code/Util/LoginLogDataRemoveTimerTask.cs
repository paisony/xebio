// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Library.Log;

/// <summary>
/// 基盤のログイン履歴のデータを削除するタスクを実行するクラスです。
/// </summary>
public class LoginLogDataRemoveTimerTask : TimerTask
{

	#region シングルトン
	/// <summary>
	/// このクラスの唯一のインスタンスです。
	/// </summary>
	public static readonly LoginLogDataRemoveTimerTask Instance = new LoginLogDataRemoveTimerTask();
	#endregion

	/// <summary>
	/// ログインログ削除時間
	/// </summary>
	public static string loginLogDeleteTimeStr = SystemSettings.LoginLogDeleteTime;

	/// <summary>
	/// ログインログを現在から何日以前を削除対象にするか設定
	/// </summary>
	public static string loginLogDeletePeriodStr = SystemSettings.LoginLogDeletePeriod;

	/// <summary>
	/// Logger
	/// </summary>
	private static readonly ILogger log = LogManager.GetLogger();

	#region デフォルトコンストラクタ

	public LoginLogDataRemoveTimerTask()
	{
	}

	#endregion

	#region 設定の読み込み

	/// <summary>
	/// 設定の読み込み
	/// </summary>
	/// <returns>設定読込が成功すればtrue</returns>
	public bool ReadConfig()
	{
		if (string.IsNullOrEmpty(loginLogDeleteTimeStr) || string.IsNullOrEmpty(loginLogDeletePeriodStr))
		{
			log.Warn("BaseのSystemSettings.configにログインログデータを削除する時刻が設定されていないため、定期的に" +
				"データ削除ＡＰＩを実行するためのタイマーを起動しませんでした。");
			return false;
		}

		// 起動時刻の設定
		base._startTime = TimeSpan.Parse(loginLogDeleteTimeStr);

		// 起動間隔は1日
		base._period = new TimeSpan(1, 0, 0, 0);

		return true;
	}

	#endregion

	#region タイマーイベントが発生した時の処理

	/// <summary>
	/// タイマーから呼び出すためのコールバックメソッド
	/// </summary>
	/// <param name="o">null</param>
	protected override void ExecuteTask(object o)
	{
		try
		{
			log.Info("設定時刻になったので、ログインログを削除するＡＰＩを起動します。");
			CertificationService service = new CertificationService();

			service.DeleteLoginLog(loginLogDeletePeriodStr);
		}
		catch (Exception e)
		{
			log.Error(e.ToString());
		}
	}

	#endregion
}
