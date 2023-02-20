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
using Common.Standard.FileLoad;
using Common.Advanced.Resource;
using Common.Standard.Session;
using Common.Standard.Batch.Constant;
using Common.Standard.Constant;
using Common.Standard.Exception;

public partial class pjcommon_mdAspx_NowLoading : System.Web.UI.Page
{
    #region フィールド
    /// <summary>
    /// リクエストプログラムIDキー値
    /// </summary>
    private const String PGID_KEY = "pgid";
    /// <summary>
    /// リクエストフォームIDキー値
    /// </summary>
    private const String FORMID_KEY = "formid";
    /// <summary>
    /// リソースタイトルバーキー値
    /// </summary>
    private const String TITLEBAR_KEY = "_Titlebar";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        String pgid = Request.QueryString.GetValues("pgId")[0];
        //セッションからファイル名を取得する。
        string fileName = (string)SessionInfoUtil.GetPgObject(pgid, "Filename", Session);
        SessionInfoUtil.RemovePgObject(pgid, "Filename", Session);

        string downloaded = (string)SessionInfoUtil.GetPgObject(pgid, "ClientFileName", Session);
        SessionInfoUtil.RemovePgObject(pgid, "ClientFileName", Session);

        //ファイルをダウンロードする。
        FileManager.MDDownload(fileName, "download", downloaded);
    }

}
