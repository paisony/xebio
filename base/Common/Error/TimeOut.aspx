<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeOut.aspx.cs" Inherits="Common_Error_TimeOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>タイムアウト</title>
<script type="text/javascript" src="../../Common/Js/menu.js"></script>
<script type="text/javascript" src="../../Common/Js/common.js"></script>
<script type="text/javascript" language="javascript">
	function timeout() 
	{
		try {
			if (opener)
			{
				opener.location = 'TimeOut.aspx';
				self.close();
			}
			else if ('<%# closeWindow %>' == 'true')
			{
				alert('<%# message %>');
				top.close();
			}
			else
			{
				alert('<%# message %>');
				window.open('../Login.html?NoCheck=no','_top','','');
			}
		}
		catch(e) {
			window.open('../Login.html?NoCheck=no','_top','','');
		}	
	}
</script>
</head>
<body onload="timeout();">
	<form id="form1" runat="server" onprerender="RenderForm">
	</form>
</body>
</html>
