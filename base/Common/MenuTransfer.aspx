<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuTransfer.aspx.cs" Inherits="Common_MenuTransfer" %>

<html>
<head id="Head1" runat="server">
	<title>メニュー</title>
	<link rel="stylesheet" type="text/css" href="Style/menu.css"/>
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <link rel="stylesheet" type="text/css" href="Style/default.css"/>
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
	<script type="text/javascript" src="Js/menu.js"></script>
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript">
		function winClosedialog() {
		var WinCloseCheck = ""
		}
	</script>
</head>
<body onload="init('<%# visibleSolutionId %>');" onscroll="window.document.body.scrollTop = 0;">
        <asp:Label ID="MenuHtmlLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="SSOScript" runat="server"></asp:Label>
</body>
</html>
