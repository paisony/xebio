using System;
using System.Text;
using System.Web;
using Common.IntegrationMD.Constant;
using Common.Advanced.Log;
using Common.IntegrationMD.FacadeAdapter;
using Common.IntegrationMD.Util;
using System.Collections.Generic;
using Common.Standard.Session;
using Common.Standard.Message;
using Common.Standard.Constant;
using System.Xml;
using System.IO;

/// <summary>
/// 非同期でリクエストを受けるクラスです
/// 処理は何もしないでResponseを返す
/// </summary>
public partial class pjcommon_mdAspx_Asynchronous_AsyncRequest : System.Web.UI.Page
{
    /// <summary>
    /// ログ出力クラスです。
    /// </summary>
    protected static ILogger logger = LogManager.GetLogger();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //セッションからスレッドオブジェクトを取得する。
            HttpRequest request = System.Web.HttpContext.Current.Request;

            if (logger.IsErrorEnabled)
            {
                logger.Debug("非同期ポーリング処理開始");
            }

            //RequestからスレッドIDを取得
            XmlDocument postedXml = new XmlDocument();
            Stream stream = request.InputStream;
            postedXml.Load(stream);

            String threadId = postedXml.GetElementsByTagName("threadId")[0].InnerText;

            //スレッド状態を取得する
            ThreadState state = ThreadStateContainer.GetInstance(threadId);
            String msgInfo = "";
            String callback = "";

            //ステータスによって処理を分岐
            switch (state.Status)
            {
                case MdSystemConstant.MdThreadState.normal:
                    callback = state.ReloadParam;
                    break;

                case MdSystemConstant.MdThreadState.updateConfirm:
                    IList<UpdateConfirmMessageVO> list = state.ConfirmMsg;
                    SessionInfoUtil.SetPgObject(state.PgId, MdSessionKeyConstant.UPDATE_CONFIRM_LIST, list, Session);
                    callback = state.ReloadParam;
                    break;

                case MdSystemConstant.MdThreadState.errorDialog:
                    IList<MessageInfoVO> elist = state.ErrMsg;
                    SessionInfoUtil.SetPgObject(state.PgId, SessionKeyConstant.MESSAGE_LIST, elist, Session);
                    MessageLevel msgLevel = state.MsgLevel;
                    callback = state.ReloadParam;
                    if (MessageLevel.ERROR.Equals(state.MsgLevel))
                    {
                        msgInfo = state.PgId.ToLower();
                    }
                    else
                    {
                        msgInfo = state.PgId.ToLower() + "INFO";
                    }

                    break;

                case MdSystemConstant.MdThreadState.abend:
                    IList<UpdateConfirmMessageVO> alist = state.ConfirmMsg;
                    SessionInfoUtil.SetPgObject(state.PgId, MdSessionKeyConstant.UPDATE_CONFIRM_LIST, alist, Session);
                    break;

                default:
                    break;
            }

            //XMLデータの作成
            XmlDocument responseXml = new XmlDocument();
            responseXml.AppendChild(responseXml.CreateXmlDeclaration("1.0", "utf-8", null));

            XmlElement root = responseXml.CreateElement("response");

            XmlElement r = responseXml.CreateElement("ret");
            r.SetAttribute("id", threadId);
            r.InnerText = state.Status.ToString();

            XmlElement ee = responseXml.CreateElement("errLevel");
            ee.InnerText = msgInfo;

            XmlElement c = responseXml.CreateElement("callback");
            c.InnerText = callback;

            root.AppendChild(r);
            root.AppendChild(ee);
            root.AppendChild(c);

            responseXml.AppendChild(root);

            //処理が終了している場合、コンテナからデータを削除する。
            //if(state.IsEnd()){
            //    ThreadStateContainer.RemoveThreadState(threadId);
            //}
            HttpResponse res = System.Web.HttpContext.Current.Response;

            res.Clear();
            res.ContentType = "text/xml";
            res.StatusCode = 200;
            res.StatusDescription = "OK";
            //レスポンスデータ生成及び送信
            res.Write(responseXml.OuterXml);
            res.Flush();
            res.End();

            if (logger.IsErrorEnabled)
            {
                logger.Debug("非同期ポーリング処理終了");
            }

        }
        catch (System.Threading.ThreadAbortException)
        {
            //ThreadAbortExceptionは必ず発生するのでここで握りつぶす。
        }
        catch (System.Exception se)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(se.StackTrace);
            }
        }
    }
}
