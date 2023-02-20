<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NowLoading.aspx.cs" Inherits="pjcommon_mdAspx_NowLoading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="Title1" runat="server">しばらくお待ちください．．．．　　　　</title>
    <meta id="refreshSetup" http-equiv="refresh" content="1"  runat="server"/>
    <!-- link css -->
	<script type="text/javascript"src="../mdJs/jquery.js"></script>
	<style type="text/css">

	</style>
	<script type="text/javascript">
	    function clo(){
	        window.close();
	    }
	    function starting(){
	        try{
			    //親ウィンドウのハンドラを取得
                var main = window.dialogArguments;
			    main.startingflg = 1;
			}catch(e){
			    window.close();
			}
	    }
	</script>
</head>
<body onload="starting();" >
<form id="form1" runat="server">
    <table style="height:120px;width:250px;">
        <tr>
            <td style="width:25%;">
                <asp:Image ID="nowloadinggif" runat="server" ImageUrl="~/pjcommon/images/busy.gif" />
            </td>
            <td style="width:75%;text-align:left;">
                <asp:Label ID="resultcode" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
