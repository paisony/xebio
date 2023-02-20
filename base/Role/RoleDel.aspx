<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleDel.aspx.cs" Inherits="Role_RoleDel" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
	
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���[��</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
        <table width="100%" height="100%">
            <tr>
                <td valign="top">
                    <%--- �^�C�g���\�� ---%>
                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_PGTITLE">
                        <tr>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                <cc:EncodedLabel ID="Programtitle" runat="server">���[���Ǘ�</cc:EncodedLabel>
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
                            <%-- �߂�{�^�����K�v�ȏꍇ�͂����ɐݒu --%>
                        </tr>
                    </table>
                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_FRMTITLE">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">���[���폜�m�F</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="TD_FRM">
                                <%--- Web �y�[�W��ɂ��邷�ׂĂ̌��؃R���g���[�����瓾��ꂽ�G���[ ���b�Z�[�W���܂Ƃ߂ĕ\���ł��܂� ---%>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                <cc:EncodedLabel ID="BusinessErrorMessage" runat="server" Visible="False" ForeColor="Red"></cc:EncodedLabel>
                                <%--- Web �y�[�W��̌��؃R���g���[�� ---%>
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
                                <%-------------------------------------------------------------------
										1.�J�[�h��
										---------------------------------------------------------------------%>
                                <table class="TABLE_ARTICLE">
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="30%">
                                            <cc:EncodedLabel ID="RoleIdLbl" runat="server">���[��ID</cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="70%">
                                            <%--- �u���[��ID�v��s�e�L�X�g�{�b�N�X ---%>
                                            <cc:EncodedLabel ID="RoleId" runat="server"></cc:EncodedLabel>
                                            &nbsp;</td>
                                    </tr>
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2" width="30%">
                                            <cc:EncodedLabel ID="RoleNameLbl" runat="server">���[����</cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3" width="70%">
                                            <%--- �u���[�����v��s�e�L�X�g�{�b�N�X ---%>
                                            <cc:EncodedLabel ID="RoleName" runat="server"></cc:EncodedLabel>
                                            &nbsp;</td>
                                    </tr>
                                    <tr class="TR_ARTICLE">
                                        <td class="TD_ARTICLE_1">
                                            &nbsp;</td>
                                        <td class="TD_ARTICLE_2">
                                            <cc:EncodedLabel ID="NoteLbl" runat="server">����</cc:EncodedLabel>
                                        </td>
                                        <td class="TD_ARTICLE_3">
                                            <%--- �u���O�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                            <cc:EncodedLabel ID="RoleNote" runat="server"></cc:EncodedLabel>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" valign="top">
                                <%-------------------------------------------------------------------
										2.���ו�
										---------------------------------------------------------------------%>
                                <div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                    <asp:GridView ID="AuthorizationList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowDataBound="AuthorizationList_RowDataBound">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="�\�����[�V����ID" Visible="False">
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# Bind("SOLUTION_ID") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�\�����[�V����">
                                                <ItemStyle CssClass="TD_ITEM_DG" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="60%" />
                                                <ItemTemplate>
                                                    <cc:EncodedLabel ID="SolutionName" runat="server" Text='<%# Bind("SOLUTION_NAME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�g�p����">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="20%" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="AllowCheckBox" Enabled="false" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="���j���[�\���D��x">
                                                <ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="20%" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="SortBox" runat="server" CssClass="TXR_R" ReadOnly="true" Columns="4"
                                                        MaxLength="4"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteBtn" runat="server" Text="�폜" OnClick="DeleteBtn_Click" />
                                <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="���" CausesValidation="False" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
