// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2015/09/16 FSWeb)Y.Tamura 新規作成

using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Web.BizMenu;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Common_BoMenu : System.Web.UI.Page
{
    private BizMenuManager mgr;

    /// <summary>
    /// メニューの画面データを作成する。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // クッキーからsolutionIdとメニュー用のfunctionViewIdを取得
            string solutionId = HttpContext.Current.Request.Cookies["LoginSolutionID"].Value;
            string functionViewId = HttpContext.Current.Request.Cookies["MenuFunctionViewId"].Value;

            // ViewStateに値を追加
            ViewState.Add("solutionId", solutionId);
            ViewState.Add("functionViewId", functionViewId);

            // BizMenuManagerの呼び出しとセッションへの格納
            mgr = new BizMenuManager(solutionId, functionViewId);
            SessionManager.SetObject(mgr, "BoMenuManager", "BoMenu");

            // メニューの第一階層の画面データを作成
            this.MenuCatRepEdit();
        }
        else
        {
            // セッションからBizMenuManagerを取得
            mgr = (BizMenuManager)SessionManager.GetObject("BoMenuManager", "BoMenu");
        }


    }
    #region ボタンイベント

    /// <summary>
    /// メニュー第一階層押下時のイベント
    /// </summary>
    /// <param name="source">object</param>
    /// <param name="e">RepeaterCommandEventArgs</param>
    protected void MenuCatRep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //選択されたカテゴリがアクティブかどうかのフラグ
        var activeFlg = false;
        LinkButton clicklink = (LinkButton)e.Item.FindControl("MenuCatLnk");
        
        //押されたメニューがアクティブならフラグにセット
        if (clicklink.CssClass.Contains("open-close-menu-cont-active"))
        {
            activeFlg = true;
        }

        //メニュカテゴリの初期化
        foreach (RepeaterItem item in MenuCatRep.Items)
        {
            LinkButton linkButton = (LinkButton)item.FindControl("MenuCatLnk");
            linkButton.CssClass = "a_menucate";
        }

        //選択されたカテゴリのみイメージを変える
        if (activeFlg)
        {
            Menu2nd.Visible = false;
        }
        else
        {
            Menu2nd.Visible = true;
            clicklink.CssClass = "a_menucate open-close-menu-cont-active";
        }
        string cateId = e.CommandArgument.ToString();
        this.SelectCategoryId = cateId;

        //メニューのサブカテゴリのデータを作成
        this.MenuSubCatEdit();
    }

    #endregion

    #region バインドイベント

    /// <summary>
    /// メニューの第二階層のバインドイベント
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">DataListItemEventArgs</param>
    protected void MenuPgList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            HtmlAnchor link = (HtmlAnchor)e.Item.FindControl("MenuPgm1Lnk");
            string functionViewId = Convert.ToString(DataBinder.GetPropertyValue(e.Item.DataItem, "ID"));

            // プログラムデータを取得する
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
                            // ウィンドウ名を設定
                            winName = Convert.ToString(ViewState["solutionId"]) + "_" + winName;
                        }
                        // 通常の業務メニューを開くjavascriptをセット
                        link.HRef = "javascript:openFunction('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "','" + winStyle + "','0','0');";
                    }
                    else
                    {
                        HttpContext.Current.Session.Add("PDF_FUNCTION_NAME", funcName);
                        HttpContext.Current.Session.Add("PDF_FUNCTION_URL", funcUrl);
                        HttpContext.Current.Session.Add("PDF_FUNCTION_PARAMS", funcPara);
                        // PDFメニューを開くjavascriptをセット
                        link.HRef = "javascript:openFunctionPDF('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "')";
                    }
                }
                else
                {
                    // htmlのリンクを開くjavascriptをセット
                    link.HRef = "javascript:openFunction2('" + Convert.ToString(ViewState["solutionId"]) + "','" + functionId + "','" + winName + "','" + winStyle + "','0','0','" + funcUrl + "');";
                }
            }
            else
            {
                // プログラムデータが存在しない場合、Exceptionをスロー
                throw new ApplicationException("機能階層表示情報取得に失敗しました。");
            }

        }
    }

    #endregion

    #region プライベートメソッド

    /// <summary>
    /// メニューカテゴリデータを作成する。
    /// </summary>
    private void MenuCatRepEdit()
    {
        // 第一階層のデータを全て取得する。
        DataTable dt = mgr.GetCategoryDataSource();
        MenuCatRep.DataSource = dt;
        MenuCatRep.DataBind();

    }

    /// <summary>
    /// メニューサブカテゴリを取得する
    /// </summary>
    private void MenuSubCatEdit()
    {
        DataTable dt = mgr.GetSubCategoryDataSource(Convert.ToString(ViewState["solutionId"]), SelectCategoryId);

        //第一階層に所属するサブカテゴリIDを全て取得する
        if (dt.Rows.Count > 0)
        {
            string[] subCateIds = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                subCateIds[i] = Convert.ToString(dt.Rows[i]["ID"]);
            }

            //プログラムデータを作成する。
            this.MenuPgmEdit(subCateIds);
        }
    }

    /// <summary>
    /// プログラムデータを作成する。
    /// </summary>
    /// <param name="subCateIds">サブカテゴリID</param>
    private void MenuPgmEdit(string[] subCateIds)
    {
        //ログイン情報を取得する。
        ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
        infoVo.LoginId = LoginUserContext.LoginId;

        //運用時間内かチェックする。
        bool oprCheckFlg = false;
        if (!LoginMst.CheckLoginAvailableOperation(infoVo, LoginUserContext.LoginId, LoginUserContext.UserType))
        {
            oprCheckFlg = true;
        }
        string cateID = this.SelectCategoryId;

        // プログラムデータを取得する。
        DataTable dt = mgr.GetProgramDataSource2(Convert.ToString(ViewState["solutionId"]), SelectCategoryId, subCateIds, oprCheckFlg);
        MenuPgList.DataSource = dt;
        MenuPgList.DataBind();
    }

    /// <summary>
    /// カテゴリIDのアクセサ
    /// </summary>
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

    #endregion

}
