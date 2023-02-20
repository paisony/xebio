<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="pjcommon_mdAspx_Confirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title id="Windowtitle" runat="server"></title>
		<adv:ContentType ID="ContentType1" runat="server" />
		<!--- キャッシュの無効化設定 --->
		<adv:NoCache ID="NoCache1" runat="server" />
		<!-- link css -->
		<script type="text/javascript" src="../mdJs/mdPjCommon.js"></script>
		<script type="text/javascript" language="javascript">
			function OK() {
                var callbackId = "<%# pgId %>";
				var arge = new Array();
				arge[0] = "<%# pgId %>";
				window.opener[callbackId](arge);
				window.close();
				return false;
			}
			function CANCEL() {
                var callbackId = "<%# pgId %>";
				var arge = new Array();
                window.opener[callbackId](arge);
				window.close();
				return false;
			}
			// ×ボタン押下時
			function beforeUnload(e) {
				CANCEL();
			}

			window.addEventListener('beforeunload', beforeUnload);

        </script>
</head>
	<body style="width:99%;height:99%;overflow-x:hidden;overflow-y:hidden" bgcolor="linen">
		<form id="form1" runat="server" onprerender="RenderForm">
			<div id="confirm" style="width:97%;height:90%;">
				<table cellspacing="0" cellpadding="0" border="0">
					<tr>
						<td valign="middle" align="left" style="height:50px">
							<img src="../images/question.gif" alt="confirm" style="width:30px" height="30px" />
						</td>   
						<td valign="middle" align="left" style="font-size:smaller">
							<asp:Literal ID="message" runat="server"/>　
						</td>
					</tr>
					<tr style="height:40px;">
					    <td colspan="2" style="text-align:center;vertical-align:bottom">
					        <div style="width:270px;">
                                <input name="Input" type="button" style="font-size:smaller;padding:1px 10px;text-align:center;width:90px" id="button1" onclick="OK();"  runat="server"/>
	        				    <input name="Input" type="button" style="font-size:smaller;padding:1px 10px;text-align:center;width:90px" id="button2" onclick="CANCEL();"  runat="server"/>
					        </div>
					    </td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</html>