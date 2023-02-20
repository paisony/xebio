<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%-- 
改版履歴
2015/09/16 FSWeb)Y.Tamura 新規作成
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoMenu.aspx.cs" Inherits="Common_BoMenu" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <meta http-equiv="Content-Style-Type" content="text/css">
    <link href="Style/default.css" type="text/css" rel="stylesheet" />
	<meta http-equiv="Content-Script-Type" content="text/javascript"/>
    <script type="text/javascript" src="Js/menu.js"></script>
    <script type="text/javascript" src="Js/jquery.js"></script>
    <title>XEBIO</title>
</head>
<body style="overflow: hidden; background-color: #0296d3;">
    <form id="form1" runat="server">
        <!-- open-close-menu -->
        <div id="oc-menu" class="open-close-menu" >
            <div class="open-close-menu-cont">
                <asp:Repeater ID="MenuCatRep" runat="server" OnItemCommand="MenuCatRep_ItemCommand">
                    <ItemTemplate>
                        <p id="icon-search-menu<%# Container.ItemIndex + 1 %>">
                            <asp:LinkButton runat="server" CssClass="a_menucate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "DISPLAYNAME") %>' ID="MenuCatLnk" />
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="Menu2nd" class="open-close-menu-2nd" runat="server" visible="false">
                    <ul>
                        <asp:DataList ID="MenuPgList" runat="server" OnItemDataBound="MenuPgList_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <a id="MenuPgm1Lnk" class="a_menupg" runat="server"><%# DataBinder.Eval(Container.DataItem, "DISPLAYNAME") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                    </ul>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#menu-frame', window.parent.document).height($(".open-close-menu-2nd").height() < $(".open-close-menu").height() ? $(".open-close-menu").height() : $(".open-close-menu-2nd").height());
            <%-- 2016-07-12 FE)Y.Kawabuchi Update End ST-043
            if ($('#Menu2nd').is(':visible')) {
                $('#menu-frame', window.parent.document).width(415);
            } else {
                $('#menu-frame', window.parent.document).width(207);
            }
            --%>
            if ($('#Menu2nd').is(':visible')) {
                $('#menu-frame', window.parent.document).width(483);
            } else {
                $('#menu-frame', window.parent.document).width(207);
            }
            <%-- 2016-07-12 FE)Y.Kawabuchi Update End ST-043 --%>
        });
    </script>
</body>
</html>
