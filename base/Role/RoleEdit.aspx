<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="Role_RoleEdit" %>

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
        <table height="100%" width="100%">
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
                                <cc:EncodedLabel ID="Formtitle" runat="server">ロール設定</cc:EncodedLabel>
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
                <td height="100%" valign="top">
                    <table height="100%" width="100%">
                        <tr>
                            <td class="TD_FRM">
                                <%------------------------------------------------------------------
                                     1.カード部
                                ---------------------------------------------------------------------%>
                                <table class="TABLE_ARTICLE">
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1" style="height: 25px">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="30%" style="height: 25px">
                                            <cc:EncodedLabel ID="RoleIDLbl" runat="server">ロールID</cc:EncodedLabel><span class="MUST_MERK">*</span>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="70%" style="height: 25px">
                                            <%--- 「ロールID」一行テキストボックス ---%>
                                            <asp:TextBox ID="RoleId" Columns="32" runat="server" MaxLength="20"></asp:TextBox>
                                            <cc:EncodedLabel ID="RoleIdCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>&nbsp;                                            
                                            <asp:RequiredFieldValidator ID="RoleIdReqValid" runat="server"
                                                ControlToValidate="RoleId" Display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RoleIdRegValid" runat="server" ControlToValidate="RoleId"
                                                                Display="None" ValidationExpression="^[0-9a-zA-Z]*$" EnableClientScript="False"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1" style="height: 25px">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="30%" style="height: 25px">
                                            <cc:EncodedLabel ID="RoleNameLbl" runat="server">ロール名</cc:EncodedLabel><span class="MUST_MERK">*</span>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="70%" style="height: 25px">
                                            <%--- 「ロール名」一行テキストボックス ---%>
                                            <asp:TextBox ID="RoleName" Columns="32" runat="server" MaxLength="32"></asp:TextBox>
                                            <cc:EncodedLabel ID="RoleCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>&nbsp;
                                            <asp:RequiredFieldValidator ID="RoleNameReqValid" runat="server"
                                                ControlToValidate="RoleName" Display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
											<asp:Label ID="RoleNameInvalidCharValid" runat="server" Text=''></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2">
                                            <cc:EncodedLabel ID="NoteLbl" runat="server">注釈</cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3">
                                            <%--- 「名前」一行テキストボックス（セパレート日付以外） ---%>
                                            <asp:TextBox ID="RoleNote" Columns="50" runat="server" MaxLength="256" TextMode="MultiLine"
                                                Rows="3"></asp:TextBox>
                                            <cc:EncodedLabel id="RoleNoteCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                            <asp:RegularExpressionValidator ID="RoleNoteRegValid" runat="server"
                                                ControlToValidate="RoleNote" Display="None" ValidationExpression="^[\w\W]{0,256}$" EnableClientScript="False"></asp:RegularExpressionValidator>
											<asp:Label ID="RoleNoteInvalidCharValid" runat="server" Text=''></asp:Label>
                                        </td>
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
                                    <asp:GridView ID="AuthorizationList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowDataBound="AuthorizationList_RowDataBound">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="ソリューションID" Visible="False">
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# Bind("SOLUTION_ID") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ソリューション">
                                                <ItemStyle CssClass="TD_ITEM_DG" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="60%" />
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="SolutionName" runat="server" Text='<%# Bind("SOLUTION_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="使用許可">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="20%" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="AllowCheckBox" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="メニュー表示優先度">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="20%" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="SortBox" runat="server" CssClass="TEXT_R" Columns="4" MaxLength="4">0</asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 11px">
                                <asp:Button ID="UpdateBtn" runat="server" Text="更新" OnClick="UpdateBtn_Click" />
                                <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" Text="戻る" CausesValidation="False" />
                                <asp:CustomValidator ID="SortValid" runat="server" Display="None"
                                    ErrorMessage="CustomValidator" OnServerValidate="SortValid_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
