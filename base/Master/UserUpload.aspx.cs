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
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Data.SqlClient;
using System.IO;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Fsol.QuiQplus.Common.Check.Charcode;
using Com.Fujitsu.SmartBase.Base.Common.Config;

public partial class Master_UserUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BusinessErrorMessage.Visible = false;
        BusinessMessage.Visible = false;
        ListBox.Text = "";
    }
    /// <summary>
    /// フォームのデータを表示する。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        #region 標題セット
        //リソース取得
        FormResource resource = ResourceManager.GetInstance().GetFormResource("UserUpload");

        //標題をセットする
        Programtitle.Text = resource.GetString("Programtitle");
        Formtitle.Text = resource.GetString("Formtitle");
        CsvLbl.Text = resource.GetString("CsvLbl");
        UploadBtn.Text = resource.GetString("UploadBtn");
        BackBtn.Text = resource.GetString("BackBtn");
        #endregion 
    }

    protected void UploadBtn_Click(object sender, System.EventArgs e)
    {
        HttpPostedFile posted = Request.Files["UserFile"];

        string ext = Path.GetExtension(posted.FileName);
        
        if (ext.ToLower() != ".csv")
        {
            //エラー
            BusinessErrorMessage.Text = "有効なCSVファイルを選択してください。";
            BusinessErrorMessage.Visible = true;
            return;
        }

        if (!string.IsNullOrEmpty(posted.FileName))
        {
            string csv;

            using (StreamReader sr = new StreamReader(posted.InputStream, Encoding.GetEncoding(932)))
            {
                csv = sr.ReadToEnd();

                if (!csv.EndsWith("\r\n"))
                {
                    csv = csv + "\r\n";
                }
            }

            //4バイト文字列チェック
            if (InhibitionCharacterCheck.Contains(csv))
            {
                //エラー
                BusinessErrorMessage.Text = "ファイルに無効な文字が含まれています。";
                BusinessErrorMessage.Visible = true;
                return;
            }

            LoginUserInfoVO infoVO = new LoginUserInfoVO();
            infoVO.LoginId = LoginUserContext.LoginId;
            LoginUserService service = new LoginUserService(infoVO);

            StringBuilder msg = new StringBuilder();

            DataTable dt = CsvUtil.ConvertDataTable(csv);
            if(!dt.Columns.Contains("LOGIN_ID"))
            {
                msg.AppendLine("CSVファイルにはLOGIN_ID列が存在しません。");
            }
            if (!dt.Columns.Contains("PASSWORD"))
            {
                msg.AppendLine("CSVファイルにはPASSWORD列が存在しません。");
            }
            if (!dt.Columns.Contains("NAME"))
            {
                msg.AppendLine("CSVファイルにはNAME列が存在しません。");
            }
            if (!dt.Columns.Contains("COMPANY_ID"))
            {
                msg.AppendLine("CSVファイルにはCOMPANY_ID列が存在しません。");
            }
            if (dt == null)
            {
                BusinessErrorMessage.Text = "有効なCSVファイルを選択してください。";
                BusinessErrorMessage.Visible = true;
                return;
            }


            // 入力チェック
            List<LoginUserVO> vos;
            List<RoleUserMapVO> maps;
            LoginUploadUtil.ConvertLoginTableToVO(dt, ref msg, out vos, out maps);

            if (msg.ToString().Length != 0)
            {
                ListBox.Text = msg.ToString();
                BusinessErrorMessage.Text = "利用者情報の一括登録は失敗しました。";
                BusinessErrorMessage.Visible = true;
                return;
            }
            else
            {
                #region 登録、更新
                Result res = null;
                if (dt.Columns.Contains("ROLE_MAPPING"))
                    res = service.InsertLoginUser(vos.ToArray(), maps.ToArray(), UploadTypeRdb.SelectedValue == "Update");
                else
                    res = service.InsertLoginUser(vos.ToArray(), UploadTypeRdb.SelectedValue == "Update");

                if (!res.IsSuccess)
                {
                    if (res.HasError)
                    {
                        // 排他エラー.ビジネスロジックエラー
                        MessageResource resource = ResourceManager.GetInstance().GetMessageResource();

                        foreach (Error error in res.Errors)
                        {
                            msg.AppendLine(error.Message);
                        }
                        ListBox.Text = msg.ToString();
                        BusinessErrorMessage.Text = "利用者情報の一括登録は失敗しました。";
                        BusinessErrorMessage.Visible = true;
                        return;
                    }
                    else
                    {
                        ListBox.Text = msg.ToString();
                        BusinessErrorMessage.Text = "利用者情報の一括登録は失敗しました。";
                        BusinessErrorMessage.Visible = true;
                        return;
                    }
                }
                else
                {
                    BusinessMessage.Text = "利用者情報の一括登録は成功しました。";
                    BusinessMessage.Visible = true;
                    return;
                }

                #endregion
            }
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("LoginUser01.aspx");
    }
}
