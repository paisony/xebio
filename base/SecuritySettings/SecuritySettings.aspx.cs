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
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Com.Fujitsu.SmartBase.Base.Common.Config;

public partial class SecurityPolicy_SecuritySettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BusinessMessage.Visible = false;

        if (!Page.IsPostBack)
        {
            SecurityPolicyService service = new SecurityPolicyService();
            //データ取得
            DataResult<DataTable> res = service.GetSecuritySettings();
            //エラー処理
            if (!res.IsSuccess)
            {
                throw new ApplicationException("情報取得に失敗しました。");
            }

            #region 標題セット
            //リソース取得
            FormResource resource = ResourceManager.GetInstance().GetFormResource("SecuritySettings");

            //標題をセットする
            Programtitle.Text = resource.GetString("Programtitle");
            Formtitle.Text = resource.GetString("Formtitle");
            UpdateBtn.Text = resource.GetString("UpdateBtn");

            M1.Columns[2].HeaderText = resource.GetString("M1_SETTING_NAME");
            M1.Columns[3].HeaderText = resource.GetString("M1_SETTING_NOTE");
            M1.Columns[4].HeaderText = resource.GetString("M1_SETTING_VALUE");

            #endregion

            M1.DataSource = res.ResultData;
            M1.DataBind();
        }
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        //更新処理
        foreach (GridViewRow row in M1.Rows)
        {
            string settingKey = ((Label)row.FindControl("GridSettingKeyLbl")).Text;
            string settingValue = null;

            TextBox valueBox = (TextBox)row.FindControl("GridSettingValueBox");            
            if (valueBox.Visible)
                settingValue = valueBox.Text;
            else
                settingValue = ((DropDownList)row.FindControl("GridSettingValueDDL")).SelectedValue;

            SystemSettings.SecuritySettings.Settings[settingKey].Value = settingValue;
        }

        //保存
        SystemSettings.Save();
        
        BusinessMessage.Text = "セキュリティ設定を更新しました。";
        BusinessMessage.Visible = true;

        //データ取得
        SecurityPolicyService service = new SecurityPolicyService();
        DataResult<DataTable> settingRes = service.GetSecuritySettings();
        //エラー処理
        if (!settingRes.IsSuccess)
        {
            throw new ApplicationException("セキュリティ設定の取得に失敗しました。");
        }
        M1.DataSource = settingRes.ResultData;
        M1.DataBind();
    }

    //protected void SettingValid_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    args.IsValid = true;
    //    //SettingValid.ErrorMessage = string.Empty;

    //    //StringBuilder sb = new StringBuilder();

    //    //foreach (GridViewRow row in M1.Rows)
    //    //{
    //    //    string settingValue = ((TextBox)row.FindControl("GridSettingValueBox")).Text;
    //    //    string regexp = ((Label)row.FindControl("GridSettingValidRegExpLbl")).Text;
    //    //    string settingName = ((Label)row.FindControl("GridSettingNameLbl")).Text;

    //    //    if (!Regex.IsMatch(settingValue, regexp))
    //    //    {
    //    //        args.IsValid = false;
    //    //        sb.AppendLine(string.Format(@"{0}の設定値が不正です。", settingName));
    //    //    }
    //    //}
    //    //SettingValid.ErrorMessage = sb.ToString();
    //}
    protected void M1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string selectionItem = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SETTING_CONDITION"));
            string settingKey = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SETTING_KEY"));

            RegularExpressionValidator regValid = (RegularExpressionValidator)e.Row.FindControl("RegexValid");
            RequiredFieldValidator reqValid = (RequiredFieldValidator)e.Row.FindControl("ReqValid");
            TextBox textBox = (TextBox)e.Row.FindControl("GridSettingValueBox");

            //設定値
            string settingValue = SystemSettings.SecuritySettings.Settings[settingKey].Value;

            if (string.IsNullOrEmpty(selectionItem))
            {
                string settingName = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SETTING_NAME"));
                string regex = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SETTING_VALID_REGEXP"));
                
                regValid.ValidationExpression = regex;
                regValid.ErrorMessage = string.Format(@"{0}の設定値が不正です。", settingName);
                reqValid.ErrorMessage = string.Format(@"{0}の設定値を入力してください。", settingName);
                textBox.Text = settingValue;
            }
            else
            {
                regValid.Visible = false;
                reqValid.Visible = false;
                textBox.Visible = false;
                DropDownList ddl = (DropDownList)e.Row.FindControl("GridSettingValueDDL");
                ddl.Visible = true;

                string[] items = selectionItem.Split('|');
                foreach (string item in items)
                {
                    string itemText = item.Substring(0, item.IndexOf('('));
                    string itemValue = item.Substring(item.IndexOf('(') + 1, item.Length - item.IndexOf('(') - 2);
                    ddl.Items.Add(new ListItem(itemText, itemValue));
                }
                ddl.SelectedValue = settingValue;
            }
        }
    }

    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        SecurityPolicyService service = new SecurityPolicyService();
        //データ取得
        DataResult<DataTable> res = service.GetSecuritySettings();
        //エラー処理
        if (!res.IsSuccess)
        {
            throw new ApplicationException("情報取得に失敗しました。");
        }

        //設定値取得
        DataTable dt = res.ResultData;

        foreach (GridViewRow row in M1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label keyLbl = (Label)row.FindControl("GridSettingKeyLbl");
                string key = keyLbl.Text;

                DataRow[] settingRows = dt.Select(string.Format("SETTING_KEY = '{0}'", key));
                TextBox textBox = (TextBox)row.FindControl("GridSettingValueBox");
                if (textBox.Visible)
                {
                    textBox.Text = Convert.ToString(settingRows[0]["SETTING_DEFAULT_VALUE"]);
                }
                else
                {
                    DropDownList ddl = (DropDownList)row.FindControl("GridSettingValueDDL");
                    ddl.SelectedValue = Convert.ToString(settingRows[0]["SETTING_DEFAULT_VALUE"]);
                }
            }
        }
    }
}
