<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%-- 
改版履歴
2015/09/16 FSWeb)Y.Tamura 新規作成
--%>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link title="default" href="Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Common/Js/menu.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
    <script type="text/javascript" language="javascript">
	<!--
    function initLogin() {
        var src = "Login.aspx";
        if (1 < window.location.search.length) {
            // 最初の1文字 (?記号) を除いた文字列を取得する
            var query = window.location.search.substring(1);
            src = "Login.aspx?" + query;
        }
        document.getElementById('login').src = src;
    }
    // -->
	</script>
    <title>XEBIO</title>
</head>
<body onload="initLogin();">
    <div>
        <iframe id="login" style="width:100%; height:100%;" marginwidth="0" marginheight="0"
            frameborder="0" scrolling="no"></iframe>
    </div>
</body>
</html>
