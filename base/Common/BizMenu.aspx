<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%-- 
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BizMenu.aspx.cs" Inherits="Common_BizMenu" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>BizMenu</title>
    <link href="Style/bizmenu.css" type="text/css" rel="stylesheet" />
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <link href="Style/default.css" type="text/css" rel="stylesheet" />
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
	<script type="text/javascript" src="../Common/Js/menu.js"></script>
	<meta http-equiv="Content-Script-Type" content="text/javascript"/>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript">
	<!--
		function init()
		{
			document.onkeydown=fnKey;
		}

		function fnKey() { 
			var keyCode=event.keyCode;	// キーコードを取得
			if(112<=keyCode && keyCode<=123) {
				event.keyCode = 0;
				event.returnValue = false;
				return false;
			}
			// CTRL+R キャンセル
			if (event.ctrlKey && keyCode==82)
			{
				//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
				//alert(getQuiQplusMessage("L995"));
				return false;
			}
			// CTRL+N 新規画面（同一セッションID）
			if (event.ctrlKey && keyCode==78)
			{
				//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
				//alert(getQuiQplusMessage("L995"));
				return false;
			}
			// ALT+→ ALT+← ALT+HOME キャンセル
			if (event.altKey && (keyCode==37 || keyCode==39 || keyCode==36))	
			{
				if(keyCode==36) alert("このショートカット操作は無効です");
				//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
				//alert(getQuiQplusMessage("L995"));
				return false;
			}
			// CTRL+'+' CTRL+"-" キャンセル
			if (event.ctrlKey && (keyCode==187 || keyCode==189))
			{
				//alert("ブラウザの機能による画面拡大・縮小は禁止です。");
				//alert(getQuiQplusMessage("L996"));
				return false;
			}
			// CTRL+Enter キャンセル
			if (event.ctrlKey && (keyCode==13))
			{
				//alert("ブラウザの機能による最大化は禁止です。");
				//alert(getQuiQplusMessage("L994"));
				return false;
			}
			// BACKSPACE キャンセル
			if (keyCode==8)
			{
				return false;
			}
		}
		function overCate(id){
			document.getElementById(id).style.background="url(Images/BizMenu/main_menu_btn_on.jpg)";
		}
		function outCate(id){
			document.getElementById(id).style.background="url(Images/BizMenu/main_menu_btn_off.jpg)";
		}
		function overPg(id){
			document.getElementById(id).style.background="url(Images/BizMenu/pg_btn_on.gif)";
		}
		function outPg(id){
			document.getElementById(id).style.background="url(Images/BizMenu/pg_btn_off.gif)";
		}
		
		function clickLink(id)
		{
			document.getElementById(id).click();
		}
	// -->
	</script>

    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body onload="init()">
    <form id="form1" runat="server">
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <div id="wrap">
        <div id="top-main">
			<div id="top-side" style="overflow-y: auto;">
                <ul>
                <asp:Repeater ID="MenuCatRep" runat="server" OnItemCommand="MenuCatRep_ItemCommand">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton runat="server" CssClass="a_menucate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "DISPLAYNAME") %>' ID="MenuCatLnk" />
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
				<ul>
					<asp:LinkButton ID="lbMdMenu" runat="server" OnClick="lbMdMenu_Click">店舗MDメニュー</asp:LinkButton>
				</ul>
			</div><!-- top-side -->
			<div id="top-cont">
				<div class="tab-li clearfix">
                    <ul>
                        <asp:Repeater ID="MenuSubCatRep" runat="server" OnItemCommand="MenuSubCatRep_ItemCommand">
                            <ItemTemplate>
                            <li>
                                <asp:LinkButton runat="server" CssClass="a_menusubcate" Style="text-align: center;"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' Text='<%# DataBinder.Eval(Container.DataItem, "DISPLAYNAME") %>'
                                    ID="MenuSubCatLnk" />
                            </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
				</div>
				<div class="tab-cont clearfix">
				    <ul>
                        <asp:DataList ID="MenuPgList" runat="server" RepeatColumns="3" ShowFooter="False"
                            RepeatDirection="Horizontal" ShowHeader="False" CellPadding="12" OnItemDataBound="MenuPgList_ItemDataBound">
                            <ItemTemplate>
                                <li runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "VISIBLE") %>'>
                                    <a ID="MenuPgm1Lnk" class="a_menupg" runat="server"><%# DataBinder.Eval(Container.DataItem, "DISPLAYNAME") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                    </ul>
                </div>
			</div><!-- /top-cont -->
		</div><!-- /top-main -->
	</div><!-- /wrap -->
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
    </form>
</body>
</html>
