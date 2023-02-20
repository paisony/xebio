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

using Com.Fujitsu.SmartBase.Base.Information.Dac;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

public partial class Information_LabelDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //DBから表示情報を取得
            TopDisplayVO vo = this.GetTopDisplayVO();

            //画面に表示情報をセット
            DisplayContentLbl.Text = vo.DisplayContent;

            //VOに格納した画面表示情報をセッションに格納
            SessionManager.SetObject(vo,
                "SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
                "SESSION_KEY_INFORMATION_PGID");
        }
    }

    #region ボタン押下イベント

    /// <summary>
    /// 編集ボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("LabelEdit.aspx");
    }

    /// <summary>
    /// デフォルトボタン押下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="ApplicationException">
    /// トップ画面情報取得時にレコードが取得できない、
    /// または2件以上レコードが取得された場合。
    /// </exception>
    protected void DefaultBtn_Click(object sender, EventArgs e)
    {
        string website = Convert.ToString(ConfigurationManager.AppSettings["DefaultContent"]);
        if (!website.Trim().StartsWith("http"))
        {
            website = "../Common/" + website;
        }
        DisplayContentLbl.Text = "<iframe src=\"" + website + "\" width=\"100%\" height=\"100%\" scrolling=\"no\" frameborder=\"0\"></iframe>";

        //セッションからトップ画面表示情報VOを取得
        TopDisplayVO dVO = (TopDisplayVO)SessionManager.GetObject(
            "SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
            "SESSION_KEY_INFORMATION_PGID");

        //デフォルト情報をVOにセット
        dVO.DisplayContent = DisplayContentLbl.Text;

        #region 更新

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        InformationService service = new InformationService(loginInfo);
        Result res = service.UpdateTopDisplay(dVO);
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
            throw new ApplicationException("Information_LabelDisplay:表示画面情報の更新に失敗しました。" + res.ToString());
        }

        //DBから表示情報を取得
        TopDisplayVO updatedVO = this.GetTopDisplayVO();

        //更新用VOをセッションに格納
        SessionManager.SetObject(updatedVO,
            "SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
            "SESSION_KEY_INFORMATION_PGID");

        #endregion

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

    #endregion

    #region その他のイベント

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
            FormResource resource = ResourceManager.GetInstance().GetFormResource("LabelDisplay");

            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            EditBtn.Text = resource.GetString("EditBtn");
            DefaultBtn.Text = resource.GetString("DefaultBtn");
            BackBtn.Text = resource.GetString("BackBtn");
            
            #endregion
        }
    }

    #endregion

    #region privateメソッド

    /// <summary>
    /// DBからトップ画面情報を取得する
    /// </summary>
    /// <returns>データがセットされた画面情報VO<see cref="TopDisplayVO"/></returns>
    private TopDisplayVO GetTopDisplayVO()
    {
        #region DBからトップ画面情報を取得し値をVOに格納する

        LoginUserInfoVO loginInfo = new LoginUserInfoVO();
        loginInfo.LoginId = LoginUserContext.LoginId;
        InformationService service = new InformationService(loginInfo);

		DataResult<DataTable> getRes = service.GetAllTopDisplay(false, LoginUserContext.LoginId);
        if (getRes.ResultData.Rows.Count != 1)
        {
            throw new ApplicationException("Information_LabelDisplay:トップ画面情報の取得に失敗しました。");
        }

        TopDisplayVO dVO = new TopDisplayVO();
        dVO.DisplayId = Convert.ToString(getRes.ResultData.Rows[0]["DISPLAY_ID"]);
        //画面の更新情報をセット
        dVO.DisplayContent = Convert.ToString(getRes.ResultData.Rows[0]["DISPLAY_CONTENT"]);
        dVO.CreateDateTime = Convert.ToDateTime(getRes.ResultData.Rows[0]["CREATE_DATETIME"]);
        dVO.CreateUserId = Convert.ToString(getRes.ResultData.Rows[0]["CREATE_USER_ID"]);
        dVO.UpdateDateTime = Convert.ToDateTime(getRes.ResultData.Rows[0]["UPDATE_DATETIME"]);
        dVO.UpdateUserId = Convert.ToString(getRes.ResultData.Rows[0]["UPDATE_USER_ID"]);
        dVO.RowUpdateId = Convert.ToString(getRes.ResultData.Rows[0]["ROW_UPDATE_ID"]);

        #endregion

        return dVO;
    }

    #endregion

}
