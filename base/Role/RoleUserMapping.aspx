<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleUserMapping.aspx.cs"
    Inherits="Role_RoleUserMapping" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>ロールユーザ設定</title>
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
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">ロール付与設定</cc:EncodedLabel>
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
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="100%" valign="top">
                    <table width="100%" height="100%">
                        <tr>
                            <td class="TD_FRM" valign="top">
                                <%-------------------------------------------------------------------
                                    1.カード部
                                ---------------------------------------------------------------------%>
                                <table class="TABLE_ARTICLE">
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">&nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="20%">
                                            <cc:EncodedLabel ID="RoleIdLbl" runat="server" Text="ロールID"></cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="30%">
                                            <cc:EncodedLabel ID="RoleIdValueLbl" runat="server"></cc:EncodedLabel>&nbsp;    
                                        </td>
                                        <td class="TD_ARTICLE_1">&nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="20%">
                                            <cc:EncodedLabel ID="RoleLbl" runat="server" Text="ロール名"></cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="30%">
                                            <cc:EncodedLabel ID="RoleNameLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                        </td>
                                    </tr>
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="20%">
                                            <cc:EncodedLabel ID="QueryLbl" runat="server" Text="検索条件"></cc:EncodedLabel></td>
                                        <td class="TD_ARTICLE_3" width="80%" colspan="4">
                                            <cc:EncodedLabel ID="CompanyLbl" runat="server" Text="会社："></cc:EncodedLabel>
                                            <asp:DropDownList ID="CompanyList" runat="server">
                                            </asp:DropDownList>
                                            <cc:EncodedLabel ID="LoginIdLbl" runat="server" Text="ログインID："></cc:EncodedLabel>
                                            <asp:TextBox ID="LoginIdBox" runat="server" Columns="10" MaxLength="10"></asp:TextBox>
                                            <cc:EncodedLabel ID="NameLbl" runat="server" Text="名前："></cc:EncodedLabel>
											<asp:Label ID="LoginIdInvalidCharValid" runat="server" Text=''></asp:Label>
                                            <asp:TextBox ID="NameBox" runat="server" MaxLength="20"></asp:TextBox>
											<asp:Label ID="NameInvalidCharValid" runat="server" Text=''></asp:Label>
                                            <asp:Button ID="SearchBtn" runat="server" Text="検索" OnClick="SearchBtn_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" valign="top">
                                <table class="TABLE_ARTICLE" height="100%">
                                    <tr>
                                        <td valign="top" align="center" height="100%" style="width: 50%">
                                            <div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                                <asp:GridView ID="SearchList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                                    Width="100%" OnRowDataBound="SearchList_RowDataBound">
                                                    <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                                    <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                                    <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="UserCheckBox" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="AllCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="AllCheckBox1_CheckedChanged" />
                                                            </HeaderTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="CompanyIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMPANY_ID") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="会社">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="30%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="CompanyLbl" runat="server"></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ログインID">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="30%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="LoginIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LOGIN_ID") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="利用者名">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="40%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="40%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="NameIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NAME") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            &nbsp;
                                        </td>
                                        <td align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="AddBtn" runat="server" Text="追加>>" OnClick="AddBtn_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="DelBtn" runat="server" Text="<<削除" OnClick="DelBtn_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="center" height="100%" width="50%">
                                            <div id="Div2" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                                <asp:GridView ID="RoleUserList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                                    Width="100%" OnRowDataBound="RoleUserList_RowDataBound">
                                                    <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                                    <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                                    <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="UserCheckBox" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="AllCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="AllCheckBox2_CheckedChanged" />
                                                            </HeaderTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="CompanyIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMPANY_ID") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="会社">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="30%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="CompanyLbl" runat="server"></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ログインID">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="30%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="LoginIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LOGIN_ID") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="利用者名">
                                                            <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="40%"></HeaderStyle>
                                                            <ItemStyle CssClass="TD_ITEM_DG" Width="40%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="NameIdLbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NAME") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="UpdateBtn" runat="server" Text="更新" OnClick="UpdateBtn_Click" />
                                <asp:Button ID="CancelBtn" runat="server" Text="取消" OnClick="CancelBtn_Click" />
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="bottom" style="height: 29px">
                    <uc:Footer ID="footer" runat="server"></uc:Footer>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

