<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserUpload.aspx.cs" Inherits="Master_UserUpload" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>���p�ҊǗ�</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="UserUpload" runat="server" onprerender="RenderForm">
        <table height="100%" width="100%">
            <tr>
                <td height="100%" width="100%">
                    <div style="height: 100%; overflow: auto; width: 100%;">
                        <table width="100%">
                            <tr>
                                <td valign="top" style="height: 305px">
                                    <%--- �^�C�g���\�� ---%>
                                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                    <table class="TABLE_PGTITLE">
                                        <tr>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                                            </td>
                                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                                <cc:EncodedLabel ID="Programtitle" runat="server">���p�ҊǗ�</cc:EncodedLabel>
                                            </td>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                                            </td>
                                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)" align="right">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" /><asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" />
                            </td>
                                            <td align="right" style="width: 75px">
                                            </td>
                                            <%-- �߂�{�^�����K�v�ȏꍇ�͂����ɐݒu --%>
                                        </tr>
                                    </table>
                                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                    <table class="TABLE_FRMTITLE">
                                        <tr>
                                            <td style="height: 18px">
                                                <img src="../Common/Images/point.gif" alt="point" />
                                                <cc:EncodedLabel ID="Formtitle" runat="server">���p�҈ꊇ�A�b�v���[�h</cc:EncodedLabel>
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%--- Web �y�[�W��ɂ��邷�ׂĂ̌��؃R���g���[�����瓾��ꂽ�G���[ ���b�Z�[�W���܂Ƃ߂ĕ\���ł��܂� ---%>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="False"></asp:ValidationSummary>
                                                <cc:EncodedLabel ID="BusinessErrorMessage" runat="server" ForeColor="Red" Visible="False"></cc:EncodedLabel>
                                                <cc:EncodedLabel ID="BusinessMessage" runat="server" Visible="False" ForeColor="Blue"></cc:EncodedLabel>
                                                <%--- Web �y�[�W��̌��؃R���g���[�� ---%>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
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
                                                                <cc:EncodedLabel ID="UploadTypeLbl" runat="server">�A�b�v���[�h���</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                            <td class="TD_ARTICLE_3" width="70%">
                                                                <asp:RadioButtonList ID="UploadTypeRdb" runat="server" RepeatDirection="Horizontal" Font-Size="X-Small">
                                                                    <asp:ListItem Text="�ǉ�" Value="Add" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="�X�V" Value="Update"></asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2" width="30%">
                                                            <cc:EncodedLabel ID="CsvLbl" runat="server">CSV�t�@�C��</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" width="70%">
                                                            <asp:FileUpload ID="UserFile" runat="server" /></td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE_BTN">
                                                        <td class="TD_ARTICLE_BTN">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_BTN">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN">
                                                            <asp:Button ID="UploadBtn" runat="server" Text="�A�b�v���[�h" OnClick="UploadBtn_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                    <tr>        
                                            <td class="TD_ARTICLE_BTN" width="60%">
                                                <asp:TextBox ID="ListBox" runat="server" Rows="8" TextMode="MultiLine" Width="100%"></asp:TextBox><br />
                                                <uc:Footer ID="footer" runat="server"></uc:Footer>
                                            </td>
                                            <td class="TD_ARTICLE_BTN" width="40%">
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
