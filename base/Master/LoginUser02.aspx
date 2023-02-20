<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginUser02.aspx.cs" Inherits="UserMst_Input" %>

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
    <form id="LoginUser02" runat="server" onprerender="RenderForm">
        <table height="100%" width="100%">
            <tr>
                <td width="100%" style="height: 154%">
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
                                                <cc:EncodedLabel ID="Formtitle" runat="server">���p�ҏ�����</cc:EncodedLabel>
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
                                                        <td class="TD_ARTICLE_1" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2" width="30%">
                                                            <cc:EncodedLabel ID="LoginIdLbl" runat="server">���O�C��ID</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" width="70%">
                                                            <%--- �u���O�C��id1�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <asp:TextBox ID="LoginIdBox" Columns="20" CssClass="TEXT_L" runat="server"></asp:TextBox>
                                                            <cc:EncodedLabel ID="LoginIDCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:RequiredFieldValidator ID="LoginIdReqValid" ControlToValidate="LoginIdBox" runat="server"
                                                                Display="None"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="LoginIdRegValid" ControlToValidate="LoginIdBox" runat="server"
                                                                ValidationExpression="[0-9a-zA-Z]*" Display="None"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator ID="LoginIdCustomValid" runat="server" ControlToValidate="LoginIdBox"
                                                                Display="None" OnServerValidate="LoginIdCustomValid_ServerValidate"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" style="height: 25px" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2" style="height: 25px">
                                                            <cc:EncodedLabel ID="PasswordLbl1" runat="server">�p�X���[�h</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" style="height: 25px">
                                                            <%--- �u�p�X���[�h1�v�p�X���[�h�{�b�N�X ---%>
                                                            <asp:TextBox ID="Password1Box" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
                                                            <cc:EncodedLabel ID="PasswordCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:RequiredFieldValidator ID="PasswordReqValid" ControlToValidate="Password1Box" runat="server"
                                                                Display="None"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="PasswordRegValid" runat="server" ControlToValidate="Password1Box"
                                                                Display="None"></asp:RegularExpressionValidator>
																<asp:Label ID="PasswordInvalidCharValid" runat="server" Text=''></asp:Label>
                                                            <asp:CustomValidator ID="PwdStrengthCusVal" runat="server" ControlToValidate="Password1Box"
                                                                Display="None" EnableClientScript="False" OnServerValidate="PwdStrengthCusVal_ServerValidate"></asp:CustomValidator>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" style="height: 25px" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2" style="height: 25px">
                                                            <cc:EncodedLabel ID="PasswordLbl2" runat="server">�p�X���[�h�m�F</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3" style="height: 25px">
                                                            <%--- �u�p�X���[�h1�v�p�X���[�h�{�b�N�X ---%>
                                                            <asp:TextBox ID="Password2Box" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
                                                            <cc:EncodedLabel ID="PasswordMatchCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:CustomValidator ID="PasswordMatchValid" runat="server" Display="None"
                                                                OnServerValidate="PasswordMatchValid_ServerValidate"
                                                                ValidateEmptyText="True"></asp:CustomValidator>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="UsernameLbl" runat="server">���p�Җ�</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u���O�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <asp:TextBox ID="UserNameBox" Columns="40" CssClass="TEXT_L" runat="server"
                                                                Font-Italic="False" MaxLength="20"></asp:TextBox>
                                                            <cc:EncodedLabel ID="UserNameCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:RequiredFieldValidator ID="UserNameReqValid" ControlToValidate="UserNameBox" runat="server"
                                                                Display="None"></asp:RequiredFieldValidator>
															<asp:Label ID="UserNameInvalidCharValid" runat="server" Text=''></asp:Label>
                                                            <asp:RegularExpressionValidator ID="UserNameRegValid" runat="server" ControlToValidate="UserNameBox"
                                                                Display="None" ValidationExpression="^[^';*%|�f�G�����b]*$"></asp:RegularExpressionValidator>
                                                    </tr>
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="KanaLbl" runat="server">���p�Җ��J�i</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u���p�Җ��J�i�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <asp:TextBox ID="KanaBox" Columns="40" CssClass="TEXT_L" runat="server"
                                                                Font-Italic="False" MaxLength="20"></asp:TextBox>
                                                            <cc:EncodedLabel ID="KanaCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:RegularExpressionValidator ID="KanaRegValid" runat="server" ControlToValidate="KanaBox"
                                                                Display="None" ValidationExpression="^[ �@\u30A0-\u30FF]*$"></asp:RegularExpressionValidator>&nbsp;
                                                            </td>
                                                    </tr>
                                                    
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="EmpLbl" runat="server">�Ј��R�[�h</cc:EncodedLabel><span class="MUST_MERK"></span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u�Ј��R�[�h�v��s�e�L�X�g�{�b�N�X�i���p�p���L���̂݁j ---%>
                                                            <asp:TextBox ID="EmployeeCodeTextBox" Columns="20" CssClass="TEXT_L" runat="server"
                                                                Font-Italic="False" MaxLength="20"></asp:TextBox>
                                                            <cc:EncodedLabel ID="EmplCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            &nbsp;&nbsp;
                                                            <asp:RegularExpressionValidator ID="EmpRegValid" runat="server" ControlToValidate="EmployeeCodeTextBox"
                                                                Display="None" ValidationExpression="([0-9]|[A-Z]|[a-z]|[!@#$%\^&\*\(\)\-\+\|~`\\=_\[\]\{\}&quot;':;\?/\.,<> ])*"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    
                                                    <tr class="TR_ARTICLE">
                                                        <td class="TD_ARTICLE_1" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_2">
                                                            <cc:EncodedLabel ID="CompanyLbl" runat="server">���</cc:EncodedLabel><span class="MUST_MERK">*</span></td>
                                                        <td class="TD_ARTICLE_3">
                                                            <%--- �u��Ёv��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
                                                            <asp:DropDownList ID="CompanyDrop" runat="server">
                                                            </asp:DropDownList>
                                                            <cc:EncodedLabel ID="CompanyCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                            <asp:RequiredFieldValidator ID="CompanyReqValid" runat="server" ControlToValidate="CompanyDrop"
                                                                Display="None"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr class="TR_ARTICLE_BTN">
                                                        <td class="TD_ARTICLE_BTN" style="height: 23px" >
                                                            &nbsp;</td>
                                                        <td class="TD_ARTICLE_BTN" style="height: 23px">
                                                        </td>
                                                        <td class="TD_ARTICLE_BTN" style="height: 23px">
                                                            <asp:Button ID="ConfirmBtn" runat="server" Text="�m�F" OnClick="ConfirmBtn_Click" />
                                                            <asp:Button ID="CancelBtn" runat="server" Text="���" CausesValidation="False" OnClick="CancelBtn_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
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
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
