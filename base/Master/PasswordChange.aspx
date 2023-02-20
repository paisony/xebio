<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordChange.aspx.cs" Inherits="Master_PasswordChange" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>利用者管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <%-- jacascript --%>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript" src="../Common/Js/PwdStrengthCheck.js"></script>
    <script language="javascript" type="text/javascript">
	<!--
        //フレーム解除
		function ChangeTarget() {
		    document.forms[0].target = "_top";
		}
		
	    //パスワード強度表示部
		function ExecPasswordCheck(password)
		{
            switch (PwdStrengthCheck(password)) {
                case 0:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '未入力';
                    return;
                    break;
                case 1:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '登録不可能な文字があります';
                    return;
                    break;
                case 2:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#ff6347';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '弱';
                    return;
                    break;
                case 3:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#ffff00';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#ffff00';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#d3d3d3';
                    document.getElementById("PwdResultStr").value = '中';
                    return;
                    break;
                case 4:
                    document.getElementById("PwdLowTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdMidTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdHighTD").style.backgroundColor = '#00ff00';
                    document.getElementById("PwdResultStr").value = '強';
	                return;
	                break;  
                default:
                    break;
            }

		}

        //パスワード強度バリデータ
        //強度が弱の時に検証失敗とする。
        function PwdStrengthCusVal_Validate(sender, e){
            if (PwdStrengthCheck(document.getElementById("NewPassword1Box").value) == 2)
            {
                e.IsValid = false;
            } else {
                e.IsValid = true;
            }
        }
        
        //パスワード不正文字列混入チェック
        //パスワードに半角英数字以外の文字列が含まれている場合は検証失敗。
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
                                    <%--- タイトル表示 ---%>
                                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                    <table class="TABLE_PGTITLE">
                                        <tr>
                                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                                            </td>
                                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                                <cc:EncodedLabel ID="Programtitle" runat="server">利用者管理</cc:EncodedLabel>
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
                                                <cc:EncodedLabel ID="Formtitle" runat="server">パスワード変更</cc:EncodedLabel>
                                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%--- Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます ---%>
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
										1.カード部
										---------------------------------------------------------------------%>
                                                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
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
												                                <cc:EncodedLabel ID="PasswordLbl1" runat="server">古いパスワード</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="PasswordBox" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
											                                <asp:Label ID="PasswordBoxInvalidCharValid" runat="server" Text=''></asp:Label>
                                                                            <cc:EncodedLabel ID="OldPasswordCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                                            <%-- 2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応　Start--%>
                                                                            <asp:RequiredFieldValidator ID="OldPwdReqVal" runat="server" ControlToValidate="PasswordBox" Display="None" ErrorMessage="現在のパスワードを入力してください。"></asp:RequiredFieldValidator>
                                                                            <%-- 2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応　End--%>
                                                                        </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PasswordLbl2" runat="server">新しいパスワード</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="NewPassword1Box" TextMode="Password" Columns="20" runat="server" onkeyup="ExecPasswordCheck(this.value)"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="PasswordCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>
                                                                            &nbsp;<asp:CustomValidator ID="PwdLimitDurationCusVal" runat="server" Display="None" ErrorMessage="前回のパスワード更新時刻との間隔が短いため更新できません。"
                                                                                OnServerValidate="PwdLimitDurationCusVal_ServerValidate" EnableClientScript="False"></asp:CustomValidator>
                                                                            <asp:RequiredFieldValidator ID="NewPwdReqVal" runat="server" ControlToValidate="NewPassword1Box" Display="None" ErrorMessage="新しいパスワードを入力してください。"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="PwdRegValid" runat="server" ControlToValidate="NewPassword1Box"
                                                                                Display="None"></asp:RegularExpressionValidator>
                                                                            <asp:CustomValidator ID="PwdStrengthCusVal" runat="server" OnServerValidate="PwdStrengthCusVal_ServerValidate" Display="None" EnableClientScript="False"></asp:CustomValidator>
											                                <asp:Label ID="NewPwdInvalidCharValid" runat="server" Text=''></asp:Label>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PwdStrengthLbl" runat="server" Escape="True" URLConvert="False">パスワード強度</cc:EncodedLabel>
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
                                                                                            <input id="PwdResultStr" type="text" value="未入力" readonly style="width:70%;height:auto;border-top-style: none;border-right-style: none;border-left-style: none;background-color: #FFFFFF;border-bottom-style: none;color:Gray;" tabindex="-1"/>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
											                                <span class="tbl-hdg">
												                                <cc:EncodedLabel ID="PasswordLbl3" runat="server">新しいパスワード確認</cc:EncodedLabel>
                                                                                <span class="required">*</span>
											                                </span>
										                                </th>
										                                <td>
											                                <asp:TextBox ID="NewPassword2Box" TextMode="Password" Columns="20" runat="server"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="PasswordMatchCutline" runat="server" CssClass="CUTLINE"></cc:EncodedLabel>&nbsp;
                                                                            <asp:CompareValidator ID="NewPwdCompVal" runat="server" ControlToCompare="NewPassword2Box"
                                                                                ControlToValidate="NewPassword1Box" ErrorMessage="新しいパスワードが一致しません。"
                                                                                Display="None"></asp:CompareValidator>
										                                </td>
									                                </tr>
									                                <tr>
										                                <th scope="col">
										                                </th>
										                                <td>
                                                                            <asp:Button ID="ConfirmBtn" runat="server" Text="更新" OnClick="ConfirmBtn_Click" />
                                                                            <asp:Button ID="SuspendBtn" runat="server" CausesValidation="False" OnClick="SuspendBtn_Click" OnClientClick='return ChangeTarget();' Text="変更しない" />
                                                                            <asp:Button ID="MenuBtn" runat="server" CausesValidation="False" OnClick="MenuBtn_Click" OnClientClick='return ChangeTarget();' Text="確認" /></td>
										                                </td>
									                                </tr>
								                                </table>
							                                <!-- /inner --></div>
						                                <!-- /str-form-02 --></div>
		    		                                <!-- /inner-02 --></div>
		    	                                <!-- /str-search-01 --></div>
                                                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
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
