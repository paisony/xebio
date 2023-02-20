// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Web;

using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

public partial class Information_MessageComfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //セッションからVOを取得

            TopMessageVO vo = (TopMessageVO)SessionManager.GetObject(
                "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
                "SESSION_KEY_INFORMATION_PGID");
            if (vo == null)
            {
                throw new ApplicationException("Information_MessageConfirm:メッセージ情報の取得に失敗しました。");
            }

            TopTopicKey pkey = new TopTopicKey(vo.TopicId);

            #region 見出し情報の取得


            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            InformationService service = new InformationService(loginInfo);
            DataResult<DataTable> topicResult = service.GetTopTopic(pkey);
            if (!topicResult.IsSuccess)
            {
                throw new ApplicationException("Information_MessageConfirm:見出し情報の取得に失敗しました。");
            }
            #endregion

            #region VOの内容を画面のコントロールにセット

            //リソース取得

            FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageConfirm");

            //見出属性
            TopicConfirmLbl.Text = (string)topicResult.ResultData.Rows[0]["TOPIC"];
            //メッセージ  
            MessageConfirmLbl.Text = vo.Message;
            //URL
            UrlConfirmLbl.Text = vo.Url;
            //表示の可否
            if (vo.DisplayFlag == true)
            {
                DisplayConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
            } else 
            {
                DisplayConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
            }

            #endregion

        }
    }

    /// <summary>
    /// 確定ボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CreateBtn_Click(object sender, EventArgs e)
    {
        //セッションからVOを取得
        TopMessageVO vo = (TopMessageVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
            "SESSION_KEY_INFORMATION_PGID");

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;

        InformationService service = new InformationService(loginInfo);
        //追加・更新
        Result res = service.InsertOrUpdateTopMessage(vo);

        if (!res.IsSuccess && res.HasError && res.Errors[0] is DBConcurrencyError)
        {
            // 排他エラー
            MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
            BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
            BusinessErrorMessage.Visible = true;
            return;
        }
        else if (!res.IsSuccess)
        {
            //排他チェックエラー以外のエラーの発生時
            throw new ApplicationException("Information_MessageConfirm:メッセージ情報の追加／更新に失敗しました。" + res.ToString());
        }

        //セッションからVOを削除
        SessionManager.SessionRemove(
            "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
            "SESSION_KEY_INFORMATION_PGID");

        //メッセージ一覧画面で検索を行うため"SCH"を渡す。

        HttpContext.Current.Items.Add("EditMode", "SCH");
        Server.Transfer("MessageList.aspx");
    }

    /// <summary>
    /// 戻るボタン押下

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Items.Add("EditMode", "CFM");
        Server.Transfer("MessageEdit.aspx");
    }

    /// <summary>
    /// 標題セット
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            #region 標題セット

            //リソース取得

            FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageConfirm");

            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            TopicLbl.Text = resource.GetString("TopicLbl");
            MessageLbl.Text = resource.GetString("MessageLbl");
            UrlLbl.Text = resource.GetString("UrlLbl");
            DisplayLbl.Text = resource.GetString("DisplayLbl");
            ConfirmBtn.Text = resource.GetString("ConfirmBtn");
            BackBtn.Text = resource.GetString("BackBtn");

            #endregion
        }
    }
}
