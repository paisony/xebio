<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoMessageDialog.aspx.cs" Inherits="Common.Business.aspx.BoMessageDialog" %>

<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" Assembly="com.xebio.bo.Common" %>
<%@ Register TagPrefix="std" Namespace="Common.Standard.Web.Control" %>
<%@ Import Namespace="Common.Standard.Message" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="ja">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="Content-Style-Type" content="text/css">
	<adv:NoCache ID="NoCache1" runat="server" />
    <link rel="stylesheet" type="text/css" href="../../boStyle/base.css">
    <link rel="stylesheet" type="text/css" href="../../boStyle/parts.css">
    <script type="text/javascript" src="../../boJs/jquery.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../boJs/modal.js" charset="UTF-8"></script>
    <title>#</title>
    <meta name="keywords" content="#" />
    <meta name="description" content="#" />
    <!-- jacascript -->
    <script type="text/javascript" language="javascript">
        function onUnLoad() {
            window.dialogArguments.canOpenRedisplayDialog = true;
        }
    </script>
</head>
<body id="str-modal" style="overflow:hidden; height:inherit;">
    <form id="form1" runat="server" onprerender="RenderForm">
        <div id="wrapper" style="width: 100%;">
            <div id="wrap-modal">
				<!---------------------------------->
				<!--- インフォダイアログ(OKのみ) --->
				<!---------------------------------->
                <asp:Panel ID="PanelInfo" runat="server">
					<h1 class="modal-ttl">確認</h1>
					<div id="modal-info" style="overflow:auto;">
						<asp:Repeater ID="RepeaterInfo" runat="server">
							<ItemTemplate>
								<p>
									<asp:Label ID="Message" runat="server" Text='<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message).Replace("\\n", "<br />") %>'></asp:Label>
								</p>
							</ItemTemplate>
						</asp:Repeater>
					</div>
					<!-- /modal-btn-info -->
					<p class="modal-btn">
						<a id="btn-yes" class="btn type-01 modal" style="margin-right: 0px;" href="#">ＯＫ</a>
					</p>
                </asp:Panel>
				<!---------------------------------->
				<!--- 警告ダイアログ       --------->
				<!---------------------------------->
                <asp:Panel ID="PanelWarn" runat="server">
					<h1 class="modal-ttl">確認</h1>
					<div id="modal-cont" style="overflow:auto;">
						<asp:Repeater ID="RepeaterWarn" runat="server">
							<ItemTemplate>
								<p>
									<asp:Label ID="Message" runat="server" Text='<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message).Replace("\\n", "<br />") %>'></asp:Label>
								</p>
							</ItemTemplate>
						</asp:Repeater>
					</div>
					<!-- /modal-cont -->
					<p class="modal-btn">
						<a id="btn-yes" class="btn type-01 modal" href="#">はい</a>
						<a id="btn-no" class="btn type-01 modal" href="#">いいえ</a>
					</p>
                </asp:Panel>
				<!---------------------------------->
				<!--- 警告ダイアログ(複数) --------->
				<!---------------------------------->
                <asp:Panel ID="PanelWarnMulti" runat="server">
					<h1 class="modal-ttl">確認</h1>
					<div id="modal-warnlist" style="overflow:auto;height:254px;">
						<asp:Repeater ID="RepeaterWarnMulti" runat="server">
							<ItemTemplate>
								<p>
									<asp:Label ID="Message" runat="server" Text='<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message).Replace("\\n", "<br />") %>'></asp:Label>
								</p>
							</ItemTemplate>
						</asp:Repeater>
					</div>
					<!-- /modal-cont -->
					<p class="modal-btn">
						<a id="btn-yes" class="btn type-01 modal" href="#">はい</a>
						<a id="btn-no" class="btn type-01 modal" href="#">いいえ</a>
					</p>
                </asp:Panel>


                <!-- /wrap-modal -->
            </div>
    </form>
</body>
</html>
