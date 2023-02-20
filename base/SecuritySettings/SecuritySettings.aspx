<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecuritySettings.aspx.cs" Inherits="SecurityPolicy_SecuritySettings" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>セキュリティ設定</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
                                <cc:EncodedLabel ID="Programtitle" runat="server">セキュリティ設定</cc:EncodedLabel>
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
                                <cc:EncodedLabel ID="Formtitle" runat="server">セキュリティ設定一覧</cc:EncodedLabel>
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
                    <table height="100%" width="100%">
                       
                        <tr>
                            <td height="100%" valign="top" colspan="2">
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
                                                    <%--- 「設定キー」ラベル ---%>
                                                    &nbsp;<cc:EncodedLabel ID="GridSettingKeyLbl" runat="server" Text='<%# Bind("SETTING_KEY") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <%--- 「入力チェックルール」ラベル ---%>
                                                    &nbsp;<asp:Label ID="GridSettingValidRegExpLbl" runat="server" Text='<%# Bind("SETTING_VALID_REGEXP") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="設定項目">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="35%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「設定名」ラベル ---%>
                                                    &nbsp;<cc:EncodedLabel ID="GridSettingNameLbl" runat="server" Text='<%# Bind("SETTING_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="説明">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="55%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「説明」ラベル ---%>
                                                    &nbsp;<cc:EncodedLabel ID="GridSettingNoteLbl" runat="server" Text='<%# Bind("SETTING_NOTE") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="設定値">
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="10%"></HeaderStyle>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--- 「設定値」一行テキストボックス ---%>
                                                    <asp:TextBox ID="GridSettingValueBox" runat="server" Width="100%" CssClass="TEXT_R"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegexValid" runat="server" Display="None" ControlToValidate="GridSettingValueBox" EnableClientScript="False"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="ReqValid" runat="server" ControlToValidate="GridSettingValueBox"
                                                        Display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
                                                    <asp:DropDownList ID="GridSettingValueDDL" Width="100%" runat="server" Visible="False">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr class="TR_ARTICLE_BTN">
                            <td class="TD_ARTICLE_BTN">
                                <asp:Button ID="UpdateBtn" runat="server" Text="確定" OnClick="UpdateBtn_Click" />
                                <%--<asp:CustomValidator ID="SettingValid" runat="server" Display="None"
                                    OnServerValidate="SettingValid_ServerValidate"></asp:CustomValidator>--%>
                                    </td>
                                    <td align="right">
                                    <asp:Button ID="ResetBtn" runat="server" Text="既定値にリセットする" OnClick="ResetBtn_Click" CausesValidation="False" />
                                    </td>
                        </tr>
                        <tr>
                            <td valign="bottom" colspan="2">
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
