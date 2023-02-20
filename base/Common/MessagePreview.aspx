<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL 
 改版履歴
 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessagePreview.aspx.cs" Inherits="Information_MessagePreview" %>
<%@ Register TagPrefix="uc" TagName="TopInfo" Src="../Common/Usercontrol/TopInformation.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>メッセージプレビュー</title>
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <link href="Style/default.css" type="text/css" rel="stylesheet" />
    <link href="Style/login.css" type="text/css" rel="stylesheet" />
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body>
		<form id="Form1" method="post" runat="server" onprerender="RenderForm">
			<table cellpadding="0" cellspacing="0" width="100%" height="100%">
				<tr>
					<td>
						<table id="Table8" cellSpacing="0" cellPadding="0" width="100%" class="TABLE_FRMTITLE">
							<tr>
								<td class="minutiae">
									<IMG src="../common/Images/point.gif" align="absMiddle" id="PointImg" runat="server">
									<cc:EncodedLabel id="PreviewLbl" runat="server" CssClass="minutiae"></cc:EncodedLabel>
								</td>
                                <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
                                <td style="text-align:right;">
                                    <asp:Button id="CloseBtn" runat="server" onclick="CloseBtn_Click"></asp:Button>
                                </td>
                                <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%" height="100%" valign="top">
                        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
						<div class="login-cont">
							<uc:TopInfo id="Topinfo" RunAt="server"></uc:TopInfo>
						</div>
                        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
					</td>
				</tr>
			</table>
		</form>
</body>
</html>
