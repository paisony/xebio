<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FooterControl.ascx.cs" Inherits="Common.Standard.Page.FooterControl" %>
<%@ Register Tagprefix="uc" Tagname="Message" Src="~/pjcommon/usercontrol/MessageControl.ascx" %>
<table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<tr>
		<td style="width:25%"><font face="MS UI Gothic"></font></td>
		<td style="text-align:center; width:50%"></td>
		<td style="width:25%"></td>
	</tr>
</table>
<!--- メッセージ表示 --->
<uc:Message ID="message1" runat="server"></uc:Message>