<%-- グイン・メニュー画面変更 --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Common_Login" %>

<%@ Register TagPrefix="uc" TagName="TopInfo" Src="Usercontrol/TopInformation.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>ＢＯシステム　ログイン</title>
    <link href="Style/login.css" type="text/css" rel="stylesheet" />
    <link href="Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Common/Js/common.js"></script>
    <script type="text/javascript" src="../Common/Js/menu.js"></script>
    <script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
    <script type="text/javascript">
	<!--
    function init() {
        if (window.localStorage.getItem("LogoffFunctionID") == null || window.localStorage.getItem("LogoffFunctionID").length < 5) {
            window.localStorage.setItem("clsBtn", "0");
            winStorageClear();
            document.onkeydown = fnKey;
        }
    }
    function fnKey() {
        var keyCode = event.keyCode;	// キーコードを取得
        if (112 <= keyCode && keyCode <= 123) {
            event.keyCode = 0;
            event.returnValue = false;
            return false;
        }
        // CTRL+R キャンセル
        if (event.ctrlKey && keyCode == 82) {
            //alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
            //alert(getQuiQplusMessage("L995"));
            return false;
        }
        // CTRL+N 新規画面（同一セッションID）
        if (event.ctrlKey && keyCode == 78) {
            //alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
            //alert(getQuiQplusMessage("L995"));
            return false;
        }
        // ALT+→ ALT+← ALT+HOME キャンセル
        if (event.altKey && (keyCode == 37 || keyCode == 39 || keyCode == 36)) {
            if (keyCode == 36) alert("このショートカット操作は無効です");
            //alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
            //alert(getQuiQplusMessage("L995"));
            return false;
        }
        // CTRL+'+' CTRL+"-" キャンセル
        if (event.ctrlKey && (keyCode == 187 || keyCode == 189)) {
            //alert("ブラウザの機能による画面拡大・縮小は禁止です。");
            //alert(getQuiQplusMessage("L996"));
            return false;
        }
        // CTRL+Enter キャンセル
        if (event.ctrlKey && (keyCode == 13)) {
            //alert("ブラウザの機能による最大化は禁止です。");
            //alert(getQuiQplusMessage("L994"));
            return false;
        }

    }
    /* 二重ログインエラー処理 */
    function DuplicationLoginError(mess) {

        //"既にログインされています。強制的にログインしますか？"
        var returnValue = window.open('Confirm.aspx?pgId=Dup', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
        try {
            if (returnValue[0] != null && returnValue[0].length > 0) {
                document.all.CompulsoryLoginBtn.click();
                return true;
            }
            else {
                document.all.CancelLoginBtn.click();
                return false;
            }
        } catch (e) {
            return false;
        }
    }
    function end() {
        window.localStorage.setItem("LoginSolutionID", GetCookie("LoginSolutionID"));
        window.localStorage.setItem("LoginFunctionID", GetCookie("LoginFunctionID"));
        window.localStorage.setItem("LogoffFunctionID", GetCookie("LogoffFunctionID"));
        window.localStorage.setItem("loginId", GetCookie("loginId"));
        window.localStorage.setItem("comId", GetCookie("comId"));
        window.localStorage.setItem("functionUrl", GetCookie("functionUrl"));

        window.localStorage.setItem("LogoffClosingFunctionIDs", GetCookie("LogoffClosingFunctionIDs"));
    }
    function sleep(timeWait) {
        var timeStart = new Date().getTime();
        var timeNow = new Date().getTime();
        while (timeNow < (timeStart + timeWait)) {
            timeNow = new Date().getTime();
        }
        return;
    }

	// -->
    </script>
    <style type="text/css">
        .style1 {
            width: 263px;
        }

        .style2 {
            width: 41px;
        }
    </style>
</head>
<body onload="init();" onunload="end();">
    <form id="form1" runat="server" onprerender="RenderForm">
        <div id="wrap">
            <!-- ■ヘッダ領域 -->
            <div id="header">
                <p class="logo">
                    <img src="boImages/logo.png" height="49" width="98px" alt="XEBIO">
                </p>
                <div class="inner">
                    <div class="header-utility-01">
                        <h1 class="hdg-lv1-01">BO System</h1>
                    </div>
                    <!-- /header-utility-01 -->
                </div>
                <!-- /inner -->
            </div>
            <!-- /header -->
            <div id="login-main">
                <div id="side">
                    <div id="side-cont">
                        <div id="login-id">
                            <p>
                                <cc:EncodedLabel ID="LoginIDLbl" CssClass="loginLbl" runat="server">ログインID</cc:EncodedLabel>
                            </p>
                            <asp:TextBox ID="LoginIDBox" runat="server" Columns="15"></asp:TextBox>
                        </div>
                        <!-- /login-id -->
                        <div id="login-password">
                            <p>
                                <cc:EncodedLabel ID="PasswordLbl" CssClass="loginLbl" runat="server">パスワード</cc:EncodedLabel>
                            </p>
                            <asp:TextBox ID="PasswordBox" runat="server" Columns="15" TextMode="Password"></asp:TextBox></p>
                        </div>
                        <!-- /login-password -->
                        <p id="login-btn">
                            <asp:Button ID="LoginBtn" runat="server"
                                OnClick="LoginBtn_Click" CssClass="btn type-03" Text="ログイン" Font-Size="Medium"></asp:Button>
                        </p>
                        <p>
                            <cc:EncodedLabel ID="ErrorLbl" runat="server" CssClass="loginerror" Visible="False"></cc:EncodedLabel>
                            <asp:Button ID="CompulsoryLoginBtn" runat="server" CssClass="hiddenbtn" Text=""
                                OnClick="CompulsoryLoginBtn_Click" />
                            <asp:Button ID="CancelLoginBtn" runat="server" CssClass="hiddenbtn" Text="" OnClick="CancelLoginBtn_Click" />
                        </p>
                        <asp:Label ID="DisplayContentLbl" runat="server"></asp:Label>
                    </div>
                    <!-- /side-cont -->
                </div>
                <!-- /side -->
                <div id="login-cont">
                    <uc:TopInfo ID="Topinfo" runat="server" scrolling="yes"></uc:TopInfo>
                </div>
                <!-- /login-cont -->
            </div>
            <!-- /login-main -->
        </div>
        <!-- /wrap -->
    </form>
</body>
</html>
