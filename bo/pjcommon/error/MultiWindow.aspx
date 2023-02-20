<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiWindow.aspx.cs" Inherits="Common.Standard.Page.MultiWindow" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../../pjcommon/usercontrol/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>多重起動エラー</title>
    <script type="text/javascript" language="javascript">
	    function Close() {
	        window.opener = true;
	        window.close();
	    }
    </script>
</head>
<body onerror="Page_Error">
    <form id="form1" runat="server" onprerender="RenderForm">		
		<div style="width:100%;padding:5px 15px 0px 5px;">		
			<%--  件数表示 --%>
			<div style="width:98%;background-color:#ff0000; margin-bottom:15px;background:url(../pjcommon/images/bg_numberitems.gif) repeat left top;">
				<table>
					<tr>
						<td style="height:30px;padding:0px 10px;color:#ffffff;font-weight:bold;font-size:15px; white-space: nowrap; ">
							多重起動エラーが発生しました。
						</td>
					</tr>
				</table>
			</div>
			
			<%-- データの表示 --%>
			<div style="width:98%; height: 260px; overflow-x: hidden; overflow-y:auto;">
				<table border="0" cellspacing="0" rules="all" style="border-collapse: collapse;">
					<tr>
						<td style="height:22px; text-align:left; padding-left:20px;">
							同一画面が開いている可能性があります。<br />もう一方の画面が閉じられていることを確認し、再度開き直してください。
						</td>
					</tr>
				</table>
			</div>
			
			<%-- 閉じるボタン --%>
			<div style="width:98%">
				<table style="width:100%; height:35px;">
					<tr>
						<td style="text-align:right;">
							<input id="CloseBtn" type="button" value="閉じる" style="width:80px; padding:1px 10px;" onclick="return Close();" runat="server"/>
						</td>
					</tr>
				</table>
			</div>
		</div>
	</form>
</body>
</html>
