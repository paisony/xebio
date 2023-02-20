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
using Common.Standard.Model.Data;
using System.Xml;
using Common.Standard.Batch;
using Common.Standard.Util;
using System.Collections.Generic;
using Common.Standard.Model.Entity.VO;
using System.IO;

public partial class pjcommon_mdAspx_AsynchronousBatchMonitor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.Advanced.Model.Context.IDBContext context = null;

        //ジョブIDを取得する。
        String jobId = Request.QueryString.GetValues(BatchManager.JOBID_KEY)[0];

        try
        {
            //コネクションを取得する。
            ConnectionStringSettings setting = ContextUtil.GetDefaultQuiqConnectionStringSettings();
            BatchEndMonitor2 bem = new BatchEndMonitor2(setting);
            Sc_job_status_logVO vo = bem.StartMonitor(jobId);

            //レスポンスXmlデータを生成
            XmlDocument responseXml = this.CreateResponseXml(vo);

            //レスポンスを送信します。
            this.SetHttpResponse(System.Web.HttpContext.Current.Response, responseXml);

        }
        finally
        {
            // コネクションクローズ
            if (context != null) context.CloseConnection();
        }
    }

 
    /// <summary>
    /// レスポンスを送信します。
    /// </summary>
    /// <param name="response"></param>
    /// <param name="responseXml"></param>
    /// <returns></returns>
    protected virtual void SetHttpResponse(HttpResponse response, XmlDocument responseXml)
    {
        //Httpレスポンスヘッダをセットする
        response.Clear();
        response.ContentType = "text/xml";
        response.StatusCode = 200;
        response.StatusDescription = "OK";

        //レスポンスデータ生成及び送信
        response.Write(responseXml.InnerXml);
        response.End();
    }

    /// <summary>
    /// レスポンスXmlデータを生成
    /// </summary>
    /// <param name="resultMap"></param>
    /// <returns></returns>
    protected virtual XmlDocument CreateResponseXml(Sc_job_status_logVO vo)
    {
        //ドキュメント宣言
        XmlDocument responseXml = new XmlDocument();
        responseXml.AppendChild(responseXml.CreateXmlDeclaration("1.0", "utf-8", null));

        //ルートエレメント生成
        XmlElement root = responseXml.CreateElement("response");
        root.SetAttribute("ret", Convert.ToString(vo.Job_status));

        //ファイルの状態を設定します。
        int cnt = 0;
        foreach (Sc_job_status_log_detailVO dvo in vo.Details)
        {
            if (!String.IsNullOrEmpty(dvo.Filmei))
            {
                XmlElement file = responseXml.CreateElement("file");
                file.SetAttribute("id", Convert.ToString(cnt));

                XmlElement edb = responseXml.CreateElement("edb");
                edb.InnerText = Convert.ToString(dvo.Edb);

                XmlElement status = responseXml.CreateElement("status");
                status.InnerText = Convert.ToString(dvo.Job_status_d);

                XmlElement errFile = responseXml.CreateElement("errFilename");
                errFile.InnerText = dvo.Errordata_file_name;

                file.AppendChild(edb);
                file.AppendChild(status);
                file.AppendChild(errFile);

                root.AppendChild(file);
            }

            cnt++;
        }
 
        responseXml.AppendChild(root);

        return responseXml;
    }


}
