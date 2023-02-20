<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageDialog.aspx.cs" Inherits="Common.Standard.Page.MessageDialog" %>

<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" Assembly="com.xebio.bo.Common" %>
<%@ Register TagPrefix="std" Namespace="Common.Standard.Web.Control" %>
<%@ Import Namespace="Common.Standard.Message" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="ja">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="Content-Style-Type" content="text/css">
	<adv:NoCache ID="NoCache1" runat="server" />
    <link rel="stylesheet" type="text/css" href="../boStyle/base.css">
    <script type="text/javascript" src="../boJs/jquery.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../boJs/modal.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/KeySafe.js" charset="UTF-8"></script>
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
                <asp:Panel ID="PanelError" runat="server">
                <h1 class="hdg-error-01">
                    <asp:Literal ID="PgNameLiteral" runat="server"></asp:Literal>
                </h1>
                <div style="overflow:auto;height:312px;">
                    <ul class="list-error-01" style="padding-left:1em;">

                        <asp:Repeater ID="RepeaterError" runat="server">
                            <ItemTemplate>
                                <li>
                                    <asp:Label ID="Message" runat="server" Text="<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message) %>"></asp:Label>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <li style="color:#cc0000;font-weight:bold;margin-top:2px;margin-bottom:2px;margin-left:20px;list-style:none;">
					※複数ページに跨るエラーが発生している場合は、遷移先で再度確認を行って下さい。
                </li>
                </asp:Panel>
                
                <asp:Panel ID="PanelInfo" runat="server">
                <h1 class="modal-ttl">確認</h1>
                <div id="modal-cont" style="overflow:auto;">
                    <asp:Repeater ID="RepeaterInfo" runat="server">
                        <ItemTemplate>
                            <p>
                                <asp:Label ID="Message" runat="server" Text="<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message) %>"></asp:Label>
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
