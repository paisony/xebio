<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    private static bool isInit = false;

    void Application_Start(object sender, EventArgs e)
    {

        //タイムアウトしたセッションをチェックするタイマー
        System.Timers.Timer timer1 = new System.Timers.Timer();
        LoginCertManager loginMgr = new LoginCertManager();
        timer1.Elapsed += new System.Timers.ElapsedEventHandler(loginMgr.CheckInvalidSession);
        timer1.Interval = Com.Fujitsu.SmartBase.Base.Common.Config.SystemSettings.CertCheckTimerDuration * 1000;
        timer1.AutoReset = true;
        timer1.Enabled = true;

        if (Com.Fujitsu.SmartBase.Base.Common.Config.SystemSettings.SynchroMode == Com.Fujitsu.SmartBase.Base.Systems.Util.SystemsConstantUtil.SYNCHRO_ON)
        {
            //Smart SOA連携タイマー
            System.Timers.Timer timer2 = new System.Timers.Timer();
            SynchroBatManager syncMgr = new SynchroBatManager();
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(syncMgr.ExecSynchroBat);
            timer2.Interval = Com.Fujitsu.SmartBase.Base.Common.Config.SystemSettings.SynchroBatDuration * 60000;
            timer2.AutoReset = true;
            timer2.Enabled = true;
        }

        #region タイマー起動処理
        // 基盤のログインログを削除するためのタイマーを起動
        if (LoginLogDataRemoveTimerTask.Instance.ReadConfig())
        {
            LoginLogDataRemoveTimerTask.Instance.StartTimer();
        }
        #endregion

        // メニューキャッシュのクリア
        //Com.Fujitsu.SmartBase.Base.Web.Menu.MenuSetManager menuSetManager = new Com.Fujitsu.SmartBase.Base.Web.Menu.MenuSetManager();
        //menuSetManager.DeleteAllMenuSetCache();

        RegisterRoutes(RouteTable.Routes);

    }

    void Application_End(object sender, EventArgs e)
    {
        //  アプリケーションのシャットダウンで実行するコードです
        //タイマーの停止
        LoginLogDataRemoveTimerTask.Instance.Dispose();
    }

    void Application_Error(Object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        Server.Transfer("~/Common/Error/SystemError.aspx");
    }

    void Session_Start(object sender, EventArgs e)
    {

    }

    void Session_End(object sender, EventArgs e)
    {
        // セッションが終了したときに実行するコードです 
        // メモ: Web.config ファイル内で sessionstate モードが InProc に設定されているときのみ、
        // Session_End イベントが発生します。session モードが StateServer か、または SQLServer に 
        // 設定されている場合、イベントは発生しません。

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        //クライアントにキャッシュさせないための処理
        //		Response.Cache.SetNoStore();     //ダウンロード可能にするためコメント
        Response.Expires = -1;

        /* 2016-08-04 FE)Y.Kawabuchi Delete Start */
        // if (!isInit)
        // {
        // 	/* 2016-07-12 FE)Y.Kawabuchi Add Start ST-022 */
        // 	lock (lockObject)
        // 	{
        // 		if (!isInit) //ロック待ちの間に変更があった場合の対応
        // 		{
        // 	/* 2016-07-12 FE)Y.Kawabuchi Add End ST-022 */
        // 	
        // 			#region 画像のコピー
        // 			string basePath = Request.PhysicalApplicationPath;
        // 			CopyDirectory(basePath + "Common\\DataMaster\\Images\\" + ConfigurationManager.AppSettings[WebConstantUtil.BASE_MENU_FORMAT], basePath + "Common\\Images");
        // 			CopyDirectory(basePath + "Common\\DataMaster\\Style\\" + ConfigurationManager.AppSettings[WebConstantUtil.BASE_MENU_FORMAT], basePath + "Common\\Style");
        // 			isInit = true;
        // 			#endregion
        // 	
        // 	/* 2016-07-12 FE)Y.Kawabuchi Add Start ST-022 */
        // 		}
        // 	}
        // 	/* 2016-07-12 FE)Y.Kawabuchi Add End ST-022 */
        // }
        /* 2016-08-04 FE)Y.Kawabuchi Delete End */
    }

    void Application_OnAcquireRequestState(object sender, EventArgs e)
    {
        // TODO yusy
        ////認証を行なう。
        LoginCertManager.CertBaseLoginInfo();

        ////URL直接入力による不正アクセスの防止
        //LoginCertManager.CheckUrlAccess();
    }

    /// <summary>
    /// ディレクトリをコピーする
    /// </summary>
    /// <param name="sourceDirName">コピーするディレクトリ</param>
    /// <param name="destDirName">コピー先のディレクトリ</param>
    public static void CopyDirectory(string sourceDirName, string destDirName)
    {
        //コピー先のディレクトリがないときは作る
        if (!System.IO.Directory.Exists(destDirName))
        {
            System.IO.Directory.CreateDirectory(destDirName);
        }

        //コピー先のディレクトリ名の末尾に"\"をつける
        if (destDirName[destDirName.Length - 1] !=
                System.IO.Path.DirectorySeparatorChar)
            destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

        //コピー元のディレクトリにあるファイルをコピー
        string[] files = System.IO.Directory.GetFiles(sourceDirName);
        string[] ex = { ".jpg", ".gif", ".ani", ".css" };

        foreach (string file in files)
        {
            #region 所定の拡張子以外は除外
            bool hit = false;

            foreach (string exStr in ex)
            {
                if (file.ToLower().EndsWith(exStr.ToLower()))
                {
                    hit = true;
                    break;
                }
            }

            if (!hit)
            {
                continue;
            }
            #endregion

            string copyTo = destDirName + System.IO.Path.GetFileName(file);
            SetNotReadOnly(copyTo);
            System.IO.File.Copy(file, copyTo, true);
            SetNotReadOnly(copyTo);
        }

        //コピー元のディレクトリにあるディレクトリについて、
        //再帰的に呼び出す
        string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
        foreach (string dir in dirs)
            CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
    }

    private static void SetNotReadOnly(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            System.IO.FileAttributes fas = System.IO.File.GetAttributes(filePath);
            fas = fas & ~System.IO.FileAttributes.ReadOnly;
            System.IO.File.SetAttributes(filePath, fas);
        }
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
    }
</script>

