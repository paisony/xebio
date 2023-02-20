﻿// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
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

using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Web;

public partial class Information_MessageDelConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region データを画面にセット

            string messageId = Convert.ToString(HttpContext.Current.Items["MessageId"]);

            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            InformationService service = new InformationService(loginInfo);

            TopMessageKey pKey = new TopMessageKey(messageId);
            DataResult<DataTable> messageResult = service.GetTopMessage(pKey);

            if (messageResult.IsSuccess)
            {
                if (messageResult.ResultData.Rows.Count > 0)
                {
                    DataTable res = messageResult.ResultData;

                    #region VOにセットしてセッションに格納


                    TopMessageVO vo = new TopMessageVO();

                    vo.MessageId = Convert.ToString(res.Rows[0]["MESSAGE_ID"]);
                    vo.TopicId = Convert.ToString(res.Rows[0]["TOPIC_ID"]);
                    vo.Message = Convert.ToString(res.Rows[0]["MESSAGE"]);
                    vo.Url = Convert.ToString(res.Rows[0]["URL"]);
                    vo.DisplayFlag = (Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]) == "1") ? true : false;
                    vo.CreateDateTime = Convert.ToDateTime(res.Rows[0]["CREATE_DATETIME"]);
                    vo.CreateUserId = Convert.ToString(res.Rows[0]["CREATE_USER_ID"]);
                    vo.UpdateDateTime = Convert.ToDateTime(res.Rows[0]["UPDATE_DATETIME"]);
                    vo.UpdateUserId = Convert.ToString(res.Rows[0]["UPDATE_USER_ID"]);
                    vo.RowUpdateId = Convert.ToString(res.Rows[0]["ROW_UPDATE_ID"]);

                    //セッションにセット
                    SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
                        "SESSION_KEY_INFORMATION_PGID");

                    #endregion

                    #region VOの内容を画面のコントロールにセット

                    #region 見出し情報の取得


                    DataResult<DataTable> topicResult = service.GetTopTopic(new TopTopicKey(vo.TopicId));
                    if (!topicResult.IsSuccess)
                    {
                        throw new ApplicationException("Information_MessageDelConfirm:見出し情報の取得に失敗しました。");
                    }
                    #endregion


                    //見出属性
                    TopicConfirmLbl.Text = (string)topicResult.ResultData.Rows[0]["TOPIC"];
                    //メッセージ
                    MessageConfirmLiteral.Text = vo.Message;
                    //URL
                    UrlConfirmLbl.Text = vo.Url;
                    //表示の可否
                    //リソース取得

                    FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageDelConfirm");

                    if (vo.DisplayFlag == true)
                    {
                        DisplayConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
                    }
                    else
                    {
                        DisplayConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
                    }

                    #endregion
                }
                else
                { 
                //排他エラー
                 MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                 BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                 BusinessErrorMessage.Visible = true;

                 DeleteBtn.Enabled = false;
                 return;
                }

            }

            #endregion
        }
    }

    /// <summary>
    /// 戻るボタン押下

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        //一覧画面で検索を行うためにEditModeを渡す。

        HttpContext.Current.Items.Add("EditMode", "SCH");
        Server.Transfer("MessageList.aspx");
    }

    /// <summary>
    /// 削除ボタン押下

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        //セッションからVOを取得

        TopMessageVO vo = (TopMessageVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
            "SESSION_KEY_INFORMATION_PGID");

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        InformationService service = new InformationService(loginInfo);
        //削除
        Result res = service.DeleteTopMessage(new TopMessageKey(vo.MessageId), vo.RowUpdateId);

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
            throw new ApplicationException("Information_MessageDelConfirm:メッセージ情報の削除に失敗しました。" + res.ToString());
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
    /// 表題をセット
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            #region 標題セット

            //リソース取得

            FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageDelConfirm");

            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            TopicLbl.Text = resource.GetString("TopicLbl");
            MessageLbl.Text = resource.GetString("MessageLbl");
            UrlLbl.Text = resource.GetString("UrlLbl");
            DisplayLbl.Text = resource.GetString("DisplayLbl");
            DeleteBtn.Text = resource.GetString("DeleteBtn");
            BackBtn.Text = resource.GetString("BackBtn");

            #endregion
        }
    }
}
