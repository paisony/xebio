using System;
using System.Web.UI.WebControls;
using Common.Standard.Session;
using System.Collections.Generic;
using Common.Standard.Message;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using Common.IntegrationMD.Import;
using Common.Advanced.Web.Context;
using Common.Standard.Constant;
using System.Collections;



public partial class pjcommon_mdAspx_UpdateConfirm : System.Web.UI.Page
{
    #region フィールド
    /// <summary>
    /// リクエストキー
    /// </summary>
    private const String REQUEST_KEY = "pgId";
    private const String REQUEST_KEY_FLG = "flg";
    #endregion

    #region メソッド
    /// <summary>
    /// ページロード
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        String pgId = (String)Request[REQUEST_KEY];
        String noDispFlg = (String)Request[REQUEST_KEY_FLG];

        IList<ErrInfoVo> list = (IList<ErrInfoVo>)SessionInfoUtil.GetPgObject(pgId, MdSessionKeyConstant.CONFIRM_KEY, Session);
        Repeater1.DataSource = list;
        Repeater1.DataBind();

        SessionInfoUtil.RemovePgObject(pgId, MdSessionKeyConstant.CONFIRM_KEY, Session);

        if ("YES".Equals(noDispFlg))
        {
            Reset2.Visible = false;
        }

    }

    /// <summary>
    /// リピーターのイベントハンドラです。
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void OnItemCreated(object sender, RepeaterItemEventArgs e)
    {
        //メッセージのフォントカラーを指定する。
        ((Label)e.Item.FindControl("Message")).ForeColor = System.Drawing.Color.Blue;
    }

    #region 標題を設定します。
    /// <summary>
    /// 標題を設定します。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            // 標題
            StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();

            ////ウィンドウタイトル(メッセージ一覧)
            this.Windowtitle.Text = Server.HtmlEncode(captionMgr.GetString("C996"));

            //標題（処理の継続）
            this.Reset1.Value = MessageResourceUtil.GetString("I429");
            //標題（処理の中断）
            this.Reset2.Value = MessageResourceUtil.GetString("I430");

            //標題(業務メッセージ)
            //エラー件数の取得
            string[] parameter = { Repeater1.Items.Count.ToString() };//エラー件数の取得
            this.PgNameLiteral.Text = Server.HtmlEncode(MessageResourceUtil.GetString("I428",parameter));

        }
    }
    #endregion
    #endregion
}
