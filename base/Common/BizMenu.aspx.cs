// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更

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
using Com.Fujitsu.SmartBase.Base.Web.BizMenu;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Model;

public partial class Common_BizMenu : System.Web.UI.Page
{
	private BizMenuManager mgr;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string lang = SystemSettings.DefaultLanguage;

			string solutionId = Request.Params["solutionId"];
			string functionViewId = Request.Params["functionViewId"];
            string menuFlag = LoginUserContext.MenuFlag;

            switch (menuFlag)
            {
                case "MENU110":
                    Response.Write(@"<script language='javascript'>alert('BO')</script>");
                    lbMdMenu.Visible =　false;
                    MenuCatRep.Visible = true;
                    break;

                case "MENU120":
                    Response.Write(@"<script language='javascript'>alert('BO & MD')</script>");
                    lbMdMenu.Visible = false;
                    MenuCatRep.Visible = true;
                    break;

                case "MENU140":
                    Response.Write(@"<script language='javascript'>alert('MD')</script>");
                    lbMdMenu.Visible = false;
                    MenuCatRep.Visible = true;
                    break;

                default:
                    break;
            }

            ViewState.Add("solutionId", solutionId);
			ViewState.Add("functionViewId", functionViewId);
            if (HttpContext.Current.Response.Cookies["MenuFunctionViewId"].Value == null)
            {
                HttpContext.Current.Response.Cookies["MenuFunctionViewId"].Value = functionViewId;
            }

			mgr = new BizMenuManager(solutionId, functionViewId);
			SessionManager.SetObject(mgr, "BizMenuManager", "BizMenu");
            this.MenuCatRepEdit();
		}
		else
		{
			mgr = (BizMenuManager)SessionManager.GetObject("BizMenuManager", "BizMenu");
		}


	}

	#region ボタンイベント

	protected void MenuCatRep_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
		//メニュカテゴリの初期化
        foreach (RepeaterItem item in MenuCatRep.Items)
        {
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            //HtmlTableCell td = (HtmlTableCell)item.FindControl("MenuCatTd");
            LinkButton link = (LinkButton)item.FindControl("MenuCatLnk");
            link.CssClass = "a_menucate";
            //td.Attributes.Add("onMouseOver", "overCate('" + item.ClientID + "_MenuCatTd')");
            //td.Attributes.Add("onMouseOut", "outCate('" + item.ClientID + "_MenuCatTd')");
            //td.Attributes.Add("onClick", "clickLink('" + item.ClientID + "_MenuCatLnk')");
            //td.Style["background"] = "url(Images/BizMenu/main_menu_btn_off.jpg)";
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
        }
        //選択されたカテゴリのみイメージを変える
        // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
        //HtmlTableCell clicktd = (HtmlTableCell)e.Item.FindControl("MenuCatTd");
        LinkButton clicklink = (LinkButton)e.Item.FindControl("MenuCatLnk");
        clicklink.CssClass = "a_menucate top-stay";
        //clicktd.Attributes.Remove("onMouseOver");
        //clicktd.Attributes.Remove("onMouseOut");
        //clicktd.Attributes.Remove("onClick");
        //clicktd.Style["background"] = "url(Images/BizMenu/main_menu_btn_on.jpg)";
        // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

		string cateId = e.CommandArgument.ToString();
		this.SelectCategoryId = cateId;
		this.MenuSubCatEdit();

	}

	protected void MenuSubCatRep_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
		//サブカテゴリの初期化
        foreach (RepeaterItem item in MenuSubCatRep.Items)
        {
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            LinkButton link = (LinkButton)item.FindControl("MenuSubCatLnk");
            link.CssClass = "a_menusubcate";
            //HtmlTableCell td = (HtmlTableCell)item.FindControl("MenuSubCatTd");
            //HtmlTableCell ltd = (HtmlTableCell)item.FindControl("MenuSubCatTdLeft");
            //HtmlTableCell rtd = (HtmlTableCell)item.FindControl("MenuSubCatTdRight");

            //td.Attributes.Add("onClick", "clickLink('" + item.ClientID + "_MenuSubCatLnk')");
            //ltd.Attributes.Add("onClick", "clickLink('" + item.ClientID + "_MenuSubCatLnk')");
            //rtd.Attributes.Add("onClick", "clickLink('" + item.ClientID + "_MenuSubCatLnk')");

            //td.Style["background"] = "url(Images/BizMenu/tab_off_back.jpg)";
            //ltd.Style["background"] = "url(Images/BizMenu/tab_off_left.jpg)";
            //rtd.Style["background"] = "url(Images/BizMenu/tab_off_right.jpg)";
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
        }
		//選択されたサブカテゴリのみイメージを変える
        // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
        LinkButton clicklink = (LinkButton)e.Item.FindControl("MenuSubCatLnk");
        clicklink.CssClass = "a_menusubcate top-tab-active";
        //HtmlTableCell ontd = (HtmlTableCell)e.Item.FindControl("MenuSubCatTd");
        //HtmlTableCell onltd = (HtmlTableCell)e.Item.FindControl("MenuSubCatTdLeft");
        //HtmlTableCell onrtd = (HtmlTableCell)e.Item.FindControl("MenuSubCatTdRight");

        //ontd.Attributes.Remove("onClick");
        //onltd.Attributes.Remove("onClick");
        //onrtd.Attributes.Remove("onClick");

        //ontd.Style["background"] = "url(Images/BizMenu/tab_on_back.jpg)";
        //onltd.Style["background"] = "url(Images/BizMenu/tab_on_left.jpg)";
        //onrtd.Style["background"] = "url(Images/BizMenu/tab_on_right.jpg)";
        // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start

		string subCateId = e.CommandArgument.ToString();
		this.SelectSubCategoryId = subCateId;
		this.MenuPgmEdit();

    }

	#endregion

	#region バインドイベント

	protected void MenuPgList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            //HtmlTableCell td = (HtmlTableCell)e.Item.FindControl("MenuPgTd");
            //td.Attributes.Add("onMouseOver", "overPg('" + e.Item.ClientID + "_MenuPgTd')");
            //td.Attributes.Add("onMouseOut", "outPg('" + e.Item.ClientID + "_MenuPgTd')");

            //td.Attributes.Add("onClick", "clickLink('" + e.Item.ClientID + "_MenuPgm1Lnk')");
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

			HtmlAnchor link = (HtmlAnchor)e.Item.FindControl("MenuPgm1Lnk");
			string functionViewId = Convert.ToString(DataBinder.GetPropertyValue(e.Item.DataItem, "ID"));
            DataTable dt = FunctionViewMst.GetFunctionView(Convert.ToString(ViewState["solutionId"]), functionViewId);
            if (dt.Rows.Count > 0)
            {
                string functionId = Convert.ToString(dt.Rows[0]["FUNCTION_ID"]);
                DataRow funcRow = FunctionMst.GetFunction(Convert.ToString(ViewState["solutionId"]), functionId);

                string funcUrl = Convert.ToString(funcRow["FUNCTION_URL"]);
                string funcName = Convert.ToString(funcRow["FUNCTION_NAME"]);
                string winName = Convert.ToString(funcRow["WINDOW_NAME"]);
                string winStyle = Convert.ToString(funcRow["WINDOW_STYLE"]);
                string funcPara = Convert.ToString(funcRow["FUNCTION_PARAMS"]);
                if (funcPara != "html")
                {
                    if (funcPara.IndexOf("APPLICATION") < 0)
                    {
                        if (winName != "_blank" && winName != "_self" && winName != "_top")
                        {
                            winName = Convert.ToString(ViewState["solutionId"]) + "_" + winName;
                        }
                        link.HRef = "javascript:openFunction('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "','" + winStyle + "','0','0');";
                    }
                    else
                    {
                        HttpContext.Current.Session.Add("PDF_FUNCTION_NAME", funcName);
                        HttpContext.Current.Session.Add("PDF_FUNCTION_URL", funcUrl);
                        HttpContext.Current.Session.Add("PDF_FUNCTION_PARAMS", funcPara);
                        link.HRef = "javascript:openFunctionPDF('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "')";
                    }
                }
                else
                {
                    link.HRef = "javascript:openFunction2('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "','" + winStyle + "','0','0','" + funcUrl + "');";
                }
            }
            else
            {
                throw new ApplicationException("機能階層表示情報取得に失敗しました。");
            }

		}
	}

	#endregion

	#region プライベートメソッド

	/// <summary>
	/// メニューカテゴリを表示する
	/// </summary>
	private void MenuCatRepEdit()
	{
		DataTable dt = mgr.GetCategoryDataSource();
		MenuCatRep.DataSource = dt;
		MenuCatRep.DataBind();

		//カテゴリの初期化処理
        for (int i = 0; i < MenuCatRep.Items.Count; ++i)
        {
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            LinkButton link = (LinkButton)MenuCatRep.Items[i].FindControl("MenuCatLnk");
            //HtmlTableCell td = (HtmlTableCell)MenuCatRep.Items[i].FindControl("MenuCatTd");
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
            if (i == 0)
            {
                // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                link.CssClass = "a_menucate top-stay";
                //td.Attributes.Remove("onMouseOver");
                //td.Attributes.Remove("onMouseOut");
                //td.Attributes.Remove("onClick");
                //td.Style["background"] = "url(Images/BizMenu/main_menu_btn_on.jpg)";
                // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
            }
            else
            {
                // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                link.CssClass = "a_menucate";
                //td.Attributes.Add("onMouseOver", "overCate('" + MenuCatRep.Items[i].ClientID + "_MenuCatTd')");
                //td.Attributes.Add("onMouseOut", "outCate('" + MenuCatRep.Items[i].ClientID + "_MenuCatTd')");
                //td.Attributes.Add("onClick", "clickLink('" + MenuCatRep.Items[i].ClientID + "_MenuCatLnk')");
                //td.Style["background"] = "url(Images/BizMenu/main_menu_btn_off.jpg)";
                // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
            }
        }

        if (dt.Rows.Count > 0)
        {
            string cateId = Convert.ToString(dt.Rows[0]["ID"]);
            this.SelectCategoryId = cateId;
            this.MenuSubCatEdit();
        }
	}


    /// <summary>
    /// メニューサブカテゴリを表示する。
    /// </summary>
    /// <param name="menucatID"></param>
    private void MenuSubCatEdit()
	{
		DataTable dt = mgr.GetSubCategoryDataSource(Convert.ToString(ViewState["solutionId"]), SelectCategoryId);
		MenuSubCatRep.DataSource = dt;
		MenuSubCatRep.DataBind();

		//サブカテゴリの初期化処理
        for (int i = 0; i < MenuSubCatRep.Items.Count; ++i)
        {
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            //HtmlTableCell td = (HtmlTableCell)MenuSubCatRep.Items[i].FindControl("MenuSubCatTd");
            //HtmlTableCell ltd = (HtmlTableCell)MenuSubCatRep.Items[i].FindControl("MenuSubCatTdLeft");
            //HtmlTableCell rtd = (HtmlTableCell)MenuSubCatRep.Items[i].FindControl("MenuSubCatTdRight");
            LinkButton link = (LinkButton)MenuSubCatRep.Items[i].FindControl("MenuSubCatLnk");
            //if (link.Text.Trim().Length > 0)
            //{
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
                if (i == 0)
                {
                    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                    link.CssClass = "a_menusubcate top-tab-active";
                    //td.Attributes.Remove("onClick");
                    //ltd.Attributes.Remove("onClick");
                    //rtd.Attributes.Remove("onClick");
                    //td.Style["background"] = "url(Images/BizMenu/tab_on_back.jpg)";
                    //ltd.Style["background"] = "url(Images/BizMenu/tab_on_left.jpg)";
                    //rtd.Style["background"] = "url(Images/BizMenu/tab_on_right.jpg)";
                    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
                }
                else
                {
                    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                    link.CssClass = "a_menusubcate";
                    //td.Attributes.Add("onClick", "clickLink('" + MenuSubCatRep.Items[i].ClientID + "_MenuSubCatLnk')");
                    //ltd.Attributes.Add("onClick", "clickLink('" + MenuSubCatRep.Items[i].ClientID + "_MenuSubCatLnk')");
                    //rtd.Attributes.Add("onClick", "clickLink('" + MenuSubCatRep.Items[i].ClientID + "_MenuSubCatLnk')");
                    //td.Style["background"] = "url(Images/BizMenu/tab_off_back.jpg)";
                    //ltd.Style["background"] = "url(Images/BizMenu/tab_off_left.jpg)";
                    //rtd.Style["background"] = "url(Images/BizMenu/tab_off_right.jpg)";
                    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
                }
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            //}
            //else
            //{
            //    //SUBCATで名称が空白なら非表示をセット
            //    td.Style["background"] = "url(img/insidemenu/)";
            //    ltd.Style["background"] = "url(img/insidemenu/)";
            //    rtd.Style["background"] = "url(img/insidemenu/)";
            //}
            // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

        }

        if (dt.Rows.Count > 0)
        {
            string subCateId = Convert.ToString(dt.Rows[0]["ID"]);
            this.SelectSubCategoryId = subCateId;
            this.MenuPgmEdit();
        }
	}

	/// <summary>
	/// プログラムを表示する。
	/// </summary>
	/// <param name="subcateID"></param>
	private void MenuPgmEdit()
	{
		ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
		infoVo.LoginId = LoginUserContext.LoginId;
		bool oprCheckFlg = false;
		if (!LoginMst.CheckLoginAvailableOperation(infoVo, LoginUserContext.LoginId, LoginUserContext.UserType))
		{
			oprCheckFlg = true;
		}

		string cateID = this.SelectCategoryId;
		string subcateID = this.SelectSubCategoryId;
		DataTable dt = mgr.GetProgramDataSource(Convert.ToString(ViewState["solutionId"]), SelectCategoryId, SelectSubCategoryId, oprCheckFlg);
		MenuPgList.DataSource = dt;
		MenuPgList.DataBind();
	}

	private string SelectCategoryId
	{
		get
		{
			return Convert.ToString(ViewState["SelectCategoryId"]);
		}
		set
		{
			ViewState.Add("SelectCategoryId", value);
		}
	}

	private string SelectSubCategoryId
	{
		get
		{
			return Convert.ToString(ViewState["SelectSubCategoryId"]);
		}
		set
		{
			ViewState.Add("SelectSubCategoryId", value);
		}
	}

    #endregion


    protected void lbMdMenu_Click(object source, EventArgs e)
    {
        Response.Write(@"<script language='javascript'>alert('Click Button!')</script>");
    }

}
