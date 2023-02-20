<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleList.aspx.cs" Inherits="role_RoleList" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head runat="server">
    <title>ロール</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
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
                                <cc:EncodedLabel ID="Programtitle" runat="server">ロール管理</cc:EncodedLabel>
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
                                <cc:EncodedLabel ID="Formtitle" runat="server">ロール一覧</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="100%" valign="top">
                    <table height="100%" width="100%">
                        <tr>
                            <td class="TD_FRM" style="height: 44px">
                                <%-------------------------------------------------------------------
										1.カード部
										---------------------------------------------------------------------%>
                                <table class="TABLE_ARTICLE">
                                    <tr class="TR_ARTICLE_BTN">
                                        <td class="TD_ARTICLE_BTN">
                                            <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="新規登録" /></td>
                                        <td class="TD_ARTICLE_BTN">
                                        </td>
                                        <td class="TD_ARTICLE_BTN" align="right"></td>
                                        <td class="TD_ARTICLE_BTN" width="13%">
                                            <asp:Button ID="UploadBtn" runat="server" OnClick="UploadBtn_Click" Text="ロールテンプレートアップロード" Width="190px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" valign="top">
                                <%-------------------------------------------------------------------
										2.明細部
										---------------------------------------------------------------------%>
                                <div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                    <asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowCommand="RoleList_RowCommand" PageSize="20" AllowPaging="True">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="ロールID">
                                                <ItemStyle CssClass="TD_ITEM_DG"/>
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="25%" />
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="RoleId" runat="server" Text='<%# Bind("ROLE_ID") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ロール名">
                                                <ItemStyle CssClass="TD_ITEM_DG"/>
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%" />
                                                <ItemTemplate>
                                                   <cc:EncodedLabel ID="RoleName" runat="server" Text='<%# Bind("ROLE_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="注釈">
                                                <EditItemTemplate>
                                                    <cc:EncodedLabel ID="RoleNote" runat="server" Text='<%# Eval("ROLE_NOTE") %>'></cc:EncodedLabel>
                                                </EditItemTemplate>
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="45%" />
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="RoleNote" runat="server" Text='<%# Bind("ROLE_NOTE") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Button" CommandName="EditRow" Text="編集">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
                                            </asp:ButtonField>
                                             <asp:ButtonField ButtonType="Button" CommandName="MenuSetting" Text="メニュー設定">
                                                <ItemStyle CssClass="TD_ITEM_DG" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Button" CommandName="DeleteRow" Text="削除">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Button" CommandName="UserSetting" Text="ユーザ設定">
                                                <ItemStyle CssClass="TD_ITEM_DG" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 18px">
                                <%--- 「ページャー」カスタムページャー ---%>
                                <cc:Pager ID="Pager" runat="server" CurrentPageIndex="0" PageSize="20" Font-Size="11pt"
                                    NextText="Next >>" OnPageIndexChanged="Pager_PageIndexChanged" PrevText="<< Back"
                                    VirtualItemCount="0"></cc:Pager>
                            </td>
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
