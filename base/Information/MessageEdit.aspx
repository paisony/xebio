<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageEdit.aspx.cs" Inherits="Information_MessageEdit"  %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>メッセージ管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
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
                                                <cc:EncodedLabel ID="Programtitle" runat="server"></cc:EncodedLabel>
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
                                                <cc:EncodedLabel ID="Formtitle" runat="server"></cc:EncodedLabel>
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
                                    <table width="100%">
                                        <tr>
                                            <td class="TD_FRM">
                                                <%-------------------------------------------------------------------
										1.カード部
										---------------------------------------------------------------------%>
                                                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
                                                <!-- search-list -->
				                                <div class="str-search-01">		
					                                <div class="inner-02">
						                                <p class="required">*が付いている項目は必須入力になります。</p>
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
														                        <cc:EncodedLabel ID="TopicLbl" runat="server"></cc:EncodedLabel><span class="required">*</span>
													                        </span>
                                                                        </th>
													                    <td>
														                    &nbsp;
                                                                            &nbsp;
                                                                            <asp:DropDownList ID="TopicDDL" runat="server" Width="100px">
                                                                                <asp:ListItem></asp:ListItem>
                                                                            </asp:DropDownList>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="MessageLbl" runat="server"></cc:EncodedLabel><span class="required">*</span>
													                        </span>
                                                                        </th>
													                    <td>
														                    &nbsp;
                                                                            &nbsp;
                                                                            <asp:TextBox ID="MessageBox" runat="server" Height="132px" MaxLength="512"
                                                                                Rows="2" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="MessageCutline" runat="server" CssClass="CUTLINE" Escape="True"
                                                                                URLConvert="False"></cc:EncodedLabel>
                                                                            <asp:RequiredFieldValidator ID="MessageBoxReqValid" runat="server" ControlToValidate="MessageBox"
                                                                                 Display="None"></asp:RequiredFieldValidator>
															                <asp:Label ID="MessageBoxInvalidCharValid" runat="server" Text=''></asp:Label>
                                                                            <asp:RegularExpressionValidator ID="MessageBoxRegValid" runat="server" ControlToValidate="MessageBox"
                                                                                Display="None"
                                                                                ValidationExpression="(\r\n|\n|.){1,512}"></asp:RegularExpressionValidator>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="UrlLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
														                    &nbsp;
                                                                            &nbsp;
                                                                            <asp:TextBox ID="UrlBox" runat="server" MaxLength="512" Width="400px"  Height="100%"></asp:TextBox>
                                                                            <cc:EncodedLabel ID="UrlCutline" runat="server" CssClass="CUTLINE" Escape="True"
                                                                                URLConvert="False"></cc:EncodedLabel>
															                <asp:Label ID="URLInvalidCharValid" runat="server" Text=''></asp:Label>
                                                                            <asp:RegularExpressionValidator ID="URLValid" runat="server" ControlToValidate="UrlBox"
                                                                                Display="None"
                                                                                ValidationExpression="https?://([\w-]+\.?)+[\w-]+(/[\w- ./?%&=#~\(\)]*)?"></asp:RegularExpressionValidator>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="DisplayLbl" runat="server"></cc:EncodedLabel><span class="required">*</span>
													                        </span>
                                                                        </th>
													                    <td>
														                    &nbsp;
                                                                            &nbsp;
                                                                            <asp:RadioButtonList ID="RadioListDisplay" Font-Size="X-Small" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                            </asp:RadioButtonList>
													                    </td>
												                    </tr>
												                    <tr>
													                    <td>
                                                                             &nbsp;
                                                                        </td>
													                    <td>
														                    &nbsp;
                                                                            &nbsp;
                                                                            <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" />
                                                                            <asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" />
                                                                            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" /></td>
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
                                    </table>
                                    <%-------------------------------------------------------------------
										2.明細部
										---------------------------------------------------------------------%>

                                    </td>
                            </tr>
                            <tr>
                                <td valign="bottom">
                                    <uc:Footer ID="footer" runat="server"></uc:Footer>
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
