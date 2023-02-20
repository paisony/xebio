// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Timers;
using System.Diagnostics;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using Com.Fujitsu.SmartBase.Base.Systems.Util;
using Com.Fujitsu.SmartBase.Base.Common.Model;

/// <summary>
/// SynchroBatManager の概要の説明です
/// </summary>
public class SynchroBatManager
{
    private static object lockkey = new object();

    public SynchroBatManager()
    {
    }

    /// <summary>
    /// シンクロバッチを起動する。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ExecSynchroBat(object sender, ElapsedEventArgs e)
    {

        DateTime batDateTime = DateTime.Now;
        int? exitCode = null;
        try
        {
            lock (lockkey)
            {
                using (Process process = Process.Start(InstallInfoUtil.GetInstallPath() + "Base/App/SynchroDataBat/Com.Fujitsu.SmartBase.Base.SynchroDataBat.exe"))
                {
                    process.WaitForExit();
                    exitCode = process.ExitCode;
                }
            }
        }
        catch
        {
            exitCode = 3;
        }

        //結果を格納
        SynchroInformationService service = new SynchroInformationService();
        BatInformationVO vo = new BatInformationVO();
        vo.BatId = SystemsConstantUtil.BAT_ID_SYNCHRO;
        vo.LastBatDatetime = batDateTime;
        vo.LastBatExitCode = exitCode;
        Result res = service.UpdateBatInfo(vo);

        if (!res.IsSuccess)
            throw new ApplicationException("同期バッチの実行情報の登録に失敗しました。");

    }
}
