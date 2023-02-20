<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolutionSetting.aspx.cs"
    Inherits="System_SolutionSetting" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>SSO設定</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="SolutionSetting" runat="server">
        <table width="100%" height="100%">
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
                                <cc:EncodedLabel ID="Programtitle" runat="server">SSO設定</cc:EncodedLabel>
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
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">サーバ設定</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="TD_FRM">
                                <%--- Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます ---%>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="False">
                                </asp:ValidationSummary>
                                <cc:EncodedLabel ID="BusinessMessage" runat="server" Visible="False" ForeColor="Blue"></cc:EncodedLabel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="100%" valign="top">
                    <table width="100%" height="100%">
                        <tr>
                            <td height="100%" valign="top">
                                <%-------------------------------------------------------------------
										    2.明細部
										    ---------------------------------------------------------------------%>
                                <div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                    <asp:GridView ID="M1" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowDataBound="M1_RowDataBound">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <%--- 「ソリューション名」一行テキストボックス（セパレート日付以外） ---%>
                                                    &nbsp;<cc:EncodedLabel ID="SolutionIdLbl" runat="server" Text='<%# Bind("SOLUTION_ID") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <%--- 「ソリューション名」一行テキストボックス（セパレート日付以外） ---%>
                                                    &nbsp;<cc:EncodedLabel ID="SubSystemIdLbl" runat="server" Text='<%# Bind("SUBSYSTEM_ID") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ソリューション">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="25%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「ソリューション名」一行テキストボックス（セパレート日付以外） ---%>
                                                    &nbsp;<cc:EncodedLabel ID="GridSolutionLbl" runat="server" Text='<%# Bind("SOLUTION_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="サブシステム名">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="25%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「サブシステム名」ラベル ---%>
                                                    &nbsp;<cc:EncodedLabel ID="GridSubsystemLbl" runat="server" Text='<%# Bind("SUBSYSTEM_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="URL">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="50%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「URL」一行テキストボックス（セパレート日付以外） ---%>
                                                    <asp:TextBox ID="GridHostBox" runat="server" Width="66%"  MaxLength="96"></asp:TextBox>
                                                    <asp:TextBox ID="GridDirBox" runat="server" Width="33%" ReadOnly="true" ForeColor="Gray"  MaxLength="32"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr class="TR_ARTICLE_BTN">
                            <td class="TD_ARTICLE_BTN">
                                <asp:Button ID="ConfirmBtn" runat="server" Text="確定" OnClick="ConfirmBtn_Click" />
                                <asp:CustomValidator ID="UrlValid" runat="server" Display="None" ErrorMessage="URLに設定されたホスト名は不正です。"
                                    OnServerValidate="UrlValid_ServerValidate"></asp:CustomValidator></td>
                        </tr>
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
