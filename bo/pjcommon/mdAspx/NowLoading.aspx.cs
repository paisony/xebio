using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Common.Standard.Batch;
using System.Text;
using Common.Standard.Model.Entity.VO;
using Common.Standard.Util;
using Common.Standard.Form;
using Common.Standard.Batch.Constant;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using System.Collections.Generic;

public partial class pjcommon_mdAspx_NowLoading : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String jobId = Request.QueryString.GetValues(BatchManager.JOBID_KEY)[0];

        String pgid = Request.QueryString.GetValues(BatchManager.PGID_KEY)[0];
        String formid = Request.QueryString.GetValues(BatchManager.FORMID_KEY)[0];
        String commode = Request.QueryString.GetValues(BatchManager.COMMODE_KEY)[0];
        String pgloadmode = Request.QueryString.GetValues(BatchManager.ISINIT_KEY)[0];

        //画面から渡されたメッセージを取得する。
        String normalEndMsg = Request.QueryString.GetValues(BatchManager.NORMALEND_MSG_KEY)[0];
        String abendMsg = Request.QueryString.GetValues(BatchManager.ABEND_MSG_KEY)[0];
        String dealing = Request.QueryString.GetValues(BatchManager.DEALING_MSG_KEY)[0];

        //帳票出力件数が超過した場合のメッセージを取得する。
        string maxRecord = MessageResourceUtil.GetString("I434");
        string zeroCount = MessageResourceUtil.GetString("I433");

        //タイムアウト発生時(起動時)のメッセージを取得する。
        string batchWaitTimeoutMsg = MessageResourceUtil.GetString("I410");
        //タイムアウト発生時（実行時）のメッセージを取得する。
        string batchRunTimeoutMsg = MessageResourceUtil.GetString("I410");


        //フォーカス制御用のキーを取得する
        String itemKey = FormFocusUtil.GetItemIdKey();
        String mCountKey = FormFocusUtil.GetMcountKey();

        String itemid = null;
        if (Request[itemKey] != null)
        {
            itemid = Request.QueryString.GetValues(itemKey)[0];
        }

        String mid = null;
        if (Request[mCountKey] != null)
        {
            mid = Request.QueryString.GetValues(mCountKey)[0];
        }

        //コネクションを取得する。
        ConnectionStringSettings setting = ContextUtil.GetDefaultQuiqConnectionStringSettings();
        BatchEndMonitor2 bem = new BatchEndMonitor2(setting);

        Sc_job_status_logVO vo = bem.StartMonitor(jobId);
        decimal? status = vo.Job_status;

        //Statusにより、処理を行う
        switch ((int)status)
        {
            //正常終了
            case (int)JobStatus.NormalEnd:
                //ダウンロード用のファイルが登録されている場合、ダウンロードを行う。
                if (vo.Syuturyoku_file_nm != null)
                {
                    //ファイルの存在チェックを行う。
                    if (System.IO.File.Exists(vo.Syuturyoku_file_nm))
                    {
                        SetDownload(vo.Syuturyoku_file_nm,pgid);
                    }
                    else if("MaxRecord".Equals(vo.Syuturyoku_file_nm))
                    {
                        //MAXRECORD
                        StopRefresh(maxRecord, vo.Errordata_file_name, pgid);
                    }
                    else if ("DataNotFound".Equals(vo.Syuturyoku_file_nm))
                    {
                        //NOTDATAFOUND
                        StopRefresh(zeroCount, vo.Errordata_file_name, pgid);
                    }
                    else
                    {
                        StopRefresh(normalEndMsg, vo.Errordata_file_name, pgid);
                    }
                }
                else
                {
                    StopRefresh(normalEndMsg, vo.Errordata_file_name, pgid);
                }
                break;

            //正常終了（対象なし）
            case (int)JobStatus.NormalEndWithNoTaget:
                //SetNormalEnd(normalEndMsg);
                StopRefresh(normalEndMsg, vo.Errordata_file_name, pgid);
                break;

            //起動タイムアウト
            case (int)JobStatus.BootTimeOut:
                StopRefresh(batchWaitTimeoutMsg, vo.Errordata_file_name, pgid);
                break;

            //実行タイムアウト
            case (int)JobStatus.RunTimeOut:
                StopRefresh(batchRunTimeoutMsg, vo.Errordata_file_name, pgid);
                break;

            //異状終了
            case (int)JobStatus.BadEnd:
                StopRefresh(abendMsg, vo.Errordata_file_name, pgid);
                break;

            //処理中
            default:
                SetRunning(dealing);
                break;
        }
    }


    /// <summary>
    /// 自画面更新停止し、閉じるボタンを表示します。
    /// </summary>
    private void StopRefresh(String msgStr,String voMsgStr,String pgid)
    {

    //ダウンロード用のファイルが登録されていない場合。
    //更新件数確認画面を表示させる。
        IList<UpdateConfirmMessageVO> msgList = new List<UpdateConfirmMessageVO>();

        if(!String.IsNullOrEmpty(voMsgStr)){
            String[] str = voMsgStr.Split(',');
            foreach (String s in str)
            {
                msgList.Add(new UpdateConfirmMessageVO(s));
            }
        }else{
                msgList.Add(new UpdateConfirmMessageVO(msgStr));
        }

        SessionInfoUtil.SetPgObject(pgid, MdSessionKeyConstant.UPDATE_CONFIRM_LIST, msgList, Session);

        this.nowloadinggif.Style.Clear();
        this.nowloadinggif.Style.Add("display", "none");
        this.refreshSetup.Content = "-1";

        string script = "<SCRIPT LANGUAGE='javascript'>" +
                              " var main = window.dialogArguments;" +
                              " main.finishflg = 1; "+
                              " main.updateConfirmDisplay.on();" +
                              " window.close();" +
                            "</SCRIPT>";
        ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "resize", script);
    }

    /// <summary>
    /// バッチ処理中に、表示する内容です。
    /// </summary>
    private void SetRunning(String dealing)
    {
        this.resultcode.Text = Server.HtmlEncode(dealing);
    }


    /// <summary>
    /// ファイルをダウンロード時の処理です。
    /// </summary>
    private void SetDownload(string fileNm,String pgId)
    {

        //ファイル名をセッションに格納する。
        SessionInfoUtil.SetPgObject(pgId, "FileName", fileNm, Session);

        //ダウンロード処理を実行する。
        //ファイルをダウンロードします。
        string script = "<SCRIPT LANGUAGE='javascript'>" +
                              " var main = window.dialogArguments;" +
                              " main.finishflg = 1; " +
                              " main.downloadflg = 1; " +
                              //" var w = window.open('DownLoadRun.aspx?pgId="+pgId+"','download','dependent=yes,alwaysLowered=yes,width=1,height=1,left=2000,top=2000');" +
                              " window.close();" +
                            "</SCRIPT>";
        ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "resize", script);

    }
}
