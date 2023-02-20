using System;
using System.Web.UI.WebControls;
using Common.Standard.Session;
using System.Collections.Generic;
using Common.Standard.Message;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;



public partial class pjcommon_mdAspx_UpdateConfirm : System.Web.UI.Page
{
    #region フィールド
    /// <summary>
    /// リクエストキー
    /// </summary>
    private const String REQUEST_KEY = "pgId";
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
        List<UpdateConfirmMessageVO> list = (List<UpdateConfirmMessageVO>)SessionInfoUtil.GetPgObject(pgId, MdSessionKeyConstant.UPDATE_CONFIRM_LIST, Session);

        Repeater1.DataSource = list;
        Repeater1.DataBind();

        SessionInfoUtil.RemovePgObject(pgId, MdSessionKeyConstant.UPDATE_CONFIRM_LIST, Session);
    }

    /// <summary>
    /// リピーターのイベントハンドラです。
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void OnItemCreated(object sender, RepeaterItemEventArgs e)
    {
        UpdateConfirmMessageVO msgInfoVO = (UpdateConfirmMessageVO)e.Item.DataItem;

        //各項目の個別設定
        switch (msgInfoVO.Type)
        {
            
            default:
                break;
        }
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
            this.Windowtitle.Text = Server.HtmlEncode("処理結果確認画面");

            //標題(閉じる)
            this.Reset2.Value = captionMgr.GetString("C987");

            // メッセージ
            StandardMessageManager messageMgr = StandardMessageManager.GetInstance();

            //標題(業務メッセージ)

            //エラー件数の取得
            //string[] parameter = { Repeater1.Items.Count.ToString() };
            string count =  Repeater1.Items.Count.ToString() ;

            this.PgNameLiteral.Text = Server.HtmlEncode("確認メッセージ");
        }
    }
    #endregion
    #endregion
}
