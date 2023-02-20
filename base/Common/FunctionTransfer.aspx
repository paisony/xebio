<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FunctionTransfer.aspx.cs"
	Inherits="Common_FunctionTransfer" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Now Loading</title>

	<script language="javascript" type="text/javascript">
		<!--
		function init()
		{	try
			{
				var baseWinName = '<%# windowName %>';
				var mainWinName;
				var funcWinName;
		        if (window.opener && window.opener.parent)
                {
                    mainWinName = window.opener.parent.name;
                }
                else
                {
		            mainWinName = window.name;
                }
                
		        if ('<%# windowOpenFlag %>' == '0')
                {
                    funcWinName = 'main';
                }
                else if (baseWinName.length == 0 || baseWinName == '_blank')
                {
                    funcWinName = '_blank';
                }
                else
                {
                    funcWinName = mainWinName + '<%# solutionId %>' + baseWinName;
                }
	            //機能ウィンドウを開く
	            openFunction('<%# solutionId %>', '<%# functionId %>', funcWinName, '<%# windowStyle %>');
                close();
            }
            catch (e)
            {
                window.open('index.aspx');
                close();
            }
        }
		
		//ポップアップブロック対応----------------------------------------------------------
        //機能を起動する。
        function openFunction(solutionId,functionId,winName,winStyle)
        {        	
            try
            {
	            var url = "PageTransfer.aspx?solutionId=" + solutionId + "&functionId=" + functionId + "&eventParams=<%# eventParams %>";
                if (window.opener && window.opener.parent)
                {
                    if (winName == 'main')
                    {
                        if (window.opener.name == 'main' && window.opener.parent.main)
                        {
                        	window.opener.parent.main.location = url;
                        }
                        else
                        {   
                        	updateWin(url, winName, winStyle);
                        }
                    }
                    else
                    {
                        updateWin(url, winName, winStyle);
                    }            
                }
                else
                {
                    updateWin(url, winName, winStyle);
                }
            }
            catch (e)
            {
                window.open('index.aspx');
                close();
            }
        }

        function updateWin(url, name, style)
        {
            if (name == '_blank' || name== 'main')
            {
                if (style.length == 0)
                {
                    //画面表示(winName=mainの場合は別画面表示無効)
                    window.open(url,name);
                }
                else
                {
                    //画面表示(winName=mainの場合は別画面表示無効)
                    window.open(url,name,style);
                }
                return;
            }

			var w;
			var flag;
			if (style.length == 0)
			{
				//画面表示(winName=mainの場合は別画面表示無効)
				w = window.open('',name);
			}
			else
			{
				//画面表示(winName=mainの場合は別画面表示無効)
				w = window.open('',name,style);
			}

			try
			{
                //HOSTが異なる場合ここでエラーが発生するためtryで囲う
                flag = w.location.href == "about:blank";
			}
			catch (e)
			{
                //例外が発生した場合既にウィンドウが開いていると判断する
                flag = false;
			}

			if(flag)
			{
				w.location.href = url;
			}
			else
			{
			    w.focus();
			}
		}

        function sleep(timeWait)
        {
            var timeStart = new Date().getTime();
            var timeNow = new Date().getTime();
            while( timeNow < (timeStart + timeWait ) )
            {
                timeNow = new Date().getTime();
            }
            return;
        }
		//-->
	</script>

	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>

</head>
<body onload="init()">
	<form>
	<cc:EncodedLabel ID="Label1" Style="z-index: 101; left: 72px; position: absolute;
		top: 16px" Font-Bold="True" ForeColor="Gray" runat="server" Font-Size="18px">Now Loading ...</cc:EncodedLabel>
	</form>
</body>
</html>
