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
/// Information_TopicConfirmのコードビハインドです。

/// </summary>
public partial class Information_TopicConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //セッションからVOを取得

            TopTopicVO vo = (TopTopicVO)SessionManager.GetObject(
                "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
                "SESSION_KEY_INFORMATION_PGID");
            if (vo == null)
            {
                throw new ApplicationException("Information_TopicConfirm:見出し情報の取得に失敗しました。");
            }

            #region VOの内容を画面のコントロールにセット

            //リソース取得

            FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicConfirm");

            //見出し名
            TopicNameConfirmLbl.Text = vo.Topic;
            //「見出し表示」

            switch (vo.DisplayFlag)
            {
                #region 分岐


                case "0":
                    DisplayTopicConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
                    break;
                case "1":
                    DisplayTopicConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
                    break;
                default:
                    break;

                #endregion
            }
            //New表示期間
            NewDisplayPeriodConfirmLbl.Text = vo.NewDisplayPriod;
            //日付表示(表示・非表示のラジオボタン)
            switch (vo.DateDisplayFlag)
            {
                #region 分岐


                case "0":
                    DisplayDateConfirmLbl.Text = resource.GetString("CAPTION_HIDDEN");
                    break;
                case "1":
                    DisplayDateConfirmLbl.Text = resource.GetString("CAPTION_VISIBLE");
                    break;
                default:
                    break;

                #endregion
            }            
            //日付フォーマット

            switch (vo.DateFormat)
            {
                #region 分岐


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

                #endregion
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
    }
    /// <summary>
    /// 戻るボタン遷移
    /// </summary>
    /// <remarks>
    /// 入力画面に遷移。EditMode:CFMを渡す。

    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Items.Add("EditMode", "CFM");
        Server.Transfer("TopicEdit.aspx");
    }

    /// <summary>
    /// 確定ボタン押下

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CreateBtn_Click(object sender, EventArgs e)
    {
        //セッションからVOを取得

        TopTopicVO vo = (TopTopicVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
            "SESSION_KEY_INFORMATION_PGID");

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        InformationService service = new InformationService(loginInfo);
        //追加・更新
        Result res = service.InsertOrUpdateTopTopic(vo);

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
            throw new ApplicationException("Information_TopicConfirm:見出し情報の追加／更新に失敗しました。" + res.ToString());
        }

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

            FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicConfirm");

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
            ConfirmBtn.Text = resource.GetString("ConfirmBtn");
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
}
