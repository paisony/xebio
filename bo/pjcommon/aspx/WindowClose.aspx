<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WindowClose.aspx.cs" Inherits="Common.Standard.Page.WindowClose" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title id="Windowtitle" runat="server"></title>
</head>
<body onload="window.close()">
	<form id="form1" runat="server" onprerender="RenderForm">
	</form>
</body>
</html>
