﻿<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessMenu.aspx.cs" Inherits="Access_AccessMenu" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
	<title>アクセス管理</title>
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
											<cc:EncodedLabel ID="Programtitle" runat="server">アクセス管理</cc:EncodedLabel>
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
											<cc:EncodedLabel ID="Formtitle" runat="server">アクセス管理メニュー</cc:EncodedLabel>
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
									                <div class="str-form-02">
										                <div class="inner">
											                <table  class="info-table">
												                <colgroup>
													                <col class="w-type-01">
													                <col class="w-type-02">
												                </colgroup>
															    <tr>
																    <th scope="col">
			                                                            <span class="tbl-hdg">
																	        <asp:HyperLink ID="UserLockLink" runat="server" NavigateUrl="UserLock.aspx">[UserLockLink]</asp:HyperLink>
																        </span>
			                                                        </th>
																    <td>
																	    &nbsp;
			                                                            &nbsp;
			                                                            <cc:EncodedLabel ID="UserLockLbl" runat="server"></cc:EncodedLabel>
																    </td>
															    </tr>
															    <tr>
																    <th scope="col">
			                                                            <span class="tbl-hdg">
																	        <asp:HyperLink ID="OperationTimeSettingLink" runat="server" NavigateUrl="OperationTimeSettings.aspx">[OperationTimeSettingsLink]</asp:HyperLink>
																        </span>
			                                                        </th>
																    <td>
																	    &nbsp;
			                                                            &nbsp;
			                                                            <cc:EncodedLabel ID="OperationTimeSettingLbl" runat="server"></cc:EncodedLabel>
																    </td>
															    </tr>
															    <tr>
																    <th scope="col">
			                                                            <span class="tbl-hdg">
																	        <asp:HyperLink ID="LoginLogReferenceLink" runat="server" NavigateUrl="LoginLogReference.aspx">[LoginLogReferenceLink]</asp:HyperLink>
																        </span>
			                                                        </th>
																    <td>
																	    &nbsp;
			                                                            &nbsp;
			                                                            <cc:EncodedLabel ID="LoginLogReferenceLbl" runat="server"></cc:EncodedLabel>
																    </td>
															    </tr>
															    <tr>
																    <th scope="col">
			                                                            <span class="tbl-hdg">
																	        <asp:HyperLink ID="LoginStatusReferenceLink" runat="server" NavigateUrl="LoginStatusReference.aspx">[LoginStatusReferenceLink]</asp:HyperLink>
																        </span>
			                                                        </th>
																    <td>
																	    &nbsp;
			                                                            &nbsp;
			                                                            <cc:EncodedLabel ID="LoginStatusReferenceLbl" runat="server"></cc:EncodedLabel>
																    </td>
															    </tr>
											                </table>
										                <!-- /inner --></div>
									                <!-- /str-form-02 --></div>
					    		                <!-- /inner-02 --></div>
					    	                <!-- /str-search-01 --></div>
                                            <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
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
