<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleMappingOutput.aspx.cs" Inherits="access_RoleMappingOutput" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="head1" runat="server">
    <title>ロール付与状況出力</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
        <table width="100%" height="100%">
            <tr>
                <td valign="top" style="width: 1087px">
                    <%--- タイトル表示 ---%>
                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_PGTITLE">
                        <tr>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                <cc:EncodedLabel ID="Programtitle" runat="server">アクセス管理</cc:EncodedLabel>
                            </td>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)" align="right">
                                <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" Text="戻る" Width="50px"/>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
                            </td>
                            <td align="right" style="width: 75px">
                            </td>
                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                        </tr>
                    </table>
                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_FRMTITLE">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">ロール付与状況出力</cc:EncodedLabel>
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
                </td>
            </tr>
            <tr>
                <td height="100%" valign="top" style="width: 1087px">
                    <table width="100%" height="100%">
                        <tr>
                            <td class="TD_FRM" valign="top">
                                <%-------------------------------------------------------------------
						    1.カード部
						    ---------------------------------------------------------------------%>
                                <table class="TABLE_ARTICLE">
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="30%">
                                            <cc:EncodedLabel ID="CompanyLbl" runat="server">会社</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                        <td class="TD_ARTICLE_3" width="70%">
                                            <asp:DropDownList ID="CompanyDrop" runat="server"></asp:DropDownList>
                                            &nbsp; &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table class="TABLE_ARTICLE" width="100%">    
                                    <tr class="TR_ARTICLE_BTN">
                                        <td class="TD_ARTICLE_BTN" style="height: 23px">
                                        </td>
                                        <td class="TD_ARTICLE_BTN" width="30%" style="height: 23px">
                                                &nbsp;</td>
                                        <td class="TD_ARTICLE_BTN" style="width: 70%; height: 23px;">
                                            <asp:Button ID="OutputButton" runat="server" OnClick="OutputButton_Click" Text="出力" Width="50px"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td height="100%"></td></tr>
                        <tr>
                            <td valign="bottom">
                                <uc:Footer ID="footer" runat="server"></uc:Footer>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
