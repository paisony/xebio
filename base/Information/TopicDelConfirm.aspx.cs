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

using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

/// <summary>
/// Information_TopicDelConfirmのコードビハインドです。

/// </summary>
public partial class Information_TopicDelConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region データを画面にセット

            string topicId = Convert.ToString(HttpContext.Current.Items["TopicId"]);

            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            InformationService service = new InformationService(loginInfo);

            TopTopicKey pKey = new TopTopicKey(topicId);
            DataResult<DataTable> topicResult = service.GetTopTopic(pKey);

            if (topicResult.IsSuccess)
            {
                if (topicResult.ResultData.Rows.Count > 0)
                {
                    DataTable res = topicResult.ResultData;

                    #region VOにセットしてセッションに格納


                    TopTopicVO vo = new TopTopicVO();

                    vo.TopicId = Convert.ToString(res.Rows[0]["TOPIC_ID"]);
                    vo.Topic = Convert.ToString(res.Rows[0]["TOPIC"]);
                    vo.NewDisplayPriod = Convert.ToString(res.Rows[0]["NEW_DISPLAY_PERIOD"]);
                    vo.DateDisplayFlag = Convert.ToString(res.Rows[0]["DATE_DISPLAY_FLAG"]);
                    vo.DateFormat = Convert.ToString(res.Rows[0]["DATE_FORMAT"]);
                    vo.DisplayNumber = Convert.ToString(res.Rows[0]["DISPLAY_NUMBER"]);
                    vo.DisplayPeriod = Convert.ToString(res.Rows[0]["DISPLAY_PERIOD"]);
                    vo.DisplayFlag = Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]);
                    vo.SortNo = Convert.ToString(res.Rows[0]["SORT_NO"]);
                    vo.CreateDateTime = Convert.ToDateTime(res.Rows[0]["CREATE_DATETIME"]);
                    vo.CreateUserId = Convert.ToString(res.Rows[0]["CREATE_USER_ID"]);
                    vo.UpdateDateTime = Convert.ToDateTime(res.Rows[0]["UPDATE_DATETIME"]);
                    vo.UpdateUserId = Convert.ToString(res.Rows[0]["UPDATE_USER_ID"]);
                    vo.RowUpdateId = Convert.ToString(res.Rows[0]["ROW_UPDATE_ID"]);

                    //セッションにセット
                    SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
                        "SESSION_KEY_INFORMATION_PGID");

                    #endregion

                    #region VOの内容を画面のコントロールにセット

                    //リソース取得

                    FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicDelConfirm");


                    //見出し名
                    TopicNameConfirmLbl.Text = vo.Topic;
                    //「見出し表示」

                    switch (vo.DisplayFlag)
                    {
                        case "0":
                            DisplayTopicConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
                            break;
                        case "1":
                            DisplayTopicConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
                            break;
                        default:
                            break;
                    }
                    //New表示期間
                    NewDisplayPeriodConfirmLbl.Text = vo.NewDisplayPriod;
                    //日付表示(表示・非表示のラジオボタン)
                    switch (vo.DateDisplayFlag)
                    {
                        case "0":
                            DisplayDateConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
                            break;
                        case "1":
                            DisplayDateConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
                            break;
                        default:
                            break;
                    }
                    //日付フォーマット

                    switch (vo.DateFormat)
                    {
                        case "yyyy.MM.dd":
                            DateFormatConfirmLbl.Text = "(YYYY.MM.DD)";
                            break;
                        case "yyyy/MM/dd":
                            DateFormatConfirmLbl.Text = "(YYYY/MM/DD)";
                            break;
                        case "yyyy年MM月dd日":
                            DateFormatConfirmLbl.Text = "(YYYY年MM月DD日)";
                            break;
                        case "MM.dd":
                            DateFormatConfirmLbl.Text = "(MM.DD)";
                            break;
                        case "MM/dd":
                            DateFormatConfirmLbl.Text = "(MM/DD)";
                            break;
                        case "MM月dd日":
                            DateFormatConfirmLbl.Text = "(MM月DD日)";
                            break;
                        default:
                            break;
                    }
                    //表示件数
                    DisplayNumberConfirmLbl.Text = vo.DisplayNumber;
                    //表示期間
                    DisplayPeriodCOnfirmLbl.Text = vo.DisplayPeriod;
                    //表示順

                    SortNoConfirmLbl.Text = vo.SortNo;

                    #endregion

                    //RenderFormメソッドでDateDisplayFlagを使用するためViewstateにセット
                    ViewState["DateDisplayFlag"] = vo.DateDisplayFlag;
                }
                else
                {
                 //排他エラー
                 MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                 BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                 BusinessErrorMessage.Visible = true;

                 DeleteBtn.Enabled = false;
                 UnitDayLbl2.Enabled = false;
                 UnitAffarLbl.Enabled = false;
                 UnitDayLbl1.Enabled = false;
                 return;
                }
            }

            #endregion
        }
    }

    /// <summary>
    /// 削除ボタン押下

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        //セッションからVOを取得

        TopTopicVO vo = (TopTopicVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
            "SESSION_KEY_INFORMATION_PGID");

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        InformationService service = new InformationService(loginInfo);
        //削除
        Result res = service.DeleteTopTopic(vo);

        #region エラー処理


        if (!res.IsSuccess && res.HasError)
        {
            MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
 
            foreach (Error error in res.Errors) {
                if (error is DBConcurrencyError)
                {
                    // 排他エラー
                    BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                    BusinessErrorMessage.Visible = true;
                    return;
                }
                else if (error is BusinessError && 
                    error.ErrorCode == InformationErrorCode.ERROR_CODE_MESSAGE_EXIST)
                {
                    // 業務エラー
                    BusinessErrorMessage.Text = resource.GetString(InformationErrorCode.ERROR_CODE_MESSAGE_EXIST);
                    BusinessErrorMessage.Visible = true;
                    return;
                }
                else if (!res.IsSuccess)
                {
                    //排他チェックエラー以外のエラーの発生時
                    throw new ApplicationException("Information_TopicDelConfirm:見出し情報の削除に失敗しました。" + res.ToString());
                }
            }
        }

        #endregion

        //セッションからVOを削除
        SessionManager.SessionRemove(
            "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
            "SESSION_KEY_INFORMATION_PGID");

        Server.Transfer("TopicList.aspx");
    }


    /// <summary>
    /// 表題セット，コントロールの表示制御
    /// </summary>
    /// <remarks>
    /// 1.日付表示フラグ(DateDisplayFlag)が0の場合は日付フォーマットを非表示。1なら表示。

    /// </remarks>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            #region 標題セット

            //リソース取得

            FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicDelConfirm");

            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            TopicNameLbl.Text = resource.GetString("TopicNameLbl");
            DisplayLbl.Text = resource.GetString("DisplayLbl");
            NewDisplayPeriodLbl.Text = resource.GetString("NewDisplayPeriodLbl");
            DateDisplayFlagLbl.Text = resource.GetString("DateDisplayFlagLbl");
            DisplayNumberLbl.Text = resource.GetString("DisplayNumberLbl");
            DisplayPeriodLbl.Text = resource.GetString("DisplayPeriodLbl");
            SortNo.Text = resource.GetString("SortNo");
            UnitDayLbl2.Text = resource.GetString("UnitDayLbl2");
            UnitAffarLbl.Text = resource.GetString("UnitAffarLbl");
            UnitDayLbl1.Text = resource.GetString("UnitDayLbl1");
            DeleteBtn.Text = resource.GetString("DeleteBtn");
            BackBtn.Text = resource.GetString("BackBtn");


            #endregion

            // 1
            switch ((string)ViewState["DateDisplayFlag"])
            {
                case "0":
                    DateFormatConfirmLbl.Visible = false;
                    break;
                case "1":
                    DateFormatConfirmLbl.Visible = true;
                    break;
                default:
                    break;
            }

        }
    }

    /// <summary>
    /// 戻るボタン押下

    /// </summary>
    /// <remarks>
    /// 一覧画面に遷移。

    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("TopicList.aspx");
    }
}
