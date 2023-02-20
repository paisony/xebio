<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarnConfirm.aspx.cs" Inherits="pjcommon_mdAspx_UpdateConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" Assembly="com.xebio.bo.Common" %>
<%@ Register TagPrefix="std" Namespace="Common.Standard.Web.Control" %>
<%@ Import Namespace="Common.IntegrationMD.Util" %>
<%@ Import Namespace="Common.IntegrationMD.Import" %>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title id="Windowtitle" runat="server"></title>
		<adv:ContentType ID="ContentType1" runat="server" />
		<!--- キャッシュの無効化設定 --->
		<adv:NoCache ID="NoCache1" runat="server" />
		<!-- link css -->
		<!-- jacascript -->
		<script type="text/javascript" language="javascript">
		    function fi(state){
    		    var parent = window.dialogArguments;
		    
		        if(state === true){
		            var parent = window.dialogArguments;
		            parent.warning.go();
		        }else{
		            parent.warning.importStatusChange();
		        }
		    }
			function onLoad() {
			}
			function onUnLoad() {
			}
		</script>
		<!-- スクリプトのインポート -->
		<std:SetCustomHeader ID="SetHeader1" runat="server" />
	</head>
	<body style="border:solid 1px blue;width:99%;height:99%;">
		<form id="form1" runat="server" onprerender="RenderForm">
	        <div id="wrapper" style="width:100%;padding:5px 15px 0px 5px;">
			    <%--  件数表示 --%>
                <div id="header" style="height:30px;width:98%;margin-bottom:15px;background:url(../images/bg_numberitems_warn.gif) repeat left top;">
	                 <div style="height:30px;padding:5px 10px;color:#ffffff;font-weight:bold;font-size:15px; white-space: nowrap; ">
	                    <asp:Literal ID="PgNameLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div  style="height:265px;width:98% ; overflow:auto">
        	        <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="OnItemCreated" >
                        <ItemTemplate>
                            <div style="height:auto; text-align:left; padding-left:20px;white-space: nowrap">
	                            <asp:Label ID="Message" runat="server" Font-Size="13px" Text="<%# Server.HtmlEncode(((ErrInfoVo)Container.DataItem).Msg) %>"></asp:Label>
                            </div>
                        </ItemTemplate>
	                </asp:Repeater>
	            </div>
                <%-- ボタン --%>
                <div style="height:35px ;text-align:right;padding:1px 10px">
                    <input name="Input" type="button" style="padding:1px 10px;text-align:center" id="Reset1" onclick="fi(true); window.close();"  runat="server"/>                    
                    <input name="Input" type="button" style="padding:1px 10px;text-align:center" id="Reset2" onclick="fi(false);window.close();"  runat="server"/>
                </div>        
		    </div>
		</form>
	</body>
</html>