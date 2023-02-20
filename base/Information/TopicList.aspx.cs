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
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

/// <summary>
/// Information_TopicListのコードビハインドです。
/// </summary>
public partial class Information_TopicList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region 見出しを全件取得する
            
            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;
            InformationService service = new InformationService(loginInfo);
            DataResult<DataTable> topicResult = service.GetAllTopTopic(false);

            if (topicResult.IsSuccess)
            {
                TopicList.DataSource = topicResult.ResultData;
            }
            else
            {
                throw new ApplicationException("見出しリストの取得に失敗しました。" + topicResult.ToString());
            }

            #endregion
        }
    }

    #region フォームのデータを表示

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
            FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicList");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            AddBtn.Text = resource.GetString("AddBtn");
            BackBtn.Text = resource.GetString("BackBtn");

            TopicList.Columns[1].HeaderText = resource.GetString("CAPTION_LIST_TOPIC");
            TopicList.Columns[2].HeaderText = resource.GetString("CAPTION_LIST_DISPLAY");
            TopicList.Columns[3].HeaderText = resource.GetString("CAPTION_LIST_ORDER");
            TopicList.Columns[4].HeaderText = resource.GetString("CAPTION_LIST_EDIT_BTN");
            TopicList.Columns[5].HeaderText = resource.GetString("CAPTION_LIST_DEL_BTN");

            //ボタンフィールド中のボタンのテキスト表示
            ((ButtonField)TopicList.Columns[4]).Text = resource.GetString("CAPTION_LIST_EDIT_BTN");
            ((ButtonField)TopicList.Columns[5]).Text = resource.GetString("CAPTION_LIST_DEL_BTN");


            TopicList.DataBind();

            #region 表示列の値 1なら「表示」、2なら「非表示」をセット

            for (int i = 0; i < TopicList.Rows.Count; i++)
            {
                if (((Label)TopicList.Rows[i].FindControl("DisplayFlag")).Text == "1")
                {
                    ((Label)TopicList.Rows[i].FindControl("DisplayFlag")).Text = resource.GetString("CAPTION_VISIBLE");
                }
                else
                {
                    ((Label)TopicList.Rows[i].FindControl("DisplayFlag")).Text = resource.GetString("CAPTION_HIDDEN");
                }
            }

            #endregion

            #endregion

        }

    }
    #endregion


    /// <summary>
    /// 新規作成ボタン押下時
    /// </summary>
    /// 
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddBtn_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Items.Add("EditMode", "NEW");
        Server.Transfer("TopicEdit.aspx");
    }

    /// <summary>
    /// DataViewのボタン押下時
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void topicList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //押された行の行番号を取得
        int index = Convert.ToInt32(e.CommandArgument);

        string topicId = ((Label)TopicList.Rows[index].FindControl("TopicID")).Text;
        HttpContext.Current.Items.Add("TopicId", topicId);

        if (e.CommandName == "EditRow")
        {
            //編集時
            HttpContext.Current.Items.Add("EditMode", "UPD");
            Server.Transfer("TopicEdit.aspx");

        }
        else if (e.CommandName == "DeleteRow")
        {
            //削除時
            Server.Transfer("TopicDelConfirm.aspx");
        }
    }

    /// <summary>
    /// 戻るボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("InformationMenu.aspx");
    }
}
