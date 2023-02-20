<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
 2012/12/07 WT)K.Banno 変更管理[OM-0092]
 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 2015/09/16 FSWeb)Y.Tamura ログアウト・×ボタン対応
 --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="Common_Header" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head runat="server">
	<title>ヘッダー</title>
	<meta http-equiv="Refresh" content="3000" />
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <link href="Style/default.css" type="text/css" rel="stylesheet" />
    <link href="Style/menu.css" type="text/css" rel="stylesheet" />
    <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/menu.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript" src="../Common/Js/jquery.js"></script>
    <%-- TODO yusy header-tmp.js一時追加 --%>
	<script type="text/javascript" src="../Common/Js/header-tmp.js"></script>
	<script type="text/javascript">
		var WinCloseCheck = ""
		function init() {
			document.getElementById("CANCEL").style.visibility = "hidden";
			document.getElementById("END").style.visibility = "hidden";
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
		function winCloseBtn(check) {
			WinCloseCheck = check;
			$("#LogOutBtn").click();
		}

	    //2015/09/16 FSWeb)Y.Tamura ログアウト・×ボタン対応 Start
        //×ボタン押下時に業務画面を閉じる
		//window.onbeforeunload = function () {
		//    var winClose = findWinClose();
		//    if (!winClose) {
		//        g_canWindow();
		//    }
		//    winStorageClear();
		//}
		parent.addEventListener("beforeunload", function(){
		    //var winClose = findWinClose();
		    //if (!winClose) {
		        g_canWindow();
		    //}
		    winStorageClear();
		}, false);	
	    //2015/09/16 FSWeb)Y.Tamura ログアウト・×ボタン対応 End

		// TODO yusy LogoutConfirm処理を一旦header-tmp.jsに移動
		/* ログオフ処理 */
		//function LogoutConfirm()
		//{
		//	window.localStorage.setItem("clsBtn", "1");
		//	document.getElementById("CANCEL").value = "0";
		//	if (window.localStorage.getItem("LogoffFunctionID") == null || localStorage.getItem("LogoffFunctionID").length < 5) {
		//		var winClose = findWinClose();
		//		if (WinCloseCheck == "1"){
		//			var result = LogoutCheck("1", winClose)
		//			if(result) {
		//				document.forms[0].target = "_top";
		//				winStorageClear(); 
		//				return true;
		//			} else {
		//				document.getElementById("CANCEL").value = "1";
		//				return false;
		//			}
		//		} else {
		//			if (WinCloseCheck != "9"){
		//				var result = LogoutCheck("1", winClose)
		//				if(result) {
		//					document.forms[0].target = "_top";
		//					winStorageClear(); 
		//					return true;
		//				} else {
		//					return false;
		//				}
		//			} else {
		//				document.getElementById("END").value = "9";
		//			}
		//		}
		//	} else {
		//		// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update START ---------------
		//		if (WinCloseCheck != "9"){
		//			var url = window.localStorage.getItem("functionUrl") 
		//												+ "?loginId=" + window.localStorage.getItem("loginId")
		//												+ "&comId=" + window.localStorage.getItem("comId")
		//												+ "&solutionId=" + window.localStorage.getItem("LoginSolutionID")
		//												+ "&functionId=" + window.localStorage.getItem("LogoffFunctionID")
		//												+ "&certId=" + window.localStorage.getItem("LogoffFunctionID");
		//			var returnValue = window.open(url , this, 'dialogWidth:500px;dialogHeight:180px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
		//			try {
		//				if (returnValue[0] != null && returnValue[0] == "ok"){
		//					document.forms[0].target = "_top";
		//					winStorageClear(); 
		//					window.localStorage.setItem("LogoffFunctionIDOK", "ok");
		//					window.open('../Login.html?FkeyCheck=ok','_top','','');
		//					return true;
		//				}
		//				else {
		//					document.getElementById("CANCEL").value = "1";
		//					return false;
		//				}
		//			} catch (e) {
		//				document.getElementById("CANCEL").value = "1";
		//				return false;
		//			}
		//		}
		//		// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update  END  ---------------
		//	}
		//}
    </script>
</head>
<body onload="init();" style="margin: 0px; padding: 0px;" onscroll="window.document.body.scrollTop = 0;">
	<form id="form1" runat="server" onprerender="RenderForm">
        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
		<!-- header -->
		<div id="top-header">
			<p class="logo"><img src="boImages/logo.png" height="49" width="98" alt="XEBIO"></p>
			<div class="inner">
				<div class="header-utility-01">
					<h1 class="hdg-lv1-01">BO System</h1>
					<p class="admin-date"><cc:EncodedLabel ID="DateLbl" runat="server"></cc:EncodedLabel></p>
					<p class="greeting"><cc:EncodedLabel ID="UserNameLbl" runat="server"></cc:EncodedLabel></p>
				</div><!-- /header-utility-01 -->
				<div class="header-utility-02">
					<p class="btn-logout"><asp:ImageButton ID="LogOutBtn" runat="server" CausesValidation="False" ImageUrl="boImages/icon-logout2.png"
							OnClick="LogOutBtn_Click" OnClientClick="return LogoutConfirm();"  Height="37" Width="40" AlternateText="業務終了"></asp:ImageButton></p>
				</div><!-- /header-utility-02 -->
                    <asp:TextBox ID="CANCEL" Columns="1" runat="server"/>
					<asp:TextBox ID="END" Columns="1" runat="server"/>
			</div><!-- /inner -->
		</div><!-- /header -->
        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
	</form>
</body>
</html>
