<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%--
	改版履歴
    2012/03/16 WT)Banno OT1障害対応[QA-0664]
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageTransfer.aspx.cs" Inherits="Common_PageTransfer" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Now Loading</title>

    <script language="javascript" type="text/javascript">
		<!--
		function init()
		{
			window.focus();
			document.forms[0].action = "<%# url %>";
			document.forms[0].submit();
		}
		function error()
		{
			var errOperate2 = "<%# errOperate2 %>";
			if(errOperate2.length > 0)
			{
				//"オンライン停止中ため起動できません。ログオフして下さい。"
				var returnValue2 = window.open('Confirm.aspx?pgId=' + 'Opr2' , this
					,'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
				try {
					if (returnValue2[0] != null && returnValue2[0].length > 0){
						window.close();
						return true;
					}
					else {
						window.close();
						return false;
					}
				} catch (e) {
					window.close();
					return false;
				}
				window.close();
			}
			var errOperate = "<%# errOperate %>";
			if(errOperate.length > 0)
			{
				//"運用時間外のため起動できません。ログオフして下さい。"
				var returnValue = window.open('Confirm.aspx?pgId=' + 'Opr' , this
					,'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
				try {
					if (returnValue[0] != null && returnValue[0].length > 0){
						window.close();
						return true;
					}
					else {
						window.close();
						return false;
					}
				} catch (e) {
					window.close();
					return false;
				}
				window.close();
			}
			var errSession = "<%# errSession %>";
			if(errSession.length > 0)
			{
				//"セッションエラーのため起動できません。ログオフして下さい。"
				var returnValue = window.open('Confirm.aspx?pgId=' + 'Sess' , this
					,'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
				try {
					if (returnValue[0] != null && returnValue[0].length > 0){
						window.close();
						return true;
					}
					else {
						window.close();
						return false;
					}
				} catch (e) {
					window.close();
					return false;
				}
				window.close();
			}
		}
		//-->
    </script>

	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body onload="init()" onunload="error()">
	<form method="<%# method %>">
		<table style="width:200px;height:100px;">
			<tr>
				<td style="width:30px;text-align:left;height:50px;">
					<asp:Image ID="WaitImg" runat="server" ImageAlign="left"></asp:Image>
				</td>
				<td style="width:170px;text-align:left">
					<asp:label id="NowLoading" runat="server" Style="z-index: 101;" Font-Bold="True" ForeColor="Gray" Font-Size="14px">Now Loading ...</asp:label>
				</td>
			</tr>
			<tr>
				<td style="width:30px;text-align:left;height:50px;">
					<cc:EncodedLabel Style="z-index: 101; left: 72px; position: absolute; top: 16px;"
						Font-Bold="True" ForeColor="Gray" runat="server" Font-Size="18px"></cc:EncodedLabel>
				</td>
			</tr>
		</table>
		<asp:Repeater ID="hiddenRepeater" runat="server">
			<ItemTemplate>
				<input type="hidden" name='<%# DataBinder.Eval(Container.DataItem, "name") %>' value='<%# DataBinder.Eval(Container.DataItem, "value")%>'>
			</ItemTemplate>
		</asp:Repeater>
	</form>
</body>
</html>