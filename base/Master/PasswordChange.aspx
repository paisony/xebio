<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
���ŗ���
2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX
2015/10/05 FSWeb)Y.Tamura �p�X���[�h�ύX��Q�Ή�
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordChange.aspx.cs" Inherits="Master_PasswordChange" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>���p�ҊǗ�</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <%-- jacascript --%>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript" src="../Common/Js/PwdStrengthCheck.js"></script>
    <script language="javascript" type="text/javascript">
	<!--
        //�t���[������
		function ChangeTarget() {
		    document.forms[0].target = "_top";
		}
		
	    //�p�X���[�h���x�\����
		function ExecPasswordCheck(password)
		{
            switch (PwdStrengthCheck(password)) {
                case 0:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '������';
                    return;
                    break;
                case 1:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '�o�^�s�\�ȕ���������܂�';
                    return;
                    break;
                case 2:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#ff6347';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '��';
                    return;
                    break;
                case 3:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#ffff00';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#ffff00';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '��';
                    return;
                    break;
                case 4:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdResultStr").value = '��';
	                return;
	                break;  
                default:
                    break;
            }

		}

        //�p�X���[�h���x�o���f�[�^
        //���x����̎��Ɍ��؎��s�Ƃ���B
        function PwdStrengthCusVal_Validate(sender, e){
            if (PwdStrengthCheck(document.getElementById("NewPassword1Box").value) == 2)
            {
                e.IsValid = false;
            } else {
                e.IsValid = true;
            }
        }
        
        //�p�X���[�h�s�������񍬓��`�F�b�N
        //�p�X���[�h�ɔ��p�p�����ȊO�̕����񂪊܂܂�Ă���ꍇ�͌��؎��s�B
        function PwdInvalidCharCusVal_Validate(sender, e){
            if (PwdStrengthCheck(document.getElementById("NewPassword1Box").value) == 1)
            {
                e.IsValid = false;
            } else {
                e.IsValid = true;
            }
        }
        
    //-->
    </script>

    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body>
    <form id="PasswordChange" runat="server" onprerender="RenderForm">
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
                                                <cc:EncodedLabel ID="Formtitle" runat="server">�p�X���[�h�ύX</cc:EncodedLabel>
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%--- Web �y�[�W��ɂ��邷�ׂĂ̌��؃R���g���[�����瓾��ꂽ�G���[ ���b�Z�[�W���܂Ƃ߂ĕ\���ł��܂� ---%>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                                <cc:EncodedLabel ID="BusinessErrorMessage" runat="server" ForeColor="Red" Visible="False"></cc:EncodedLabel>
                                                <cc:EncodedLabel ID="BusinessMessage" runat="server" Visible="False" ForeColor="Blue"></cc:EncodedLabel>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%-------------------------------------------------------------------
										1.�J�[�h��
										---------------------------------------------------------------------%>
                                                <!-- 2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX Start -->
				                                <div class="str-search-01">
					                                <div class="inner-02">
						                                <div class="str-form-02">
							                                <div class="inner">
								                                <table>
									                                <colgroup>
										                                <col class="w-type-01">
										                                <col class="w-type-02">
									                                </colgroup>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PasswordLbl1" runat="server">�Â��p�X���[�h</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="PasswordBox" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
											                                <asp:Label ID="PasswordBoxInvalidCharValid" runat="server" Text=''></asp:Label>
                                                                            <cc:EncodedLabel ID="OldPasswordCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                                            <%-- 2015/10/05 FSWeb)Y.Tamura �p�X���[�h�ύX��Q�Ή��@Start--%>
                                                                            <asp:RequiredFieldValidator ID="OldPwdReqVal" runat="server" ControlToValidate="PasswordBox" Display="None" ErrorMessage="���݂̃p�X���[�h����͂��Ă��������B"></asp:RequiredFieldValidator>
                                                                            <%-- 2015/10/05 FSWeb)Y.Tamura �p�X���[�h�ύX��Q�Ή��@End--%>
                                                                        </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PasswordLbl2" runat="server">�V�����p�X���[�h</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="NewPassword1Box" TextMode="Password" Columns="20" runat="server" onkeyup="ExecPasswordCheck(this.value)"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="PasswordCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                                            &nbsp;<asp:CustomValidator ID="PwdLimitDurationCusVal" runat="server" Display="None" ErrorMessage="�O��̃p�X���[�h�X�V�����Ƃ̊Ԋu���Z�����ߍX�V�ł��܂���B"
                                                                                OnServerValidate="PwdLimitDurationCusVal_ServerValidate" EnableClientScript="False"></asp:CustomValidator>
                                                                            <asp:RequiredFieldValidator ID="NewPwdReqVal" runat="server" ControlToValidate="NewPassword1Box" Display="None" ErrorMessage="�V�����p�X���[�h����͂��Ă��������B"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="PwdRegValid" runat="server" ControlToValidate="NewPassword1Box"
                                                                                Display="None"></asp:RegularExpressionValidator>
                                                                            <asp:CustomValidator ID="PwdStrengthCusVal" runat="server" OnServerValidate="PwdStrengthCusVal_ServerValidate" Display="None" EnableClientScript="False"></asp:CustomValidator>
											                                <asp:Label ID="NewPwdInvalidCharValid" runat="server" Text=''></asp:Label>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PwdStrengthLbl" runat="server" Escape="True" URLConvert="False">�p�X���[�h���x</cc:EncodedLabel>
											                                </span>
										                                </th>
										                                <td>
										                                    <table class="PWD_CHECK_TABLE" cellSpacing="2" style="font-size:x-small;width: 100%;border-collapse: separate; border-spacing: 2px; ">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td id="PwdLowTD" style="width: 25%;background-color:LightGrey;padding-bottom:0px;">
                                                                                        </td>
                                                                                        <td id="PwdMidTD" style="width: 25%;background-color:LightGrey;padding-bottom:0px;">
                                                                                        </td>
                                                                                        <td id="PwdHighTD" style="width: 25%;background-color:LightGrey;padding-bottom:0px;">
                                                                                        </td>
                                                                                        <td id="PwdResultTD" style="width: 25%;padding-bottom:0px;">
                                                                                            <input id="PwdResultStr" type="text" value="������" readonly style="width:70%;height:auto;border-top-style: none;border-right-style: none;border-left-style: none;background-color: #FFFFFF;border-bottom-style: none;color:Gray;" tabindex="-1"/>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PasswordLbl3" runat="server">�V�����p�X���[�h�m�F</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="NewPassword2Box" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="PasswordMatchCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>&nbsp;
                                                                            <asp:CompareValidator ID="NewPwdCompVal" runat="server" ControlToCompare="NewPassword2Box"
                                                                                ControlToValidate="NewPassword1Box" ErrorMessage="�V�����p�X���[�h����v���܂���B"
                                                                                Display="None"></asp:CompareValidator>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
										                                </th>
										                                <td>
                                                                            <asp:Button ID="ConfirmBtn" runat="server" Text="�X�V" OnClick="ConfirmBtn_Click" />
                                                                            <asp:Button ID="SuspendBtn" runat="server" CausesValidation="False" OnClick="SuspendBtn_Click" OnClientClick='return ChangeTarget();' Text="�ύX���Ȃ�" />
                                                                            <asp:Button ID="MenuBtn" runat="server" CausesValidation="False" OnClick="MenuBtn_Click" OnClientClick='return ChangeTarget();' Text="�m�F" /></td>
										                                </td>
									                                </tr>
								                                </table>
							                                <!-- /inner --></div>
						                                <!-- /str-form-02 --></div>
		    		                                <!-- /inner-02 --></div>
		    	                                <!-- /str-search-01 --></div>
                                                <!-- 2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX Start -->
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
