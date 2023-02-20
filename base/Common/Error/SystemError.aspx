<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%-- 
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemError.aspx.cs" Inherits="SystemError" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>システムエラー</title>
	<link title="default" href="../../Common/style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../../Common/Js/common.js"></script>
	<script type="text/javascript" language="javascript">
			function Close() {
				window.opener = true;
				window.close();
			}
	</script>
</head>
<body onerror="Page_Error">
    <form id="form1" runat="server" onprerender="RenderForm">
        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
        <div>
            <table style="height: 100%;background:#ffffff;" width="100%" id="str-search-01" >
                <colgroup>
                    <col style="width: 20%" />
                    <col style="width: 60%" />
                    <col style="width: 20%" />
                    <col />
                </colgroup>
                <tbody>
                    <tr>
                        <tr>
                            <td colspan="3" style="height:60px;">
                            </td>
                        </tr>
                        <td style="height: 60%"></td>
                        <td>
                            <table style="height: 100%" width="100%" class="inner-02">
                                <colgroup>
                                    <col style="width: 110px" />
                                    <col />
                                    <col />
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <span id="error-01" style="display:block;">
                                                <cc:EncodedLabel ID="ErrorTitleLbl" runat="server"></cc:EncodedLabel></td>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="last"><span class="tbl-hdg"><cc:EncodedLabel ID="ErrorLbl" runat="server" Font-Size="9pt"></cc:EncodedLabel></td></th>
                                        <td class="last">
                                            <cc:EncodedLabel ID="ExceptionName" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="last"><span class="tbl-hdg">
                                            <cc:EncodedLabel ID="MessageLbl" runat="server" Font-Size="9pt"></cc:EncodedLabel></th>
                                        <td class="last">
                                            <cc:EncodedLabel ID="ExceptionMessage" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height:20px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                    <div class="str-btn-search" style="width:100%;text-align:center;">
                                        <asp:Button ID="CloseBtn" CssClass="btn type-01" runat="server" OnClick="CloseBtn_Click" />
                                    <!-- /str-btn-search --></div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td valign="bottom" colspan="3" style="height: 20%">
                            <uc:Footer ID="footer1" runat="server"></uc:Footer>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
    </form>
</body>
</html>
