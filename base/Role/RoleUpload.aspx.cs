// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Xml;
using System.Xml.Schema;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Text;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using System.Reflection;
using Com.Fujitsu.SmartBase.Base.DataLog;
using Fsol.QuiQplus.Common.Check.Charcode;

/// <summary>
/// ロールをＸＭＬファイルでアップロードするコードビハインドです。
/// </summary>
public partial class Role_RoleUpload : System.Web.UI.Page
{
    private static bool xsdErrorFlag;
    private static string xsdErrorMessage;

    /// <summary>
    /// ロールをＸＭＬファイルでアップロードする画面です。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        BusinessErrorMessage.Visible = false;
        BusinessMessage.Visible = false;
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
        FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleUpload");

        //標題をセットする
        Programtitle.Text = resource.GetString("Programtitle");
        Formtitle.Text = resource.GetString("Formtitle");
        XmlLbl.Text = resource.GetString("XmlLbl");
        UploadBtn.Text = resource.GetString("UploadBtn");
        BackBtn.Text = resource.GetString("BackBtn");
        #endregion
    }

    /// <summary>
    /// ロールのテンプレートをアップロードします。
    /// ＸＭＬファイルの読み込み、ＸＳＤチェックを行い、
    /// データを読み込んでデータベースに格納します。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UploadBtn_Click(object sender, EventArgs e)
    {
        HttpPostedFile posted = Request.Files["UserFile"];
        XmlReader roleFileReader = null;
        string xmlStr = null;

        string ext = Path.GetExtension(posted.FileName);
        if (ext.ToLower() != ".xml")
        {
            //エラー
            BusinessErrorMessage.Text = "有効なXMLファイルを選択してください。";
            BusinessErrorMessage.Visible = true;
            return;
        }

        FileInfo xsdFile =
            new FileInfo(string.Format(@"{0}bin\roleSchema.xsd", Request.PhysicalApplicationPath));

        using (StreamReader sr = new StreamReader(posted.InputStream, Encoding.UTF8))
        {
            xmlStr = sr.ReadToEnd();
        }

        //4バイト文字列チェック
        if (InhibitionCharacterCheck.Contains(xmlStr))
        {
            //エラー
            BusinessErrorMessage.Text = "ファイルに無効な文字が含まれています。";
            BusinessErrorMessage.Visible = true;
            return;
        }

        #region XSDチェック
        // ＸＳＤで構成が正しいかどうかチェック

        if (CheckRoleTemplateFileByXSD(xsdFile, xmlStr))
        {
            // 正しくなかったらリターン
            return;
        }

        #endregion

        #region XMLファイルをパースして情報を登録

        TextReader tr = new StringReader(xmlStr);
        try
        {
            LoginUserInfoVO loginInfo = new LoginUserInfoVO();
            loginInfo.LoginId = LoginUserContext.LoginId;

            roleFileReader = XmlReader.Create(tr);
            XmlDocument roleFileDoc = new XmlDocument();

            // ロールテンプレートファイルのロード
            roleFileDoc.Load(roleFileReader);

            // ここにコメント文の削除機構を追加

            // ロール情報を取得する
            XmlNodeList roleElements =
                roleFileDoc.GetElementsByTagName("role");

            if (roleElements != null && roleElements.Count > 0)
            {
                foreach (XmlNode roleElement in roleElements)
                {
                    // VOリスト
                    List<SystemAuthorizationVO> systemAuthVOList = new List<SystemAuthorizationVO>();
                    List<FunctionAuthorizationVO> funcAuthVOList = new List<FunctionAuthorizationVO>();

                    RoleVO roleVO = new RoleVO();
                    // ロールIDの取得
                    XmlNodeList roleIdList = ((XmlElement)roleElement).GetElementsByTagName("id");
                    if (roleIdList.Count > 0)
                    {
                        string roleId = roleIdList[0].InnerText;
                        roleVO.RoleId = roleId;
                    }

                    // ロール名の取得
                    XmlNodeList roleNameList = ((XmlElement)roleElement).GetElementsByTagName("name");
                    string roleName = roleNameList[0].InnerText;
                    roleVO.RoleName = roleName;

                    // 備考情報の取得
                    XmlNodeList roleNoteList = ((XmlElement)roleElement).GetElementsByTagName("note");
                    string roleNote = null;
                    if (roleNoteList != null && roleNoteList.Count > 0 && roleNoteList[0].InnerText.Length != 0)
                    {
                        roleNote = roleNoteList[0].InnerText;
                    }
                    roleVO.RoleNote = roleNote;

                    // 権限情報を取得する
                    XmlNodeList authorizationList = ((XmlElement)roleElement).GetElementsByTagName("authorization");
                    int count = 0;
                    if (authorizationList != null && authorizationList.Count > 0)
                    {
                        foreach (XmlNode authorizationNode in authorizationList)
                        {
                            FunctionAuthorizationVO funcAuthVO = new FunctionAuthorizationVO();
                            string solutionId = authorizationNode.Attributes["solution_id"].Value;
                            string functionId = authorizationNode.Attributes["function_id"].Value;
                            foreach (FunctionAuthorizationVO fvo in funcAuthVOList)
                            {
                                if (solutionId == fvo.SolutionId)
                                {
                                    count++;
                                }
                            }
                            if (count > 0)
                            {
                                count = 0;
                            }
                            else
                            {
                                SystemAuthorizationVO systemAuthVO = new SystemAuthorizationVO();
                                systemAuthVO.SolutionId = solutionId;
                                systemAuthVO.SortNo = 0;
                                systemAuthVOList.Add(systemAuthVO);
                            }
                            funcAuthVO.SolutionId = solutionId;
                            funcAuthVO.FunctionId = functionId;
                            funcAuthVOList.Add(funcAuthVO);
                        }
                    }

                    RoleService rs = new RoleService(loginInfo);
                    SystemAuthorizationVO[] systemAuthVOArray = new SystemAuthorizationVO[systemAuthVOList.Count];
                    FunctionAuthorizationVO[] funcAuthVOArray = new FunctionAuthorizationVO[funcAuthVOList.Count];
                    systemAuthVOList.CopyTo(systemAuthVOArray);
                    funcAuthVOList.CopyTo(funcAuthVOArray);
                    Result res = rs.InsertRole(roleVO, systemAuthVOArray, funcAuthVOArray);

                    if (!res.IsSuccess && res.HasError && res.Errors[0] is DBConcurrencyError)
                    {
                        // 排他エラー
                        MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                        BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
                        BusinessErrorMessage.Visible = true;
                        return;
                    }
                    else if (!res.IsSuccess && res.HasError && res.Errors[0] is BusinessError)
                    {
                        //業務ロジックエラー
                        MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
                        BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
                        BusinessErrorMessage.Visible = true;
                        return;

                    }
                    else if (!res.IsSuccess)
                    {
                        throw new ApplicationException("ロール情報のアップデートに失敗しました。" + res.ToString());
                    }
                }
                BusinessMessage.Text = "ロールテンプレートのアップロードに成功しました。";
                BusinessMessage.Visible = true;
            }
        }
        catch
        {
            BusinessMessage.Text = "予期せぬエラーが発生しました。";
            BusinessMessage.Visible = true;
        }
        finally
        {
            if (roleFileReader != null)
            {
                roleFileReader.Close();
            }
        }

        #endregion

    }

    /// <summary>
    /// 戻るボタンクリック時のイベント
    /// ここではロール一覧画面に戻る
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("RoleList.aspx");
    }

    #region ValidationEventHandler

    private static void XsdSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("StartSetup#xsdSettingsValidationEventHandler 警告: ");
            Console.WriteLine(e.Message);
            xsdErrorMessage = e.Message;
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("StartSetup#xsdSettingsValidationEventHandler エラー: ");
            Console.WriteLine(e.Message);
            xsdErrorMessage = e.Message;
        }
        Role_RoleUpload.xsdErrorFlag = true;
    }

    #endregion

    #region private

    /// <summary>
    /// ロールテンプレートアップロードファイルが正しい構文かチェックします。
    /// XMLの構文が正しければfalse, 正しくなければtrueを返します。
    /// </summary>
    /// <param name="xsdFile">XSDファイル情報</param>
    /// <param name="xmlStr">ロールテンプレートアップロードファイルのXML文字列</param>
    /// <returns>
    /// true or false
    /// XMLの構文が正しければfalse, 構文が正しくなければtrue
    /// </returns>
    private bool CheckRoleTemplateFileByXSD(FileInfo xsdFile, string xmlStr)
    {
        #region XSDチェック
        // ＸＳＤで構成が正しいかどうかチェック
        XmlReader roleFileReader = null;
        TextReader tr = new StringReader(xmlStr);

        using (Stream schemaStream = new FileStream(xsdFile.FullName, FileMode.Open, FileAccess.Read)
                        )
        {
            try
            {
                XmlReaderSettings readerSettings = new XmlReaderSettings();
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                XmlSchema schema = XmlSchema.Read(schemaStream, null);
                schemaSet.Add(schema);
                readerSettings.Schemas = schemaSet;
                readerSettings.ValidationType = ValidationType.Schema;
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                readerSettings.ValidationEventHandler += new ValidationEventHandler(XsdSettingsValidationEventHandler);

                roleFileReader = XmlReader.Create(tr, readerSettings);

                while (roleFileReader.Read())
                {
                }

                if (xsdErrorFlag)
                {
                    BusinessErrorMessage.Text = "ロールテンプレートのアップロードに失敗しました。XMLを正しく記述してください。";
                    BusinessErrorMessage.Visible = true;
                    xsdErrorFlag = false;
                    return true;
                }
            }
            catch
            {
                BusinessErrorMessage.Text = "ロールテンプレートのアップロードに失敗しました。XMLを正しく記述してください。";
                BusinessErrorMessage.Visible = true;
                xsdErrorFlag = false;
                return true;
            }
            finally
            {
                if (roleFileReader != null)
                {
                    roleFileReader.Close();
                }
                if (schemaStream != null)
                {
                    schemaStream.Close();
                }
            }
        }

        #endregion

        return false;
    }

    #endregion
}
