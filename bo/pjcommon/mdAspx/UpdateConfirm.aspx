<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateConfirm.aspx.cs" Inherits="pjcommon_mdAspx_UpdateConfirm"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" Assembly="com.xebio.bo.Common" %>
<%@ Register TagPrefix="std" Namespace="Common.Standard.Web.Control" %>
<%@ Import Namespace="Common.IntegrationMD.Util" %>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title id="Windowtitle" runat="server"></title>
		<adv:ContentType ID="ContentType1" runat="server" />
		<!--- キャッシュの無効化設定 --->
		<adv:NoCache ID="NoCache1" runat="server" />
		<!-- link css -->
		<!-- jacascript -->
		<script type="text/javascript" language="javascript">
			function onLoad() {
			}
			function onUnLoad() {
			}
		</script>
		<!-- スクリプトのインポート -->
		<std:SetCustomHeader ID="SetHeader1" runat="server" />
	</head>
	<body style="border:solid 1px #373c4f;width:99%;height:99%;background-color:#dddddd;">
		<form id="form1" runat="server" onprerender="RenderForm">
			<div id="wrapper" style="width:580px;padding:5px 15px 0px 5px;">
				<%--  タイトル表示 --%>
			    <div id="header" style="height:30px;width:561px; border:solid 1px black;text-align:left;background-color:#373c4f;color:#ffffff;font-weight:bold;font-size:15px; white-space: nowrap;">
			        <div style="font-size:15px;font-weight:bold;padding:5px 15px 5px">
                        <asp:Literal ID="PgNameLiteral" runat="server"></asp:Literal>
			        </div>
			    </div>
			    <%-- データの表示 --%>
			    <div  style="height:280px;overflow:auto">
			        <div id ="container" style="width:561px;border-left:solid 1px black;border-right:solid 1px black;">
				        <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="OnItemCreated" >
			                <ItemTemplate>
	                            <div style="background-color:White;border-bottom:solid 1px black;padding-left:20px;">
	                            	 <p>
				                          <asp:Label ID="Message" runat="server" Font-Size="13px" Text="<%# Server.HtmlEncode(((UpdateConfirmMessageVO)Container.DataItem).Message) %>"></asp:Label>
	                                 </p>
	                            </div>
			                </ItemTemplate>
				        </asp:Repeater>
			        </div>
			    </div>
                <%-- 閉じるボタン --%>
                <div id ="footer" style="height:10%;width:98%;text-align:right">
                    <input name="Input" type="reset" style="position:relative;width:80px; padding:1px 20px;" id="Reset2" onclick="return closeWindow()" value="閉じる" runat="server"/>
                </div>
			</div>
		</form>
	</body>
</html>