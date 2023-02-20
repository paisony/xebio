<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionTimeout.aspx.cs" Inherits="Common.Standard.Page.SessionTimeout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title id="Windowtitle" runat="server">セッションタイムアウト</title>
		<script type="text/javascript" src="../mdJs/jquery.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/jquery-ui.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/jquery.blockUI.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/Datepicker.ja.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/mdPjCommonVariable.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/mdPjClientConstant.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/mdPjCommon.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../mdJs/mdPjClientAsynchronous.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../js/pjcommon.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../js/coreEvent.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../js/clientMessage.js"></script>
		<script type="text/javascript" src="../js/standardClientMessage.js"></script>
		<script type="text/javascript" src="../js/InhibitionCharacterCheck.js" charset="UTF-8"></script>
		<script type="text/javascript" src="../js/pextcharchkvst.js" charset="UTF-8"></script>
		<script type="text/javascript" language="javascript">
		function Close() {
			alert("<%# clientMessage %>");
			//alert('32');
			window.close();
			if (window.dialogArguments) {
				window.dialogArguments.close();
			}
			window.top.close();
		}
	</script>
</head>
<body onload="javascript:Close()">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
