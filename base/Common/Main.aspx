<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Common_Main" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns:t="urn:schemas-microsoft-com:time">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS" />
	<meta http-equiv="Content-Style-Type" content="text/css" />
	<meta http-equiv="Pragma" content="no-cache" />
	<title><%# GetTitle() %></title>
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
	<script type="text/javascript" src="../Common/Js/menu.js"></script>
	<style type="text/css">
		body{
		  margin:0;
		}
		TD{
		  font-size : 14px;
		  font-family : "MS UI Gothic";
		  line-height : 140%;
		}.time{
		  behavior: url(#default#time2);
		}
	</style>

	<script type="text/javascript" language="javascript">
	<!--
		var flag = 0;
		function iFrameOpen(menuHeight)
		{
			if(flag ==0)
			{
			   tif2.from = "35px";
			   tif2.to = menuHeight;
			   main_shrink.from = getWindowHeight() - 95;
			   main_shrink.to = getWindowHeight() - 60 - menuHeight;
			   flag = 1;
			   tif2.beginElement();
			   main_shrink.beginElement();
			 }
		}

		function iFrameClose(menuHeight)
		{
			if(flag == 1)
			{

			   tif1.from = menuHeight;
			   tif1.to = "35px";
			   main_expand.from = getWindowHeight() - 60 - menuHeight;
			   main_expand.to = getWindowHeight() - 95;
			   flag = 0;
			   tif1.beginElement();
			   main_expand.beginElement();
			  }
		}

		function initClose(menuHeight)
		{
			if (document.getElementById('init_menu'))
			{
				init_menu.from = menuHeight;
				init_menu.to = "35px";
				init_main.from = getWindowHeight() - 60 - menuHeight;
				init_main.to = getWindowHeight() - 95;
				//init_menu.beginElement();
				//init_main.beginElement();
		   }
		}

		function resizeWindow()
		{
			var menuHeight = document.getElementById('iframe').offsetHeight;
			tif1.from = menuHeight;
			tif1.to = menuHeight;
			main_expand.from = getWindowHeight() - 60 - menuHeight;
			main_expand.to = getWindowHeight() - 60 - menuHeight;
			tif1.beginElement();
			main_expand.beginElement();
		}

		function getWindowHeight()
		{
			return document.body.clientHeight;
		}

		function getWindowWidth()
		{
			return document.body.clientWidth;
		}

		function init()
		{
			document.onkeydown=fnKey;
			window.onunload=g_onUnLoad;

			document.getElementById('iframe').style.height = 35;
			document.getElementById('main').style.height = getWindowHeight() - 95;

			var Width  = window.localStorage.getItem("LoginWidthSize");
			var Height = window.localStorage.getItem("LoginHeightSize");
			var Positioning = window.localStorage.getItem("LoginPositioning");
			var TopPosition = window.localStorage.getItem("LoginTopPositionAdjustment");
			var Top =window.localStorage.getItem("LoginPositionTop");
			var Left =window.localStorage.getItem("LoginPositionLeft");
			var SolutionID = window.localStorage.getItem("LoginSolutionID");
			var FunctionID = window.localStorage.getItem("LoginFunctionID");
			var winStyle = "";
			if (FunctionID != null && FunctionID != "null" && FunctionID.length >= 8 )
			{
				var Toolbar = "no";
				var Location = "no";
				var Directories = "no";
				var Menubar = "no";
				var Scrollbars = "no";
				var Status = "yes";
				var Resizable = "no";
				if (Positioning != null && Positioning != "null" &&  Positioning == "true")
				{
					if (TopPosition != null && TopPosition != "null")
					{
						Top = (screen.height - Height - TopPosition) / 2;
						if (Top < 0)
						{
							Top = 0;
						}
						Left = (screen.width - Width) / 2;
						winStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left="+ Left
									+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
									+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
					}
					else
					{
						if (Top != null && Top != "null")
						{
							winStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left="+ Left
										+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
										+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
						}
						else
						{
							winStyle = ",width=" + Width + ",height=" + Height
										+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
										+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
						}
					}
				}
				else
				{
							winStyle = ",width=" + Width + ",height=" + Height
										+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
										+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
				}
				
				if (FunctionID == "XO999P01")
				{
					Status = "no";
					Top = (screen.height - Height) / 2 + Height / 2 - 50;
					Left = (screen.width - Width) / 2  + Width  / 2 -100;
					winStyle = ",width=200,height=100" + ",top=" + Top + ",left="+ Left
								+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
								+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
				}
				
				var windowname = SolutionID + "_" + FunctionID;
				var url = "PageTransfer.aspx?solutionId=" + SolutionID + "&functionId=" + FunctionID;
				updateWin(url, windowname, winStyle);
			}
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

		function loadFunction(solutionId,functionId)
		{
			var url = "PageTransfer.aspx?solutionId=" + solutionId + "&functionId=" + functionId;
			document.getElementById('main').src = url;
		}

		function ssoFunction(solutionId,functionId,eventParams)
		{
			var url = "PageTransfer.aspx?solutionId=" + solutionId + "&functionId=" + functionId + "&eventParams=" + eventParams;
			document.getElementById('main').src = url;
		}

		function loadBizMenu(solutionId,functionViewId)
		{
			var url = "BizMenu.aspx?solutionId=" + solutionId + "&functionViewId=" + functionViewId;
			document.getElementById('main').src = url;
		}

		function loadMenuLink(solutionId,functionViewId)
		{
			var url = "MenuLink.aspx?solutionId=" + solutionId + "&functionViewId=" + functionViewId;
			document.getElementById('main').src = url;
		}
		function loadMenuNotiong()
		{
			var url = "MenuNothing.html";
			document.getElementById('main').src = url;    
		}

	//-->
	</script>
	<?IMPORT namespace="t" implementation="#default#time2">

</head>
<body onload="init();" onresize="resizeWindow();">
        <iframe id="header" src="header.aspx" style="width: 100%; height: 60px" frameborder="0"
            marginwidth="0" marginheight="0" scrolling="no"></iframe>
        <br/>
        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
        <iframe id="iframe" src="menuTransfer.aspx" style="width: 100%;" frameborder="0"
            marginwidth="0" marginheight="0" scrolling="no"></iframe>
        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
        <br/>
        <iframe id="main" src="Nothing.html" style="width: 100%; height:100%" marginwidth="0" marginheight="0"
            frameborder="0" scrolling="no"></iframe>
        <br/>
        <t:animate id="tif1" targetelement="iframe" attributename="height" begin="indefinite"
            from="" to="" dur=".2s" autoreverse="false" fill="freeze" />
        <t:animate id="tif2" targetelement="iframe" attributename="height" begin="indefinite"
            from="" to="" dur=".2s" autoreverse="false" fill="freeze" />
        <t:animate id="main_shrink" targetelement="main" attributename="height" begin="indefinite"
            from="" to="" dur=".2s" autoreverse="false" fill="freeze" />
        <t:animate id="main_expand" targetelement="main" attributename="height" begin="indefinite"
            from="" to="" dur=".2s" autoreverse="false" fill="freeze" />
        <t:animate id="init_menu" targetelement="iframe" attributename="height" from="" to=""
            begin="" dur=".5s" />
        <t:animate id="init_main" targetelement="main" attributename="height" from="" to=""
            begin="" dur=".5s" />
</body>
</html>
