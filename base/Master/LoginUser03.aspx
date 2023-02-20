<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginUser03.aspx.cs" Inherits="UserMst_Confirm" %>

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
    <form id="LoginUser03" runat="server" onprerender="RenderForm">
        <table height="100%" width="100%">
            <tr>
                <td height="100%" width="100%">
                    <div style="height: 100%; overflow: auto; width: 100%;">
                        <table width="100%">
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
                                                <cc:EncodedLabel ID="Programtitle" runat="server">���p�ҊǗ�</cc:EncodedLabel>
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
                                            <td style="height: 18px">
                                                <img src="../Common/Images/point.gif" alt="point" />
                                                <cc:EncodedLabel ID="Formtitle" runat="server">���p�ҏ��m�F</cc:EncodedLabel>
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
                                                            <cc:EncodedLabel ID="LoginIdMenuLbl" runat="server">���O�C��ID</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" width="70%">
                                                            <%--- �u���O�C��id�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="LoginIdLbl" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="PasswordMenuLbl1" runat="server">�p�X���[�h</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u�p�X���[�h�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="PasswordLbl1" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="PasswordMenuLbl2" runat="server">�p�X���[�h�m�F</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u�p�X���[�h�m�F�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="PasswordLbl2" runat="server"></cc:EncodedLabel>&nbsp;</td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="UsernameMenuLbl" runat="server">���p�Җ�</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u���O�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="UserNameLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="KanaMenuLbl" runat="server">���p�Җ��J�i</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u���p�Җ��J�i�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="KanaLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                     <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="EmployeeCodeMenuLbl" runat="server">�Ј��R�[�h</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u�Ј��R�[�h�v��s�e�L�X�g�{�b�N�X�i�p���L���̂݁j ---%>
                                                            <cc:EncodedLabel ID="EmployeeCodeLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1">
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="CompanyMenuLbl" runat="server">���</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u��Ёv��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <cc:EncodedLabel ID="CompanyLbl" runat="server"></cc:EncodedLabel>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE_BTN">
                                                        <td class="TD_ARTICLE_BTN">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN">
                                                            <asp:Button ID="ConfirmBtn" runat="server" Text="�m��" CausesValidation="False" OnClick="ConfirmBtn_Click" />
                                                            <asp:Button ID="CancelBtn" runat="server" Text="����" CausesValidation="False" OnClick="ReBtn_Click" />
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
