<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginUser03.aspx.cs" Inherits="UserMst_Confirm" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>利用者管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="LoginUser03" runat="server" onprerender="RenderForm">
        <table height="100%" width="100%">
            <tr>
                <td height="100%" width="100%">
                    <div style="height: 100%; overflow: auto; width: 100%;">
                        <table width="100%">
                            <tr>
                                <td valign="top">
                                    <%--- タイトル表示 ---%>
                                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                    <table class="TABLE_PGTITLE">
                                        <tr>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                                            </td>
                                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                                <cc:EncodedLabel ID="Programtitle" runat="server">利用者管理</cc:EncodedLabel>
                                            </td>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                                            </td>
                                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
                                            </td>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_5.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="95px" />
                                            </td>
                                            <td align="right" style="width: 75px">
                                            </td>
                                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                                        </tr>
                                    </table>
                                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                    <table class="TABLE_FRMTITLE">
                                        <tr>
                                            <td style="height: 18px">
                                                <img src="../Common/Images/point.gif" alt="point" />
                                                <cc:EncodedLabel ID="Formtitle" runat="server">利用者情報確認</cc:EncodedLabel>
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%--- Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます ---%>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                                <cc:EncodedLabel ID="BusinessErrorMessage" runat="server" Visible="False" ForeColor="Red"></cc:EncodedLabel>
                                                <%--- Web ページ上の検証コントロール ---%>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%-------------------------------------------------------------------
										1.カード部
										---------------------------------------------------------------------%>
                                                <table class="TABLE_ARTICLE">
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2" width="30%">
                                                            <cc:EncodedLabel ID="LoginIdMenuLbl" runat="server">ログインID</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" width="70%">
                                                            <%--- 「ログインid」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="LoginIdLbl" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="PasswordMenuLbl1" runat="server">パスワード</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「パスワード」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="PasswordLbl1" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="PasswordMenuLbl2" runat="server">パスワード確認</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「パスワード確認」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="PasswordLbl2" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="UsernameMenuLbl" runat="server">利用者名</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「名前」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="UserNameLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="KanaMenuLbl" runat="server">利用者名カナ</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「利用者名カナ」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="KanaLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                     <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="EmployeeCodeMenuLbl" runat="server">社員コード</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「社員コード」一行テキストボックス（英数記号のみ） ---%>
                                                            <cc:EncodedLabel ID="EmployeeCodeLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="CompanyMenuLbl" runat="server">会社</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- 「会社」一行テキストボックス（セパレート日付以外） ---%>
                                                            <cc:EncodedLabel ID="CompanyLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE_BTN">
                                                        <td class="TD_ARTICLE_BTN">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN">
                                                            <asp:Button ID="ConfirmBtn" runat="server" Text="確定" CausesValidation="False" OnClick="ConfirmBtn_Click" />
                                                            <asp:Button ID="CancelBtn" runat="server" Text="訂正" CausesValidation="False" OnClick="ReBtn_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <tr>
                                                    <td valign="bottom">
                                                        <uc:Footer ID="footer" runat="server"></uc:Footer>
                                                    </td>
                                                </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
