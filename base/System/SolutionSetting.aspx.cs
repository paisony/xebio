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
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.Common.Util;

public partial class System_SolutionSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BusinessMessage.Visible = false;

        if (!Page.IsPostBack)
        {
            SystemService service = new SystemService();
            //データ取得
            DataResult<DataTable> res = service.GetAllSolutionAndSubSystem();
            //エラー処理
            if (!res.IsSuccess)
            {
                throw new ApplicationException("情報検索に失敗しました。");
            }

            #region 標題セット
            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("SolutionSetting");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            ConfirmBtn.Text = resource.GetString("ConfirmBtn");

            M1.Columns[2].HeaderText = resource.GetString("M1_SOLUTION_NAME");
            M1.Columns[3].HeaderText = resource.GetString("M1_SUBSYSTEM_NAME");
            M1.Columns[4].HeaderText = resource.GetString("M1_SERVER_URL");

            #endregion

            M1.DataSource = res.ResultData;
            M1.DataBind();
        }

    }
    
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        SystemService service1 = new SystemService();

        //更新処理
        List<SubsystemVO> vos = new List<SubsystemVO>();
        foreach (GridViewRow row in M1.Rows)
        {
            SubsystemVO vo = new SubsystemVO();

            vo.SolutionId = ((Label)row.FindControl("SolutionIdLbl")).Text;
            vo.SubsystemId = ((Label)row.FindControl("SubSystemIdLbl")).Text;
            string host = ((TextBox)row.FindControl("GridHostBox")).Text;
            string dir = ((TextBox)row.FindControl("GridDirBox")).Text;
            vo.ServerUrl = host + dir;

            vos.Add(vo);
        }
       
        Result res3 = service1.UpdateSubSystem(vos.ToArray());
        //エラー処理
        if (!res3.IsSuccess)
        {
            throw new ApplicationException("URLの更新に失敗しました。");
        }
        else
        {
            BusinessMessage.Text = "URLの更新が成功しました。";
            BusinessMessage.Visible = true;
        }  

        //キャッシュクリア
        SolutionMst.ClearCache();

        SystemService service2 = new SystemService();

        //データ取得
        DataResult<DataTable> res2 = service2.GetAllSolutionAndSubSystem();
        //エラー処理
        if (!res2.IsSuccess)
        {
            throw new ApplicationException("情報検索に失敗しました。");
        }
        M1.DataSource = res2.ResultData;
        M1.DataBind();

    }
   
    protected void UrlValid_ServerValidate(object source, ServerValidateEventArgs args)
    {
        foreach (GridViewRow row in M1.Rows)
        {
            if (row.Enabled)
            {
                string host = ((TextBox)row.FindControl("GridHostBox")).Text;
                string dir = ((TextBox)row.FindControl("GridDirBox")).Text;

                if (!string.IsNullOrEmpty(host))
                {
                    //正規表現でチェック
                    if (Regex.IsMatch(host, "^https?://([-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+)$"))
                    {
                        //ホスト以外が指定されている場合はエラー
                        Uri uri = new Uri(host);
                        if (host.ToLower() == string.Format(@"{0}://{1}", uri.Scheme, uri.Authority).ToLower())
                        {
                            //入力チェック成功
                            args.IsValid = true;
                        }
                        else
                        {
                            //失敗
                            args.IsValid = false;
                            return;
                        }

                    }
                    else
                    {
                        //失敗
                        args.IsValid = false;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(dir))
                {
                    //正規表現でチェック
                    if (Regex.IsMatch(dir, "^[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+/$"))
                    {
                        //入力チェック成功
                        args.IsValid = true;
                    }
                    else
                    {
                        //失敗
                        args.IsValid = false;
                        return;
                    }
                }
                else
                {
                    //失敗
                    args.IsValid = false;
                    return;
                }
            }
        }
    }

    protected void M1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SUBSYSTEM_TYPE"));
            if (type == ConstantUtil.SUBSYSTEM_TYPE_WEB || type == ConstantUtil.SUBSYSTEM_TYPE_CLICKONCE)
            {
                string url = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SERVER_URL"));
                
                TextBox hostBox = (TextBox)e.Row.FindControl("GridHostBox");
                TextBox dirBox = (TextBox)e.Row.FindControl("GridDirBox");
                Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);

                if (uri.IsAbsoluteUri)
                {
                    hostBox.Text = string.Format(@"{0}://{1}", uri.Scheme, uri.Authority);
                    dirBox.Text = string.Format(@"{0}", uri.AbsolutePath);
                }
                else
                {
                    dirBox.Text = uri.OriginalString;
                }
            }
            else
                e.Row.Enabled = false;

        }
    }
}
